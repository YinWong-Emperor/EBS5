Public Class ClsIRS
    Protected Friend Function lFnGetFinancialYear() As DataSet
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "" & _
        "SELECT " & _
            "CONVERT(VARCHAR(30), ISNULL(MAX(tdate),''), 103) AS tdate " & _
        "FROM " & _
            "" & GStrConDB & ".dbo.exchangerate " & _
        "WHERE tdate BETWEEN DATEADD(yy, DATEDIFF(yy,0,DATEADD(yy,-1,getdate())), 0) AND DATEADD(yy, DATEDIFF(yy,0,DATEADD(yy,-1,getdate())) + 1, -1) "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "FinancialYear")
        Return ds
    End Function
    Protected Friend Function lFnGetSystemStaticParamCurr() As DataSet
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "" & _
        "SELECT " & _
            "CharValue " & _
        "FROM " & _
            "" & GStrConDB & ".dbo.SystemStaticParam " & _
        "WHERE ParamType='IRS' AND Paramname='Curr'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "IRSCurr")
        Return ds
    End Function


    Protected Friend Function lFnGetFATCAAccSecurities(ByVal sFinancialYear As String, ByVal sCurr As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "" & _
        "SELECT " & _
            "g2scm.name " & _
            ", g2scm.aid " & _
            ", g2scm.cmid" & _
            ", g2scm.accno " & _
            ", g2scm.name_1 " & _
            ", g2scm.client_type " & _
            ", g2scm.dob " & _
            ", g2scm.nature " & _
            ", COALESCE(NULLIF(cm.addr_1 + ' ' + cm.addr_2 + ' ' + cm.addr_3 + ' ' + cm.addr_4 COLLATE DATABASE_DEFAULT,''), g2scm.addr_1 + ' ' + g2scm.addr_2 + ' ' + g2scm.addr_3 + ' ' + g2scm.addr_4) AS addr_1 " & _
            ", g2scm.acbal " & _
            ", cm.IRSFatcaAccType " & _
            ", cm.us_tin " & _
            ", cm.FATCA_GIIN " & _
            ", cm.CountryCode " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "cm.acc_no " & _
                ", cm.client_type " & _
                ", IRSFatcaAccType " & _
                ", us_tin " & _
                ", FATCA_GIIN " & _
                ",ISNULL(IRS.addr_1,'') AS addr_1" & _
                ",ISNULL(IRS.addr_2,'') AS addr_2 " & _
                ",ISNULL(IRS.addr_3,'') AS addr_3 " & _
                ",ISNULL(IRS.addr_4,'') AS addr_4 " & _
                ",IRS.CountryCode " & _
            "FROM " & _
            "( " & _
                "SELECT " & _
                    "acc_no " & _
                    ", client_type " & _
                    ", ifatp.IRSFatcaAccType " & _
                    ", us_tin " & _
                    ", FATCA_GIIN " & _
                "FROM " & _
                    "" & GStrConDB & ".dbo.client_master cm " & _
                "INNER JOIN " & _
                    "" & GStrConDB & ".dbo.IRSFatcaAccTypeMapping ifatp " & _
                "ON ifatp.EBS4FatcaAccType = cm.FATCA_acc_type AND ifatp.IsPoolReport=0 " & _
                "WHERE (cm.client_type='Securities' OR cm.client_type='CIES') " & _
            ") cm " & _
            "INNER JOIN " & _
            "( " & _
                "SELECT " & _
                    "iaccl.AccNo " & _
                    ",iaccl.ClientType " & _
                    ",ISNULL(iaa.addr_1,'') AS addr_1" & _
                    ",ISNULL(iaa.addr_2,'') AS addr_2 " & _
                    ",ISNULL(iaa.addr_3,'') AS addr_3 " & _
                    ",ISNULL(iaa.addr_4,'') AS addr_4 " & _
                    ",iaa.Countrycode " & _
                "FROM " & _
                    "" & GStrConDB & ".dbo.IRSAccountList iaccl " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrConDB & ".dbo.IRSAccountAddress iaa " & _
                "ON iaa.AccNo = iaccl.AccNo " & _
                "WHERE iaccl.IsPoolReport='0' AND iaccl.IsActive='1' AND (iaccl.ClientType='Securities' OR iaccl.ClientType='CIES') " & _
            ") IRS " & _
            "ON IRS.AccNo=cm.acc_no AND IRS.ClientType=cm.client_type " & _
        ") cm " & _
        "INNER JOIN " & _
        "( " & _
            "SELECT " & _
                "g2scomm.name " & _
                ",g2scms.aid " & _
                ", g2scms.cmid " & _
                ", g2scm.accno " & _
                ", g2scm.name_1 " & _
                ",CASE " & _
                    "WHEN SUBSTRING(g2scm.accno, 1,3) = '500' THEN 'CIES' " & _
                    "ELSE 'Securities' " & _
                "END AS client_type " & _
                ",CASE WHEN CONVERT(VARCHAR(30), ISNULL(g2scm.dob,''), 120) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(g2scm.dob,''), 120) END AS dob " & _
                ",g2scm.nature " & _
                ",RTRIM(clma.addr_1) AS addr_1 " & _
                ",RTRIM(clma.addr_2) AS addr_2 " & _
                ",RTRIM(clma.addr_3) AS addr_3 " & _
                ",RTRIM(clma.addr_4) AS addr_4" & _
                ",RTRIM(clma1.addr_1) AS nd_addr_1 " & _
                ",RTRIM(clma1.addr_2) AS nd_addr_2 " & _
                ",RTRIM(clma1.addr_3) AS nd_addr_3 " & _
                ",RTRIM(clma1.addr_4) AS nd_addr_4 " & _
                ",ISNULL(acbal,0) AS acbal " & _
            "FROM " & _
                "" & GStrG2BSLYRDB & ".dbo.client_master g2scm " & _
            "INNER JOIN  " & _
                "" & GStrG2BSLYRDB & ".dbo.client_master_s g2scms " & _
            "ON g2scms.aid=g2scm.aid " & _
            "INNER JOIN " & _
                "" & GStrG2BSLYRDB & ".dbo.company_master g2scomm " & _
            "ON g2scomm.cmid=g2scms.cmid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BSLYRDB & ".dbo.view_first_addid AS stadd " & _
            "ON stadd.aid COLLATE DATABASE_DEFAULT = g2scm.aid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BSLYRDB & ".dbo.clientadd_master AS clma " & _
            "ON clma.addid COLLATE DATABASE_DEFAULT = stadd.addid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BSLYRDB & ".dbo.view_second_addid AS ndadd " & _
            "ON ndadd.aid COLLATE DATABASE_DEFAULT = g2scm.aid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BSLYRDB & ".dbo.clientadd_master AS clma1 " & _
            "ON clma1.addid COLLATE DATABASE_DEFAULT = ndadd.addid " & _
            "LEFT OUTER JOIN " & _
            "( " & _
                "SELECT " & _
                    "aid " & _
                    ",ISNULL(ROUND(SUM(ISNULL(cash_bal,0) + ISNULL(mktval,0)),2), 0) AS acbal " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                        "vwcb.aid " & _
                        ",vwcb.accno " & _
                        ", vwcb.cuid " & _
                        ", SUM(vwcb.cash_bal * exrateprod.targetrate) AS cash_bal " & _
                        ", SUM(vwmk.market_value * exrateprod.targetrate) AS mktval " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                            "vwcb.aid " & _
                            ",clm.accno " & _
                            ", vwcb.cuid " & _
                            ", vwcb.cash_bal " & _
                        "FROM " & _
                            "" & GStrG2BSLYRDB & ".dbo.view_client_bals vwcb " & _
                        "INNER JOIN " & _
                            "" & GStrG2BSLYRDB & ".dbo.client_master clm " & _
                        "ON vwcb.aid=clm.aid " & _
                        "WHERE EXISTS " & _
                        "( " & _
                            "SELECT " & _
                                "AccNo " & _
                            "FROM " & _
                                "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                            "WHERE IsActive='1' and IsPoolReport='0' and (ClientType='Securities' OR ClientType='CIES') " & _
                            "AND ial.accno COLLATE DATABASE_DEFAULT = clm.accno " & _
                        ") " & _
                    ") vwcb " & _
                    "LEFT OUTER JOIN " & _
                    "( " & _
                        "SELECT " & _
                            "g2scm.aid " & _
                            ",vwmk.client_code " & _
                            ",currma.cuid " & _
                            ",vwmk.currency_code " & _
                            ",vwmk.market_value " & _
                        "FROM " & _
                        "(" & _
                              "SELECT " & _
                                "vwmk.client_code " & _
                                ",vwmk.currency_code " & _
                                ",vwmk.market_value " & _
                            "FROM " & _
                                "" & GStrG2BSLYRDB & ".dbo.view_er_client_master_mkt_mrg_value vwmk " & _
                            "WHERE EXISTS " & _
                            "( " & _
                                "SELECT " & _
                                    "AccNo " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                "WHERE IsActive='1' and IsPoolReport='0' and (clienttype='Securities' OR clienttype='CIES') " & _
                                "AND ial.accno COLLATE DATABASE_DEFAULT = vwmk.client_code " & _
                            ") " & _
                        ") vwmk " & _
                        "INNER JOIN " & _
                            "" & GStrG2BSLYRDB & ".dbo.currency_master currma " & _
                        "ON currma.name_s = vwmk.currency_code " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "cm.aid " & _
                                ",cm.accno " & _
                            "FROM " & _
                            "(" & _
                                "SELECT " & _
                                    "cm.aid " & _
                                    ",cm.accno " & _
                                "FROM " & _
                                    "" & GStrG2BSLYRDB & ".dbo.client_master cm " & _
                                "WHERE EXISTS " & _
                                "( " & _
                                    "SELECT " & _
                                        "AccNo " & _
                                    "FROM " & _
                                        "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                    "WHERE IsActive='1' and IsPoolReport='0' and (clienttype='Securities' OR clienttype='CIES') " & _
                                    "AND ial.accno COLLATE DATABASE_DEFAULT = cm.accno " & _
                                ")  " & _
                            ") cm " & _
                        ") g2scm " & _
                        "ON " & _
                            "g2scm.accno = vwmk.client_code " & _
                    ") vwmk " & _
                    "ON " & _
                    "vwmk.aid = vwcb.aid AND vwmk.cuid = vwcb.cuid " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT " & _
                            "currma.cuid  " & _
                            ", exrate.currency_in " & _
                            ", exrate.ex_rate / targetbaseexrate.targetrate AS targetrate " & _
                        "FROM " & _
                        "( " & _
                            "SELECT " & _
                                "currency_in " & _
                                ", ex_rate " & _
                                ", '" & sCurr & "' AS targetbase " & _
                            "FROM " & _
                                "" & GStrConDB & ".dbo.exchangerate " & _
                            "WHERE tdate='" & sFinancialYear & "' AND System_Type ='Securities' " & _
                        ") exrate " & _
                        "INNER JOIN " & _
                            "" & GStrG2BSLYRDB & ".dbo.currency_master currma " & _
                        "ON " & _
                            "currma.name_s = exrate.currency_in " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "currency_in " & _
                                ", ex_rate AS targetrate " & _
                            "FROM " & _
                                "" & GStrConDB & ".dbo.exchangerate " & _
                            "WHERE tdate='" & sFinancialYear & "' AND currency_in='" & sCurr & "' AND System_Type ='Securities' " & _
                        ") targetbaseexrate " & _
                        "ON exrate.targetbase = targetbaseexrate.currency_in " & _
                    ") exrateprod " & _
                    "ON " & _
                        "exrateprod.cuid = vwcb.cuid " & _
                    "GROUP BY vwcb.aid, vwcb.accno, vwcb.cuid " & _
                ") acbal " & _
                "GROUP BY acbal.aid " & _
            ") cb " & _
            "ON cb.aid = g2scms.aid " & _
        ") g2scm " & _
        "ON " & _
            "g2scm.accno COLLATE DATABASE_DEFAULT = cm.acc_no " & _
            "AND g2scm.client_type = cm.client_type "


        ds = GFncRtnDS(GSCnSqlConn, lstr, "client_master")
        Return ds
    End Function
    Protected Friend Function lFnGetFATCAAccFutures(ByVal sFinancialYear As String, ByVal sCurr As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "" & _
        "SELECT " & _
            "g2fcm.name " & _
            ", g2fcm.aid " & _
            ", g2fcm.cmid " & _
            ", g2fcm.accno " & _
            ", g2fcm.name_1 " & _
            ", g2fcm.client_type " & _
            ", g2fcm.dob " & _
            ", g2fcm.nature " & _
            ", COALESCE(NULLIF(cm.addr_1 + ' ' + cm.addr_2 + ' ' + cm.addr_3 + ' ' + cm.addr_4 COLLATE DATABASE_DEFAULT,''), g2fcm.addr_1 + ' ' + g2fcm.addr_2 + ' ' + g2fcm.addr_3 + ' ' + g2fcm.addr_4) AS addr_1 " & _
            ", g2fcm.acbal " & _
            ", cm.IRSFatcaAccType " & _
            ", cm.us_tin " & _
            ", cm.FATCA_GIIN " & _
            ", cm.CountryCode " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "cm.acc_no " & _
                ", cm.client_type " & _
                ", IRSFatcaAccType " & _
                ", us_tin " & _
                ", FATCA_GIIN " & _
                ",ISNULL(IRS.addr_1,'') AS addr_1" & _
                ",ISNULL(IRS.addr_2,'') AS addr_2 " & _
                ",ISNULL(IRS.addr_3,'') AS addr_3 " & _
                ",ISNULL(IRS.addr_4,'') AS addr_4 " & _
                ",IRS.CountryCode " & _
            "From " & _
            "( " & _
                "SELECT " & _
                    "acc_no " & _
                    ", client_type " & _
                    ", ifatp.IRSFatcaAccType " & _
                    ", us_tin " & _
                    ", FATCA_GIIN " & _
                "FROM " & _
                    "" & GStrConDB & ".dbo.client_master cm " & _
                "INNER JOIN " & _
                    "" & GStrConDB & ".dbo.IRSFatcaAccTypeMapping ifatp " & _
                "ON ifatp.EBS4FatcaAccType = cm.FATCA_acc_type AND ifatp.IsPoolReport=0 " & _
                "WHERE  (cm.client_type='Futures')" & _
            ") cm " & _
            " INNER JOIN " & _
            "( " & _
                "SELECT " & _
                    "iaccl.AccNo " & _
                    ",iaccl.ClientType " & _
                    ",ISNULL(iaa.addr_1,'') AS addr_1" & _
                    ",ISNULL(iaa.addr_2,'') AS addr_2 " & _
                    ",ISNULL(iaa.addr_3,'') AS addr_3 " & _
                    ",ISNULL(iaa.addr_4,'') AS addr_4 " & _
                    ",iaa.CountryCode " & _
                "FROM " & _
                "" & GStrConDB & ".dbo.IRSAccountList iaccl " & _
                "LEFT OUTER JOIN " & _
                "" & GStrConDB & ".dbo.IRSAccountAddress iaa " & _
                "ON iaa.AccNo = iaccl.AccNo " & _
                "WHERE iaccl.IsPoolReport='0' AND iaccl.IsActive='1' AND (iaccl.ClientType='Futures') " & _
            ") IRS " & _
            "ON IRS.AccNo=cm.acc_no AND IRS.ClientType=cm.client_type " & _
        ") cm " & _
        "INNER JOIN " & _
        "( " & _
            "SELECT " & _
                "g2scomm.name " & _
                ",g2fcms.aid " & _
                ", g2fcms.cmid " & _
                ", g2fcm.accno " & _
                ", g2fcm.name_1 " & _
                ",'Futures' AS client_type " & _
                ",CASE WHEN CONVERT(VARCHAR(30), ISNULL(g2fcm.dob,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(g2fcm.dob,''), 103) END AS dob " & _
                ", g2fcm.nature " & _
                ",RTRIM(clma.addr_1) AS addr_1" & _
                ",RTRIM(clma.addr_2) AS addr_2" & _
                ",RTRIM(clma.addr_3) AS addr_3" & _
                ",RTRIM(clma.addr_4) AS addr_4 " & _
                ",RTRIM(clma1.addr_1) AS nd_addr_1 " & _
                ",RTRIM(clma1.addr_2) AS nd_addr_2 " & _
                ",RTRIM(clma1.addr_3) AS nd_addr_3 " & _
                ",RTRIM(clma1.addr_4) AS nd_addr_4 " & _
                ",ISNULL(acbal, 0) AS acbal " & _
            "FROM " & _
            "( " & _
                "SELECT " & _
                    "g2fcm.aid " & _
                    ", g2fcm.accno " & _
                    ", g2fcm.name_1 " & _
                    ",g2fcm.dob,g2fcm.nature " & _
                "FROM " & _
                    "" & GStrG2BFLYRDB & ".dbo.client_master g2fcm " & _
                "WHERE EXISTS " & _
                "( " & _
                    "SELECT " & _
                        "AccNo " & _
                    "FROM " & _
                        "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                    "WHERE IsActive='1' and IsPoolReport='0' and (ClientType='Futures') " & _
                    "AND ial.accno COLLATE DATABASE_DEFAULT = g2fcm.accno " & _
                ") " & _
            ") g2fcm " & _
            "INNER JOIN " & _
                "" & GStrG2BFLYRDB & ".dbo.client_master_f g2fcms " & _
            "ON g2fcms.aid=g2fcm.aid " & _
            "INNER JOIN " & _
                "" & GStrG2BFLYRDB & ".dbo.company_master g2scomm " & _
            "ON g2scomm.cmid=g2fcms.cmid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BFLYRDB & ".dbo.view_first_addid AS stadd " & _
            "ON stadd.aid COLLATE DATABASE_DEFAULT = g2fcm.aid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BFLYRDB & ".dbo.clientadd_master AS clma " & _
            "ON clma.addid COLLATE DATABASE_DEFAULT = stadd.addid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BFLYRDB & ".dbo.view_second_addid AS ndadd " & _
            "ON ndadd.aid COLLATE DATABASE_DEFAULT = g2fcm.aid " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BFLYRDB & ".dbo.clientadd_master AS clma1 " & _
            "ON clma1.addid COLLATE DATABASE_DEFAULT = ndadd.addid " & _
            "LEFT OUTER JOIN " & _
            "( " & _
                "SELECT " & _
                    "aid " & _
                    ",ISNULL(ROUND(SUM(ISNULL(bal,0) + ISNULL(floatpl,0)),2), 0) AS acbal " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                        "vwcb.aid " & _
                        ", vwcb.accno " & _
                        ", vwcb.cuid " & _
                        ", SUM(vwcb.bal * exrateprod.targetrate) AS bal " & _
                        ", SUM(vwcbfl.float_pl * exrateprod.targetRate) AS floatpl " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                            "vwcb.aid " & _
                            ",clm.accno " & _
                            ", vwcb.cuid " & _
                            ", vwcb.bal " & _
                        "FROM " & _
                            "" & GStrG2BFLYRDB & ".dbo.view_client_bal_for_CSV vwcb " & _
                        "INNER JOIN " & GStrG2BFLYRDB & ".dbo.client_master clm " & _
                            "ON vwcb.aid=clm.aid " & _
                        "WHERE EXISTS " & _
                        "( " & _
                            "SELECT " & _
                                "AccNo " & _
                            "FROM " & _
                                "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                            "WHERE IsActive='1' and IsPoolReport='0' and (ClientType='Futures') " & _
                            "AND ial.accno COLLATE DATABASE_DEFAULT = clm.accno " & _
                        ") " & _
                    ") vwcb " & _
                    "LEFT OUTER JOIN " & _
                    "( " & _
                        "SELECT " & _
                            "g2fcm.aid " & _
                            ",vwcbfl.accno " & _
                            ",currma.cuid " & _
                            ",vwcbfl.ccy " & _
                            ",vwcbfl.float_pl " & _
                        "FROM " & _
                        "( " & _
                            "SELECT " & _
                                "clm.aid " & _
                                ",clm.accno " & _
                                ",cm.name_s AS ccy " & _
                                ",vwcbfl.float_pl " & _
                            "FROM " & _
                                "" & GStrG2BFLYRDB & ".dbo.client_bal vwcbfl " & _
                            "INNER JOIN " & _
                                "" & GStrG2BFLYRDB & ".dbo.client_master clm " & _
                            "ON vwcbfl.aid = clm.aid " & _
                            "INNER JOIN " & _
                                "" & GStrG2BFLYRDB & ".dbo.currency_master cm " & _
                            "ON cm.cuid=vwcbfl.cuid " & _
                            "WHERE EXISTS " & _
                            "( " & _
                                "SELECT " & _
                                    "AccNo " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                "WHERE IsActive='1' and IsPoolReport='0' and (ClientType='Futures') " & _
                                "AND ial.accno COLLATE DATABASE_DEFAULT = clm.accno " & _
                            ") " & _
                        ") vwcbfl " & _
                        "INNER JOIN " & _
                            "" & GStrG2BFLYRDB & ".dbo.currency_master currma " & _
                        "ON currma.name_s = vwcbfl.ccy " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "cm.aid " & _
                                ",cm.accno " & _
                            "FROM " & _
                            "( " & _
                                "SELECT " & _
                                    "cm.aid " & _
                                    ",cm.accno " & _
                                "FROM " & _
                                    "" & GStrG2BFLYRDB & ".dbo.client_master cm " & _
                                "WHERE EXISTS " & _
                                "( " & _
                                    "SELECT " & _
                                        "AccNo " & _
                                    "FROM " & _
                                        "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                    "WHERE IsActive='1' and IsPoolReport='0' and (ClientType='Futures') " & _
                                    "AND ial.accno COLLATE DATABASE_DEFAULT = cm.accno " & _
                                ") " & _
                            ") cm " & _
                        ") g2fcm " & _
                        "ON " & _
                            "g2fcm.accno = vwcbfl.accno " & _
                    ") vwcbfl " & _
                    "ON " & _
                        "vwcbfl.aid = vwcb.aid And vwcbfl.cuid = vwcb.cuid " & _
                    "INNER JOIN " & _
                    "( " & _
                        "SELECT " & _
                            "currma.cuid " & _
                            ", exrate.currency_in " & _
                            ",  exrate.ex_rate / targetbaseexrate.targetrate AS targetrate " & _
                        "FROM " & _
                        "( " & _
                            "SELECT " & _
                                "currency_in " & _
                                ", ex_rate " & _
                                ", '" & sCurr & "' AS targetbase " & _
                            "FROM " & _
                                "" & GStrConDB & ".dbo.exchangerate " & _
                            "WHERE tdate='" & sFinancialYear & "' AND System_Type ='Futures' " & _
                        ") exrate " & _
                        "INNER JOIN " & _
                            "" & GStrG2BFLYRDB & ".dbo.currency_master currma " & _
                        "ON " & _
                            "currma.name_s = exrate.currency_in " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "currency_in " & _
                                ", ex_rate AS targetrate " & _
                            "FROM " & _
                                "" & GStrConDB & ".dbo.exchangerate " & _
                            "WHERE tdate='" & sFinancialYear & "' AND currency_in='" & sCurr & "' AND System_Type ='Futures' " & _
                        ") targetbaseexrate " & _
                        "ON exrate.targetbase = targetbaseexrate.currency_in " & _
                    ") exrateprod " & _
                    "ON " & _
                        "exrateprod.cuid = vwcb.cuid " & _
                    "GROUP BY vwcb.aid, vwcb.accno, vwcb.cuid " & _
                ") acbal " & _
                "GROUP BY acbal.aid " & _
            ") cb " & _
            "ON cb.aid = g2fcms.aid " & _
        ") g2fcm " & _
        "ON " & _
            "g2fcm.accno COLLATE DATABASE_DEFAULT = cm.acc_no " & _
            "AND g2fcm.client_type = cm.client_type "



        ds = GFncRtnDS(GSCnSqlConn, lstr, "client_master")
        Return ds
    End Function

    Protected Friend Function lFnGetFATCAAccGroupSecurities(ByVal sFinancialYear As String, ByVal sCurr As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "" & _
        "SELECT " & _
            "final.name " & _
            ",final.IRSFatcaAccType " & _
            ",SUM(acbal) AS acbal " & _
            ",COUNT(*) AS cnt " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "g2scm.name " & _
                ", g2scm.aid " & _
                ", g2scm.cmid" & _
                ", g2scm.accno " & _
                ", g2scm.name_1 " & _
                ", g2scm.client_type " & _
                ", g2scm.dob " & _
                ", g2scm.addr_1 " & _
                ", g2scm.addr_2 " & _
                ", g2scm.addr_3 " & _
                ", g2scm.addr_4 " & _
                ", g2scm.nd_addr_1 " & _
                ", g2scm.nd_addr_2 " & _
                ", g2scm.nd_addr_3 " & _
                ", g2scm.nd_addr_4 " & _
                ", g2scm.acbal " & _
                ", cm.IRSFatcaAccType " & _
                ", cm.us_tin " & _
                ", cm.FATCA_GIIN " & _
            "FROM " & _
            "( " & _
                "SELECT " & _
                    "cm.acc_no " & _
                    ", cm.client_type " & _
                    ", IRSFatcaAccType " & _
                    ", us_tin " & _
                    ", FATCA_GIIN " & _
                "From " & _
                "( " & _
                    "SELECT " & _
                        "acc_no " & _
                        ", client_type " & _
                        ", ifatp.IRSFatcaAccType " & _
                        ", us_tin " & _
                        ", FATCA_GIIN " & _
                    "FROM " & _
                        "" & GStrConDB & ".dbo.client_master cm " & _
                    "INNER JOIN " & _
                        "" & GStrConDB & ".dbo.IRSFatcaAccTypeMapping ifatp " & _
                    "ON ifatp.EBS4FatcaAccType = cm.FATCA_acc_type AND ifatp.IsPoolReport=1 " & _
                    "WHERE (cm.client_type='Securities' OR cm.client_type='CIES') " & _
                ") cm " & _
                " INNER JOIN " & _
                "( " & _
                    "SELECT " & _
                        "AccNo " & _
                        ",ClientType " & _
                    "FROM " & _
                    "" & GStrConDB & ".dbo.IRSAccountList iaccl " & _
                    "WHERE IsPoolReport='1' AND iaccl.IsActive='1' AND (ClientType='Securities' OR ClientType='CIES') " & _
                ") IRS " & _
                "ON IRS.AccNo=cm.acc_no AND IRS.ClientType=cm.client_type " & _
            ") cm " & _
            "INNER JOIN " & _
            "( " & _
                "SELECT " & _
                    "g2scomm.name " & _
                    ",g2scms.aid " & _
                    ", g2scms.cmid " & _
                    ", g2scm.accno " & _
                    ", g2scm.name_1 " & _
                    ",CASE " & _
                        "WHEN SUBSTRING(g2scm.accno, 1,3) = '500' THEN 'CIES' " & _
                        "ELSE 'Securities' " & _
                    "END AS client_type " & _
                    ",CASE WHEN CONVERT(VARCHAR(30), ISNULL(g2scm.dob,''), 120) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(g2scm.dob,''), 120) END AS dob " & _
                    ",clma.addr_1 " & _
                    ",clma.addr_2 " & _
                    ",clma.addr_3 " & _
                    ",clma.addr_4 " & _
                    ",clma1.addr_1 AS nd_addr_1 " & _
                    ",clma1.addr_2 AS nd_addr_2 " & _
                    ",clma1.addr_3 AS nd_addr_3 " & _
                    ",clma1.addr_4 AS nd_addr_4 " & _
                    ", ISNULL(acbal, 0) AS acbal " & _
                "FROM " & _
                    "" & GStrG2BSLYRDB & ".dbo.client_master g2scm " & _
                "INNER JOIN  " & _
                    "" & GStrG2BSLYRDB & ".dbo.client_master_s g2scms " & _
                "ON g2scms.aid=g2scm.aid " & _
                "INNER JOIN " & _
                    "" & GStrG2BSLYRDB & ".dbo.company_master g2scomm " & _
                "ON g2scomm.cmid=g2scms.cmid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BSLYRDB & ".dbo.view_first_addid AS stadd " & _
                "ON stadd.aid COLLATE DATABASE_DEFAULT = g2scm.aid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BSLYRDB & ".dbo.clientadd_master AS clma " & _
                "ON clma.addid COLLATE DATABASE_DEFAULT = stadd.addid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BSLYRDB & ".dbo.view_second_addid AS ndadd " & _
                "ON ndadd.aid COLLATE DATABASE_DEFAULT = g2scm.aid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BSLYRDB & ".dbo.clientadd_master AS clma1 " & _
                "ON clma1.addid COLLATE DATABASE_DEFAULT = ndadd.addid " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT " & _
                        "aid " & _
                        ",ISNULL(ROUND(SUM(ISNULL(cash_bal,0) + ISNULL(mktval,0)),2), 0) AS acbal " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                            "vwcb.aid " & _
                            ", vwcb.cuid " & _
                            ", SUM(vwcb.cash_bal * exrateprod.targetRate) AS cash_bal " & _
                            ", SUM(vwmk.market_value * exrateprod.targetRate) AS mktval " & _
                        "FROM " & _
                        "( " & _
                            "SELECT " & _
                                "vwcb.aid " & _
                                ",clm.accno " & _
                                ", vwcb.cuid " & _
                                ", vwcb.cash_bal " & _
                            "FROM " & _
                                "" & GStrG2BSLYRDB & ".dbo.view_client_bals vwcb " & _
                            "INNER JOIN " & GStrG2BSLYRDB & ".dbo.client_master clm " & _
                                "ON vwcb.aid=clm.aid " & _
                            "WHERE EXISTS " & _
                            "( " & _
                                "SELECT " & _
                                    "AccNo " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                "WHERE IsActive='1' and IsPoolReport='1' and (ClientType='Securities' OR ClientType='CIES') " & _
                                "AND ial.accno COLLATE DATABASE_DEFAULT = clm.accno " & _
                            ") " & _
                        ") vwcb " & _
                        "LEFT OUTER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "g2scm.aid " & _
                                ",vwmk.client_code " & _
                                ",currma.cuid " & _
                                ",vwmk.currency_code " & _
                                ",vwmk.market_value " & _
                            "FROM " & _
                            "(" & _
                                "SELECT " & _
                                    "vwmk.client_code " & _
                                    ",vwmk.currency_code " & _
                                    ",vwmk.market_value " & _
                                "FROM " & _
                                    "" & GStrG2BSLYRDB & ".dbo.view_er_client_master_mkt_mrg_value vwmk " & _
                                "WHERE EXISTS " & _
                                "( " & _
                                    "SELECT " & _
                                        "AccNo " & _
                                    "FROM " & _
                                        "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                    "WHERE IsActive='1' and IsPoolReport='1' and (clienttype='Securities' OR clienttype='CIES') " & _
                                    "AND ial.accno COLLATE DATABASE_DEFAULT = vwmk.client_code " & _
                                ") " & _
                            ") vwmk " & _
                            "INNER JOIN " & _
                                "" & GStrG2BSLYRDB & ".dbo.currency_master currma " & _
                            "ON currma.name_s = vwmk.currency_code " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT " & _
                                    "cm.aid " & _
                                    ",cm.accno " & _
                                "FROM " & _
                                "(" & _
                                    "SELECT " & _
                                        "cm.aid " & _
                                        ",cm.accno " & _
                                    "FROM " & _
                                        "" & GStrG2BSLYRDB & ".dbo.client_master cm " & _
                                    "WHERE EXISTS " & _
                                    "( " & _
                                        "SELECT " & _
                                            "AccNo " & _
                                        "FROM " & _
                                            "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                        "WHERE IsActive='1' and IsPoolReport='1' and (clienttype='Securities' OR clienttype='CIES') " & _
                                        "AND ial.accno COLLATE DATABASE_DEFAULT = cm.accno " & _
                                    ") " & _
                                ") cm " & _
                            ") g2scm " & _
                            "ON " & _
                                "g2scm.accno = vwmk.client_code " & _
                        ") vwmk " & _
                        "ON " & _
                        "vwmk.aid = vwcb.aid AND vwmk.cuid = vwcb.cuid " & _
                        "INNER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "currma.cuid  " & _
                                ", exrate.currency_in " & _
                                ", exrate.ex_rate / targetbaseexrate.targetrate AS targetrate " & _
                            "FROM " & _
                            "( " & _
                                "SELECT " & _
                                    "currency_in " & _
                                    ", ex_rate " & _
                                    ", '" & sCurr & "' AS targetbase " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.exchangerate " & _
                                "WHERE tdate='" & sFinancialYear & "' AND System_Type ='Securities' " & _
                            ") exrate " & _
                            "INNER JOIN " & _
                                "" & GStrG2BSLYRDB & ".dbo.currency_master currma " & _
                            "ON " & _
                                "currma.name_s = exrate.currency_in " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT " & _
                                    "currency_in " & _
                                    ", ex_rate AS targetrate " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.exchangerate " & _
                                "WHERE tdate='" & sFinancialYear & "' AND currency_in='" & sCurr & "' AND System_Type ='Securities' " & _
                            ") targetbaseexrate " & _
                            "ON exrate.targetbase = targetbaseexrate.currency_in " & _
                        ") exrateprod " & _
                        "ON " & _
                            "exrateprod.cuid = vwcb.cuid " & _
                        "GROUP BY vwcb.aid, vwcb.cuid " & _
                    ") acbal " & _
                    "GROUP BY acbal.aid " & _
                ") cb " & _
                "ON cb.aid = g2scms.aid " & _
            ") g2scm " & _
            "ON " & _
                "g2scm.accno COLLATE DATABASE_DEFAULT = cm.acc_no " & _
                "AND g2scm.client_type = cm.client_type " & _
        ") final GROUP BY final.name, final.IRSFatcaAccType"


        ds = GFncRtnDS(GSCnSqlConn, lstr, "client_master")
        Return ds
    End Function
    Protected Friend Function lFnGetFATCAAccGroupFutures(ByVal sFinancialYear As String, ByVal sCurr As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "" & _
        "SELECT " & _
            "final.name " & _
            ",final.IRSFatcaAccType " & _
            ",SUM(acbal) AS acbal " & _
            ",COUNT (*) AS cnt " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "g2fcm.name " & _
                ", g2fcm.aid " & _
                ", g2fcm.cmid " & _
                ", g2fcm.accno " & _
                ", g2fcm.name_1 " & _
                ", g2fcm.client_type " & _
                ", g2fcm.dob " & _
                ", g2fcm.addr_1 " & _
                ", g2fcm.addr_2 " & _
                ", g2fcm.addr_3 " & _
                ", g2fcm.addr_4 " & _
                ", g2fcm.nd_addr_1 " & _
                ", g2fcm.nd_addr_2 " & _
                ", g2fcm.nd_addr_3 " & _
                ", g2fcm.nd_addr_4 " & _
                ", g2fcm.acbal " & _
                ", cm.IRSFatcaAccType " & _
                ", cm.us_tin " & _
                ", cm.FATCA_GIIN " & _
            "FROM " & _
            "( " & _
                "SELECT " & _
                    "cm.acc_no " & _
                    ", cm.client_type " & _
                    ", IRSFatcaAccType " & _
                    ", us_tin " & _
                    ", FATCA_GIIN " & _
                "From " & _
                "( " & _
                    "SELECT " & _
                        "acc_no " & _
                        ", client_type " & _
                        ", ifatp.IRSFatcaAccType " & _
                        ", us_tin " & _
                        ", FATCA_GIIN " & _
                    "FROM " & _
                        "" & GStrConDB & ".dbo.client_master cm " & _
                    "INNER JOIN " & _
                        "" & GStrConDB & ".dbo.IRSFatcaAccTypeMapping ifatp " & _
                    "ON ifatp.EBS4FatcaAccType = cm.FATCA_acc_type AND ifatp.IsPoolReport=1 " & _
                        "WHERE (cm.client_type='Futures') " & _
                ") cm " & _
                " INNER JOIN " & _
                "( " & _
                    "SELECT " & _
                        "AccNo " & _
                        ",ClientType " & _
                    "FROM " & _
                    "" & GStrConDB & ".dbo.IRSAccountList iaccl " & _
                    "WHERE IsPoolReport='1' AND iaccl.IsActive='1' AND  (ClientType='Futures') " & _
                ") IRS " & _
                "ON IRS.AccNo=cm.acc_no AND IRS.ClientType=cm.client_type " & _
            ") cm " & _
            "INNER JOIN " & _
            "( " & _
                "SELECT " & _
                    "g2scomm.name " & _
                    ",g2fcms.aid " & _
                    ", g2fcms.cmid " & _
                    ", g2fcm.accno " & _
                    ", g2fcm.name_1 " & _
                    ", 'Futures' AS client_type " & _
                    ",CASE WHEN CONVERT(VARCHAR(30), ISNULL(g2fcm.dob,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(g2fcm.dob,''), 103) END AS dob " & _
                    ",clma.addr_1 " & _
                    ",clma.addr_2 " & _
                    ",clma.addr_3 " & _
                    ",clma.addr_4 " & _
                    ",clma1.addr_1 AS nd_addr_1 " & _
                    ",clma1.addr_2 AS nd_addr_2 " & _
                    ",clma1.addr_3 AS nd_addr_3 " & _
                    ",clma1.addr_4 AS nd_addr_4 " & _
                    ",ISNULL(acbal, 0) AS acbal " & _
                "FROM " & _
                "( " & _
                    "SELECT " & _
                        "g2fcm.aid " & _
                        ", g2fcm.accno " & _
                        ", g2fcm.name_1 " & _
                        ",g2fcm.dob " & _
                        ",g2fcm.nature " & _
                    "FROM " & _
                        "" & GStrG2BFLYRDB & ".dbo.client_master g2fcm " & _
                    "WHERE EXISTS " & _
                    "( " & _
                        "SELECT " & _
                            "AccNo " & _
                        "FROM " & _
                            "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                        "WHERE IsActive='1' and IsPoolReport='1' and (ClientType='Futures') " & _
                        "AND ial.accno COLLATE DATABASE_DEFAULT = g2fcm.accno " & _
                    ") " & _
                ") g2fcm " & _
                "INNER JOIN " & _
                    "" & GStrG2BFLYRDB & ".dbo.client_master_f g2fcms " & _
                "ON g2fcms.aid=g2fcm.aid " & _
                "INNER JOIN " & _
                    "" & GStrG2BFLYRDB & ".dbo.company_master g2scomm " & _
                "ON g2scomm.cmid=g2fcms.cmid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BFLYRDB & ".dbo.view_first_addid AS stadd " & _
                "ON stadd.aid COLLATE DATABASE_DEFAULT = g2fcm.aid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BFLYRDB & ".dbo.clientadd_master AS clma " & _
                "ON clma.addid COLLATE DATABASE_DEFAULT = stadd.addid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BFLYRDB & ".dbo.view_second_addid AS ndadd " & _
                "ON ndadd.aid COLLATE DATABASE_DEFAULT = g2fcm.aid " & _
                "LEFT OUTER JOIN " & _
                    "" & GStrG2BFLYRDB & ".dbo.clientadd_master AS clma1 " & _
                "ON clma1.addid COLLATE DATABASE_DEFAULT = ndadd.addid " & _
                "LEFT OUTER JOIN " & _
                "( " & _
                    "SELECT " & _
                        "aid " & _
                        ",ISNULL(ROUND(SUM(ISNULL(bal,0) + ISNULL(floatpl,0)),2), 0) AS acbal " & _
                    "FROM " & _
                    "( " & _
                        "SELECT " & _
                            "vwcb.aid " & _
                            ", vwcb.cuid " & _
                            ", SUM(vwcb.bal * exrateprod.targetRate) AS bal " & _
                            ", SUM(vwcbfl.float_pl * exrateprod.targetRate) AS floatpl " & _
                        "FROM " & _
                        "( " & _
                            "SELECT " & _
                                "vwcb.aid " & _
                                ",clm.accno " & _
                                ", vwcb.cuid " & _
                                ", vwcb.bal " & _
                            "FROM " & _
                                "" & GStrG2BFLYRDB & ".dbo.view_client_bal_for_CSV vwcb " & _
                            "INNER JOIN " & GStrG2BFLYRDB & ".dbo.client_master clm " & _
                                "ON vwcb.aid=clm.aid " & _
                            "WHERE EXISTS " & _
                            "( " & _
                                "SELECT " & _
                                    "AccNo " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                "WHERE IsActive='1' and IsPoolReport='1' and (ClientType='Futures') " & _
                                "AND ial.accno COLLATE DATABASE_DEFAULT = clm.accno " & _
                            ") " & _
                        ") vwcb " & _
                        "LEFT OUTER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "g2fcm.aid " & _
                                ",vwcbfl.accno " & _
                                ",currma.cuid " & _
                                ",vwcbfl.ccy " & _
                                ",vwcbfl.float_pl " & _
                            "FROM " & _
                            "( " & _
                                "SELECT " & _
                                    "clm.aid " & _
                                    ",clm.accno " & _
                                    ",cm.name_s AS ccy " & _
                                    ",vwcbfl.float_pl " & _
                                "FROM " & _
                                    "" & GStrG2BFLYRDB & ".dbo.client_bal vwcbfl " & _
                                "INNER JOIN " & _
                                    "" & GStrG2BFLYRDB & ".dbo.client_master clm " & _
                                "ON vwcbfl.aid = clm.aid " & _
                                "INNER JOIN " & _
                                    "" & GStrG2BFLYRDB & ".dbo.currency_master cm " & _
                                "ON cm.cuid=vwcbfl.cuid " & _
                                "WHERE EXISTS " & _
                                "( " & _
                                    "SELECT " & _
                                        "AccNo " & _
                                    "FROM " & _
                                        "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                    "WHERE IsActive='1' and IsPoolReport='1' and (ClientType='Futures') " & _
                                    "AND ial.accno COLLATE DATABASE_DEFAULT = clm.accno " & _
                                ") " & _
                            ") vwcbfl " & _
                            "INNER JOIN " & _
                                "" & GStrG2BFLYRDB & ".dbo.currency_master currma " & _
                            "ON currma.name_s = vwcbfl.ccy " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT " & _
                                    "cm.aid " & _
                                ",cm.accno " & _
                                "FROM " & _
                                "( " & _
                                    "SELECT " & _
                                        "cm.aid " & _
                                        ",cm.accno " & _
                                    "FROM " & _
                                        "" & GStrG2BFLYRDB & ".dbo.client_master cm " & _
                                    "WHERE EXISTS " & _
                                    "( " & _
                                        "SELECT " & _
                                            "AccNo " & _
                                        "FROM " & _
                                            "" & GStrConDB & ".dbo.IRSAccountList ial " & _
                                        "WHERE IsActive='1' and IsPoolReport='1' and (ClientType='Futures') " & _
                                        "AND ial.accno COLLATE DATABASE_DEFAULT = cm.accno " & _
                                    ") " & _
                                ") cm " & _
                            ") g2fcm " & _
                            "ON " & _
                            "g2fcm.accno = vwcbfl.accno " & _
                        ") vwcbfl " & _
                        "ON " & _
                            "vwcbfl.aid = vwcb.aid And vwcbfl.cuid = vwcb.cuid " & _
                       "INNER JOIN " & _
                        "( " & _
                            "SELECT " & _
                                "currma.cuid " & _
                                ", exrate.currency_in " & _
                                ", exrate.ex_rate / targetbaseexrate.targetrate AS targetrate " & _
                            "FROM " & _
                            "( " & _
                                "SELECT " & _
                                    "currency_in " & _
                                    ", ex_rate " & _
                                    ", '" & sCurr & "' AS targetbase " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.exchangerate " & _
                                "WHERE tdate='" & sFinancialYear & "' AND System_Type ='Futures' " & _
                            ") exrate " & _
                            "INNER JOIN " & _
                                "" & GStrG2BFLYRDB & ".dbo.currency_master currma " & _
                            "ON " & _
                                "currma.name_s = exrate.currency_in " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT " & _
                                    "currency_in " & _
                                    ", ex_rate AS targetrate " & _
                                "FROM " & _
                                    "" & GStrConDB & ".dbo.exchangerate " & _
                                "WHERE tdate='" & sFinancialYear & "' AND currency_in='" & sCurr & "' AND System_Type ='Futures' " & _
                            ") targetbaseexrate " & _
                            "ON exrate.targetbase = targetbaseexrate.currency_in " & _
                        ") exrateprod " & _
                        "ON " & _
                            "exrateprod.cuid = vwcb.cuid " & _
                        "GROUP BY vwcb.aid, vwcb.cuid " & _
                    ") acbal " & _
                    "GROUP BY acbal.aid " & _
                ") cb " & _
                "ON cb.aid = g2fcms.aid " & _
            ") g2fcm " & _
            "ON " & _
                "g2fcm.accno COLLATE DATABASE_DEFAULT = cm.acc_no " & _
                "AND g2fcm.client_type = cm.client_type " & _
        ") final GROUP BY final.name, final.IRSFatcaAccType"

        ds = GFncRtnDS(GSCnSqlConn, lstr, "client_master")
        Return ds
    End Function
    
End Class
