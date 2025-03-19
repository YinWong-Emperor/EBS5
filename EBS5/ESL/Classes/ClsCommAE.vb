Imports System.Data.SqlClient

Public Class ClsCommAE
    Dim ldsDefault As DataSet = Nothing
    Dim ldsGrpList As DataSet = Nothing
    Dim ldsAccList As DataSet = Nothing
    Dim ldsTrade As DataSet = Nothing
    Dim ldsRate As DataSet = Nothing
    Dim ldsAEList As DataSet = Nothing
    Dim ldsAETotal As DataSet = Nothing
    Dim ldsGroupAEList As DataSet = Nothing
    Dim ldsGroupAETotal As DataSet = Nothing

    Protected Friend Function lFncGetTxMonth() As DataTable
        Dim lstrSQL As String = " select distinct  txmonth from comm_trade_s union select distinct  txmonth from comm_trade_f " & _
            "order by txmonth desc "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function lFncGetAccF(ByVal strMonth As String) As DataTable
        Dim lstrSQL As String = " select * from comm_acc_master_d where txmonth = '" & strMonth & "' order by acc_no "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function lFncGetAE(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_ae_master_d " & _
                " where txmonth = '" & strMonth & _
               "' order by ae_no "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lFncGetCommAdj(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_comm_adj " & _
                " where txmonth = '" & strMonth & _
               "' order by ae_no "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function

    Protected Friend Function lFncGetAccGroupF(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_group_f " & _
                " where txmonth = '" & strMonth & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lFncGetRateF(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_rate_f  " & _
                  " where comm_month = '" & strMonth & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lFncGetRateOther(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_rate_other  " & _
                  " where comm_month = '" & strMonth & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lFncGetProdGrpF(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_product_group " & _
                  " where txmonth = '" & strMonth & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lFncGetGlobalF(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_global " & _
                  " where txmonth = '" & strMonth & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lFncGetTurnOverF(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select a.txmonth, a.accno as acc_no, tradetype, case when call_put = 0 then 'F' else 'O' end as txtype, " & _
                    " a.aeno as ae_no ,isnull(b.acc_group_f, '') as acc_group_f, isnull(b.isconsolid, 0) as isconsolid, commod, isbothfo," & _
                    " sum(day_mm - i_day_mm) as nor_total_day,  sum(night_mm - i_night_mm) as nor_total_night, " & _
                    " sum(i_day_mm) as int_total_day,  sum(i_night_mm) as int_total_night, " & _
                    " sum(day_commission - i_day_commission) as day_comm_nor,  sum(night_commission - i_night_commission) as night_comm_nor, " & _
                    " sum(i_day_commission) as day_comm_int,  sum(i_night_commission) as night_comm_int " & _
                    " from view_comm_adjusted_f a left outer join comm_acc_master_d b " & _
                    " on a.txmonth = b.txmonth and b.ae_no_f = a.aeno and b.acc_no = a.accno " & _
                    " where a.txmonth = '" & strMonth & "' " & _
                      " and ( a.aeno in ( select ae_no from comm_ae_master_d c where a.txmonth = c.txmonth and iscommission_f = 1) " & _
                    " or exists (select * from comm_acc_master_d d where a.txmonth = d.txmonth and a.accno = d.acc_no and a.aeno = d.ae_no_f)) " & _
                    " group by  a.txmonth,a.accno, tradetype," & _
                    " case when call_put = 0 then 'F' else 'O' end, a.aeno, b.acc_group_f, b.isconsolid, commod, isbothfo " & _
                    " order by  a.txmonth,  a.aeno, a.accno, b.acc_group_f, a.tradetype, b.isconsolid, commod, isbothfo "

        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lfncParpareTODTF(ByVal strMonth As String) As DataTable

        Dim ldtTO As DataTable = lFncGetTurnOverF(strMonth)
        Dim ldtRate As DataTable = lFncGetRateF(strMonth)
        Dim ldtPG As DataTable = lFncGetProdGrpF(strMonth)
        Dim ldtGlobal As DataTable = lFncGetGlobalF(strMonth)
        Dim ldtGrp As DataTable = lFncGetAccGroupF(strMonth)
        Dim ldtAE As DataTable = lFncGetAE(strMonth)
        Dim ldtAcc As DataTable = lFncGetAccF(strMonth)
        Dim ldtDetail As New DataTable
        InitDetailDTF(ldtDetail)

        For Each ldrTO As DataRow In ldtTO.Rows
            Dim ldr As DataRow() = ldtDetail.Select(" acc_no = '" & ldrTO("acc_no") & _
                "' and ae_no = '" & ldrTO("ae_no") & "' and commod = '" & _
                ldrTO("commod") & "' and txtype = '" & ldrTO("txtype").ToString.Trim & "'")
            If ldr.Length > 0 Then
                ldr(0).Item("day_nor") += ldrTO("nor_total_day")
                ldr(0).Item("night_nor") += ldrTO("nor_total_night")
                ldr(0).Item("day_int") += ldrTO("int_total_day")
                ldr(0).Item("night_int") += ldrTO("int_total_night")
                ldr(0).Item("day_comm_nor") += ldrTO("day_comm_nor")
                ldr(0).Item("night_comm_nor") += ldrTO("night_comm_nor")
                ldr(0).Item("day_comm_int") += ldrTO("day_comm_int")
                ldr(0).Item("night_comm_int") += ldrTO("night_comm_int")
            Else
                Dim ldrDetail As DataRow = ldtDetail.NewRow
                ldrDetail("txmonth") = strMonth
                ldrDetail("acc_no") = ldrTO("acc_no")
                ldrDetail("ae_no") = ldrTO("ae_no")
                ldrDetail("acc_group") = ldrTO("acc_group_f").ToString.Trim
                ldrDetail("txtype") = ldrTO("txtype").ToString.Trim
                ldrDetail("isbothfo") = ldrTO("isbothfo")
                ldrDetail("day_nor") = 0
                ldrDetail("day_int") = 0
                ldrDetail("night_nor") = 0
                ldrDetail("night_int") = 0
                ldrDetail("day_nor") = GFncNoNullValue(ldrTO("nor_total_day"))
                ldrDetail("night_nor") = GFncNoNullValue(ldrTO("nor_total_night"))
                ldrDetail("day_int") = GFncNoNullValue(ldrTO("int_total_day"))
                ldrDetail("night_int") = GFncNoNullValue(ldrTO("int_total_night"))
                ldrDetail("isconsolid") = GFncNoNullValue(ldrTO("isconsolid"))
                ldrDetail("commod") = ldrTO("commod")
                ldrDetail("day_comm_nor") = GFncNoNullValue(ldrTO("day_comm_nor"))
                ldrDetail("night_comm_nor") = GFncNoNullValue(ldrTO("night_comm_nor"))
                ldrDetail("day_comm_int") = GFncNoNullValue(ldrTO("day_comm_int"))
                ldrDetail("night_comm_int") = GFncNoNullValue(ldrTO("night_comm_int"))
                ldrDetail("ae_comm") = 0
                ldrDetail("day_rate_nor") = 0
                ldrDetail("night_rate_nor") = 0
                ldrDetail("day_rate_int") = 0
                ldrDetail("night_rate_int") = 0
                ldrDetail("night_nor_total_TO") = 0
                ldrDetail("night_int_total_TO") = 0
                ldrDetail("day_nor_total_TO") = 0
                ldrDetail("day_int_total_TO") = 0
                ldrDetail("night_nor_g_total_TO") = 0
                ldrDetail("night_int_g_total_TO") = 0
                ldrDetail("day_nor_g_total_TO") = 0
                ldrDetail("day_int_g_total_TO") = 0
                ldrDetail("night_nor_ae_total_TO") = 0
                ldrDetail("night_int_ae_total_TO") = 0
                ldrDetail("day_nor_ae_total_TO") = 0
                ldrDetail("day_int_ae_total_TO") = 0
                ldrDetail("night_nor_ae_total_TO_b") = 0
                ldrDetail("night_int_ae_total_TO_b") = 0
                ldrDetail("day_nor_ae_total_TO_b") = 0
                ldrDetail("day_int_ae_total_TO_B") = 0
                ldrDetail("night_nor_total_TO_b") = 0
                ldrDetail("night_int_total_TO_b") = 0
                ldrDetail("day_nor_total_TO_b") = 0
                ldrDetail("day_int_total_TO_b") = 0
                ldrDetail("night_nor_g_total_TO_b") = 0
                ldrDetail("night_int_g_total_TO_b") = 0
                ldrDetail("day_nor_g_total_TO_B") = 0
                ldrDetail("day_int_g_total_TO_b") = 0
                ldtDetail.Rows.Add(ldrDetail)
            End If
        Next

        lfuncUpdPGTOF(ldtPG, ldtDetail)
        lfncCalCommF(ldtDetail, ldtRate, ldtPG, ldtGrp, ldtGlobal, ldtAE, ldtAcc)


        Return ldtDetail

    End Function
    Protected Friend Function lfncCalOther(ByVal strMonth As String, ByVal dtComm As DataTable) As DataTable
        Dim ldtAE As DataTable = lFncGetAE(strMonth)
        Dim ldtRateOther As DataTable = lFncGetRateOther(strMonth)
        Dim ldrAE As DataRow() = ldtAE.Select(" incentive_flag = 1 or bonus_flag = 1 ")

        For lintCnt As Integer = 0 To ldrAE.Length - 1
            Dim ldrComm As DataRow() = dtComm.Select(" ae_no = '" & ldrAE(lintCnt).Item("ae_no") & "'")
            If ldrComm.Length > 0 Then
                Dim ldecCoComm As Decimal = ldrcomm(0).item("total_brok_s") + ldrcomm(0).item("total_brok_f") _
               + ldrcomm(0).item("total_brok_o") - ldrcomm(0).item("total_comm_s") - ldrComm(0).Item("total_comm_f") _
                - ldrComm(0).Item("total_comm_o")
                If ldrComm(0).Item("total_comm_s") + ldrComm(0).Item("total_comm_f") _
                    + ldrComm(0).Item("total_comm_o") > 0 Then
                    If ldrAE(lintCnt).Item("incentive_flag") Then
                        Dim ldrRate As DataRow = lfncCalRateOther(ldrComm(0), "INCAE", ldtRateOther)
                        If Not IsNothing(ldrRate) Then
                            ldrComm(0).Item("total_comm_i") = ldecCoComm * ldrRate("comm_rate") / 100
                            ldrComm(0).Item("comm_rate_inc") = ldrRate("comm_rate")
                        End If
                    End If
                    If ldrAE(lintCnt).Item("bonus_flag") Then
                        Dim ldrRate As DataRow = lfncCalRateOther(ldrComm(0), "BONAE", ldtRateOther)
                        If Not IsNothing(ldrRate) Then
                            ldrComm(0).Item("total_comm_b") = ldecCoComm * ldrRate("comm_rate") / 100
                            ldrComm(0).Item("comm_rate_bon") = ldrRate("comm_rate")
                        End If
                    End If
                End If
            End If
        Next

        Return dtComm

    End Function
    Protected Friend Function lfncCalRateOther(ByVal drComm As DataRow, _
    ByVal strCommType As String, ByVal dtRateOther As DataTable) As DataRow

        Dim ldecCoComm As Decimal = drComm("total_brok_s") + drComm("total_brok_f") _
                + drComm("total_brok_o") - drComm("total_comm_s") - drComm("total_comm_f") _
                 - drComm("total_comm_o")
        Dim ldrRateOther As DataRow() = dtRateOther.Select(" comm_type = '" & strCommType & _
                    "' and ae_no = '" & drComm("ae_no") & "'", " comm_net_brok desc ")
        If ldrRateOther.Length > 0 Then
            For lintCnt As Integer = 0 To ldrRateOther.Length - 1
                If ldecCoComm >= ldrRateOther(lintCnt).Item("comm_net_brok") Then
                    Return ldrRateOther(lintCnt)
                End If
            Next
        Else
            Dim ldrRateDef As DataRow() = dtRateOther.Select(" comm_type = 'DEF" & strCommType & _
                                "'", " comm_net_brok desc ")
            For lintCnt As Integer = 0 To ldrRateDef.Length - 1
                If ldecCoComm >= ldrRateDef(lintCnt).Item("comm_net_brok") Then
                    Return ldrRateDef(lintCnt)
                End If
            Next
        End If

        Return Nothing

    End Function
    Protected Friend Function lfncUpdComm(ByVal strMonth As String, ByVal dtDetailS As DataTable, _
    ByVal dtDetailF As DataTable) As DataTable

        Dim ldtComm As New DataTable
        Dim lstrSQL As String = ""

        InitCommDTF(ldtComm)
        For Each ldrDetail As DataRow In dtDetailF.Rows
            Dim ldrComm As DataRow() = ldtComm.Select("ae_no = '" & ldrDetail("ae_no").ToString.Trim & "'")
            If ldrComm.Length > 0 Then
                If ldrDetail("txtype") = "F" Then
                    ldrComm(0).Item("total_brok_f") += ldrDetail("day_comm_nor") + ldrDetail("night_comm_nor") + _
                                    ldrDetail("day_comm_int") + ldrDetail("night_comm_int")
                    ldrComm(0).Item("total_comm_f") += ldrDetail("ae_comm")
                    ldrComm(0).Item("total_TO_f") += ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                          + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                Else
                    ldrComm(0).Item("total_brok_o") += ldrDetail("day_comm_nor") + ldrDetail("night_comm_nor") + _
                                    ldrDetail("day_comm_int") + ldrDetail("night_comm_int")
                    ldrComm(0).Item("total_comm_o") += ldrDetail("ae_comm")
                    ldrComm(0).Item("total_TO_o") += ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                          + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                End If
            Else
                Dim ldr As DataRow
                ldr = ldtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrDetail("ae_no").ToString.Trim
                ldr("total_brok_o") = 0
                ldr("total_comm_o") = 0
                ldr("total_brok_f") = 0
                ldr("total_comm_f") = 0
                ldr("total_TO_o") = 0
                ldr("total_TO_s") = 0
                ldr("total_TO_f") = 0
                If ldrDetail("txtype") = "F" Then
                    ldr("total_brok_f") = ldrDetail("day_comm_nor") + ldrDetail("night_comm_nor") + _
                                    ldrDetail("day_comm_int") + ldrDetail("night_comm_int")
                    ldr("total_comm_f") = ldrDetail("ae_comm")
                    ldr("total_TO_f") = ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                           + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                Else
                    ldr("total_brok_o") = ldrDetail("day_comm_nor") + ldrDetail("night_comm_nor") + _
                                    ldrDetail("day_comm_int") + ldrDetail("night_comm_int")
                    ldr("total_comm_o") = ldrDetail("ae_comm")
                    ldr("total_TO_o") = ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                          + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                End If
                ldr("total_brok_s") = 0
                ldr("total_comm_s") = 0
                ldr("total_comm_i") = 0
                ldr("total_comm_b") = 0
                ldr("total_comm_a_s") = 0
                ldr("total_comm_a_f") = 0
                ldr("total_comm_m") = 0
                ldr("comm_rate_inc") = 0
                ldr("comm_rate_bon") = 0
                ldr("man_no_s") = ""
                ldr("man_no_f") = ""
                ldtComm.Rows.Add(ldr)
            End If
        Next
        For Each ldrDetail As DataRow In dtDetailS.Rows
            Dim ldrComm As DataRow() = ldtComm.Select("ae_no = '" & ldrDetail("ae_no").ToString.Trim & "'")
            If ldrComm.Length > 0 Then
                ldrComm(0).Item("total_brok_s") += ldrDetail("ae_comm") + ldrDetail("co_comm")
                ldrComm(0).Item("total_comm_s") += ldrDetail("ae_comm")
                ldrComm(0).Item("total_TO_s") += ldrDetail("grossamt")
            Else
                Dim ldr As DataRow
                ldr = ldtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrDetail("ae_no").ToString.Trim
                ldr("total_brok_s") = ldrDetail("ae_comm") + ldrDetail("co_comm")
                ldr("total_comm_s") = ldrDetail("ae_comm")
                ldr("total_brok_o") = 0
                ldr("total_TO_o") = 0
                ldr("total_TO_s") = ldrDetail("grossamt")
                ldr("total_TO_f") = 0
                ldr("total_comm_o") = 0
                ldr("total_brok_f") = 0
                ldr("total_comm_f") = 0
                ldr("total_comm_i") = 0
                ldr("total_comm_b") = 0
                ldr("total_comm_a_s") = 0
                ldr("total_comm_a_f") = 0
                ldr("total_comm_m") = 0
                ldr("comm_rate_inc") = 0
                ldr("comm_rate_bon") = 0
                ldr("man_no_s") = ""
                ldr("man_no_f") = ""
                ldtComm.Rows.Add(ldr)
            End If
        Next


        Return ldtComm

    End Function
    Protected Friend Function lfncUpdCommM(ByVal strMonth As String, _
    ByVal dtComm As DataTable, ByVal dtDetailM As DataTable) As DataTable
        Dim ldtCommAdj As DataTable = lFncGetCommAdj(strMonth)

        For Each ldrDetail As DataRow In dtDetailM.Rows
            Dim ldrComm As DataRow() = dtComm.Select(" ae_no = '" & ldrDetail("man_no").ToString.Trim & "'")
            If ldrComm.Length > 0 Then
                ldrComm(0).Item("total_comm_m") += ldrDetail("comm_s") + ldrDetail("comm_f") + ldrDetail("comm_o")
            Else
                Dim ldr As DataRow
                ldr = dtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrDetail("man_no").ToString.Trim
                ldr("total_brok_s") = 0
                ldr("total_comm_s") = 0
                ldr("total_brok_o") = 0
                ldr("total_TO_o") = 0
                ldr("total_TO_s") = 0
                ldr("total_TO_f") = 0
                ldr("total_comm_o") = 0
                ldr("total_brok_f") = 0
                ldr("total_comm_f") = 0
                ldr("total_comm_i") = 0
                ldr("total_comm_b") = 0
                ldr("total_comm_a_s") = 0
                ldr("total_comm_a_f") = 0
                ldr("total_comm_m") = ldrDetail("comm_s") + ldrDetail("comm_f") + ldrDetail("comm_o")
                ldr("comm_rate_inc") = 0
                ldr("comm_rate_bon") = 0
                ldr("man_no_s") = ""
                ldr("man_no_f") = ""
                dtComm.Rows.Add(ldr)
            End If
            ldrComm = dtComm.Select("ae_no = '" & ldrDetail("ae_no") & "'")
            If ldrComm.Length > 0 Then
                If ldrDetail("basis_s").ToString.Trim <> "" Then
                    ldrComm(0).Item("man_no_s") = ldrDetail("man_no")
                End If
                If ldrDetail("basis_f").ToString.Trim <> "" Then
                    ldrComm(0).Item("man_no_f") = ldrDetail("man_no")
                End If
            End If
        Next

        For Each ldrAdj As DataRow In ldtCommAdj.Rows
            Dim ldrComm As DataRow() = dtComm.Select("ae_no = '" & ldrAdj("ae_no").ToString.Trim & "'")
            If ldrComm.Length > 0 Then
                If ldrAdj("secfut") = "S" Then
                    ldrComm(0).Item("total_comm_a_s") = ldrAdj("adj_amt")
                Else
                    ldrComm(0).Item("total_comm_a_f") = ldrAdj("adj_amt")
                End If
            Else
                Dim ldr As DataRow
                ldr = dtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrAdj("ae_no").ToString.Trim
                ldr("total_brok_s") = 0
                ldr("total_comm_s") = 0
                ldr("total_brok_o") = 0
                ldr("total_TO_o") = 0
                ldr("total_TO_s") = 0
                ldr("total_TO_f") = 0
                ldr("total_comm_o") = 0
                ldr("total_brok_f") = 0
                ldr("total_comm_f") = 0
                ldr("total_comm_i") = 0
                ldr("total_comm_b") = 0
                ldr("total_comm_m") = 0
                ldr("total_comm_a_s") = 0
                ldr("total_comm_a_f") = 0
                If ldrAdj("secfut") = "S" Then
                    ldr("total_comm_a_s") = ldrAdj("adj_amt")
                Else
                    ldr("total_comm_a_f") = ldrAdj("adj_amt")
                End If
                ldr("comm_rate_inc") = 0
                ldr("comm_rate_bon") = 0
                ldr("man_no_s") = ""
                ldr("man_no_f") = ""
                dtComm.Rows.Add(ldr)
            End If
        Next

        Return dtComm

    End Function

    Protected Friend Function lfncUpdateTable(ByVal strMonth As String, ByVal dtComm As DataTable) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = ""
        Dim logstr As String = ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lstrSQL = " delete from comm_ae_comm where txmonth = '" & strMonth & "' "
            GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0)
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "CommGen", "", "", 0, strMonth, "Commission Generation", lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            For Each ldrComm As DataRow In dtComm.Rows
                logstr = ""
                lstrSQL = " insert into comm_ae_comm (txmonth, ae_no, comm_s, comm_f, comm_o, incentive_comm, bonus_comm, comm_paid_s, " & _
                            "comm_paid_f, comm_adj_s, comm_adj_f, override_comm, brokerage_s, brokerage_f, brokerage_o, managerno_s, " & _
                            "managerno_f, luptuser, luptdate ) values ('" & strMonth & "', '" & ldrComm("ae_no") & "', " & _
                            ldrComm("total_comm_s") & ", " & ldrComm("total_comm_f") & ", " & ldrComm("total_comm_o") & ", " & _
                            ldrComm("total_comm_i") & ", " & ldrComm("total_comm_b") & ", 0, 0, " & ldrComm("total_comm_a_s") & ", " & _
                            ldrComm("total_comm_a_f") & ", " & ldrComm("total_comm_m") & ", " & ldrComm("total_brok_s") & ", " & _
                            ldrComm("total_brok_f") & ", " & ldrComm("total_brok_o") & ", '" & ldrComm("man_no_s") & "', '" & _
                            ldrComm("man_no_f") & "', '" & GStrloginID & "', getdate()) "
                If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    lstnTrans.Rollback()
                    Return False
                End If
                'logstr = GfncOneFieldLog("Comm. Securities", Math.Round(GFncNoNullValue(ldrComm("total_comm_s"))), 2) & " " & _
                '            GfncOneFieldLog("Comm. Futures", Math.Round(GFncNoNullValue(ldrComm("total_comm_f"))), 2) & " " & _
                '            GfncOneFieldLog("Comm. O", Math.Round(GFncNoNullValue(ldrComm("total_comm_o"))), 2) & " " & _
                '            GfncOneFieldLog("Incentive Comm.", Math.Round(GFncNoNullValue(ldrComm("total_comm_i"))), 2) & " " & _
                '            GfncOneFieldLog("Bonus Comm.", Math.Round(GFncNoNullValue(ldrComm("total_comm_b"))), 2) & " " & _
                '            GfncOneFieldLog("Comm. Paid Securities", 0) & " " & GfncOneFieldLog("Comm. Paid Futures", 0) & " " & _
                '            GfncOneFieldLog("Comm. Adj. Securities", Math.Round(GFncNoNullValue(ldrComm("total_comm_a_s"))), 2) & " " & _
                '            GfncOneFieldLog("Comm. Adj. Futures", Math.Round(GFncNoNullValue(ldrComm("total_comm_a_f"))), 2) & " " & _
                '            GfncOneFieldLog("Override Comm.", Math.Round(GFncNoNullValue(ldrComm("total_comm_m"))), 2) & " " & _
                '            GfncOneFieldLog("Brokerage Securities", Math.Round(GFncNoNullValue(ldrComm("total_brok_s"))), 2) & " " & _
                '            GfncOneFieldLog("Brokerage Futures", Math.Round(GFncNoNullValue(ldrComm("total_brok_f"))), 2) & " " & _
                '            GfncOneFieldLog("Brokerage O", Math.Round(GFncNoNullValue(ldrComm("total_brok_o"))), 2) & " " & _
                '            GfncOneFieldLog("Manager No. Securities", GFncNoNullString(ldrComm("man_no_s")).Trim) & " " & _
                '            GfncOneFieldLog("Manager No. Futures", GFncNoNullString(ldrComm("man_no_f")).Trim)
                'If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "CommGen", GFncNoNullString(ldrComm("ae_no")).Trim, "", 0, strMonth, logstr, lstnTrans) Then
                '    lstnTrans.Rollback()
                '    GSubShowInfo(GFncGetSysMsg(9))
                '    Return False
                'End If
            Next
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
            lstnTrans = Nothing
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function
    Protected Friend Function lfncCalCommF(ByRef dtDetail As DataTable, _
    ByVal dtRate As DataTable, ByVal dtPG As DataTable, _
    ByVal dtGrp As DataTable, ByVal dtGlobal As DataTable, _
    ByVal dtAE As DataTable, ByVal dtAcc As DataTable) As Boolean

        Dim ldrDetail As DataRow() = dtDetail.Select(" acc_group = '' ")
        Dim ldrGlobal As DataRow()
        Dim ldrRate As DataRow
        Dim lblnIsCon As Boolean = False
        Dim lblnISFo As Boolean = False
        For lintCnt As Integer = 0 To ldrDetail.Length - 1
            Dim ldrAcc As DataRow() = dtAcc.Select(" acc_no = '" & ldrDetail(lintCnt).Item("acc_no") & _
                                "' and ae_no_f = '" & ldrDetail(lintCnt).Item("ae_no") & "' ")
            Dim ldrAE As DataRow() = dtAE.Select("  ae_no = '" & ldrDetail(lintCnt).Item("ae_no") & "' and iscommission_f = 1 ")

            If ldrDetail(lintCnt).Item("ae_no").ToString.Trim = "0515" Then
                Debug.Print("")
            End If
            Dim lstrCommType As String = ""
            If ldrAcc.Length > 0 Then
                lstrCommType = "ACC"
                lblnIsCon = ldrDetail(lintCnt).Item("isconsolid")
                lblnISFo = ldrAcc(0).Item("isbothfo")
            ElseIf ldrAE.Length > 0 Then
                lstrCommType = "AE"
                lblnIsCon = ldrAE(0).Item("isconsolid")
                lblnISFo = ldrAE(0).Item("isbothfo")
            End If
            If lstrCommType = "AE" Or lstrCommType = "ACC" Then
                ldrGlobal = dtGlobal.Select(" comm_type = '" & lstrCommType & "' ")
                If ldrDetail(lintCnt).Item("day_int") + ldrDetail(lintCnt).Item("night_int") > 0 Then
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), lstrCommType, _
                                               "INT", lblnIsCon, dtRate, dtPG, dtDetail, lblnISFo)
                    If Not IsNothing(ldrRate) Then
                        ldrDetail(lintCnt).Item("day_rate_int") = ldrRate("day_rate")
                        ldrDetail(lintCnt).Item("night_rate_int") = ldrRate("night_rate")
                    Else
                        If ldrGlobal.Length > 0 Then
                            ldrDetail(lintCnt).Item("day_rate_int") = ldrGlobal(0).Item("commintrate_f")
                            ldrDetail(lintCnt).Item("night_rate_int") = ldrGlobal(0).Item("commintrate_f")
                        End If
                    End If
                    If ldrDetail(lintCnt).Item("day_rate_int") > 0 Then
                        ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm_int") * (1 - (ldrDetail(lintCnt).Item("day_rate_int") / 100))
                    End If
                    If ldrDetail(lintCnt).Item("night_rate_int") > 0 Then
                        ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm_int") * (1 - (ldrDetail(lintCnt).Item("night_rate_int") / 100))
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_nor") + ldrDetail(lintCnt).Item("night_nor") > 0 Then
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), lstrCommType, _
                                             "NOR", lblnIsCon, dtRate, dtPG, dtDetail, lblnISFo)
                    ldrDetail(lintCnt).Item("day_rate_nor") = 0
                    ldrDetail(lintCnt).Item("night_rate_nor") = 0
                    If Not IsNothing(ldrRate) Then
                        ldrDetail(lintCnt).Item("day_rate_nor") = ldrRate("day_rate")
                        ldrDetail(lintCnt).Item("night_rate_nor") = ldrRate("night_rate")
                    Else
                        If ldrGlobal.Length > 0 Then
                            ldrDetail(lintCnt).Item("day_rate_nor") = ldrGlobal(0).Item("commnorrate_f")
                            ldrDetail(lintCnt).Item("night_rate_nor") = ldrGlobal(0).Item("commnorrate_f")
                        End If
                    End If
                    If ldrDetail(lintCnt).Item("day_rate_nor") > 0 Then
                        ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm_nor") * (1 - (ldrDetail(lintCnt).Item("day_rate_nor") / 100))
                    End If
                    If ldrDetail(lintCnt).Item("night_rate_nor") > 0 Then
                        ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm_nor") * (1 - (ldrDetail(lintCnt).Item("night_rate_nor") / 100))
                    End If
                End If
            End If

        Next

        ldrDetail = dtDetail.Select(" acc_group <> '' ")
        ldrGlobal = dtGlobal.Select(" comm_type = 'AGRP' ")
        For lintCnt As Integer = 0 To ldrDetail.Length - 1

            Dim ldrGrp As DataRow() = dtGrp.Select(" ae_group_f = '" & _
                        ldrDetail(lintCnt).Item("acc_group") & _
                        "' and ae_no = '" & ldrDetail(lintCnt).Item("ae_no") & "'")

            If ldrDetail(lintCnt).Item("day_int") + ldrDetail(lintCnt).Item("night_int") > 0 Then
                Dim lblnGroup As Boolean = False
                Dim lblnIsConsolid As Boolean = ldrDetail(lintCnt).Item("isconsolid")
                If ldrGrp.Length > 0 Then
                    lblnIsConsolid = ldrGrp(0).Item("isconsolid")
                    If ldrGrp(0).Item("isbothfo") Then
                        If ldrGrp(0).Item("isconsolid") Then
                            If ldrDetail(lintCnt).Item("day_nor_g_total_to_b") + _
                            ldrDetail(lintCnt).Item("day_int_g_total_to_b") + _
                             ldrDetail(lintCnt).Item("night_nor_g_total_to_b") + _
                            ldrDetail(lintCnt).Item("night_int_g_total_to_b") >= ldrGrp(0).Item("minconto") Then
                                lblnGroup = True
                            End If
                        Else
                            If ldrDetail(lintCnt).Item("day_int_total_to_b") + _
                              ldrDetail(lintCnt).Item("night_int_total_to_b") >= ldrGrp(0).Item("minintto") Then
                                lblnGroup = True
                            End If
                        End If
                    Else
                        If ldrGrp(0).Item("isconsolid") Then
                            If ldrDetail(lintCnt).Item("day_nor_g_total_to") + _
                            ldrDetail(lintCnt).Item("day_int_g_total_to") + _
                             ldrDetail(lintCnt).Item("night_nor_g_total_to") + _
                            ldrDetail(lintCnt).Item("night_int_g_total_to") >= ldrGrp(0).Item("minconto") Then
                                lblnGroup = True
                            End If
                        Else
                            If ldrDetail(lintCnt).Item("day_int_total_to") + _
                              ldrDetail(lintCnt).Item("night_int_total_to") >= ldrGrp(0).Item("minintto") Then
                                lblnGroup = True
                            End If
                        End If
                    End If

                End If
                If lblnGroup Then
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "AGRP", _
                                             "INT", lblnIsConsolid, dtRate, dtPG, dtDetail, ldrGrp(0).Item("isbothfo"))
                Else
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "ACC", _
                                             "INT", lblnIsConsolid, dtRate, dtPG, dtDetail, ldrDetail(lintCnt).Item("isbothfo"))
                End If
                If Not IsNothing(ldrRate) Then
                    ldrDetail(lintCnt).Item("day_rate_int") = ldrRate("day_rate")
                    ldrDetail(lintCnt).Item("night_rate_int") = ldrRate("night_rate")
                Else
                    If ldrGlobal.Length > 0 Then
                        ldrDetail(lintCnt).Item("day_rate_int") = ldrGlobal(0).Item("commnorrate_f")
                        ldrDetail(lintCnt).Item("night_rate_int") = ldrGlobal(0).Item("commnorrate_f")
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm_int") * (1 - (ldrDetail(lintCnt).Item("day_rate_int") / 100))
                End If
                If ldrDetail(lintCnt).Item("night_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm_int") * (1 - (ldrDetail(lintCnt).Item("night_rate_int") / 100))
                End If
            End If
            If ldrDetail(lintCnt).Item("day_nor") + ldrDetail(lintCnt).Item("night_nor") > 0 Then
                Dim lblnGroup As Boolean = False
                Dim lblnIsConsolid As Boolean = ldrDetail(lintCnt).Item("isconsolid")
                If ldrGrp.Length > 0 Then
                    lblnIsConsolid = ldrGrp(0).Item("isconsolid")
                    If ldrGrp(0).Item("isbothfo") Then
                        If ldrGrp(0).Item("isconsolid") Then
                            If ldrDetail(lintCnt).Item("day_nor_g_total_to_b") + _
                            ldrDetail(lintCnt).Item("day_int_g_total_to_b") + _
                             ldrDetail(lintCnt).Item("night_nor_g_total_to_b") + _
                            ldrDetail(lintCnt).Item("night_int_g_total_to_b") >= ldrGrp(0).Item("minconto") Then
                                lblnGroup = True
                            End If
                        Else
                            If ldrDetail(lintCnt).Item("day_nor_g_total_to_b") + _
                              ldrDetail(lintCnt).Item("night_nor_g_total_to_b") >= ldrGrp(0).Item("minnorto") Then
                                lblnGroup = True
                            End If
                        End If
                    Else
                        If ldrGrp(0).Item("isconsolid") Then
                            If ldrDetail(lintCnt).Item("day_nor_g_total_to") + _
                            ldrDetail(lintCnt).Item("day_int_g_total_to") + _
                             ldrDetail(lintCnt).Item("night_nor_g_total_to") + _
                            ldrDetail(lintCnt).Item("night_int_g_total_to") >= ldrGrp(0).Item("minconto") Then
                                lblnGroup = True
                            End If
                        Else
                            If ldrDetail(lintCnt).Item("day_nor_g_total_to") + _
                              ldrDetail(lintCnt).Item("night_nor_g_total_to") >= ldrGrp(0).Item("minnorto") Then
                                lblnGroup = True
                            End If
                        End If
                    End If

                End If
                If lblnGroup Then
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "AGRP", _
                                             "NOR", lblnIsConsolid, dtRate, dtPG, dtDetail, ldrGrp(0).Item("isbothfo"))
                Else
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "ACC", _
                                             "NOR", lblnIsConsolid, dtRate, dtPG, dtDetail, ldrDetail(lintCnt).Item("isbothfo"))
                End If

                ldrDetail(lintCnt).Item("day_rate_nor") = 0
                ldrDetail(lintCnt).Item("night_rate_nor") = 0
                If Not IsNothing(ldrRate) Then
                    ldrDetail(lintCnt).Item("day_rate_nor") = ldrRate("day_rate")
                    ldrDetail(lintCnt).Item("night_rate_nor") = ldrRate("night_rate")
                Else
                    If ldrGlobal.Length > 0 Then
                        ldrDetail(lintCnt).Item("day_rate_nor") = ldrGlobal(0).Item("commnorrate_f")
                        ldrDetail(lintCnt).Item("night_rate_nor") = ldrGlobal(0).Item("commnorrate_f")
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_rate_nor") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm_nor") * (1 - (ldrDetail(lintCnt).Item("day_rate_nor") / 100))
                End If
                If ldrDetail(lintCnt).Item("night_rate_nor") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm_nor") * (1 - (ldrDetail(lintCnt).Item("night_rate_nor") / 100))
                End If
            End If
        Next

        Return True

    End Function

    Protected Friend Function lfuncUpdPGTOF(ByVal dtPG As DataTable, ByRef dtDetail As DataTable) As Decimal

        'For Each ldrDetail As DataRow In dtDetail.Rows
        '    Dim ldrPG As DataRow() = dtPG.Select(" product_CODE = '" & ldrDetail("commod") & "' ")
        '    If ldrPG.Length > 0 Then
        '        Dim lstrPG As String = ldrPG(0).Item("product_group")
        '        ldrPG = dtPG.Select(" product_group = '" & lstrPG.Trim & "' ")
        '        For lintCnt As Integer = 0 To ldrPG.Length - 1
        '            Dim ldr As DataRow()
        '            ldr = dtDetail.Select(" acc_no = '" & ldrDetail("acc_no") & _
        '                                  "' and ae_no = '" & ldrDetail("ae_no") & _
        '                                   "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
        '                                   "' and txtype = '" & ldrDetail("txtype") & "'")
        '            For lintIdx As Integer = 0 To ldr.Length - 1
        '                ldrDetail("day_nor_total_TO") += ldr(lintIdx).Item("day_nor")
        '                ldrDetail("day_int_total_TO") += ldr(lintIdx).Item("day_int")
        '                ldrDetail("night_nor_total_TO") += ldr(lintIdx).Item("night_nor")
        '                ldrDetail("night_int_total_TO") += ldr(lintIdx).Item("night_int")
        '            Next
        '            If ldrDetail("acc_group").ToString.Trim <> "" Then
        '                ldr = dtDetail.Select(" ae_no = '" & ldrDetail("ae_no") & _
        '                                     "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
        '                                     "' and txtype = '" & ldrDetail("txtype") & _
        '                                     "' and acc_group = '" & ldrDetail("acc_group").ToString.Trim & "'")
        '                For lintIdx As Integer = 0 To ldr.Length - 1
        '                    ldrDetail("day_nor_g_total_TO") += ldr(lintIdx).Item("day_nor")
        '                    ldrDetail("day_int_g_total_TO") += ldr(lintIdx).Item("day_int")
        '                    ldrDetail("night_nor_g_total_TO") += ldr(lintIdx).Item("night_nor")
        '                    ldrDetail("night_int_g_total_TO") += ldr(lintIdx).Item("night_int")
        '                Next
        '            End If
        '            ldr = dtDetail.Select(" ae_no = '" & ldrDetail("ae_no") & _
        '                                  "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
        '                                  "' and txtype = '" & ldrDetail("txtype") & "'")
        '            For lintIdx As Integer = 0 To ldr.Length - 1
        '                ldrDetail("day_nor_ae_total_TO") += ldr(lintIdx).Item("day_nor")
        '                ldrDetail("day_int_ae_total_TO") += ldr(lintIdx).Item("day_int")
        '                ldrDetail("night_nor_ae_total_TO") += ldr(lintIdx).Item("night_nor")
        '                ldrDetail("night_int_ae_total_TO") += ldr(lintIdx).Item("night_int")
        '            Next
        '        Next
        '    End If
        'Next
        For Each ldrDetail As DataRow In dtDetail.Rows
            Dim ldrPG As DataRow() = dtPG.Select(" product_CODE = '" & ldrDetail("commod") & "' ")
            If ldrPG.Length > 0 Then
                Dim lstrPG As String = ldrPG(0).Item("product_group")
                ldrPG = dtPG.Select(" product_group = '" & lstrPG.Trim & "' ")
                For lintCnt As Integer = 0 To ldrPG.Length - 1
                    Dim ldr As DataRow()
                    ldr = dtDetail.Select(" acc_no = '" & ldrDetail("acc_no") & _
                                          "' and ae_no = '" & ldrDetail("ae_no") & _
                                           "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
                                          "'")
                    For lintIdx As Integer = 0 To ldr.Length - 1
                        If ldrDetail("txtype") = ldr(lintIdx).Item("txtype") Then
                            ldrDetail("day_nor_total_TO") += ldr(lintIdx).Item("day_nor")
                            ldrDetail("day_int_total_TO") += ldr(lintIdx).Item("day_int")
                            ldrDetail("night_nor_total_TO") += ldr(lintIdx).Item("night_nor")
                            ldrDetail("night_int_total_TO") += ldr(lintIdx).Item("night_int")
                        End If
                        ldrDetail("day_nor_total_TO_B") += ldr(lintIdx).Item("day_nor")
                        ldrDetail("day_int_total_TO_b") += ldr(lintIdx).Item("day_int")
                        ldrDetail("night_nor_total_TO_b") += ldr(lintIdx).Item("night_nor")
                        ldrDetail("night_int_total_TO_B") += ldr(lintIdx).Item("night_int")
                    Next
                    If ldrDetail("acc_group").ToString.Trim <> "" Then
                        ldr = dtDetail.Select(" ae_no = '" & ldrDetail("ae_no") & _
                                             "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
                                             "' and acc_group = '" & ldrDetail("acc_group").ToString.Trim & "'")
                        For lintIdx As Integer = 0 To ldr.Length - 1
                            If ldrDetail("txtype") = ldr(lintIdx).Item("txtype") Then
                                ldrDetail("day_nor_g_total_TO") += ldr(lintIdx).Item("day_nor")
                                ldrDetail("day_int_g_total_TO") += ldr(lintIdx).Item("day_int")
                                ldrDetail("night_nor_g_total_TO") += ldr(lintIdx).Item("night_nor")
                                ldrDetail("night_int_g_total_TO") += ldr(lintIdx).Item("night_int")
                            End If
                            ldrDetail("day_nor_g_total_TO_b") += ldr(lintIdx).Item("day_nor")
                            ldrDetail("day_int_g_total_TO_b") += ldr(lintIdx).Item("day_int")
                            ldrDetail("night_nor_g_total_TO_b") += ldr(lintIdx).Item("night_nor")
                            ldrDetail("night_int_g_total_TO_B") += ldr(lintIdx).Item("night_int")
                        Next
                    End If
                    ldr = dtDetail.Select(" ae_no = '" & ldrDetail("ae_no") & _
                                          "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
                                          "'")
                    For lintIdx As Integer = 0 To ldr.Length - 1
                        If ldrDetail("txtype") = ldr(lintIdx).Item("txtype") Then
                            ldrDetail("day_nor_ae_total_TO") += ldr(lintIdx).Item("day_nor")
                            ldrDetail("day_int_ae_total_TO") += ldr(lintIdx).Item("day_int")
                            ldrDetail("night_nor_ae_total_TO") += ldr(lintIdx).Item("night_nor")
                            ldrDetail("night_int_ae_total_TO") += ldr(lintIdx).Item("night_int")
                        End If
                        ldrDetail("day_nor_ae_total_TO_b") += ldr(lintIdx).Item("day_nor")
                        ldrDetail("day_int_ae_total_TO_B") += ldr(lintIdx).Item("day_int")
                        ldrDetail("night_nor_ae_total_TO_b") += ldr(lintIdx).Item("night_nor")
                        ldrDetail("night_int_ae_total_TO_b") += ldr(lintIdx).Item("night_int")
                    Next
                Next
            End If
        Next
    End Function

    Protected Friend Function lfuncCalCommRateF(ByVal drDetail As DataRow, ByVal strCommType As String, _
    ByVal strRateType As String, ByVal blnIsConsolid As Boolean, ByVal dtRate As DataTable, _
    ByVal dtpg As DataTable, ByVal dtDetail As DataTable, ByVal blnIsFO As Boolean) As DataRow


        Dim ldecTO As Decimal = 0

        Dim lstrPG As String = ""
        Dim ldrPG As DataRow() = dtpg.Select(" product_code = '" & drDetail("commod") & "' ")
        If ldrPG.Length <= 0 Then
            Return Nothing
        End If

        If blnIsConsolid Then
            strRateType = "CON"
        End If
        Dim lstrTxType As String = drDetail("txtype")
        If blnIsFO Then
            lstrTxType = "B"
        End If
        Dim ldrRate As DataRow()

        If strCommType = "ACC" Then
            ldrRate = dtRate.Select(" comm_type = '" & strCommType & _
                         "' and rate_type = '" & strRateType & lstrTxType & _
                         "' and acc_no = '" & drDetail("acc_no") & _
                         "' and ae_no = '" & drDetail("ae_no") & _
                         "' and product_group = '" & ldrPG(0).Item("product_group") & "' ", " turnover_from desc ")
            If blnIsFO Then
                If blnIsConsolid Then
                    ldecTO = drDetail("day_nor_total_to_b") + drDetail("night_nor_total_to_b") + _
                             drDetail("day_int_total_to_b") + drDetail("night_int_total_to_b")
                Else
                    If strRateType = "NOR" Then
                        ldecTO = drDetail("day_nor_total_to_b") + drDetail("night_nor_total_to_b")
                    Else
                        ldecTO = drDetail("day_int_total_to_b") + drDetail("night_int_total_to_b")
                    End If
                End If
            Else
                If blnIsConsolid Then
                    ldecTO = drDetail("day_nor_total_to") + drDetail("night_nor_total_to") + _
                             drDetail("day_int_total_to") + drDetail("night_int_total_to")
                Else
                    If strRateType = "NOR" Then
                        ldecTO = drDetail("day_nor_total_to") + drDetail("night_nor_total_to")
                    Else
                        ldecTO = drDetail("day_int_total_to") + drDetail("night_int_total_to")
                    End If
                End If
            End If

        ElseIf strCommType = "AE" Then
            ldrRate = dtRate.Select(" comm_type = '" & strCommType & _
                         "' and rate_type = '" & strRateType & lstrTxType & _
                         "' and ae_no = '" & drDetail("ae_no") & _
                         "' and product_group = '" & ldrPG(0).Item("product_group") & "' ", " turnover_from desc ")
            If blnIsFO Then
                If blnIsConsolid Then
                    ldecTO = drDetail("day_nor_ae_total_to_b") + drDetail("night_nor_ae_total_to_b") + _
                             drDetail("day_int_ae_total_to_b") + drDetail("night_int_ae_total_to_b")
                Else
                    If strRateType = "NOR" Then
                        ldecTO = drDetail("day_nor_ae_total_to_b") + drDetail("night_nor_ae_total_to_b")
                    Else
                        ldecTO = drDetail("day_int_ae_total_to_b") + drDetail("night_int_ae_total_to_b")
                    End If
                End If
            Else
                If blnIsConsolid Then
                    ldecTO = drDetail("day_nor_ae_total_to") + drDetail("night_nor_ae_total_to") + _
                             drDetail("day_int_ae_total_to") + drDetail("night_int_ae_total_to")
                Else
                    If strRateType = "NOR" Then
                        ldecTO = drDetail("day_nor_ae_total_to") + drDetail("night_nor_ae_total_to")
                    Else
                        ldecTO = drDetail("day_int_ae_total_to") + drDetail("night_int_ae_total_to")
                    End If
                End If
            End If

        Else
            ldrRate = dtRate.Select(" comm_type = '" & strCommType & _
                        "' and rate_type = '" & strRateType & lstrTxType & _
                        "' and acc_group = '" & drDetail("acc_group") & _
                        "' and ae_no = '" & drDetail("ae_no") & _
                        "' and product_group = '" & ldrPG(0).Item("product_group") & "' ", " turnover_from desc ")
            If blnIsFO Then
                If blnIsConsolid Then
                    ldecTO = drDetail("day_nor_g_total_to_b") + drDetail("night_nor_g_total_to_b") + _
                             drDetail("day_int_g_total_to_b") + drDetail("night_int_g_total_to_b")
                Else
                    If strRateType = "NOR" Then
                        ldecTO = drDetail("day_nor_g_total_to_b") + drDetail("night_nor_g_total_to_b")
                    Else
                        ldecTO = drDetail("day_int_g_total_to_b") + drDetail("night_int_g_total_to_b")
                    End If
                End If
            Else
                If blnIsConsolid Then
                    ldecTO = drDetail("day_nor_g_total_to") + drDetail("night_nor_g_total_to") + _
                             drDetail("day_int_g_total_to") + drDetail("night_int_g_total_to")
                Else
                    If strRateType = "NOR" Then
                        ldecTO = drDetail("day_nor_g_total_to") + drDetail("night_nor_g_total_to")
                    Else
                        ldecTO = drDetail("day_int_g_total_to") + drDetail("night_int_g_total_to")
                    End If
                End If
            End If

        End If

        If ldrRate.Length > 0 Then
            For lintCnt As Integer = 0 To ldrRate.Length - 1
                If ldecTO >= ldrRate(lintCnt).Item("turnover_from") Then
                    Return ldrRate(lintCnt)
                End If
            Next
        End If

        Return Nothing

    End Function

    Private Sub InitCommDTF(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ae_no"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "man_no_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "man_no_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_Brok_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_Brok_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_Brok_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_m"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_i"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_b"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_a_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_comm_a_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate_inc"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate_bon"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_TO_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_TO_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Total_TO_s"
        DT.Columns.Add(Column)
    End Sub

    Private Sub InitDetailDTF(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "acc_no"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ae_no"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "acc_group"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "commod"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Boolean")
        Column.ColumnName = "isbothfo"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txtype"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Int16")
        Column.ColumnName = "isconsolid"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_comm_nor"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_comm_nor"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_comm_int"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_comm_int"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_rate_nor"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_rate_nor"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_rate_int"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_rate_int"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "ae_comm"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor_G_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor_G_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int_G_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int_G_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor_ae_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor_ae_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int_ae_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int_ae_total_TO"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor_ae_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor_ae_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int_ae_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int_ae_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_nor_G_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_nor_G_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_int_G_total_TO_B"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_int_G_total_TO_B"
        DT.Columns.Add(Column)

    End Sub




















































































    '====Securities Commission Calulation======================================================================================

    Protected Friend Function lFncCalTotalComm(ByVal txmonth As String) As DataSet

        ldsDefault = lFncLoadDefaultCfg(txmonth)
        ldsGrpList = lFncLoadGroupCfgList(txmonth)
        ldsAccList = lFncLoadAccCfgList(txmonth)
        ldsAEList = lFncLoadAECfgList(txmonth)
        ldsTrade = lFncLoadTrade(txmonth)
        ldsRate = lFncLoadRate(txmonth)
        ldsAETotal = lFncLoadAEList(txmonth)
        ldsGroupAEList = lFncLoadGroupAEList(txmonth)
        ldsGroupAETotal = lFncLoadGroupAETotal(txmonth)

        For i As Integer = 0 To ldsTrade.Tables(0).Rows.Count - 1
            Dim ae_no As String = ldsTrade.Tables(0).Rows(i).Item("ae_no")
            Dim acc_group As String = GFncNoNullString(ldsTrade.Tables(0).Rows(i).Item("acc_group"))
            Dim acc_no As String = ldsTrade.Tables(0).Rows(i).Item("acc_no")
            Dim tradetype As Integer = ldsTrade.Tables(0).Rows(i).Item("tradetype")
            Dim grossamt As Decimal = ldsTrade.Tables(0).Rows(i).Item("grossamt")
            Dim commission As Decimal = ldsTrade.Tables(0).Rows(i).Item("commission")
            Dim comm_rate As Decimal = ldsTrade.Tables(0).Rows(i).Item("comm_rate")
            Dim co_comm As Decimal = 0
            Dim ae_comm As Decimal = 0


            If (acc_group.Trim = "") Then
                co_comm = lFncCalIndvComm(ae_no, acc_no, tradetype, grossamt, commission, comm_rate, i)
            Else
                co_comm = lFncCalGroupComm(ae_no, acc_group, acc_no, tradetype, grossamt, commission, comm_rate, i)
            End If
            ldsTrade.Tables(0).Rows(i).Item("co_comm") = co_comm
            ldsTrade.Tables(0).Rows(i).Item("ae_comm") = commission - co_comm
        Next

        Return ldsTrade

    End Function

    Protected Friend Function lFncCalGroupComm(ByVal ae_no As String, ByVal acc_group As String, ByVal acc_no As String, _
                                            ByVal tradetype As Integer, ByVal grossamt As Decimal, ByVal commission As Decimal, _
                                             ByVal comm_rate As Decimal, Optional ByVal row As Integer = -1) As Decimal

        Dim coRateComm As Decimal = 0
        Dim rate_type As String = ""
        Dim grpTO As Decimal = 0
        Dim minTO As Decimal = 0

        Dim ldrGrpList As DataRow() = ldsGrpList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_group = '" & acc_group & "' ")
        If (ldrGrpList.Length > 0) Then
            If (lFncGetGrpConsolidStatus(ae_no, acc_group)) Then
                rate_type = "CON"
                grpTO = ldrGrpList(0).Item("norTO") + ldrGrpList(0).Item("intTO")
                minTO = ldrGrpList(0).Item("minConTO")
            Else
                If (tradetype = 0) Then
                    rate_type = "NOR"
                    grpTO = ldrGrpList(0).Item("norTO")
                    minTO = ldrGrpList(0).Item("minNorTO")
                ElseIf (tradetype = 4) Then
                    rate_type = "INT"
                    grpTO = ldrGrpList(0).Item("intTO")
                    minTO = ldrGrpList(0).Item("minIntTO")
                End If
            End If
            If (grpTO >= minTO) Then
                Dim coRate As Decimal = 0

                coRate = lFncGetGroupRate(ae_no, acc_group, rate_type, grpTO)
                coRateComm = grpTO * coRate / 100
                If (coRateComm >= commission) Then
                    coRateComm = commission
                End If

                If (row >= 0) Then
                    ldsTrade.Tables(0).Rows(row).Item("CoRate") = coRate
                    ldsTrade.Tables(0).Rows(row).Item("MinTO") = minTO
                    ldsTrade.Tables(0).Rows(row).Item("CoRateComm") = coRateComm
                    ldsTrade.Tables(0).Rows(row).Item("GrpTO") = grpTO
                End If
            Else
                coRateComm = lFncCalIndvComm(ae_no, acc_no, tradetype, grossamt, commission, comm_rate, row)
            End If
        End If

        Return coRateComm

    End Function

    Protected Friend Function lFncGetGrpConsolidStatus(ByVal ae_no As String, ByVal acc_group As String) As Boolean

        Dim ldrGrpList As DataRow() = ldsGrpList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_group = '" & acc_group & "' ")

        If (ldrGrpList.Length > 0) Then
            Return ldrGrpList(0).Item("isConsolid")
        End If
        Return False

    End Function

    Protected Friend Function lFncGetGroupRate(ByVal ae_no As String, ByVal acc_group As String, ByVal rate_type As String, _
                                                ByVal turnover As Decimal) As Decimal

        Dim ldrRate As DataRow() = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_group = '" & acc_group & _
                                                                    "' and rate_type = '" & rate_type & _
                                                                    "' and turnover_from <= " & turnover & _
                                                                    " and comm_rate > 0 ", " turnover_from desc")

        Dim rate As Decimal

        If (ldrRate.Length > 0) Then
            rate = ldrRate(0).Item("comm_rate")
        Else
            rate = lFncGetDefaultComm(rate_type, "AGRP", "C")
        End If

        Return rate

    End Function

    Protected Friend Function lFncGetDefaultComm(ByVal rate_type As String, ByVal comm_type As String, _
    ByVal rate_flag As String) As Decimal

        Dim ldrDefault As DataRow() = ldsDefault.Tables(0).Select(" comm_type = '" & comm_type & "' ")

        If (ldrDefault.Length > 0) Then
            If (rate_type = "NOR") Then
                If rate_flag = "C" Then
                    Return ldrDefault(0).Item("commNorRate")
                Else
                    Return ldrDefault(0).Item("minNorRate")
                End If
            Else
                If rate_flag = "C" Then
                    Return ldrDefault(0).Item("commIntRate")
                Else
                    Return ldrDefault(0).Item("minIntRate")
                End If
            End If
        End If

        Return 0

    End Function

    Protected Friend Function lFncCalIndvComm(ByVal ae_no As String, ByVal acc_no As String, ByVal tradetype As Integer, _
                                            ByVal grossamt As Decimal, ByVal commission As Decimal, ByVal comm_rate As Decimal, _
                                            Optional ByVal row As Integer = -1) As Decimal

        Dim minRate As Decimal = 0
        Dim minAmt As Decimal = 0
        Dim coRate As Decimal = 0
        Dim brokRate As Decimal = 0
        Dim minRateComm As Decimal = 0
        Dim coRateComm As Decimal = 0
        Dim minTOComm As Decimal = 0
        Dim co_comm As Decimal = 0
        Dim total_TO As Decimal = 0
        Dim total_comm_recd As Decimal = 0
        Dim lblnIsConsolid As Boolean = False
        Dim comm_type As String = ""
        Dim rate_type As String = ""

        If ae_no = "0479" Then
            Application.DoEvents()
        End If
        Dim ldrAccList As DataRow() = ldsAccList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_no & "' ")
        Dim ldrAEList As DataRow() = ldsAEList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_no & "' ")
        Dim ldrAETotal As DataRow() = ldsAETotal.Tables(0).Select(" ae_no = '" & ae_no & "' ")
        'get min rate and amount from table
        If ldrAccList.Length > 0 Then
            comm_type = "ACC"
            lFncGetIndvMinVal(ae_no, acc_no, tradetype, minAmt, minRate, ldrAccList(0), comm_type)
            lblnIsConsolid = ldrAccList(0).Item("isConsolid")
            If lblnIsConsolid Then
                total_TO = ldrAccList(0).Item("norto") + ldrAccList(0).Item("intto")
                total_comm_recd = ldrAccList(0).Item("NorComm") + ldrAccList(0).Item("IntComm")
                rate_type = "CON"
            Else
                If tradetype = 0 Then
                    total_TO = ldrAccList(0).Item("norto")
                    total_comm_recd = ldrAccList(0).Item("NorComm")
                    rate_type = "NOR"
                Else
                    total_TO = ldrAccList(0).Item("intto")
                    total_comm_recd = ldrAccList(0).Item("IntComm")
                    rate_type = "INT"
                End If
            End If

        ElseIf ldrAEList.Length > 0 Then
            comm_type = "AE"
            lFncGetIndvMinVal(ae_no, acc_no, tradetype, minAmt, minRate, ldrAEList(0), comm_type)
            lblnIsConsolid = ldrAEList(0).Item("isConsolid")

            'special case, use group turnover to replace ae turnover
            Dim ldrGroupAEList As DataRow() = ldsGroupAEList.Tables(0).Select(" ae_no = '" & ae_no & "' ")
            If (ldrGroupAEList.Length > 0) Then
                Dim group_ae As String = ldrGroupAEList(0).Item("group_ae")
                lblnIsConsolid = ldrGroupAEList(0).Item("isConsolid")
                ldrAETotal = ldsGroupAETotal.Tables(0).Select(" group_ae ='" & group_ae & "' ")
            End If

            If lblnIsConsolid Then
                total_TO = ldrAETotal(0).Item("norto") + ldrAETotal(0).Item("intto")
                total_comm_recd = ldrAETotal(0).Item("NorComm") + ldrAETotal(0).Item("IntComm")
                rate_type = "CON"
            Else
                If tradetype = 0 Then
                    total_TO = ldrAETotal(0).Item("norto")
                    total_comm_recd = ldrAETotal(0).Item("NorComm")
                    rate_type = "NOR"
                Else
                    total_TO = ldrAETotal(0).Item("intto")
                    total_comm_recd = ldrAETotal(0).Item("IntComm")
                    rate_type = "INT"
                End If
            End If
        Else
            Return commission
        End If


        'get company commission rate from table
        'If lblnIsConsolid Then
        coRate = lFncGetAccCommRate(ae_no, acc_no, rate_type, total_TO, total_comm_recd, comm_type)
        brokRate = lFncGetAccBrokRate(ae_no, acc_no, rate_type, total_TO, total_comm_recd, comm_type)
        If brokRate > 0 Then
            minRate = brokRate
        End If
        'Else
        'If (tradetype = 0) Then
        '    coRate = lFncGetAccCommRate(ae_no, acc_no, "NOR", total_TO, comm_type)
        'Else
        '    coRate = lFncGetAccCommRate(ae_no, acc_no, "INT", total_TO, comm_type)
        'End If
        'End If

        If coRate >= comm_rate Then
            Return commission
        End If

        'calculate commission
        minRateComm = commission * minRate / 100
        If Math.Abs(commission - (comm_rate * grossamt / 100)) > 1 And coRate > 0 Then
            coRateComm = (coRate * commission / comm_rate)
        Else
            coRateComm = coRate * grossamt / 100
        End If
        minTOComm = minAmt

        If (minRateComm > coRateComm) Then
            If (minRateComm > minTOComm) Then
                co_comm = minRateComm
            Else
                co_comm = minTOComm
            End If
        Else
            If (coRateComm > minTOComm) Then
                co_comm = coRateComm
            Else
                co_comm = minTOComm
            End If
        End If

        If (co_comm >= commission) Then
            co_comm = commission
        End If

        If (row >= 0) Then
            ldsTrade.Tables(0).Rows(row).Item("CoRate") = coRate
            ldsTrade.Tables(0).Rows(row).Item("MinTO") = minAmt
            ldsTrade.Tables(0).Rows(row).Item("MinRate") = minRate
            ldsTrade.Tables(0).Rows(row).Item("MinRateComm") = minRateComm
            ldsTrade.Tables(0).Rows(row).Item("CoRateComm") = coRateComm
            ldsTrade.Tables(0).Rows(row).Item("MinTOComm") = minTOComm
        End If

        Return co_comm

    End Function

    Protected Friend Sub lFncGetIndvMinVal(ByVal ae_no As String, ByVal acc_no As String, ByVal tradetype As Integer, _
                    ByRef minAmt As Decimal, ByRef minRate As Decimal, ByVal dr As DataRow, ByVal comm_type As String)

        If Not IsNothing(dr) Then
            If (dr.Item("isDefault_s")) Then
                lFncGetDefaultIndvMin(tradetype, minAmt, minRate, comm_type)
            Else
                If (tradetype = 0) Then
                    minAmt = dr.Item("minNorAmt")
                    minRate = dr.Item("minNorRate")
                Else
                    minAmt = dr.Item("minIntAmt")
                    minRate = dr.Item("minIntRate")
                End If
            End If
        End If

    End Sub
    Protected Friend Function lFncGetAccBrokRate(ByVal ae_no As String, ByVal acc_group As String, ByVal rate_type As String, _
                                                 ByVal turnover As Decimal, ByVal comm_recd As Decimal, ByVal comm_type As String) As Decimal

        'Dim ldrRate As DataRow()
        'If comm_type = "ACC" Then
        '    ldrRate = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_group & _
        '                                                                       "' and rate_type = '" & rate_type & _
        '                                                                        "' and comm_type = '" & comm_type & _
        '                                                                        "' and turnover_from <= " & turnover & _
        '                                                                       " and brokerage_rate > 0 ", " turnover_from desc")

        'ElseIf comm_type = "AE" Then
        '    ldrRate = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & _
        '                                        "' and rate_type = '" & rate_type & _
        '                                        "' and comm_type = '" & comm_type & _
        '                                        "' and turnover_from <= " & turnover & _
        '                                        " and brokerage_rate > 0 ", " turnover_from desc")
        'Else
        '    Return 0
        'End If

        'Dim rate As Decimal

        'If (ldrRate.Length > 0) Then
        '    rate = ldrRate(0).Item("Brokerage_rate")
        'Else
        '    Return 0
        'End If

        'Return rate


        Dim rate As Decimal = 0
        If comm_type = "ACC" Then
            Dim ldrRate As DataRow()
            ldrRate = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_group & _
                                                                               "' and rate_type = '" & rate_type & _
                                                                                "' and comm_type = '" & comm_type & _
                                                                                "' and turnover_from <= " & turnover & _
                                                                               " and brokerage_rate > 0 ", " turnover_from desc")
            If (ldrRate.Length > 0) Then
                rate = ldrRate(0).Item("Brokerage_rate")
            Else
                Return 0
            End If
        ElseIf comm_type = "AE" Then
            Dim ldrRateTurnover As DataRow()
            Dim ldrRateCommRecd As DataRow()
            Dim rateTurnover As Decimal = 0
            Dim rateCommRecd As Decimal = 0

            ldrRateTurnover = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & _
                                                "' and rate_type = '" & rate_type & _
                                                "' and comm_type = '" & comm_type & _
                                                "' and turnover_from <= " & turnover & _
                                                " and brokerage_rate > 0 and turnover_type = 'Turnover'", " turnover_from asc")
            If (ldrRateTurnover.Length > 0) Then
                For lintCnt As Integer = 0 To ldrRateTurnover.Length - 1
                    If ldrRateTurnover(lintCnt).Item("Brokerage_rate") > 0 Then
                        If ldrRateTurnover(lintCnt).Item("turnover_from") <= turnover Then
                            rateTurnover = ldrRateTurnover(lintCnt).Item("Brokerage_rate")
                        Else
                            Exit For
                        End If
                    End If
                Next
            End If

            ldrRateCommRecd = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & _
                                                "' and rate_type = '" & rate_type & _
                                                "' and comm_type = '" & comm_type & _
                                                "' and turnover_from <= " & turnover & _
                                                " and brokerage_rate > 0 and turnover_type = 'Comm. Recd'", " turnover_from asc")
            If (ldrRateCommRecd.Length > 0) Then
                For lintCnt As Integer = 0 To ldrRateCommRecd.Length - 1
                    If ldrRateCommRecd(lintCnt).Item("Brokerage_rate") > 0 Then
                        If ldrRateCommRecd(lintCnt).Item("turnover_from") <= comm_recd Then
                            rateCommRecd = ldrRateCommRecd(lintCnt).Item("Brokerage_rate")
                        Else
                            Exit For
                        End If
                    End If
                Next
            End If

            If (ldrRateTurnover.Length <= 0 And ldrRateCommRecd.Length <= 0) Then
                rate = 0
            Else
                If (rateTurnover > rateCommRecd) Then
                    rate = rateTurnover
                Else
                    rate = rateCommRecd
                End If
            End If
        Else
            Return 0
        End If

        Return rate
    End Function
    Protected Friend Function lFncGetAccCommRate(ByVal ae_no As String, ByVal acc_group As String, ByVal rate_type As String, _
                                                 ByVal turnover As Decimal, ByVal comm_recd As Decimal, ByVal comm_type As String) As Decimal
        'Dim ldrRate As DataRow()
        ''Dim ldrRate As DataRow() = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_group & _
        ''                                                            "' and rate_type = '" & rate_type & _
        ''                                                             "' and comm_type = '" & comm_type & _
        ''                                       "' and turnover_from <= " & turnover & _
        ''            " and (comm_rate > 0 or (brokerage_rate = 0 and comm_rate = 0))   ", " turnover_from desc")
        'If comm_type = "ACC" Then
        '    ldrRate = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_group & _
        '                                         "' and rate_type = '" & rate_type & _
        '                                            "' and comm_type = '" & comm_type & "' ", " turnover_from asc")
        'ElseIf comm_type = "AE" Then
        '    ldrRate = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & _
        '                                         "' and rate_type = '" & rate_type & _
        '                                        "' and comm_type = '" & comm_type & _
        '                                        "' and turnover_type = '" & range_type & "'", " turnover_from asc")
        'Else
        '    Return 0
        'End If

        'Dim rate As Decimal = 0

        'If (ldrRate.Length > 0) Then
        '    For lintCnt As Integer = 0 To ldrRate.Length - 1
        '        If ldrRate(lintCnt).Item("comm_rate") > 0 Then
        '            If ldrRate(lintCnt).Item("turnover_from") <= turnover Then
        '                rate = ldrRate(lintCnt).Item("comm_rate")
        '            Else
        '                Exit For
        '            End If
        '        End If
        '    Next
        'Else
        '    rate = lFncGetDefaultComm(rate_type, comm_type, "C")
        'End If

        'Return rate

        Dim rate As Decimal = 0
        If comm_type = "ACC" Then
            Dim ldrRate As DataRow()
            ldrRate = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_group & _
                                                 "' and rate_type = '" & rate_type & _
                                                    "' and comm_type = '" & comm_type & "' ", " turnover_from asc")

            If (ldrRate.Length > 0) Then
                For lintCnt As Integer = 0 To ldrRate.Length - 1
                    If ldrRate(lintCnt).Item("comm_rate") > 0 Then
                        If ldrRate(lintCnt).Item("turnover_from") <= turnover Then
                            rate = ldrRate(lintCnt).Item("comm_rate")
                        Else
                            Exit For
                        End If
                    End If
                Next
            Else
                rate = lFncGetDefaultComm(rate_type, comm_type, "C")
            End If
        ElseIf comm_type = "AE" Then
            Dim ldrRateTurnover As DataRow()
            Dim ldrRateCommRecd As DataRow()
            Dim rateTurnover As Decimal = 0
            Dim rateCommRecd As Decimal = 0

            ldrRateTurnover = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & _
                                                       "' and rate_type = '" & rate_type & _
                                                       "' and comm_type = '" & comm_type & _
                                                       "' and turnover_type = 'Turnover'", " turnover_from asc")
            If (ldrRateTurnover.Length > 0) Then
                For lintCnt As Integer = 0 To ldrRateTurnover.Length - 1
                    If ldrRateTurnover(lintCnt).Item("comm_rate") > 0 Then
                        If ldrRateTurnover(lintCnt).Item("turnover_from") <= turnover Then
                            rateTurnover = ldrRateTurnover(lintCnt).Item("comm_rate")
                        Else
                            Exit For
                        End If
                    End If
                Next
            End If

            ldrRateCommRecd = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & _
                                                 "' and rate_type = '" & rate_type & _
                                                "' and comm_type = '" & comm_type & _
                                                "' and turnover_type = 'Comm. Recd'", " turnover_from asc")
            If (ldrRateCommRecd.Length > 0) Then
                For lintCnt As Integer = 0 To ldrRateCommRecd.Length - 1
                    If ldrRateCommRecd(lintCnt).Item("comm_rate") > 0 Then
                        If ldrRateCommRecd(lintCnt).Item("turnover_from") <= comm_recd Then
                            rateCommRecd = ldrRateCommRecd(lintCnt).Item("comm_rate")
                        Else
                            Exit For
                        End If
                    End If
                Next
            End If

            If (ldrRateTurnover.Length <= 0 And ldrRateCommRecd.Length <= 0) Then
                rate = lFncGetDefaultComm(rate_type, comm_type, "C")
            Else
                If (rateTurnover > rateCommRecd) Then
                    rate = rateTurnover
                Else
                    rate = rateCommRecd
                End If
            End If
        Else
            Return 0
        End If

        Return rate
    End Function

    Protected Friend Sub lFncGetDefaultIndvMin(ByVal tradetype As Integer, _
    ByRef minAmt As Decimal, ByRef minRate As Decimal, ByVal comm_type As String)

        Dim ldrDefault As DataRow() = ldsDefault.Tables(0).Select(" comm_type = '" & comm_type & "' ")

        If (ldrDefault.Length > 0) Then
            If (tradetype = 0) Then
                minAmt = ldrDefault(0).Item("minNorAmt")
                minRate = ldrDefault(0).Item("minNorRate")
            Else
                minAmt = ldrDefault(0).Item("minIntAmt")
                minRate = ldrDefault(0).Item("minIntRate")
            End If
        Else
            minAmt = 0
            minRate = 0
        End If


    End Sub

    Protected Friend Function lFncLoadDefaultCfg(ByVal txMonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select comm_type, minNorAmt, minIntAmt, minNorRate_s as minNorRate, minIntRate_s as minIntRate, commNorRate, " & _
                    "commIntRate from comm_global where txmonth = '" & txMonth & "' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "tradelist")
        Return lds

    End Function

    Protected Friend Function lFncLoadGroupCfgList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.ae_no, b.acc_group_s as acc_group, c.isConsolid, c.minConTO, c.minNorTO, c.minIntTO, " & _
                    "sum(case when tradetype = 0 then grossamt else 0 end) as norTO, " & _
                    "sum(case when tradetype = 4 then grossamt else 0 end) as intTO, " & _
                    "sum(case when tradetype = 0 then commission else 0 end) as NorComm, " & _
                    "sum(case when tradetype = 4 then commission  else 0 end) as IntComm " & _
                    "from view_comm_adjusted_s a " & _
                    "inner join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "inner join comm_group_s c on b.txmonth = c.txmonth and b.ae_no_s = c.ae_no and b. acc_group_s = c.ae_group_s " & _
                    "where a.txmonth = '" & txmonth & "' " & _
                    "group by a.ae_no, b.acc_group_s, c.isConsolid, c.minConTO, c.minNorTO, c.minIntTO "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "grplist")
        Return lds

    End Function

    Protected Friend Function lFncLoadAccCfgList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.ae_no, b.acc_group_s as acc_group, a.acc_no, b.minNorAmt, b.minIntAmt, b.minNorRate, " & _
                    "b.minIntRate, b.isConsolid, isDefault_s, " & _
                    "sum(case when a.tradetype = 0 then a.grossamt else 0 end) as norTO, " & _
                    "sum(case when a.tradetype = 4 then a.grossamt else 0 end) as intTO, " & _
                     "sum(case when tradetype = 0 then commission else 0 end) as NorComm, " & _
                    "sum(case when tradetype = 4 then commission  else 0 end) as IntComm " & _
                    "from view_comm_adjusted_s a " & _
                    "inner join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "where a.txmonth = '" & txmonth & "' group by  a.ae_no, b.acc_group_s, a.acc_no, b.minNorAmt, b.minIntAmt, " & _
                    "b.minNorRate, b.minIntRate, b.isConsolid, a.comm_rate, isDefault_s " & _
                    "order by a.ae_no, acc_group_s, a.acc_no "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "acclist")
        Return lds

    End Function
    Protected Friend Function lFncLoadAECfgList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.ae_no, a.acc_no, b.minNorAmt, b.minIntAmt, b.minNorRate, " & _
                     "b.minIntRate, b.isConsolid, isDefault_s, " & _
                     "sum(case when a.tradetype = 0 then a.grossamt else 0 end) as norTO, " & _
                     "sum(case when a.tradetype = 4 then a.grossamt else 0 end) as intTO, " & _
                      "sum(case when tradetype = 0 then commission else 0 end) as NorComm, " & _
                    "sum(case when tradetype = 4 then commission  else 0 end) as IntComm " & _
                     "from view_comm_adjusted_s a " & _
                     "inner join comm_ae_master_d b on a.txmonth = b.txmonth and a.ae_no = b.ae_no and iscommission_s = 1 " & _
                     "where a.txmonth = '" & txmonth & "' " & _
                     " and not exists ( select * from comm_acc_master_d c " & _
                     " where a.txmonth = c.txmonth and a.acc_no = c.acc_no and a.ae_no = c.ae_no_s )  " & _
                     " group by  a.ae_no, a.acc_no, b.minNorAmt, b.minIntAmt, " & _
                     "b.minNorRate, b.minIntRate, b.isConsolid, a.comm_rate, isDefault_s " & _
                     "order by a.ae_no, a.acc_no "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "acclist")
        Return lds

    End Function
    Protected Friend Function lFncLoadAEList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.ae_no, " & _
                     "sum(case when a.tradetype = 0 then a.grossamt else 0 end) as norTO, " & _
                     "sum(case when a.tradetype = 4 then a.grossamt else 0 end) as intTO, " & _
                      " sum(case when tradetype = 0 then commission else 0 end) as NorComm, " & _
                    "sum(case when tradetype = 4 then commission  else 0 end) as IntComm " & _
                     "from view_comm_adjusted_s a " & _
                     "where a.txmonth = '" & txmonth & "' " & _
                     " and a.acc_no not in ( select acc_no from comm_acc_master_d b " & _
                     " where a.ae_no = b.ae_no_s and b.txmonth = '" & txmonth & "' ) " & _
                    " group by  a.ae_no order by a.ae_no "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "acclist")
        Return lds

    End Function

    Protected Friend Function lFncLoadGroupAEList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select group_ae, ae_no, isConsolid from comm_group_ae_s where txmonth = '" & txmonth & "' and calSpecial=1 "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "groupaelist")
        Return lds

    End Function

    Protected Friend Function lFncLoadGroupAETotal(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select group_ae, sum(case when tradetype = 0 then a.grossamt else 0 end) as norTO, " & _
                    "sum(case when a.tradetype = 4 then a.grossamt else 0 end) as intTO, " & _
                    "sum(case when tradetype = 0 then commission else 0 end) as NorComm, " & _
                    "sum(case when tradetype = 4 then commission  else 0 end) as IntComm " & _
                    "from view_comm_adjusted_s a " & _
                    "inner join comm_group_ae_s b on a.txmonth = b.txmonth collate database_default " & _
                    "and a.ae_no = b.ae_no collate database_default " & _
                    "where a.txmonth = '" & txmonth & "' group by group_ae "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "groupaetotal")
        Return lds

    End Function

    Protected Friend Function lFncLoadTrade(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet        

        lstrSQL = "select a.ae_no, a.aename, isnull(b.acc_group_s, '') as acc_group, a.acc_no, a.tradetype, a.grossamt, a.commission, a.comm_rate, " & _
                    " a.tdate, a.oid, " & _
                    "cast(0 as numeric(18,4)) as co_comm, cast(0 as numeric(18,4)) as ae_comm, cast(0 as decimal(18,4)) as CoRate, " & _
                    "cast(0 as decimal(18,4)) as MinTO, cast(NULL as decimal(18,4)) as MinRate, cast(NULL as decimal(18,4)) as CoRateComm, " & _
                    "cast(NULL as decimal(18,4)) as MinRateComm, cast(NULL as decimal(18,4)) as MinTOComm, cast(NULL as decimal(18,4)) as GrpTO, " & _
                    "vitd.currency_code_set " & _
                    "from view_comm_adjusted_s a " & _
                    "left outer join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "left outer join " & GStrG2BSDB & ".dbo.View_IT_trade_detail vitd on vitd.aeno COLLATE DATABASE_DEFAULT = a.ae_no COLLATE DATABASE_DEFAULT and vitd.accno COLLATE DATABASE_DEFAULT = a.acc_no COLLATE DATABASE_DEFAULT and vitd.cn_no COLLATE DATABASE_DEFAULT = a.oid COLLATE DATABASE_DEFAULT and a.tdate = vitd.tdate " & _
                    "where a.txmonth = '" & txmonth & "' and a.aename<>'' " & _
                    " and ( a.ae_no in ( select ae_no from comm_ae_master_d c where a.txmonth = c.txmonth and iscommission_s = 1) " & _
                    " or exists (select * from comm_acc_master_d d where a.txmonth = d.txmonth and a.acc_no = d.acc_no and a.ae_no = d.ae_no_s)) " & _
                    " union " & _
                    "select a.ae_no, a.aename, isnull(b.acc_group_s, '') as acc_group, a.acc_no, a.tradetype, a.grossamt, a.commission, a.comm_rate, " & _
                    " a.tdate, a.oid, " & _
                    "cast(0 as numeric(18,4)) as co_comm, cast(0 as numeric(18,4)) as ae_comm, cast(0 as decimal(18,4)) as CoRate, " & _
                    "cast(0 as decimal(18,4)) as MinTO, cast(NULL as decimal(18,4)) as MinRate, cast(NULL as decimal(18,4)) as CoRateComm, " & _
                    "cast(NULL as decimal(18,4)) as MinRateComm, cast(NULL as decimal(18,4)) as MinTOComm, cast(NULL as decimal(18,4)) as GrpTO, " & _
                    "vitd.currency_code_set " & _
                    "from view_comm_adjusted_s a " & _
                    "left outer join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "left outer join " & GStrG2BSDB & ".dbo.View_IT_trade_detail vitd on vitd.aeno COLLATE DATABASE_DEFAULT = a.ae_no COLLATE DATABASE_DEFAULT and vitd.accno COLLATE DATABASE_DEFAULT = a.acc_no COLLATE DATABASE_DEFAULT and vitd.cn_no COLLATE DATABASE_DEFAULT = a.oid COLLATE DATABASE_DEFAULT and a.tdate = vitd.tdate " & _
                    "where a.txmonth = '" & txmonth & "'" & _
                    "and a.aename='' and a.acc_no+a.oid not in (select acc_no+oid from view_comm_adjusted_s where txmonth = '" & txmonth & "' group by acc_no+oid having count(*) > 1) " & _
                    " and ( a.ae_no in ( select ae_no from comm_ae_master_d c where a.txmonth = c.txmonth and iscommission_s = 1) " & _
                    " or exists (select * from comm_acc_master_d d where a.txmonth = d.txmonth and a.acc_no = d.acc_no and a.ae_no = d.ae_no_s)) " & _
                    "order by a.ae_no, acc_group, a.acc_no"

        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "tradelist")
        Return lds

    End Function

    Protected Friend Function lFncLoadRate(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct a.ae_no, a.acc_group, a.acc_no, a.rate_type, a.comm_type, " & _
                    " a.turnover_from, a.comm_rate, a.brokerage_rate, a.turnover_type " & _
                   " from comm_rate_s a " & _
                    " where a.comm_month = '" & txmonth & "' " & _
                    "order by a.ae_no, a.acc_no  "

        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "tradelist")
        Return lds

    End Function

    Protected Friend Function lFncGetAccGrp(ByVal ae_no As String, ByVal acc_no As String) As String

        Dim ldrAccList As DataRow() = ldsAccList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_no & "' ")

        If (ldrAccList.Length > 0) Then
            Return ldrAccList(0).Item("acc_group_s")
        End If

        Return ""

    End Function

    '====Manager Override Calulation======================================================================================

    Protected Friend Function lFncCalCommManager(ByVal ldtComm As DataTable, ByVal txmonth As String) As DataTable

        Dim ldsStandard = lFncLoadDefaultCfg(txmonth)
        Dim ldsGrpS As DataSet = lFncLoadGrpS(txmonth)
        Dim ldsGrpF As DataSet = lFncLoadGrpF(txmonth)
        Dim ldsRateS As DataSet = lFncLoadRateS(txmonth)
        Dim ldsRateF As DataSet = lFncLoadRateF(txmonth)
        Dim ldsAE As DataSet = lFncAEList(txmonth)

        Dim ldtManager As New DataTable
        InitManagerDTF(ldtManager)

        'used to calculate group total
        For i As Integer = 0 To ldtComm.Rows.Count - 1
            Dim ae_no As String = ldtComm.Rows(i).Item("ae_no")
            Dim ldrAE As DataRow() = ldsAE.Tables(0).Select(" ae_no = '" & ae_no & "' ")
            For j As Integer = 0 To ldrAE.Length - 1
                Dim man_no_s As String = ldrAE(j).Item("man_no_s")
                Dim man_group_s As String = ldrAE(j).Item("man_group_s")
                Dim total_brok_s As String = ldtComm.Rows(i).Item("total_brok_s")
                Dim total_TO_s As String = ldtComm.Rows(i).Item("total_TO_s")
                Dim total_rebate_s As String = ldtComm.Rows(i).Item("Total_comm_s")
                Dim ldrGrpS As DataRow() = ldsGrpS.Tables(0).Select(" man_no = '" & man_no_s & "' and man_group = '" & man_group_s & "' ")
                If (ldrGrpS.Length > 0) Then
                    ldrGrpS(0).Item("turn") = ldrGrpS(0).Item("turn") + total_TO_s
                    ldrGrpS(0).Item("brok") = ldrGrpS(0).Item("brok") + total_brok_s
                    ldrGrpS(0).Item("rebate") = ldrGrpS(0).Item("rebate") + total_rebate_s
                End If

                Dim man_no_f As String = ldrAE(j).Item("man_no_f")
                Dim man_group_f As String = ldrAE(j).Item("man_group_f")
                Dim total_brok_f As String = ldtComm.Rows(i).Item("total_brok_f")
                Dim total_TO_f As String = ldtComm.Rows(i).Item("total_TO_f")
                Dim total_brok_o As String = ldtComm.Rows(i).Item("total_brok_o")
                Dim total_TO_o As String = ldtComm.Rows(i).Item("total_TO_o")
                Dim ldrGrpF As DataRow() = ldsGrpF.Tables(0).Select(" man_no = '" & man_no_f & "' and man_group = '" & man_group_f & "' ")
                If (ldrGrpF.Length > 0) Then
                    ldrGrpF(0).Item("brokf") = ldrGrpF(0).Item("brokf") + total_brok_f
                    ldrGrpF(0).Item("turnf") = ldrGrpF(0).Item("turnf") + total_TO_f
                    ldrGrpF(0).Item("broko") = ldrGrpF(0).Item("broko") + total_brok_o
                    ldrGrpF(0).Item("turno") = ldrGrpF(0).Item("turno") + total_TO_o
                End If
            Next
        Next

        'used to update group rate(securities)
        For i As Integer = 0 To ldsGrpS.Tables(0).Rows.Count - 1
            Dim man_no As String = ldsGrpS.Tables(0).Rows(i).Item("man_no")
            Dim man_group As String = ldsGrpS.Tables(0).Rows(i).Item("man_group")
            Dim vol As Decimal = 0
            Dim ldrRate As DataRow() = Nothing
            If (ldsGrpS.Tables(0).Rows(i).Item("isDefault_s")) Then
                'get default
                Dim ldrDefault As DataRow() = ldsStandard.Tables(0).Select(" comm_type = 'MAN' ")

                If (ldrDefault.Length > 0) Then
                    If (ldsGrpS.Tables(0).Rows(i).Item("turnover_flag_s")) Then
                        ldsGrpS.Tables(0).Rows(i).Item("rate") = ldrDefault(0).Item("commNorRate")
                    ElseIf (ldsGrpS.Tables(0).Rows(i).Item("brokerage_flag_s")) Then
                        ldsGrpS.Tables(0).Rows(i).Item("rate") = ldrDefault(0).Item("minNorRate")
                    ElseIf (ldsGrpS.Tables(0).Rows(i).Item("rebate_flag_s")) Then
                        ldsGrpS.Tables(0).Rows(i).Item("rate") = 0
                    End If
                Else
                    ldsGrpS.Tables(0).Rows(i).Item("rate") = 0
                End If
            Else
                If (ldsGrpS.Tables(0).Rows(i).Item("turnover_flag_s")) Then
                    ldrRate = ldsRateS.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'MTURN' and turnover_from <= " & _
                                                        ldsGrpS.Tables(0).Rows(i).Item("turn"), " turnover_from ")
                ElseIf (ldsGrpS.Tables(0).Rows(i).Item("brokerage_flag_s")) Then
                    ldrRate = ldsRateS.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'MBROK' and turnover_from <= " & _
                                                        ldsGrpS.Tables(0).Rows(i).Item("brok"), " turnover_from ")
                ElseIf (ldsGrpS.Tables(0).Rows(i).Item("rebate_flag_s")) Then
                    ldrRate = ldsRateS.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'MREBATE' and turnover_from <= " & _
                                                        ldsGrpS.Tables(0).Rows(i).Item("rebate"), " turnover_from ")
                End If
                If (ldrRate.Length > 0) Then
                    ldsGrpS.Tables(0).Rows(i).Item("rate") = ldrRate(0).Item("comm_rate")
                Else
                    ldsGrpS.Tables(0).Rows(i).Item("rate") = 0
                End If
            End If
        Next

        'used to update group rate(futures)
        For i As Integer = 0 To ldsGrpF.Tables(0).Rows.Count - 1
            Dim man_no As String = ldsGrpF.Tables(0).Rows(i).Item("man_no")
            Dim man_group As String = ldsGrpF.Tables(0).Rows(i).Item("man_group")
            Dim ldrRateF As DataRow() = Nothing
            Dim ldrRateO As DataRow() = Nothing
            If (ldsGrpF.Tables(0).Rows(i).Item("isDefault_f")) Then
                'get default, need to change
                ldsGrpF.Tables(0).Rows(i).Item("ratef") = 0
                ldsGrpF.Tables(0).Rows(i).Item("rateo") = 0
            Else
                If (ldsGrpF.Tables(0).Rows(i).Item("turnover_flag_f")) Then
                    ldrRateF = ldsRateF.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'TURNF' and turnover_from <= " & _
                                                        ldsGrpF.Tables(0).Rows(i).Item("turnf"), " turnover_from ")
                    ldrRateO = ldsRateF.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'TURNO' and turnover_from <= " & _
                                                        ldsGrpF.Tables(0).Rows(i).Item("turno"), " turnover_from ")
                Else
                    ldrRateF = ldsRateF.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'BROKF' and turnover_from <= " & _
                                                        ldsGrpF.Tables(0).Rows(i).Item("brokf"), " turnover_from ")
                    ldrRateO = ldsRateF.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                        "' and rate_type = 'BROKO' and turnover_from <= " & _
                                                        ldsGrpF.Tables(0).Rows(i).Item("broko"), " turnover_from ")
                End If
                If (ldrRateF.Length > 0) Then
                    ldsGrpF.Tables(0).Rows(i).Item("ratef") = ldrRateF(0).Item("day_rate")
                Else
                    ldsGrpF.Tables(0).Rows(i).Item("ratef") = 0
                End If
                If (ldrRateO.Length > 0) Then
                    ldsGrpF.Tables(0).Rows(i).Item("rateo") = ldrRateO(0).Item("day_rate")
                Else
                    ldsGrpF.Tables(0).Rows(i).Item("rateo") = 0
                End If
            End If
        Next

        'calculate manager overridde and create dataset 
        For i As Integer = 0 To ldtComm.Rows.Count - 1
            Dim ae_no As String = ldtComm.Rows(i).Item("ae_no")
            Dim ldrAE As DataRow() = ldsAE.Tables(0).Select(" ae_no = '" & ae_no & "' ")
            '            If (ldrAE.Length > 0) Then
            For j As Integer = 0 To ldrAE.Length - 1
                Dim man_no_s As String = ldrAE(j).Item("man_no_s")
                Dim man_no_f As String = ldrAE(j).Item("man_no_f")
                Dim man_group_s As String = ldrAE(j).Item("man_group_s")
                Dim man_group_f As String = ldrAE(j).Item("man_group_f")
                Dim basis_s As String = ""
                Dim basis_f As String = ""
                Dim turnover_s As Decimal = 0
                Dim turnover_f As Decimal = 0
                Dim turnover_o As Decimal = 0
                Dim brokerage_s As Decimal = 0
                Dim brokerage_f As Decimal = 0
                Dim brokerage_o As Decimal = 0
                Dim rebate_s As Decimal = 0
                Dim grp_turnover_s As Decimal = 0
                Dim grp_turnover_f As Decimal = 0
                Dim grp_turnover_o As Decimal = 0
                Dim grp_brokerage_s As Decimal = 0
                Dim grp_brokerage_f As Decimal = 0
                Dim grp_brokerage_o As Decimal = 0
                Dim grp_rebate_s As Decimal = 0
                Dim comm_rate_s As Decimal = 0
                Dim comm_rate_f As Decimal = 0
                Dim comm_rate_o As Decimal = 0
                Dim comm_s As Decimal = 0
                Dim comm_f As Decimal = 0
                Dim comm_o As Decimal = 0

                Dim ldrGrpS As DataRow() = ldsGrpS.Tables(0).Select(" man_no = '" & man_no_s & "' and man_group = '" & man_group_s & "' ")
                If (ldrGrpS.Length > 0) Then
                    turnover_s = ldtComm.Rows(i).Item("Total_TO_s")
                    brokerage_s = ldtComm.Rows(i).Item("Total_Brok_s")
                    rebate_s = ldtComm.Rows(i).Item("Total_comm_s")
                    grp_turnover_s = ldrGrpS(0).Item("turn")
                    grp_brokerage_s = ldrGrpS(0).Item("brok")
                    grp_rebate_s = ldrGrpS(0).Item("rebate")
                    comm_rate_s = ldrGrpS(0).Item("rate")
                    'comm_s = turnover_s * comm_rate_s / 100
                    If (ldrGrpS(0).Item("turnover_flag_s") = True) Then
                        basis_s = "Turnover"
                        comm_s = turnover_s * comm_rate_s / 100
                    ElseIf (ldrGrpS(0).Item("brokerage_flag_s") = True) Then
                        basis_s = "Brokerage"
                        comm_s = brokerage_s * comm_rate_s / 100
                    ElseIf (ldrGrpS(0).Item("rebate_flag_s") = True) Then
                        basis_s = "Rebate"
                        comm_s = rebate_s * comm_rate_s / 100
                    End If
                End If

                Dim ldrGrpF As DataRow() = ldsGrpF.Tables(0).Select(" man_no = '" & man_no_f & "' and man_group = '" & man_group_f & "' ")
                If (ldrGrpF.Length > 0) Then
                    If (ldrGrpF(0).Item("turnover_flag_f") = True) Then
                        basis_f = "Turnover"
                    Else
                        basis_f = "Brokerage"
                    End If
                    turnover_f = ldtComm.Rows(i).Item("Total_TO_f")
                    turnover_o = ldtComm.Rows(i).Item("Total_TO_o")
                    brokerage_f = ldtComm.Rows(i).Item("Total_Brok_f")
                    brokerage_o = ldtComm.Rows(i).Item("Total_Brok_o")
                    grp_turnover_f = ldrGrpF(0).Item("turnf")
                    grp_turnover_o = ldrGrpF(0).Item("turno")
                    grp_brokerage_f = ldrGrpF(0).Item("brokf")
                    grp_brokerage_o = ldrGrpF(0).Item("broko")
                    comm_rate_f = ldrGrpF(0).Item("ratef")
                    comm_rate_o = ldrGrpF(0).Item("rateo")
                    comm_f = turnover_f * comm_rate_f / 100
                    comm_o = turnover_o * comm_rate_o / 100
                End If

                If (man_no_s <> man_no_f) Then
                    Dim ldrManager As DataRow = Nothing

                    If (man_no_s <> "") Then
                        ldrManager = ldtManager.NewRow
                        ldrManager("man_no") = man_no_s
                        ldrManager("ae_no") = ae_no
                        ldrManager("man_grp_s") = man_group_s
                        ldrManager("man_grp_f") = ""
                        ldrManager("basis_s") = basis_s
                        ldrManager("basis_f") = ""
                        ldrManager("turnover_s") = turnover_s
                        ldrManager("turnover_f") = 0
                        ldrManager("turnover_o") = 0
                        ldrManager("brokerage_s") = brokerage_s
                        ldrManager("brokerage_f") = 0
                        ldrManager("brokerage_o") = 0
                        ldrManager("grp_turnover_s") = grp_turnover_s
                        ldrManager("grp_turnover_f") = 0
                        ldrManager("grp_turnover_o") = 0
                        ldrManager("grp_brokerage_s") = grp_brokerage_s
                        ldrManager("grp_brokerage_f") = 0
                        ldrManager("grp_brokerage_o") = 0
                        ldrManager("comm_rate_s") = comm_rate_s
                        ldrManager("comm_rate_f") = 0
                        ldrManager("comm_rate_o") = 0
                        ldrManager("comm_s") = comm_s
                        ldrManager("comm_f") = 0
                        ldrManager("comm_o") = 0
                        ldtManager.Rows.Add(ldrManager)
                    End If

                    If (man_no_f <> "") Then
                        ldrManager = ldtManager.NewRow
                        ldrManager("man_no") = man_no_f
                        ldrManager("ae_no") = ae_no
                        ldrManager("man_grp_s") = ""
                        ldrManager("man_grp_f") = man_group_f
                        ldrManager("basis_s") = ""
                        ldrManager("basis_f") = basis_f
                        ldrManager("turnover_s") = 0
                        ldrManager("turnover_f") = turnover_f
                        ldrManager("turnover_o") = turnover_o
                        ldrManager("brokerage_s") = 0
                        ldrManager("brokerage_f") = brokerage_f
                        ldrManager("brokerage_o") = brokerage_o
                        ldrManager("grp_turnover_s") = 0
                        ldrManager("grp_turnover_f") = grp_turnover_f
                        ldrManager("grp_turnover_o") = grp_turnover_o
                        ldrManager("grp_brokerage_s") = 0
                        ldrManager("grp_brokerage_f") = grp_brokerage_f
                        ldrManager("grp_brokerage_o") = grp_brokerage_o
                        ldrManager("comm_rate_s") = 0
                        ldrManager("comm_rate_f") = comm_rate_f
                        ldrManager("comm_rate_o") = comm_rate_o
                        ldrManager("comm_s") = 0
                        ldrManager("comm_f") = comm_f
                        ldrManager("comm_o") = comm_o
                        ldtManager.Rows.Add(ldrManager)
                    End If
                Else
                    'same
                    Dim ldrManager As DataRow = ldtManager.NewRow
                    ldrManager("man_no") = man_no_s
                    ldrManager("ae_no") = ae_no
                    ldrManager("man_grp_s") = man_group_s
                    ldrManager("man_grp_f") = man_group_f
                    ldrManager("basis_s") = basis_s
                    ldrManager("basis_f") = basis_f
                    ldrManager("turnover_s") = turnover_s
                    ldrManager("turnover_f") = turnover_f
                    ldrManager("turnover_o") = turnover_o
                    ldrManager("brokerage_s") = brokerage_s
                    ldrManager("brokerage_f") = brokerage_f
                    ldrManager("brokerage_o") = brokerage_o
                    ldrManager("grp_turnover_s") = grp_turnover_s
                    ldrManager("grp_turnover_f") = grp_turnover_f
                    ldrManager("grp_turnover_o") = grp_turnover_o
                    ldrManager("grp_brokerage_s") = grp_brokerage_s
                    ldrManager("grp_brokerage_f") = grp_brokerage_f
                    ldrManager("grp_brokerage_o") = grp_brokerage_o
                    ldrManager("comm_rate_s") = comm_rate_s
                    ldrManager("comm_rate_f") = comm_rate_f
                    ldrManager("comm_rate_o") = comm_rate_o
                    ldrManager("comm_s") = comm_s
                    ldrManager("comm_f") = comm_f
                    ldrManager("comm_o") = comm_o
                    ldtManager.Rows.Add(ldrManager)
                End If
                'End If
            Next
        Next

        Return ldtManager

    End Function

    Protected Friend Function lFncLoadRateS(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select * from comm_rate_s where (rate_type = 'MTURN' or rate_type = 'MBROK' or rate_type = 'MREBATE' or rate_type = 'DEFM') and comm_month = '" & txmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
        Return lds

    End Function

    Protected Friend Function lFncLoadRateF(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select * from comm_rate_f where (rate_type = 'TURNF' or rate_type = 'BROKF' or rate_type = 'TURNO' " & _
                    "or rate_type = 'BROKO') and comm_month = '" & txmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "rate")
        Return lds

    End Function

    Protected Friend Function lFncLoadManagerCfgList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.man_no, b.ae_no, case when a.man_no = b.man_no_s then man_group_s else '' end man_group_s, " & _
                    "case when a.man_no = b.man_no_f then man_group_f else '' end man_group_f, " & _
                    "case when a.man_no = b.man_no_s then case when turnover_flag_s = 1 then 'Turnover' else 'Brokerage' end else '' end basis_s, " & _
                    "case when a.man_no = b.man_no_f then case when turnover_flag_f = 1 then 'Turnover' else 'Brokerage' end else '' end basis_f " & _
                    "from comm_man_master_d a " & _
                    "inner join comm_ae_master_d b on a.txmonth = b.txmonth and (a.man_no = b.man_no_s or a.man_no = b.man_no_f) " & _
                    "where a.txmonth = '" & txmonth & "' order by a.man_no, man_group_s, man_group_f "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "managerlist")
        Return lds

    End Function

    Protected Friend Function lFncLoadGrpS(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct man_no, man_group_s as man_group, turnover_flag_s, brokerage_flag_s, rebate_flag_s, " & _
                    "a.isDefault_s, cast(0 as decimal(18,4)) as turn, cast(0 as decimal(18,4)) as brok, " & _
                    "cast(0 as decimal(18,4)) as rebate, cast(0 as decimal(18,4)) as rate " & _
                    "from comm_man_master_d a " & _
                    "inner join comm_ae_master_d b on a.txmonth = b.txmonth and a.man_no = b.man_no_s and b.isCommission_s = 1 " & _
                    "where (a.turnover_flag_s = 1 or a.brokerage_flag_s = 1 or a.rebate_flag_s = 1) " & _
                    "and a.txmonth = '" & txmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "GrpS")
        Return lds

    End Function

    Protected Friend Function lFncLoadGrpF(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct man_no, man_group_f as man_group, turnover_flag_f, brokerage_flag_f, a.isDefault_f,  " & _
                    "cast(0 as decimal(18,4)) as brokf, cast(0 as decimal(18,4)) as broko, " & _
                    "cast(0 as decimal(18,4)) as turnf, cast(0 as decimal(18,4)) as turno, " & _
                    "cast(0 as decimal(18,4)) as ratef, cast(0 as decimal(18,4)) as rateo " & _
                    "from comm_man_master_d a " & _
                    "inner join comm_ae_master_d b on a.txmonth = b.txmonth and a.man_no = b.man_no_f " & _
                    "where a.txmonth = '" & txmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "GrpF")
        Return lds

    End Function

    Protected Friend Function lFncAEList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select ae_no, man_no_s, man_no_f, man_group_s, man_group_f " & _
                    "from comm_ae_master_d " & _
                    "where txmonth = '" & txmonth & "'" & _
                    "and (man_no_s <> '' or man_no_f <> '') "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "AE")
        Return lds

    End Function

    Private Sub InitManagerDTF(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "man_no"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ae_no"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "man_grp_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "man_grp_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "basis_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "basis_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "turnover_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "turnover_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "turnover_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "brokerage_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "brokerage_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "brokerage_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grp_turnover_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grp_turnover_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grp_turnover_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grp_brokerage_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grp_brokerage_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grp_brokerage_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate_o"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_s"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_f"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_o"
        DT.Columns.Add(Column)

    End Sub

    Protected Friend Function lFncGetLastGenerateDate(ByVal txmonth As String) As String

        Dim lstrSQL As String
        Dim ldtDate As DataTable = Nothing

        lstrSQL = "select min(luptdate) lastImportDate " & _
                    "from comm_ae_comm " & _
                    "where txmonth = '" & txmonth & "' "
        ldtDate = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If (IsDBNull(ldtDate.Rows(0).Item("lastImportDate"))) Then
            Return ""
        End If

        Return Format(ldtDate.Rows(0).Item("lastImportDate"), "dd MMM yyyy HH:mm:ss")

    End Function

    Protected Friend Function lFncGetLastImportDate(ByVal txmonth As String) As String

        Dim lstrSQL As String
        Dim ldtDate As DataTable = Nothing

        lstrSQL = "select min(lastupddate) as minDate " & _
                    "from comm_trade_s " & _
                    "where txmonth = '" & txmonth & "' "
        ldtDate = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If (IsDBNull(ldtDate.Rows(0).Item("minDate"))) Then
            Return ""
        End If

        Return Format(ldtDate.Rows(0).Item("minDate"), "dd MMM yyyy HH:mm:ss")

    End Function

    Public Function FncGetLogs(ByVal mCode As String) As Boolean
        Dim lpt As String = ""
        Dim str As String = "select max(d_Date) as d_date from comm_last_posting_time "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            lpt = Format(GFncNoNullDate(dt.Rows(0).Item("d_date")), "yyyy/MM/dd HH:mm:ss")
        End If
        str = "select * from logtbl where d_txmonth = '" & mCode & "' and d_type in " & _
            "(select distinct misc_code from misc_master where misc_type = 'COMMLOG')"
        If lpt <> "" Then
            str &= "and d_date > '" & lpt & "' "
        End If
        dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

End Class
