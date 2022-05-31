Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptMarginCall
    Dim clsRpt As New ClsReports
    Protected Friend Function lFncGetRunner() As DataSet
        Dim lstrSQL As String

        lstrSQL = "Select * from staemaster order by run_code "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL)

    End Function

    Protected Friend Function lFncPrepareMC(ByVal lstrQuery As String, ByVal lstrSort As String, ByVal MC As String) As DataTable
        Dim ldtsTemp As DataSet
        Dim lstrCrit As String = ""
        Dim lstrSQL As String = ""

        'lstrSQL = "SELECT  *,case when liq.liq_day is null then 0 else liq.liq_day end liq_day, " & _
        '        " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
        '        " run_name, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
        '        " '' as Due_Undue, '' as Risk " & _
        '        " FROM stcltmaster mst inner JOIN  stcltliq liq ON  mst.clt_code = liq.clt_code " & _
        '        " and liq.liq_day > 0 " & _
        '        " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "
        lstrSQL = "SELECT  mst.*,case when liq.liq_day is null then 0 else liq.liq_day end liq_day, " & _
                " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
                " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
                " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
                " run_name, Branch_Name, OverTrade_Group, OverTrade_Limit, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
                " '' as Due_Undue, '' as Risk " & _
                " FROM stcltmaster mst inner JOIN  stcltliq liq ON  mst.clt_code = liq.clt_code " & _
                " and liq.liq_day > 0 " & _
                " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "
        lstrSQL += lstrQuery & " order by " & lstrSort
        'lstrSQL += " ORDER BY mst.mc_total desc, mst.run_code, mst.clt_type DESC, mst.mc_act_ratio desc, mst.clt_code "


        ldtsTemp = GFncRtnDS(GSCnLiqConn, lstrSQL)

        lstrSQL = " select * from STPortfolio " & _
                " where clt_code in (select mst.clt_code from stcltmaster mst " & _
                " inner JOIN  stcltliq liq ON  mst.clt_code = liq.clt_code " & _
                " and liq.liq_day > 0 " & lstrQuery & ")  "
        Dim ldtTop As DataTable = GFncRtnDS(GSCnLiqConn, lstrSQL).Tables(0)
        For Each ldtwTemp As DataRow In ldtsTemp.Tables(0).Rows
            ldtwTemp.Item("top1_stock_code") = ""
            ldtwTemp.Item("top2_stock_code") = ""
            ldtwTemp.Item("top3_stock_code") = ""
            ldtwTemp.Item("top1_market_value") = 0
            ldtwTemp.Item("top2_market_value") = 0
            ldtwTemp.Item("top3_market_value") = 0
            'ldtwTemp.Item("margin_call_amount") = IIf(ldtwTemp.Item("cr_limit") > 1, _
            '        (IIf(ldtwTemp.Item("mc_due") > _
            '        (IIf(ldtwTemp.Item("dr_bal") - ldtwTemp.Item("cr_limit") < 0, 0, ldtwTemp.Item("dr_bal") - ldtwTemp.Item("cr_limit"))), _
            '        ldtwTemp.Item("mc_due"), _
            '        (IIf(ldtwTemp.Item("dr_bal") - ldtwTemp.Item("cr_limit") < 0, 0, ldtwTemp.Item("dr_bal") - ldtwTemp.Item("cr_limit"))))), _
            '        ldtwTemp.Item("mc_due"))
            Dim tmp_bal As Decimal
            If (ldtwTemp.Item("mc_dr_bal") - ldtwTemp.Item("cr_limit") < 0) Then
                tmp_bal = 0
            Else
                tmp_bal = ldtwTemp.Item("mc_dr_bal") - ldtwTemp.Item("cr_limit")
            End If

            If (ldtwTemp.Item("cr_limit") > 1) Then
                If (ldtwTemp.Item("mc_due") > tmp_bal) Then
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due")
                Else
                    ldtwTemp.Item("margin_call_amount") = tmp_bal
                End If
            Else
                If ldtwTemp.Item("MC_T2") < 0 Then
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due") + ldtwTemp.Item("MC_T2")
                Else
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due")
                End If
            End If


            Dim ldtaTop As DataRow()
            ldtaTop = ldtTop.Select(" clt_code = '" & ldtwTemp.Item("clt_code") & "'", " net_market_value desc ")
            For lintCnt As Integer = 0 To ldtaTop.Length - 1
                Select Case lintCnt
                    Case 0
                        ldtwTemp.Item("top1_stock_code") = ldtaTop(0).Item("stk_code")
                        ldtwTemp.Item("top1_market_value") = GFncNoNullValue(ldtaTop(0).Item("net_market_value"))
                    Case 1
                        ldtwTemp.Item("top2_stock_code") = ldtaTop(1).Item("stk_code")
                        ldtwTemp.Item("top2_market_value") = GFncNoNullValue(ldtaTop(1).Item("net_market_value"))
                    Case 2
                        ldtwTemp.Item("top3_stock_code") = ldtaTop(2).Item("stk_code")
                        ldtwTemp.Item("top3_market_value") = GFncNoNullValue(ldtaTop(2).Item("net_market_value"))
                    Case Else
                        Exit For
                End Select
            Next
            ldtwTemp.Item("Due_Undue") = lFncDue(ldtwTemp.Item("mc_due"), ldtwTemp.Item("mc_t2"))
            ldtwTemp.Item("Risk") = lFncRickFactor(ldtwTemp.Item("MC_ACT_RATIO"), ldtwTemp.Item("Due_Undue"), ldtwTemp.Item("dr_bal"))
        Next

        Dim ldt As DataTable = ldtsTemp.Tables(0).Copy
        ldt.Clear()
        Dim Sort As String
        If MC.Length > 0 Then
            Sort = MC
        Else
            Sort = "1=1"
        End If
        Dim ldtaDD As DataRow() = ldtsTemp.Tables(0).Select(Sort, lstrSort)
        For lintCnt As Integer = 0 To ldtaDD.Length - 1
            ldt.ImportRow(ldtaDD(lintCnt))
        Next

        Return ldt

    End Function

    Protected Friend Function lFncPrintMarginCall(ByVal strQuery As String, ByVal strSort As String, _
    ByVal strTitle As String, ByVal MC As String) As ReportClass
        Dim rpt As New RptMarginCall
        Dim ldtsTemp As DataTable = Me.lFncPrepareMC(strQuery, strSort, MC)

        If ldtsTemp.Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp)
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle", strTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Margin Call Report")
        End If

    End Function

    Protected Friend Function lFncRickFactor(ByVal AR As Double, ByVal Due As String, ByVal Deb_Bal As Double) As Integer
        If AR <= 0.5 Or Due = "Undue" Then
            Return 0
        End If
        If (AR > 0.5 And AR <= 0.6) Then
            Return 1
        End If
        If (AR > 0.6 And AR <= 0.7) Then
            Return 2
        End If
        If (AR > 0.7 And AR <= 0.8) Then
            Return 3
        End If
        If (AR > 0.8 And AR <= 1) Or (AR = 999.99 And Deb_Bal <= 150000) Then
            Return 4
        End If
        If (AR > 1) Or (AR = 999.99 And Deb_Bal > 150000) Then
            Return 5
        End If
    End Function

    Protected Friend Function lFncDue(ByVal McDue As Double, ByVal Undue As Double) As String
        If McDue <= 0 And Undue > 0 Then
            Return "Undue"
        ElseIf McDue > 0 Then
            Return "Due"
        Else
            Return ""
        End If
    End Function

    Protected Friend Function getAR() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'MrgCallRpt' and misc_code = 'mrg_call_ar'"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
    End Function

    Protected Friend Function getMR() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'MrgCallRpt' and misc_code = 'mrg_call_mr'"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
    End Function

    Protected Friend Function getAndOr() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'MrgCallRpt' and misc_code = 'mrg_call_AndOr'"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
    End Function

    Protected Friend Function setCriteria(ByVal newAR As String, ByVal newAndOr As String, ByVal newMR As String) As Boolean
        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            lstrSQL = "Update misc_master set misc_desc = '" & newAR & _
                        "' where misc_type = 'MrgCallRpt' and misc_code = 'mrg_call_ar'"
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & newAndOr & _
                        "' where misc_type = 'MrgCallRpt' and misc_code = 'mrg_call_AndOr'"
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & newMR & _
                        "' where misc_type = 'MrgCallRpt' and misc_code = 'mrg_call_mr'"
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            MyTrans.Commit()
            MyTrans = Nothing
            Return True
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

End Class
