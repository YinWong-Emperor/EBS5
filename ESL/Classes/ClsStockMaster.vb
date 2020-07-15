Public Class ClsStockMaster
    Protected Friend Function lFnGetProductType() As DataSet
        Dim ds As New DataSet
        Dim lstr As String = ""
        lstr += " SELECT "
        lstr += "   RTRIM(description) as description"
        lstr += " FROM "
        lstr += "   " & GStrG2BSDB & ".dbo.stock_type "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "stock_type")
        Return ds
    End Function

    Function lFncExportStockMaster(ByVal selectedProductTypes As String(), ByVal cpDate As DateTime) As Boolean

        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet
        Dim strExFile As String = "stock_master.csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            lstrSQL += " SELECT "
            lstrSQL += "   mm.name_s as MarketName, "
            lstrSQL += "   smSum.stkno as StockCode, "
            lstrSQL += "   smSum.s_code as ShortName, "
            lstrSQL += "   smSum.name as EngName, "
            lstrSQL += "   smSum.name_c as ChiName, "
            lstrSQL += "   case smSum.short_sell "
            lstrSQL += "     WHEN 0 THEN 'Yes' "
            lstrSQL += "     WHEN 1 THEN 'No' "
            lstrSQL += "     ELSE 'NA'  "
            lstrSQL += "   end as ShortSell,  "
            lstrSQL += "   isnull(REPLACE(REPLACE(sg.MarginRatio, 'STK GRADE', ''), '%', ''), '') as MarginRatio,  "
            lstrSQL += "   isnull(st.description, '') as Type,   "
            lstrSQL += "   isnull(convert(varchar, smSum.date_delisted, 103), '') as DelistedDate,  "
            lstrSQL += "   isnull(convert(varchar, smSum.date_suspend, 103), '') as SuspendDate   "
            lstrSQL += " FROM (   "
            lstrSQL += " 	SELECT		 "
            lstrSQL += " 	  stkno,		 "
            lstrSQL += " 	  mkid,		 "
            lstrSQL += " 	  sgdid,		 "
            lstrSQL += " 	  type,		 "
            lstrSQL += " 	  short_sell,  		 "
            lstrSQL += " 	  s_code,		 "
            lstrSQL += " 	  name,		 "
            lstrSQL += " 	  name_c,		 "
            lstrSQL += " 	  date_delisted,		 "
            lstrSQL += " 	  date_suspend		 "
            lstrSQL += " 	FROM		 "
            lstrSQL += " 	  " & GStrG2BSDB & ".dbo.stock_master sm "
            If cpDate <> DateTime.MinValue Then
                lstrSQL += " 	WHERE EXISTS (		 "
                lstrSQL += " 	  SELECT		 "
                lstrSQL += " 		stkno,	 "
                lstrSQL += " 		mkid	 "
                lstrSQL += " 	  FROM (  		 "
                lstrSQL += " 		SELECT	 "
                lstrSQL += " 		  stkno,	 "
                lstrSQL += " 		  mkid	 "
                lstrSQL += " 		FROM	 "
                lstrSQL += " 		  " & GStrG2BSDB & ".dbo.stock_cp sc "
                lstrSQL += "      WHERE "
                lstrSQL += "        cp_date = '" + Format(cpDate, "yyyy-MM-dd") + "' "
                lstrSQL += " 	  ) scp  		 "
                lstrSQL += " 	  WHERE 		 "
                lstrSQL += " 		scp.mkid = sm.mkid	 "
                lstrSQL += " 		  AND scp.stkno = sm.stkno	 "
                lstrSQL += " 	) "
            End If
            lstrSQL += " ) smSum "
            lstrSQL += " INNER JOIN ( "
            lstrSQL += "   SELECT "
            lstrSQL += "     type, "
            lstrSQL += "     description "
            lstrSQL += "   FROM "
            lstrSQL += "     " & GStrG2BSDB & ".dbo.stock_type "
            lstrSQL += "   WHERE "
            For i As Integer = 0 To selectedProductTypes.Count - 1
                If i < selectedProductTypes.Count - 1 Then
                    lstrSQL += " description = '" + selectedProductTypes(i) + "' OR "
                Else
                    lstrSQL += " description = '" + selectedProductTypes(i) + "' "
                End If
            Next
            lstrSQL += " ) st "
            lstrSQL += " ON "
            lstrSQL += "   st.type = smSum.type  "
            lstrSQL += " INNER JOIN ( "
            lstrSQL += "   SELECT "
            lstrSQL += "     mkid,  "
            lstrSQL += "     name_s "
            lstrSQL += "   FROM "
            lstrSQL += "     " & GStrG2BSDB & ".dbo.market_master mm "
            If cpDate <> DateTime.MinValue Then
                lstrSQL += " WHERE EXISTS ( "
                lstrSQL += "   SELECT "
                lstrSQL += "     1 "
                lstrSQL += "   FROM "
                lstrSQL += "     SystemStaticParam ssp "
                lstrSQL += "   WHERE"
                lstrSQL += "     ParamType = 'ExportStockMaster' "
                lstrSQL += "       AND ParamName = 'SelectedExchange' "
                lstrSQL += "       AND mm.name_s = ssp.CharValue COLLATE database_default"
                lstrSQL += " ) "
            End If
            lstrSQL += " ) mm   "
            lstrSQL += " ON "
            lstrSQL += "   mm.mkid = smSum.mkid "
            lstrSQL += " LEFT JOIN ( "
            lstrSQL += "   SELECT "
            lstrSQL += "     sgdid, "
            lstrSQL += "     name as MarginRatio "
            lstrSQL += "   FROM "
            lstrSQL += "     " & GStrG2BSDB & ".dbo.stk_grade "
            lstrSQL += " ) sg "
            lstrSQL += " ON "
            lstrSQL += "   sg.sgdid = smSum.sgdid "
            lstrSQL += " ORDER BY "
            lstrSQL += "   mm.name_s, "
            lstrSQL += "   st.TYPE, "
            lstrSQL += "   sg.marginRatio, "
            'lstrSQL += "   smSum.stockCode "
            lstrSQL += "   smSum.stkno "

            ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            If (ldtsTemp.Tables(0).Rows.Count > 0) Then
                GExportCSV(GStrExptDir, strExFile, ldtsTemp, "Market Name,Stock Code,Short Name,Eng Name,Chi Name,Short Sell,Margin Ratio (%),Type,Delisted Date,Suspend Date")
                Return True
            End If

            GSubShowInfo(GFncGetSysMsg(2))
        End If

        Return False
    End Function
End Class
