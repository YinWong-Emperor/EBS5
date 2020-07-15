Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class clsConTransMaintenanceFixedExRate

    Protected Friend Function FncGetEndPeriod() As Date
        Return CDate(GFncRtnDS(GSCnLiqConn, "select t2_date from IBSSTTXNDATE").Tables(0).Rows(0).Item("t2_date"))
    End Function


    Protected Friend Function FncLoadClient(Optional ByVal group As String = "") As DataTable
        If group = "" Then
            Return GFncRtnDS(GSCnLiqConn, "select distinct clt_code from STCLTMASTER order by clt_code").Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, "SELECT clt_code FROM contran WHERE list_name = '" & group & "' ORDER BY seq_no", "groupclientlist").Tables(0)
        End If
    End Function
    Protected Friend Function FncLoadGroup() As DataTable
        Return GFncRtnDS(GSCnSqlConn, "SELECT DISTINCT list_name FROM contran order by list_name").Tables(0)
    End Function
    Protected Friend Function FncSave(ByVal group As String, ByVal client As ListBox) As Boolean
        Dim trans As SqlTransaction = Nothing
        Try
            trans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, trans, "delete from contran where list_name = '" & group & "'")
        Catch ex As Exception
            Exit Try
        End Try
        Dim str As String = ""
        For i As Integer = 0 To client.Items.Count - 1
            Try
                str = "insert into contran Values('" & group & "', '" & client.Items(i).ToString.Trim & "', " & i + 1 & ")"
                GFncRunSQL(GSCnSqlConn, trans, str)
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (trans IsNot Nothing) Then
                        trans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
        Next
        trans.Commit()
    End Function

    Private Sub dropTempTable(ByVal conn As SqlConnection, ByVal name As String)
        Try
            GFncRunSQL(conn, "drop table #" & name.ToString.Trim)
        Catch ex As Exception
        End Try
    End Sub

    Protected Friend Function FncGenRpt(ByVal tin1 As Date, ByVal tin2 As Date, Optional ByVal group As String = "") As ReportClass

        Dim t1 As String = Format(tin1, "yyyy/MM/dd")
        Dim t2 As String = Format(tin2, "yyyy/MM/dd")
        Try
            GFncRunSQL(GSCnLiqConn, "ALTER TABLE monthcomm ADD ipo numeric(14, 2) NULL")
            GFncRunSQL(GSCnLiqConn, "ALTER TABLE monthcommf ADD ipo numeric(14, 2) NULL")
        Catch ex As Exception
            Exit Try
        End Try

        Dim rpt As ReportClass = New rptConnTransFixedEx
        Dim dt As DataTable = New DtsConnectedTransaction.ConTransDataTable
        Dim str As String = "select list_name as list, clt_code as client, " & _
                                    "0.00 as sComm, 0.00 as fComm, 0.00 as interest, 0.00 as creditInterest, 0.00 as ipo, " & _
                                    "0.00 as sadj, 0.00 as sipo, 0.00 as fadj, 0.00 as fipo, 0.00 as iadj, 0.00 as iint " & _
                                    "from contran "
        If group <> "" Then
            str = str & "where list_name = '" & group & "' "
        End If
        str = str & "order by list_name"
        dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)


        dropTempTable(GSCnLiqConn, "scomm")

        str = "SELECT cm.accno, ISNULL(SUM(cm.comm * ISNULL(t1.ex_rate,1)),0) as scomm, 0 as sipo into #scomm " & _
                "FROM CommissionMaster cm " & _
                "LEFT OUTER JOIN " & _
                "(" & _
                "SELECT ssp.ParamName AS currency_in, ssp.IntValue AS ex_rate FROM " & GStrConDB & ".dbo.SystemStaticParam ssp WHERE ssp.ParamType='CTRExRate' " & _
                ") t1 ON cm.Ccy COLLATE DATABASE_DEFAULT=t1.currency_in " & _
                "WHERE cm.AccType='Securities' " & _
                "AND cm.TDate>='" & Format(tin1, "yyyy/MM/dd") & "' AND cm.TDate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                "GROUP BY cm.accno "

        GFncRunSQL(GSCnLiqConn, str)

        str = "select accno, sum(isnull(comm,0)) as scomm, sum(isnull(ipo,0)) as sipo " & _
                   "from monthcomm where mth>='" & Format(tin1, "yyyy/MM/dd") & "' and mth<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                    "group by accno order by accno"
        Dim a As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)

        dropTempTable(GSCnLiqConn, "fcomm")

        str = "SELECT cm.accno, ISNULL(SUM(cm.comm * ISNULL(t1.ex_rate,1)),0) as fcomm, 0 as fipo into #fcomm " & _
                "FROM CommissionMaster cm " & _
                "LEFT OUTER JOIN " & _
                "(" & _
                "SELECT ssp.ParamName AS currency_in, ssp.IntValue AS ex_rate FROM " & GStrConDB & ".dbo.SystemStaticParam ssp WHERE ssp.ParamType='CTRExRate' " & _
                ") t1 ON cm.Ccy COLLATE DATABASE_DEFAULT=t1.currency_in " & _
                "WHERE cm.AccType='Futures' " & _
                "AND cm.TDate>='" & Format(tin1, "yyyy/MM/dd") & "' AND cm.TDate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                "GROUP BY cm.accno "
        GFncRunSQL(GSCnLiqConn, str)

        dropTempTable(GSCnLiqConn, "iint")

        str = "SELECT cm.accno, ISNULL(SUM(cm.interest * ISNULL(t1.ex_rate,1)),0) as iint, 0 as sipo into #iint " & _
                "from CommissionMaster cm " & _
                "LEFT OUTER JOIN " & _
                "(" & _
                "SELECT ssp.ParamName AS currency_in, ssp.IntValue AS ex_rate FROM " & GStrConDB & ".dbo.SystemStaticParam ssp WHERE ssp.ParamType='CTRExRate' " & _
                ") t1 ON cm.Ccy COLLATE DATABASE_DEFAULT=t1.currency_in " & _
                "WHERE cm.TDate>='" & Format(tin1, "yyyy/MM/dd") & "' AND cm.TDate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                " GROUP BY cm.accno"

        GFncRunSQL(GSCnLiqConn, str)

        str = "select a.accno, isnull(b.scomm,0) as scomm, isnull(b.sipo,0) as sipo, isnull(c.fcomm,0) as fcomm, " & _
                    "isnull(c.fipo,0) as fipo, isnull(d.iint,0) as iint " & _
                    "from (select accno from #scomm " & _
                    "union select accno from #fcomm " & _
                    "union select accno from #iint) a " & _
                    "left join #scomm b on a.accno=b.accno " & _
                    "left join #fcomm c on a.accno=c.accno " & _
                    "left join #iint d on a.accno=d.accno " & _
                    "order by a.accno"

        Dim commDT As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)


        dropTempTable(GSCnSqlConn, "scommadj")
        str = "select accno, sum(isnull(adj,0)) as sadj into #scommadj " & _
                    "from monthcommadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                    "group by accno"
        GFncRunSQL(GSCnSqlConn, str)

        dropTempTable(GSCnSqlConn, "fcommadj")
        str = "select accno, sum(isnull(adj,0)) as fadj into #fcommadj " & _
                    "from monthcommfadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                    "group by accno"
        GFncRunSQL(GSCnSqlConn, str)

        dropTempTable(GSCnSqlConn, "intadj")
        str = "select accno, sum(isnull(adj,0)) as iadj into #intadj " & _
                    "from monthintadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                    "group by accno"
        GFncRunSQL(GSCnSqlConn, str)

        dropTempTable(GSCnSqlConn, "ipo")
        str = "select accno, sum(isnull(ipo,0)) as ipo into #ipo " & _
                    "from dailyipoadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
                    "group by accno"
        GFncRunSQL(GSCnSqlConn, str)

        str = "select a.accno, isnull(b.sadj,0) as sadj,  isnull(c.fadj,0) as fadj, " & _
                    "isnull(d.iadj,0) as iadj, isnull(e.ipo,0) as ipo " & _
                    "from (select accno from #scommadj " & _
                    "union select accno from #fcommadj " & _
                    "union select accno from #intadj " & _
                    "union select accno from #ipo) a " & _
                    "left join #scommadj b on a.accno = b.accno " & _
                    "left join #fcommadj c on a.accno = c.accno " & _
                    "left join #intadj d on a.accno = d.accno " & _
                    "left join #ipo e on a.accno = e.accno " & _
                    "order by a.accno"

        Dim adjDT As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)


        Dim client As String = ""
        For Each dr As DataRow In dt.Rows
            client = dr("client").ToString.Trim
            For Each commDr As DataRow In commDT.Rows
                If commDr("accno").ToString.Trim = client Then

                    dr("sComm") = GFncNoNullValue(commDr("sComm"))
                    dr("fComm") = GFncNoNullValue(commDr("fComm"))
                    dr("iint") = GFncNoNullValue(commDr("iint"))
                    dr("sipo") = GFncNoNullValue(commDr("sipo"))
                    dr("fipo") = GFncNoNullValue(commDr("fipo"))
                    Exit For
                End If
            Next
            For Each adjDr As DataRow In adjDT.Rows
                If adjDr("accno") = client Then

                    dr("sadj") = GFncNoNullValue(adjDr("sadj"))
                    dr("fadj") = GFncNoNullValue(adjDr("fadj"))
                    dr("iadj") = GFncNoNullValue(adjDr("iadj"))
                    dr("ipo") = GFncNoNullValue(adjDr("ipo"))
                    Exit For
                End If
            Next
        Next

        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("from", CDate(t1))
        rpt.SetParameterValue("to", CDate(t2))
        Return rpt
        '{ConTrans.sComm}=0 
        'and {ConTrans.fComm}=0
        'and {ConTrans.ipo}=0
        'and {@Credit Interest}=0
        'and {@Interest}=0
        'and {@Total}=0
    End Function
End Class

