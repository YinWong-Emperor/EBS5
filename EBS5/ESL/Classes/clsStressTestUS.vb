Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class clsStressTestUS

    Protected Friend Function FncLoadDate() As Date
        Dim str As String = "select DATE from STTXNDATE"
        Dim ds As DataSet
        ds = GFncRtnDS(GSCnLiqConn, str)
        If ds.Tables(0).Select().Length > 0 Then
            Return ds.Tables(0).Rows(0).Item("DATE")
        Else
            Return System.DateTime.Today
        End If
    End Function
    Protected Friend Function FncLoadStress(ByVal txnDate As String) As Boolean
        Dim str As String = "select * from misc_master where misc_code ='" & Format(CDate(txnDate), "dd/MM/yyyy") & "'"
        Dim ds As DataSet
        ds = GFncRtnDS(GSCnSqlConn, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Friend Function FncLoadCombo() As DataSet
        Dim str As String = "select distinct stk_code from STPortfolio_US order by stk_code"
        Return GFncRtnDS(GSCnLiqConn, str)
    End Function
    Protected Friend Function FncLoadDataSet() As DataSet
        Dim str As String = "select b.stk_code, sum(b.net_market_value) as market, sum(b.net_market_value) as market_value, " & _
                            "sum(b.net_qty) as qty from STPortfolio_US b join stcltmaster_US a on b.CLT_CODE = a.clt_code " & _
                            "where a.CLT_TYPE = 'M' group by b.stk_code order by sum(b.net_market_value) DESC"
        Return GFncRtnDS(GSCnLiqConn, str)
    End Function
    Protected Friend Function FncLoadMV() As Double
        Dim str As String = "select sum(b.net_market_value) as market from STPortfolio_US b join stcltmaster_US a on b.CLT_CODE = a.clt_code " & _
                                   "where a.CLT_TYPE = 'M'"
        Return GFncRtnDS(GSCnLiqConn, str).Tables(0).Rows(0).Item("market")
    End Function
    Protected Friend Function FncAddRecords(ByVal data As String, ByVal txnDate As String, ByVal MyTrans As SqlTransaction)
        Dim str2 As String = "insert into misc_master (misc_type, misc_code, misc_desc) values ('Stress Test', '" & Format(CDate(txnDate), "dd/MM/yyyy") & "', '" & data & "')"
        'Dim str2 As String = "insert into misc_master (misc_type, misc_code, misc_desc) values ('Stress Test', '" & txnDate & "', '" & data & "')"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str2)
        Catch ex As Exception
            Exit Try
        End Try
        Return Nothing
    End Function
    Protected Friend Function FncClearRecords(ByVal txnDate As Date)
        'Dim str As String = " delete from misc_master where misc_code = '" & Format(CDate(txnDate), "dd/MM/yyyy") & "'"
        Dim str As String = "delete from misc_master where misc_type = 'Stress Test'"
        GFncRunSQL(GSCnSqlConn, str)
        Return Nothing
    End Function
    Protected Friend Function FncLoadExistingDataSet(ByVal txnDate As String) As DataSet
        Dim target As DataSet = New DtsMisc
        'Dim str1 As String = "select distinct b.stk_code,  sum(b.net_market_value) as market, " & _
        '                    "sum(b.net_market_value) as market_value, sum(b.net_qty) as qty, " & _
        '                    "sum(b.net_market_value) as Drop_down, sum(b.net_market_value) as New_price " & _
        '                    "from STPortfolio_US b join stcltmaster_US a on b.CLT_CODE = a.clt_code " & _
        '                    "where a.CLT_TYPE = 'M' and b.net_market_value > 0 group by b.stk_code order by sum(b.net_market_value) DESC"
        Dim str1 As String = "select distinct b.stk_code,  sum(b.net_market_value) as market, " & _
                            "sum(b.net_market_value) as market_value, sum(b.net_qty) as qty, " & _
                            "0.000 as Drop_down, case when sum(b.net_qty) <> 0 then round (sum(b.net_market_value) / sum(b.net_qty), 4) " & _
                            "else 0 end as New_price " & _
                            "from STPortfolio_US b join stcltmaster_US a on b.CLT_CODE = a.clt_code " & _
                            "where a.CLT_TYPE = 'M' group by b.stk_code order by sum(b.net_market_value) DESC"
        target = GFncRtnDS(GSCnLiqConn, str1)
        Dim dr1, dr2 As DataRow
        Dim data, stock, nPrice As String
        Dim str2 As String = "select misc_desc from misc_master where misc_code ='" & Format(CDate(txnDate), "dd/MM/yyyy") & "' order by misc_desc"
        Dim ds As DataSet
        ds = GFncRtnDS(GSCnSqlConn, str2)
        Dim startPoint As Integer
        Dim lth As Integer
        Dim oriPrice As Double
        For Each dr1 In ds.Tables(0).Rows
            startPoint = 0
            data = dr1("misc_desc").ToString
            lth = data.IndexOf(",", startPoint)
            stock = data.Substring(startPoint, lth - startPoint).Trim
            If stock = "03311" Then
                stock = "03311"
            End If
            lth = data.LastIndexOf(",")
            nPrice = data.Substring(lth + 2, data.Length - lth - 2).Trim
            For Each dr2 In target.Tables(0).Rows
                If dr2("stk_code") = stock Then
                    dr2("New_price") = CDbl(nPrice)
                    If CDbl(dr2("qty")) <> 0 Then
                        oriPrice = Math.Round(CDbl(dr2("market_value")) / (CDbl(dr2("qty"))), 3)
                    Else
                        oriPrice = 0
                    End If
                    If oriPrice <> 0 Then
                        dr2("Drop_down") = Math.Round((oriPrice - CDbl(nPrice)) / oriPrice, 3) * 100
                    Else
                        dr2("Drop_down") = 0
                    End If
                    Exit For
                End If
            Next
        Next
        Return target
    End Function
    Protected Friend Function FncLoadSign() As DataSet
        Dim ds As DataSet
        Dim str As String = "select misc_code as title, misc_desc as sign_by, 0 as seq " & _
                            "from misc_master where misc_type like 'STCSIGN%' order by misc_type "
        ds = GFncRtnDS(GSCnSqlConn, str)
        If ds.Tables(0).Rows.Count <> 6 Then
            ds.Clear()
            Dim MyTrans As SqlTransaction = Nothing
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                GFncRunSQL(GSCnSqlConn, MyTrans, "insert into misc_master values ('STCSIGN', 'Prepared By', 'CRC Dept')")
                GFncRunSQL(GSCnSqlConn, MyTrans, "insert into misc_master values ('STCSIGN', 'Noted By', 'Jammy Lui')")
                GFncRunSQL(GSCnSqlConn, MyTrans, "insert into misc_master values ('STCSIGN', 'Noted By', 'Aaron Ho')")
                GFncRunSQL(GSCnSqlConn, MyTrans, "insert into misc_master values ('STCSIGN', 'Noted By', 'Louisa Choi')")
                GFncRunSQL(GSCnSqlConn, MyTrans, "insert into misc_master values ('STCSIGN', 'Noted By', 'Tom Chan')")
                GFncRunSQL(GSCnSqlConn, MyTrans, "insert into misc_master values ('STCSIGN', 'Noted By', 'Daisy Yeung')")
                MyTrans.Commit()
                MyTrans = Nothing
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
            ds = GFncRtnDS(GSCnSqlConn, str)
        End If
        For lintCnt As Integer = 1 To ds.Tables(0).Rows.Count
            ds.Tables(0).Rows(lintCnt - 1).Item("seq") = lintCnt
        Next
        Return ds
    End Function
    Protected Friend Function FncInsertSign(ByVal dgv As DataGridView, ByVal MyTrans As SqlTransaction)
        Dim str As String = "delete from misc_master where misc_type like 'STCSIGN%'"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
        Catch ex As Exception
            Return Nothing
        End Try
        Dim title As String = ""
        Dim sign As String = ""
        For idrow As Integer = 0 To dgv.Rows.Count - 1
            title = dgv.Item("title", idrow).Value.ToString.Trim
            sign = dgv.Item("sign_by", idrow).Value.ToString.Trim
            str = "insert into misc_master values ('STCSIGN', '" & title & "', '" & sign & "')"
            Try
                GFncRunSQL(GSCnSqlConn, MyTrans, str)
            Catch ex As Exception
                Return Nothing
            End Try
        Next
        Return Nothing
    End Function
    Protected Friend Function FncGenRpt(ByVal txnDate As Date, ByVal dt As DataTable, ByVal detail As Boolean, ByVal ds As DataTable, _
    ByVal BLA As Double, ByVal CLC As Double, ByVal kind As Boolean, _
    Optional ByVal decTotalSF As Double = 0, Optional ByVal remark As String = "") As ReportClass
        Dim rpt As ReportClass
        If kind Then
            rpt = New rptStrTestUS
        Else
            rpt = New rptStrTest1US
        End If
        rpt.SetDataSource(dt)
        rpt.Subreports(0).SetDataSource(ds)
        rpt.SetParameterValue("date", txnDate)
        rpt.SetParameterValue("showDetail", detail)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("BLA", BLA)
        rpt.SetParameterValue("CLC", CLC)
        If kind Then
            rpt.SetParameterValue("remark", remark)
            rpt.SetParameterValue("TotalSF", decTotalSF)
        End If
        Return rpt
    End Function
    Protected Friend Function FncGetClient(ByVal FRR As Boolean) As DataTable
        Dim ds As DataSet = Nothing
        Dim str As String = ""
        'Dim str As String = "select a.CLT_CODE as client_code, a.DR_BAL, a.CLT_NAME as name, b.stk_code as Stk_code, " & _
        '                    "round(b.net_qty, 0) as qty, round(b.net_market_value / b.net_qty, 3) as price, b.net_market_value as market_value, 0.00 as new_price, " & _
        '                    "0.00 as short_fall, 0.00 as avalible_balance, 0.00 as drop_down, 0.00 as short from client_liq_master a " & _
        '                    "join STPortfolio_US b on a.CLT_CODE = b.clt_code " & _
        '                    "join stcltmaster_US c on a.CLT_CODE = c.clt_code where b.net_market_value > 0 and c.CLT_TYPE = 'M' order by a.CLT_CODE "
        'Dim str As String = "select a.CLT_CODE as client_code, a.DR_BAL, a.CLT_NAME as name, b.stk_code as Stk_code, " & _
        '                    "round(b.net_qty, 0) as qty, 0.000 as price, b.net_market_value as market_value, 0.000 as new_price, " & _
        '                    "0.00 as short_fall, 0.00 as avalible_balance, 0.00 as drop_down, 0.00 as short from client_liq_master a " & _
        '                    "join STPortfolio_US b on a.CLT_CODE = b.clt_code " & _
        '                    "join stcltmaster_US c on a.CLT_CODE = c.clt_code where b.net_market_value > 0 and c.CLT_TYPE = 'M' order by a.CLT_CODE "
        'If Not FRR Then
        '    str = "select c.CLT_CODE as client_code, c.DR_BAL, c.CLT_NAME as name, b.stk_code as Stk_code, round(b.net_qty, 0) as qty, 0.000 as price, " & _
        '        "b.net_market_value as market_value, 0.000 as new_price, 0.00 as short_fall, 0.00 as avalible_balance, 0.00 as drop_down, 0.00 as short " & _
        '        "from  stcltmaster_US c left join STPortfolio_US b on c.CLT_CODE = b.clt_code where c.CLT_TYPE = 'M' and c.CR_bal <= 0 order by c.CLT_CODE "
        'Else
        str = "select c.CLT_CODE as client_code, c.DR_BAL-c.interest as DR_BAL, c.CLT_NAME as name, b.stk_code as Stk_code, round(b.net_qty, 0) as qty, " & _
            "0.000 as price, b.net_market_value as market_value, 0.000 as new_price, 0.00 as short_fall, 0.00 as avalible_balance, 0.00 as drop_down, " & _
            "0.00 as short from  stcltmaster_US c left join (select * from STPortfolio_US where stk_code not in (select distinct stkno from STSUSPENDSTOCK)) b " & _
            "on c.CLT_CODE = b.clt_code where c.CLT_TYPE = 'M' and (c.DR_bal > 0 or c.cr_bal + c.interest < 0) order by c.CLT_CODE "
        'End If
        ds = GFncRtnDS(GSCnLiqConn, str)
        Return ds.Tables(0)
    End Function
    Protected Friend Function FncGetStock() As DataTable
        Dim str As String = "select distinct b.Stk_code, 0.00 as price, 0.00 as new_price from STPortfolio_US b " & _
                            "inner join stcltmaster_US a on b.CLT_CODE = a.clt_code " & _
                            "where a.CLT_TYPE = 'M' order by b.Stk_code"
        Return GFncRtnDS(GSCnLiqConn, str).Tables(0)
    End Function

    Protected Friend Function FncGetHaircut(Optional ByVal region As String = "") As DataTable
        Dim IDSTR As String = "select @@SPID "
        Dim IDDT As DataTable = GFncRtnDS(GSCnSqlConn, IDSTR).Tables(0)

        Dim str As String = ""

        'Dim str As String = "select distinct b.stkno as Stk_code,  1- round(a.haircut / a.market_value , 2) as haircut " & _
        '                    "from " & GStrG2BSDB & ".dbo.view_rpt_Approved_stk_assets_part1 a " & _
        '                    "join " & GStrG2BSDB & ".dbo.stock_master b on a.sid = b.sid " & _
        '                    "where 1=1 and a.market_value > 0 and session_id = @@SPID "

        'str = "select stkno as Stk_code, hair_cut as haircut " & _
        '        "from " & GStrG2BSDB & ".dbo.hs100_hd hd " & _
        '        "inner join " & GStrG2BSDB & ".dbo.stock_master AS sm" & _
        '        " on sm.sid = hd.sid " & _
        '        " where 1=1 "

        str = "select stkno as Stk_code,  (sg.haircut_rate) / 100 as haircut" & _
                       " from " & GStrG2BSDB & ".dbo.stock_grade AS sg INNER join " & _
                       GStrG2BSDB & ".dbo.hs100_hd AS hd ON sg.gdid = hd.gdid INNER JOIN " & _
                       GStrG2BSDB & ".dbo.stock_master AS sm ON hd.sid = sm.sid  " & _
                       " where 1=1 "

        'Dim str As String = "select stkno as Stk_code, round(haircut_rate / 100, 2) as haircut from " & GStrG2BSDB & _
        '    ".dbo.stock_master a left outer join " & GStrG2BSDB & ".dbo.stock_grade b on a.gdid= b.gdid" ' where stkno not like '%-%'"

        Dim dsTemp As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        'str = "select stkno as Stk_code,  (100 - sg.haircut_rate) / 100 as haircut" & _
        '           " from " & GStrG2BSDB & ".dbo.stock_grade AS sg INNER join " & _
        '           GStrG2BSDB & ".dbo.stock_type AS st ON sg.gdid = st.gdid INNER JOIN " & _
        '           GStrG2BSDB & ".dbo.stock_master AS sm ON st.type = sm.type" & _
        '           " where 1=1 "

        str = "select stkno as Stk_code,  (sg.haircut_rate) / 100 as haircut" & _
                 " from " & GStrG2BSDB & ".dbo.stock_grade AS sg INNER join " & _
                 GStrG2BSDB & ".dbo.stock_type AS st ON sg.gdid = st.gdid INNER JOIN " & _
                 GStrG2BSDB & ".dbo.stock_master AS sm ON st.type = sm.type" & _
                 " where 1=1 "

        If region <> "" Then
            'str = str & " and b.stkno in " & region
            str = str & " and stkno in " & region
        End If
        'str = str & " order by b.stkno"
        str = str & " order by stkno"

        Dim dsResult As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        For Each dtTemp As DataRow In dsTemp.Rows
            For Each dtResult As DataRow In dsResult.Rows
                If dtResult.Item("Stk_code") = dtTemp.Item("Stk_code") Then
                    dtResult.Item("haircut") = dtTemp.Item("haircut")
                End If
            Next
        Next

        str = "select distinct stkno as Stk_code " & _
            " from " & GStrG2BSDB & ".dbo.eFRR_illquid_stock  " & _
            " where p_month = '" & Format(GDteTradeDate, "yyyyMM") & _
            "' and (n_mkt_cap = 1 or n_a_month_turn = 1) "
        Dim dsLiqStk As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        For Each dtResult As DataRow In dsResult.Rows
            dtResult.Item("Stk_code") = dtResult.Item("Stk_code").ToString.Trim
            If dsLiqStk.Rows.Count > 0 Then
                Dim dtLiqStk() As DataRow = dsLiqStk.Select(" stk_code = '" & dtResult.Item("Stk_code") & "' ")
                If dtLiqStk.Length > 0 Then
                    dtResult.Item("haircut") = 0.8
                End If
            End If
            'If dtResult.Item("Stk_code").ToString.Trim = "00163" Or _
            '    dtResult.Item("Stk_code").ToString.Trim = "00708" Or _
            '    dtResult.Item("Stk_code").ToString.Trim = "00717" Or _
            '    dtResult.Item("Stk_code").ToString.Trim = "03886" Or _
            '    dtResult.Item("Stk_code").ToString.Trim = "00559" Or _
            '    dtResult.Item("Stk_code").ToString.Trim = "01003" Then

            '    dtResult.Item("haircut") = 0.8
            'End If
            'If dtResult.Item("haircut") = 1 Then
            '    dtResult.Item("haircut") = 0
            'End If
        Next

        Return dsResult
    End Function

    Protected Friend Function FncExpertExcel(ByVal dgvSingle As DataGridView, ByVal dgvSign As DataGridView, ByVal indate As Date, ByVal LB As Boolean, ByVal cSF As Double, ByVal cHC As Double, Optional ByVal cut As Double = 1) As Boolean
        cSF *= -1
        cHC *= -1
        Dim stkCode As String = ""
        Dim stk As String = ""
        Dim dInvertedInterest As Double = 0
        If dgvSingle.Rows.Count > 0 Then
            stkCode = stkCode & "("
            For idrow As Integer = 0 To dgvSingle.Rows.Count - 1
                stk = dgvSingle.Item("sStk_code", idrow).Value.ToString.Trim
                If stk <> "" Then
                    stkCode = stkCode & "'" & stk & "', "
                End If
            Next
            stkCode = stkCode.Substring(0, stkCode.LastIndexOf(",")) & ")"
        Else
            Exit Function
        End If
        Dim str As String = "select a.clt_code, a.clt_name, a.run_code, b.run_name, 0.00 as concentration, " & _
                            "c.net_market_value, 0.00 as total_market_value, 0.00 as margin_shortfall, " & _
                            "0.00 as newMV, 0.00 as newMarginSF, 0.00 as increase1, " & _
                            "a.DR_BAL, 0.00 as haircut, 0.00 as accepted1, 0.00 as total_acc1, a.mc_act_ratio, a.margin_ratio, c.stk_code, " & _
                            "0.00 as adjust1, 0.00 as accepted2, 0.00 as total_acc2, 0.00 as adjust2, 0.00 as increase2, a.interest, a.mkt_value, a.margin_value " & _
                            "from stcltmaster_US a left join staemaster b on a.run_code = b.run_code " & _
                            "left join STPortfolio_US c on a.clt_code = c.clt_code " & _
                            "where c.stk_code in " & stkCode & " and a.clt_type = 'M'"
        If LB Then
            str = str & " and a.DR_BAL>0"
        End If
        str = str & " order by a.DR_BAL DESC"
        Dim cltDT As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)

        str = "select a.clt_code, a.clt_name, a.run_code, b.run_name, 0.00 as concentration, " & _
                            "c.net_market_value, 0.00 as total_market_value, 0.00 as margin_shortfall, " & _
                            "0.00 as newMV, 0.00 as newMarginSF, 0.00 as increase1, " & _
                            "a.DR_BAL, 0.00 as haircut, 0.00 as accepted1, 0.00 as total_acc1, a.mc_act_ratio, a.margin_ratio, c.stk_code, " & _
                            "0.00 as adjust1, 0.00 as accepted2, 0.00 as total_acc2, 0.00 as adjust2, 0.00 as increase2, a.interest, a.mkt_value, a.margin_value " & _
                            "from stcltmaster_US a left join staemaster b on a.run_code = b.run_code " & _
                            "left join STPortfolio_US c on a.clt_code = c.clt_code " & _
                            "where c.stk_code NOT in " & stkCode & " and a.clt_type = 'M' "
        If LB Then
            str = str & " and a.DR_BAL>0"
        End If
        str = str & " order by a.clt_code"
        Dim cltDTNOTConcentrated As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)


        str = "select a.clt_code, sum(b.net_market_value) as nmv from stcltmaster_US a left join STPortfolio_US b on " & _
                "a.clt_code = b.clt_code where a.clt_type = 'M' group by a.clt_code"
        Dim MVDT As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)
        For Each dr1 As DataRow In cltDT.Rows
            For Each dr2 As DataRow In MVDT.Rows
                If dr2("clt_code").ToString.Trim = dr1("clt_code").ToString.Trim Then
                    If dr1("total_market_value") <> 0 Then
                        Dim a As String = ""
                    End If
                    If Not IsDBNull(dr2("nmv")) Then
                        dr1("total_market_value") = dr2("nmv")
                    Else
                        Dim a As String = ""
                    End If
                    Exit For
                End If
            Next
        Next
        Dim sfDT As DataTable = FncGetHaircut(stkCode)
        Dim clt As String = ""
        Dim preClt As String = cltDT.Rows(0).Item("clt_code").ToString.Trim
        Dim startRow As Integer = 0
        Dim totalMV As Double = 0
        Dim totalAcc1 As Double = 0
        'Dim totalAcc2 As Double = 0
        For cltDR As Integer = 0 To cltDT.Rows.Count - 1
            'If cltDT.Rows(cltDR).Item("stk_code").ToString.Trim = "00922" Or _
            ' cltDT.Rows(cltDR).Item("stk_code").ToString.Trim = "00585" Or _
            ' cltDT.Rows(cltDR).Item("stk_code").ToString.Trim = "00985" Or _
            ' cltDT.Rows(cltDR).Item("stk_code").ToString.Trim = "00076" Then
            '    cltDT.Rows(cltDR).Item("haircut") = 0.3
            '    cltDT.Rows(cltDR).Item("accepted1") = cltDT.Rows(cltDR).Item("net_market_value") - cltDT.Rows(cltDR).Item("net_market_value") * 0.3
            'Else
            For Each sfDR As DataRow In sfDT.Rows
                If sfDR("Stk_code").ToString.Trim = cltDT.Rows(cltDR).Item("stk_code").ToString.Trim Then
                    cltDT.Rows(cltDR).Item("haircut") = sfDR("haircut")
                    cltDT.Rows(cltDR).Item("accepted1") = cltDT.Rows(cltDR).Item("net_market_value") - cltDT.Rows(cltDR).Item("net_market_value") * sfDR("haircut")
                    'If cltDT.Rows(cltDR).Item("accepted1") > cltDT.Rows(cltDR).Item("DR_BAL") Then
                    '    cltDT.Rows(cltDR).Item("adjust1") = cltDT.Rows(cltDR).Item("DR_BAL")
                    'Else
                    '    cltDT.Rows(cltDR).Item("adjust1") = cltDT.Rows(cltDR).Item("accepted1")
                    'End If
                    'For idrow As Integer = 0 To dgvSingle.Rows.Count - 1
                    '    If dgvSingle.Item("sStk_code", idrow).Value = cltDT.Rows(cltDR).Item("stk_code").ToString.Trim And _
                    '        cltDT.Rows(cltDR).Item("concentration") > dgvSingle.Item("precentage", idrow).Value Then
                    '        cltDT.Rows(cltDR).Item("accepted2") = 0
                    '        Exit For
                    '    End If
                    'Next
                    Exit For
                End If
            Next
            'End If

            clt = cltDT.Rows(cltDR).Item("clt_code").ToString.Trim
            If preClt <> clt Then
                preClt = clt
                For i As Integer = startRow To cltDR - 1
                    totalMV = cltDT.Rows(i).Item("total_market_value")
                    If totalMV - cltDT.Rows(i).Item("DR_BAL") < 0 Then
                        cltDT.Rows(i).Item("margin_shortfall") = Math.Round(totalMV - cltDT.Rows(i).Item("DR_BAL"), 2)
                    Else
                        cltDT.Rows(i).Item("margin_shortfall") = 0
                    End If
                    If totalMV = 0 Then
                        cltDT.Rows(i).Item("concentration") = 0
                    Else
                        cltDT.Rows(i).Item("concentration") = cltDT.Rows(i).Item("net_market_value") / totalMV
                    End If

                    cltDT.Rows(i).Item("total_acc1") = totalAcc1
                    If totalAcc1 > cltDT.Rows(i).Item("DR_BAL") Then
                        cltDT.Rows(i).Item("adjust1") = cltDT.Rows(i).Item("DR_BAL")
                    Else
                        cltDT.Rows(i).Item("adjust1") = totalAcc1
                    End If
                    'cltDT.Rows(i).Item("total_acc2") = cltDT.Rows(i).Item("accepted1") * (1 - cltDT.Rows(i).Item("concentration"))
                    'If cltDT.Rows(i).Item("total_acc2") > cltDT.Rows(i).Item("DR_BAL") Then
                    '    cltDT.Rows(i).Item("adjust2") = cltDT.Rows(i).Item("DR_BAL")
                    'Else
                    '    cltDT.Rows(i).Item("adjust2") = cltDT.Rows(i).Item("total_acc2")
                    'End If
                    'cltDT.Rows(i).Item("increase2") = cltDT.Rows(i).Item("adjust2") - cltDT.Rows(i).Item("adjust1")
                    'cltDT.Rows(i).Item("newMV") = totalMV - cltDT.Rows(i).Item("net_market_value")
                    'cltDT.Rows(i).Item("newMarginSF") = Math.Round(cltDT.Rows(i).Item("newMV") - cltDT.Rows(i).Item("DR_BAL"), 2)
                    'cltDT.Rows(i).Item("increase1") = cltDT.Rows(i).Item("newMarginSF") - cltDT.Rows(i).Item("margin_shortfall")
                    'For idrow As Integer = 0 To dgvSingle.Rows.Count - 1
                    '    If dgvSingle.Item("sStk_code", idrow).Value = cltDT.Rows(i).Item("stk_code").ToString.Trim Then
                    '        If cltDT.Rows(i).Item("concentration") > dgvSingle.Item("precentage", idrow).Value Then
                    '            cltDT.Rows(i).Item("newMV") = totalMV - cltDT.Rows(i).Item("net_market_value")
                    '            cltDT.Rows(i).Item("newMarginSF") = Math.Round(cltDT.Rows(i).Item("newMV") - cltDT.Rows(i).Item("DR_BAL"), 2)
                    '            cltDT.Rows(i).Item("increase1") = cltDT.Rows(i).Item("newMarginSF") - cltDT.Rows(i).Item("margin_shortfall")
                    '        Else
                    '            cltDT.Rows(i).Item("newMV") = totalMV
                    '            cltDT.Rows(i).Item("newMarginSF") = Math.Round(cltDT.Rows(i).Item("newMV") - cltDT.Rows(i).Item("DR_BAL"), 2)
                    '            cltDT.Rows(i).Item("increase1") = cltDT.Rows(i).Item("newMarginSF") - cltDT.Rows(i).Item("margin_shortfall")
                    '        End If
                    '        Exit For
                    '    End If
                    'Next
                Next
                totalMV = 0
                totalAcc1 = 0
                'totalAcc2 = 0
                startRow = cltDR
            End If
            'totalMV = totalMV + cltDT.Rows(cltDR).Item("net_market_value")
            totalAcc1 = totalAcc1 + cltDT.Rows(cltDR).Item("accepted1")
            'totalAcc2 = totalAcc2 + cltDT.Rows(cltDR).Item("accepted2")
        Next


        cltDTNOTConcentrated = CalculateNonConcentratedFRR(cltDTNOTConcentrated, MVDT)



        Dim strExFile As String = "SingleStockConcentration" & Format(Now(), "yyyyMMdd") & ".xls"
        Dim strFiles() As String
        Dim alignCentre As Integer = -4108
        Dim alignRight As Integer = -4152
        'Dim alignLeft As Integer
        'Dim alignCentre As Integer = 3
        'Dim alignRight As Integer = 5
        'Dim alignLeft As Integer = 1

        Dim edgeTop As Integer = 8
        Dim edgeBottom As Integer = 9
        Dim edgeLeft As Integer = 1
        Dim edgeRight As Integer = 2
        Dim continuous As Integer = 1
        Dim ldouble As Integer = -4119
        Dim dot As Integer = -4118
        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim xlWorkSheet As Object
        Dim xlRange As Object
        Dim show As Boolean = False
        Dim showRow As Boolean = False
        Dim deletedStartRow As Integer

        xlApp = CreateObject("Excel.Application")
        xlWorkBook = xlApp.Workbooks.Add()
        xlWorkBook.Activate()
        xlApp.Visible = False
        xlWorkSheet = xlWorkBook.Worksheets(1)
        Try
            strFiles = System.IO.Directory.GetFiles(GStrExptDir, strExFile)
            For Each strFile As String In strFiles
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next

            xlWorkSheet.Columns("A:A").ColumnWidth = 2.75
            xlWorkSheet.Columns("B:B").ColumnWidth = 11
            xlWorkSheet.Columns("C:C").ColumnWidth = 30
            xlWorkSheet.Columns("D:D").ColumnWidth = 12
            xlWorkSheet.Columns("E:E").ColumnWidth = 18
            xlWorkSheet.Columns("F:F").ColumnWidth = 11.5
            xlWorkSheet.Columns("G:G").ColumnWidth = 15
            xlWorkSheet.Columns("H:H").ColumnWidth = 8
            xlWorkSheet.Columns("I:I").ColumnWidth = 16
            xlWorkSheet.Columns("J:J").ColumnWidth = 0.5
            xlWorkSheet.Columns("K:K").ColumnWidth = 15.5
            xlWorkSheet.Columns("L:L").ColumnWidth = 0.5
            xlWorkSheet.Columns("M:M").ColumnWidth = 7
            xlWorkSheet.Columns("N:N").ColumnWidth = 0.5
            xlWorkSheet.Columns("O:O").ColumnWidth = 7
            xlWorkSheet.Columns("P:P").ColumnWidth = 0.5
            xlWorkSheet.Columns("Q:Q").ColumnWidth = 15.5
            xlWorkSheet.Columns("R:R").ColumnWidth = 15.5
            xlWorkSheet.Columns("S:S").ColumnWidth = 15.5
            xlWorkSheet.Columns("T:T").ColumnWidth = 7
            xlWorkSheet.Columns("U:U").ColumnWidth = 0.5
            xlWorkSheet.Columns("V:V").ColumnWidth = 15.5
            xlWorkSheet.Columns("W:W").ColumnWidth = 0.5
            xlWorkSheet.Columns("X:X").ColumnWidth = 15.5
            xlWorkSheet.Columns("Y:Y").ColumnWidth = 0.5
            xlWorkSheet.Columns("Z:Z").ColumnWidth = 15.5
            xlWorkSheet.Columns("AA:AA").ColumnWidth = 15.5
            xlWorkSheet.Columns("AB:AB").ColumnWidth = 15.5
            xlWorkSheet.Columns("AC:AC").ColumnWidth = 0.5

            xlWorkSheet.Cells(1, 1) = "Emperor Securities Limited"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 3))
            xlRange.Font.Bold = True
            xlRange.Merge()
            xlWorkSheet.Cells(2, 1) = "Debit Margin Client Stock Concentration"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 3))
            xlRange.Font.Bold = True
            xlRange.Merge()
            xlWorkSheet.Cells(3, 1) = "Top 20 Stocks or a Single Stock Exceeds 1% Total Stock Market Value"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 5))
            xlRange.Font.Bold = True
            xlRange.Font.underline = True
            xlRange.Merge()
            xlWorkSheet.Cells(1, 26) = "Date:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(1, 26), xlWorkSheet.Cells(1, 26))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(1, 27) = indate
            xlWorkSheet.Cells(5, 17) = "If high concentrated stock value dropped " & cut * 100 & "%"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 17), xlWorkSheet.Cells(5, 20))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 10
            xlRange.HorizontalAlignment = alignCentre
            xlRange.Merge()
            xlWorkSheet.Cells(5, 26) = "If high concentrated stock value dropped " & cut * 100 & "%"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 26), xlWorkSheet.Cells(5, 28))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 10
            xlRange.HorizontalAlignment = alignCentre
            xlRange.Merge()

            xlWorkSheet.Cells(7, 1) = "A/C No."
            xlWorkSheet.Cells(7, 2) = "A/C No."
            xlWorkSheet.Cells(7, 3) = "A/C Name"
            xlWorkSheet.Cells(7, 4) = "AE No."
            xlWorkSheet.Cells(7, 5) = "AE Name"
            xlWorkSheet.Cells(6, 6) = "Concentration"
            xlWorkSheet.Cells(7, 6) = "Ratio"
            xlWorkSheet.Cells(7, 7) = "Loan Balance"
            xlWorkSheet.Cells(7, 8) = "Interest"
            xlWorkSheet.Cells(6, 9) = "Total Stock"
            xlWorkSheet.Cells(7, 9) = "Market Value"
            xlWorkSheet.Cells(7, 10) = ""
            xlWorkSheet.Cells(7, 11) = "Margin Shortfall"
            xlWorkSheet.Cells(7, 12) = ""
            xlWorkSheet.Cells(7, 13) = "AR"
            xlWorkSheet.Cells(7, 14) = ""
            xlWorkSheet.Cells(7, 15) = "MR"
            xlWorkSheet.Cells(7, 16) = ""
            xlWorkSheet.Cells(6, 17) = "New"
            xlWorkSheet.Cells(7, 17) = "Market Value"
            xlWorkSheet.Cells(6, 18) = "New"
            xlWorkSheet.Cells(7, 18) = "Margin Shortfall"
            xlWorkSheet.Cells(6, 19) = "Increase of"
            xlWorkSheet.Cells(7, 19) = "Shortfall"
            xlWorkSheet.Cells(7, 20) = "AR"
            xlWorkSheet.Cells(7, 21) = ""
            xlWorkSheet.Cells(6, 22) = "Accepted (FRR)"
            xlWorkSheet.Cells(7, 22) = "Market Value"
            xlWorkSheet.Cells(7, 23) = ""
            xlWorkSheet.Cells(6, 24) = "Adjusted"
            xlWorkSheet.Cells(7, 24) = "Loan Balance"
            xlWorkSheet.Cells(7, 25) = ""
            xlWorkSheet.Cells(6, 26) = "Accepted (FRR)"
            xlWorkSheet.Cells(7, 26) = "Market Value"
            xlWorkSheet.Cells(6, 27) = "Adjusted"
            xlWorkSheet.Cells(7, 27) = "Loan Balance"
            xlWorkSheet.Cells(6, 28) = "Increase of"
            xlWorkSheet.Cells(7, 28) = "Haircut"
            xlWorkSheet.Cells(8, 6) = "(A)"
            xlWorkSheet.Cells(8, 7) = "(B)"
            xlWorkSheet.Cells(8, 9) = "(C)"
            xlWorkSheet.Cells(8, 11) = "(D)=C-B"
            xlWorkSheet.Cells(8, 17) = "(E)"
            xlWorkSheet.Cells(8, 18) = "(F)=E-B"
            xlWorkSheet.Cells(8, 19) = "(G)=F-D"
            xlWorkSheet.Cells(8, 20) = ""
            xlWorkSheet.Cells(8, 22) = "(H)"
            xlWorkSheet.Cells(8, 24) = "(I)=Lower of B or H"
            xlWorkSheet.Cells(8, 26) = "(J)"
            xlWorkSheet.Cells(8, 27) = "(K)=Lower of B or J"
            xlWorkSheet.Cells(8, 28) = "(L)=K-I"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(8, 6), xlWorkSheet.Cells(8, 28))
            xlRange.HorizontalAlignment = alignCentre
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(8, 28))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 10
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(7, 28))
            xlRange.HorizontalAlignment = alignCentre
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(7, 1), xlWorkSheet.Cells(7, 28))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 17), xlWorkSheet.Cells(5, 20))
            xlRange.Borders(edgeTop).LineStyle = continuous
            xlRange.Borders(edgeTop).Weight = 3
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 17), xlWorkSheet.Cells(7, 17))
            xlRange.Borders(edgeLeft).LineStyle = continuous
            xlRange.Borders(edgeLeft).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 20), xlWorkSheet.Cells(7, 20))
            xlRange.Borders(edgeRight).LineStyle = continuous
            xlRange.Borders(edgeRight).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(7, 17), xlWorkSheet.Cells(7, 20))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 26), xlWorkSheet.Cells(5, 28))
            xlRange.Borders(edgeTop).LineStyle = continuous
            xlRange.Borders(edgeTop).Weight = 3
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 26), xlWorkSheet.Cells(7, 26))
            xlRange.Borders(edgeLeft).LineStyle = continuous
            xlRange.Borders(edgeLeft).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 28), xlWorkSheet.Cells(7, 28))
            xlRange.Borders(edgeRight).LineStyle = continuous
            xlRange.Borders(edgeRight).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(7, 26), xlWorkSheet.Cells(7, 28))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3


            Dim xlRow As Integer = 10
            Dim xlStartRow As Integer = xlRow
            Dim count As Integer = 0
            Dim precentage As Decimal = 0
            Dim tLB, tMV, tMSH, tNMV, tNMSH, tISH, tAMV, tALB, tNAMV, tNALB, tNIF As Double
            Dim tLB1, tMV1, tMSH1, tNMV1, tNMSH1, tISH1, tAMV1, tALB1, tNAMV1, tNALB1, tNIF1 As Double
            Dim tLB2, tMV2, tMSH2, tNMV2, tNMSH2, tISH2, tAMV2, tALB2, tNAMV2, tNALB2, tNIF2 As Double
            For singleid As Integer = 0 To dgvSingle.Rows.Count - 1
                deletedStartRow = xlRow
                xlStartRow = xlRow
                stk = dgvSingle.Item("sStk_code", singleid).Value.ToString.Trim
                precentage = dgvSingle.Item("percentage", singleid).Value / 100
                xlWorkSheet.Cells(xlRow, 2) = "Stock Code :"
                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 2), xlWorkSheet.Cells(xlRow, 2))
                xlRange.Font.Bold = True
                xlRange.Font.Size = 10
                xlWorkSheet.Cells(xlRow, 3) = "=""" & stk & """"
                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 3))
                'xlRange.HorizontalAlignment = alignRight
                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 3))
                xlRange.Font.Size = 10
                'xlWorkSheet.Cells(xlRow, 4) = "Stock Name :"
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 4), xlWorkSheet.Cells(xlRow, 4))
                'xlRange.Font.Bold = True
                'xlRange.Font.Size = 10
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 5), xlWorkSheet.Cells(xlRow, 5))
                'xlRange.Font.Size = 10
                'xlWorkSheet.Cells(xlRow, 6) = "Margin Ratio :"
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 6), xlWorkSheet.Cells(xlRow, 6))
                'xlRange.Font.Bold = True
                'xlRange.Font.Size = 10
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 7))
                'xlRange.Font.Size = 10
                xlRow += 1
                xlWorkSheet.Cells(xlRow, 2) = "Type :"
                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 2), xlWorkSheet.Cells(xlRow, 2))
                xlRange.Font.Bold = True
                xlRange.Font.Size = 10
                xlWorkSheet.Cells(xlRow, 3) = dgvSingle.Item("type", singleid).Value.ToString.Trim
                xlRow += 1
                xlWorkSheet.Cells(xlRow, 2) = "Market Value :"
                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 2), xlWorkSheet.Cells(xlRow, 2))
                xlRange.Font.Bold = True
                xlRange.Font.Size = 10
                Dim marketValue As String = (Math.Round(dgvSingle.Item("market1", singleid).Value, 2)).ToString.Trim
                Dim dotPos As Integer = marketValue.IndexOf(".")
                If dotPos = -1 Then
                    marketValue = marketValue & ".00"
                    dotPos = marketValue.IndexOf(".")
                End If
                Dim length As Integer = marketValue.Length
                Dim i As Integer = dotPos
                While i > 0
                    If i - 3 > 0 Then
                        marketValue = marketValue.Substring(0, i - 3) & "," & marketValue.Substring(i - 3, length - i + 3)
                        length = marketValue.Length
                    End If
                    i -= 3
                End While
                xlWorkSheet.Cells(xlRow, 3) = "=""" & marketValue & """"
                'xlWorkSheet.Cells(xlRow, 3) = dgvSingle.Item("market1", singleid).Value
                'xlRange.HorizontalAlignment = alignLeft
                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 3))
                xlRange.Font.Size = 10
                'xlWorkSheet.Cells(xlRow, 4) = "Margin Value :"
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 4), xlWorkSheet.Cells(xlRow, 4))
                'xlRange.Font.Bold = True
                'xlRange.Font.Size = 10
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 5), xlWorkSheet.Cells(xlRow, 5))
                'xlRange.Font.Size = 10
                'xlWorkSheet.Cells(xlRow, 6) = "Weighting Ratio :"
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 6), xlWorkSheet.Cells(xlRow, 6))
                'xlRange.Font.Bold = True
                'xlRange.Font.Size = 10
                'xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 7))
                'xlRange.Font.Size = 10
                xlRow += 2

                tLB = 0
                tMV = 0
                tMSH = 0
                tNMV = 0
                tNMSH = 0
                tISH = 0
                tAMV = 0
                tALB = 0
                tNAMV = 0
                tNALB = 0
                tNIF = 0
                For Each dr As DataRow In cltDT.Rows

                    Dim dSUMNonConcentratedFRR As Double = SUMNonConcentratedFRR(cltDTNOTConcentrated, dr("clt_code").ToString.Trim)
                    Dim dSUMConcentratedFRR As Double = SUMConcentratedFRR(cltDT, dr("clt_code").ToString.Trim)

                    If dr("stk_code").ToString.Trim = stk Then
                        If dr("concentration") > precentage Then
                            'If dr("concentration") > 0 Then
                            count += 1
                            xlWorkSheet.Cells(xlRow, 1) = count
                            xlWorkSheet.Cells(xlRow, 2) = "=""" & dr("clt_code").ToString.Trim & """"
                            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 2), xlWorkSheet.Cells(xlRow, 2))
                            'xlRange.HorizontalAlignment = alignRight
                            xlWorkSheet.Cells(xlRow, 3) = dr("clt_name").ToString.Trim
                            xlWorkSheet.Cells(xlRow, 4) = "=""" & dr("run_code").ToString.Trim & """"
                            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 4), xlWorkSheet.Cells(xlRow, 4))
                            'xlRange.HorizontalAlignment = alignRight
                            xlWorkSheet.Cells(xlRow, 5) = dr("run_name").ToString.Trim
                            xlWorkSheet.Cells(xlRow, 6) = "=""" & (Math.Round(dr("concentration") * 100, 2)).ToString.Trim & "%"""
                            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 6), xlWorkSheet.Cells(xlRow, 6))
                            xlRange.HorizontalAlignment = alignRight
                            xlWorkSheet.Cells(xlRow, 7) = Math.Round(dr("DR_BAL"), 2)
                            dInvertedInterest = Math.Round(dr("interest") * -1, 2)
                            xlWorkSheet.Cells(xlRow, 8) = dInvertedInterest
                            xlWorkSheet.Cells(xlRow, 9) = Math.Round(dr("total_market_value"), 2)
                            xlWorkSheet.Cells(xlRow, 11) = Math.Round(dr("margin_shortfall"), 2)
                            xlWorkSheet.Cells(xlRow, 17) = Math.Round(dr("total_market_value") * (1 - dr("concentration") * cut), 2)
                            If xlWorkSheet.Cells(xlRow, 17).value - xlWorkSheet.Cells(xlRow, 7).value > 0 Then
                                xlWorkSheet.Cells(xlRow, 18) = 0
                            Else
                                xlWorkSheet.Cells(xlRow, 18) = xlWorkSheet.Cells(xlRow, 17).value - xlWorkSheet.Cells(xlRow, 7).value
                            End If

                            If xlWorkSheet.Cells(xlRow, 17).value = 0 Then
                                xlWorkSheet.Cells(xlRow, 20) = "=""99999%"""
                            Else
                                If dInvertedInterest >= 0 Then 'ratio equal to balance with interest when +ve interest(inverted)
                                    xlWorkSheet.Cells(xlRow, 20) = "=""" & (Math.Round((xlWorkSheet.Cells(xlRow, 7).value + xlWorkSheet.Cells(xlRow, 8).value) / xlWorkSheet.Cells(xlRow, 17).value * 100, 2)).ToString.Trim & "%"""
                                Else 'ratio equal to balance without interest when -ve interest(inverted)
                                    xlWorkSheet.Cells(xlRow, 20) = "=""" & (Math.Round((xlWorkSheet.Cells(xlRow, 7).value) / xlWorkSheet.Cells(xlRow, 17).value * 100, 2)).ToString.Trim & "%"""
                                End If

                            End If
                            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 20), xlWorkSheet.Cells(xlRow, 20))
                            xlRange.HorizontalAlignment = alignRight

                            xlWorkSheet.Cells(xlRow, 19) = xlWorkSheet.Cells(xlRow, 18).value - xlWorkSheet.Cells(xlRow, 11).value
                            If dInvertedInterest >= 0 Then 'ratio equal to balance with interest when +ve interest(inverted)
                                xlWorkSheet.Cells(xlRow, 13) = "=""" & (Math.Round(dr("mc_act_ratio") * 100, 2)).ToString.Trim & "%"""
                                xlWorkSheet.Cells(xlRow, 15) = "=""" & (Math.Round(dr("margin_ratio") * 100, 2)).ToString.Trim & "%"""
                            Else 'ratio equal to balance without interest when -ve interest(inverted)
                                xlWorkSheet.Cells(xlRow, 13) = "=""" & Math.Round((dr("DR_BAL") / dr("mkt_value")) * 100, 2).ToString.Trim & "%"""
                                xlWorkSheet.Cells(xlRow, 15) = "=""" & Math.Round((dr("DR_BAL") / dr("margin_value")) * 100, 2).ToString.Trim & "%"""
                            End If

                            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 13), xlWorkSheet.Cells(xlRow, 16))
                            xlRange.HorizontalAlignment = alignRight


                            xlWorkSheet.Cells(xlRow, 22) = Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2)

                            'xlWorkSheet.Cells(xlRow, 24) = Math.Round(dr("adjust1"), 2)
                            If Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2) > dr("DR_BAL") Then
                                xlWorkSheet.Cells(xlRow, 24) = dr("DR_BAL")
                            Else
                                xlWorkSheet.Cells(xlRow, 24) = Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2)
                            End If

                            xlWorkSheet.Cells(xlRow, 26) = Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2)

                            'If dr("total_acc1") * (1 - dr("concentration") * cut) > dr("DR_BAL") Then
                            '    xlWorkSheet.Cells(xlRow, 27) = dr("DR_BAL")
                            'Else
                            '    xlWorkSheet.Cells(xlRow, 27) = dr("total_acc1") * (1 - dr("concentration") * cut)
                            'End If
                            If Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2) > dr("DR_BAL") Then
                                xlWorkSheet.Cells(xlRow, 27) = dr("DR_BAL")
                            Else
                                xlWorkSheet.Cells(xlRow, 27) = Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2)
                            End If
                            xlWorkSheet.Cells(xlRow, 28) = xlWorkSheet.Cells(xlRow, 27).value - xlWorkSheet.Cells(xlRow, 24).value
                            If CDbl(xlWorkSheet.Cells(xlRow, 19).value) <= cSF Or CDbl(xlWorkSheet.Cells(xlRow, 28).value) <= cHC Then
                                showRow = True
                                show = True
                                xlRow += 1
                            Else
                                count -= 1
                            End If
                            If Not showRow Then
                                tLB += Math.Round(dr("DR_BAL"), 2)
                                tMV += Math.Round(dr("total_market_value"), 2)
                                tMSH += Math.Round(dr("margin_shortfall"), 2)
                                tNMV += Math.Round(dr("total_market_value") * (1 - dr("concentration") * cut), 2)
                                If dr("total_market_value") * (1 - dr("concentration") * cut) - dr("DR_BAL") > 0 Then
                                    tNMSH += 0
                                Else
                                    tNMSH += dr("total_market_value") * (1 - dr("concentration") * cut) - dr("DR_BAL")
                                End If
                                'tNMSH = tNMV - tLB
                                tISH = tNMSH - tMSH

                                'tAMV += Math.Round(dr("total_acc1"), 2)
                                tAMV += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2)

                                'tALB += Math.Round(dr("adjust1"), 2)
                                If Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2) > dr("DR_BAL") Then
                                    tALB += dr("DR_BAL")
                                Else
                                    tALB += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2)
                                End If


                                'tNAMV += Math.Round(dr("total_acc1") * (1 - dr("concentration") * cut), 2)
                                tNAMV += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2)

                                'If dr("total_acc1") * (1 - dr("concentration") * cut) > dr("DR_BAL") Then
                                '    tNALB += dr("DR_BAL")
                                'Else
                                '    tNALB += dr("total_acc1") * (1 - dr("concentration") * cut)
                                'End If
                                If Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2) > dr("DR_BAL") Then
                                    tNALB += dr("DR_BAL")
                                Else
                                    tNALB += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2)
                                End If
                                tNIF = tNALB - tALB
                                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 1), xlWorkSheet.Cells(xlRow, 25))
                                xlRange.delete()
                                'xlRow -= 1
                            End If
                        Else
                            tLB += Math.Round(dr("DR_BAL"), 2)
                            tMV += Math.Round(dr("total_market_value"), 2)
                            tMSH += Math.Round(dr("margin_shortfall"), 2)
                            tNMV += Math.Round(dr("total_market_value") * (1 - dr("concentration") * cut), 2)
                            If dr("total_market_value") * (1 - dr("concentration") * cut) - dr("DR_BAL") > 0 Then
                                tNMSH += 0
                            Else
                                tNMSH += dr("total_market_value") * (1 - dr("concentration") * cut) - dr("DR_BAL")
                            End If
                            'tNMSH = tNMV - tLB
                            tISH = tNMSH - tMSH

                            'tAMV += Math.Round(dr("total_acc1"), 2)
                            tAMV += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2)

                            'tALB += Math.Round(dr("adjust1"), 2)
                            If Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2) > dr("DR_BAL") Then
                                tALB += dr("DR_BAL")
                            Else
                                tALB += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR, 2)
                            End If

                            'tNAMV += Math.Round(dr("total_acc1") * (1 - dr("concentration") * cut), 2)
                            tNAMV += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2)

                            'If dr("total_acc1") * (1 - dr("concentration") * cut) > dr("DR_BAL") Then
                            '    tNALB += dr("DR_BAL")
                            'Else
                            '    tNALB += dr("total_acc1") * (1 - dr("concentration") * cut)
                            'End If
                            If Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2) > dr("DR_BAL") Then
                                tNALB += dr("DR_BAL")
                            Else
                                tNALB += Math.Round(dSUMNonConcentratedFRR + dSUMConcentratedFRR - dr("accepted1"), 2)
                            End If
                            tNIF = tNALB - tALB
                        End If

                        showRow = False
                    End If
                Next
                count = 0
                xlRow += 1
                If Not show Then
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(deletedStartRow, 1), xlWorkSheet.Cells(xlRow, 25))
                    xlRange.delete()
                    xlRow = deletedStartRow
                Else

                    xlWorkSheet.Cells(xlRow, 3) = "Debit Margin Client > " & precentage * 100 & "% Concentration Ratio:"
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 5))
                    xlRange.Merge()
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 19))
                    xlRange.Borders(edgeTop).LineStyle = continuous
                    xlRange.Borders(edgeTop).Weight = 2
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
                    xlRange.Borders(edgeTop).LineStyle = continuous
                    xlRange.Borders(edgeTop).Weight = 2
                    xlWorkSheet.Cells(xlRow, 7) = "=SUM(G" & xlStartRow & ":G" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 9) = "=SUM(I" & xlStartRow & ":I" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 11) = "=SUM(K" & xlStartRow & ":K" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 17) = "=SUM(Q" & xlStartRow & ":Q" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 18) = "=SUM(R" & xlStartRow & ":R" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 19) = "=SUM(S" & xlStartRow & ":S" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 22) = "=SUM(V" & xlStartRow & ":V" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 24) = "=SUM(X" & xlStartRow & ":X" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 26) = "=SUM(Z" & xlStartRow & ":Z" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 27) = "=SUM(AA" & xlStartRow & ":AA" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 28) = "=SUM(AB" & xlStartRow & ":AB" & xlRow - 1 & ")"
                    tLB1 += Math.Round(xlWorkSheet.Cells(xlRow, 7).value, 2)
                    tMV1 += Math.Round(xlWorkSheet.Cells(xlRow, 9).value, 2)
                    tMSH1 += Math.Round(xlWorkSheet.Cells(xlRow, 11).value, 2)
                    tNMV1 += Math.Round(xlWorkSheet.Cells(xlRow, 17).value, 2)
                    tNMSH1 += Math.Round(xlWorkSheet.Cells(xlRow, 18).value, 2)
                    tISH1 += Math.Round(xlWorkSheet.Cells(xlRow, 19).value, 2)
                    tAMV1 += Math.Round(xlWorkSheet.Cells(xlRow, 22).value, 2)
                    tALB1 += Math.Round(xlWorkSheet.Cells(xlRow, 24).value, 2)
                    tNAMV1 += Math.Round(xlWorkSheet.Cells(xlRow, 26).value, 2)
                    tNALB1 += Math.Round(xlWorkSheet.Cells(xlRow, 27).value, 2)
                    tNIF1 += Math.Round(xlWorkSheet.Cells(xlRow, 28).value, 2)
                    xlRow += 1

                    xlWorkSheet.Cells(xlRow, 3) = "Other Debit Margin Client:"
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 19))
                    xlRange.Borders(edgeBottom).LineStyle = continuous
                    xlRange.Borders(edgeBottom).Weight = 2
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
                    xlRange.Borders(edgeBottom).LineStyle = continuous
                    xlRange.Borders(edgeBottom).Weight = 2
                    xlWorkSheet.Cells(xlRow, 7) = tLB
                    xlWorkSheet.Cells(xlRow, 9) = tMV
                    xlWorkSheet.Cells(xlRow, 11) = tMSH
                    xlWorkSheet.Cells(xlRow, 17) = tNMV
                    xlWorkSheet.Cells(xlRow, 18) = tNMSH
                    xlWorkSheet.Cells(xlRow, 19) = tISH
                    xlWorkSheet.Cells(xlRow, 22) = tAMV
                    xlWorkSheet.Cells(xlRow, 24) = tALB
                    xlWorkSheet.Cells(xlRow, 26) = tNAMV
                    xlWorkSheet.Cells(xlRow, 27) = tNALB
                    xlWorkSheet.Cells(xlRow, 28) = tNIF
                    tLB2 += Math.Round(xlWorkSheet.Cells(xlRow, 7).value, 2)
                    tMV2 += Math.Round(xlWorkSheet.Cells(xlRow, 9).value, 2)
                    tMSH2 += Math.Round(xlWorkSheet.Cells(xlRow, 11).value, 2)
                    tNMV2 += Math.Round(xlWorkSheet.Cells(xlRow, 17).value, 2)
                    tNMSH2 += Math.Round(xlWorkSheet.Cells(xlRow, 18).value, 2)
                    tISH2 += Math.Round(xlWorkSheet.Cells(xlRow, 19).value, 2)
                    tAMV2 += Math.Round(xlWorkSheet.Cells(xlRow, 22).value, 2)
                    tALB2 += Math.Round(xlWorkSheet.Cells(xlRow, 24).value, 2)
                    tNAMV2 += Math.Round(xlWorkSheet.Cells(xlRow, 26).value, 2)
                    tNALB2 += Math.Round(xlWorkSheet.Cells(xlRow, 27).value, 2)
                    tNIF2 += Math.Round(xlWorkSheet.Cells(xlRow, 28).value, 2)
                    xlRow += 1
                    xlWorkSheet.Cells(xlRow, 3) = "Total Debit Margin Client:"
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 19))
                    xlRange.Borders(edgeBottom).LineStyle = ldouble
                    xlRange.Borders(edgeBottom).Weight = 4
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
                    xlRange.Borders(edgeBottom).LineStyle = ldouble
                    xlRange.Borders(edgeBottom).Weight = 4
                    xlWorkSheet.Cells(xlRow, 7) = "=SUM(G" & xlRow - 2 & ":G" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 9) = "=SUM(I" & xlRow - 2 & ":I" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 11) = "=SUM(K" & xlRow - 2 & ":K" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 17) = "=SUM(Q" & xlRow - 2 & ":Q" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 18) = "=SUM(R" & xlRow - 2 & ":R" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 19) = "=SUM(S" & xlRow - 2 & ":S" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 22) = "=SUM(V" & xlRow - 2 & ":V" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 24) = "=SUM(X" & xlRow - 2 & ":X" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 26) = "=SUM(Z" & xlRow - 2 & ":Z" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 27) = "=SUM(AA" & xlRow - 2 & ":AA" & xlRow - 1 & ")"
                    xlWorkSheet.Cells(xlRow, 28) = "=SUM(AB" & xlRow - 2 & ":AB" & xlRow - 1 & ")"
                    xlRow += 3
                    tLB = 0
                    tMV = 0
                    tMSH = 0
                    tNMV = 0
                    tNMSH = 0
                    tISH = 0
                    tAMV = 0
                    tALB = 0
                    tNAMV = 0
                    tNALB = 0
                    tNIF = 0
                End If
                show = False
            Next
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(8, 1), xlWorkSheet.Cells(xlRow, 28))
            xlRange.Font.Size = 10
            xlRow += 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow + 5, 5))
            xlRange.Font.Bold = True
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Borders(edgeTop).LineStyle = continuous
            xlRange.Borders(edgeTop).Weight = 3
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3
            xlWorkSheet.Cells(xlRow, 3) = "Top 20 Stocks or a Single Stock Exceeds 1% Total Stock Market "
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 5))
            xlRange.Merge()
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
            xlRange.Borders(edgeTop).LineStyle = continuous
            xlRange.Borders(edgeTop).Weight = 3
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow + 5, 3))
            xlRange.Borders(edgeLeft).LineStyle = continuous
            xlRange.Borders(edgeLeft).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow + 5, 22))
            xlRange.Borders(edgeLeft).LineStyle = continuous
            xlRange.Borders(edgeLeft).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 19), xlWorkSheet.Cells(xlRow + 5, 19))
            xlRange.Borders(edgeRight).LineStyle = continuous
            xlRange.Borders(edgeRight).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 28), xlWorkSheet.Cells(xlRow + 5, 28))
            xlRange.Borders(edgeRight).LineStyle = continuous
            xlRange.Borders(edgeRight).Weight = 3
            xlRow += 2

            xlWorkSheet.Cells(xlRow, 3) = "Debit Margin Client at high Concentration Ratio:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 5))
            xlRange.Merge()
            xlWorkSheet.Cells(xlRow, 7) = tLB1
            xlWorkSheet.Cells(xlRow, 9) = tMV1
            xlWorkSheet.Cells(xlRow, 11) = tMSH1
            xlWorkSheet.Cells(xlRow, 17) = tNMV1
            xlWorkSheet.Cells(xlRow, 18) = tNMSH1
            xlWorkSheet.Cells(xlRow, 19) = tISH1
            xlWorkSheet.Cells(xlRow, 22) = tAMV1
            xlWorkSheet.Cells(xlRow, 24) = tALB1
            xlWorkSheet.Cells(xlRow, 26) = tNAMV1
            xlWorkSheet.Cells(xlRow, 27) = tNALB1
            xlWorkSheet.Cells(xlRow, 28) = tNIF1
            xlRow += 1
            xlWorkSheet.Cells(xlRow, 3) = "Other Debit Margin Client:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlWorkSheet.Cells(xlRow, 7) = tLB2
            xlWorkSheet.Cells(xlRow, 9) = tMV2
            xlWorkSheet.Cells(xlRow, 11) = tMSH2
            xlWorkSheet.Cells(xlRow, 17) = tNMV2
            xlWorkSheet.Cells(xlRow, 18) = tNMSH2
            xlWorkSheet.Cells(xlRow, 19) = tISH2
            xlWorkSheet.Cells(xlRow, 22) = tAMV2
            xlWorkSheet.Cells(xlRow, 24) = tALB2
            xlWorkSheet.Cells(xlRow, 26) = tNAMV2
            xlWorkSheet.Cells(xlRow, 27) = tNALB2
            xlWorkSheet.Cells(xlRow, 28) = tNIF2
            xlRow += 1
            xlWorkSheet.Cells(xlRow, 3) = "Total Debit Margin Client:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 7), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Borders(edgeBottom).LineStyle = ldouble
            xlRange.Borders(edgeBottom).Weight = 4
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
            xlRange.Borders(edgeBottom).LineStyle = ldouble
            xlRange.Borders(edgeBottom).Weight = 4
            xlWorkSheet.Cells(xlRow, 7) = "=SUM(G" & xlRow - 2 & ":G" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 9) = "=SUM(I" & xlRow - 2 & ":I" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 11) = "=SUM(K" & xlRow - 2 & ":K" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 17) = "=SUM(Q" & xlRow - 2 & ":Q" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 18) = "=SUM(R" & xlRow - 2 & ":R" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 19) = "=SUM(S" & xlRow - 2 & ":S" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 22) = "=SUM(V" & xlRow - 2 & ":V" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 24) = "=SUM(X" & xlRow - 2 & ":X" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 26) = "=SUM(Z" & xlRow - 2 & ":Z" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 27) = "=SUM(AA" & xlRow - 2 & ":AA" & xlRow - 1 & ")"
            xlWorkSheet.Cells(xlRow, 28) = "=SUM(AB" & xlRow - 2 & ":AB" & xlRow - 1 & ")"
            xlRow += 1
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 3), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 22), xlWorkSheet.Cells(xlRow, 28))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3
            xlRow += 3

            xlWorkSheet.Cells(xlRow, 1) = dgvSign.Item("title", 0).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 1), xlWorkSheet.Cells(xlRow, 2))
            xlRange.Merge()
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 6) = dgvSign.Item("title", 1).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 6), xlWorkSheet.Cells(xlRow, 6))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 11) = dgvSign.Item("title", 2).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 11), xlWorkSheet.Cells(xlRow, 11))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 15) = dgvSign.Item("title", 3).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 15), xlWorkSheet.Cells(xlRow, 15))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 19) = dgvSign.Item("title", 4).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 19), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 24) = dgvSign.Item("title", 5).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 24), xlWorkSheet.Cells(xlRow, 24))
            xlRange.Font.Bold = True
            xlRow += 4
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 1), xlWorkSheet.Cells(xlRow, 2))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 6), xlWorkSheet.Cells(xlRow, 6))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 11), xlWorkSheet.Cells(xlRow, 11))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 15), xlWorkSheet.Cells(xlRow, 15))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 19), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 24), xlWorkSheet.Cells(xlRow, 24))
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2
            xlRow += 1
            xlWorkSheet.Cells(xlRow, 1) = dgvSign.Item("sign_by", 0).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 1), xlWorkSheet.Cells(xlRow, 2))
            xlRange.Merge()
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 6) = dgvSign.Item("sign_by", 1).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 6), xlWorkSheet.Cells(xlRow, 6))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 11) = dgvSign.Item("sign_by", 2).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 11), xlWorkSheet.Cells(xlRow, 11))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 15) = dgvSign.Item("sign_by", 3).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 15), xlWorkSheet.Cells(xlRow, 15))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 19) = dgvSign.Item("sign_by", 4).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 19), xlWorkSheet.Cells(xlRow, 19))
            xlRange.Font.Bold = True
            xlWorkSheet.Cells(xlRow, 24) = dgvSign.Item("sign_by", 5).Value
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(xlRow, 24), xlWorkSheet.Cells(xlRow, 24))
            xlRange.Font.Bold = True

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(9, 2), xlWorkSheet.Cells(xlRow, 28))
            xlRange.Font.Name = "Times New Roman"
            xlRange.NumberFormat = "#,##0.00_);(#,##0.00)"

            With xlWorkSheet.PageSetup
                .Orientation = PaperOrientation.Landscape
                .PaperSize = PaperSize.PaperA3
                .CenterHorizontally = True
                .Zoom = False
                .FitToPagesWide = 1
                .FitToPagesTall = False
                .LeftMargin = xlApp.InchesToPoints(0.24)
                .RightMargin = xlApp.InchesToPoints(0.24)
                .TopMargin = xlApp.InchesToPoints(0.74)
                .BottomMargin = xlApp.InchesToPoints(0.74)
                .HeaderMargin = xlApp.InchesToPoints(0.29)
                .FooterMargin = xlApp.InchesToPoints(0.29)
            End With

            xlWorkBook.SaveAs(GStrExptDir & strExFile)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            GC.Collect()
            GC.WaitForPendingFinalizers()
            Return True
        Catch ex As Exception
            xlWorkBook.close()
            xlApp.Quit()
            GC.Collect()
            GSubWriteErrLog(ex.Message)
            GSubShowInfo(GFncGetSysMsg(89))
        End Try
        Return False
    End Function
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Protected Friend Function FncLoadMisc() As DataSet
        Return GFncRtnDS(GSCnSqlConn, "select * from misc_master where misc_type = 'SSCM'")
    End Function
    Protected Friend Function FncInsertMisc(ByVal stk As String, ByVal precentage As Double, ByVal MyTrans As SqlTransaction)
        Dim checkStr As String = "select * from misc_master where misc_type = 'SSCM' and misc_code = '" & stk & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, checkStr, MyTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            Return Nothing
        End If
        Dim str As String = "insert into misc_master values('SSCM', '" & stk & "', " & precentage & ")"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return Nothing
    End Function
    Protected Friend Function FncUpdateMisc(ByVal stk As String, ByVal precentage As Double, ByVal MyTrans As SqlTransaction)
        Dim str As String = "update misc_master set misc_desc = " & precentage & " where misc_type = 'SSCM' and misc_code = '" & stk & "'"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
        Catch ex As Exception
            Exit Try
        End Try
        Return Nothing
    End Function
    Protected Friend Function FncDeleteMisc(ByVal stk As String, ByVal MyTrans As SqlTransaction)
        Dim str As String = "delete from misc_master where misc_type = 'SSCM' and misc_code = '" & stk & "'"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
        Catch ex As Exception
            Exit Try
        End Try
        Return Nothing
    End Function
    Private Function CalculateNonConcentratedFRR(ByVal cltDTNOTConcentrated As DataTable, ByVal MVDT As DataTable) As DataTable
        Dim dt As New DataTable

        'start calcaulated non concentrated FRR market value
        Dim clt As String = ""
        Dim preClt As String = cltDTNOTConcentrated.Rows(0).Item("clt_code").ToString.Trim
        Dim startRow As Double = 0
        Dim totalMV As Double = 0
        Dim totalAcc1 As Double = 0

        Dim sfDTNOTConcentrated As DataTable = FncGetHaircut("")
        For Each dr1 As DataRow In cltDTNOTConcentrated.Rows
            For Each dr2 As DataRow In MVDT.Rows
                If dr2("clt_code").ToString.Trim = dr1("clt_code").ToString.Trim Then
                    dr1("total_market_value") = dr2("nmv")
                    Exit For
                End If
            Next
        Next
        For cltDR As Integer = 0 To cltDTNOTConcentrated.Rows.Count - 1
            Dim client_code As String = cltDTNOTConcentrated.Rows(cltDR).Item("clt_code").ToString()

            For Each sfDR As DataRow In sfDTNOTConcentrated.Rows
                If sfDR("Stk_code").ToString.Trim = cltDTNOTConcentrated.Rows(cltDR).Item("stk_code").ToString.Trim Then
                    cltDTNOTConcentrated.Rows(cltDR).Item("haircut") = sfDR("haircut")
                    cltDTNOTConcentrated.Rows(cltDR).Item("accepted1") = cltDTNOTConcentrated.Rows(cltDR).Item("net_market_value") - cltDTNOTConcentrated.Rows(cltDR).Item("net_market_value") * sfDR("haircut")

                    Exit For
                End If
            Next

            clt = cltDTNOTConcentrated.Rows(cltDR).Item("clt_code").ToString.Trim
            If preClt <> clt Then
                preClt = clt
                For i As Integer = startRow To cltDR - 1
                    totalMV = cltDTNOTConcentrated.Rows(i).Item("total_market_value")
                    If totalMV - cltDTNOTConcentrated.Rows(i).Item("DR_BAL") < 0 Then
                        cltDTNOTConcentrated.Rows(i).Item("margin_shortfall") = Math.Round(totalMV - cltDTNOTConcentrated.Rows(i).Item("DR_BAL"), 2)
                    Else
                        cltDTNOTConcentrated.Rows(i).Item("margin_shortfall") = 0
                    End If
                    If totalMV = 0 Then
                        cltDTNOTConcentrated.Rows(i).Item("concentration") = 0
                    Else
                        cltDTNOTConcentrated.Rows(i).Item("concentration") = cltDTNOTConcentrated.Rows(i).Item("net_market_value") / totalMV
                    End If

                    cltDTNOTConcentrated.Rows(i).Item("total_acc1") = totalAcc1
                    If totalAcc1 > cltDTNOTConcentrated.Rows(i).Item("DR_BAL") Then
                        cltDTNOTConcentrated.Rows(i).Item("adjust1") = cltDTNOTConcentrated.Rows(i).Item("DR_BAL")
                    Else
                        cltDTNOTConcentrated.Rows(i).Item("adjust1") = totalAcc1
                    End If

                Next
                totalMV = 0
                totalAcc1 = 0

                startRow = cltDR
            End If

            totalAcc1 = totalAcc1 + cltDTNOTConcentrated.Rows(cltDR).Item("accepted1")

        Next
        'end calculated non concentrated FRR market value

        Return cltDTNOTConcentrated
    End Function
    Private Function SUMConcentratedFRR(ByVal cltDT As DataTable, ByVal pclientcode As String) As Double

        Dim totalAcc1 As Double = 0
        pclientcode = pclientcode.Trim
        For Each dr As DataRow In cltDT.Rows
            If pclientcode = dr("clt_code").ToString.Trim Then
                totalAcc1 = totalAcc1 + dr("accepted1")
            End If
        Next

        Return totalAcc1
    End Function
    Private Function SUMNonConcentratedFRR(ByVal cltDTNOTConcentrated As DataTable, ByVal pclientcode As String) As Double
        Dim dTotal As Double

        dTotal = 0

        pclientcode = pclientcode.Trim
        For Each dr1 As DataRow In cltDTNOTConcentrated.Rows
            If pclientcode = dr1("clt_code").ToString.Trim Then
                dTotal = dTotal + dr1("accepted1")
            End If
        Next

        Return dTotal
    End Function
End Class
