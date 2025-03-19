Imports CrystalDecisions.CrystalReports.Engine

Public Class clsRptAEDetail
    Dim clsRpt As New ClsReports
    Dim DtsAEDetail As New DtsAEDetail

    Protected Friend Function PrintAEDetailICBC(ByVal fromAE As ComboBox, ByVal toAE As ComboBox) As ReportClass
        Dim rpt As New rptAEDetail_ICBC
        Dim condition As String = "AE Detail ICBC Report ("
        Dim strSQL As String = ""

        If fromAE.Text <> "" Then
            condition &= "AE no >= " & fromAE.Text.Trim
        End If

        If toAE.Text <> "" Then
            condition &= ", AE no <= " & toAE.Text.Trim
        End If

        condition &= ") "
        rpt.SetDataSource(genRptICBC(fromAE, toAE))

        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "paraTitle", condition)

        Return rpt

    End Function

    Protected Friend Function PrintAEDetailRpt(ByVal fromAE As ComboBox, ByVal toAE As ComboBox, _
    ByVal tradeType As String, ByVal tradeDate As String, ByVal strBranch As String) As ReportClass
        Dim rpt As New rptAEDetail
        Dim condition As String = "AE Detail Report ("
        Dim maxTxMonth As String = tradeDate
        Dim strSQL As String = ""

        If tradeDate = "" Or tradeDate.Length <> 6 Then
            strSQL = "select max(txmonth) as maxTxMonth from comm_ae_comm "
            Dim tempDt As DataTable = GFncRtnDS(GSCnSqlConn, strSQL, 0).Tables(0)
            If tempDt.Rows.Count > 0 Then
                maxTxMonth = GFncNoNullString(tempDt.Rows(0).Item("maxTxMonth"))
            End If
        End If

        If fromAE.Text <> "" Then
            condition &= "AE no >= " & fromAE.Text.Trim
        End If

        If toAE.Text <> "" Then
            condition &= ", AE no <= " & toAE.Text.Trim
        End If
        If strBranch <> "" Then
            condition &= "   Branch = " & strBranch
        End If
        condition &= ") "
        rpt.SetDataSource(genRptComm(fromAE, toAE, tradeType, maxTxMonth, strBranch))

        clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "paraTitle", condition)
        Return rpt

    End Function

    Protected Friend Function genRptICBC(ByVal fromAE As ComboBox, ByVal toAE As ComboBox) As DataTable
        Dim strSQL As String = ""
        Dim ldtsICBC As DataSet
        Dim resultDt As New DtsAEDetail.AEDetail_ICBCDataTable

        strSQL = "select a.accno, aeno, a.name_1, a.date_open, b.lastday, c.currency_code, c.sub_account, " & _
                    "a.addr_1, a.addr_2,a.addr_3,a.addr_4, " & _
                    "a.nd_addr_1, a.nd_addr_2,a.nd_addr_3,a.nd_addr_4, " & _
                    "a.mail_status, a.email " & _
                    "from " & GStrG2BSDB & ".dbo.view_IT_client_all a " & _
                    "left outer join ICBC.dbo.client_detail c " & _
                    "on a.accno = c.client_id  collate database_default " & _
                    "and c.company_id like '%ESL%' " & _
                    "and c.status <> 'DS' " & _
                    "left outer join " & GStrG2BSDB & ".dbo.view_IT_client_last_trade_day b " & _
                    "on b.client_code = a.accno " & _
                    "where 1=1 "

        If fromAE.Text <> "" Then
            strSQL &= "and aeno >= '" & fromAE.Text.Trim & "' "
        End If

        If toAE.Text <> "" Then
            strSQL &= "and aeno <= '" & toAE.Text.Trim & "' "
        End If
        strSQL &= "order by a.accno "

        ldtsICBC = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        For Each ldrICBC As DataRow In ldtsICBC.Tables(0).Rows
            Dim ldr As DataRow = resultDt.NewRow
            ldr("accno") = ldrICBC("accno")
            ldr("name_1") = ldrICBC("name_1")

            If DBNull.Equals(ldrICBC("date_open"), DBNull.Value) Then
                ldr("date_open") = ""
            Else
                ldr("date_open") = Format(ldrICBC("date_open"), "dd-MMM-yyyy")
            End If

            If DBNull.Equals(ldrICBC("lastday"), DBNull.Value) Then
                ldr("lastday") = ""
            Else
                ldr("lastday") = Format(ldrICBC("lastday"), "dd-MMM-yyyy")
            End If

            ldr("sub_account") = ldrICBC("sub_account")

            ldr("addr") = ldrICBC("addr_1").ToString.Trim
            If ldrICBC("addr_2").ToString.Trim <> "" Then
                ldr("addr") = ldr("addr").ToString.Trim + ", " + ldrICBC("addr_2").ToString.Trim
            End If
            If ldrICBC("addr_3").ToString.Trim <> "" Then
                ldr("addr") = ldr("addr").ToString.Trim + ", " + ldrICBC("addr_3").ToString.Trim
            End If
            If ldrICBC("addr_4").ToString.Trim <> "" Then
                ldr("addr") = ldr("addr").ToString.Trim + ", " + ldrICBC("addr_4").ToString.Trim
            End If

            ldr("nd_addr") = ldrICBC("nd_addr_1").ToString.Trim
            If ldrICBC("nd_addr_2").ToString.Trim <> "" Then
                ldr("nd_addr") = ldr("nd_addr").ToString.Trim + ", " + ldrICBC("nd_addr_2").ToString.Trim
            End If
            If ldrICBC("nd_addr_3").ToString.Trim <> "" Then
                ldr("nd_addr") = ldr("nd_addr").ToString.Trim + ", " + ldrICBC("nd_addr_3").ToString.Trim
            End If
            If ldrICBC("nd_addr_4").ToString.Trim <> "" Then
                ldr("nd_addr") = ldr("nd_addr").ToString.Trim + ", " + ldrICBC("nd_addr_4").ToString.Trim
            End If

            ldr("mail_status") = ldrICBC("mail_status")
            ldr("email") = ldrICBC("email")
            resultDt.Rows.Add(ldr)
        Next

        Return resultDt

    End Function

    Protected Friend Function genRptComm(ByVal fromAE As ComboBox, ByVal toAE As ComboBox, _
    ByVal tradeType As String, ByVal maxTxMonth As String, _
    ByVal strBranch As String) As DataTable
        Dim strSQL As String = ""


        Dim txTime1 As Date = New Date
        Dim txTime2 As Date = New Date
        If maxTxMonth.Length = 6 Then
            Dim yearString As String = maxTxMonth.Substring(0, 4)
            Dim monthString As String = maxTxMonth.Substring(4, 2)

            Dim year As Integer = CInt(yearString)
            Dim month As Integer = CInt(monthString)

            txTime1 = New Date(year, month, 1)
        Else
            Return Nothing
        End If

        txTime2 = txTime1.AddMonths(-6)

        Dim txMonth1 As String = Format(txTime1, "yyyyMM")
        Dim txMonth2 As String = Format(txTime2, "yyyyMM")

        Dim resultDt As New DtsAEDetail.AEDetailDataTable

        strSQL = "select a.run_code, a.clt_code, a.clt_name, a.lastTradeDate as Last_Trade_date, date_open, " & _
                " b.brokerage_i as Commission_rate_itrade,  b.brokerage_p as Commission_rate_normal, b.barnch_name  " & _
              "from " & GSCnLiqConn.Database.Trim & "..stcltmaster a left outer join " & GStrG2BSDB & ".dbo.view_it_client_all b " & _
        "on a.clt_code = b.accno where a.clt_code is not null "

        If fromAE.Text <> "" Then
            strSQL &= "and a.run_code >='" & fromAE.Text.Trim & "' "
        End If

        If toAE.Text <> "" Then
            strSQL &= "and a.run_code <='" & toAE.Text.Trim & "' "
        End If

        strSQL &= "order by a.run_code, a.clt_code "

        Dim ldtsAC As DataSet = GFncRtnDS(GSCnSqlConn, strSQL, 0)
        For Each ldrAC As DataRow In ldtsAC.Tables(0).Rows
            If strBranch.Trim = "" Or strBranch = GFncNoNullString(ldrAC("barnch_name")).Trim Then
                Dim ldr As DataRow = resultDt.NewRow
                ldr("run_code") = ldrAC("run_code")
                ldr("clt_code") = ldrAC("clt_code")
                ldr("clt_name") = ldrAC("clt_name")
                ldr("Last_Trade_date") = ldrAC("Last_Trade_date")
                ldr("open_date") = ldrAC("date_open")
                ldr("Commission_rate_normal") = ldrAC("Commission_rate_normal")
                ldr("Commission_rate_itrade") = ldrAC("Commission_rate_itrade")
                ldr("barnch_name") = ldrAC("barnch_name")

                For lintCnt As Integer = 1 To 6
                    ldr("month_" & lintCnt.ToString) = ""
                    ldr("commission_" & lintCnt.ToString) = 0
                    ldr("turnover_normal_" & lintCnt.ToString) = 0
                    ldr("turnover_all_" & lintCnt.ToString) = 0
                    ldr("Turnover_itrade_" & lintCnt.ToString) = 0
                    ldr("rebate_amount_" & lintCnt.ToString) = 0
                Next
                resultDt.Rows.Add(ldr)
            End If
        Next

        Dim ldtsComm As DataSet

        strSQL = "Select txmonth, ae_no , comm_s, comm_o, comm_adj_s, comm_paid_s, override_comm, " & _
            " incentive_comm, bonus_comm from comm_ae_comm " & _
            "where txmonth in  ('" & txMonth1 & "' "
        For lintCnt As Integer = 1 To 5
            strSQL &= ",'" & Format(txTime1.AddMonths(lintCnt * (-1)), "yyyyMM") & "' "
        Next
        strSQL &= " ) "
        If fromAE.Text <> "" Then
            strSQL &= "and ae_no >='" & fromAE.Text.Trim & "' "
        End If

        If toAE.Text <> "" Then
            strSQL &= "and ae_no <='" & toAE.Text.Trim & "' "
        End If
        ldtsComm = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Dim ldtsTrade As DataSet
        strSQL = "SELECT txmonth, accno, tradetype, sum(grossamt) as turnover, sum(commission) as commission " & _
                " FROM view_comm_trade_s where txmonth in ( '" & txMonth1 & "' "
        For lintCnt As Integer = 1 To 5
            strSQL &= ",'" & Format(txTime1.AddMonths(lintCnt * (-1)), "yyyyMM") & "' "
        Next
        strSQL &= " ) "
        If fromAE.Text <> "" Then
            strSQL &= "and aeno >='" & fromAE.Text.Trim & "' "
        End If

        If toAE.Text <> "" Then
            strSQL &= "and aeno <='" & toAE.Text.Trim & "' "
        End If
        strSQL &= " group by txmonth , accno, tradetype "
        ldtsTrade = GFncRtnDS(GSCnSqlConn, strSQL, 0)


        For Each dtr As DataRow In resultDt.Rows

            Dim aeNo As String = GFncNoNullString(dtr("run_code"))
            Dim accNo As String = GFncNoNullString(dtr("clt_code"))


            For i As Integer = 1 To 6
                Dim txTimeX As Date = txTime1.AddMonths((i - 1) * (-1))
                Dim txMonthX As String = Format(txTimeX, "yyyyMM")
                Dim ldrTrade() As DataRow = ldtsTrade.Tables(0).Select("  accno = '" & accNo.Trim & "' and txmonth = '" & txMonthX & "'")


                Dim ldrComm() As DataRow = ldtsComm.Tables(0).Select(" ae_no = '" & aeNo & "' and txmonth = '" & txMonthX & "'")
                If ldrComm.Length > 0 Then
                    dtr("rebate_amount_" & i.ToString) = GFncNoNullValue(ldrComm(0).Item("comm_s")) + _
                                            GFncNoNullValue(ldrComm(0).Item("comm_o")) + _
                                            GFncNoNullValue(ldrComm(0).Item("comm_adj_s")) + _
                                            GFncNoNullValue(ldrComm(0).Item("comm_paid_s")) + _
                                            GFncNoNullValue(ldrComm(0).Item("override_comm")) + _
                                            GFncNoNullValue(ldrComm(0).Item("incentive_comm")) + _
                                            GFncNoNullValue(ldrComm(0).Item("bonus_comm"))
                End If
                dtr("month_" & i.ToString) = txMonthX
                dtr("commission_" & i.ToString) = 0
                dtr("turnover_normal_" & i.ToString) = 0
                dtr("turnover_all_" & i.ToString) = 0
                dtr("Turnover_itrade_" & i.ToString) = 0

                If ldrTrade.Length > 0 Then

                    For lintCnt As Integer = 0 To ldrTrade.Length - 1
                        Select Case GFncNoNullString(ldrTrade(lintCnt).Item("tradetype"))
                            Case "0"
                                dtr("turnover_normal_" & i.ToString) = GFncNoNullValue(ldrTrade(lintCnt).Item("turnover"))
                            Case "4"
                                dtr("Turnover_itrade_" & i.ToString) = GFncNoNullValue(ldrTrade(lintCnt).Item("turnover"))
                        End Select
                        dtr("commission_" & i.ToString) += GFncNoNullValue(ldrTrade(lintCnt).Item("commission"))
                    Next
                    dtr("turnover_all_" & i.ToString) = dtr("turnover_normal_" & i.ToString) + dtr("Turnover_itrade_" & i.ToString)
                End If
            Next
        Next

        Return resultDt

    End Function

End Class
