Imports System.Data.SqlClient

Public Class ClsCommRateTableS

    Public comm_rate_nor As String = "NOR"
    Public comm_rate_int As String = "INT"
    Public comm_rate_con As String = "CON"
    Public comm_rate_ManTurn As String = "MTURN"
    Public comm_rate_ManBrok As String = "MBROK"
    Public comm_rate_ManRebate As String = "MREBATE"
    Public normalType As String = "Normal Trade"
    Public internetType As String = "Internet Trade"
    Public comm_rate_ManDef As String = "DEFM"
    'variable for extra rebate rate
    Public comm_rate_er_nor As String = "ERNOR"
    Public comm_rate_er_int As String = "ERINT"
    Public comm_rate_er_con As String = "ERCON"
    Public comm_type_acc As String = "ACC"
    Public comm_type_ae As String = "AE"
    Public comm_type_agp As String = "AGRP"
    Public comm_type_man As String = "MAN"
    Public comm_type_mgp As String = "MGRP"
    Public market_sec As String = "S"
    Public market_fut As String = "F"

    Protected Friend Function lFncGetAccList(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal comm_type As String, ByVal ae_no As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and b.rate_type = '" & rate_type & "' "
        Else
            lstrSQL = "and (b.rate_type = '" & comm_rate_nor & "' or b.rate_type ='" & comm_rate_int & _
                "' or b.rate_type ='" & comm_rate_con & "') "
        End If
        If (acc_no.Length > 0) Then
            lstrSQL = lstrSQL & "and a.acc_no = '" & acc_no & "' "
        End If
        If (ae_no.Length > 0) Then
            lstrSQL = lstrSQL & "and b.ae_no = '" & ae_no & "' "
        End If
        lstrSQL = "select distinct a.acc_no, a.acc_name_s from draft_comm_acc_master a, draft_comm_rate_s b where " & _
            "a.acc_no = b.acc_no and b.comm_month = '" & comm_month & "' and b.comm_type = '" & comm_type & "' " & lstrSQL & _
            "order by a.acc_no"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "accno")
    End Function

    'Protected Friend Function lFncGetDefAccList(ByVal comm_month As String, ByVal rate_type As String, _
    '                                         ByVal comm_type As String) As DataSet
    '    Dim lstrSQL As String = ""
    '    If (rate_type.Length > 0) Then
    '        lstrSQL = "and b.rate_type = 'DEF" & rate_type & "' "
    '    Else
    '        lstrSQL = "and (b.rate_type = 'DEF" & comm_rate_nor & "' or b.rate_type ='DEF" & comm_rate_int & "' or b.rate_type ='DEF" & comm_rate_con & "') "
    '    End If
    '    lstrSQL = "select distinct a.acc_no, a.acc_name_s from comm_acc_master a, comm_rate_s b " & _
    '                "where a.acc_no = b.acc_no and b.comm_month = '" & comm_month & "' and b.comm_type = '" & comm_type & "' " & lstrSQL
    '    Return GFncRtnDS(GSCnSqlConn, lstrSQL, "accno")
    'End Function

    Protected Friend Function lFncGetAEList(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal comm_type As String, Optional ByVal ae_no As String = "") As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and b.rate_type = '" & rate_type & "' "
        Else
            lstrSQL = "and (b.rate_type = '" & comm_rate_nor & "' or b.rate_type = '" & comm_rate_int & "' or b.rate_type = '" & _
                comm_rate_con & "') "
        End If
        If (Not acc_no Is Nothing) Then
            If (acc_no.Length > 0) Then
                lstrSQL = lstrSQL & "and b.acc_no = '" & acc_no & "' "
            End If
        End If
        If (ae_no.Length > 0) Then
            lstrSQL = lstrSQL & "and b.ae_no = '" & ae_no & "' "
        End If
        lstrSQL = "from draft_comm_ae_master a, draft_comm_rate_s b where a.ae_no = b.ae_no and b.comm_month = '" & comm_month & _
            "' and b.comm_type = '" & comm_type & "' " & lstrSQL & "order by a.ae_no"
        If (comm_type = comm_type_acc Or comm_type = comm_type_man Or comm_type = comm_type_mgp Or comm_type = comm_type_ae) Then
            lstrSQL = "select distinct a.ae_no, a.ae_name_s " & lstrSQL
        ElseIf (comm_type = comm_type_agp) Then
            lstrSQL = "select distinct a.ae_no, acc_group, a.ae_name_s " & lstrSQL
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
    End Function

    'Protected Friend Function lFncGetDefAEList(ByVal comm_month As String, ByVal rate_type As String, _
    '                                     ByVal comm_type As String) As DataSet
    '    Dim lstrSQL As String = ""
    '    If (rate_type.Length > 0) Then
    '        lstrSQL = "and b.rate_type = 'DEF" & rate_type & "' "
    '    Else
    '        lstrSQL = "and (b.rate_type = 'DEF" & comm_rate_nor & "' or b.rate_type ='DEF" & comm_rate_int & "' or b.rate_type ='DEF" & comm_rate_con & "') "
    '    End If
    '    lstrSQL = "from comm_ae_master a, comm_rate_s b where a.ae_no = b.ae_no " & _
    '                "and b.comm_month = '" & comm_month & "' and b.comm_type = '" & comm_type & "' " & lstrSQL & "order by a.ae_no"
    '    If (comm_type = comm_type_acc Or comm_type = comm_type_man Or comm_type = comm_type_mgp) Then
    '        lstrSQL = "select distinct a.ae_no, a.ae_name_s " & lstrSQL
    '    ElseIf (comm_type = comm_type_agp) Then
    '        lstrSQL = "select distinct a.ae_no, acc_group, a.ae_name_s " & lstrSQL
    '    End If
    '    Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
    'End Function

    Protected Friend Function lFncGetRateList(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal man_no As String, ByVal man_group As String, ByVal comm_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and a.rate_type = '" & rate_type & "' "
        Else
            lstrSQL = "and (a.rate_type = '" & comm_rate_nor & "' or a.rate_type ='" & comm_rate_int & "' or a.rate_type ='" & comm_rate_con & "') "
        End If
        If (Not acc_no Is Nothing) Then
            If (acc_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.acc_no = '" & acc_no & "' "
            End If
        End If
        If (Not ae_no Is Nothing) Then
            If (ae_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.ae_no = '" & ae_no & "' "
            End If
        End If
        If (Not man_no Is Nothing) Then
            If (man_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.man_no = '" & man_no & "' "
            End If
        End If
        If (Not man_group Is Nothing) Then
            If (man_group.Length > 0) Then
                lstrSQL = lstrSQL & "and a.man_group = '" & man_group & "' "
            End If
        End If
        lstrSQL = "select a.srid, a.comm_month, c.misc_desc, max(a.turnover_from) as turnover_from, " & _
            "min(b.turnover_from) as turnover_to, '' as turnover, a.comm_rate, isnull(a.brokerage_rate,0) as brokerage_rate " & _
            "from draft_comm_rate_s a left join draft_comm_rate_s b on a.acc_no = b.acc_no and a.ae_no = b.ae_no and " & _
            "a.rate_type = b.rate_type and a.comm_month = b.comm_month and a.comm_type = b.comm_type and " & _
            "a.turnover_from < b.turnover_from left join misc_master c on a.rate_type = misc_code and misc_type = 'RATESCTACC' " & _
            "where a.comm_month = '" & comm_month & "' and a.comm_type = '" & comm_type & "' " & lstrSQL & _
            "group by a.srid, a.acc_no, a.comm_month, c.misc_desc, a.comm_rate, a.brokerage_rate, a.man_no, a.man_group " & _
            "order by c.misc_desc, turnover_from"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    End Function

    'Protected Friend Function lFncGetDefRateList(ByVal comm_month As String, ByVal rate_type As String, ByVal comm_type As String) As DataSet

    '    Dim lstrSQL As String = ""

    '    If (rate_type.Length > 0) Then
    '        lstrSQL = "and a.rate_type = 'DEF" & rate_type & "' "
    '    Else
    '        lstrSQL = "and (a.rate_type = 'DEF" & comm_rate_nor & "' or a.rate_type ='DEF" & comm_rate_int & "' or a.rate_type ='DEF" & comm_rate_con & "') "
    '    End If

    '    lstrSQL = "select a.srid, a.comm_month, c.misc_desc, max(a.turnover_from) as turnover_from, " & _
    '                "min(b.turnover_from) as turnover_to, '' as turnover, a.comm_rate " & _
    '                "from comm_rate_s a " & _
    '                "left join comm_rate_s b on a.acc_no = b.acc_no and a.ae_no = b.ae_no and a.rate_type = b.rate_type " & _
    '                "and a.comm_month = b.comm_month and a.comm_type = b.comm_type and a.turnover_from < b.turnover_from " & _
    '                "left join misc_master c on a.rate_type = misc_code and misc_type = 'RATESCTACC' " & _
    '                "where a.comm_month = '" & comm_month & "' " & _
    '                "and a.comm_type = '" & comm_type & "' " & lstrSQL & _
    '                "group by a.srid, a.acc_no, a.comm_month, c.misc_desc, a.comm_rate, a.man_no, a.man_group " & _
    '                "order by c.misc_desc, a.turnover_from"
    '    Return GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")

    'End Function
    'Protected Friend Function lFncGetACCRate(ByVal rate_type As String, ByVal rate_month As String, _
    '                                      ByVal comm_type As String, ByVal accno As String) As DataSet

    '    Dim lstrSQL As String
    '    Dim lds As DataSet

    '    lstrSQL = "select a.srid, a.acc_no, c.acc_name_s, a.comm_month, misc_desc, a.comm_rate, max(a.turnover_from) as turnover_from, " & _
    '                "min(b.turnover_from) as turnover_to, '' as TurnOver, c.ae_no_s " & _
    '                "from comm_rate_s a " & _
    '                "left join comm_rate_s b on a.acc_no = b.acc_no and a.comm_type = b.comm_type " & _
    '                "and a.rate_type = b.rate_type and a.turnover_from < b.turnover_from and a.comm_month = b.comm_month " & _
    '                "left join comm_acc_master c on rtrim(a.acc_no) = rtrim(c.acc_no) " & _
    '                "left join misc_master on a.rate_type = misc_code and misc_type = 'RATESCTACC' " & _
    '                "where a.comm_type = '" & comm_type & "' " & _
    '                "and a.comm_month = '" & rate_month & "' "
    '    If (rate_type.Length <> 0) Then
    '        lstrSQL = lstrSQL & "and a.rate_type = '" & rate_type & "' "
    '    End If
    '    If (accno.Length <> 0) Then
    '        lstrSQL = lstrSQL & "and a.acc_no = '" & accno & "' "
    '    End If
    '    lstrSQL = lstrSQL & "group by a.srid, a.acc_no, c.acc_name_s, a.comm_month, misc_desc, a.comm_rate, c.ae_no_s " & _
    '                        "order by a.acc_no, misc_desc, a.turnover_from "
    '    lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    '    Return lds

    'End Function

    'Protected Friend Function lFncGetAGPRate(ByVal rate_type As String, ByVal rate_month As String, _
    '                                  ByVal comm_type As String, ByVal accno As String) As DataSet

    '    Dim lstrSQL As String
    '    Dim lds As DataSet

    '    lstrSQL = "select a.srid, a.acc_no, c.acc_name_s, a.comm_month, misc_desc, a.comm_rate, max(a.turnover_from) as turnover_from, " & _
    '                "min(b.turnover_from) as turnover_to, '' as TurnOver, a.acc_group, c.ae_no_s " & _
    '                "from comm_rate_s a " & _
    '                "left join comm_rate_s b on a.acc_no = b.acc_no and a.comm_type = b.comm_type " & _
    '                "and a.rate_type = b.rate_type and a.turnover_from < b.turnover_from and a.comm_month = b.comm_month " & _
    '                "left join comm_acc_master c on rtrim(a.acc_no) = rtrim(c.acc_no) " & _
    '                "left join misc_master on a.rate_type = misc_code and misc_type = 'RATESCTACC' " & _
    '                "where a.comm_type = '" & comm_type & "' " & _
    '                "and a.comm_month = '" & rate_month & "' "
    '    If (rate_type.Length <> 0) Then
    '        lstrSQL = lstrSQL & "and a.rate_type = '" & rate_type & "' "
    '    End If
    '    If (accno.Length <> 0) Then
    '        lstrSQL = lstrSQL & "and a.acc_no = '" & accno & "' "
    '    End If
    '    lstrSQL = lstrSQL & "group by a.srid, a.acc_no, c.acc_name_s, a.comm_month, misc_desc, a.comm_rate, a.acc_group, c.ae_no_s " & _
    '                        "order by a.acc_no, misc_desc, a.turnover_from "
    '    lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    '    Return lds

    'End Function

    Protected Friend Function lFncGetNextComm(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal comm_type As String, ByVal turnover As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select min(turnover_from) as mt from draft_comm_rate_s where acc_no = '" & acc_no & "' and ae_no = '" & _
            ae_no & "' and rate_type = '" & rate_type & "' and comm_month = '" & comm_month & "' and comm_type = '" & _
            comm_type & "'  and turnover_from > " & turnover
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "next_comm")
        Return lds
    End Function

    Protected Friend Function lFncGetCommMonth(ByVal comm_type As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select max(comm_month) as mmth from draft_comm_rate_s where comm_type = '" & comm_type & "' and rate_type<>'DEFM' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "comm_month")
        Return lds
    End Function
   
    Protected Friend Function lFnGetAllAccNo(ByVal strMonth As String, Optional ByVal ae_no As String = "") As DataSet
        Dim lstrSQL As String = ""
        'If (UCase(market_type) = market_sec) Then
        lstrSQL = "select distinct a.acc_no, a.acc_name_s, b.isConsolid from draft_comm_acc_master a inner join " & _
            "draft_comm_acc_master_d b on a.acc_no = b.acc_no and txmonth = '" & strMonth & "' "
        If ae_no <> "" Then
            lstrSQL += " and b.ae_no_s = '" & ae_no & "' "
        End If
        lstrSQL += " where inSec=1 order by a.acc_no "
        'ElseIf (UCase(market_type) = market_fut) Then
        'lstrSQL = "select distinct acc_no, acc_name_f from comm_acc_master where inFut=1 order by acc_no "
        'End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "accno")
    End Function

    Protected Friend Function lFnGetAllManNo() As DataSet
        Dim lstrSQL As String = ""
        lstrSQL = "select distinct a.man_no, isnull(isnull(b.ae_name_s,b.ae_name_f),'') as man_name, a.man_grp, a.txmonth " & _
            "from draft_comm_man_master_d a left outer join draft_comm_ae_master b on a.man_no = b.ae_no " & _
            "order by a.txmonth asc, a.man_no asc "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "manno")
    End Function

    Protected Friend Function lFnGetManGP(ByVal aeno As String, ByVal month As String) As DataSet
        Dim lstrSQL As String = ""
        lstrSQL = "select isnull(ae_group_s,'') as ae_group_s from draft_comm_group_s where ae_no='" & aeno & _
            "' and txmonth='" & month & "' order by ae_group_s "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "manno")
    End Function

    Protected Friend Function lFnGetAccName(ByVal accno As String, ByVal market_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (UCase(market_type) = market_sec) Then
            lstrSQL = "select acc_name_s from draft_comm_acc_master where acc_no = '" & accno & "' "
        ElseIf (UCase(market_type) = market_fut) Then
            lstrSQL = "select acc_name_f from draft_comm_acc_master where acc_no = '" & accno & "' "
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "accname")
    End Function

    Protected Friend Function lFnGetManName(ByVal manno As String) As DataSet
        Dim lstrSQL As String = ""
        lstrSQL = "select man_name from draft_comm_man_master where man_no = '" & manno & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "manname")
    End Function

    Protected Friend Function lFnGetAllAENo(ByVal market_type As String, ByVal strMonth As String) As DataSet
        Dim lstrSQL As String = ""
        'If (UCase(market_type) = market_sec) Then
        lstrSQL = "select distinct a.ae_no, a.ae_name_s from draft_comm_ae_master a inner join draft_comm_acc_master_d b " & _
            " on a.ae_no = b.ae_no_s and txmonth = '" & strMonth & "' where inSec=1 and a.ae_no <> '' order by a.ae_no "
        'ElseIf (UCase(market_type) = market_fut) Then
        'lstrSQL = "select ae_no, ae_name_f from comm_ae_master where inFut=1 order by ae_no "
        'End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
    End Function

    Protected Friend Function lFncGetAllAEnoList(ByVal strMonth As String) As DataSet
        Dim lstrsql As String = "select distinct a.ae_no, a.ae_name_s, b.txmonth, b.isconsolid from draft_comm_ae_master a " & _
            "inner join draft_comm_ae_master_d b on a.ae_no = b.ae_no where inSec=1 and iscommission_s = 1 and a.ae_no <> '' " & _
            " and txmonth = '" & strMonth & "' order by b.txmonth, a.ae_no "
        Return GFncRtnDS(GSCnSqlConn, lstrsql, "aeno")
    End Function

    Protected Friend Function lFnGetAENo(ByVal accno As String, ByVal market_type As String, ByVal month As String) As DataTable
        Dim lstrSQL As String = ""
        If (UCase(market_type) = market_sec) Then
            lstrSQL = "select ae_no_s from draft_comm_acc_master_d where acc_no = '" & accno & "'  and txmonth= '" & month & "' "
        ElseIf (UCase(market_type) = market_fut) Then
            lstrSQL = "select ae_no_f from draft_comm_acc_master_d where acc_no = '" & accno & "' and txmonth= '" & month & "' "
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno").Tables(0)
    End Function

    Protected Friend Function lFnGetAccGroupo(ByVal accno As String, ByVal market_type As String, ByVal month As String) As DataSet
        Dim lstrSQL As String = ""
        If (UCase(market_type) = market_sec) Then
            lstrSQL = "select acc_group_s from draft_comm_acc_master_d where acc_no = '" & accno & "' and txmonth= '" & month & "'"
        ElseIf (UCase(market_type) = market_fut) Then
            lstrSQL = "select acc_group_f from draft_comm_acc_master_d where acc_no = '" & accno & "' and txmonth= '" & month & "'"
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
    End Function

    Protected Friend Function lFnGetAEName(ByVal aeno As String, ByVal market_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (UCase(market_type) = market_sec) Then
            lstrSQL = "select ae_name_s from draft_comm_ae_master where ae_no = '" & aeno & "' "
        ElseIf (UCase(market_type) = market_fut) Then
            lstrSQL = "select ae_name_f from draft_comm_ae_master where ae_no = '" & aeno & "' "
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "accname")
    End Function

    Protected Friend Function lFnGetSRID() As String
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select max(srid) as newid from draft_comm_rate_s "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
        Return lds.Tables(0).Rows(0).Item(0).ToString
    End Function

    Protected Friend Sub lFncDeleteRate(ByVal srid As String, ByRef MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "delete from draft_comm_rate_s where srid = " & srid
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Sub

    Protected Friend Sub lFncDeleteBRate(ByVal rate_type As String, ByVal comm_type As String, ByVal turnover_from As String, _
        ByVal comm_month As String, ByVal ae_no As String, ByRef MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "delete from draft_comm_rate_s where rate_type = '" & rate_type & "' and turnover_from = " & CDbl(turnover_from) & _
            " and comm_type = '" & comm_type & "' and ae_no = '" & ae_no & "' and comm_month = '" & comm_month & "' "
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logstr As String = GfncOneFieldLog("Rate Type", rate_type) & " " & _
            GfncOneFieldLog("Turnover From", CDbl(turnover_from)) & " " & GfncOneFieldLog("Commission Type", comm_type)
        GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblSACC", ae_no, "", 0, comm_month, logstr, MyTrans)
    End Sub

    Protected Friend Sub lFncInsertRate(ByVal acc_no As String, ByVal ae_no As String, ByVal ae_group As String, _
        ByVal rate_type As String, ByVal turnover_from As String, ByVal comm_rate As String, ByVal brok_rate As String, _
        ByVal comm_month As String, ByVal comm_type As String, ByRef MyTrans As SqlTransaction, _
        Optional ByVal LOGTYPE As String = "")
        Dim lstrSQL As String = "insert into draft_comm_rate_s (acc_no, ae_no, acc_group, rate_type, turnover_from, " & _
        "comm_rate, brokerage_rate,comm_month, comm_type) values ('" & acc_no & "', '" & ae_no & "', '" & ae_group & "', '" & _
        rate_type & "', " & CDbl(turnover_from) & ", " & comm_rate & ", " & brok_rate & ", '" & comm_month & "', '" & comm_type & "')"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logstr As String = GfncOneFieldLog("Account Group", ae_group) & " " & GfncOneFieldLog("Rate Type", rate_type) & " " & _
            GfncOneFieldLog("Turnover From", CDbl(turnover_from)) & " " & GfncOneFieldLog("Commission Rate", comm_rate) & " " & _
            GfncOneFieldLog("Brokerage Rate", brok_rate) & " " & GfncOneFieldLog("Commission Type", comm_type)
        GFncFillLog(GStrloginID, "A", GDteTradeDate, LOGTYPE, ae_no, acc_no, 0, comm_month, logstr, MyTrans)
    End Sub

    Protected Friend Sub lFncModifyRate(ByVal srid As String, ByVal rate_type As String, ByVal turnover_from As String, _
        ByVal comm_rate As String, ByVal brok_rate As String, ByVal ae_group As String, ByVal man_group As String, _
        ByRef MyTrans As SqlTransaction, Optional ByVal logtype As String = "")
        Dim lstrSQL As String = ""
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_s where srid = " & srid, MyTrans).Tables(0)
        Dim oldType As String = ""
        Dim oldTurnover As Double = 0
        Dim oldRate As Double = 0
        Dim oldAEGroup As String = ""
        Dim oldManGroup As String = ""
        Dim oldBroke As Double = 0
        Dim acc As String = ""
        Dim ae As String = ""
        Dim month As String = ""
        If oldDt.Rows.Count > 0 Then
            acc = GFncNoNullString(oldDt.Rows(0).Item("acc_no")).Trim
            ae = GFncNoNullString(oldDt.Rows(0).Item("ae_no")).Trim
            month = GFncNoNullString(oldDt.Rows(0).Item("comm_month")).Trim
            oldType = GFncNoNullString(oldDt.Rows(0).Item("rate_type")).Trim
            oldTurnover = GFncNoNullValue(oldDt.Rows(0).Item("turnover_from"))
            oldRate = GFncNoNullValue(oldDt.Rows(0).Item("comm_rate"))
            oldAEGroup = GFncNoNullString(oldDt.Rows(0).Item("acc_group")).Trim
            oldManGroup = GFncNoNullString(oldDt.Rows(0).Item("man_group")).Trim
            oldBroke = GFncNoNullValue(oldDt.Rows(0).Item("brokerage_rate"))
        End If
        Dim logstr As String = ""
        If oldType <> rate_type.Trim Then
            logstr &= GfncOneFieldLog("Rate Type", oldType, rate_type.Trim)
        End If
        If oldTurnover <> CDbl(turnover_from) Then
            logstr &= GfncOneFieldLog("Turnover From", oldTurnover, CDbl(turnover_from))
        End If
        If oldRate <> comm_rate Then
            logstr &= GfncOneFieldLog("Commission Rate", oldRate, comm_rate)
        End If
        If oldAEGroup <> ae_group.Trim Then
            logstr &= GfncOneFieldLog("Account Group", oldAEGroup, ae_group.Trim)
        End If
        If oldManGroup <> man_group.Trim Then
            logstr &= GfncOneFieldLog("Manager Group", oldManGroup, man_group.Trim)
        End If
        If oldBroke <> brok_rate Then
            logstr &= GfncOneFieldLog("Brokerage Rate", oldBroke, brok_rate)
        End If
        lstrSQL = "update draft_comm_rate_s set rate_type = '" & rate_type & "', turnover_from = " & CDbl(turnover_from) & _
            ", comm_rate = " & comm_rate & ", acc_group = '" & ae_group & "', man_group = '" & man_group & _
            "', brokerage_rate = " & brok_rate & " where srid = " & srid
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        GFncFillLog(GStrloginID, "M", GDteTradeDate, logtype, ae, acc, srid, month, logstr, MyTrans)
    End Sub

    Protected Friend Sub lFncModifyBRate(ByVal rate_type As String, ByVal comm_type As String, ByVal turnover_from As String, ByVal comm_rate As String, _
        ByVal brok_rate As String, ByVal comm_month As String, ByVal ae_no As String, ByRef MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_s where rate_type = '" & rate_type & _
            "' and turnover_from = " & CDbl(turnover_from) & " and comm_type = '" & comm_type & "' and ae_no = '" & ae_no & _
            "' and comm_month = '" & comm_month & "'", MyTrans).Tables(0)
        lstrSQL = "update draft_comm_rate_s set comm_rate = " & comm_rate & ", brokerage_rate = " & brok_rate & _
            " where rate_type = '" & rate_type & "' and turnover_from = " & CDbl(turnover_from) & " and comm_type = '" & _
            comm_type & "' and ae_no = '" & ae_no & "' and comm_month = '" & comm_month & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logstr As String
        For Each dr As DataRow In oldDt.Rows
            logstr = ""
            If GFncNoNullValue(dr("comm_rate")) <> comm_rate Then
                logstr &= GfncOneFieldLog("Commission Rate", GFncNoNullValue(dr("comm_rate")), comm_rate)
            End If
            If GFncNoNullValue(dr("brokerage_rate")) <> brok_rate Then
                logstr &= GfncOneFieldLog("Brokerage Rate", GFncNoNullValue(dr("brokerage_rate")), brok_rate)
            End If
            GFncFillLog(GStrloginID, "M", GDteTradeDate, "CommRateTblSACC", GFncNoNullString(dr("ae_no")).Trim, _
                GFncNoNullString(dr("acc_no")).Trim, GFncNoNullValue(dr("srid")), GFncNoNullString(dr("comm_month")).Trim, _
                logstr, MyTrans)
        Next
    End Sub

    Protected Friend Function lFncCheckOverlap(ByVal srid As String, ByVal acc_no As String, ByVal ae_no As String, _
        ByVal rate_type As String, ByVal turnover_from As String, ByVal comm_month As String, ByVal man_no As String, _
        ByVal man_group As String, ByVal comm_type As String, ByVal turnoverType As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select srid from draft_comm_rate_s where acc_no = '" & acc_no & "' and ae_no = '" & ae_no & _
            "' and rate_type = '" & rate_type & "' and turnover_from = " & CDbl(turnover_from) & " and comm_month = '" & _
            comm_month & "' and comm_type = '" & comm_type & "' "
        If man_no <> Nothing Then
            lstrSQL += " and man_no ='" & man_no & "' "
        End If
        If man_group <> Nothing Then
            lstrSQL += " and man_group = '" & man_group & "' "
        End If
        If turnoverType <> Nothing And rate_type <> "DEFM" Then
            lstrSQL += " and turnover_type = '" & turnoverType & "' "
        End If
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
        If (lds.Tables(0).Rows.Count > 0) Then
            If (srid = "") Then
                Return True
            Else
                If (lds.Tables(0).Rows(0).Item(0) <> CInt(srid)) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Protected Friend Function lFncGetAENo(ByVal acc_no As String, ByVal month As String) As String
        Dim lstrSQL As String = ""
        lstrSQL = "Select distinct ae_no_s from draft_comm_acc_master_d where acc_no= '" & acc_no & "' and txmonth= '" & _
            month & "' and ae_no_s <> '' order by ae_no_s "
        Dim lds As DataSet = Nothing
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return GFncNoNullString(lds.Tables(0).Rows(0).Item("ae_no_s")).Trim
        Else
            Return ""
        End If
    End Function

    Protected Friend Function lFncGetAEGroup(ByVal ae_no As String, ByVal month As String) As DataSet
        Dim lstrSQL As String = ""
        lstrSQL = "Select ae_group_s from draft_comm_group_s where ae_no= '" & ae_no & "' and txmonth= '" & month & "'"
        Dim lds As DataSet = Nothing
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "acgp")
        Return lds
    End Function

    Protected Friend Function lFncGetManNo(ByVal acc_no As String, ByVal month As String) As String
        Dim lstrSQL As String = ""
        lstrSQL = "Select man_no_s from draft_comm_acc_master_d where acc_no= '" & acc_no & "' and txmonth= '" & month & "'"
        Dim lds As DataSet = Nothing
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "manno")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return GFncNoNullString(lds.Tables(0).Rows(0).Item("man_no_s")).Trim
        Else
            Return ""
        End If
    End Function

    Protected Friend Function lFncValidAC(ByVal acc_no As String) As Boolean
        Dim lstrSQL As String = ""
        lstrSQL = "Select * from draft_comm_acc_master where acc_no= '" & acc_no & "' and inSec=1"
        Dim lds As DataSet = Nothing
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "ac")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Friend Function lFncGetManList(ByVal comm_month As String, ByVal rate_type As String, ByVal man_no As String, _
        ByVal man_group As String, ByVal comm_type As String, ByVal turnoverType As String, _
        Optional ByVal DefVal As Boolean = False) As DataSet
        Dim lstrSQL As String = ""
        If Not DefVal Then
            If (rate_type.Length > 0) Then
                lstrSQL += "and a.rate_type = '" & rate_type & "' "
            Else
                lstrSQL += " and (a.rate_type ='" & comm_rate_ManTurn & "' or a.rate_type = '" & comm_rate_ManBrok & "'  or a.rate_type = '" & comm_rate_ManRebate & "') "
            End If
            If man_no.Length > 0 Then
                lstrSQL += "and a.man_no = '" & man_no & "' "
            End If
            If man_group.Length > 0 Then
                lstrSQL += "and a.man_group = '" & man_group & "' "
            End If
            If turnoverType <> Nothing Then
                lstrSQL += "and a.turnover_type = '" & turnoverType & "' "
            End If
        Else
            lstrSQL += "and 1=0 "
        End If
        lstrSQL = "from draft_comm_rate_s a left outer join draft_comm_ae_master b on a.man_no = b.ae_no " & _
            "where comm_month = '" & comm_month & "' and comm_type = '" & comm_type & "' " & lstrSQL
        If (comm_type = comm_type_man) Then
            lstrSQL = "select distinct a.man_no, isnull(isnull(b.ae_name_s, b.ae_name_f),'') as man_name " & lstrSQL
        ElseIf (comm_type = comm_type_mgp) Then
            lstrSQL = "select distinct a.man_no, isnull(isnull(b.ae_name_s, b.ae_name_f),'') as man_name , a.man_group " & lstrSQL
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "Manno")
    End Function

    Protected Friend Sub lFncInsertManRate(ByVal acc_no As String, ByVal ae_no As String, ByVal ae_group As String, ByVal rate_type As String, _
        ByVal turnover_from As String, ByVal comm_rate As String, ByVal brok_rate As String, ByVal comm_month As String, ByVal comm_type As String, _
        ByVal man_no As String, ByVal man_gp As String, ByVal turnoverType As String, ByVal logtype As String, ByRef MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "insert into draft_comm_rate_s(acc_no, ae_no, acc_group, man_no, man_group, rate_type, turnover_from, " & _
            "comm_rate, brokerage_rate, comm_month, comm_type) values('" & acc_no & "', '" & ae_no & "', '" & ae_group & "', '" & _
            man_no & "', '" & man_gp & "', '" & rate_type & "', " & CDbl(turnover_from) & ", " & comm_rate & ", " & brok_rate & _
            ", '" & comm_month & "', '" & comm_type & "') "
        Dim logstr As String = GfncOneFieldLog("Account Group", ae_group) & " " & GfncOneFieldLog("Account Group", ae_group) & _
            " " & GfncOneFieldLog("Manager No.", man_no) & " " & GfncOneFieldLog("Manager Group", man_gp) & " " & _
            GfncOneFieldLog("Rate Type", rate_type) & " " & GfncOneFieldLog("Turnover From", CDbl(turnover_from)) & " " & _
            GfncOneFieldLog("Commission Rate", comm_rate) & " " & GfncOneFieldLog("Brokerage Rate", brok_rate) & " " & _
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        GFncFillLog(GStrloginID, "A", GDteTradeDate, logtype, ae_no, acc_no, 0, comm_month, logstr, MyTrans)
    End Sub

    Protected Friend Function lFncGetALLAEGroup() As DataSet
        Dim lstrSQL As String = "select distinct a.ae_no, a.ae_name_s, isnull(b.txmonth,'') as txmonth from " & _
            "draft_comm_ae_master a left outer join comm_group_s b on a.ae_no = b.ae_no order by a.ae_no, txmonth"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aegroup")
    End Function

    Protected Friend Function lFncGetALLAEGroupList() As DataSet
        Dim lstrSQL As String = "select distinct a.ae_no, a.ae_name_s, isnull(b.txmonth,'') as txmonth, " & _
            "isnull(ae_group_s,'') as ae_group, isnull(isConsolid,0) as isConsolid from draft_comm_ae_master a left outer join " & _
            "draft_comm_group_s b on a.ae_no = b.ae_no order by a.ae_no, txmonth"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aegroup")
    End Function

    Protected Friend Function lFncGetAEgroupDT(ByVal rate_type As String, ByVal comm_month As String, ByVal AEGroup As String, _
        ByVal comm_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = " and b.rate_type = '" & rate_type & "' "
        End If
        If (AEGroup <> Nothing) Then
            lstrSQL = " and b.acc_group='" & AEGroup & "' "
        End If
        lstrSQL = "select distinct a.ae_no, b.acc_group, a.ae_name_s from draft_comm_ae_master a, draft_comm_rate_s b " & _
            "where a.ae_no = b.ae_no and b.comm_month = '" & comm_month & "' and b.comm_type = '" & comm_type & "' " & _
            lstrSQL & "order by b.acc_group, a.ae_no"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aegroup")
    End Function

    Protected Friend Function lFncGetAEGRPRateList(ByVal comm_month As String, ByVal rate_type As String, ByVal ae_no As String, _
        ByVal ae_group As String, ByVal comm_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and a.rate_type = '" & rate_type & "' "
        End If
        If (Not ae_no Is Nothing) Then
            If (ae_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.ae_no = '" & ae_no & "' "
            End If
        End If
        If (Not ae_group Is Nothing) Then
            If (ae_group.Length > 0) Then
                lstrSQL = lstrSQL & "and a.acc_group = '" & ae_group & "' "
            End If
        End If
        lstrSQL = "select a.srid, a.comm_month, c.misc_desc, max(a.turnover_from) as turnover_from, " & _
            "min(b.turnover_from) as turnover_to, '' as turnover, a.comm_rate, isnull(a.brokerage_rate,0) as brokerage_rate " & _
            "from draft_comm_rate_s a left join draft_comm_rate_s b on a.acc_no = b.acc_no and a.ae_no = b.ae_no and " & _
            "a.rate_type = b.rate_type and a.comm_month = b.comm_month and a.comm_type = b.comm_type and " & _
            "a.acc_group = b.acc_group  and a.turnover_from < b.turnover_from left join misc_master c on " & _
            "a.rate_type = misc_code and misc_type = 'RATESCTACC' where a.comm_month = '" & comm_month & "' and " & _
            "a.comm_type = '" & comm_type & "' " & lstrSQL & "group by a.srid, a.acc_no, a.comm_month, c.misc_desc, " & _
            "a.comm_rate, a.brokerage_rate, a.man_no, a.man_group order by c.misc_desc, a.turnover_from"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    End Function

    Protected Friend Function lFncGetManRateList(ByVal comm_month As String, ByVal rate_type As String, ByVal man_no As String, _
        ByVal man_group As String, ByVal comm_type As String, ByVal turnover_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL += "and a.rate_type = '" & rate_type & "' "
        End If
        If (Not man_no Is Nothing) Then
            If (man_no.Length > 0) Then
                lstrSQL += lstrSQL & "and a.man_no = '" & man_no & "' "
            End If
        End If
        If (Not man_group Is Nothing) Then
            If (man_group.Length > 0) Then
                lstrSQL += lstrSQL & "and a.man_group = '" & man_group & "' "
            End If
        End If
        lstrSQL = "select a.srid, a.comm_month, c.misc_desc, max(a.turnover_from) as turnover_from, " & _
            "min(b.turnover_from) as turnover_to, '' as turnover, a.comm_rate, isnull(a.brokerage_rate,0) as brokerage_rate " & _
            "from draft_comm_rate_s a left join draft_comm_rate_s b on a.man_no = b.man_no and a.rate_type = b.rate_type " & _
            "and a.comm_month = b.comm_month and a.comm_type = b.comm_type and a.turnover_from < b.turnover_from left join " & _
            "misc_master c on a.rate_type = misc_code and misc_type = 'RATESCTACC' where a.comm_month = '" & comm_month & "' " & _
            "and a.comm_type = '" & comm_type & "' " & lstrSQL & "group by a.srid, a.acc_no, a.comm_month, c.misc_desc, " & _
            "a.comm_rate,a.brokerage_rate, a.man_no, a.man_group order by c.misc_desc, turnover_from"
        'End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    End Function

    Protected Friend Function lFncGetNextManComm(ByVal comm_month As String, ByVal rate_type As String, _
        ByVal man_group As String, ByVal man As String, ByVal comm_type As String, ByVal turnover As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select min(turnover_from) as mt from draft_comm_rate_s where man_no = '" & man & "' and man_group = '" & _
            man_group & "' and rate_type = '" & rate_type & "' and comm_month = '" & comm_month & "' and comm_type = '" & _
            comm_type & "' and turnover_from > " & turnover
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "next_comm")
        Return lds
    End Function

    Protected Friend Function GetManGP() As DataTable
        Dim lstrSQL As String = "select distinct a.man_no, isnull(isnull(b.ae_name_s,b.ae_name_f),'') as man_name, a.txmonth " & _
            "from draft_comm_man_master_d a left outer join draft_comm_ae_master b on a.man_no = b.ae_no " & _
            "where isnull(a.man_grp,'') <> '' order by a.txmonth asc, a.man_no asc "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetAccDetail() As DataTable
        Dim lstrSQL As String = "select distinct a.acc_no, b.ae_no_s, a.txmonth from draft_comm_acc_master_d a left outer join " & _
            "draft_comm_acc_master b on a.acc_no = b.acc_no where(b.inSec = 1)"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetDefDT(ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = "select comm_type='Default', txmonth, commNorRate, MinNorRate_s from draft_comm_global " & _
            "where txmonth ='" & txmonth & "' and comm_type='MAN' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Sub lFncInsertAERate(ByVal acc_no As String, ByVal ae_no As String, ByVal ae_group As String, ByVal rate_type As String, _
        ByVal turnover_from As String, ByVal comm_rate As String, ByVal brok_rate As String, ByVal comm_month As String, _
        ByVal comm_type As String, ByRef MyTrans As SqlTransaction, ByVal range_type As String, Optional ByVal logtype As String = "")
        Dim lstrSQL As String = ""
        lstrSQL = "insert into draft_comm_rate_s (acc_no, ae_no, acc_group, rate_type, turnover_from, comm_rate, " & _
            "brokerage_rate, comm_month, comm_type, turnover_type) values ('" & acc_no & "', '" & ae_no & "', '" & ae_group & _
            "', '" & rate_type & "', " & CDbl(turnover_from) & ", " & comm_rate & ", " & brok_rate & ", '" & comm_month & _
            "', '" & comm_type & "', '" & range_type & "')"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logStr As String = GfncOneFieldLog("Account Group", ae_group) & " " & GfncOneFieldLog("Rate Type", rate_type) & " " & _
            GfncOneFieldLog("Turnover from", CDbl(turnover_from)) & " " & GfncOneFieldLog("Commission Rate", comm_rate) & " " & _
            GfncOneFieldLog("Brokerage Rate", brok_rate) & " " & GfncOneFieldLog("Commission Type", comm_type) & " " & _
            GfncOneFieldLog("Turnover Type", range_type)
        GFncFillLog(GStrloginID, "A", GDteTradeDate, logtype, ae_no, acc_no, 0, comm_month, logStr, MyTrans)
    End Sub

    Protected Friend Sub lFncModifyAERate(ByVal srid As String, ByVal rate_type As String, ByVal turnover_from As String, _
        ByVal comm_rate As String, ByVal brok_rate As String, ByVal ae_group As String, ByVal man_group As String, _
        ByRef MyTrans As SqlTransaction, ByVal range_type As String, Optional ByVal logtype As String = "")
        Dim lstrSQL As String = ""
        Dim condition As String = ""
        Dim logstr As String = ""
        Dim ae As String = ""
        Dim acc As String = ""
        Dim month As String = ""
        Dim oldType As String = ""
        Dim oldTurnover As Double = 0
        Dim oldRate As Double = 0
        Dim oldAEGroup As String = ""
        Dim oldManGroup As String = ""
        Dim oldBroke As Double = 0
        Dim oldTOType As String = ""
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_s where srid = " & srid, MyTrans).Tables(0)
        If oldDt.Rows.Count > 0 Then
            ae = GFncNoNullString(oldDt.Rows(0).Item("ae_no")).Trim
            acc = GFncNoNullString(oldDt.Rows(0).Item("acc_no")).Trim
            month = GFncNoNullString(oldDt.Rows(0).Item("comm_month")).Trim
            oldType = GFncNoNullString(oldDt.Rows(0).Item("rate_type")).Trim
            oldTurnover = GFncNoNullValue(oldDt.Rows(0).Item("turnover_from"))
            oldRate = GFncNoNullValue(oldDt.Rows(0).Item("comm_rate"))
            oldAEGroup = GFncNoNullString(oldDt.Rows(0).Item("acc_group")).Trim
            oldManGroup = GFncNoNullString(oldDt.Rows(0).Item("man_group")).Trim
            oldBroke = GFncNoNullValue(oldDt.Rows(0).Item("brokerage_rate"))
            oldTOType = GFncNoNullString(oldDt.Rows(0).Item("turnover_type")).Trim
        End If
        If oldType <> rate_type.Trim Then
            logstr &= GfncOneFieldLog("Rate Type", oldType, rate_type.Trim)
        End If
        If oldTurnover <> CDbl(turnover_from) Then
            logstr &= GfncOneFieldLog("Turnover From", oldTurnover, CDbl(turnover_from))
        End If
        If oldRate <> comm_rate Then
            logstr &= GfncOneFieldLog("Commission Rate", oldRate, comm_rate)
        End If
        If oldAEGroup <> ae_group.Trim Then
            logstr &= GfncOneFieldLog("Account Group", oldAEGroup, ae_group.Trim)
        End If
        If oldManGroup <> man_group.Trim Then
            logstr &= GfncOneFieldLog("Manager Group", oldManGroup, man_group.Trim)
        End If
        If oldBroke <> brok_rate Then
            logstr &= GfncOneFieldLog("Brokerage Rate", oldBroke, brok_rate)
        End If

        If range_type <> "" Then
            condition = ", turnover_type =  '" & range_type & "' "
            If oldTOType <> range_type.Trim Then
                logstr &= GfncOneFieldLog("Turnover Type", oldTOType, range_type.Trim)
            End If
        End If
        lstrSQL = "update draft_comm_rate_s set rate_type = '" & rate_type & "', turnover_from = " & CDbl(turnover_from) & _
            ", comm_rate = " & comm_rate & ", acc_group = '" & ae_group & "', man_group='" & man_group & _
            "', brokerage_rate = " & brok_rate & condition & " where srid = " & srid
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        GFncFillLog(GStrloginID, "M", GDteTradeDate, logtype, ae, acc, srid, month, logstr, MyTrans)
    End Sub


    Protected Friend Function lFncGetAERateList(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal man_no As String, ByVal man_group As String, ByVal comm_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and a.rate_type = '" & rate_type & "' "
        Else
            lstrSQL = "and (a.rate_type = '" & comm_rate_nor & "' or a.rate_type ='" & comm_rate_int & "' or a.rate_type ='" & comm_rate_con & "') "
        End If
        If (Not acc_no Is Nothing) Then
            If (acc_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.acc_no = '" & acc_no & "' "
            End If
        End If
        If (Not ae_no Is Nothing) Then
            If (ae_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.ae_no = '" & ae_no & "' "
            End If
        End If
        If (Not man_no Is Nothing) Then
            If (man_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.man_no = '" & man_no & "' "
            End If
        End If
        If (Not man_group Is Nothing) Then
            If (man_group.Length > 0) Then
                lstrSQL = lstrSQL & "and a.man_group = '" & man_group & "' "
            End If
        End If
        lstrSQL = "select a.srid, a.comm_month, c.misc_desc, max(a.turnover_from) as turnover_from, " & _
            "min(b.turnover_from) as turnover_to, '' as turnover, isnull(rtrim(a.turnover_type),'') as turnover_type, " & _
            "a.comm_rate, isnull(a.brokerage_rate,0) as brokerage_rate from draft_comm_rate_s a left join draft_comm_rate_s b " & _
            "on a.acc_no = b.acc_no and a.ae_no = b.ae_no and a.rate_type = b.rate_type and a.comm_month = b.comm_month and " & _
            "a.comm_type = b.comm_type and a.turnover_from < b.turnover_from and a.turnover_type = b.turnover_type left join " & _
            "misc_master c on a.rate_type = misc_code and misc_type = 'RATESCTACC' where a.comm_month = '" & comm_month & _
            "' and a.comm_type = '" & comm_type & "' " & lstrSQL & "group by a.srid, a.acc_no, a.comm_month, c.misc_desc, " & _
            "a.turnover_type, a.comm_rate, a.brokerage_rate, a.man_no, a.man_group order by c.misc_desc, a.turnover_type, turnover_from"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    End Function

    Protected Friend Function lFncGetSplAEList(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal comm_type As String, Optional ByVal ae_no As String = "") As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and b.rate_type = '" & rate_type & "' "
        Else
            lstrSQL = "and (b.rate_type = '" & comm_rate_er_nor & "' or b.rate_type ='" & comm_rate_er_int & _
                        "' or b.rate_type ='" & comm_rate_er_con & "') "
        End If
        If (Not acc_no Is Nothing) Then
            If (acc_no.Length > 0) Then
                lstrSQL = lstrSQL & "and b.acc_no = '" & acc_no & "' "
            End If
        End If
        If (ae_no.Length > 0) Then
            lstrSQL = lstrSQL & "and b.ae_no = '" & ae_no & "' "
        End If
        lstrSQL = "from draft_comm_ae_master a, draft_comm_rate_s b where a.ae_no = b.ae_no and b.comm_month = '" & comm_month & _
            "' and b.comm_type = '" & comm_type & "' " & lstrSQL & "order by a.ae_no"
        If (comm_type = comm_type_acc Or comm_type = comm_type_man Or comm_type = comm_type_mgp Or comm_type = comm_type_ae) Then
            lstrSQL = "select distinct a.ae_no, a.ae_name_s " & lstrSQL
        ElseIf (comm_type = comm_type_agp) Then
            lstrSQL = "select distinct a.ae_no, acc_group, a.ae_name_s " & lstrSQL
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
    End Function

    Protected Friend Function lFncGetSplAERateList(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal man_no As String, ByVal man_group As String, ByVal comm_type As String) As DataSet
        Dim lstrSQL As String = ""
        If (rate_type.Length > 0) Then
            lstrSQL = "and a.rate_type = '" & rate_type & "' "
        Else
            lstrSQL = "and (a.rate_type = '" & comm_rate_er_nor & "' or a.rate_type = '" & comm_rate_er_int & _
                "' or a.rate_type = '" & comm_rate_er_con & "') "
        End If
        If (Not acc_no Is Nothing) Then
            If (acc_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.acc_no = '" & acc_no & "' "
            End If
        End If
        If (Not ae_no Is Nothing) Then
            If (ae_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.ae_no = '" & ae_no & "' "
            End If
        End If
        If (Not man_no Is Nothing) Then
            If (man_no.Length > 0) Then
                lstrSQL = lstrSQL & "and a.man_no = '" & man_no & "' "
            End If
        End If
        If (Not man_group Is Nothing) Then
            If (man_group.Length > 0) Then
                lstrSQL = lstrSQL & "and a.man_group = '" & man_group & "' "
            End If
        End If
        lstrSQL = "select a.srid, a.comm_month, isnull(c.misc_desc, '') as misc_desc, max(a.turnover_from) as turnover_from, " & _
            "min(b.turnover_from) as turnover_to, '' as turnover, isnull(rtrim(a.turnover_type),'') as turnover_type, " & _
            "a.comm_rate, isnull(a.brokerage_rate,0) as brokerage_rate from draft_comm_rate_s a left join draft_comm_rate_s b " & _
            "on a.acc_no = b.acc_no and a.ae_no = b.ae_no and a.rate_type = b.rate_type and a.comm_month = b.comm_month " & _
            "and a.comm_type = b.comm_type and a.turnover_from < b.turnover_from and a.turnover_type = b.turnover_type " & _
            "left join misc_master c on a.rate_type = misc_code and misc_type = 'RATESCTACC' where a.comm_month = '" & _
            comm_month & "' and a.comm_type = '" & comm_type & "' " & lstrSQL & " group by a.srid, a.acc_no, a.comm_month, " & _
            "c.misc_desc, a.turnover_type, a.comm_rate, a.brokerage_rate, a.man_no, a.man_group order by c.misc_desc, a.turnover_type"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
    End Function

End Class