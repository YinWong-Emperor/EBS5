Imports System.Data.SqlClient

Public Class ClsCommRateTblOther

    Protected Friend Function SearchAE(ByVal aeno As String, ByVal commType As String, ByVal month As String, ByVal Type As String, ByVal inDefault As Boolean) As DataSet
        Dim lstrSQL As String = "select distinct a.ae_no, b.ae_name_s as ae_name from draft_comm_rate_other a " & _
            "left outer join draft_comm_ae_master b on a.ae_no = b.ae_no where 1=1"
        If aeno.Trim.Length > 0 Then
            lstrSQL += " and upper(a.ae_no) like '%" & aeno & "%' "
        End If
        If commType.Length > 0 Then
            lstrSQL += " and a.comm_type ='"
            'If inDefault Then
            '    lstrSQL += "DEF"
            'End If
            lstrSQL += commType.Trim & "' "
        Else
            lstrSQL += " and (a.comm_type ='"
            'If inDefault Then
            '    lstrSQL += "DEF"
            'End If
            lstrSQL += "INC" & Type & "' or a.comm_type ='"
            'If inDefault Then
            '    lstrSQL += "DEF"
            'End If
            lstrSQL += "BON" & Type & "') "
            End If
        lstrSQL += " and a.comm_month ='" & month & "' "
        If inDefault Then
            lstrSQL += " and 1=0"
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
    End Function

    Protected Friend Function SearchRateOther(ByVal aeno As String, ByVal commType As String, ByVal month As String, ByVal Type As String, ByVal DefaultValue As Boolean) As DataSet
        'Dim lstrSQL As String = "select ae_no, comm_rate,case left(comm_type,3) when 'INC' then 'Incentive Comm.' when 'BON' then 'Bonus Comm.' End comm_type, comm_month, comm_net_brok, rsid from comm_rate_other where 1=1"
        'lstrSQL += " and ae_no ='" & aeno & "' "
        Dim srchType As String = ""
        Dim DefaultAE As String = ""
        If DefaultValue Then
            DefaultAE = "DEF"
        End If
        If commType.Length > 0 Then
            srchType += " and a.comm_type ='" & DefaultAE & commType.Trim & "' "
        Else
            srchType += " and (a.comm_type ='" & DefaultAE & "INC" & Type & "' or a.comm_type ='" & DefaultAE & "BON" & Type & "') "
        End If
        Dim lstrsql As String = "select a.rsid, a.comm_month, c.misc_desc,''as brok_range, " & _
            "max(a.comm_net_brok) as comm_net_brok, min (b.comm_net_brok) as comm_net_brok_to, a.comm_rate from " & _
            "draft_comm_rate_other a left join draft_comm_rate_other b on a.ae_no = b.ae_no and a.comm_type = b.comm_type " & _
            "and a.comm_month = b.comm_month and a.comm_net_brok < b.comm_net_brok left join misc_master c on " & _
            "a.comm_type = misc_code and misc_type = 'RATEOTHERTYPE' where 1=1 "
        If aeno.Trim.Length > 0 Then
            lstrsql += " and a.ae_no ='" & aeno & "' "
        End If
        lstrsql += " and a.comm_month ='" & month & "' " & srchType & " group by a.rsid,a.comm_month, a.ae_no, c.misc_desc, " & _
            "a.comm_rate order by c.misc_desc, comm_net_brok "
        Return GFncRtnDS(GSCnSqlConn, lstrsql, "OtherRate")
    End Function

    Protected Friend Function GetLatestDate() As String
        Dim lstrSQL As String = "select max(comm_month) from draft_comm_rate_other where (comm_type='INCAE' or comm_type='BONAE')"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return Now.Year.ToString & Format(Val(Now.Month) - 1, "00")
        End If
    End Function

    Protected Friend Function GetAe() As DataTable
        Dim aedt As DataTable = Nothing
        Dim lstrSQL As String = "Select a.ae_no, isnull(b.txmonth,'') as txmonth , isnull(a.ae_name_s, '') as ae_name " & _
            "from draft_comm_ae_master a left outer join draft_comm_ae_master_d b on a.ae_no=b.ae_no order by a.ae_no asc"
        AeDT = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Return AeDT
    End Function

    Protected Friend Function NewRecord(ByVal condition As String, ByVal ae As String, ByVal rate As Double, ByVal type As String, _
        ByVal month As String, ByVal brok As Double) As Integer
        Dim rsid As DataTable = Nothing
        Dim lstrSQL As String = "Insert into draft_comm_rate_other (ae_no, comm_rate, comm_type, comm_month, comm_net_brok) " & _
            "Values (" & condition & ")"
        Dim logstr As String = GfncOneFieldLog("Commission Rate", rate) & " " & GfncOneFieldLog("Commission Net Brokerage", brok)
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            rsid = GFncRtnDS(GSCnSqlConn, "Select max(rsid) from draft_comm_rate_f", MyTrans).Tables(0)
            GFncFillLog(GStrloginID, "A", GDteTradeDate, "IncBon", ae, "", 0, month, logstr, MyTrans)
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return GFncNoNullString(rsid.Rows(0).Item(0))
    End Function

    Protected Friend Function EditRecord(ByVal condition As String, ByVal id As Integer, ByVal rate As Double, ByVal type As String, _
        ByVal broke As Double, ByVal ae As String) As Boolean
        Dim oldRate As Double = 0
        Dim oldType As String = ""
        Dim oldBroke As Double = 0
        Dim oldAE As String = ""
        Dim month As String = ""
        Dim lstrSQL As String = "Update draft_comm_rate_other Set " & condition & " where rsid =" & id
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_other where rsid = " & id).Tables(0)
        If oldDt.Rows.Count > 0 Then
            oldRate = GFncNoNullValue(oldDt.Rows(0).Item("comm_rate"))
            oldType = GFncNoNullString(oldDt.Rows(0).Item("comm_type")).Trim
            oldBroke = GFncNoNullValue(oldDt.Rows(0).Item("comm_net_brok"))
            oldAE = GFncNoNullString(oldDt.Rows(0).Item("ae_no")).Trim
            month = GFncNoNullString(oldDt.Rows(0).Item("comm_month")).Trim
        End If
        Dim logstr As String = ""
        If oldRate <> rate Then
            logstr &= GfncOneFieldLog("Commission Rate", oldRate, rate)
        End If
        If oldBroke <> broke Then
            logstr &= GfncOneFieldLog("Commission Net Brokerage", oldBroke, broke)
        End If
        If oldAE <> ae Then
            logstr &= GfncOneFieldLog("AE No.", oldAE, ae)
        End If
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            GFncFillLog(GStrloginID, "M", GDteTradeDate, "IncBon", oldAE, "", id, month, logstr, MyTrans)
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function DelRecord(ByVal id As Integer) As Boolean
        Dim lstrSQL As String = "Delete from draft_comm_rate_other where rsid =" & id
        Dim ae As String = ""
        Dim month As String = ""
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_other where rsid =" & id).Tables(0)
        If oldDt.Rows.Count > 0 Then
            ae = GFncNoNullString(oldDt.Rows(0).Item("AE_NO")).Trim
            month = GFncNoNullString(oldDt.Rows(0).Item("comm_month")).Trim
        End If
        Dim logstr As String = GfncOneFieldLog("rsid", id)
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            GFncFillLog(GStrloginID, "D", GDteTradeDate, "IncBon", ae, "", id, month, logstr, MyTrans)
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(13))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function GetLatestRecord(ByVal id As Integer) As DataSet
        Dim lstrSQL As String = "Select * from draft_comm_rate_other where rsid =" & id
        Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    End Function

    Protected Friend Function ValidateDuplicate(ByVal condition As String) As Boolean
        Dim lstrSQL As String = "Select * from draft_comm_rate_other where 1=1 " & condition
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Friend Function lFncGetNextComm(ByVal comm_month As String, ByVal ae_no As String, ByVal comm_type As String, _
        ByVal turnover As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select min(comm_net_brok) as mt from draft_comm_rate_other where ae_no = '" & ae_no & "' and comm_month = '" & _
            comm_month & "' and comm_type = '" & comm_type & "'  and comm_net_brok > " & turnover
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "next_comm")
        Return lds
    End Function

End Class
