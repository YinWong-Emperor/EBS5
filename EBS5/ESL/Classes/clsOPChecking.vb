Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class clsOPChecking

    Private Function FncGeteItem(ByVal lstrMCode As String, ByVal lstrSDate As String, ByVal lstrMDflag As String, ByVal lstrPCode As String, ByVal ldPeStrike As Decimal, ByVal ldPnStrike As Decimal, ByVal lstrPCallPut As String) As String
        Dim lstrItem As String = ""
        Dim strike As Decimal = 0
        If ldPeStrike = ldPnStrike Then
            strike = ldPeStrike
        ElseIf ldPeStrike = 0 And ldPnStrike > 0 Then
            strike = ldPnStrike
        Else
            strike = ldPeStrike
        End If

        If GFncNoNullString(lstrMDflag) = "D" Then
            lstrItem = lstrPCode + " " + lstrMCode + " " + lstrSDate + " " + IIf(strike = 0, "", strike.ToString(modGlobal.DecimalFormat)) + " " + lstrPCallPut
        Else
            lstrItem = lstrPCode + " " + lstrMCode + " " + IIf(strike = 0, "", strike.ToString(modGlobal.DecimalFormat)) + " " + lstrPCallPut
        End If

        Return lstrItem

    End Function

    Private Function FncGetSum(ByVal dtData As DataTable, ByVal strType As String, ByVal strMCode As String, _
    ByVal strMDflag As String, ByVal strPCode As String, ByVal strSday As String, ByVal dPeStrike As Decimal, ByVal dPnStrike As Decimal, ByVal strPCallPut As String) As Decimal

        Dim ldecSum As Decimal = 0

        Dim ldr() As DataRow

        If strMDflag = "M" Then
            ldr = dtData.Select("pcode = '" & strPCode & "' and mdflag = '" & _
                         strMDflag & "' and type = '" & _
                         strType & "' and monthcode = '" & strMCode & "' and ( strike = " & dPeStrike & " or strike = " & dPnStrike & " ) and callput = '" & strPCallPut & "' ")


        Else
            ldr = dtData.Select("pcode = '" & strPCode & "' and mdflag = '" & _
                         strMDflag & "' and sday = '" & strSday & "' and type = '" & _
                         strType & "' and monthcode = '" & strMCode & "' and ( strike = " & dPeStrike & " or strike = " & dPnStrike & " ) and callput = '" & strPCallPut & "' ")
        End If

        If ldr.Length > 0 Then
            For lint As Int16 = 0 To ldr.Length - 1
                If Not IsDBNull(ldr(lint).Item("floatingPL")) Then
                    ldecSum += ldr(lint).Item("floatingPL")
                End If
            Next
        End If

        Return ldecSum


    End Function

    Public Function FncGenReport(ByVal pTradeDate As Date, ByVal pCounterParty As String, ByVal pCounterParty2 As String) As ReportClass
        Dim rpt As New rptOPChecking
        rpt.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK
        Dim dtResult As DataTable = New dtsOPChecking.rptOPCheckingDataTable
        Dim dt As DataTable = New DataTable()
        Dim preTradeDate As Date = GetPreTradeDate(pTradeDate)
        Dim eDt As DataTable = New dtsFloatingPL.FloatingPLDataTable
        Dim nDt As DataTable = New dtsFloatingPL.FloatingPLDataTable

        dt = GenDataTabel(pTradeDate, pCounterParty, eDt, nDt)
        For i As Integer = 0 To dt.Rows.Count - 1

            Dim checker As Boolean = False
            Dim checkerInt As Integer = 0
            Dim lstrProduct As String = ""
            For j As Integer = 0 To dtResult.Rows.Count - 1
                lstrProduct = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
                If dtResult.Rows(j).Item("product") = lstrProduct Then
                    checker = True
                    checkerInt = j
                End If
            Next
            If checker = False Then
                dtResult.Rows.Add()
            End If
            Dim rowInt As Integer = dtResult.Rows.Count - 1
            If checker = True Then
                rowInt = checkerInt
            End If
            dtResult.Rows(rowInt).Item("product") = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
            If dt.Rows(i).Item("type") = "L" Then

                dtResult.Rows(rowInt).Item("g2b_1_pl") = GFncNoNullValue(FncGetSum(eDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
                dtResult.Rows(rowInt).Item("1_pl") = GFncNoNullValue(FncGetSum(nDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
            Else
                dtResult.Rows(rowInt).Item("g2b_1_floating") = GFncNoNullValue(FncGetSum(eDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
                dtResult.Rows(rowInt).Item("1_floating") = GFncNoNullValue(FncGetSum(nDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
            End If

        Next

        eDt = New dtsFloatingPL.FloatingPLDataTable
        nDt = New dtsFloatingPL.FloatingPLDataTable
        dt = GenDataTabel(pTradeDate, pCounterParty2, eDt, nDt)
        For i As Integer = 0 To dt.Rows.Count - 1

            'Dim checker As Boolean = False
            'Dim checkerInt As Integer = 0
            'Dim lstrProduct As String = ""
            'For j As Integer = 0 To dtResult.Rows.Count - 1
            '    lstrProduct = dt.Rows(i).Item("pcode") + " " + dt.Rows(i).Item("monthcode")
            '    If dtResult.Rows(j).Item("product") = lstrProduct Then
            '        checker = True
            '        checkerInt = j
            '    End If
            'Next
            'If checker = False Then
            '    dtResult.Rows.Add()
            'End If
            'Dim rowInt As Integer = dtResult.Rows.Count - 1
            'If checker = True Then
            '    rowInt = checkerInt
            'End If
            'dtResult.Rows(rowInt).Item("product") = dt.Rows(i).Item("pcode") + " " + dt.Rows(i).Item("monthcode")
            'If dt.Rows(i).Item("type") = "L" Then
            '    dtResult.Rows(rowInt).Item("g2b_2_pl") = dt.Rows(i).Item("eFloatingPL")
            '    dtResult.Rows(rowInt).Item("2_pl") = dt.Rows(i).Item("nFloatingPL")
            'Else
            '    dtResult.Rows(rowInt).Item("g2b_2_floating") = dt.Rows(i).Item("eFloatingPL")
            '    dtResult.Rows(rowInt).Item("2_floating") = dt.Rows(i).Item("nFloatingPL")
            'End If



            Dim checker As Boolean = False
            Dim checkerInt As Integer = 0
            Dim lstrProduct As String = ""
            For j As Integer = 0 To dtResult.Rows.Count - 1
                lstrProduct = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
                If dtResult.Rows(j).Item("product") = lstrProduct Then
                    checker = True
                    checkerInt = j
                End If
            Next
            If checker = False Then
                dtResult.Rows.Add()
            End If
            Dim rowInt As Integer = dtResult.Rows.Count - 1
            If checker = True Then
                rowInt = checkerInt
            End If
            dtResult.Rows(rowInt).Item("product") = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
            If dt.Rows(i).Item("type") = "L" Then

                dtResult.Rows(rowInt).Item("g2b_2_pl") = GFncNoNullValue(FncGetSum(eDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
                dtResult.Rows(rowInt).Item("2_pl") = GFncNoNullValue(FncGetSum(nDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
            Else
                dtResult.Rows(rowInt).Item("g2b_2_floating") = GFncNoNullValue(FncGetSum(eDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
                dtResult.Rows(rowInt).Item("2_floating") = GFncNoNullValue(FncGetSum(nDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
            End If

        Next

        eDt = New dtsFloatingPL.FloatingPLDataTable
        nDt = New dtsFloatingPL.FloatingPLDataTable
        dt = GenDataTabel(preTradeDate, pCounterParty, eDt, nDt)
        For i As Integer = 0 To dt.Rows.Count - 1

            'Dim checker As Boolean = False
            'Dim checkerInt As Integer = 0
            'Dim lstrProduct As String = ""
            'For j As Integer = 0 To dtResult.Rows.Count - 1
            '    lstrProduct = dt.Rows(i).Item("pcode") + " " + dt.Rows(i).Item("monthcode")
            '    If dtResult.Rows(j).Item("product") = lstrProduct Then
            '        checker = True
            '        checkerInt = j
            '    End If
            'Next
            'If checker = False Then
            '    dtResult.Rows.Add()
            'End If
            'Dim rowInt As Integer = dtResult.Rows.Count - 1
            'If checker = True Then
            '    rowInt = checkerInt
            'End If
            'dtResult.Rows(rowInt).Item("product") = dt.Rows(i).Item("pcode") + " " + dt.Rows(i).Item("monthcode")
            'If dt.Rows(i).Item("type") <> "L" Then
            '    dtResult.Rows(rowInt).Item("pre_g2b_1_floating") = dt.Rows(i).Item("eFloatingPL")
            '    dtResult.Rows(rowInt).Item("pre_broker_1_floating") = dt.Rows(i).Item("nFloatingPL")

            'End If


            Dim checker As Boolean = False
            Dim checkerInt As Integer = 0
            Dim lstrProduct As String = ""
            For j As Integer = 0 To dtResult.Rows.Count - 1
                lstrProduct = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
                If dtResult.Rows(j).Item("product") = lstrProduct Then
                    checker = True
                    checkerInt = j
                End If
            Next
            If checker = False Then
                dtResult.Rows.Add()
            End If
            Dim rowInt As Integer = dtResult.Rows.Count - 1
            If checker = True Then
                rowInt = checkerInt
            End If
            dtResult.Rows(rowInt).Item("product") = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
            If dt.Rows(i).Item("type") <> "L" Then

                dtResult.Rows(rowInt).Item("pre_g2b_1_floating") = GFncNoNullValue(FncGetSum(eDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
                dtResult.Rows(rowInt).Item("pre_broker_1_floating") = GFncNoNullValue(FncGetSum(nDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
            End If
        Next

        eDt = New dtsFloatingPL.FloatingPLDataTable
        nDt = New dtsFloatingPL.FloatingPLDataTable
        dt = GenDataTabel(preTradeDate, pCounterParty2, eDt, nDt)
        For i As Integer = 0 To dt.Rows.Count - 1

            'Dim checker As Boolean = False
            'Dim checkerInt As Integer = 0
            'Dim lstrProduct As String = ""
            'For j As Integer = 0 To dtResult.Rows.Count - 1
            '    lstrProduct = dt.Rows(i).Item("pcode") + " " + dt.Rows(i).Item("monthcode")
            '    If dtResult.Rows(j).Item("product") = lstrProduct Then
            '        checker = True
            '        checkerInt = j
            '    End If
            'Next
            'If checker = False Then
            '    dtResult.Rows.Add()
            'End If
            'Dim rowInt As Integer = dtResult.Rows.Count - 1
            'If checker = True Then
            '    rowInt = checkerInt
            'End If
            'dtResult.Rows(rowInt).Item("product") = dt.Rows(i).Item("pcode") + " " + dt.Rows(i).Item("monthcode")
            'If dt.Rows(i).Item("type") <> "L" Then
            '    dtResult.Rows(rowInt).Item("pre_g2b_2_floating") = dt.Rows(i).Item("eFloatingPL")
            '    dtResult.Rows(rowInt).Item("pre_broker_2_floating") = dt.Rows(i).Item("nFloatingPL")
            'End If

            Dim checker As Boolean = False
            Dim checkerInt As Integer = 0
            Dim lstrProduct As String = ""
            For j As Integer = 0 To dtResult.Rows.Count - 1
                lstrProduct = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
                If dtResult.Rows(j).Item("product") = lstrProduct Then
                    checker = True
                    checkerInt = j
                End If
            Next
            If checker = False Then
                dtResult.Rows.Add()
            End If
            Dim rowInt As Integer = dtResult.Rows.Count - 1
            If checker = True Then
                rowInt = checkerInt
            End If
            dtResult.Rows(rowInt).Item("product") = FncGeteItem(dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput"))
            If dt.Rows(i).Item("type") <> "L" Then

                dtResult.Rows(rowInt).Item("pre_g2b_2_floating") = GFncNoNullValue(FncGetSum(eDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
                dtResult.Rows(rowInt).Item("pre_broker_2_floating") = GFncNoNullValue(FncGetSum(nDt, dt.Rows(i).Item("type"), dt.Rows(i).Item("monthcode"), dt.Rows(i).Item("mdflag"), dt.Rows(i).Item("pcode"), dt.Rows(i).Item("sdate"), dt.Rows(i).Item("eStrike"), dt.Rows(i).Item("nStrike"), dt.Rows(i).Item("pcallput")))
            End If

        Next





        rpt.SetDataSource(dtResult)
        rpt.SetParameterValue("paraUser", GStrloginID)
        rpt.SetParameterValue("paraTdate", pTradeDate)
        rpt.SetParameterValue("paraPreTdate", preTradeDate)
        rpt.SetParameterValue("paraCounterParty", pCounterParty)
        rpt.SetParameterValue("paraCounterParty2", pCounterParty2)
        Return rpt
    End Function

    Public Function GenDataTabel(ByVal pTradeDate As Date, ByVal pCounterParty As String, ByRef eDt As DataTable, _
    ByRef nDt As DataTable) As DataTable
        Dim dt As DataTable = New dtsFloatingPL.MasterDataTable
        'Dim eDt As DataTable = New dtsFloatingPL.FloatingPLDataTable
        'Dim nDt As DataTable = New dtsFloatingPL.FloatingPLDataTable
        'Load Balance
        Dim balDt As DataTable = Nothing
        Dim eOpnBal As Decimal = 0.0
        Dim nOpnBal As Decimal = 0.0
        Dim eClsBal As Decimal = 0.0
        Dim nClsBal As Decimal = 0.0
        Dim openDate As Date = pTradeDate
        Dim str As String = "select * from opening_balance where counterparty = '" & pCounterParty & "'"
        balDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If balDt.Rows.Count > 0 Then
            openDate = GFncNoNullDate(balDt.Rows(0).Item("tDate"))
            eOpnBal = GFncNoNullValue(balDt.Rows(0).Item("opnBal"))
            nOpnBal = GFncNoNullValue(balDt.Rows(0).Item("NopnBal"))
        End If
        str = "select sum(PL) as PL from vw_liq_header where tdate >= '" & Format(openDate, "yyyy/MM/dd") & "' and tdate < '" & Format(pTradeDate, "yyyy/MM/dd") & "' and counterparty = '" & pCounterParty & "'"
        'str = "select sum(PL) as PL from newedge_liq_header where tdate >= '" & Format(openDate, "yyyy/MM/dd") & "' and tdate < '" & tdate & "' and counterparty = '" & pCounterParty & "'"
        balDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If balDt.Rows.Count > 0 Then
            nOpnBal += GFncNoNullValue(balDt.Rows(0).Item("PL"))
        End If
        str = "select sum(PL) as pl from FuturesClosePost where sysdate >= '" & Format(openDate, "yyyy/MM/dd") & _
            "' and counterparty = '" & pCounterParty & "' and sysdate < '" & Format(pTradeDate, "yyyy/MM/dd") & "'"
        balDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If balDt.Rows.Count > 0 Then
            eOpnBal += GFncNoNullValue(balDt.Rows(0).Item("PL"))
        End If
        'str = "select sum(PL) as PL from newedge_liq_header where tdate = '" & tdate & "' and counterparty = '" & pCounterParty & "'"
        str = "select sum(PL) as PL from vw_liq_header where tdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "' and counterparty = '" & pCounterParty & "'"
        balDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If balDt.Rows.Count > 0 Then
            'nClsBal += GFncNoNullValue(balDt.Rows(0).Item("PL")) + nOpnBal
            nClsBal += GFncNoNullValue(balDt.Rows(0).Item("PL"))
        End If
        str = "select sum(PL) as pl from FuturesClosePost where counterparty = '" & pCounterParty & "' and sysdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "'"
        balDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If balDt.Rows.Count > 0 Then
            'eClsBal += GFncNoNullValue(balDt.Rows(0).Item("PL")) + eOpnBal
            eClsBal += GFncNoNullValue(balDt.Rows(0).Item("PL"))
        End If


        Dim ldtAdjOpnBal As DataTable
        Dim eAdjOpnBal As Decimal = 0.0
        Dim nAdjOpnBal As Decimal = 0.0
        Dim lstrAdjRemark As String = ""
        str = " select * from opening_balance_adj " & _
                " where adjtdate >= '" & Format(openDate, "yyyy/MM/dd") & "' " & _
                " and adjtdate <= '" & Format(pTradeDate, "yyyy/MM/dd") & "' " & _
                " and counterparty = '" & pCounterParty & "'"
        ldtAdjOpnBal = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If ldtAdjOpnBal.Rows.Count > 0 Then
            For Each ldrAdjOpnBal As DataRow In ldtAdjOpnBal.Rows
                If ldrAdjOpnBal("Adjtdate") = pTradeDate Then
                    eAdjOpnBal += GFncNoNullValue(ldrAdjOpnBal("AdjOpnBal"))
                    nAdjOpnBal += GFncNoNullValue(ldrAdjOpnBal("AdjNopnBal"))
                    lstrAdjRemark = GFncNoNullString(ldrAdjOpnBal("Adjremark"))
                Else
                    eOpnBal += GFncNoNullValue(ldrAdjOpnBal("AdjOpnBal"))
                    nOpnBal += GFncNoNullValue(ldrAdjOpnBal("AdjNopnBal"))
                End If
            Next
            eClsBal += eAdjOpnBal
            nClsBal += nAdjOpnBal
        End If

        eClsBal += eOpnBal
        nClsBal += nOpnBal
        'Load emperor liq_position and open_position
        str = "(select 'O' as [type], a.code as pcode, b.product_name as product, " & _
            "case when a.type = 1 then qty else 0.0 end as buy, case when a.type = 2 then qty else 0.0 end as sell, " & _
            "a.sysdate as tdate, day(a.settle_date) as sday, a.monthcode, a.contract_size as csize, a.price, " & _
            "a.closing_price as cprice, 0.000000 as lprice, '' as MDFlag, a.accno as ID, " & _
            "case when a.type = 1 then (a.closing_price-a.price) * a.contract_size * a.qty " & _
            "else (a.price - a.closing_price) * a.contract_size * a.qty end as floatingPL, 'F' as used, " & _
            "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
            "from futuresOP a left join futures_product_master b on b.product_code = a.code " & _
            "where a.counterparty = '" & pCounterParty & "' and a.sysdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "') union all " & _
            "(select 'L' as [type], a.code as pcode, b.product_name as product, a.buy, a.sell, a.sysdate as tdate, " & _
            "day(a.settle_date) as sday, a.monthcode, a.contract_size as csize, a.price, 0.000000 as cprice, a.liq_price as lprice, " & _
            "'' as MDFlag, a.accno as ID, a.pl as floatingPL, 'F' as used, " & _
            "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
            "from FuturesClosePost a left join futures_product_master b on b.product_code = a.code " & _
            "where a.counterparty = '" & pCounterParty & "' and a.sysdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "') order by [type] DESC, pcode, tdate, sday"
        eDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        'Load newedge liq_position and open_position
        'str = "(select 'O' as [type], b.d_code as pcode, a.product, a.buy, a.sell, a.tdate, " & _
        '    "day(a.settle_date) as sday, a.monthcode, a.contract_size as csize, a.price, a.closing_price as cprice, 0.000000 as lprice, " & _
        '    "a.monthly_daily as MDFlag, cast(a.noid as nvarchar(20)) as ID, a.floating as floatingPL, 'F' as used " & _
        '    "from newedge_cap_OP a left join product_mapping b on b.d_newedge_code = a.product and a.counterparty = b.d_counterparty " & _
        '    " where a.tdate = '" & tdate & "' and a.counterparty = '" & pCounterParty & "') union all " & _
        '    "(select 'L' as [type], b.d_code as pcode, a.product, a.buy, a.sell, a.tdate, day(a.settle_Date) as sday, a.monthcode, " & _
        '    "a.contract_size as csize, a.price as price, 0.000000 as cprice, a.liq_price as lprice, a.monthly_daily as MDFlag, " & _
        '    "cast(a.noid as nvarchar(20)) as ID, 0.000000 as floatingPL, 'T' as used from newedge_cap_CP a left join product_mapping b on " & _
        '    "b.d_newedge_code = a.product and  a.counterparty = b.d_counterparty where a.tdate = '" & _
        '    tdate & "' and a.counterparty = '" & pCounterParty & "') union all " & _
        '    "(select 'L' as [type], b.d_code as pcode, a.product, 0 as buy, 0 as sell, a.tdate, day(a.settle_date) as sday, a.monthcode, " & _
        '    "a.contract_size as csize, 0.000000 as price, 0.000000 as cprice, 0.000000 as lprice, a.monthly_daily as MDFlag, " & _
        '    "cast(a.nid as nvarchar(20)) as ID, a.PL as floatingPL, 'F' as used from newedge_liq_header a left join product_mapping b on " & _
        '    "b.d_newedge_code = a.product  and  a.counterparty = b.d_counterparty where a.tdate = '" & tdate & "' and a.counterparty = '" & pCounterParty & "') order by [type] DESC, pcode, tdate, sday"
        str = "(select 'O' as [type], b.d_code as pcode, a.product, a.buy, a.sell, a.tdate, " & _
           "day(a.settle_date) as sday, a.monthcode, a.contract_size as csize, a.price, a.closing_price as cprice, 0.000000 as lprice, " & _
           "a.monthly_daily as MDFlag, cast(a.noid as nvarchar(20)) as ID, a.floating as floatingPL, 'F' as used, " & _
           " cast(case when isadjusted='Y' then 1 else 0 end as bit) as isadjusted, " & _
           "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           "from vw_cap_OP a left join product_mapping b on b.d_newedge_code = a.product and a.counterparty = b.d_counterparty " & _
           " where a.tdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=0 AND a.callput='') union all " & _
           "(select 'L' as [type], b.d_code as pcode, a.product, a.buy, a.sell, a.tdate, day(a.settle_Date) as sday, a.monthcode, " & _
           "a.contract_size as csize, a.price as price, 0.000000 as cprice, a.liq_price as lprice, a.monthly_daily as MDFlag, " & _
           "cast(a.noid as nvarchar(20)) as ID, 0.000000 as floatingPL, 'T' as used,  " & _
           " cast(case when isadjusted='Y' then 1 else 0 end as bit) as isadjusted, " & _
           "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           " from vw_cap_CP a left join product_mapping b on " & _
           "b.d_newedge_code = a.product and  a.counterparty = b.d_counterparty where a.tdate = '" & _
           Format(pTradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=0 AND a.callput='' ) union all " & _
           "(select 'L' as [type], b.d_code as pcode, a.product, 0 as buy, 0 as sell, a.tdate, day(a.settle_date) as sday, a.monthcode, " & _
           "a.contract_size as csize, 0.000000 as price, 0.000000 as cprice, 0.000000 as lprice, a.monthly_daily as MDFlag, " & _
           "cast(a.nid as nvarchar(20)) as ID, a.PL as floatingPL, 'F' as used,  " & _
           " cast(case when isadjusted='Y' then 1 else 0 end as bit) as isadjusted, " & _
           "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           " from vw_liq_header a left join product_mapping b on " & _
           "b.d_newedge_code = a.product  and  a.counterparty = b.d_counterparty where a.tdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=0 AND a.callput='') " & _
            "UNION ALL " & _
            "(select 'O' as [type], b.d_code as pcode, a.product, a.buy, a.sell, a.tdate, " & _
           "day(a.settle_date) as sday, a.monthcode, a.contract_size as csize, a.price, a.closing_price as cprice, 0.000000 as lprice, " & _
           "a.monthly_daily as MDFlag, cast(a.noid as nvarchar(20)) as ID, a.floating as floatingPL, 'F' as used, " & _
           " cast(case when isadjusted='Y' then 1 else 0 end as bit) as isadjusted, " & _
           "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           "from vw_cap_OP a left join product_mapping b on b.d_newedge_code = a.product and a.counterparty = b.d_counterparty " & _
           " where a.tdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=1 AND a.callput<>'') union all " & _
           "(select 'L' as [type], b.d_code as pcode, a.product, a.buy, a.sell, a.tdate, day(a.settle_Date) as sday, a.monthcode, " & _
           "a.contract_size as csize, a.price as price, 0.000000 as cprice, a.liq_price as lprice, a.monthly_daily as MDFlag, " & _
           "cast(a.noid as nvarchar(20)) as ID, 0.000000 as floatingPL, 'T' as used,  " & _
           " cast(case when isadjusted='Y' then 1 else 0 end as bit) as isadjusted, " & _
           "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           " from vw_cap_CP a left join product_mapping b on " & _
           "b.d_newedge_code = a.product and  a.counterparty = b.d_counterparty where a.tdate = '" & _
           Format(pTradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=1 AND a.callput<>'') union all " & _
           "(select 'L' as [type], b.d_code as pcode, a.product, 0 as buy, 0 as sell, a.tdate, day(a.settle_date) as sday, a.monthcode, " & _
           "a.contract_size as csize, 0.000000 as price, 0.000000 as cprice, 0.000000 as lprice, a.monthly_daily as MDFlag, " & _
           "cast(a.nid as nvarchar(20)) as ID, a.PL as floatingPL, 'F' as used,  " & _
           " cast(case when isadjusted='Y' then 1 else 0 end as bit) as isadjusted, " & _
           "a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           " from vw_liq_header a left join product_mapping b on " & _
           "b.d_newedge_code = a.product  and  a.counterparty = b.d_counterparty where a.tdate = '" & Format(pTradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=1 AND a.callput<>'') order by [type] DESC, pcode, tdate, sday"
        nDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        'insert MDFlag and closing_price to emperor
        Dim pCode As String = ""
        Dim pStrike As Decimal = 0.0
        Dim pCSize As Decimal = 0.0
        Dim pCallPut As String = ""
        Dim mCode As String = ""
        Dim sDate As Integer = 0
        Dim newedgeDr() As DataRow = Nothing
        Dim type As String = ""
        Dim cprice As Decimal = 0.0
        Dim ePL As Decimal = 0.0
        Dim eFloating As Decimal = 0.0
        Dim nPL As Decimal = 0.0
        Dim nFloating As Decimal = 0.0
        For Each edr As DataRow In eDt.Rows
            If GFncNoNullString(edr("pcode")).Trim = "" Then
                edr("pcode") = "<Not Mapped>"
            End If
            pCode = GFncNoNullString(edr("pcode")).Trim
            pStrike = GFncNoNullStrike(edr("strike"))
            pCSize = GFncNoNullStrike(edr("csize"))
            pCallPut = GFncNoNullString(edr("callput")).Trim
            mCode = GFncNoNullString(edr("monthcode")).Trim
            sDate = GFncNoNullValue(edr("sday"))
            newedgeDr = nDt.Select("pcode = '" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'D' and sDay = " & sDate & " and (strike = " & pStrike & " OR strike*CSize=" & pStrike * pCSize & ") and callput = '" & pCallPut & "'", "")
            If newedgeDr.Length > 0 Then
                edr("MDFlag") = "D"
            Else
                edr("MDFlag") = "M" 'Might be wrong for not-matched products
                newedgeDr = nDt.Select("pcode = '" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'M'" & " and (strike = " & pStrike & " OR strike*CSize=" & pStrike * pCSize & ") and callput = '" & pCallPut & "'", "")
                For i As Integer = 0 To newedgeDr.Length - 1
                    newedgeDr(i).Item("sDay") = sDate
                Next
            End If
            newedgeDr = Nothing
            type = GFncNoNullString(edr("type")).Trim
            If type = "O" Then
                newedgeDr = nDt.Select("pcode = '" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'D' and sDay = " & sDate & " and (strike = " & pStrike & " OR strike*CSize=" & pStrike * pCSize & ") and callput = '" & pCallPut & "'", "")
                If newedgeDr.Length > 0 Then
                    InsertClosingPrice(edr, newedgeDr(0))
                Else
                    newedgeDr = nDt.Select("pcode = '" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'M'" & " and (strike = " & pStrike & " OR strike*CSize=" & pStrike * pCSize & ") and callput = '" & pCallPut & "'", "")
                    If newedgeDr.Length > 0 Then
                        InsertClosingPrice(edr, newedgeDr(0))
                    Else
                        'no price found
                        edr("cprice") = 0.0
                        CalFloating(edr)
                    End If
                End If
            End If
            InsertDr(dt, edr, nDt, "e")
            If GFncNoNullString(edr("type")).Trim = "L" Then
                ePL += GFncNoNullValue(edr("floatingPL"))
            ElseIf GFncNoNullString(edr("type")).Trim = "O" Then
                eFloating += GFncNoNullValue(edr("floatingPL"))
            End If
        Next
        For Each nDr As DataRow In nDt.Rows
            If GFncNoNullString(nDr("pcode")).Trim = "" Then
                nDr("pcode") = "<Not Mapped>"
            End If
            InsertDr(dt, nDr, eDt, "n")
            If GFncNoNullString(nDr("type")).Trim = "L" Then
                nPL += GFncNoNullValue(nDr("floatingPL"))
            ElseIf GFncNoNullString(nDr("type")).Trim = "O" Then
                nFloating += GFncNoNullValue(nDr("floatingPL"))
            End If
        Next
        Dim totalCount As Integer = dt.Rows.Count
        For i As Integer = 0 To totalCount - 1
            If GFncNoNullString(dt.Rows(i).Item("pCode")) = "<Not Mapped>" Then
                dt.Rows(i).Item("product") = "<Not Mapped>"
            End If
            If GFncNoNullString(dt.Rows(i).Item("type")).Trim = "L" Then
                Dim dr As DataRow = dt.NewRow
                dr("pCode") = GFncNoNullString(dt.Rows(i).Item("pcode")).Trim
                dr("eStrike") = GFncNoNullStrike(dt.Rows(i).Item("eStrike"))
                dr("nStrike") = GFncNoNullStrike(dt.Rows(i).Item("nStrike"))
                dr("pcallput") = GFncNoNullString(dt.Rows(i).Item("pcallput")).Trim
                dr("product") = GFncNoNullString(dt.Rows(i).Item("product")).Trim
                dr("monthcode") = GFncNoNullString(dt.Rows(i).Item("monthcode")).Trim
                dr("MDFlag") = GFncNoNullString(dt.Rows(i).Item("MDFlag")).Trim
                dr("sDate") = GFncNoNullValue(dt.Rows(i).Item("sDate"))
                dr("tdate") = GFncNoNullDate(dt.Rows(i).Item("tdate"))
                dr("mapped") = GFncNoNullString(dt.Rows(i).Item("mapped")).Trim
                dr("eFloatingPL") = GFncNoNullValue(dt.Rows(i).Item("eFloatingPL"))
                dr("nFloatingPL") = GFncNoNullValue(dt.Rows(i).Item("nFloatingPL"))
                dr("nName") = GFncNoNullString(dt.Rows(i).Item("nName"))
                dr("mCode") = GFncNoNullDate(dt.Rows(i).Item("mCode"))
                dr("type") = "O"
                dt.Rows.Add(dr)
            End If
        Next
        Return dt
    End Function



    Private Sub InsertClosingPrice(ByRef edr As DataRow, ByVal nDr As DataRow)
        If GFncNoNullValue(nDr("csize")) <> 0 Then
            edr("cprice") = GFncNoNullValue(nDr("cprice")) * GFncNoNullValue(nDr("csize")) / GFncNoNullValue(edr("csize"))
            CalFloating(edr)
        Else
            edr("cprice") = GFncNoNullValue(nDr("cprice"))  'Might be wrong
            CalFloating(edr)
        End If
    End Sub

    Private Sub CalFloating(ByRef edr As DataRow)
        Dim priceDiff = (GFncNoNullValue(edr("cprice")) - GFncNoNullValue(edr("price"))) * GFncNoNullValue(edr("csize"))
        If GFncNoNullValue(edr("buy")) > 0 Then
            edr("floatingPL") = priceDiff * GFncNoNullValue(edr("buy"))
        Else
            edr("floatingPL") = priceDiff * (-1) * GFncNoNullValue(edr("sell"))
        End If
    End Sub

    Private Sub InsertDr(ByRef dt As DataTable, ByRef sdr As DataRow, ByVal sDt As DataTable, ByVal flag As String)
        If GFncNoNullString(sdr("used")).Trim = "T" Then
            Return
        End If
        Dim pCode As String = GFncNoNullString(sdr("pcode")).Trim
        Dim pCSize As String = GFncNoNullString(sdr("cSize")).Trim
        Dim pStrike As Decimal = GFncNoNullStrike(sdr("strike"))
        Dim pCallPut As String = GFncNoNullString(sdr("callput")).Trim
        Dim mCode As String = GFncNoNullString(sdr("monthcode")).Trim
        Dim sDate As Integer = GFncNoNullValue(sdr("sDay"))
        Dim MDFlag As String = GFncNoNullString(sdr("MDFlag")).Trim
        Dim strikeColumn As String = If(flag = "e", "eStrike", "nStrike")
        Dim csizeColumn As String = If(flag = "e", "eCSize", "nCSize")
        Dim tDr() As DataRow = dt.Select("pCode = '" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'D' and sDate = " & sDate & " and (((" & strikeColumn & " = " & pStrike & " OR " & strikeColumn & "*" & csizeColumn & " = " & pStrike * pCSize & " ) and " & csizeColumn & " > 0) or (" & strikeColumn & " = " & pStrike & " and " & csizeColumn & " = 0)) and pcallput = '" & pCallPut & "'", "")
        If tDr.Length > 0 Then
            If flag = "e" Then
                tDr(0).Item("eFloatingPL") = GFncNoNullValue(tDr(0).Item("eFloatingPL")) + GFncNoNullValue(sdr("floatingPL"))
            Else
                tDr(0).Item("nFloatingPL") = GFncNoNullValue(tDr(0).Item("nFloatingPL")) + GFncNoNullValue(sdr("floatingPL"))
            End If
        Else
            tDr = dt.Select("pCode = '" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'M' and (((" & strikeColumn & " = " & pStrike & " OR " & strikeColumn & "*" & csizeColumn & " = " & pStrike * pCSize & " ) and " & csizeColumn & " > 0) or (" & strikeColumn & " = " & pStrike & " and " & csizeColumn & " = 0)) and pcallput = '" & pCallPut & "'", "")
            If tDr.Length > 0 Then
                If flag = "e" Then
                    tDr(0).Item("eFloatingPL") = GFncNoNullValue(tDr(0).Item("eFloatingPL")) + GFncNoNullValue(sdr("floatingPL"))
                Else
                    tDr(0).Item("nFloatingPL") = GFncNoNullValue(tDr(0).Item("nFloatingPL")) + GFncNoNullValue(sdr("floatingPL"))
                End If
            Else
                Dim dr As DataRow = dt.NewRow
                dr("pCode") = pCode
                If flag = "e" Then
                    dr("eStrike") = pStrike
                    dr("eCSize") = pCSize
                    dr("nStrike") = 0
                    dr("nCSize") = 0
                Else
                    dr("nStrike") = pStrike
                    dr("nCSize") = pCSize
                    dr("eStrike") = 0
                    dr("eCSize") = 0
                End If
                dr("pcallput") = pCallPut
                dr("product") = GFncNoNullString(sdr("product")).Trim
                dr("monthcode") = mCode
                dr("MDFlag") = MDFlag
                dr("sDate") = sDate
                dr("type") = "L"
                dr("tdate") = GFncNoNullDate(sdr("tdate"))
                Dim sourceDr() As DataRow = sDt.Select("pCode ='" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'D' and sDay = " & sDate & " and (((strike = " & pStrike & " OR strike*csize  = " & pStrike * pCSize & " ) and csize > 0) or (strike = " & pStrike & " and csize = 0)) and callput = '" & pCallPut & "'", "")
                If sourceDr.Length > 0 Then
                    dr("mapped") = "T"
                    If flag = "e" Then
                        dr("nStrike") = sourceDr(0)("strike")
                        dr("nCSize") = sourceDr(0)("csize")
                    Else
                        dr("eStrike") = sourceDr(0)("strike")
                        dr("eCSize") = sourceDr(0)("csize")
                    End If
                Else
                    sourceDr = sDt.Select("pCode ='" & pCode & "' and monthcode = '" & mCode & "' and MDFlag = 'M' and (((strike = " & pStrike & " OR strike*csize  = " & pStrike * pCSize & ") and csize > 0) or (strike = " & pStrike & " and csize = 0)) and callput = '" & pCallPut & "'", "")
                    If sourceDr.Length > 0 Then
                        dr("mapped") = "T"
                        If flag = "e" Then
                            dr("nStrike") = sourceDr(0)("strike")
                            dr("nCSize") = sourceDr(0)("csize")
                        Else
                            dr("eStrike") = sourceDr(0)("strike")
                            dr("eCSize") = sourceDr(0)("csize")
                        End If
                    Else
                        If GFncNoNullString(dr("pcode")) <> "" And GFncNoNullString(dr("pcode")) <> "<Not Mapped>" Then
                            dr("mapped") = "T"
                        Else
                            dr("mapped") = "F"
                        End If
                    End If
                End If
                If flag = "e" Then
                    If sourceDr.Length > 0 Then
                        dr("nName") = GFncNoNullString(sourceDr(0).Item("product")).Trim
                    Else
                        dr("nName") = "<Not Mapped>"
                    End If
                Else
                    dr("nName") = GFncNoNullString(sdr("product")).Trim
                    sourceDr = sDt.Select("pCode ='" & pCode & "'", "")
                    If sourceDr.Length > 0 Then
                        dr("product") = GFncNoNullString(sourceDr(0).Item("product")).Trim
                    End If
                End If
                'Fix bug 2013/01/13 Andrew
                'dr("mCode") = Format(CDate("20" & CStr(mCode.Substring(0, 2)) & "/" & CStr(mCode.Substring(2, 2)) & "/" & sDate.ToString.PadLeft(2, "0")), "yyyy/MM/dd")
                dr("mCode") = Format(CDate("20" & CStr(mCode.Substring(0, 2)) & "/" & CStr(mCode.Substring(2, 2)) & "/" & "01"), "yyyy/MM/dd")
                dt.Rows.Add(dr)
                'Fix bug 2013/01/13 Andrew
                InsertFloatingPL(dr, sdr, flag)
            End If
        End If
        sdr("used") = "T"
    End Sub

    Private Sub InsertFloatingPL(ByRef dr As DataRow, ByVal sdr As DataRow, ByVal flag As String)
        If flag = "e" Then
            dr("eFloatingPL") = GFncNoNullValue(dr("eFloatingPL")) + GFncNoNullValue(sdr("floatingPL"))
        Else
            dr("nFloatingPL") = GFncNoNullValue(dr("nFloatingPL")) + GFncNoNullValue(sdr("floatingPL"))
        End If
    End Sub

    Private Function GetPreTradeDate(ByVal pTradeDate As Date) As Date
        Dim str As String = "select DISTINCT tdate from newedge_content where convert(datetime,tdate) < '" & Format(pTradeDate, "yyyy/MM/dd") & "'" & _
        "order by tdate DESC"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        If dt.Rows.Count > 1 Then
            Return dt.Rows(0).Item("tdate")
        End If

        Return pTradeDate

    End Function


End Class
