Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class clsConTransMaintenance
    
    Protected Friend Function FncGetEndPeriod() As Date
        'Return CDate(GFncRtnDS(GSCnLiqConn, "select t2_date from IBSSTTXNDATE").Tables(0).Rows(0).Item("t2_date"))
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_IBSSTTXNDATE", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        Return CDate(GFncExecuteScalar(sqlCmd)) 'GFncRtnDS(sqlCmd).Tables(0)
    End Function


    Protected Friend Function FncLoadClient(Optional ByVal group As String = "") As DataTable
        'If group = "" Then
        '    Return GFncRtnDS(GSCnLiqConn, "select distinct clt_code from STCLTMASTER order by clt_code").Tables(0)
        'Else
        '    Return GFncRtnDS(GSCnSqlConn, "SELECT clt_code FROM contran WHERE list_name = '" & group & "' ORDER BY seq_no", "groupclientlist").Tables(0)
        'End If

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LoadClient", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        ' 参数        
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "groupStr", group.Trim)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Protected Friend Function FncLoadGroup() As DataTable
        ''Return GFncRtnDS(GSCnSqlConn, "SELECT DISTINCT list_name FROM contran order by list_name").Tables(0)
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LoadContranGroup", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        ' 参数        

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function
    Protected Friend Function CheckClientExists(ByVal clientCode As String) As Boolean
        ''Return GFncRtnDS(GSCnSqlConn, "SELECT DISTINCT list_name FROM contran order by list_name").Tables(0)
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ConTran_Exists", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "clt_code", clientCode)
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)

        ' 参数
        Dim result As Object = GFncExecuteScalar(sqlCmd)
        Return result = 1
    End Function
    Protected Friend Function FncSave(ByVal group As String, ByVal client As ListBox, ByVal oldGroupName As String) As Boolean
        'Dim trans As SqlTransaction = Nothing
        'Try
        '    trans = GSCnSqlConn.BeginTransaction
        '    GFncRunSQL(GSCnSqlConn, trans, "delete from contran where list_name = '" & group & "'")
        'Catch ex As Exception
        '    Exit Try
        'End Try
        'Dim str As String = ""
        'For i As Integer = 0 To client.Items.Count - 1
        '    Try
        '        str = "insert into contran Values('" & group & "', '" & client.Items(i).ToString.Trim & "', " & i + 1 & ")"
        '        GFncRunSQL(GSCnSqlConn, trans, str)
        '    Catch ex As Exception
        '        If GSCnSqlConn.State <> ConnectionState.Closed Then
        '            If (trans IsNot Nothing) Then
        '                trans.Rollback()
        '            End If
        '            GSubWriteErrLog(ex.Message)
        '        End If
        '    End Try
        'Next
        'trans.Commit()
        Dim codes As String = ""
        For i As Integer = 0 To client.Items.Count - 1
            codes += client.Items(i).ToString.Trim & ","
        Next
        codes = codes.TrimEnd(",")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_ConTran", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "cltCodes", codes)
        AddParameter(sqlCmd, "groupStr", group.Trim)
        AddParameter(sqlCmd, "oldGroupName", oldGroupName)

        Return GFncExecuteNonQuery(sqlCmd)

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
        'Try
        '    GFncRunSQL(GSCnLiqConn, "ALTER TABLE monthcomm ADD ipo numeric(14, 2) NULL")
        '    GFncRunSQL(GSCnLiqConn, "ALTER TABLE monthcommf ADD ipo numeric(14, 2) NULL")
        'Catch ex As Exception
        '    Exit Try
        'End Try

        'Dim rpt As ReportClass = New rptConnTrans
        'Dim dt As DataTable = New DtsConnectedTransaction.ConTransDataTable
        'Dim str As String = "select list_name as list, clt_code as client, " & _
        '                            "0.00 as sComm, 0.00 as fComm, 0.00 as interest, 0.00 as creditInterest, 0.00 as ipo, " & _
        '                            "0.00 as sadj, 0.00 as sipo, 0.00 as fadj, 0.00 as fipo, 0.00 as iadj, 0.00 as iint " & _
        '                            "from contran "
        'If group <> "" Then
        '    str = str & "where list_name = '" & group & "' "
        'End If
        'str = str & "order by list_name"
        'dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        ''str = "select a.accno, sum(a.comm) as scomm, sum(a.ipo) as sipo, sum(b.comm) as fcomm, sum(b.ipo) as fipo, sum(c.interest) as iint " & _
        ''                    "from monthcomm a Left join monthcommf b on a.accno = b.accno " & _
        ''                    "left join monthint c on a.accno = c.accno  " & _
        ''                    "where a.mth between '" & t1 & "' and '" & t2 & "' and " & _
        ''                    "b.mth between '" & t1 & "' and '" & t2 & "' group by a.accno order by a.accno"

        'dropTempTable(GSCnLiqConn, "scomm")
        'str = "select accno, sum(isnull(comm,0)) as scomm, sum(isnull(ipo,0)) as sipo into #scomm " & _
        '           "from monthcomm where mth>='" & Format(tin1, "yyyy/MM/dd") & "' and mth<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnLiqConn, str)

        ''str = "select accno, sum(isnull(comm,0)) as scomm, sum(isnull(ipo,0)) as sipo " & _
        ''           "from monthcomm where mth>='" & Format(tin1, "yyyy/MM/dd") & "' and mth<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        ''            "group by accno order by accno"
        ''Dim a As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)

        'dropTempTable(GSCnLiqConn, "fcomm")
        'str = "select accno, sum(isnull(comm,0)) as fcomm, sum(isnull(ipo,0)) as fipo into #fcomm " & _
        '            "from monthcommf where mth>='" & Format(tin1, "yyyy/MM/dd") & "' and mth<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnLiqConn, str)

        'dropTempTable(GSCnLiqConn, "iint")
        'str = "select accno, sum(isnull(interest,0)) as iint into #iint " & _
        '            "from monthint where mth>='" & Format(tin1, "yyyy/MM/dd") & "' and mth<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnLiqConn, str)

        'str = "select a.accno, isnull(b.scomm,0) as scomm, isnull(b.sipo,0) as sipo, isnull(c.fcomm,0) as fcomm, " & _
        '            "isnull(c.fipo,0) as fipo, isnull(d.iint,0) as iint " & _
        '            "from (select accno from #scomm " & _
        '            "union select accno from #fcomm " & _
        '            "union select accno from #iint) a " & _
        '            "left join #scomm b on a.accno=b.accno " & _
        '            "left join #fcomm c on a.accno=c.accno " & _
        '            "left join #iint d on a.accno=d.accno " & _
        '            "order by a.accno"

        'Dim commDT As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)

        ''str = "select a.accno, sum(a.adj) as sadj, sum(b.adj) as fadj, sum(c.adj) as iadj into #adj from " & _
        ''        "monthcommadj a left join monthcommfadj b on a.accno=b.accno left join " & _
        ''        "monthintadj c on a.accno = c.accno " & _
        ''        "where a.adjdate between '" & t1 & "' and '" & t2 & "' and " & _
        ''        "b.adjdate between '" & t1 & "' and '" & t2 & "' and " & _
        ''         "c.adjdate between '" & t1 & "' and '" & t2 & "' group by a.accno order by a.accno"
        ''GFncRunSQL(GSCnSqlConn, str)

        ''str = "select accno, sum(ipo) as ipo into #ipo from dailyipoadj " & _
        ''        "where adjdate> '" & t1 & "' and adjdate < '" & t2 & "' group by accno order by accno"
        ''GFncRunSQL(GSCnSqlConn, str)
        ''str = "select a.*, c.ipo from #adj a left join #ipo c on a.accno collate Chinese_Taiwan_Stroke_CI_AS = c.accno collate Chinese_Taiwan_Stroke_CI_AS order by a.accno"

        'dropTempTable(GSCnSqlConn, "scommadj")
        'str = "select accno, sum(isnull(adj,0)) as sadj into #scommadj " & _
        '            "from monthcommadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnSqlConn, str)

        'dropTempTable(GSCnSqlConn, "fcommadj")
        'str = "select accno, sum(isnull(adj,0)) as fadj into #fcommadj " & _
        '            "from monthcommfadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnSqlConn, str)

        'dropTempTable(GSCnSqlConn, "intadj")
        'str = "select accno, sum(isnull(adj,0)) as iadj into #intadj " & _
        '            "from monthintadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnSqlConn, str)

        'dropTempTable(GSCnSqlConn, "ipo")
        'str = "select accno, sum(isnull(ipo,0)) as ipo into #ipo " & _
        '            "from dailyipoadj where adjdate>='" & Format(tin1, "yyyy/MM/dd") & "' and adjdate<='" & Format(tin2, "yyyy/MM/dd") & "' " & _
        '            "group by accno"
        'GFncRunSQL(GSCnSqlConn, str)

        'str = "select a.accno, isnull(b.sadj,0) as sadj,  isnull(c.fadj,0) as fadj, " & _
        '            "isnull(d.iadj,0) as iadj, isnull(e.ipo,0) as ipo " & _
        '            "from (select accno from #scommadj " & _
        '            "union select accno from #fcommadj " & _
        '            "union select accno from #intadj " & _
        '            "union select accno from #ipo) a " & _
        '            "left join #scommadj b on a.accno = b.accno " & _
        '            "left join #fcommadj c on a.accno = c.accno " & _
        '            "left join #intadj d on a.accno = d.accno " & _
        '            "left join #ipo e on a.accno = e.accno " & _
        '            "order by a.accno"

        'Dim adjDT As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        ''Dim adjDT As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        ''GFncRunSQL(GSCnSqlConn, "drop table #adj")
        ''GFncRunSQL(GSCnSqlConn, "drop table #ipo")

        'Dim client As String = ""
        'For Each dr As DataRow In dt.Rows
        '    client = dr("client").ToString.Trim
        '    For Each commDr As DataRow In commDT.Rows
        '        If commDr("accno").ToString.Trim = client Then

        '            dr("sComm") = GFncNoNullValue(commDr("sComm"))
        '            dr("fComm") = GFncNoNullValue(commDr("fComm"))
        '            dr("iint") = GFncNoNullValue(commDr("iint"))
        '            dr("sipo") = GFncNoNullValue(commDr("sipo"))
        '            dr("fipo") = GFncNoNullValue(commDr("fipo"))
        '            Exit For
        '        End If
        '    Next
        '    For Each adjDr As DataRow In adjDT.Rows
        '        If adjDr("accno") = client Then

        '            dr("sadj") = GFncNoNullValue(adjDr("sadj"))
        '            dr("fadj") = GFncNoNullValue(adjDr("fadj"))
        '            dr("iadj") = GFncNoNullValue(adjDr("iadj"))
        '            dr("ipo") = GFncNoNullValue(adjDr("ipo"))
        '            Exit For
        '        End If
        '    Next
        'Next

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ConTran", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "groupStr", group.Trim)
        AddParameter(sqlCmd, "tin1", tin1.Date.ToString("yyyy/MM/dd"))
        AddParameter(sqlCmd, "tin2", tin2.Date.ToString("yyyy/MM/dd"))

        ' 参数        
        Dim rpt As ReportClass = New rptConnTrans
        Dim dt As DataTable = GFncRtnDS(sqlCmd).Tables(0)

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
