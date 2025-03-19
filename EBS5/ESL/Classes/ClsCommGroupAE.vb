Imports System.Data.SqlClient

Public Class ClsCommGroupAE

    Protected Friend Function lFncGetAEFullList(ByVal AE As String) As DataSet
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        If AE.Length > 0 Then
            lstrSQL = " and ae_no like '%" & AE & "%' "
        End If
        lstrSQL = "select ae_no from draft_comm_ae_master where inSec = 1 " & lstrSQL & " order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        Return lds
    End Function

    Protected Friend Function lFncGetGroup(ByVal txmonth As String, ByVal ae_no As String, ByVal group As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        If (ae_no <> "") Then
            lstrSQL += " and ae_no like '%" & ae_no & "%' "
        End If
        If (group <> "") Then
            lstrSQL += " and group_ae like '%" & group & "%' "
        End If
        lstrSQL = "select gpid, txmonth, group_ae, ae_no, case when calSpecial=1 then 'Y' else 'N' end as calSpecial, " & _
            "case when isConsolid=1 then 'Y' else 'N' end as isConsolid " & _
            "from draft_comm_group_ae_s where txmonth = '" & txmonth & "' " & lstrSQL & "order by gpid "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aed")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncGetAEName(ByVal ae_no As String) As String
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select ae_name_s from draft_comm_ae_master where ae_no = '" & ae_no & "' order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aename")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item(0)
        End If
        Return ""
    End Function

    Protected Friend Function lFncDeleteAE(ByVal gpid As Integer, ByVal month As String, ByVal gAE As String, ByVal ae As String, _
        ByVal special As Boolean, ByVal consolid As Boolean) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        lsqlstr = "delete from draft_comm_group_ae_s where gpid = " & gpid & ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Group AE", gAE) & " " & _
                GfncOneFieldLog("Use Special Scheme", IIf(special = False, "No", "Yes")) & " " & _
                GfncOneFieldLog("Consolidate", IIf(consolid = False, "No", "Yes"))
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "GROUPAE", ae, "", gpid, month, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        Return True
    End Function

    Protected Friend Function lFncIsValidAE(ByVal ae_no As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet

        lstrSQL = "select * from draft_comm_ae_master where ae_no = '" & ae_no & "' and inSec = 1 "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "ae")
        If (lds.Tables(0).Rows.Count <= 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncIsAEOverlap(ByVal txmonth As String, ByVal ae_no As String, ByVal group_ae As String, Optional ByVal gpid As String = "0") As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        If (gpid <> 0) Then
            lstrSQL = "and gpid <> " & gpid
        End If
        lstrSQL = "select * from draft_comm_group_ae_s where txmonth = '" & txmonth & "' and ae_no = '" & ae_no & _
            "' and group_ae = '" & group_ae & "' " & lstrSQL
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "ae")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncAddAE(ByVal ae_no As String, ByVal txmonth As String, ByVal group_ae As String, ByVal isSpecial As String, ByVal isConsolid As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "insert into draft_comm_group_ae_s (txmonth, group_ae, ae_no, calSpecial, isConsolid) " & _
            "values ('" & txmonth & "','" & group_ae & "','" & ae_no & "'," & isSpecial & "," & isConsolid & ") "
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Group AE", group_ae) & " " & GfncOneFieldLog("Use Special Scheme", _
                IIf(CBool(isSpecial) = False, "No", "Yes")) & " " & GfncOneFieldLog("Consolid", IIf(CBool(isConsolid) = False, "No", "Yes"))
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "GROUPAE", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function lFncEditAE(ByVal gpid As Integer, ByVal ae_no As String, ByVal group_ae As String, ByVal isSpecial As String, _
        ByVal isConsolid As String, Optional ByVal month As String = "") As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "update draft_comm_group_ae_s set group_ae='" & group_ae & "', ae_no='" & ae_no & _
            "', calSpecial=" & isSpecial & ", isConsolid=" & isConsolid & " where gpid = " & gpid
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_group_ae_s where gpid = " & gpid, lstnTrans).Tables(0)
            Dim oldGAE As String = ""
            Dim oldAE As String = ""
            Dim oldIsSpecial As String = ""
            Dim oldIsConsolid As String = ""
            If oldDt.Rows.Count > 0 Then
                oldGAE = GFncNoNullString(oldDt.Rows(0).Item("group_ae")).Trim
                oldAE = GFncNoNullString(oldDt.Rows(0).Item("ae_no")).Trim
                oldIsSpecial = GFncNoNullString(oldDt.Rows(0).Item("calSpecial")).Trim
                oldIsConsolid = GFncNoNullString(oldDt.Rows(0).Item("isConsolid")).Trim
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = ""
            If group_ae.Trim <> oldGAE Then
                logStr &= GfncOneFieldLog("Group AE", oldGAE, group_ae) & " "
            End If
            If ae_no <> oldAE Then
                logStr &= GfncOneFieldLog("AE NO", oldAE, ae_no) & " "
            End If
            If CBool(isSpecial) <> CBool(oldIsSpecial) Then
                logStr &= GfncOneFieldLog("Use Special Scheme", IIf(CBool(oldIsSpecial) = False, "No", "Yes"), IIf(CBool(isSpecial) = False, "No", "Yes")) & " "
            End If
            If CBool(isConsolid) <> CBool(oldIsConsolid) Then
                logStr &= GfncOneFieldLog("Consolid", IIf(CBool(oldIsConsolid) = False, "No", "Yes"), IIf(CBool(isConsolid) = False, "No", "Yes"))
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "GROUPAE", "", "", gpid, month, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        Return True
    End Function

    Protected Friend Function lFnGetGPID() As String
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select max(gpid) as newid from draft_comm_group_ae_s "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
        Return lds.Tables(0).Rows(0).Item(0).ToString
    End Function

End Class
