Public Class ClsCommAES

    Dim ldsDefault As DataSet = Nothing
    Dim ldsGrpList As DataSet = Nothing
    Dim ldsAccList As DataSet = Nothing
    Dim ldsTrade As DataSet = Nothing
    Dim ldsRate As DataSet = Nothing

    Protected Friend Function lFncCalTotalComm(ByVal txmonth As String) As DataSet

        ldsDefault = lFncLoadDefaultCfg()
        ldsGrpList = lFncLoadGroupCfgList(txmonth)
        ldsAccList = lFncLoadAccCfgList(txmonth)
        ldsTrade = lFncLoadTrade(txmonth)
        ldsRate = lFncLoadRate(txmonth)

        For i As Integer = 0 To ldsTrade.Tables(0).Rows.Count - 1
            Dim ae_no As String = ldsTrade.Tables(0).Rows(i).Item("ae_no")
            Dim acc_group As String = ldsTrade.Tables(0).Rows(i).Item("acc_group")
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
                                                                    "' and turnover_from <= " & turnover, " turnover_from desc")

        Dim rate As Decimal

        If (ldrRate.Length > 0) Then
            rate = ldrRate(0).Item("comm_rate")
        Else
            rate = lFncGetDefaultComm(rate_type, "AGRP")
        End If

        Return rate

    End Function

    Protected Friend Function lFncGetDefaultComm(ByVal rate_type As String, ByVal comm_type As String) As Decimal

        Dim ldrDefault As DataRow() = ldsDefault.Tables(0).Select(" comm_type = '" & comm_type & "' ")

        If (rate_type = "NOR") Then
            Return ldrDefault(0).Item("commNorRate")
        Else
            Return ldrDefault(0).Item("commIntRate")
        End If

    End Function

    Protected Friend Function lFncCalIndvComm(ByVal ae_no As String, ByVal acc_no As String, ByVal tradetype As Integer, _
                                            ByVal grossamt As Decimal, ByVal commission As Decimal, ByVal comm_rate As Decimal, _
                                            Optional ByVal row As Integer = -1) As Decimal

        Dim minRate As Decimal = 0
        Dim minAmt As Decimal = 0
        Dim coRate As Decimal = 0
        Dim minRateComm As Decimal = 0
        Dim coRateComm As Decimal = 0
        Dim minTOComm As Decimal = 0
        Dim co_comm As Decimal = 0

        lFncGetIndvMinVal(ae_no, acc_no, tradetype, minAmt, minRate)
        If (lFncGetAccConsolidStatus(ae_no, acc_no)) Then
            coRate = lFncGetAccRate(ae_no, acc_no, "CON", grossamt)
        Else
            If (tradetype = 0) Then
                coRate = lFncGetAccRate(ae_no, acc_no, "NOR", grossamt)
            Else
                coRate = lFncGetAccRate(ae_no, acc_no, "INT", grossamt)
            End If
        End If

        minRateComm = commission * minRate / 100
        coRateComm = coRate * grossamt / 100
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
                                             ByRef minAmt As Decimal, ByRef minRate As Decimal)

        Dim ldrAccList As DataRow() = ldsAccList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_no & "' ")

        If (ldrAccList.Length > 0) Then
            If (tradetype = 0) Then
                minAmt = ldrAccList(0).Item("minNorAmt")
                minRate = ldrAccList(0).Item("minNorRate")
            Else
                minAmt = ldrAccList(0).Item("minIntAmt")
                minRate = ldrAccList(0).Item("minIntRate")
            End If
        Else
            lFncGetDefaultIndvMin(tradetype, minAmt, minRate)
        End If

    End Sub

    Protected Friend Function lFncGetAccConsolidStatus(ByVal ae_no As String, ByVal acc_no As String) As Boolean

        Dim ldrAccList As DataRow() = ldsAccList.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_no & "' ")

        Return ldrAccList(0).Item("isConsolid")

    End Function

    Protected Friend Function lFncGetAccRate(ByVal ae_no As String, ByVal acc_group As String, ByVal rate_type As String, _
                                                      ByVal turnover As Decimal) As Decimal

        Dim ldrRate As DataRow() = ldsRate.Tables(0).Select(" ae_no = '" & ae_no & "' and acc_no = '" & acc_group & _
                                                                    "' and rate_type = '" & rate_type & _
                                                                    "' and turnover_from <= " & turnover, " turnover_from desc")

        Dim rate As Decimal

        If (ldrRate.Length > 0) Then
            rate = ldrRate(0).Item("comm_rate")
        Else
            rate = lFncGetDefaultComm(rate_type, "ACC")
        End If

        Return rate

    End Function

    Protected Friend Sub lFncGetDefaultIndvMin(ByVal tradetype As Integer, ByRef minAmt As Decimal, ByRef minRate As Decimal)

        Dim ldrDefault As DataRow() = ldsDefault.Tables(0).Select(" comm_type = 'ACC' ")

        If (tradetype = 0) Then
            minAmt = ldrDefault(0).Item("minNorAmt")
            minRate = ldrDefault(0).Item("minNorRate")
        Else
            minAmt = ldrDefault(0).Item("minIntAmt")
            minRate = ldrDefault(0).Item("minIntRate")
        End If

    End Sub

    Protected Friend Function lFncLoadDefaultCfg() As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select comm_type, minNorAmt, minIntAmt, minNorRate_s as minNorRate, minIntRate_s as minIntRate, commNorRate, " & _
                    "commIntRate from comm_global "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "tradelist")
        Return lds

    End Function

    Protected Friend Function lFncLoadGroupCfgList(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.ae_no, b.acc_group_s as acc_group, c.isConsolid, c.minConTO, c.minNorTO, c.minIntTO, " & _
                    "sum(case when tradetype = 0 then grossamt else 0 end) as norTO, " & _
                    "sum(case when tradetype = 4 then grossamt else 0 end) as intTO " & _
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
                    "b.minIntRate, b.isConsolid, " & _
                    "sum(case when a.tradetype = 0 then a.grossamt else 0 end) as norTO, " & _
                    "sum(case when a.tradetype = 4 then a.grossamt else 0 end) as intTO " & _
                    "from view_comm_adjusted_s a " & _
                    "inner join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "where a.txmonth = '" & txmonth & "' group by  a.ae_no, b.acc_group_s, a.acc_no, b.minNorAmt, b.minIntAmt, " & _
                    "b.minNorRate, b.minIntRate, b.isConsolid, a.comm_rate " & _
                    "order by a.ae_no, acc_group_s, a.acc_no "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "acclist")
        Return lds

    End Function

    Protected Friend Function lFncLoadTrade(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select a.ae_no, b.acc_group_s as acc_group, a.acc_no, a.tradetype, a.grossamt, a.commission, a.comm_rate, " & _
                    "cast(0 as numeric(18,4)) as co_comm, cast(0 as numeric(18,4)) as ae_comm, cast(0 as decimal(18,4)) as CoRate, " & _
                    "cast(0 as decimal(18,4)) as MinTO, cast(NULL as decimal(18,4)) as MinRate, cast(NULL as decimal(18,4)) as CoRateComm, " & _
                    "cast(NULL as decimal(18,4)) as MinRateComm, cast(NULL as decimal(18,4)) as MinTOComm, cast(NULL as decimal(18,4)) as GrpTO " & _
                    "from view_comm_adjusted_s a " & _
                    "inner join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "where a.txmonth = '" & txmonth & "' " & _
                    "order by a.ae_no, acc_group_s, a.acc_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "tradelist")
        Return lds

    End Function

    Protected Friend Function lFncLoadRate(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct c.ae_no, c.acc_group, c.acc_no, c.rate_type, c.turnover_from, c.comm_rate " & _
                    "from view_comm_adjusted_s a " & _
                    "inner join comm_acc_master_d b on a.txmonth = b.txmonth and a.acc_no = b.acc_no and a.ae_no = b.ae_no_s " & _
                    "inner join comm_rate_s c on a.txmonth = c.comm_month and ((b.acc_no = c.acc_no and a.ae_no = c.ae_no) or " & _
                    "(b.acc_group_s = c.acc_group and a.ae_no = c.ae_no)) " & _
                    "where c.comm_month = '" & txmonth & "' " & _
                    "order by c.ae_no, c.acc_no  "
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

    '------------------------------------------------------------------------------------------------------------------------------


    Protected Friend Function lFncCalCommManager(ByVal ldtComm As DataTable, ByVal txmonth As String) As DataTable

        Dim ldsGrpS As DataSet = lFncLoadGrpS(txmonth)
        Dim ldsGrpF As DataSet = lFncLoadGrpF(txmonth)
        Dim ldsRateS As DataSet = lFncLoadRateS(txmonth)
        Dim ldsRateF As DataSet = lFncLoadRateF(txmonth)
        Dim ldsAE As DataSet = lFncAEList(txmonth)

        Dim ldtManager As New DataTable
        InitManagerDTF(ldtManager)

        'used to cal group total
        For i As Integer = 0 To ldtComm.Rows.Count - 1
            Dim ae_no As String = ldtComm.Rows(i).Item("ae_no")
            Dim ldrAE As DataRow() = ldsAE.Tables(0).Select(" ae_no = '" & ae_no & "' ")
            If (ldrAE.Length > 0) Then
                Dim man_no_s As String = ldrAE(0).Item("man_no_s")
                Dim man_group_s As String = ldrAE(0).Item("man_group_s")
                Dim total_brok_s As String = ldtComm.Rows(i).Item("total_brok_s")
                Dim total_TO_s As String = ldtComm.Rows(i).Item("total_TO_s")
                Dim ldrGrpS As DataRow() = ldsGrpS.Tables(0).Select(" man_no = '" & man_no_s & "' and man_group = '" & man_group_s & "' ")
                If (ldrGrpS.Length > 0) Then
                    ldrGrpS(0).Item("brok") = ldrGrpS(0).Item("brok") + total_brok_s
                    ldrGrpS(0).Item("turn") = ldrGrpS(0).Item("turn") + total_TO_s
                End If

                Dim man_no_f As String = ldrAE(0).Item("man_no_f")
                Dim man_group_f As String = ldrAE(0).Item("man_group_f")
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
            End If
        Next

        'used to update group rate
        For i As Integer = 0 To ldsGrpS.Tables(0).Rows.Count - 1
            Dim man_no As String = ldsGrpS.Tables(0).Rows(i).Item("man_no")
            Dim man_group As String = ldsGrpS.Tables(0).Rows(i).Item("man_group")
            Dim vol As Decimal = 0
            Dim ldrRate As DataRow() = Nothing
            If (ldsGrpS.Tables(0).Rows(i).Item("turnover_flag_s")) Then
                ldrRate = ldsRateS.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                    "' and rate_type = 'MTURN' and turnover_from <= " & _
                                                    ldsGrpS.Tables(0).Rows(i).Item("turn"), " turnover_from ")
            Else
                ldrRate = ldsRateS.Tables(0).Select(" man_no = '" & man_no & "' and man_group = '" & man_group & _
                                                    "' and rate_type = 'MBROK' and turnover_from <= " & _
                                                    ldsGrpS.Tables(0).Rows(i).Item("brok"), " turnover_from ")
            End If
            If (ldrRate.Length > 0) Then
                ldsGrpS.Tables(0).Rows(i).Item("rate") = ldrRate(0).Item("comm_rate")
            Else
                ldsGrpS.Tables(0).Rows(i).Item("rate") = 0
            End If
        Next

        For i As Integer = 0 To ldsGrpF.Tables(0).Rows.Count - 1
            Dim man_no As String = ldsGrpF.Tables(0).Rows(i).Item("man_no")
            Dim man_group As String = ldsGrpF.Tables(0).Rows(i).Item("man_group")
            Dim ldrRateF As DataRow() = Nothing
            Dim ldrRateO As DataRow() = Nothing
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
        Next

        'create dataset
        For i As Integer = 0 To ldtComm.Rows.Count - 1
            Dim ae_no As String = ldtComm.Rows(i).Item("ae_no")
            Dim ldrAE As DataRow() = ldsAE.Tables(0).Select(" ae_no = '" & ae_no & "' ")
            If (ldrAE.Length > 0) Then
                Dim man_no_s As String = ldrAE(0).Item("man_no_s")
                Dim man_no_f As String = ldrAE(0).Item("man_no_f")
                Dim man_group_s As String = ldrAE(0).Item("man_group_s")
                Dim man_group_f As String = ldrAE(0).Item("man_group_f")
                Dim basis_s As String = ""
                Dim basis_f As String = ""
                Dim turnover_s As Decimal = 0
                Dim turnover_f As Decimal = 0
                Dim turnover_o As Decimal = 0
                Dim brokerage_s As Decimal = 0
                Dim brokerage_f As Decimal = 0
                Dim brokerage_o As Decimal = 0
                Dim grp_turnover_s As Decimal = 0
                Dim grp_turnover_f As Decimal = 0
                Dim grp_turnover_o As Decimal = 0
                Dim grp_brokerage_s As Decimal = 0
                Dim grp_brokerage_f As Decimal = 0
                Dim grp_brokerage_o As Decimal = 0
                Dim comm_rate_s As Decimal = 0
                Dim comm_rate_f As Decimal = 0
                Dim comm_rate_o As Decimal = 0
                Dim comm_s As Decimal = 0
                Dim comm_f As Decimal = 0
                Dim comm_o As Decimal = 0

                Dim ldrGrpS As DataRow() = ldsGrpS.Tables(0).Select(" man_no = '" & man_no_s & "' and man_group = '" & man_group_s & "' ")
                If (ldrGrpS.Length > 0) Then
                    If (ldrGrpS(0).Item("turnover_flag_s") = True) Then
                        basis_s = "Turnover"
                    Else
                        basis_s = "Brokerage"
                    End If
                    turnover_s = ldtComm.Rows(i).Item("Total_TO_s")
                    brokerage_s = ldtComm.Rows(i).Item("Total_Brok_s")
                    grp_turnover_s = ldrGrpS(0).Item("turn")
                    grp_brokerage_s = ldrGrpS(0).Item("brok")
                    comm_rate_s = ldrGrpS(0).Item("rate")
                    comm_s = turnover_s * comm_rate_s / 100
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
            End If
        Next

        Return ldtManager

    End Function

    Protected Friend Function lFncLoadRateS(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select * from comm_rate_s where (rate_type = 'MTURN' or rate_type = 'MBROK') and comm_month = '" & txmonth & "'"
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

        lstrSQL = "select distinct man_no, man_group_s as man_group, turnover_flag_s, brokerage_flag_s, " & _
                    "cast(0 as decimal(18,4)) as brok, cast(0 as decimal(18,4)) as turn, cast(0 as decimal(18,4)) as rate " & _
                    "from comm_man_master_d a " & _
                    "inner join comm_ae_master_d b on a.txmonth = b.txmonth and a.man_no = b.man_no_s " & _
                    "where a.txmonth = '" & txmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "GrpS")
        Return lds

    End Function

    Protected Friend Function lFncLoadGrpF(ByVal txmonth As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct man_no, man_group_f as man_group, turnover_flag_f, brokerage_flag_f, " & _
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

End Class
