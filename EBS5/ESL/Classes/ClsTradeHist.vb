Imports System.Data.SqlClient
Imports System.IO

Public Class ClsTradeHist

    Protected Friend Function lFncExport(ByVal strStock As String, _
    ByVal dteFrom As Date, ByVal dteTo As Date, ByVal intOpt As Integer) As Boolean
        Dim lstrSQL As String
        Dim lstrEXDir As String = "c:\itas\"
        Dim lstrEXFile As String = "Trading_History_" & strStock & _
                "_" & Format(dteFrom, "yyyyMMdd") & _
                "_" & Format(dteTo, "yyyyMMdd") & ".csv"

        If GSubShowYNConfirm(GFncGetSysMsg(27) & " To " & lstrEXDir & lstrEXFile) _
               <> Windows.Forms.DialogResult.Yes Then
            GSubShowInfo(GFncGetSysMsg(29))
            Return False
        End If

        lstrSQL = "CREATE TABLE #History ( dt datetime, acc nvarchar(8), ae nvarchar(8), " & _
                                " ac_name nvarchar(50), ac_id nvarchar(50), " & _
                                " share_bought decimal(18,2), " & _
                                " share_sold decimal(18,2), " & _
                                " info_pce decimal(18,2), " & _
                                " h_tel nvarchar(100), " & _
                                " addr nvarchar(150), " & _
                                " info_qty decimal(10, 0)) "
        GFncRunSQL(GSCnSqlConn, lstrSQL)

        Select Case intOpt
            Case 1
                If Not Me.lfncGetIASIATradeHistory(strStock, dteFrom, dteTo) Then
                    Me.lsubReturn()
                    Return False
                End If
            Case 2
                If Not Me.lfncGetAFETradeHistory(strStock, dteFrom, dteTo) Then
                    Me.lsubReturn()
                    Return False
                End If
            Case 3
                If dteFrom < CDate("2005-11-04") Then
                    If Not Me.lfncGetIASIATradeHistory(strStock, dteFrom, CDate("2005-11-03")) Then
                        Me.lsubReturn()
                        Return False
                    End If
                End If
                If dteTo >= CDate("2005-11-04") Then
                    If Not Me.lfncGetAFETradeHistory(strStock, CDate("2005-11-04"), dteTo) Then
                        Me.lsubReturn()
                        Return False
                    End If
                End If
        End Select

        If Not Me.lfncTHCSV(lstrEXDir, lstrEXFile) Then
            Me.lsubReturn()
            Return False
        End If

        lstrSQL = "drop TABLE #History "
        GFncRunSQL(GSCnSqlConn, lstrSQL)

        Return True

    End Function
    Protected Friend Sub lsubReturn()

        Dim lstrSQL As String

        lstrSQL = "drop TABLE #History "
        GFncRunSQL(GSCnSqlConn, lstrsql)

        GSubShowInfo(GFncGetSysMsg(29))
    End Sub
    Protected Friend Function lfncGetIASIATradeHistory(ByVal strStock As String, _
      ByVal dteFrom As Date, ByVal dteTo As Date) As Boolean
        Dim lstrSQL As String = ""
        Dim ldtsIA As DataSet
        Dim ldtwIA As DataRow
        Dim lintCnt As Integer
        Dim lstrFPrice As String
        Dim lstrFQty As String

        If Len(strStock) = 5 And strStock.Substring(0, 1) = "0" Then
            strStock = strStock.Substring(1, 4)
        End If

        lstrSQL = " SELECT  iac.ACC AS ac_code," & _
                " iac.AE AS ae_code, iac.AC_NAME AS ac_name," & _
                 " iac.AC_ID AS ac_id,iac.H_TEL," & _
                " iac.ADDR, ise.* " & _
                " FROM  itas_user.itas_developers.itas_fmsedt ise inner join " & _
                " itas_user.itas_developers.itas_fmacdt iac on iac.ACC = ise.ACC " & _
                " where ise.dt between '" & Format(dteFrom, "yyyyMMdd") & _
                "' and '" & Format(dteTo, "yyyyMMdd") & _
                "' and ise.coll = '" & strStock & "' "
        ldtsIA = GFncRtnDS(GSCnSqlConn, lstrSQL)

        For Each ldtwIA In ldtsIA.Tables(0).Rows
            For lintCnt = 1 To 18
                lstrFPrice = "INFO_PCE_" & lintCnt.ToString.Trim
                lstrFQty = "INFO_QTY_" & lintCnt.ToString.Trim
                If ldtwIA(lstrFQty) <> 0 Then
                    Try
                        lstrSQL = "insert into #history (dt, acc, ae, " & _
                                " ac_name, ac_id,  share_bought, share_sold, info_pce, h_tel, addr) " & _
                                " values ('" & ldtwIA("DT").ToString.Substring(0, 4) & "/" & _
                                ldtwIA("DT").ToString.Substring(4, 2) & "/" & _
                                ldtwIA("DT").ToString.Substring(6, 2) & "','" & _
                                ldtwIA("ac_code") & "','" & ldtwIA("ae_code") & _
                                "','" & lfncRep(ldtwIA("ac_name")) & "','" & ldtwIA("ac_id") & "'," & _
                                IIf(ldtwIA("tn_type") = "B", Str(ldtwIA(lstrFQty)), "0") & "," & _
                                IIf(ldtwIA("tn_type") = "S", Str(ldtwIA(lstrFQty)), "0") & "," & _
                                Str(ldtwIA(lstrFPrice)) & ",'" & lfncRep(ldtwIA("h_tel")) & "','" & _
                                lfncRep(ldtwIA("addr")) & "') "
                        GFncRunSQL(GSCnSqlConn, lstrSQL)
                    Catch ex As Exception
                        GSubWriteErrLog("GFncRunSQL: " & ex.Message & Environment.NewLine & lstrSQL)
                        Return False
                    End Try
                End If
            Next
        Next

        Return True

    End Function
    Protected Friend Function lfncRep(ByVal lstrField As String) As String
        Return Replace(lstrField, "'", " ")
    End Function
    Protected Friend Function lfncGetAFETradeHistory(ByVal strStock As String, _
    ByVal dteFrom As Date, ByVal dteTo As Date) As Boolean
        Dim lstrSQL As String = ""

        Try
            lstrSQL = " insert into #History " & _
                               " SELECT ctr.tdate AS dt, " & _
                             " con.client_code AS acc, " & _
                             " con.ae_code AS ae, " & _
                              " con.client_name AS ac_name, " & _
                              " con.HKID as ac_id, " & _
                              " case ctr.BS when 'B' then ord.ttlqty else 0 end as share_bought, " & _
                               " case ctr.BS when 'S' then ord.ttlqty else 0 end as share_sold, " & _
                                "  ord.price AS info_pce, " & _
                                 " con.contact_no AS h_tel, " & _
                              " rtrim(con.addr_1) + " & _
                              " rtrim(con.addr_2) + " & _
                              " rtrim(con.addr_3) + " & _
                             "  rtrim(con.addr_4) as addr, " & _
                             "  ord.ttlqty AS info_qty " & _
                               " FROM " & GStrG2BSDB & ".dbo.view_client_contact_info con " & _
                               "  INNER JOIN " & GStrG2BSDB & ".dbo.view_ER_ctrade_namt ctr " & _
                              "  ON  con.client_code = ctr.accno  " & _
                              "   INNER JOIN " & GStrG2BSDB & ".dbo.view_client_order_detail_all ord  " & _
                               " ON  ctr.oid = ord.oid " & _
                               " where ctr.tdate between '" & Format(dteFrom, "yyyy/MM/dd") & _
                               "' and '" & Format(dteTo, "yyyy/MM/dd") & _
                               "' and ctr.stkno = '" & strStock & "'  " & _
                               " order by con.client_code, ctr.tdate , ctr.BS "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            Return True

        Catch ex As Exception
            GSubWriteErrLog("GFncRunSQL: " & ex.Message & Environment.NewLine & lstrSQL)
            Return False
        End Try


    End Function

    Protected Friend Function lfncTHCSV(ByVal strEXDir As String, ByVal strExFile As String) As Boolean
        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtsData As DataSet
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        ldtsData = GFncRtnDS(GSCnSqlConn, " select dt, acc, ae, ac_name, ac_id," & _
                    " share_bought, share_sold, info_pce, h_tel, addr " & _
                    " from #history order by acc ")

        Try

            lstrFiles = System.IO.Directory.GetFiles(strEXDir, strExFile)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            lsWriter = New StreamWriter(strEXDir & strExFile, False, System.Text.Encoding.GetEncoding(950))
            lstrColValue = " dt, acc, ae, ac_name, ac_id, share_bought, share_sold, info_pce, h_tel, addr "
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()

            For Each ldtwData In ldtsData.Tables(0).Rows
                lstrColValue = ldtwData("dt") & ","
                lstrColValue += "=""" & ldtwData("acc") & """" & ","
                lstrColValue += "=""" & ldtwData("ae") & """" & ","
                lstrColValue += """" & ldtwData("ac_name") & """" & ","
                lstrColValue += """" & ldtwData("ac_id") & """" & ","
                lstrColValue += ldtwData("share_bought") & ","
                lstrColValue += ldtwData("share_sold") & ","
                lstrColValue += ldtwData("info_pce") & ","
                lstrColValue += """" & ldtwData("h_tel") & """" & ","
                lstrColValue += """" & ldtwData("addr") & """"
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
            Next
            lsWriter.Close()
            GSubShowInfo(GFncGetSysMsg(28) & " (" & strEXDir & strExFile & ")")
            Return True

        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
        End Try

        Return False

    End Function

End Class
