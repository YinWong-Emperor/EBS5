Imports System.Data.SqlClient

Public Class ClsFeeClsMaster
    Protected Friend Function lFncGenFeeCls(ByVal dbName As String) As DataSet
        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing
        Dim currConn As SqlConnection = Nothing
        Try
            lstrSQL = "select fee_class.name as fc, market_master.name_s as mm, feenature_master.name as fn, fee_master.name fee " & _
                        "into #fee_class " & _
                        "from " & dbName & "fee_class as fee_class, " & dbName & "fee_class_d as fee_class_d, " & dbName & "market_master as market_master, " & dbName & "feenature_master as feenature_master, " & dbName & "fee_master as fee_master " & _
                        "where ((rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'DJI Commission (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'DJI Commission (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'DJI A/E Rebate (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'DJI A/E Rebate (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI Commission (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI Commission (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI Commission (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI Commission (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI A/E Rebate (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI A/E Rebate (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI A/E Rebate (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFI A/E Rebate (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFO Commission') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HFO A/E Rebate') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI Commission (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI Commission (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI Commission (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI Commission (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI Commission (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI Commission (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI A/E Rebate (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI A/E Rebate (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI A/E Rebate (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI A/E Rebate (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI A/E Rebate (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHI A/E Rebate (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHO Commission') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHO Commission(i)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHO A/E Rebate') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HHO A/E Rebate(i)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI Commission (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI Commission (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI Commission (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI Commission (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI Commission (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI Commission (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI A/E Rebate (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI A/E Rebate (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI A/E Rebate (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI A/E Rebate (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI A/E Rebate (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSI A/E Rebate (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSO Commission') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSO Commission(i)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSO A/E Rebate') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'HSO A/E Rebate (i)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH Commission (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH Commission (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH Commission (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH Commission (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH Commission (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH Commission (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH A/E Rebate (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH A/E Rebate (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH A/E Rebate (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH A/E Rebate (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH A/E Rebate (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MCH A/E Rebate (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI Commission (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI Commission (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI Commission (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI Commission (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI Commission (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI Commission (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI A/E Rebate (CS)D') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI A/E Rebate (CS)N') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI A/E Rebate (IDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI A/E Rebate (INF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI A/E Rebate (NDF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHI A/E Rebate (NNF)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHO Commission') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHO Commission(i)') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHO A/E Rebate') " & _
                        "or (rtrim(market_master.name_s) = 'HKEX' and rtrim(feenature_master.name) = 'MHO A/E Rebate(i)') " & _
                        "or (rtrim(market_master.name_s) = 'CBOT' and rtrim(feenature_master.name) = 'US Futures Comm.') " & _
                        "or (rtrim(market_master.name_s) = 'CBOT' and rtrim(feenature_master.name) = 'US Futures Comm (i)') " & _
                        "or (rtrim(market_master.name_s) = 'CBOT' and rtrim(feenature_master.name) = 'US REB for AE') " & _
                        "or (rtrim(market_master.name_s) = 'CBOT' and rtrim(feenature_master.name) = 'US REB for AE(i)') " & _
                        "or (rtrim(market_master.name_s) = 'CME' and rtrim(feenature_master.name) = 'US Futures Comm.') " & _
                        "or (rtrim(market_master.name_s) = 'CME' and rtrim(feenature_master.name) = 'US Futures Comm (i)') " & _
                        "or (rtrim(market_master.name_s) = 'CME' and rtrim(feenature_master.name) = 'US REB for AE') " & _
                        "or (rtrim(market_master.name_s) = 'CME' and rtrim(feenature_master.name) = 'US REB for AE(i)') " & _
                        "or (rtrim(market_master.name_s) = 'NYBOT' and rtrim(feenature_master.name) = 'US Futures Comm.') " & _
                        "or (rtrim(market_master.name_s) = 'NYBOT' and rtrim(feenature_master.name) = 'US Futures Comm (i)') " & _
                        "or (rtrim(market_master.name_s) = 'NYBOT' and rtrim(feenature_master.name) = 'US REB for AE') " & _
                        "or (rtrim(market_master.name_s) = 'NYBOT' and rtrim(feenature_master.name) = 'US REB for AE(i)') " & _
                        "or (rtrim(market_master.name_s) = 'NYMEX' and rtrim(feenature_master.name) = 'US Futures Comm.') " & _
                        "or (rtrim(market_master.name_s) = 'NYMEX' and rtrim(feenature_master.name) = 'US Futures Comm (i)') " & _
                        "or (rtrim(market_master.name_s) = 'NYMEX' and rtrim(feenature_master.name) = 'US REB for AE') " & _
                        "or (rtrim(market_master.name_s) = 'NYMEX' and rtrim(feenature_master.name) = 'US REB for AE(i)') " & _
                        "or (rtrim(market_master.name_s) = 'TGE' and rtrim(feenature_master.name) = 'Japan Futures Comm.') " & _
                        "or (rtrim(market_master.name_s) = 'TGE' and rtrim(feenature_master.name) = 'JP REB for AE') " & _
                        "or (rtrim(market_master.name_s) = 'TOCOM' and rtrim(feenature_master.name) = 'Japan Futures Comm.') " & _
                        "or (rtrim(market_master.name_s) = 'TOCOM' and rtrim(feenature_master.name) = 'JP REB for AE') " & _
                        "or (rtrim(market_master.name_s) = 'LME' and rtrim(feenature_master.name) = 'LME COMM') " & _
                        "or (rtrim(market_master.name_s) = 'LME' and rtrim(feenature_master.name) = 'LME REB of AE')) " & _
                        "and fee_class.fcid = fee_class_d.fcid " & _
                        "and fee_class_d.mkid = market_master.mkid " & _
                        "and fee_class_d.fuid =  feenature_master.fuid " & _
                        "and fee_class_d.fid =  fee_master.fid " & _
                        "order by  fee_class.name, market_master.name_s, feenature_master.name"
            GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
            MyTrans = GSCnLiqConn.BeginTransaction
            lstrSQL = "CREATE table #tmplist(FeeClass nvarchar(20), DJI_com_csd nvarchar(40) default '', DJI_com_csn nvarchar(40) default '', DJI_reb_csd nvarchar(40) default '', DJI_reb_csn nvarchar(40) default '', HFI_com_csd nvarchar(40) default '', " & _
                        "HFI_com_csn nvarchar(40) default '', HFI_com_ndf nvarchar(40) default '', HFI_com_nnf nvarchar(40) default '', HFI_reb_csd nvarchar(40) default '', HFI_reb_csn nvarchar(40) default '', HFI_reb_ndf nvarchar(40) default '', " & _
                        "HFI_reb_nnf nvarchar(40) default '', HFO_com_n nvarchar(40) default '', HFO_reb_n nvarchar(40) default '', HHI_com_csd nvarchar(40) default '', HHI_com_csn nvarchar(40) default '', HHI_com_idf nvarchar(40) default '', " & _
                        "HHI_com_inf nvarchar(40) default '', HHI_com_ndf nvarchar(40) default '', HHI_com_nnf nvarchar(40) default '', HHI_reb_csd nvarchar(40) default '', HHI_reb_csn nvarchar(40) default '', HHI_reb_idf nvarchar(40) default '', " & _
                        "HHI_reb_inf nvarchar(40) default '', HHI_reb_ndf nvarchar(40) default '', HHI_reb_nnf nvarchar(40) default '', HHO_com_n nvarchar(40) default '', HHO_com_i nvarchar(40) default '', HHO_reb_n nvarchar(40) default '', " & _
                        "HHO_reb_i nvarchar(40) default '', HSI_com_csd nvarchar(40) default '', HSI_com_csn nvarchar(40) default '', HSI_com_idf nvarchar(40) default '', HSI_com_inf nvarchar(40) default '', HSI_com_ndf nvarchar(40) default '', " & _
                        "HSI_com_nnf nvarchar(40) default '', HSI_reb_csd nvarchar(40) default '', HSI_reb_csn nvarchar(40) default '', HSI_reb_idf nvarchar(40) default '', HSI_reb_inf nvarchar(40) default '', HSI_reb_ndf nvarchar(40) default '', " & _
                        "HSI_reb_nnf nvarchar(40) default '', HSO_com_n nvarchar(40) default '', HSO_com_i nvarchar(40) default '', HSO_reb_n nvarchar(40) default '', HSO_reb_i nvarchar(40) default '', MCH_com_csd nvarchar(40) default '', " & _
                        "MCH_com_csn nvarchar(40) default '', MCH_com_idf nvarchar(40) default '', MCH_com_inf nvarchar(40) default '', MCH_com_ndf nvarchar(40) default '', MCH_com_nnf nvarchar(40) default '', MCH_reb_csd nvarchar(40) default '', " & _
                        "MCH_reb_csn nvarchar(40) default '', MCH_reb_idf nvarchar(40) default '', MCH_reb_inf nvarchar(40) default '', MCH_reb_ndf nvarchar(40) default '', MCH_reb_nnf nvarchar(40) default '', MHI_com_csd nvarchar(40) default '', " & _
                        "MHI_com_csn nvarchar(40) default '', MHI_com_idf nvarchar(40) default '', MHI_com_inf nvarchar(40) default '', MHI_com_ndf nvarchar(40) default '', MHI_com_nnf nvarchar(40) default '', MHI_reb_csd nvarchar(40) default '', " & _
                        "MHI_reb_csn nvarchar(40) default '', MHI_reb_idf nvarchar(40) default '', MHI_reb_inf nvarchar(40) default '', MHI_reb_ndf nvarchar(40) default '', MHI_reb_nnf nvarchar(40) default '', MHO_com_n nvarchar(40) default '', " & _
                        "MHO_com_i nvarchar(40) default '', MHO_reb_n nvarchar(40) default '', MHO_reb_i nvarchar(40) default '', CBOT_com_n nvarchar(40) default '', CBOT_com_i nvarchar(40) default '', CBOT_reb_n nvarchar(40) default '', " & _
                        "CBOT_reb_i nvarchar(40) default '', CME_com_n nvarchar(40) default '', CME_com_i nvarchar(40) default '', CME_reb_n nvarchar(40) default '', CME_reb_i nvarchar(40) default '', NYBOT_com_n nvarchar(40) default '', " & _
                        "NYBOT_com_i nvarchar(40) default '', NYBOT_reb_n nvarchar(40) default '', NYBOT_reb_i nvarchar(40) default '', NYMEX_com_n nvarchar(40) default '', NYMEX_com_i nvarchar(40) default '', NYMEX_reb_n nvarchar(40) default '', " & _
                        "NYMEX_reb_i nvarchar(40) default '', TGE_com nvarchar(40) default '', TGE_reb nvarchar(40) default '', TOCOM_com nvarchar(40) default '', TOCOM_reb nvarchar(40) default '', LME_com nvarchar(40) default '', LME_reb nvarchar(40) default '')"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "INSERT INTO #tmplist(FeeClass) SELECT distinct fc FROM #fee_class"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET DJI_com_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'DJI Commission (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET DJI_com_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'DJI Commission (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET DJI_reb_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'DJI A/E Rebate (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET DJI_reb_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'DJI A/E Rebate (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_com_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI Commission (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_com_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI Commission (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_com_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI Commission (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_com_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI Commission (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_reb_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI A/E Rebate (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_reb_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI A/E Rebate (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_reb_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI A/E Rebate (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFI_reb_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFI A/E Rebate (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFO_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFO Commission'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HFO_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HFO A/E Rebate'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_com_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI Commission (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_com_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI Commission (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_com_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI Commission (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_com_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI Commission (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_com_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI Commission (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_com_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI Commission (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_reb_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI A/E Rebate (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_reb_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI A/E Rebate (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_reb_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI A/E Rebate (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_reb_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI A/E Rebate (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_reb_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI A/E Rebate (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHI_reb_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHI A/E Rebate (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHO_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHO Commission'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHO_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHO Commission(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHO_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHO A/E Rebate'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HHO_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HHO A/E Rebate(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_com_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI Commission (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_com_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI Commission (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_com_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI Commission (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_com_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI Commission (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_com_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI Commission (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_com_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI Commission (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_reb_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI A/E Rebate (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_reb_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI A/E Rebate (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_reb_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI A/E Rebate (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_reb_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI A/E Rebate (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_reb_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI A/E Rebate (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSI_reb_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSI A/E Rebate (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSO_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSO Commission'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSO_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSO Commission(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSO_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSO A/E Rebate'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET HSO_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'HSO A/E Rebate (i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_com_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH Commission (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_com_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH Commission (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_com_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH Commission (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_com_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH Commission (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_com_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH Commission (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_com_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH Commission (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_reb_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH A/E Rebate (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_reb_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH A/E Rebate (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_reb_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH A/E Rebate (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_reb_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH A/E Rebate (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_reb_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH A/E Rebate (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MCH_reb_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MCH A/E Rebate (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_com_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI Commission (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_com_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI Commission (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_com_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI Commission (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_com_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI Commission (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_com_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI Commission (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_com_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI Commission (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_reb_csd = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI A/E Rebate (CS)D'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_reb_csn = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI A/E Rebate (CS)N'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_reb_idf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI A/E Rebate (IDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_reb_inf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI A/E Rebate (INF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_reb_ndf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI A/E Rebate (NDF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHI_reb_nnf = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHI A/E Rebate (NNF)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHO_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHO Commission'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHO_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHO Commission(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHO_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHO A/E Rebate'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET MHO_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'HKEX' and fn = 'MHO A/E Rebate(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CBOT_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CBOT' and fn = 'US Futures Comm.'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CBOT_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CBOT' and fn = 'US Futures Comm (i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CBOT_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CBOT' and fn = 'US REB for AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CBOT_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CBOT' and fn = 'US REB for AE(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CME_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CME' and fn = 'US Futures Comm.'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CME_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CME' and fn = 'US Futures Comm (i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CME_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CME' and fn = 'US REB for AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET CME_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'CME' and fn = 'US REB for AE(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYBOT_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYBOT' and fn = 'US Futures Comm.'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYBOT_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYBOT' and fn = 'US Futures Comm (i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYBOT_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYBOT' and fn = 'US REB for AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYBOT_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYBOT' and fn = 'US REB for AE(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYMEX_com_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYMEX' and fn = 'US Futures Comm.'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYMEX_com_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYMEX' and fn = 'US Futures Comm (i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYMEX_reb_n = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYMEX' and fn = 'US REB for AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET NYMEX_reb_i = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'NYMEX' and fn = 'US REB for AE(i)'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET TGE_com = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'TGE' and fn = 'Japan Futures Comm.'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET TGE_reb = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'TGE' and fn = 'JP REB for AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET TOCOM_com = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'TOCOM' and fn = 'Japan Futures Comm.'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET TOCOM_reb = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'TOCOM' and fn = 'JP REB for AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET LME_com = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'LME' and fn = 'LME COMM'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "UPDATE #tmplist SET LME_reb = #fee_class.fee from #fee_class WHERE #tmplist.feeclass collate database_default = #fee_class.fc collate database_default AND mm = 'LME' and fn = 'LME REB of AE'"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            lstrSQL = "select * from #tmplist order by feeclass"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return Nothing
    End Function

End Class
