Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptLog

    Dim clsRpt As New ClsReports

    Protected Friend Function gFncGetType() As DataSet
        'Return GFncRtnDS(GSCnSqlConn, "select misc_code, misc_desc from misc_master where misc_type = 'LOGTYPE' union select distinct d_type as misc_code, d_type as misc_desc from logtbl ")
        Return GFncRtnDS(GSCnSqlConn, "select misc_code, misc_desc from misc_master where misc_type = 'LOGTYPE' order by misc_code")
    End Function

    Protected Friend Function Executed_Rpt(ByVal lstrMonth As String, ByVal ldteFromDate As Date, ByVal ldteToDate As Date, ByVal acc_no As String, ByVal log_type As DataRow) As ReportClass

        Dim lstrSQL As String
        Dim ldtsTemp As DataSet
        Dim rpt As New RptLog

        'lstrSQL = " SELECT * " & _
        '            "FROM logtbl " & _
        '            "WHERE d_date >= '" & Format(ldteFromDate.Date, "yyyyMMdd") & "' " & _
        '            "AND d_date < '" & Format(ldteToDate.AddDays(1).Date, "yyyyMMdd") & _
        '            "' AND d_type = '" & log_type.Item("misc_code").ToString & "' " & _
        '            "ORDER BY d_date "
        lstrSQL = " SELECT * " & _
                    "FROM logtbl " & _
                    "WHERE d_date >= '" & Format(ldteFromDate.Date, "yyyyMMdd") & "' " & _
                    "AND d_date < '" & Format(ldteToDate.AddDays(1).Date, "yyyyMMdd") & _
                    "' AND d_type = '" & log_type.Item("misc_code").ToString & "' "
        If Trim(acc_no) <> "" Then
            lstrSQL = lstrSQL & " AND d_ac = '" & acc_no & "' "
        End If
        lstrSQL = lstrSQL & "ORDER BY d_date "
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraTitle", log_type.Item("misc_desc").ToString & " Log report")
            clsRpt.AddParam(rpt, "ParaDateRange", "For the Period  " & Format(ldteFromDate, "dd MMM yyyy") & " - " & Format(ldteToDate, "dd MMM yyyy"))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt(log_type.Item("misc_desc").ToString & " Log report")
        End If

    End Function

End Class
