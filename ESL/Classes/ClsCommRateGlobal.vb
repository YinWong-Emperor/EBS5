Imports System.Data.SqlClient

Public Class ClsCommRateGlobal
    Protected Friend Function GetLastestYear() As String
        Dim lstrSQL As String = "Select max(txmonth) as max_month from draft_comm_global"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, lstrSQL, "maxmonth")
        If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
            Return ds.Tables(0).Rows(0).Item(0)
        Else
            Return Now.Year & Format(Now.Month - 1, "00")
        End If
    End Function

    Protected Friend Function EnquirySearch(ByVal condition As String) As DataSet
        Dim lstrSQL As String = "Select case comm_type when 'ACC' then 'Account' when 'AE' then 'AE' when 'AGRP' then " & _
            "'A/C Group' when 'MAN' then 'Manager' End comm_type, txmonth, minNorAmt, minIntAmt, minNorRate_s, minIntRate_s, " & _
            "commNorRate, commIntRate, minFNorBrkRate, minFIntBrkRate, minONorBrkRate, minOIntBrkRate, commNorRate_f, " & _
            "commIntRate_f from draft_comm_global where 1=1 " & condition & " order by txmonth asc, comm_type desc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "GlobalRate")
    End Function

    Protected Friend Function ValidateDuplicate(ByVal month As String, ByVal type As String) As Boolean
        Dim lstrSQL As String = "Select * from draft_comm_global where txmonth ='" & month & "' and comm_type ='" & type & "'"
        If GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Friend Function NewRecord(ByVal month As String, ByVal type As String, ByVal minnoramt As Double, ByVal minIntAmt As Double, _
        ByVal minNorRate_s As Double, ByVal minIntRate_s As Double, ByVal commNorRate As Double, ByVal commIntRate As Double, _
        ByVal minFNorBrkRate As Double, ByVal minFIntBrkRate As Double, ByVal minONorBrkRate As Double, ByVal minOIntBrkRate As Double, _
        ByVal commNorRate_f As Double, ByVal commIntRate_f As Double)
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "Insert into draft_comm_global (comm_type, txmonth, minnoramt, minIntAmt, minNorRate_s, " & _
            "minIntRate_s, commNorRate, commIntRate, minFNorBrkRate, minFIntBrkRate, minONorBrkRate, minOIntBrkRate, " & _
            "commNorRate_f, commIntRate_f) Values ('" & type & "', '" & month & "', " & minnoramt & ", " & minIntAmt & ", " & _
            minNorRate_s & ", " & minIntRate_s & ", " & commNorRate & ", " & commIntRate & ", " & minFNorBrkRate & ", " & _
            minFIntBrkRate & ", " & minONorBrkRate & ",  " & minOIntBrkRate & ", " & commNorRate_f & ", " & commIntRate_f & ")"
        Dim logStr As String = GfncOneFieldLog("Commission Type", type.Trim) & " " & _
            GfncOneFieldLog("Min. Nor. Amt.", minnoramt) & " " & GfncOneFieldLog("Min. Int. Amt.", minIntAmt) & " " & _
            GfncOneFieldLog("Min. Nor. Rate Securities", minNorRate_s) & " " & _
            GfncOneFieldLog("Min. Int. Rate Securities", minIntRate_s) & " " & _
            GfncOneFieldLog("Commission Nor. Rate", commNorRate) & " " & GfncOneFieldLog("Commission Int. Rate", commIntRate) & _
            " " & GfncOneFieldLog("Min. Futures Nor. Brokrage Rate", minFNorBrkRate) & " " & _
            GfncOneFieldLog("Min. Futures Int. Brokrage Rate", minFIntBrkRate) & " " & _
            GfncOneFieldLog("Min. Option Nor. Brokrage Rate", minONorBrkRate) & " " & _
            GfncOneFieldLog("Min. Option Int. Brokrage Rate", minOIntBrkRate) & " " & _
            GfncOneFieldLog("Commission Nor. Rate Futures", commNorRate_f) & " " & _
            GfncOneFieldLog("Commission Int. Rate Futures", commIntRate_f)
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "GlobalRate", "", "", 0, month, logStr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
        Return True
    End Function


    Protected Friend Function EditRecord(ByVal month As String, ByVal type As String, ByVal minnoramt As Double, ByVal minIntAmt As Double, _
        ByVal minNorRate_s As Double, ByVal minIntRate_s As Double, ByVal commNorRate As Double, ByVal commIntRate As Double, _
        ByVal minFNorBrkRate As Double, ByVal minFIntBrkRate As Double, ByVal minONorBrkRate As Double, ByVal minOIntBrkRate As Double, _
        ByVal commNorRate_f As Double, ByVal commIntRate_f As Double)
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "Update draft_comm_global Set minnoramt = " & minnoramt & ", minIntAmt = " & minIntAmt & _
            ", minNorRate_s  = " & minNorRate_s & ", minIntRate_s = " & minIntRate_s & ", commNorRate = " & commNorRate & _
            ", commIntRate = " & commIntRate & ", minFNorBrkRate = " & minFNorBrkRate & ", minFIntBrkRate = " & minFIntBrkRate & _
            ", minONorBrkRate = " & minONorBrkRate & ", minOIntBrkRate = " & minOIntBrkRate & ", commNorRate_f = " & _
            commNorRate_f & ", commIntRate_f = " & commIntRate_f & " where txmonth ='" & month & "' and comm_type ='" & type & "'"
        Dim oldminnoramt As Double = 0
        Dim oldminIntAmt As Double = 0
        Dim oldminNorRate_s As Double = 0
        Dim oldminIntRate_s As Double = 0
        Dim oldcommNorRate As Double = 0
        Dim oldcommIntRate As Double = 0
        Dim oldminFNorBrkRate As Double = 0
        Dim oldminFIntBrkRate As Double = 0
        Dim oldminONorBrkRate As Double = 0
        Dim oldminOIntBrkRate As Double = 0
        Dim oldcommNorRate_f As Double = 0
        Dim oldcommIntRate_f As Double = 0
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_global where txmonth ='" & month & _
            "' and comm_type ='" & type & "'").Tables(0)
        If oldDt.Rows.Count > 0 Then
            oldminnoramt = GFncNoNullValue(oldDt.Rows(0).Item("minnoramt"))
            oldminIntAmt = GFncNoNullValue(oldDt.Rows(0).Item("minIntAmt"))
            oldminNorRate_s = GFncNoNullValue(oldDt.Rows(0).Item("minNorRate_s"))
            oldminIntRate_s = GFncNoNullValue(oldDt.Rows(0).Item("minIntRate_s"))
            oldcommNorRate = GFncNoNullValue(oldDt.Rows(0).Item("commNorRate"))
            oldcommIntRate = GFncNoNullValue(oldDt.Rows(0).Item("commIntRate"))
            oldminFNorBrkRate = GFncNoNullValue(oldDt.Rows(0).Item("minFNorBrkRate"))
            oldminFIntBrkRate = GFncNoNullValue(oldDt.Rows(0).Item("minFIntBrkRate"))
            oldminONorBrkRate = GFncNoNullValue(oldDt.Rows(0).Item("minONorBrkRate"))
            oldminOIntBrkRate = GFncNoNullValue(oldDt.Rows(0).Item("minOIntBrkRate"))
            oldcommNorRate_f = GFncNoNullValue(oldDt.Rows(0).Item("commNorRate_f"))
            oldcommIntRate_f = GFncNoNullValue(oldDt.Rows(0).Item("commIntRate_f"))
        End If
        Dim logstr As String = GfncOneFieldLog("Commission Type", type.Trim) & " "
        If oldminnoramt <> minnoramt Then
            logstr &= GfncOneFieldLog("Min. Nor. Amt.", oldminnoramt, minnoramt) & " "
        End If
        If oldminIntAmt <> minIntAmt Then
            logstr &= GfncOneFieldLog("Min. Int. Amt.", oldminIntAmt, minIntAmt) & " "
        End If
        If oldminNorRate_s <> minNorRate_s Then
            logstr &= GfncOneFieldLog("Min. Nor. Rate Securities", oldminNorRate_s, minNorRate_s) & " "
        End If
        If oldminIntRate_s <> minIntRate_s Then
            logstr &= GfncOneFieldLog("Min. Int. Rate Securities", oldminIntRate_s, minIntRate_s) & " "
        End If
        If oldcommNorRate <> commNorRate Then
            logstr &= GfncOneFieldLog("Commission Nor. Rate", oldcommNorRate, commNorRate) & " "
        End If
        If oldcommIntRate <> commIntRate Then
            logstr &= GfncOneFieldLog("Commission Int. Rate", oldcommIntRate, commIntRate) & " "
        End If
        If oldminFNorBrkRate <> minFNorBrkRate Then
            logstr &= GfncOneFieldLog("Min. Futures Nor. Brokerage Rate", oldminFNorBrkRate, minFNorBrkRate) & " "
        End If
        If oldminFIntBrkRate <> minFIntBrkRate Then
            logstr &= GfncOneFieldLog("Min. Futures Int. Brokerage Rate", oldminFIntBrkRate, minFIntBrkRate) & " "
        End If
        If oldminONorBrkRate <> minONorBrkRate Then
            logstr &= GfncOneFieldLog("Min. Option Nor. Brokerage Rate", oldminONorBrkRate, minONorBrkRate) & " "
        End If
        If oldminOIntBrkRate <> minOIntBrkRate Then
            logstr &= GfncOneFieldLog("Min. Option Int. Brokerage Rate", oldminOIntBrkRate, minOIntBrkRate) & " "
        End If
        If oldcommNorRate_f <> commNorRate_f Then
            logstr &= GfncOneFieldLog("Commission Nor. Rate Futures", oldcommNorRate_f, commNorRate_f) & " "
        End If
        If oldcommIntRate_f <> commIntRate_f Then
            logstr &= GfncOneFieldLog("Commission Int. Rate Futures", oldcommIntRate_f, commIntRate_f) & " "
        End If
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "GlobalRate", "", "", 0, month, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
        Return True
    End Function

    Protected Friend Function DeleteRecord(ByVal month As String, ByVal type As String)
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "Delete from draft_comm_global where txmonth ='" & month & "' and comm_type ='" & type & "'"
        Dim logstr As String = GfncOneFieldLog("Commission Type", type)
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "GlobalRate", "", "", 0, month, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(13))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
        Return True
    End Function

End Class

