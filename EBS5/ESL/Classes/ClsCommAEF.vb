Imports System.Data.SqlClient

Public Class ClsCommAEF

    Protected Friend Function lFncGetAccF(ByVal strMonth As String) As DataTable

        Dim lstrSQL As String

        lstrSQL = " select * from comm_acc_master_d " & _
                " where txmonth = '" & strMonth & _
                " and acc_no not in ( select accno from view_comm_adjusted_f " & _
                " where txmonth = '" & strMonth & "') " & _
                 "' order by accno "
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

        lstrSQL = " select a.txmonth, b.acc_no, tradetype, case when call_put = 0 then 'F' else 'O' end as txtype, " & _
                    " b.ae_no_f as ae_no ,isnull(b.acc_group_f, '') as acc_group_f, b.isconsolid, commod," & _
                    " sum(day_mm) as total_day,  sum(night_mm) as total_night, " & _
                    " sum(day_commission) as day_comm,  sum(night_commission) as night_comm " & _
                    " from view_comm_adjusted_f a inner  join comm_acc_master_d b " & _
                    " on a.txmonth = b.txmonth and b.ae_no_f = a.aeno and b.acc_no = a.accno" & _
                    " group by  a.txmonth,b.acc_no, tradetype," & _
                    " case when call_put = 0 then 'F' else 'O' end, b.ae_no_f, b.acc_group_f, b.isconsolid, commod " & _
                    " order by  a.txmonth,  b.ae_no_f, b.acc_no, b.acc_group_f, a.tradetype, b.isconsolid, commod "

        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)

    End Function
    Protected Friend Function lfncParpareTODTF(ByVal strMonth As String) As DataTable

        Dim ldtTO As DataTable = lFncGetTurnOverF(strMonth)
        Dim ldtRate As DataTable = lFncGetRateF(strMonth)
        Dim ldtPG As DataTable = lFncGetProdGrpF(strMonth)
        Dim ldtGlobal As DataTable = lFncGetGlobalF(strMonth)
        Dim ldtGrp As DataTable = lFncGetAccGroupF(strMonth)
        Dim ldtDetail As New DataTable
        InitDetailDTF(ldtDetail)

        For Each ldrTO As DataRow In ldtTO.Rows
            Dim ldr As DataRow() = ldtDetail.Select(" acc_no = '" & ldrTO("acc_no") & _
                "' and ae_no = '" & ldrTO("ae_no") & "' and commod = '" & _
                ldrTO("commod") & "' and txtype = '" & ldrTO("txtype").ToString.Trim & "'")
            If ldr.Length > 0 Then
                If ldrTO("tradetype") = 0 Then
                    ldr(0).Item("day_nor") += ldrTO("total_day")
                    ldr(0).Item("night_nor") += ldrTO("total_night")
                Else
                    ldr(0).Item("day_int") += ldrTO("total_day")
                    ldr(0).Item("night_int") += ldrTO("total_night")
                End If
                ldr(0).Item("day_comm") += ldrTO("day_comm")
                ldr(0).Item("night_comm") += ldrTO("night_comm")
            Else
                Dim ldrDetail As DataRow = ldtDetail.NewRow
                ldrDetail("txmonth") = strMonth
                ldrDetail("acc_no") = ldrTO("acc_no")
                ldrDetail("ae_no") = ldrTO("ae_no")
                ldrDetail("acc_group") = ldrTO("acc_group_f").ToString.Trim
                ldrDetail("txtype") = ldrTO("txtype").ToString.Trim
                ldrDetail("day_nor") = 0
                ldrDetail("day_int") = 0
                ldrDetail("night_nor") = 0
                ldrDetail("night_int") = 0
                If ldrTO("tradetype") = 0 Then
                    ldrDetail("day_nor") = ldrTO("total_day")
                    ldrDetail("night_nor") = ldrTO("total_night")
                Else
                    ldrDetail("day_int") = ldrTO("total_day")
                    ldrDetail("night_int") = ldrTO("total_night")
                End If
                ldrDetail("isconsolid") = ldrTO("isconsolid")
                ldrDetail("commod") = ldrTO("commod")
                ldrDetail("day_comm") = ldrTO("day_comm")
                ldrDetail("night_comm") = ldrTO("night_comm")
                ldrDetail("ae_comm") = 0
                ldrDetail("day_rate") = 0
                ldrDetail("night_rate") = 0
                ldrDetail("night_nor_total_TO") = 0
                ldrDetail("night_int_total_TO") = 0
                ldrDetail("day_nor_total_TO") = 0
                ldrDetail("day_int_total_TO") = 0
                ldrDetail("night_nor_g_total_TO") = 0
                ldrDetail("night_int_g_total_TO") = 0
                ldrDetail("day_nor_g_total_TO") = 0
                ldrDetail("day_int_g_total_TO") = 0
                ldtDetail.Rows.Add(ldrDetail)
            End If
        Next

        lfuncUpdPGTOF(ldtPG, ldtDetail)
        lfncCalCommF(ldtDetail, ldtRate, ldtPG, ldtGrp, ldtGlobal)


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
            Dim ldrComm As DataRow() = ldtComm.Select("ae_no = '" & ldrDetail("ae_no") & "'")
            If ldrComm.Length > 0 Then
                If ldrDetail("txtype") = "F" Then
                    ldrComm(0).Item("total_brok_f") += ldrDetail("day_comm") + ldrDetail("night_comm")
                    ldrComm(0).Item("total_comm_f") += ldrDetail("ae_comm")
                    ldrComm(0).Item("total_TO_f") += ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                          + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                Else
                    ldrComm(0).Item("total_brok_o") += ldrDetail("day_comm") + ldrDetail("night_comm")
                    ldrComm(0).Item("total_comm_o") += ldrDetail("ae_comm")
                    ldrComm(0).Item("total_TO_o") += ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                          + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                End If
            Else
                Dim ldr As DataRow
                ldr = ldtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrDetail("ae_no")
                ldr("total_brok_o") = 0
                ldr("total_comm_o") = 0
                ldr("total_brok_f") = 0
                ldr("total_comm_f") = 0
                ldr("total_TO_o") = 0
                ldr("total_TO_s") = 0
                ldr("total_TO_f") = 0
                If ldrDetail("txtype") = "F" Then
                    ldr("total_brok_f") = ldrDetail("day_comm") + ldrDetail("night_comm")
                    ldr("total_comm_f") = ldrDetail("ae_comm")
                    ldr("total_TO_f") = ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                           + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                Else
                    ldr("total_brok_o") = ldrDetail("day_comm") + ldrDetail("night_comm")
                    ldr("total_comm_o") = ldrDetail("ae_comm")
                    ldr("total_TO_o") = ldrDetail("day_nor_total_to") + ldrDetail("night_nor_total_to") _
                          + ldrDetail("day_int_total_to") + ldrDetail("night_int_total_to")
                End If
                ldr("total_brok_s") = 0
                ldr("total_comm_s") = 0
                ldr("total_comm_i") = 0
                ldr("total_comm_b") = 0
                ldr("total_comm_a") = 0
                ldr("total_comm_m") = 0
                ldr("comm_rate_inc") = 0
                ldr("comm_rate_bon") = 0
                ldr("man_no_s") = ""
                ldr("man_no_f") = ""
                ldtComm.Rows.Add(ldr)
            End If
        Next
        For Each ldrDetail As DataRow In dtDetailS.Rows
            Dim ldrComm As DataRow() = ldtComm.Select("ae_no = '" & ldrDetail("ae_no") & "'")
            If ldrComm.Length > 0 Then
                ldrComm(0).Item("total_brok_s") += ldrDetail("ae_comm") + ldrDetail("co_comm")
                ldrComm(0).Item("total_comm_s") += ldrDetail("ae_comm")
                ldrComm(0).Item("total_TO_s") += ldrDetail("grossamt")
            Else
                Dim ldr As DataRow
                ldr = ldtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrDetail("ae_no")
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
                ldr("total_comm_a") = 0
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
            Dim ldrComm As DataRow() = dtComm.Select("ae_no = '" & ldrDetail("man_no") & "'")
            If ldrComm.Length > 0 Then
                ldrComm(0).Item("total_comm_m") += ldrDetail("comm_s") + ldrDetail("comm_f") + ldrDetail("comm_o")
            Else
                Dim ldr As DataRow
                ldr = dtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrDetail("ae_no")
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
                ldr("total_comm_a") = 0
                ldr("total_comm_m") = ldrDetail("comm_s") + ldrDetail("comm_f") + ldrDetail("comm_o")
                ldr("comm_rate_inc") = 0
                ldr("comm_rate_bon") = 0
                ldr("man_no_s") = ""
                ldr("man_no_f") = ""
                dtComm.Rows.Add(ldr)
            End If
            ldrComm = dtComm.Select("ae_no = '" & ldrDetail("ae_no") & "'")
            If ldrComm.Length > 0 Then
                If ldrDetail("comm_s") > 0 Then
                    ldrComm(0).Item("man_no_s") = ldrDetail("man_no")
                End If
                If ldrDetail("comm_f") + ldrDetail("comm_o") > 0 Then
                    ldrComm(0).Item("man_no_f") = ldrDetail("man_no")
                End If
            End If
        Next

        For Each ldrAdj As DataRow In ldtCommAdj.Rows
            Dim ldrComm As DataRow() = dtComm.Select("ae_no = '" & ldrAdj("ae_no") & "'")
            If ldrComm.Length > 0 Then
                ldrComm(0).Item("total_comm_a") += ldrAdj("adj_amt")
            Else
                Dim ldr As DataRow
                ldr = dtComm.NewRow
                ldr("txmonth") = strMonth
                ldr("ae_no") = ldrAdj("ae_no")
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
                ldr("total_comm_a") = ldrAdj("adj_amt")
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
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lstrSQL = " delete from comm_ae_comm where txmonth = '" & strMonth & "' "
            GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0)
            For Each ldrComm As DataRow In dtComm.Rows
                lstrSQL = " insert into comm_ae_comm (txmonth, ae_no, comm_s, comm_f, comm_o, incentive_comm, " & _
                    " bonus_comm, comm_paid, comm_adj, override_comm, brokerage_s, brokerage_f, " & _
                    " brokerage_o, managerno_s,managerno_f, luptuser, luptdate ) values " & _
                    "('" & strMonth & "','" & ldrComm("ae_no") & "'," & ldrComm("total_comm_s") & _
                    "," & ldrComm("total_comm_f") & "," & ldrComm("total_comm_o") & _
                    "," & ldrComm("total_comm_i") & "," & ldrComm("total_comm_b") & _
                    ",0," & ldrComm("total_comm_a") & "," & ldrComm("total_comm_m") & _
                    "," & ldrComm("total_brok_s") & "," & ldrComm("total_brok_f") & _
                    "," & ldrComm("total_brok_o") & ",'" & ldrComm("man_no_s") & _
                    "','" & ldrComm("man_no_f") & _
                    "','" & GStrloginID & "',getdate()) "
                If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    lstnTrans.Rollback()
                    Return False
                End If
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
    Protected Friend Function lfncCalCommF(ByRef dtDetail As DataTable, ByVal dtRate As DataTable, ByVal dtPG As DataTable, _
        ByVal dtGrp As DataTable, ByVal dtGlobal As DataTable) As Boolean
        Dim ldrDetail As DataRow() = dtDetail.Select(" acc_group = '' ")
        Dim ldrGlobal As DataRow() = dtGlobal.Select(" comm_type = 'ACC' ")
        Dim ldrRate As DataRow
        For lintCnt As Integer = 0 To ldrDetail.Length - 1
            If ldrDetail(lintCnt).Item("day_int") + ldrDetail(lintCnt).Item("night_int") > 0 Then
                ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "ACC", _
                                           "INT", ldrDetail(lintCnt).Item("isconsolid"), dtRate, dtPG, dtDetail)
                If Not IsNothing(ldrRate) Then
                    ldrDetail(lintCnt).Item("day_rate") = ldrRate("day_rate")
                    ldrDetail(lintCnt).Item("night_rate") = ldrRate("night_rate")
                Else
                    If ldrGlobal.Length > 0 Then
                        ldrDetail(lintCnt).Item("day_rate") = ldrGlobal(0).Item("commnorrate_f")
                        ldrDetail(lintCnt).Item("night_rate") = ldrGlobal(0).Item("commnorrate_f")
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm") * (1 - (ldrDetail(lintCnt).Item("day_rate") / 100))
                End If
                If ldrDetail(lintCnt).Item("night_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm") * (1 - (ldrDetail(lintCnt).Item("night_rate") / 100))
                End If
            End If
            If ldrDetail(lintCnt).Item("day_nor") + ldrDetail(lintCnt).Item("night_nor") > 0 Then
                ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "ACC", _
                                         "NOR", ldrDetail(lintCnt).Item("isconsolid"), dtRate, dtPG, dtDetail)
                ldrDetail(lintCnt).Item("day_rate") = 0
                ldrDetail(lintCnt).Item("night_rate") = 0
                If Not IsNothing(ldrRate) Then
                    ldrDetail(lintCnt).Item("day_rate") = ldrRate("day_rate")
                    ldrDetail(lintCnt).Item("night_rate") = ldrRate("night_rate")
                Else
                    If ldrGlobal.Length > 0 Then
                        ldrDetail(lintCnt).Item("day_rate") = ldrGlobal(0).Item("commnorrate_f")
                        ldrDetail(lintCnt).Item("night_rate") = ldrGlobal(0).Item("commnorrate_f")
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm") * (1 - (ldrDetail(lintCnt).Item("day_rate") / 100))
                End If
                If ldrDetail(lintCnt).Item("night_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm") * (1 - (ldrDetail(lintCnt).Item("night_rate") / 100))
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
                If lblnGroup Then
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "AGRP", _
                                             "INT", lblnIsConsolid, dtRate, dtPG, dtDetail)
                Else
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "ACC", _
                                             "INT", lblnIsConsolid, dtRate, dtPG, dtDetail)
                End If
                If Not IsNothing(ldrRate) Then
                    ldrDetail(lintCnt).Item("day_rate") = ldrRate("day_rate")
                    ldrDetail(lintCnt).Item("night_rate") = ldrRate("night_rate")
                Else
                    If ldrGlobal.Length > 0 Then
                        ldrDetail(lintCnt).Item("day_rate") = ldrGlobal(0).Item("commnorrate_f")
                        ldrDetail(lintCnt).Item("night_rate") = ldrGlobal(0).Item("commnorrate_f")
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm") * (1 - (ldrDetail(lintCnt).Item("day_rate") / 100))
                End If
                If ldrDetail(lintCnt).Item("night_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm") * (1 - (ldrDetail(lintCnt).Item("night_rate") / 100))
                End If
            End If
            If ldrDetail(lintCnt).Item("day_nor") + ldrDetail(lintCnt).Item("night_nor") > 0 Then
                Dim lblnGroup As Boolean = False
                Dim lblnIsConsolid As Boolean = ldrDetail(lintCnt).Item("isconsolid")
                If ldrGrp.Length > 0 Then
                    lblnIsConsolid = ldrGrp(0).Item("isconsolid")
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
                If lblnGroup Then
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "AGRP", _
                                             "NOR", lblnIsConsolid, dtRate, dtPG, dtDetail)
                Else
                    ldrRate = lfuncCalCommRateF(ldrDetail(lintCnt), "ACC", _
                                             "NOR", lblnIsConsolid, dtRate, dtPG, dtDetail)
                End If

                ldrDetail(lintCnt).Item("day_rate") = 0
                ldrDetail(lintCnt).Item("night_rate") = 0
                If Not IsNothing(ldrRate) Then
                    ldrDetail(lintCnt).Item("day_rate") = ldrRate("day_rate")
                    ldrDetail(lintCnt).Item("night_rate") = ldrRate("night_rate")
                Else
                    If ldrGlobal.Length > 0 Then
                        ldrDetail(lintCnt).Item("day_rate") = ldrGlobal(0).Item("commnorrate_f")
                        ldrDetail(lintCnt).Item("night_rate") = ldrGlobal(0).Item("commnorrate_f")
                    End If
                End If
                If ldrDetail(lintCnt).Item("day_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("day_comm") * (1 - (ldrDetail(lintCnt).Item("day_rate") / 100))
                End If
                If ldrDetail(lintCnt).Item("night_rate") > 0 Then
                    ldrDetail(lintCnt).Item("ae_comm") += ldrDetail(lintCnt).Item("night_comm") * (1 - (ldrDetail(lintCnt).Item("night_rate") / 100))
                End If
            End If
        Next

        Return True

    End Function

    Protected Friend Function lfuncUpdPGTOF(ByVal dtPG As DataTable, ByRef dtDetail As DataTable) As Decimal

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
                                           "' and txtype = '" & ldrDetail("txtype") & "'")
                    For lintIdx As Integer = 0 To ldr.Length - 1
                        ldrDetail("day_nor_total_TO") += ldr(lintIdx).Item("day_nor")
                        ldrDetail("day_int_total_TO") += ldr(lintIdx).Item("day_int")
                        ldrDetail("night_nor_total_TO") += ldr(lintIdx).Item("night_nor")
                        ldrDetail("night_int_total_TO") += ldr(lintIdx).Item("night_int")
                    Next
                    If ldrDetail("acc_group").ToString.Trim <> "" Then
                        ldr = dtDetail.Select(" ae_no = '" & ldrDetail("ae_no") & _
                                             "' and commod = '" & ldrPG(lintCnt).Item("product_code") & _
                                             "' and txtype = '" & ldrDetail("txtype") & _
                                             "' and acc_group = '" & ldrDetail("acc_group").ToString.Trim & "'")
                        For lintIdx As Integer = 0 To ldr.Length - 1
                            ldrDetail("day_nor_g_total_TO") += ldr(lintIdx).Item("day_nor")
                            ldrDetail("day_int_g_total_TO") += ldr(lintIdx).Item("day_int")
                            ldrDetail("night_nor_g_total_TO") += ldr(lintIdx).Item("night_nor")
                            ldrDetail("night_int_g_total_TO") += ldr(lintIdx).Item("night_int")
                        Next
                    End If
                Next
            End If
        Next

    End Function

    Protected Friend Function lfuncCalCommRateF(ByVal drDetail As DataRow, ByVal strCommType As String, _
    ByVal strRateType As String, ByVal blnIsConsolid As Boolean, ByVal dtRate As DataTable, _
    ByVal dtpg As DataTable, ByVal dtDetail As DataTable) As DataRow


        Dim ldecTO As Decimal = 0

        Dim lstrPG As String = ""
        Dim ldrPG As DataRow() = dtpg.Select(" product_code = '" & drDetail("commod") & "' ")
        If ldrPG.Length <= 0 Then
            Return Nothing
        End If

        Dim ldrRate As DataRow()
        If strCommType = "ACC" Then
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
            ldrRate = dtRate.Select(" comm_type = '" & strCommType & _
                         "' and rate_type = '" & strRateType & drDetail("txtype") & _
                         "' and acc_no = '" & drDetail("acc_no") & _
                         "' and ae_no = '" & drDetail("ae_no") & _
                         "' and product_group = '" & ldrPG(0).Item("product_group") & "' ", " turnover_from desc ")
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
            ldrRate = dtRate.Select(" comm_type = '" & strCommType & _
                        "' and rate_type = '" & strRateType & drDetail("txtype") & _
                        "' and acc_group = '" & drDetail("acc_group") & _
                        "' and ae_no = '" & drDetail("ae_no") & _
                        "' and product_group = '" & ldrPG(0).Item("product_group") & "' ", " turnover_from desc ")
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
        Column.ColumnName = "Total_comm_a"
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
        Column.ColumnName = "day_comm"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_comm"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_rate"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_rate"
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

    End Sub

End Class
