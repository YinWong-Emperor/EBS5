Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class clsAutoMatchReport

    Private strSQL As String = ""

    Public Function FncGenReport(ByVal tdate As String) As ReportClass
        Dim rpt As New rptNewedgeOpenPos
        Dim dt As DataTable = New dtsNewedge.OpenPosDataTable
        Dim str As String = ""
        str = "select a.code, a.tdate, case when a.type = 1 then a.qty else 0 end as buy, case when a.type = 2 then a.qty else 0 end as sell, " & _
            "a.accno, b.product_name, a.monthcode, a.price from FuturesOpenPost a left join futures_product_master b on b.product_code = a.code where " & _
            "a.counterparty = 'NEWEDGE' and a.tdate = '" & tdate & "' order by a.code"
        Dim eDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        str = "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product from vw_cap_op a inner join product_mapping b on " & _
            "b.d_newedge_code = a.product left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & tdate & "' order by b.d_code"
        'str = "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product from newedge_cap_op a inner join product_mapping b on " & _
        '   "b.d_newedge_code = a.product left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & tdate & "' order by b.d_code"
        Dim nDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim pCode As String = ""
        Dim pCount As Integer = 0
        Dim dr As DataRow = Nothing
        Dim nDr() As DataRow = Nothing
        Dim start As Integer = 0
        Dim fMonth As String = ""
        dr = eDt.NewRow
        dr("code") = ""
        eDt.Rows.Add(dr)
        dr = Nothing

        str = "select distinct a.code as futuresName, b.d_newedge_code as newedgeName from futuresopenpost a inner join product_mapping b on a.code=b.d_code"
        Dim dsTemp As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        For Each eDr As DataRow In eDt.Rows

            If GFncNoNullString(eDr("code")).Trim <> pCode Or GFncNoNullString(eDr("monthCode")) <> fMonth Then
                nDr = nDt.Select("d_code = '" & pCode & "' and monthcode = '" & fMonth & "'", "")
                For i As Integer = 0 To nDr.Length - 1
                    If start < dt.Rows.Count Then
                        dt.Rows(start).Item("nClient") = "NEWEDGE"
                        dt.Rows(start).Item("nBuy") = GFncNoNullValue(nDr(i).Item("buy"))
                        dt.Rows(start).Item("nSell") = GFncNoNullValue(nDr(i).Item("sell"))
                        dt.Rows(start).Item("nPrice") = GFncNoNullValue(nDr(i).Item("price"))
                        dt.Rows(start).Item("nName") = GFncNoNullString(nDr(i).Item("product")).Trim
                    Else
                        dr = dt.NewRow
                        dr("pCode") = pCode
                        dr("nClient") = "NEWEDGE"
                        dr("eBuy") = 0
                        dr("eSell") = 0
                        dr("nBuy") = GFncNoNullValue(nDr(i).Item("buy"))
                        dr("nSell") = GFncNoNullValue(nDr(i).Item("sell"))
                        dr("nPrice") = GFncNoNullValue(nDr(i).Item("price"))
                        dr("tdate") = CDate(tdate)
                        dr("pName") = GFncNoNullString(nDr(i).Item("product_name")).Trim
                        dr("fMonth") = fMonth
                        dr("nName") = GFncNoNullString(nDr(i).Item("product")).Trim

                        dt.Rows.Add(dr)
                        dr = Nothing
                    End If
                    start += 1
                Next
                nDr = Nothing
                pCode = GFncNoNullString(eDr("code")).Trim
                fMonth = GFncNoNullString(eDr("monthcode")).Trim
                pCount = 0
                start = dt.Rows.Count
            End If
            If GFncNoNullString(eDr("code")).Trim = "" Then
                Exit For
            End If
            pCount += 1
            dr = dt.NewRow
            dr("pCode") = pCode
            dr("pName") = GFncNoNullString(eDr("product_name")).Trim
            dr("eClient") = GFncNoNullString(eDr("accno")).Trim
            dr("eBuy") = GFncNoNullValue(eDr("buy"))
            dr("eSell") = GFncNoNullValue(eDr("sell"))
            dr("ePrice") = GFncNoNullValue(eDr("price"))
            dr("fMonth") = GFncNoNullString(eDr("monthcode")).Trim
            dr("nSell") = 0
            dr("nBuy") = 0
            dr("tdate") = CDate(tdate)
            dr("fMonth") = fMonth

            dr("nName") = dsTemp.Select("futuresName='" + pCode + "'")(0)("newedgeName")

            dt.Rows.Add(dr)
            dr = Nothing
        Next
        For Each ndDr As DataRow In nDt.Rows
            pCode = GFncNoNullString(ndDr("d_code")).Trim
            fMonth = GFncNoNullString(ndDr("monthcode")).Trim
            nDr = dt.Select("pCode = '" & pCode & "' and fMonth = '" & fMonth & "'", "")
            If nDr.Length = 0 Then
                dr = dt.NewRow
                dr("pCode") = pCode
                dr("nClient") = "NEWEDGE"
                dr("eBuy") = 0
                dr("eSell") = 0
                dr("nBuy") = GFncNoNullValue(ndDr("buy"))
                dr("nSell") = GFncNoNullValue(ndDr("sell"))
                dr("nPrice") = GFncNoNullValue(ndDr("price"))
                dr("fMonth") = fMonth
                dr("pName") = GFncNoNullString(ndDr("product_name")).Trim
                dr("nName") = GFncNoNullString(ndDr("product")).Trim

                dt.Rows.Add(dr)
                dr = Nothing
            End If
        Next
        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", GStrloginID)
        Return rpt
    End Function

    Private Function getFuturesAutoMatch(ByVal tradeDate As Date) As DataTable
        Dim dtFutureOpenPosition As DataSet
        strSQL = "select "
        dtFutureOpenPosition = GFncRtnDS(GSCnSqlConn, strSQL)
        Return Nothing
    End Function
End Class
