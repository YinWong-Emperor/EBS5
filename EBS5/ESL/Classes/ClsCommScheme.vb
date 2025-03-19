Imports System.Data.SqlClient

Public Class ClsCommScheme

    Protected Function lfncDelete(ByVal strTableName As String, ByVal strDateTo As String, ByVal stnTrans As SqlTransaction, ByVal strField As String) As Boolean
        GFncRunSQL(GSCnSqlConn, stnTrans, " delete from draft_" & strTableName & "  where " & strField & " = '" & strDateTo & "' ", 0)
        GFncRunSQL(GSCnSqlConn, stnTrans, " delete from " & strTableName & "  where " & strField & " = '" & strDateTo & "' ", 0)
        Return True
    End Function

    Protected Friend Function lFncCopyScheme(ByVal strDateFrom As String, ByVal strDateTo As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = ""
        Dim logstr As String = ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lfncDelete("comm_man_master_d", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_ae_master_d", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_acc_master_d", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_group_s", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_group_f", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_product_group", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_global", strDateTo, lstnTrans, "txmonth")
            lfncDelete("comm_rate_s", strDateTo, lstnTrans, "comm_month")
            lfncDelete("comm_rate_f", strDateTo, lstnTrans, "comm_month")
            lfncDelete("comm_rate_other", strDateTo, lstnTrans, "comm_month")

            'copy manager master detail
            lstrSQL = "insert into draft_comm_man_master_d(txmonth, brokerage_flag_f, brokerage_flag_s, isDefault_f, isDefault_s, " & _
                "man_grp, man_no, turnover_flag_f, turnover_flag_s, rebate_flag_s, rebate_flag_f) select '" & strDateTo & _
                "', brokerage_flag_f, brokerage_flag_s, isDefault_f, isDefault_s, man_grp, man_no, turnover_flag_f, " & _
                "turnover_flag_s, rebate_flag_s, rebate_flag_f from comm_man_master_d where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_man_master_d(txmonth, brokerage_flag_f, brokerage_flag_s, isDefault_f, isDefault_s, " & _
               "man_grp, man_no, turnover_flag_f, turnover_flag_s, rebate_flag_s, rebate_flag_f) select '" & strDateTo & _
               "', brokerage_flag_f, brokerage_flag_s, isDefault_f, isDefault_s, man_grp, man_no, turnover_flag_f, " & _
               "turnover_flag_s, rebate_flag_s, rebate_flag_f from comm_man_master_d where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy ae master detail
            lstrSQL = "insert into draft_comm_ae_master_d(txmonth, ae_no, bonus_flag, incentive_flag, isCommission_f, " & _
                "isCommission_s, isConsolid, isDefault_f, isDefault_s, man_group_f, man_group_s ,man_no_f,  man_no_s, " & _
                "minIntAmt, minIntRate, minNorAmt, minNorRate, team, isBothFO) select '" & strDateTo & "', ae_no, bonus_flag, " & _
                "incentive_flag, isCommission_f, isCommission_s, isConsolid, isDefault_f, isDefault_s, man_group_f, " & _
                "man_group_s, man_no_f, man_no_s, minIntAmt, minIntRate, minNorAmt, minNorRate, team, isBothFO from " & _
                "comm_ae_master_d where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_ae_master_d(txmonth, ae_no, bonus_flag, incentive_flag, isCommission_f, " & _
               "isCommission_s, isConsolid, isDefault_f, isDefault_s, man_group_f, man_group_s ,man_no_f,  man_no_s, " & _
               "minIntAmt, minIntRate, minNorAmt, minNorRate, team, isBothFO) select '" & strDateTo & "', ae_no, bonus_flag, " & _
               "incentive_flag, isCommission_f, isCommission_s, isConsolid, isDefault_f, isDefault_s, man_group_f, " & _
               "man_group_s, man_no_f, man_no_s, minIntAmt, minIntRate, minNorAmt, minNorRate, team, isBothFO from " & _
               "comm_ae_master_d where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy securities group
            lstrSQL = "insert into draft_comm_group_s (txmonth, ae_group_s, ae_no, isConsolid, minConTO, minIntTO, minNorTO) " & _
                "select '" & strDateTo & "', ae_group_s, ae_no, isConsolid, minConTO, minIntTO, minNorTO from " & _
                "comm_group_s where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_group_s (txmonth, ae_group_s, ae_no, isConsolid, minConTO, minIntTO, minNorTO) " & _
             "select '" & strDateTo & "', ae_group_s, ae_no, isConsolid, minConTO, minIntTO, minNorTO from " & _
             "comm_group_s where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy futures group
            lstrSQL = "insert into draft_comm_group_f (txmonth, ae_group_f, ae_no, isConsolid, minConTO, minIntTO, minNorTO, " & _
                "isBothFO) select '" & strDateTo & "', ae_group_f, ae_no, isConsolid, minConTO, minIntTO, minNorTO, isBothFO " & _
                "from comm_group_f where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_group_f (txmonth, ae_group_f, ae_no, isConsolid, minConTO, minIntTO, minNorTO, " & _
               "isBothFO) select '" & strDateTo & "', ae_group_f, ae_no, isConsolid, minConTO, minIntTO, minNorTO, isBothFO " & _
               "from comm_group_f where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy acc master detail
            lstrSQL = "insert into draft_comm_acc_master_d (acc_no, txmonth, comm_type, isConsolid, acc_group_s, acc_group_f, " & _
                "ae_no_s,ae_no_f, isDefault_f, isDefault_s, man_no_f, man_no_s, minIntAmt, minIntRate, minNorAmt, minNorRate, " & _
                "isBothFO) select acc_no, '" & strDateTo & "', comm_type, isConsolid, acc_group_s, acc_group_f, ae_no_s, " & _
                "ae_no_f, isDefault_f, isDefault_s, man_no_f, man_no_s, minIntAmt, minIntRate, minNorAmt, minNorRate, " & _
                "isBothFO from comm_acc_master_d where txmonth = '" & strDateFrom & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_acc_master_d (acc_no, txmonth, comm_type, isConsolid, acc_group_s, acc_group_f, " & _
              "ae_no_s,ae_no_f, isDefault_f, isDefault_s, man_no_f, man_no_s, minIntAmt, minIntRate, minNorAmt, minNorRate, " & _
              "isBothFO) select acc_no, '" & strDateTo & "', comm_type, isConsolid, acc_group_s, acc_group_f, ae_no_s, " & _
              "ae_no_f, isDefault_f, isDefault_s, man_no_f, man_no_s, minIntAmt, minIntRate, minNorAmt, minNorRate, " & _
              "isBothFO from comm_acc_master_d where txmonth = '" & strDateFrom & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy product group
            lstrSQL = "insert into draft_comm_product_group (txmonth, product_code, product_group) select '" & strDateTo & _
                "', product_code, product_group from comm_product_group where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_product_group (txmonth, product_code, product_group) select '" & strDateTo & _
               "', product_code, product_group from comm_product_group where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into draft_comm_product_group (product_group, product_code, txmonth) select 'ALL', " & _
                "a.product_code, '" & strDateTo & "' from futures_product_master a left join draft_comm_product_group b " & _
                "on a.product_code = b.product_code collate database_default and b.product_group = 'ALL' and b.txmonth = '" & _
                strDateTo & "' where b.product_code is null "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_product_group (product_group, product_code, txmonth) select 'ALL', " & _
                "a.product_code, '" & strDateTo & "' from futures_product_master a left join comm_product_group b " & _
                "on a.product_code = b.product_code collate database_default and b.product_group = 'ALL' and b.txmonth = '" & _
                strDateTo & "' where b.product_code is null "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy default rate
            lstrSQL = "insert into draft_comm_global (txmonth, comm_type, commIntRate, commIntRate_f, commNorRate, " & _
                "commNorRate_f, minFIntBrkRate, minFNorBrkRate, minIntAmt, minIntRate_s, minNorAmt, minNorRate_s, " & _
                "minOIntBrkRate, minONorBrkRate) select '" & strDateTo & "', comm_type, commIntRate, commIntRate_f, " & _
                "commNorRate, commNorRate_f, minFIntBrkRate, minFNorBrkRate, minIntAmt, minIntRate_s, minNorAmt, " & _
                "minNorRate_s, minOIntBrkRate, minONorBrkRate from comm_global where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_global (txmonth, comm_type, commIntRate, commIntRate_f, commNorRate, " & _
                "commNorRate_f, minFIntBrkRate, minFNorBrkRate, minIntAmt, minIntRate_s, minNorAmt, minNorRate_s, " & _
                "minOIntBrkRate, minONorBrkRate) select '" & strDateTo & "', comm_type, commIntRate, commIntRate_f, " & _
                "commNorRate, commNorRate_f, minFIntBrkRate, minFNorBrkRate, minIntAmt, minIntRate_s, minNorAmt, " & _
                "minNorRate_s, minOIntBrkRate, minONorBrkRate from comm_global where txmonth = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy securities rate
            lstrSQL = "insert into draft_comm_rate_s (comm_month, acc_group, acc_no, ae_no, brokerage_rate, comm_rate, " & _
                "comm_type, man_group, man_no, rate_type, turnover_from, turnover_type) select '" & strDateTo & "', " & _
                "acc_group, acc_no, ae_no, brokerage_rate, comm_rate, comm_type, man_group, man_no, rate_type, turnover_from, " & _
                "turnover_type from comm_rate_s where comm_month = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_rate_s (comm_month, acc_group, acc_no, ae_no, brokerage_rate, comm_rate, " & _
              "comm_type, man_group, man_no, rate_type, turnover_from, turnover_type) select '" & strDateTo & "', " & _
              "acc_group, acc_no, ae_no, brokerage_rate, comm_rate, comm_type, man_group, man_no, rate_type, turnover_from, " & _
              "turnover_type from comm_rate_s where comm_month = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy futures rate
            lstrSQL = "insert into draft_comm_rate_f (comm_month, acc_group, acc_no, ae_no, all_rate, brok_per_lot, " & _
                "comm_rate, comm_type, day_rate, man_group, man_no, night_rate, product_group, rate_type, turnover_from, " & _
                "turnover_type) select '" & strDateTo & "', acc_group, acc_no, ae_no, all_rate, brok_per_lot, comm_rate, " & _
                "comm_type, day_rate, man_group, man_no, night_rate, product_group, rate_type, turnover_from, turnover_type " & _
                "from comm_rate_f where comm_month = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_rate_f (comm_month, acc_group, acc_no, ae_no, all_rate, brok_per_lot, " & _
                 "comm_rate, comm_type, day_rate, man_group, man_no, night_rate, product_group, rate_type, turnover_from, " & _
                 "turnover_type) select '" & strDateTo & "', acc_group, acc_no, ae_no, all_rate, brok_per_lot, comm_rate, " & _
                 "comm_type, day_rate, man_group, man_no, night_rate, product_group, rate_type, turnover_from, turnover_type " & _
                 "from comm_rate_f where comm_month = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'copy futures other rate
            lstrSQL = "insert into draft_comm_rate_other (comm_month, ae_no, comm_net_brok, comm_rate, comm_type) select '" & _
                strDateTo & "', ae_no, comm_net_brok, comm_rate, comm_type from comm_rate_other " & _
                "where comm_month = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstrSQL = "insert into comm_rate_other (comm_month, ae_no, comm_net_brok, comm_rate, comm_type) select '" & _
              strDateTo & "', ae_no, comm_net_brok, comm_rate, comm_type from comm_rate_other " & _
              "where comm_month = '" & strDateFrom & "'"
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            logstr = GfncOneFieldLog("Commission Month", strDateFrom, strDateTo)
            GFncFillLog(GStrloginID, "C", GDteTradeDate, "CopyCommScheme", "", "", 0, strDateFrom, logstr, lstnTrans)
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function lFncGetLastDate() As String
        Dim ldtsData As DataSet = GFncRtnDS(GSCnSqlConn, " select max(txmonth) from draft_comm_ae_master_d ")
        If ldtsData.Tables(0).Rows.Count > 0 Then
            Return ldtsData.Tables(0).Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

End Class
