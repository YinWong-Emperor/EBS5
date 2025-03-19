Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class ClsRptCommAEDetail
    Dim clsRpt As New ClsReports
    Dim cls As New ClsCommAE

    Protected Friend Function PrintTotalCommSRpt(ByVal txmonth As String) As ReportClass
        Dim rpt As New RptCommAEDetailS
        Dim ldtDetail As DataTable = lFncCalTotalComm(txmonth)
        Dim GenstrSQL As String = "select top 1 luptdate, luptuser from comm_ae_comm where txmonth ='" & txmonth & "'"
        Dim GenDS As DataSet = GFncRtnDS(GSCnSqlConn, GenstrSQL)
        rpt.SetDataSource(ldtDetail)
        clsRpt.AddParam(rpt, "paraTDate", txmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        If GenDS.Tables(0).Rows.Count > 0 Then
            clsRpt.AddParam(rpt, "paraGenPerson", GenDS.Tables(0).Rows(0).Item("luptuser").ToString)
            clsRpt.AddParam(rpt, "paraGenTime", Format(GenDS.Tables(0).Rows(0).Item("luptdate"), "yyyy/MM/dd hh:mm:ss"))
        Else
            clsRpt.AddParam(rpt, "paraGenPerson", "")
            clsRpt.AddParam(rpt, "paraGenTime", "")
        End If
        Return rpt
    End Function

    Protected Friend Function PrintTotalCommFRpt(ByVal txmonth As String) As ReportClass
        Dim rpt As New RptCommAEDetailF
        Dim ldtDetail As DataTable = lfncParpareTODTF(txmonth)
        Dim GenstrSQL As String = "select top 1 luptdate, luptuser from comm_ae_comm where txmonth ='" & txmonth & "'"
        Dim GenDS As DataSet = GFncRtnDS(GSCnSqlConn, GenstrSQL)
        rpt.SetDataSource(ldtDetail)
        clsRpt.AddParam(rpt, "paraTDate", txmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        If GenDS.Tables(0).Rows.Count > 0 Then
            clsRpt.AddParam(rpt, "paraGenPerson", GenDS.Tables(0).Rows(0).Item("luptuser").ToString)
            clsRpt.AddParam(rpt, "paraGenTime", Format(GenDS.Tables(0).Rows(0).Item("luptdate"), "yyyy/MM/dd hh:mm:ss"))
        Else
            clsRpt.AddParam(rpt, "paraGenPerson", "")
            clsRpt.AddParam(rpt, "paraGenTime", "")
        End If
        Return rpt
    End Function

    Protected Friend Function PrintTotalCommMRpt(ByVal txmonth As String) As ReportClass
        Dim rpt As New RptCommAEDetailM
        Dim ldtDetailS As DataTable = cls.lFncCalTotalComm(txmonth).Tables(0)
        Dim ldtDetailF As DataTable = cls.lfncParpareTODTF(txmonth)
        Dim ldtComm As DataTable = cls.lfncUpdComm(txmonth, ldtDetailS, ldtDetailF)
        Dim GenstrSQL As String = "select top 1 luptdate, luptuser from comm_ae_comm where txmonth ='" & txmonth & "'"
        Dim GenDS As DataSet = GFncRtnDS(GSCnSqlConn, GenstrSQL)
        ldtComm = cls.lfncCalOther(txmonth, ldtComm)
        ldtComm = cls.lFncCalCommManager(ldtComm, txmonth)
        rpt.SetDataSource(ldtComm)
        clsRpt.AddParam(rpt, "paraTDate", txmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        If GenDS.Tables(0).Rows.Count > 0 Then
            clsRpt.AddParam(rpt, "paraGenPerson", GenDS.Tables(0).Rows(0).Item("luptuser").ToString)
            clsRpt.AddParam(rpt, "paraGenTime", Format(GenDS.Tables(0).Rows(0).Item("luptdate"), "yyyy/MM/dd hh:mm:ss"))
        Else
            clsRpt.AddParam(rpt, "paraGenPerson", "")
            clsRpt.AddParam(rpt, "paraGenTime", "")
        End If
        Return rpt
    End Function

    Protected Friend Function lFncCalTotalComm(ByVal txmonth As String) As DataTable
        Dim ldtDefDetail As DataTable = cls.lFncCalTotalComm(txmonth).Tables(0)
        Dim tradetype As DataTable = GFncRtnDS(GSCnSqlConn, "select * from misc_master where misc_type='TranAdjSTType'", "detail").Tables(0)
        Dim AccMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct acc_no, acc_name_s from comm_acc_master where inSec=1").Tables(0)
        Dim AeMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct ae_no, ae_name_s from comm_ae_master where inSec=1").Tables(0)

        Dim ldtDetail As DataTable = ldtDefDetail.Copy
        Dim type() As DataRow
        Dim ae() As DataRow
        Dim acc() As DataRow
        Dim Column As DataColumn
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ae_name"
        ldtDetail.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "acc_name"
        ldtDetail.Columns.Add(Column)
        For Each dr As DataRow In ldtDetail.Rows
            type = tradetype.Select("misc_code ='" & dr.Item("tradetype") & "'")
            If type.Length > 0 Then
                dr.Item("tradetype") = type(0).Item("misc_desc")
            End If
            acc = AccMaster.Select("acc_no ='" & dr.Item("acc_no") & "'")
            If acc.Length > 0 Then
                dr.Item("acc_name") = acc(0).Item("acc_name_s")
            End If
            ae = AeMaster.Select("ae_no ='" & dr.Item("ae_no") & "'")
            If ae.Length > 0 Then
                dr.Item("ae_name") = ae(0).Item("ae_name_s")
            End If
        Next


        Return ldtDetail
    End Function
    Protected Friend Function lfncParpareMan(ByVal txmonth As String) As DataTable
        Dim ldtDetailS As DataTable = cls.lFncCalTotalComm(txmonth).Tables(0)
        Dim ldtDetailF As DataTable = cls.lfncParpareTODTF(txmonth)
        Dim ldtComm As DataTable = cls.lfncUpdComm(txmonth, ldtDetailS, ldtDetailF)
        ldtComm = cls.lfncCalOther(txmonth, ldtComm)
        Return cls.lFncCalCommManager(ldtComm, txmonth)

    End Function
    Protected Friend Function lfncParpareTODTF(ByVal txmonth As String) As DataTable
        Dim ldtDefDetail As DataTable = cls.lfncParpareTODTF(txmonth)
        Dim AccMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct acc_no, acc_name_f from comm_acc_master where inFut=1").Tables(0)
        Dim AeMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct ae_no, ae_name_f from comm_ae_master where inFut=1").Tables(0)
        Dim ProdMaster As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct product_code, product_name from futures_product_master").Tables(0)

        Dim ldtDetail As DataTable = ldtDefDetail.Copy

        Dim ae() As DataRow
        Dim acc() As DataRow
        Dim prod() As DataRow
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
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "prod_name"
        ldtDetail.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "consolid"
        ldtDetail.Columns.Add(Column)
        For Each dr As DataRow In ldtDetail.Rows
            If dr.Item("txtype") = "F" Then
                dr.Item("txtype") = "Futures"
            ElseIf dr.Item("txtype") = "O" Then
                dr.Item("txtype") = "Options"
            End If
            acc = AccMaster.Select("acc_no ='" & dr.Item("acc_no") & "'")
            If acc.Length > 0 Then
                dr.Item("acc_name") = acc(0).Item("acc_name_f").ToString.Trim
            End If
            ae = AeMaster.Select("ae_no ='" & dr.Item("ae_no") & "'")
            If ae.Length > 0 Then
                dr.Item("ae_name") = ae(0).Item("ae_name_f").ToString.Trim
            End If
            prod = ProdMaster.Select("product_code ='" & dr.Item("commod") & "'")
            If ae.Length > 0 Then
                dr.Item("prod_name") = prod(0).Item("product_name").ToString.Trim
            End If
            If dr.Item("isconsolid") = 0 Then
                dr.Item("consolid") = "False"
            ElseIf dr.Item("isconsolid") = 1 Then
                dr.Item("consolid") = "True"
            End If
        Next
        'For row As Integer = 0 To ldtDetail.Rows.Count - 1
        '    If ldtDetail.Rows(row).Item("txtype") = "F" Then
        '        ldtDetail.Rows(row).Item("txtype") = "Futures"
        '    ElseIf ldtDetail.Rows(row).Item("txtype") = "O" Then
        '        ldtDetail.Rows(row).Item("txtype") = "Options"
        '    End If
        '    acc = AccMaster.Select("acc_no ='" & ldtDetail.Rows(row).Item("acc_no") & "'")
        '    If acc.Length > 0 Then
        '        ldtDetail.Rows(row).Item("acc_name") = acc(0).Item("acc_name_f").ToString.Trim
        '    End If
        '    ae = AeMaster.Select("ae_no ='" & ldtDetail.Rows(row).Item("ae_no") & "'")
        '    If ae.Length > 0 Then
        '        ldtDetail.Rows(row).Item("ae_name") = ae(0).Item("ae_name_f").ToString.Trim
        '    End If
        '    prod = ProdMaster.Select("product_code ='" & ldtDetail.Rows(row).Item("commod") & "'")
        '    If ae.Length > 0 Then
        '        ldtDetail.Rows(row).Item("prod_name") = prod(0).Item("product_name").ToString.Trim
        '    End If
        '    If ldtDetail.Rows(row).Item("isconsolid") = 0 Then
        '        ldtDetail.Rows(row).Item("consolid") = "False"
        '    ElseIf ldtDetail.Rows(row).Item("isconsolid") = 1 Then
        '        ldtDetail.Rows(row).Item("consolid") = "True"
        '    End If
        'Next


        Return ldtDetail
    End Function



End Class
