Imports System.IO
Public Class clsExportForeignMarket

    Protected Friend Function lFncForeignMarketByMarket(ByVal lstrSQL As String, ByVal sMarket As String, ByVal sComm As String, ByVal strExFile As String) As Boolean


        Dim ldtsTemp As DataSet
        Dim ldtTemp As DataTable


        Dim lstr As String = "SELECT " & _
        "rpt.client_type, " & _
        "rpt.accno, " & _
        "rpt.name_1, " & _
        "rpt.name_1_c, " & _
        "rpt.aeno, " & _
        "rpt.name_s, " & _
        "rpt.fee, " & _
        "rpt.name, " & _
        "ISNULL(rpt.ServiceStartDate,'') AS ServiceStartDate " & _
        "FROM " & _
            "( " & _
                "SELECT " & _
                "cm.aid, " & _
                "cm.accno, " & _
                "cm.name_1, " & _
                "cm.name_1_c, " & _
                "cm.client_type, " & _
                "cm.aeno, " & _
                "cm.name_s, " & _
                "fee.fee, " & _
                "fee.name, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) END AS ServiceStartDate, " & _
                "ssd.RiskDisclosure " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                    "cm.aid, " & _
                    "cm.accno, " & _
                    "cm.name_1, " & _
                    "cm.name_1_c, " & _
                    "cm.client_type, " & _
                    "cm.aeno, " & _
                    "cm.name_s " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                        "cm.aid, " & _
                        "cm.accno, " & _
                        "cm.name_1, " & _
                        "cm.name_1_c, " & _
                        "CASE " & _
                        "WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' " & _
                        "ELSE 'Securities' " & _
                        "END AS client_type, " & _
                        "ae.aeno, " & _
                        "mc.name_s " & _
                        "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.client_master_s cms  " & _
                        "ON cm.aid=cms.aid	" & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.ae_master AS ae " & _
                        "ON ae.aeid = cms.aeid AND ae.cmid = cms.cmid " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT mm.name_s, mc.aid FROM " & GStrG2BSDB & ".dbo.market_client mc INNER JOIN " & GStrG2BSDB & ".dbo.market_master mm ON mm.mkid = mc.mkid WHERE mm.name_s = '" & sMarket & "'" & _
                        ") mc " & _
                        "ON mc.aid = cms.aid " & _
                    ") cm " & _
                    "WHERE cm.client_type='Securities' " & _
                ") cm " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT " & _
                    "cfbp.aid, " & _
                    "feebp.name AS fee, " & _
                    "fnm.name " & _
                    "FROM " & _
                    "( " & _
                        "Select aid, fid, fuid FROM " & GStrG2BSDB & ".dbo.Client_Fee AS cfbp " & _
                        "WHERE EXISTS " & _
                        "( " & _
                            "SELECT 1 FROM " & GStrG2BSDB & ".dbo.market_master AS mm WHERE mm.mkid=cfbp.mkid AND mm.name_s='" & sMarket & "'" & _
                        ")" & _
                        " AND cfbp.fuid = '" & sComm & "'" & _
                    ") cfbp " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fid, name FROM " & GStrG2BSDB & ".dbo.fee_master " & _
                    ") feebp " & _
                    "ON feebp.fid = cfbp.fid " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fuid, name FROM " & GStrG2BSDB & ".dbo.FeeNature_master " & _
                    ") fnm " & _
                    "ON fnm.fuid=cfbp.fuid " & _
                ") fee ON fee.aid=cm.aid " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT afi.AccNo, afi.ServiceStartDate, " & _
                        "CASE WHEN afi.RiskDisclosure=1 THEN 'Yes' ELSE 'No' END AS RiskDisclosure " & _
                    "FROM " & GStrConDB & ".dbo.AccountForeignInfo afi WHERE afi.market='" & sMarket & "' " & _
                ") ssd ON ssd.AccNo=cm.AccNo collate database_default " & _
            ") rpt " & _
        "order by accno ASC "
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstr, 0)

        If (ldtsTemp.Tables(0).Rows.Count > 0) Then
            ldtTemp = ldtsTemp.Tables(0)

            Dim sBrokerage As String
            sBrokerage = GetBrokerageName(ldtTemp)

            ldtTemp.Columns.Remove("name")
            ExportCSV(GStrExptDir, strExFile, ldtsTemp, " AccountType, accno,name_1, name_1_c, aeno, Market, " & sBrokerage & ", Service Start Date ")
            Return True
        End If

        GSubShowInfo(GFncGetSysMsg(2))


        Return False

    End Function
    Protected Friend Function lFncForeignMarketByMarketSSE(ByVal lstrSQL As String, ByVal sMarket As String, ByVal sComm As String, ByVal strExFile As String) As Boolean


        Dim ldtsTemp As DataSet
        Dim ldtTemp As DataTable


        Dim lstr As String = "SELECT " & _
        "rpt.client_type, " & _
        "rpt.accno, " & _
        "rpt.name_1, " & _
        "rpt.name_1_c, " & _
        "rpt.aeno, " & _
        "rpt.name_s, " & _
        "rpt.fee, " & _
        "rpt.name, " & _
        "ISNULL(rpt.ServiceStartDate,'') AS ServiceStartDate, " & _
        "ISNULL(rpt.RiskDisclosure, '') AS RiskDisclosure " & _
        "FROM " & _
            "( " & _
                "SELECT " & _
                "cm.aid, " & _
                "cm.accno, " & _
                "cm.name_1, " & _
                "cm.name_1_c, " & _
                "cm.client_type, " & _
                "cm.aeno, " & _
                "cm.name_s, " & _
                "fee.fee, " & _
                "fee.name, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) END AS ServiceStartDate, " & _
                "ssd.RiskDisclosure " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                    "cm.aid, " & _
                    "cm.accno, " & _
                    "cm.name_1, " & _
                    "cm.name_1_c, " & _
                    "cm.client_type, " & _
                    "cm.aeno, " & _
                    "cm.name_s " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                        "cm.aid, " & _
                        "cm.accno, " & _
                        "cm.name_1, " & _
                        "cm.name_1_c, " & _
                        "CASE " & _
                        "WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' " & _
                        "ELSE 'Securities' " & _
                        "END AS client_type, " & _
                        "ae.aeno, " & _
                        "mc.name_s " & _
                        "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.client_master_s cms  " & _
                        "ON cm.aid=cms.aid	" & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.ae_master AS ae " & _
                        "ON ae.aeid = cms.aeid AND ae.cmid = cms.cmid " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT mm.name_s, mc.aid FROM " & GStrG2BSDB & ".dbo.market_client mc INNER JOIN " & GStrG2BSDB & ".dbo.market_master mm ON mm.mkid = mc.mkid WHERE mm.name_s = '" & sMarket & "'" & _
                        ") mc " & _
                        "ON mc.aid = cms.aid " & _
                    ") cm " & _
                    "WHERE cm.client_type='Securities' " & _
                ") cm " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT " & _
                    "cfbp.aid, " & _
                    "feebp.name AS fee, " & _
                    "fnm.name " & _
                    "FROM " & _
                    "( " & _
                        "Select aid, fid, fuid FROM " & GStrG2BSDB & ".dbo.Client_Fee AS cfbp " & _
                        "WHERE EXISTS " & _
                        "( " & _
                            "SELECT 1 FROM " & GStrG2BSDB & ".dbo.market_master AS mm WHERE mm.mkid=cfbp.mkid AND mm.name_s='" & sMarket & "'" & _
                        ")" & _
                        " AND cfbp.fuid = '" & sComm & "'" & _
                    ") cfbp " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fid, name FROM " & GStrG2BSDB & ".dbo.fee_master " & _
                    ") feebp " & _
                    "ON feebp.fid = cfbp.fid " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fuid, name FROM " & GStrG2BSDB & ".dbo.FeeNature_master " & _
                    ") fnm " & _
                    "ON fnm.fuid=cfbp.fuid " & _
                ") fee ON fee.aid=cm.aid " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT afi.AccNo, afi.ServiceStartDate, " & _
                    "CASE WHEN afi.RiskDisclosure=1 THEN 'Yes' ELSE 'No' END AS RiskDisclosure " & _
                    "FROM " & GStrConDB & ".dbo.AccountForeignInfo afi WHERE afi.market='" & sMarket & "' " & _
                ") ssd ON ssd.AccNo=cm.AccNo collate database_default " & _
            ") rpt " & _
        "order by accno ASC "
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstr, 0)

        If (ldtsTemp.Tables(0).Rows.Count > 0) Then
            ldtTemp = ldtsTemp.Tables(0)

            Dim sBrokerage As String
            sBrokerage = GetBrokerageName(ldtTemp)

            ldtTemp.Columns.Remove("name")
            ExportCSV(GStrExptDir, strExFile, ldtsTemp, " AccountType, accno,name_1, name_1_c, aeno, Market, " & sBrokerage & ", Service Start Date, RiskDisclosure ")
            Return True
        End If

        GSubShowInfo(GFncGetSysMsg(2))


        Return False

    End Function
    Protected Friend Function lFncForeignMarketByMarketSG(ByVal lstrSQL As String, ByVal sMarket As String, ByVal sComm As String, ByVal strExFile As String) As Boolean


        Dim ldtsTemp As DataSet
        Dim ldtTemp As DataTable


        Dim lstr As String = "SELECT " & _
        "rpt.client_type, " & _
        "rpt.accno, " & _
        "rpt.name_1, " & _
        "rpt.name_1_c, " & _
        "rpt.aeno, " & _
        "rpt.name_s, " & _
        "rpt.fee, " & _
        "rpt.name, " & _
        "ISNULL(rpt.ServiceStartDate,'') AS ServiceStartDate, " & _
        "rpt.external_accno " & _
        "FROM " & _
            "( " & _
                "SELECT " & _
                "cm.aid, " & _
                "cm.accno, " & _
                "cm.name_1, " & _
                "cm.name_1_c, " & _
                "cm.client_type, " & _
                "cm.aeno, " & _
                "cm.name_s, " & _
                "fee.fee, " & _
                "fee.name, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) END AS ServiceStartDate, " & _
                "cm.external_accno " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                    "cm.aid, " & _
                    "cm.accno, " & _
                    "cm.name_1, " & _
                    "cm.name_1_c, " & _
                    "cm.client_type, " & _
                    "cm.aeno, " & _
                    "cm.name_s, " & _
                    "cm.external_accno " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                        "cm.aid, " & _
                        "cm.accno, " & _
                        "cm.name_1, " & _
                        "cm.name_1_c, " & _
                        "CASE " & _
                        "WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' " & _
                        "ELSE 'Securities' " & _
                        "END AS client_type, " & _
                        "ae.aeno, " & _
                        "mc.name_s, " & _
                        "cm.external_accno " & _
                        "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.client_master_s cms  " & _
                        "ON cm.aid=cms.aid	" & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.ae_master AS ae " & _
                        "ON ae.aeid = cms.aeid AND ae.cmid = cms.cmid " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT mm.name_s, mc.aid FROM " & GStrG2BSDB & ".dbo.market_client mc INNER JOIN " & GStrG2BSDB & ".dbo.market_master mm ON mm.mkid = mc.mkid WHERE mm.name_s = '" & sMarket & "'" & _
                        ") mc " & _
                        "ON mc.aid = cms.aid " & _
                    ") cm " & _
                    "WHERE cm.client_type='Securities' " & _
                ") cm " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT " & _
                    "cfbp.aid, " & _
                    "feebp.name AS fee, " & _
                    "fnm.name " & _
                    "FROM " & _
                    "( " & _
                        "Select aid, fid, fuid FROM " & GStrG2BSDB & ".dbo.Client_Fee AS cfbp " & _
                        "WHERE EXISTS " & _
                        "( " & _
                            "SELECT 1 FROM " & GStrG2BSDB & ".dbo.market_master AS mm WHERE mm.mkid=cfbp.mkid AND mm.name_s='" & sMarket & "'" & _
                        ")" & _
                        " AND cfbp.fuid = '" & sComm & "'" & _
                    ") cfbp " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fid, name FROM " & GStrG2BSDB & ".dbo.fee_master " & _
                    ") feebp " & _
                    "ON feebp.fid = cfbp.fid " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fuid, name FROM " & GStrG2BSDB & ".dbo.FeeNature_master " & _
                    ") fnm " & _
                    "ON fnm.fuid=cfbp.fuid " & _
                ") fee ON fee.aid=cm.aid " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT afi.AccNo, afi.ServiceStartDate FROM " & GStrConDB & ".dbo.AccountForeignInfo afi WHERE afi.market='" & sMarket & "' " & _
                ") ssd ON ssd.AccNo=cm.AccNo collate database_default " & _
            ") rpt " & _
            "order by accno ASC "
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstr, 0)

        If (ldtsTemp.Tables(0).Rows.Count > 0) Then
            ldtTemp = ldtsTemp.Tables(0)
            Dim sBrokerage As String
            sBrokerage = GetBrokerageName(ldtTemp)
            ldtTemp.Columns.Remove("name")
            ExportCSV(GStrExptDir, strExFile, ldtsTemp, " AccountType, accno,name_1, name_1_c, aeno, Market, " & sBrokerage & ", Service Start Date, external_account_no")
            Return True
        End If

        GSubShowInfo(GFncGetSysMsg(2))


        Return False

    End Function
    Protected Friend Function lFncForeignMarketByMarketUS(ByVal lstrSQL As String, ByVal sMarket As String, ByVal sComm As String, ByVal strExFile As String) As Boolean


        Dim ldtsTemp As DataSet
        Dim ldtTemp As DataTable


        Dim lstr As String = "SELECT " & _
        "rpt.client_type, " & _
        "rpt.accno, " & _
        "rpt.client_type1, " & _
        "rpt.name_1, " & _
        "rpt.name_1_c, " & _
        "rpt.aeno, " & _
        "rpt.name_s, " & _
        "rpt.Channel, " & _
        "rpt.fee, " & _
        "rpt.name, " & _
        "ISNULL(rpt.ServiceStartDate,'') AS ServiceStartDate, " & _
        "rpt.w8_form_date, " & _
        "ISNULL(rpt.UVOTCMarketStartDate, '') AS UVOTCMarketStartDate, " & _
        "rpt.iTradeStartDate, " & _
        "rpt.external_accno, " & _
        "rpt.suspend_field, " & _
        "rpt.suspend_code, " & _
        "rpt.date_suspend, " & _
        "rpt.startdate, " & _
        "rpt.enddate " & _
        "FROM " & _
            "( " & _
                "SELECT " & _
                "cm.aid, " & _
                "cm.client_type, " & _
                "cm.accno, " & _
                "cm.client_type1, " & _
                "cm.name_1, " & _
                "cm.name_1_c, " & _
                "cm.aeno, " & _
                "cm.name_s, " & _
                "ssd.Channel, " & _
                "fee.fee, " & _
                "fee.name, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.ServiceStartDate,''), 103) END AS ServiceStartDate, " & _
                "cm.w8_form_date, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.UVOTCMarketStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.UVOTCMarketStartDate,''), 103) END AS UVOTCMarketStartDate, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.iTradeStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.iTradeStartDate,''), 103) END AS iTradeStartDate, " & _
                "cm.external_accno, " & _
                "cm.suspend_field, " & _
                "cm.suspend_code, " & _
                "cm.date_suspend, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.startdate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.startdate,''), 103) END AS startdate, " & _
                "CASE WHEN CONVERT(VARCHAR(30), ISNULL(ssd.enddate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(ssd.enddate,''), 103) END AS enddate " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                    "cm.aid, " & _
                    "cm.accno, " & _
                    "cm.client_type1, " & _
                    "cm.name_1, " & _
                    "cm.name_1_c, " & _
                    "cm.client_type, " & _
                    "cm.aeno, " & _
                    "cm.name_s, " & _
                    "cm.w8_form_date, " & _
                    "cm.external_accno, " & _
                    "cm.suspend_field, " & _
                    "cm.suspend_code, " & _
                    "cm.date_suspend " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                        "cm.aid, " & _
                        "cm.accno, " & _
                        "CASE cms.type WHEN '2' THEN 'Cash' WHEN '1' THEN 'Margin' END AS client_type1, " & _
                        "cm.name_1, " & _
                        "cm.name_1_c, " & _
                        "CASE " & _
                        "WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' " & _
                        "ELSE 'Securities' " & _
                        "END AS client_type, " & _
                        "ae.aeno, " & _
                        "mc.name_s, " & _
                        "localcm.w8_form_date, " & _
                        "cm.external_accno, " & _
                        "CASE rtrim(isnull(sus.sreason, '')) " & _
                        "WHEN '' THEN 'No' " & _
                        "Else 'Yes' " & _
                        "END AS suspend_field, " & _
                        "RTRIM(ISNULL(sus.sreason, '')) AS suspend_code, " & _
                        "cm.sus_date AS date_suspend " & _
                        "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.suspense_master AS sus " & _
                        "ON cm.spid = sus.spid " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.client_master_s cms  " & _
                        "ON cm.aid=cms.aid	" & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BSDB & ".dbo.ae_master AS ae " & _
                        "ON ae.aeid = cms.aeid AND ae.cmid = cms.cmid " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT mm.name_s, mc.aid FROM " & GStrG2BSDB & ".dbo.market_client mc INNER JOIN " & GStrG2BSDB & ".dbo.market_master mm ON mm.mkid = mc.mkid WHERE mm.name_s = '" & sMarket & "'" & _
                        ") mc " & _
                        "ON mc.aid = cms.aid " & _
                        "INNER JOIN " & _
                        "( " & _
                            " SELECT cm.acc_no, cm.client_type, CASE WHEN CONVERT(VARCHAR(30), ISNULL(cm.w8_form_date,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(cm.w8_form_date,''), 103) END AS w8_form_date FROM " & GStrConDB & ".dbo.client_master cm WHERE cm.client_type='Securities'" & _
                        ") localcm " & _
                        "ON localcm.acc_no = cm.accno collate database_default AND localcm.client_type = CASE WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' ELSE 'Securities' END " & _
                    ") cm " & _
                    "WHERE cm.client_type='Securities' " & _
                ") cm " & _
                "LEFT OUTER Join " & _
                "( " & _
                    "SELECT " & _
                    "cfbp.aid, " & _
                    "feebp.name AS fee, " & _
                    "fnm.name " & _
                    "FROM " & _
                    "( " & _
                        "Select aid, fid, fuid FROM " & GStrG2BSDB & ".dbo.Client_Fee AS cfbp " & _
                        "WHERE EXISTS " & _
                        "( " & _
                            "SELECT 1 FROM " & GStrG2BSDB & ".dbo.market_master AS mm WHERE mm.mkid=cfbp.mkid AND mm.name_s='" & sMarket & "'" & _
                        ")" & _
                        " AND cfbp.fuid = '" & sComm & "'" & _
                    ") cfbp " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fid, name FROM " & GStrG2BSDB & ".dbo.fee_master " & _
                    ") feebp " & _
                    "ON feebp.fid = cfbp.fid " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT fuid, name FROM " & GStrG2BSDB & ".dbo.FeeNature_master " & _
                    ") fnm " & _
                    "ON fnm.fuid=cfbp.fuid " & _
                ") fee ON fee.aid=cm.aid " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT " & _
                        "afi.AccNo, " & _
                        "CASE WHEN afi.Channel='P' THEN 'P' ELSE 'P&I' END AS Channel, " & _
                        "afi.ServiceStartDate, " & _
                        "afi.iTradeStartDate, " & _
                        "afi.UVOTCMarketStartDate, " & _
                        "asi.startdate, " & _
                        "asi.enddate " & _
                    "FROM " & _
                    "" & GStrConDB & ".dbo.AccountForeignInfo afi " & _
                    "INNER JOIN " & _
                    "" & GStrConDB & ".dbo.AdvServiceInfo asi " & _
                    "ON asi.accno = afi.accno AND asi.Market = afi.Market " & _
                    "WHERE afi.market='" & sMarket & "' " & _
                ") ssd ON ssd.AccNo=cm.AccNo collate database_default " & _
            ") rpt " & _
            "order by accno ASC "

        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstr, 0)

        If (ldtsTemp.Tables(0).Rows.Count > 0) Then
            ldtTemp = ldtsTemp.Tables(0)
            Dim sBrokerage As String
            sBrokerage = GetBrokerageName(ldtTemp)
            ldtTemp.Columns.Remove("name")
            ExportCSV(GStrExptDir, strExFile, ldtsTemp, "AccountType, accno, client_type, name_1, name_1_c, aeno, Market, Order Placing Mode, " & sBrokerage & ",Service Start Date, W form Signing Date, UV (OTC Market) Start Date, i-trade(send password), external_account_no, suspend_field, suspend_code, date_suspend, Streaming Quotation Start Date, Streaming Quotation End Date")
            'ExportCSV(GStrExptDir, strExFile, ldtsTemp, " AccountType, accno,name_1, name_1_c, aeno, Market, " & sBrokerage & ", Service Start Date, external_account_no")
            Return True
        End If

        GSubShowInfo(GFncGetSysMsg(2))


        Return False

    End Function

    Protected Friend Function lFncForeignMarketByMarketIB(ByVal lstrSQL As String, ByVal sMarket As String, ByVal sComm As String, ByVal strExFile As String) As Boolean

        Dim ldtsTemp As DataSet
        'Dim ldtTemp As DataTable



        Dim lstr As String = "SELECT " & _
        "rpt.client_type, " & _
        "rpt.accno, " & _
        "rpt.name_1, " & _
        "rpt.aeno, " & _
        "ISNULL(rpt.Platform,'') AS Platform, " & _
        "ISNULL(rpt.ThirdPartyAccNo,'') ThirdPartyAccNo, " & _
        "ISNULL(rpt.ThirdPartyUsername,'') AS ThirdPartyUsername, " & _
        "ISNULL(rpt.Remarks,'') AS Remarks, " & _
        "ISNULL(rpt.ServiceStartDate,'') AS ServiceStartDate, " & _
        "rpt.w8_form_date, " & _
        "ISNULL(rpt.suspend_field,'') AS suspend_field, " & _
        "ISNULL(rpt.suspend_code,'') AS suspend_code, " & _
        "rpt.date_suspend " & _
        "FROM " & _
            "( " & _
                "SELECT " & _
                "cm.aid, " & _
                "cm.client_type, " & _
                "cm.accno, " & _
                "cm.name_1, " & _
                "cm.aeno, " & _
                "tp.Platform, " & _
                "tp.ThirdPartyAccNo, " & _
                "tp.ThirdPartyUsername, " & _
                "tp.Remarks, " & _
                "tp.ServiceStartDate, " & _
                "cm.w8_form_date, " & _
                "cm.suspend_field, " & _
                "cm.suspend_code, " & _
                "cm.date_suspend " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                    "cm.aid, " & _
                    "cm.client_type, " & _
                    "cm.accno, " & _
                    "cm.name_1, " & _
                    "cm.aeno, " & _
                    "cm.w8_form_date, " & _
                    "cm.suspend_field, " & _
                    "cm.suspend_code, " & _
                    "cm.date_suspend " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                        "cm.aid, " & _
                        "cm.accno, " & _
                        "cm.name_1, " & _
                        "cm.name_1_c, " & _
                        "CASE " & _
                        "WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' " & _
                        "ELSE 'Futures' " & _
                        "END AS client_type, " & _
                        "ae.aeno, " & _
                        "localcm.w8_form_date, " & _
                        "CASE rtrim(isnull(sus.sreason, '')) " & _
                        "WHEN '' THEN 'No' " & _
                        "Else 'Yes' " & _
                        "END AS suspend_field, " & _
                        "RTRIM(ISNULL(sus.sreason, '')) AS suspend_code, " & _
                        "cms.date_close AS date_suspend " & _
                        "FROM " & GStrG2BFDB & ".dbo.client_master cm " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BFDB & ".dbo.suspense_master AS sus " & _
                        "ON cm.spid = sus.spid " & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BFDB & ".dbo.client_master_f cms  " & _
                        "ON cm.aid=cms.aid	" & _
                        "LEFT OUTER JOIN " & _
                            "" & GStrG2BFDB & ".dbo.ae_master AS ae " & _
                        "ON ae.aeid = cms.aeid AND ae.cmid = cms.cmid " & _
                        "LEFT OUTER JOIN " & _
                        "( " & _
                            " SELECT cm.acc_no, cm.client_type, CASE WHEN CONVERT(VARCHAR(30), ISNULL(cm.w8_form_date,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(cm.w8_form_date,''), 103) END AS w8_form_date FROM " & GStrConDB & ".dbo.client_master cm WHERE cm.client_type='Futures'" & _
                        ") localcm " & _
                        "ON localcm.acc_no = cm.accno collate database_default AND localcm.client_type = CASE WHEN SUBSTRING(cm.accno,1,3) ='500' THEN 'CIES' ELSE 'Futures' END " & _
                    ") cm " & _
                    "WHERE cm.client_type='Futures' " & _
                ") cm " & _
                "INNER JOIN " & _
                "( " & _
                    "SELECT " & _
                        "tpamapp.AccNo, " & _
                        "tpamapp.Platform, " & _
                        "tpam.ThirdPartyAccNo, " & _
                        "tpam.ThirdPartyUsername, " & _
                        "tpam.Remarks, " & _
                        "CASE WHEN CONVERT(VARCHAR(30), ISNULL(tpamapp.ServiceStartDate,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(tpamapp.ServiceStartDate,''), 103) END AS ServiceStartDate " & _
                    "FROM " & _
                    "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
                    "INNER JOIN " & _
                    "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
                    "ON tpam.Platform = tpamapp.Platform AND tpam.ThirdPartyAccNo = tpamapp.ThirdPartyAccNo " & _
                    "WHERE tpamapp.Platform='" & sMarket & "' " & _
                ") tp ON tp.AccNo=cm.AccNo collate database_default " & _
            ") rpt " & _
            "order by accno ASC "

        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstr, 0)

        If (ldtsTemp.Tables(0).Rows.Count > 0) Then

            ExportCSV(GStrExptDir, strExFile, ldtsTemp, "AccountType, accno, name_1, aeno, Platform, ib_account_no, ib_username, ib_remarks, ib_servicestartsate, W form Signing Date, suspend_field, suspend_code, date_close")
            'ExportCSV(GStrExptDir, strExFile, ldtsTemp, " AccountType, accno,name_1, name_1_c, aeno, Market, " & sBrokerage & ", Service Start Date, external_account_no")
            Return True
        End If

        GSubShowInfo(GFncGetSysMsg(2))


        Return False

    End Function

    Public Function ExportCSV(ByVal strExptDir As String, ByVal strExptFilename As String, _
                                ByVal ldtsData As DataSet, ByVal strHeader As String) As Boolean

        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtcData As DataColumn
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        Try
            lstrFiles = System.IO.Directory.GetFiles(strExptDir, strExptFilename)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            lsWriter = New StreamWriter(strExptDir & strExptFilename, False, System.Text.Encoding.UTF8)
            lstrColValue = strHeader
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()

            For Each ldtwData In ldtsData.Tables(0).Rows
                lstrColValue = ""
                For Each ldtcData In ldtsData.Tables(0).Columns
                    If (lstrColValue.Length > 0) Then
                        lstrColValue += ","
                    End If

                    If (ldtcData.DataType.Name = "String") Then
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += "=""" & Trim(Replace(Replace(Replace(Replace(ldtwData(ldtcData.ColumnName), ",", ";"), _
                                            Chr(10), ""), Chr(12), ""), Chr(13), "")) & """"
                        End If
                    Else
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += Trim(CStr(ldtwData(ldtcData.ColumnName)))
                        End If
                    End If
                Next
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()

            Next
            lstrColValue = ""
            lsWriter.WriteLine(lstrColValue)


            lstrColValue = "=""" & Trim(Replace(Replace(Replace(Replace("Total", ",", ";"), _
                                            Chr(10), ""), Chr(12), ""), Chr(13), "")) & """"
            lstrColValue += ","
            lstrColValue += "="" " & ldtsData.Tables(0).Rows.Count & " accounts"""
            lsWriter.WriteLine(lstrColValue)

            lsWriter.Close()

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try

    End Function
    Public Function GetBrokerageName(ByVal dt As DataTable) As String
        Dim sBrokerage As String
        sBrokerage = String.Empty
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row.Item("name")) Then
                sBrokerage = row.Item("name").ToString
                Return sBrokerage
            End If
        Next
        Return sBrokerage
    End Function
End Class
