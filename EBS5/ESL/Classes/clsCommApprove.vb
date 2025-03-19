Imports System.Data.SqlClient

Public Class clsCommApprove

    Public Function FncGetMonth() As String
        Dim monthCode As String = Format(Date.Now, "yyyyMM")
        Dim str As String = "select misc_code from misc_master where misc_type = 'Commmonth'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            monthCode = GFncNoNullString(dt.Rows(0).Item("misc_code")).Trim
        End If
        Return monthCode
    End Function

    Public Function FncGetLastPostingTime(ByVal month As String) As String
        Dim lpt As String = ""
        Dim str As String = "select * from comm_last_posting_time where d_month = '" & month & "' order by d_date DESC"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            lpt = GFncNoNullString(dt.Rows(0).Item("d_date")).Trim
            lpt = Format(CDate(lpt), "yyyy/MM/dd HH:mm:ss")
        End If
        Return lpt
    End Function

    Public Function FncGetLogs(ByVal mCode As String, ByVal lpt As String, Optional ByVal lpt2 As String = "", Optional ByVal AE As String = "") As DataTable
        Dim str As String = "select a.*, b.misc_desc from logtbl a inner join misc_master b on b.misc_code = a.d_type " & _
            "and b.misc_type = 'CommLog' where d_txmonth = '" & mCode & "' "
        If lpt <> "" Then
            str &= "and a.d_Date >= '" & Format(CDate(lpt), "yyyy/MM/dd HH:mm:ss") & "' "
        End If
        If lpt2 <> "" Then
            str &= "and a.d_Date <= '" & Format(CDate(lpt2), "yyyy/MM/dd HH:mm:ss") & "' "
        End If
        If AE <> "" Then
            str &= "and a.d_ae = '" & AE & "' "
        End If
        str &= "order by b.misc_desc ASC, a.d_date ASC"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        For Each dr As DataRow In dt.Rows
            If Format(GFncNoNullDate(dr("d_o_tdate")), "yyyy/MM/dd") = "1900/01/01" Then
                dr("d_o_tdate") = System.DBNull.Value
            End If
            Dim action As String = GFncNoNullString(dr("d_action")).Trim
            If action.ToUpper = "A" Then
                dr("d_action") = "Add"
            ElseIf action.ToUpper = "M" Then
                dr("d_action") = "Modify"
            ElseIf action.ToUpper = "D" Then
                dr("d_action") = "Delete"
            End If
            If GFncNoNullString(dr("d_oid")).Trim = "0" Then
                dr("d_oid") = System.DBNull.Value
            Else
                dr("d_oid") = GFncNoNullString(dr("d_oid")).Trim
            End If
        Next
        Return dt
    End Function

    Public Function FncLockFnc(ByVal mCode As String, ByVal lpt As String, ByVal month As String) As Boolean
        Dim selectStr As String = "select distinct misc_code from misc_master where misc_type = 'Commlog'"
        Dim str As String = " insert into function_access (fncuserID, fncobjectkey) select '*ALL', fiobjectkey from " & _
            "function_info where fidesc in (" & selectStr & ")"
        Dim mytrans As SqlTransaction = Nothing
        Try
            mytrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, mytrans, str) < 0 Then
                mytrans.Rollback()
                Return False
            End If
            str = "delete from misc_master where misc_type = 'CommStatus'"
            If GFncRunSQL(GSCnSqlConn, mytrans, str) < 0 Then
                mytrans.Rollback()
                Return False
            End If
            str = "insert into misc_master (misc_type, misc_code) values ('CommStatus', 'Locked')"
            If GFncRunSQL(GSCnSqlConn, mytrans, str) <= 0 Then
                mytrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Lock Status", "Locked")
            GFncFillLog(GStrloginID, "A", GDteTradeDate, "COMMLOCK", Nothing, Nothing, Nothing, month, logStr, mytrans)
            mytrans.Commit()
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                mytrans.Rollback()
            End If
            GSubWriteErrLog("FncLockFnc: " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function FncUnlockFnc(ByVal month As String, Optional ByVal intrans As SqlTransaction = Nothing) As Boolean
        Dim str As String = "delete from function_access where fncuserID = '*ALL'"
        Dim mytrans As SqlTransaction = Nothing
        Try
            If intrans Is Nothing Then
                mytrans = GSCnSqlConn.BeginTransaction
            Else
                mytrans = intrans
            End If
            If GFncRunSQL(GSCnSqlConn, mytrans, str) < 0 Then
                mytrans.Rollback()
                Return False
            End If
            str = "delete from misc_master where misc_type = 'CommStatus'"
            If GFncRunSQL(GSCnSqlConn, mytrans, str) < 0 Then
                mytrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Lock Status", "Unlocked")
            GFncFillLog(GStrloginID, "D", GDteTradeDate, "COMMLOCK", Nothing, Nothing, Nothing, month, logStr, mytrans)
            If intrans Is Nothing Then
                mytrans.Commit()
                mytrans.Dispose()
                mytrans = Nothing
            End If
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                mytrans.Rollback()
            End If
            GSubWriteErrLog("FncUnLockFnc: " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function FncDeleteTable(ByVal mytrans As SqlTransaction, ByVal mCode As String, ByVal lpt As String, ByRef dt As DataTable) As Boolean
        Dim selectStr As String = "select distinct d_type from logtbl where d_txmonth = '" & mCode & "' "
        If lpt <> "" Then
            selectStr &= "and d_Date >= '" & lpt & "' "
        End If
        Dim str As String = "select distinct misc_desc from misc_master where misc_type = 'CommRelatedTable' and misc_code in " & _
            "(" & selectStr & ")"
        dt = GFncRtnDS(GSCnSqlConn, str, mytrans).Tables(0)
        For Each dr As DataRow In dt.Rows
            Dim dbName As String = GFncNoNullString(dr("misc_desc")).Trim
            If dbName.ToUpper <> "MISC_MASTER" Then
                str = "delete from " & dbName
                If GFncRunSQL(GSCnSqlConn, mytrans, str, 0) < 0 Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function FncInsertData(ByVal mytrans As SqlTransaction, ByVal dt As DataTable) As Boolean
        For Each dr As DataRow In dt.Rows
            Dim dbName As String = GFncNoNullString(dr("misc_desc")).Trim
            If dbName.ToUpper <> "MISC_MASTER" Then
                Dim tableDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from " & dbName, mytrans).Tables(0)
                Dim fieldStr As String = " ("
                For Each dc As DataColumn In tableDt.Columns
                    fieldStr &= GFncNoNullString(dc.ColumnName).Trim & ", "
                Next
                fieldStr = fieldStr.Substring(0, fieldStr.Length - 2) & ") "
                Dim str As String = "insert into " & dbName & fieldStr & "select * from Draft_" & dbName
                Try
                    If GFncRunSQL(GSCnSqlConn, mytrans, str, 0) < 0 Then
                        Return False
                    End If
                Catch ex As Exception
                    GFncRunSQL(GSCnSqlConn, mytrans, "set IDENTITY_INSERT " & dbName & " on")
                    If GFncRunSQL(GSCnSqlConn, mytrans, str, 0) < 0 Then
                        Return False
                    End If
                    GFncRunSQL(GSCnSqlConn, mytrans, "set IDENTITY_INSERT " & dbName & " off")
                End Try
            End If
        Next
        Return True
    End Function

    Public Function FncUpdateLPT(ByVal mytrans As SqlTransaction, ByVal month As String) As Boolean
        'Dim str As String = "delete from comm_last_posting_time"
        'If GFncRunSQL(GSCnSqlConn, mytrans, str) < 0 Then
        '    Return False
        'End If
        Dim str As String = "insert into comm_last_posting_time (d_date, d_month) values (getdate(), '" & month & "')"
        If GFncRunSQL(GSCnSqlConn, mytrans, str) < 0 Then
            Return False
        End If
        'Dim logStr As String = GfncOneFieldLog("Lock Status", "Unlocked")
        'GFncFillLog(GStrloginID, "D", GDteTradeDate, "COMMLOCK", Nothing, Nothing, Nothing, month, logStr, mytrans)
        Dim logStr As String = GfncOneFieldLog("Approve Logs", "Approved")
        GFncFillLog(GStrloginID, "A", GDteTradeDate, "CommApprove", Nothing, Nothing, Nothing, month, logStr, mytrans)
        Return True
    End Function

    Public Function FncGetApprovedTime(ByVal month As String)
        Dim str As String = "select * from comm_last_posting_time where d_month = '" & month & "' order by d_date DESC"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Public Function FncGetAE() As DataTable
        Dim str As String = "select * from comm_ae_master order by ae_no ASC"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Public Function FncCheckCommMonth(ByVal month As String, ByVal lpt As String) As Boolean
        Dim str As String = "select * from logtbl where d_type = 'COMMMONTH' and d_txmonth = '" & month & _
            "' and d_log like '%Commission Month% = ''%''% To ''" & month & "''' "
        If lpt <> "" Then
            str &= "and d_date > '" & lpt & "' "
        End If
        str = str.Trim
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
