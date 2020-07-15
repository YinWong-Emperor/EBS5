Imports System.Data.SqlClient

Public Class ClsCommCopyRate

    Protected Friend Function GetLatestMonth() As String
        Dim lstrSQL As String = "Select isnull(max(txmonth),0) as txmonth from view_comm_afe_rate_s "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows(0).Item(0) = 0 Then
            Return Now.Year.ToString & Format(Val(Now.Month) - 1, "00")
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    'Protected Friend Function lFncImportAE(ByVal ae_no As String) As Boolean
    '    Dim lstrSQL As String = "delete from comm_rate_s where comm_month = '200810' and ae_no = '" & ae_no & "' "
    '    GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
    '    lstrSQL = "insert into comm_rate_s(acc_no, acc_group, man_no, man_group, ae_no, rate_type, " & _
    '                "turnover_from, comm_rate, comm_month, comm_type, turnover_type, brokerage_rate) " & _
    '                "select acc_no, '', '', '', ae_no, rate_type, turnover_from, 0, txmonth, comm_type, null, " & _
    '                "brokerage_rate from view_comm_afe_rate_s " & _
    '                "where ae_no = '" & ae_no & "' " & _
    '                "and acc_no in (select acc_no from view_comm_adjusted_s where txmonth = '200810') "
    '    Return GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
    'End Function

    Protected Friend Function lFncImportAcc(ByVal acc_no As String, ByVal ae_no As String, ByVal txmonth As String, ByVal TType As String, ByVal MyTrans As SqlTransaction) As Boolean
        Dim lstrSQL As String = "delete from draft_comm_rate_s where comm_month = '" & txmonth & "' and acc_no = '" & acc_no & "'"
        Dim resultCount As Integer = 0
        Dim logstr As String = ""
        resultCount = GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        If resultCount > 0 Then
            GFncFillLog(GStrloginID, "D", GDteTradeDate, "CopyCommRate", "", acc_no, 0, txmonth, logstr, MyTrans)
        End If
        lstrSQL = "insert into draft_comm_rate_s (acc_no, acc_group, man_no, man_group, ae_no, rate_type, turnover_from, " & _
            "comm_rate, comm_month, comm_type, turnover_type, brokerage_rate) select acc_no, '', '', '', ae_no, rate_type, " & _
            "turnover_from, 0, txmonth, comm_type, null, brokerage_rate from view_comm_afe_rate_s where acc_no = '" & acc_no & _
            "' and rate_type = '" & TType & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select acc_no, ae_no, rate_type, turnover_from, 0, txmonth, comm_type, " & _
            "brokerage_rate from view_comm_afe_rate_s where acc_no = '" & acc_no & "' and rate_type = '" & TType & "' ", MyTrans).Tables(0)
        For Each dr As DataRow In dt.Rows
            logstr = GfncOneFieldLog("Account Group", "") & " " & GfncOneFieldLog("Manager No.", "") & " " & _
                GfncOneFieldLog("Manager Group", "") & " " & GfncOneFieldLog("Account Group", "") & " " & _
                GfncOneFieldLog("Rate Type", TType) & " " & GfncOneFieldLog("Turnover from", GFncNoNullValue(dr("turnover_from"))) & " " & _
                GfncOneFieldLog("Commission Rate", 0) & " " & GfncOneFieldLog("Commission Type", GFncNoNullString(dr("comm_type")).Trim) & _
                " " & GfncOneFieldLog("Turnover Type", "") & " " & GfncOneFieldLog("Brokerage Rate", GFncNoNullValue(dr("brokerage_rate")))
            GFncFillLog(GStrloginID, "A", GDteTradeDate, "CopyCommRate", GFncNoNullString(dr("ae_no")).Trim, acc_no, 0, txmonth, logstr, MyTrans)
        Next
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFncLoadDTG(ByVal txmonth As String, ByVal acc_no As String, ByVal ae_no As String, ByVal Type As String) As DataSet
        Dim lstrSQL As String = "select txmonth, accno, aeno, fee_nature_name, fee_name, rate from draft_comm_afe_rate_s " & _
            "where txmonth ='" & txmonth & "' "
        ' "and exists (select * from view_comm_adjusted_s where  txmonth ='" & txmonth & "' ) "
        If acc_no.Length > 0 Then
            lstrSQL += " and accno ='" & acc_no & "' "
        End If
        'If ae_no.Length > 0 Then
        lstrSQL += " and aeno ='" & ae_no & "' "
        'End If
        If Type <> "" Then
            Select Case Type
                Case "NOR"
                    lstrSQL += " and fee_nature_name ='A/E Rebate'"
                Case "INT"
                    lstrSQL += " and fee_nature_name ='A/E Rebate (i)'"
            End Select
        End If
        lstrSQL += " order by accno asc, fee_nature_name asc "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "afe_rate_s")
    End Function

    Protected Friend Function lFncLoadImportDTG(ByVal txmonth As String, ByVal acc_no As String, ByVal ae_no As String, ByVal Type As String) As DataSet
        Dim lstrSQL As String = " select a.txmonth, a.accno, a.aeno, a.fee_nature_name, a.fee_name, a.rate from " & _
            "draft_comm_afe_rate_s a inner join (select distinct acc_no, case rate_type when 'INT' then 'A/E Rebate (i)' else " & _
            "'A/E Rebate' end rate_type from view_comm_afe_rate_s where txmonth ='" & txmonth & "' and ae_no='" & ae_no & "') c " & _
            "on a.accno=c.acc_no and a.fee_nature_name = c.rate_type inner join (select distinct acc_no, case tradetype " & _
            "when 4 then 'A/E Rebate (i)' else 'A/E Rebate' end rate_type from view_comm_adjusted_s f where f.txmonth ='" & _
            txmonth & "' and f.ae_no ='" & ae_no & "') b on c.acc_no=b.acc_no and c.rate_type = b.rate_type " & _
            "where a.txmonth ='" & txmonth & "' and a.aeno ='" & ae_no & "' "
        '"select a.txmonth, a.accno, a.aeno, a.fee_nature_name, a.fee_name, a.rate from comm_afe_rate_s a " & _
        '   "where a.txmonth ='" & txmonth & "' and a.aeno ='" & ae_no & "' " & _
        '   "and exists (select * from view_comm_afe_rate_s c " & _
        '   "where txmonth ='" & txmonth & "' and ae_no='" & ae_no & "' and a.accno=c.acc_no )"
        If acc_no.Length > 0 Then
            lstrSQL += " and a.accno ='" & acc_no & "' "
        End If
        'If ae_no.Length > 0 Then
        ' lstrSQL += " and aeno ='" & ae_no & "' "
        'End If
        If Type <> "" Then
            Select Case Type
                Case "NOR"
                    lstrSQL += " and a.fee_nature_name ='A/E Rebate' "
                Case "INT"
                    lstrSQL += " and a.fee_nature_name ='A/E Rebate (i)' "
            End Select
        End If
        lstrSQL += " order by a.accno asc, a.fee_nature_name asc "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "afe_rate_s")
    End Function

    Protected Friend Function lFncLoadAEDTG(ByVal txmonth As String, ByVal acc_no As String, ByVal ae_no As String, ByVal Type As String) As DataSet
        'Dim lstrSQL As String = "select distinct a.aeno as ae_no, b.ae_name_s from comm_afe_rate_s a left outer join comm_ae_master b on a.aeno=b.ae_no " & _
        '                                             "where txmonth ='" & txmonth & "' and exists (select * from view_comm_adjusted_s where  txmonth ='" & txmonth & "' ) "
        Dim lstrSQL As String = "select distinct a.aeno as ae_no, b.ae_name_s  from draft_comm_afe_rate_s a inner join " & _
            "draft_comm_ae_master b on a.aeno=b.ae_no where a.txmonth ='" & txmonth & "' "
        If acc_no.Length > 0 Then
            lstrSQL += " and accno ='" & acc_no & "' "
        End If
        If ae_no.Length > 0 Then
            lstrSQL += " and aeno ='" & ae_no & "' "
        End If
        If Type <> "" Then
            Select Case Type
                Case "NOR"
                    lstrSQL += " and fee_nature_name ='A/E Rebate'"
                Case "INT"
                    lstrSQL += " and fee_nature_name ='A/E Rebate (i)'"
            End Select
        End If
        lstrSQL += " order by aeno asc "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "ae")
    End Function

    Protected Friend Function lFncImportAccToMaster(ByVal acc_no As String, ByVal ae_no As String, ByVal txmonth As String, ByVal TType As String, ByVal MyTrans As SqlTransaction) As Boolean
        Dim lstrSQL As String = "Select * from draft_comm_acc_master_d where txmonth = '" & txmonth & "' and acc_no = '" & acc_no & "' "
        If GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Dim logstr As String = ""
            lstrSQL = "Insert into draft_comm_acc_master_d (acc_no, txmonth, isconsolid, minNorAmt, minNorRate, minIntAmt, " & _
                "minIntRate, ae_no_f, ae_no_s, isdefault_f, isdefault_s, acc_group_f, acc_group_s) Values ('" & acc_no & "', '" & _
                txmonth & "', 0, 0, 0, 0, 0, '', '" & ae_no & "', 0, 0, '', '')"
            logstr = GfncOneFieldLog("Consolid", "No") & " " & GfncOneFieldLog("Min Nor. Amt.", 0) & " " & _
                GfncOneFieldLog("Min Nor. Rate", 0) & " " & GfncOneFieldLog("Min Int. Amt.", 0) & " " & _
                GfncOneFieldLog("Min Int. Rate", 0) & " " & GfncOneFieldLog("AE No. Futures", "") & " " & _
                GfncOneFieldLog("AE No. Securities", ae_no) & " " & GfncOneFieldLog("Default Futures", "No") & " " & _
                GfncOneFieldLog("Default Securities", "No") & " " & GfncOneFieldLog("Account Group Futures", "") & " " & _
                GfncOneFieldLog("Account Group Securities", "")
            GFncFillLog(GStrloginID, "A", GDteTradeDate, "CopyCommRate", ae_no, acc_no, 0, txmonth, logstr, MyTrans)
            Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        End If
    End Function

    Protected Friend Function lFncGetAeImportList(ByVal txmonth As String, ByVal acc_no As String, ByVal ae_no As String, ByVal Type As String) As DataSet
        Dim lstrsql As String = ""
        Dim condition As String = ""
        If acc_no.Length > 0 Then
            lstrsql += " and acc_no ='" & acc_no & "' "
            condition += " and acc_no ='" & acc_no & "' "
        End If
        If ae_no.Length > 0 Then
            lstrsql += " and ae_no ='" & ae_no & "' "
            condition += " and ae_no ='" & ae_no & "' "
        End If
        If Type <> "" Then
            Select Case Type
                Case "NOR"
                    lstrsql += " and rate_type ='NOR' "
                    condition += " and tradetype =0 "
                Case "INT"
                    lstrsql += " and rate_type ='INT' "
                    condition += " and tradetype =4 "
            End Select
        End If
        lstrsql = "Select distinct z.ae_no as ae_no, y.ae_name_s from (select a.ae_no from (select ae_no from " & _
            "view_comm_afe_rate_s where txmonth ='" & txmonth & "' " & lstrsql & ") a inner join " & _
            "(select ae_no from view_comm_adjusted_s f where txmonth ='" & txmonth & "' " & condition & ") b " & _
            "on a.ae_no=b.ae_no ) z inner join draft_comm_ae_master y on z.ae_no= y.ae_no order by z.ae_no "
        Return GFncRtnDS(GSCnSqlConn, lstrsql, "ae")
    End Function

End Class
