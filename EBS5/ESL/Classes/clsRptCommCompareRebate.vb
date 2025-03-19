Imports CrystalDecisions.CrystalReports.Engine

Public Class clsRptCommCompareRebate
    Dim clsRpt As New ClsReports
    Dim cls As New ClsCommAE

    Protected Friend Sub GetLatestDate(ByRef year As String, ByRef month As String)
        'Dim lstrSQL As String = " select max(txmonth) as maxmonth from view_comm_adjusted_s"
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        'If dt.Rows.Count > 0 Then
        '    year = CInt(dt.Rows(0).Item(0).ToString.Substring(0, 4)).ToString
        '    month = CInt(dt.Rows(0).Item(0).ToString.Substring(4, 2)).ToString
        'Else
        year = Now.Year
        month = Now.Month - 1
        'End If
    End Sub


    Protected Friend Function PrintTotalCommSRpt(ByVal txmonth As String, ByVal ae As String, ByVal full As Boolean, _
        ByVal range As Decimal, ByVal strSummary As String) As ReportClass
        Dim rpt As New RptCommCompareRebate
        Dim ldtDetail As DataTable = lFncCalTotalComm(txmonth, ae, full, range)
        rpt.SetDataSource(ldtDetail)
        clsRpt.AddParam(rpt, "paraTDate", txmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "parasummary", strSummary)
        Return rpt
    End Function

    Protected Friend Function lFncCalTotalComm(ByVal txmonth As String, ByVal ae_no As String, ByVal full As Boolean, ByVal range As Decimal) As DataTable
        Dim ldtDetail As DataTable = cls.lFncCalTotalComm(txmonth).Tables(0)
        Dim tradetype As DataTable = GFncRtnDS(GSCnSqlConn, "select * from misc_master where misc_type='TranAdjSTType'", "detail").Tables(0)
        Dim AccMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct acc_no, acc_name_s from comm_acc_master where inSec=1").Tables(0)
        Dim AeMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct ae_no, ae_name_s from comm_ae_master where inSec=1").Tables(0)
        Dim RebateMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select * from view_comm_adjusted_s where txmonth ='" & txmonth & "'").Tables(0)
        Dim type() As DataRow
        Dim ae() As DataRow
        Dim acc() As DataRow
        Dim Rebate() As DataRow
        Dim Column As DataColumn
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ae_name"
        ldtDetail.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "acc_name"
        ldtDetail.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Rebate"
        ldtDetail.Columns.Add(Column)
        For row As Integer = 0 To ldtDetail.Rows.Count - 1
            type = tradetype.Select("misc_code ='" & ldtDetail.Rows(row).Item("tradetype") & "'")
            If type.Length > 0 Then
                ldtDetail.Rows(row).Item("tradetype") = type(0).Item("misc_desc")
            End If
            acc = AccMaster.Select("acc_no ='" & ldtDetail.Rows(row).Item("acc_no") & "'")
            If acc.Length > 0 Then
                ldtDetail.Rows(row).Item("acc_name") = acc(0).Item("acc_name_s")
            End If
            ae = AeMaster.Select("ae_no ='" & ldtDetail.Rows(row).Item("ae_no") & "'")
            If ae.Length > 0 Then
                ldtDetail.Rows(row).Item("ae_name") = ae(0).Item("ae_name_s")
            End If
            Rebate = RebateMaster.Select("oid ='" & ldtDetail.Rows(row).Item("oid") & "'")
            If ae.Length > 0 Then
                ldtDetail.Rows(row).Item("Rebate") = Rebate(0).Item("rebate")
            End If
        Next
        If ae_no <> "" Then
            Dim rows() As DataRow = ldtDetail.Select("ae_no='" & ae_no & "'")
            ldtDetail = ldtDetail.Clone
            For Each row As DataRow In rows
                ldtDetail.ImportRow(row)
            Next
        End If
        If Not full Then
            Dim rows() As DataRow = ldtDetail.Select("ae_comm-rebate>" & range & " or rebate-ae_comm>" & range)
            ldtDetail = ldtDetail.Clone
            For Each row As DataRow In rows
                ldtDetail.ImportRow(row)
            Next
        End If
        Return ldtDetail
    End Function

    Protected Friend Function FncGetAE() As DataTable
        Dim lstrSQL As String = "Select distinct ae_no, ae_name_s from comm_ae_master where inSec=1 order by ae_no"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

End Class
