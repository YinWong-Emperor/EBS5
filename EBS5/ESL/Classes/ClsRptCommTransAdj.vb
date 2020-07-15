Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptCommTransAdj
    Dim clsRpt As New ClsReports

    Protected Friend Sub GetLatestDate(ByVal inYr As Integer, ByVal inMon As Integer)
        Dim query As String = " select max(a.txmonth) as txmonth  from (select max(txmonth)as txmonth from comm_adj_f " & _
                                            "union select max(txmonth)as txmonth from comm_adj_s " & _
                                            "union select max(txmonth)as txmonth from comm_trade_f " & _
                                            "union select max(txmonth)as txmonth from view_comm_trade_s ) a"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            inYr = dt.Rows(0).Item(0).ToString.Substring(0, 4)
            inMon = dt.Rows(0).Item(0).ToString.Substring(4, 2)
        Else
            inYr = Now.Year
            inMon = Now.Month - 1
        End If
    End Sub

    Protected Friend Function PrintCommRpt(ByVal inTxmonth As String) As ReportClass
        Dim rpt As New RptTransAdjS

        Dim GridDT As New DataTable
        InitCommSDT(GridDT)
        Dim query As String = "select * from comm_adj_s "
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select * from view_comm_trade_s where order by tdate desc, oid asc "
        Dim ViewDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select ae_no, isnull(ae_name, isnull(ae_name_s, '')) as  aename from comm_ae_master"
        Dim AeDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select acc_no, isnull(acc_name, isnull(acc_name_s, '')) as acname from comm_acc_master"
        Dim AcDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Dim AdjDr() As DataRow
        Dim GridDr As DataRow
        Dim AeDr() As DataRow
        Dim AcDr() As DataRow

        For Each dr As DataRow In ViewDT.Rows
            AdjDr = AdjDT.Select("oid ='" & dr.Item("oid") & "' and AdjAction<>'A' ")
            If AdjDr.Length > 0 Then
                If AdjDr(0).Item("adjaction") <> "D" Then
                    'show adj records
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = AdjDr(0).Item("oid")
                    GridDr.Item("txmonth") = AdjDr(0).Item("txmonth")
                    GridDr.Item("aeno") = AdjDr(0).Item("aeno")
                    GridDr.Item("accno") = AdjDr(0).Item("acno")
                    GridDr.Item("tdate") = AdjDr(0).Item("tdate")
                    GridDr.Item("stk") = AdjDr(0).Item("stk")
                    GridDr.Item("avgprice") = AdjDr(0).Item("price")
                    GridDr.Item("qty") = AdjDr(0).Item("qty")
                    GridDr.Item("grossamt") = AdjDr(0).Item("grossamt")
                    GridDr.Item("comm") = AdjDr(0).Item("commission")
                    GridDr.Item("comm_rate") = AdjDr(0).Item("comm_rate")
                    GridDr.Item("ttype") = GetTradeType(AdjDr(0).Item("tradetype"))
                    'GridDr.Item("adjaction") = "Adjusted"

                    AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        GridDr.Item("aename") = AdjDr(0).Item("ae").ToString.Trim
                    End If
                    AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        GridDr.Item("accname") = AdjDr(0).Item("acct").ToString.Trim
                    End If
                    GridDr.Item("stkname") = AdjDr(0).Item("stkname")
                    GridDT.Rows.Add(GridDr)
                End If
            Else
                'show unAdj record
                GridDr = GridDT.NewRow
                GridDr.Item("oid") = dr.Item("oid")
                GridDr.Item("txmonth") = dr.Item("txmonth")
                GridDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                GridDr.Item("accno") = dr.Item("accno").ToString.Trim
                GridDr.Item("tdate") = dr.Item("tdate")
                GridDr.Item("stk") = dr.Item("stkno")
                GridDr.Item("avgprice") = dr.Item("avgprice")
                GridDr.Item("qty") = dr.Item("qty")
                GridDr.Item("grossamt") = dr.Item("grossamt")
                GridDr.Item("comm") = dr.Item("commission")
                GridDr.Item("comm_rate") = dr.Item("comm_rate")
                GridDr.Item("ttype") = dr.Item("tradetype")
                'GridDr.Item("adjaction") = ""
                AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                If AeDr.Length > 0 Then
                    GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                Else
                    GridDr.Item("aename") = dr.Item("aename").ToString.Trim
                End If
                AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                If AcDr.Length > 0 Then
                    GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                Else
                    GridDr.Item("accname") = dr.Item("accname").ToString.Trim
                End If
                GridDr.Item("stkname") = dr.Item("stkname")
                GridDT.Rows.Add(GridDr)
            End If

        Next
        AdjDr = AdjDT.Select("Adjaction='A'")
        For Each dr As DataRow In AdjDr
            GridDr = GridDT.NewRow
            GridDr.Item("oid") = dr.Item("oid")
            GridDr.Item("txmonth") = dr.Item("txmonth")
            GridDr.Item("aeno") = dr.Item("aeno")
            GridDr.Item("accno") = dr.Item("acno")
            GridDr.Item("tdate") = dr.Item("tdate")
            GridDr.Item("stk") = dr.Item("stk")
            GridDr.Item("avgprice") = dr.Item("price")
            GridDr.Item("qty") = dr.Item("qty")
            GridDr.Item("grossamt") = dr.Item("grossamt")
            GridDr.Item("comm") = dr.Item("commission")
            GridDr.Item("comm_rate") = dr.Item("comm_rate")
            GridDr.Item("ttype") = GetTradeType(dr.Item("tradetype"))
            'GridDr.Item("adjaction") = "New"
            AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
            If AeDr.Length > 0 Then
                GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
            Else
                GridDr.Item("aename") = dr.Item("ae").ToString.Trim
            End If
            AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
            If AcDr.Length > 0 Then
                GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
            Else
                GridDr.Item("accname") = dr.Item("acct").ToString.Trim
            End If
            'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
            'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
            GridDr.Item("stkname") = dr.Item("stkname")
            GridDT.Rows.Add(GridDr)
        Next

        rpt.SetDataSource(GridDT)
        Return rpt
    End Function

    Private Sub InitCommSDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.String")
        'Column.ColumnName = "adjaction"
        'DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "oid"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aeno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aename"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "tdate"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "stk"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "stkname"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "avgprice"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "qty"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grossamt"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ttype"
        DT.Columns.Add(Column)
    End Sub

    Private Function GetTradeType(ByVal inVal As String) As String
        'If inVal = "4" Then
        '    Return "I-trade"
        'Else
        '    Return "Normal"
        'End If
        Dim query As String = " select misc_desc from misc_master where misc_type='TranAdjSTType' and misc_code='" & inVal & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function
End Class
