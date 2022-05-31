Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class clsCommLog

    Protected Friend Function FncGetType() As DataTable
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select misc_code, misc_desc from misc_master where misc_type = 'COMMLOG' order by misc_desc").Tables(0)
        Dim resultDt As DataTable = GFncRtnDS(GSCnSqlConn, "select '' as misc_code, '' as misc_desc").Tables(0)
        Dim resultDr As DataRow
        For Each dr As DataRow In dt.Rows
            resultDr = resultDt.NewRow
            resultDr("misc_code") = GFncNoNullString(dr("misc_code")).Trim
            resultDr("misc_desc") = GFncNoNullString(dr("misc_desc")).Trim
            resultDt.Rows.Add(resultDr)
        Next
        Return resultDt
    End Function

    Protected Friend Function FncGetUser() As DataTable
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct uiUserID from User_Information order by uiUserID").Tables(0)
        Dim resultDt As DataTable = GFncRtnDS(GSCnSqlConn, "select '' as uiUserID").Tables(0)
        Dim resultDr As DataRow
        For Each dr As DataRow In dt.Rows
            resultDr = resultDt.NewRow
            resultDr("uiUserID") = GFncNoNullString(dr("uiUserID")).Trim
            resultDt.Rows.Add(resultDr)
        Next
        Return resultDt
    End Function

    Protected Friend Function FncGenReport(ByVal startTime As String, ByVal endTime As String, ByVal type As String, ByVal user As String) As ReportClass
        Dim str As String = "select a.d_user, a.d_date, a.d_action, b.misc_desc as d_type, a.d_ae, a.d_ac, a.d_o_tdate, a.d_oid, a.d_txmonth, " & _
                            "a.d_log from logtbl a inner join misc_master b on a.d_type = b.misc_code and b.misc_type = 'COMMLOG' where a.d_date " & _
                            "between '" & startTime & "' and '" & endTime & "'"
        If type <> "" Then
            str &= " and a.d_type = '" & type & "'"
        End If
        If user <> "" Then
            str &= " and a.d_user = '" & user & "'"
        End If
        str &= "order by b.misc_desc ASC, a.d_date ASC"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim rpt As New rptCommLog
        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        Dim condition As String = "[Date Range] From " & Format(CDate(startTime), "dd/MM/yyyy") & " To " & Format(CDate(endTime), "dd/MM/yyyy") & "          "
        If type <> "" Then
            condition &= "[Function Type] " & type & "          "
        End If
        If user <> "" Then
            condition &= "[Action User] " & user
        End If
        rpt.SetParameterValue("condition", condition)
        rpt.SetParameterValue("status", "")
        Return rpt
    End Function
End Class
