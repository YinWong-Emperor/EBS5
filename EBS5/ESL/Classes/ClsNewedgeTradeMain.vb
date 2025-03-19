Imports System.Data.SqlClient

Public Class ClsNewedgeTradeMain

    Protected Friend Function lFncGetTrades(ByVal trade_date As String, ByVal pCounterParty As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select tid, tdate, buy, sell, monthcode, product, price, period, comm, clearing, levy " & _
                  "from newedge_cap_trade_hist " & _
                  "where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "trade")
        Return lds

    End Function

    Protected Friend Function lFncUpdateTrade(ByVal tid As String, ByVal tPeriod As String, _
                                                ByVal comm As String, ByVal clearing As String, _
                                                ByVal levy As String, ByRef MyTrans As SqlTransaction) As Long

        Dim lstrSQL As String

        lstrSQL = "update newedge_cap_trade_hist set period = '" & tPeriod & "', comm = " & comm & ", clearing = " & clearing & _
                    ", levy = " & levy & " where tid = " & tid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Sub lFncGetComm(ByVal period As String, ByVal commodity As String, ByRef comm As Double, _
                                            ByRef clearing As Double, ByRef levy As Double)

        Dim lstrSQL As String
        Dim lds As DataSet

        If period = "Electronic" Then
            lstrSQL = " electronic_comm, electronic_clearing, electronic_levy "
        Else
            lstrSQL = " floor_comm, floor_clearing, floor_levy "
        End If

        lstrSQL = "select " & lstrSQL & "from newedge_commod where commodity = '" & commodity & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "commod")

        If (lds.Tables(0).Rows.Count > 0) Then
            comm = lds.Tables(0).Rows(0).Item(0)
            clearing = lds.Tables(0).Rows(0).Item(1)
            levy = lds.Tables(0).Rows(0).Item(2)
        Else
            comm = 0
            clearing = 0
            levy = 0
        End If

    End Sub

    Protected Friend Function lFncWriteLog(ByVal tid As String, ByVal originalPeriod As String, _
                                            ByVal originalComm As Double, ByVal originalClearing As Double, _
                                            ByVal originalLevy As Double, ByVal curPeriod As String, _
                                            ByVal curComm As Double, ByVal curClearing As Double, _
                                            ByVal curLevy As Double, ByRef MyTrans As SqlTransaction) As Long

        Dim lstrSQL As String = ""

        If (originalPeriod <> curPeriod) Then
            lstrSQL = lstrSQL & "[Period]=''" & originalPeriod & "'' To ''" & curPeriod & "'' "
        End If
        If (originalComm <> curComm) Then
            lstrSQL = lstrSQL & "[Comm]=''" & originalComm & "'' To ''" & curComm & "'' "
        End If
        If (originalClearing <> curClearing) Then
            lstrSQL = lstrSQL & "[Clearing]=''" & originalClearing & "'' To ''" & curClearing & "'' "
        End If
        If (originalLevy <> curLevy) Then
            lstrSQL = lstrSQL & "[Levy]=''" & originalLevy & "'' To ''" & curLevy & "'' "
        End If

        If (lstrSQL.Length > 0) Then
            lstrSQL = "insert into LOGTBL(D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, D_TXMONTH, D_LOG) " & _
                        "values ('" & GStrloginID & "', getdate(), 'M', 'NewedgeTrade', '', '', getdate(), '" & tid & "', '', '" & lstrSQL & "') "
            Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        End If

        Return 0

    End Function

End Class
