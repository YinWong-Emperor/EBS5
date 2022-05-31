Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsNewedgeCommDiff

    Dim clsRpt As New ClsReports

    Protected Friend Function lFnGetComm(ByVal tdate As Date) As DataSet

        Dim lstrSQL As String
        'lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
        '                  "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
        '                  "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
        '                  "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
        '                  "from newedge_cap_trade_hist " & _
        '                  "where tdate = '" & Format(tdate, "yyyyMMdd") & "' " & _
        '                  "group by monthcode, product) a " & _
        '                  "full join (select monthcode, product, comm, clearing, exchange " & _
        '                  "from newedge_cap_fee " & _
        '                  "where tdate = '" & Format(tdate, "yyyyMMdd") & "') b " & _
        '                  "on a.monthcode = b.monthcode and a.product = b.product " & _
        '                  "order by a.product, a.monthcode"
        lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
                    "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
                    "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
                    "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
                    "from vw_cap_trade_hist " & _
                    "where tdate = '" & Format(tdate, "yyyyMMdd") & "' " & _
                    "group by monthcode, product) a " & _
                    "full join (select monthcode, product, comm, clearing, exchange " & _
                    "from newedge_cap_fee " & _
                    "where tdate = '" & Format(tdate, "yyyyMMdd") & "') b " & _
                    "on a.monthcode = b.monthcode and a.product = b.product " & _
                    "order by a.product, a.monthcode"

        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "product")

    End Function

    Protected Friend Function lFncGetDiffRpt(ByVal tdate As Date) As ReportClass

        Dim lstrSQL As String
        Dim ldtsTemp As DataSet
        Dim rpt As New RptNewedgeCommDiff

        'lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
        '            "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
        '            "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
        '            "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
        '            "from newedge_cap_trade_hist " & _
        '            "where tdate = '" & Format(tdate, "yyyyMMdd") & "' " & _
        '            "group by monthcode, product) a " & _
        '            "full join (select monthcode, product, comm, clearing, exchange " & _
        '            "from newedge_cap_fee " & _
        '            "where tdate = '" & Format(tdate, "yyyyMMdd") & "') b " & _
        '            "on a.monthcode = b.monthcode and a.product = b.product " & _
        '            "where (a.comm <> b.comm or a.clearing <> b.clearing or a.levy <> b.exchange) " & _
        '            "order by a.product, a.monthcode"
        lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
                    "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
                    "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
                    "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
                    "from vw_cap_trade_hist " & _
                    "where tdate = '" & Format(tdate, "yyyyMMdd") & "' " & _
                    "group by monthcode, product) a " & _
                    "full join (select monthcode, product, comm, clearing, exchange " & _
                    "from newedge_cap_fee " & _
                    "where tdate = '" & Format(tdate, "yyyyMMdd") & "') b " & _
                    "on a.monthcode = b.monthcode and a.product = b.product " & _
                    "where (a.comm <> b.comm or a.clearing <> b.clearing or a.levy <> b.exchange) " & _
                    "order by a.product, a.monthcode"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle", "NewEdge Difference Report")
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("NewEdge Difference Report")
        End If

    End Function

End Class
