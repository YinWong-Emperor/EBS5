Public Class frmNewedgeAutoMatch

    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim cls As New clsNewedgeReport

    Private Sub frmNewedgeAutoMatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty.ValueMember = "misc_desc"
        Me.dtpTrade.Text = Format(GDteTradeDate, "yyyy/MM/dd")
        lsubShowProcessing(False)
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        lsubShowProcessing(True)
        If Me.rbtPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        Application.DoEvents()
        rpt = FncGenAutoMatchReport(Me.dtpTrade.Value, Me.cbxCounterParty.Text)
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Public Function FncGenAutoMatchReport(ByVal tdate As DateTime, ByVal pCounterParty As String) As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim rptAutoMatch As New rptNewedgeAutoMatch
        rptAutoMatch.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK
        Dim dtG2bf As DataTable = New DtsNewedgeAutoMatch.G2BFDataTable
        Dim dtNewedge As DataTable = New DtsNewedgeAutoMatch.NewedgeDataTable
        Dim dtMain As DataTable = New DtsNewedgeAutoMatch.mainDataTable
        getDtAutoMatch(tdate, dtMain, dtG2bf, dtNewedge, pCounterParty)
        rptAutoMatch.Database.Tables("main").SetDataSource(dtMain)
        rptAutoMatch.Subreports("rptAutoMatchG2BF.rpt").SetDataSource(dtG2bf)
        rptAutoMatch.Subreports("rptAutoMatchNewedge.rpt").SetDataSource(dtNewedge)
        rptAutoMatch.SetParameterValue("user", GStrloginID)
        rptAutoMatch.SetParameterValue("tdate", tdate)
        rptAutoMatch.SetParameterValue("CounterParty", pCounterParty)
        Return rptAutoMatch
    End Function

    Private Sub getDtAutoMatch(ByVal tradeDate As DateTime, ByRef dtMain As DataTable, ByRef dtG2BF As DataTable, ByRef dtNewedge As DataTable, ByVal pCounterParty As String)
        Dim dtReturn As DataTable = New DataTable
        Dim dtG2BF_OpenPosition As DataTable
        Dim dtNewedge_OpenPosition As DataTable
        Dim strSQL As String = ""
        Dim newedgeRowArray() As DataRow
        Dim g2bfRowArray() As DataRow
        Dim newedgeRow As DataRow
        Dim g2bfRow As DataRow
        Dim newedgeNewRow As DataRow
        Dim g2bfNewRow As DataRow
        Dim groupName As String = ""
        Dim tempRow As DataRow
        Dim tempRowArray() As DataRow
        Dim dtMatchedProd As DataTable = New DataTable

        Dim dtTempGroup As DataTable = New DataTable
        dtTempGroup.Columns.Add("group_name", System.Type.GetType("System.String"))
        dtTempGroup.Columns.Add("group_mcode", System.Type.GetType("System.DateTime"))
        dtTempGroup.Columns.Add("monthly_daily", System.Type.GetType("System.String"))
        dtTempGroup.Columns.Add("product_name", System.Type.GetType("System.String"))
        dtTempGroup.Columns.Add("nbuy", System.Type.GetType("System.Decimal"))
        dtTempGroup.Columns.Add("nsell", System.Type.GetType("System.Decimal"))
        dtTempGroup.Columns.Add("fbuy", System.Type.GetType("System.Decimal"))
        dtTempGroup.Columns.Add("fsell", System.Type.GetType("System.Decimal"))
        dtTempGroup.Columns.Add("checked", System.Type.GetType("System.String"))

        'get matched product name
        strSQL = "select b.product_name as product_name from product_mapping a left join futures_product_master b on a.d_code=b.product_code"
        dtMatchedProd = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        'get open position
        strSQL = "select " _
                    & " a.code, isnull(b.product_name, a.code) as product_name, a.sysdate, a.tdate, isnull(a.qty, 0) as qty, " _
                    & " a.type, a.monthcode, a.accno, isnull(a.price, 0) as price, a.settle_date, 'N' as checked " _
                    & " from futuresop a left outer join futures_product_master b " _
                    & " on a.code=b.product_code where upper(a.counterparty)='" & pCounterParty & "' " _
                    & " and a.sysdate='" & Format(tradeDate, "yyyy/MM/dd") & "'"

        dtG2BF_OpenPosition = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        'strSQL = "select " _
        '            & " a.noid, a.tdate, a.odate, isnull(a.buy, 0) as buy, isnull(a.sell, 0) as sell, a.monthcode, " _
        '            & " a.product, isnull(c.product_name, a.product) as product_name, isnull(a.price, 0) as price, " _
        '            & " a.settle_date, a.monthly_daily, 'N' as checked " _
        '            & " from newedge_cap_op a left outer join product_mapping b " _
        '            & " on a.product=b.d_newedge_code and a.counterparty=b.d_counterparty left outer join futures_product_master c " _
        '            & " on b.d_code=c.product_code where a.tdate='" & Format(tradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "'"
        strSQL = "select " _
                           & " a.noid, a.tdate, a.odate, isnull(a.buy, 0) as buy, isnull(a.sell, 0) as sell, a.monthcode, " _
                           & " a.product, isnull(c.product_name, a.product) as product_name, isnull(a.price, 0) as price, " _
                           & " a.settle_date, a.monthly_daily, 'N' as checked " _
                           & " from vw_cap_op a left outer join product_mapping b " _
                           & " on a.product=b.d_newedge_code and a.counterparty=b.d_counterparty left outer join futures_product_master c " _
                           & " on b.d_code=c.product_code where a.tdate='" & Format(tradeDate, "yyyy/MM/dd") & "' and a.counterparty = '" & pCounterParty & "'"
        dtNewedge_OpenPosition = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        'get daily products
        newedgeRowArray = dtNewedge_OpenPosition.Select("monthly_daily='D' and checked='N'")
        For Each newedgeRow In newedgeRowArray

            'handle matched and unmatched product name
            Dim prod_name As String = newedgeRow.Item("product_name").ToString.Trim
            If IsDBNull(prod_name) Then
                prod_name = newedgeRow.Item("product").ToString.Trim
            End If

            groupName = prod_name & " [" & Format(newedgeRow.Item("settle_date"), "dd MMM yy") & "]"

            newedgeNewRow = dtNewedge.NewRow()
            newedgeNewRow.Item("prod_code") = newedgeRow.Item("product").ToString.Trim
            newedgeNewRow.Item("prod_name") = newedgeRow.Item("product_name").ToString.Trim
            newedgeNewRow.Item("tid") = newedgeRow.Item("noid").ToString.Trim
            newedgeNewRow.Item("tdate") = newedgeRow.Item("tdate")
            newedgeNewRow.Item("odate") = newedgeRow.Item("odate")
            newedgeNewRow.Item("buy") = newedgeRow.Item("buy")
            newedgeNewRow.Item("sell") = newedgeRow.Item("sell")
            newedgeNewRow.Item("monthcode") = newedgeRow.Item("monthcode").ToString.Trim
            newedgeNewRow.Item("price") = newedgeRow.Item("price")
            newedgeNewRow.Item("settle_date") = newedgeRow.Item("settle_date")
            newedgeNewRow.Item("monthly_daily") = newedgeRow.Item("monthly_daily").ToString.Trim
            newedgeNewRow.Item("group_name") = groupName
            dtNewedge.Rows.Add(newedgeNewRow)

            newedgeRow.Item("checked") = "Y"

            tempRow = dtTempGroup.NewRow
            tempRow.Item("group_name") = groupName
            tempRow.Item("group_mcode") = newedgeRow.Item("settle_date")
            tempRow.Item("monthly_daily") = "D"
            tempRow.Item("product_name") = newedgeRow.Item("product_name").ToString.Trim
            tempRow.Item("nbuy") = newedgeRow.Item("buy")
            tempRow.Item("nsell") = newedgeRow.Item("sell")
            tempRow.Item("fbuy") = 0
            tempRow.Item("fsell") = 0
            tempRow.Item("checked") = "N"
            dtTempGroup.Rows.Add(tempRow)

            'get matched g2bf products
            g2bfRowArray = dtG2BF_OpenPosition.Select("product_name='" & newedgeRow.Item("product_name") & "' and settle_date='" & Format(newedgeRow.Item("settle_date"), "yyyy/MM/dd") & "' and checked='N'")

            For Each g2bfRow In g2bfRowArray

                g2bfNewRow = dtG2BF.NewRow()
                g2bfNewRow.Item("prod_code") = g2bfRow.Item("code").ToString.Trim
                g2bfNewRow.Item("prod_name") = g2bfRow.Item("product_name").ToString.Trim
                g2bfNewRow.Item("sysdate") = g2bfRow.Item("sysdate")
                g2bfNewRow.Item("tdate") = g2bfRow.Item("tdate")

                If g2bfRow.Item("type").ToString.Trim = "1" Then
                    g2bfNewRow.Item("buy") = g2bfRow.Item("qty")
                    g2bfNewRow.Item("sell") = 0

                ElseIf g2bfRow.Item("type") = "2" Then
                    g2bfNewRow.Item("buy") = 0
                    g2bfNewRow.Item("sell") = g2bfRow.Item("qty")
                End If

                g2bfNewRow.Item("monthcode") = g2bfRow.Item("monthcode").ToString.Trim
                g2bfNewRow.Item("accno") = g2bfRow.Item("accno").ToString.Trim
                g2bfNewRow.Item("price") = g2bfRow.Item("price")
                g2bfNewRow.Item("settle_date") = g2bfRow.Item("settle_date")
                g2bfNewRow.Item("group_name") = groupName
                dtG2BF.Rows.Add(g2bfNewRow)

                g2bfRow.Item("checked") = "Y"

                tempRow = dtTempGroup.NewRow
                tempRow.Item("group_name") = groupName
                tempRow.Item("group_mcode") = newedgeRow.Item("settle_date")
                tempRow.Item("monthly_daily") = "D"
                tempRow.Item("product_name") = g2bfRow.Item("product_name").ToString.Trim
                tempRow.Item("fbuy") = g2bfNewRow.Item("buy")
                tempRow.Item("fsell") = g2bfNewRow.Item("sell")
                tempRow.Item("nbuy") = 0
                tempRow.Item("nsell") = 0
                tempRow.Item("checked") = "N"
                dtTempGroup.Rows.Add(tempRow)
            Next
        Next

        'get monthly products
        newedgeRowArray = dtNewedge_OpenPosition.Select("monthly_daily='M' and checked='N'")
        For Each newedgeRow In newedgeRowArray

            'handle matched and unmatched product name
            Dim prod_name As String = newedgeRow.Item("product_name").ToString.Trim
            If IsDBNull(prod_name) Then
                prod_name = newedgeRow.Item("product").ToString.Trim
            End If

            Dim tempStr As String = newedgeRow.Item("monthcode").ToString.Trim
            Dim tempDate As DateTime = New Date("20" & tempStr.Substring(0, 2), tempStr.Substring(2, 2), 1)
            groupName = prod_name & " [" & Format(tempDate, "MMM yy") & "]"

            newedgeNewRow = dtNewedge.NewRow()
            newedgeNewRow.Item("prod_code") = newedgeRow.Item("product").ToString.Trim
            newedgeNewRow.Item("prod_name") = newedgeRow.Item("product_name").ToString.Trim
            newedgeNewRow.Item("tid") = newedgeRow.Item("noid").ToString.Trim
            newedgeNewRow.Item("tdate") = newedgeRow.Item("tdate")
            newedgeNewRow.Item("odate") = newedgeRow.Item("odate")
            newedgeNewRow.Item("buy") = newedgeRow.Item("buy")
            newedgeNewRow.Item("sell") = newedgeRow.Item("sell")
            newedgeNewRow.Item("monthcode") = newedgeRow.Item("monthcode").ToString.Trim
            newedgeNewRow.Item("price") = newedgeRow.Item("price")
            newedgeNewRow.Item("settle_date") = newedgeRow.Item("settle_date")
            newedgeNewRow.Item("monthly_daily") = newedgeRow.Item("monthly_daily").ToString.Trim
            newedgeNewRow.Item("group_name") = groupName
            dtNewedge.Rows.Add(newedgeNewRow)

            newedgeRow.Item("checked") = "Y"

            tempRow = dtTempGroup.NewRow
            tempRow.Item("group_name") = groupName
            tempRow.Item("group_mcode") = tempDate
            tempRow.Item("monthly_daily") = "M"
            tempRow.Item("product_name") = newedgeRow.Item("product_name").ToString.Trim
            tempRow.Item("nbuy") = newedgeRow.Item("buy")
            tempRow.Item("nsell") = newedgeRow.Item("sell")
            tempRow.Item("fbuy") = 0
            tempRow.Item("fsell") = 0
            tempRow.Item("checked") = "N"
            dtTempGroup.Rows.Add(tempRow)

            'get matched g2bf products
            g2bfRowArray = dtG2BF_OpenPosition.Select("product_name='" & newedgeRow.Item("product_name").ToString.Trim & "' and monthcode='" & newedgeRow.Item("monthcode").ToString.Trim & "' and checked='N'")

            For Each g2bfRow In g2bfRowArray

                g2bfNewRow = dtG2BF.NewRow()
                g2bfNewRow.Item("prod_code") = g2bfRow.Item("code").ToString.Trim
                g2bfNewRow.Item("prod_name") = g2bfRow.Item("product_name").ToString.Trim
                g2bfNewRow.Item("sysdate") = g2bfRow.Item("sysdate")
                g2bfNewRow.Item("tdate") = g2bfRow.Item("tdate")

                If g2bfRow.Item("type").ToString.Trim = "1" Then
                    g2bfNewRow.Item("buy") = g2bfRow.Item("qty")
                    g2bfNewRow.Item("sell") = 0

                ElseIf g2bfRow.Item("type") = "2" Then
                    g2bfNewRow.Item("buy") = 0
                    g2bfNewRow.Item("sell") = g2bfRow.Item("qty")

                End If

                g2bfNewRow.Item("monthcode") = g2bfRow.Item("monthcode").ToString.Trim
                g2bfNewRow.Item("accno") = g2bfRow.Item("accno").ToString.Trim
                g2bfNewRow.Item("price") = g2bfRow.Item("price")
                g2bfNewRow.Item("settle_date") = g2bfRow.Item("settle_date")
                g2bfNewRow.Item("group_name") = groupName
                dtG2BF.Rows.Add(g2bfNewRow)

                g2bfRow.Item("checked") = "Y"

                tempRow = dtTempGroup.NewRow
                tempRow.Item("group_name") = groupName
                tempRow.Item("group_mcode") = tempDate
                tempRow.Item("monthly_daily") = "M"
                tempRow.Item("product_name") = g2bfRow.Item("product_name").ToString.Trim
                tempRow.Item("fbuy") = g2bfNewRow.Item("buy")
                tempRow.Item("fsell") = g2bfNewRow.Item("sell")
                tempRow.Item("nbuy") = 0
                tempRow.Item("nsell") = 0
                tempRow.Item("checked") = "N"
                dtTempGroup.Rows.Add(tempRow)
            Next
        Next

        'get unmatched newedge product
        newedgeRowArray = dtNewedge_OpenPosition.Select("checked='N'")
        For Each newedgeRow In newedgeRowArray

            Dim prod_name As String = newedgeRow.Item("product_name").ToString.Trim
            If IsDBNull(prod_name) Then
                prod_name = newedgeRow.Item("product").ToString.Trim
            End If

            Dim tempDate As DateTime = Nothing
            If newedgeRow.Item("monthly_daily") = "M" Then
                Dim tempStr As String = newedgeRow.Item("monthcode").ToString.Trim
                tempDate = New Date("20" & tempStr.Substring(0, 2), tempStr.Substring(2, 2), 1)
                groupName = prod_name & " [" & Format(tempDate, "MMM yy") & "]"

            ElseIf newedgeRow.Item("monthly_daily") = "D" Then
                groupName = prod_name & " [" & Format(newedgeRow.Item("settle_date"), "dd MMM yy") & "]"
            End If

            newedgeNewRow = dtNewedge.NewRow()
            newedgeNewRow.Item("prod_code") = newedgeRow.Item("product").ToString.Trim
            newedgeNewRow.Item("prod_name") = newedgeRow.Item("product_name").ToString.Trim
            newedgeNewRow.Item("tid") = newedgeRow.Item("noid").ToString.Trim
            newedgeNewRow.Item("tdate") = newedgeRow.Item("tdate")
            newedgeNewRow.Item("odate") = newedgeRow.Item("odate")
            newedgeNewRow.Item("buy") = newedgeRow.Item("buy")
            newedgeNewRow.Item("sell") = newedgeRow.Item("sell")
            newedgeNewRow.Item("monthcode") = newedgeRow.Item("monthcode").ToString.Trim
            newedgeNewRow.Item("price") = newedgeRow.Item("price")
            newedgeNewRow.Item("settle_date") = newedgeRow.Item("settle_date")
            newedgeNewRow.Item("monthly_daily") = newedgeRow.Item("monthly_daily").ToString.Trim
            newedgeNewRow.Item("group_name") = groupName
            dtNewedge.Rows.Add(newedgeNewRow)

            newedgeRow.Item("checked") = "Y"

            tempRow = dtTempGroup.NewRow
            tempRow.Item("group_name") = groupName
            tempRow.Item("group_mcode") = IIf(newedgeRow.Item("monthly_daily") = "M", tempDate, newedgeRow.Item("settle_date"))
            tempRow.Item("monthly_daily") = IIf(newedgeRow.Item("monthly_daily") = "M", "M", "D")
            tempRow.Item("product_name") = newedgeRow.Item("product_name").ToString.Trim
            tempRow.Item("nbuy") = newedgeRow.Item("buy").ToString.Trim
            tempRow.Item("nsell") = newedgeRow.Item("sell").ToString.Trim
            tempRow.Item("fbuy") = 0
            tempRow.Item("fsell") = 0
            tempRow.Item("checked") = "N"
            dtTempGroup.Rows.Add(tempRow)
        Next

        'get unmatched g2bf product
        g2bfRowArray = dtG2BF_OpenPosition.Select("checked='N'")
        For Each g2bfRow In g2bfRowArray

            Dim prod_name As String = g2bfRow.Item("product_name").ToString.Trim
            If IsDBNull(prod_name) Then
                prod_name = g2bfRow.Item("code").ToString.Trim
            End If
            groupName = prod_name & " [" & Format(g2bfRow.Item("settle_date"), "dd MMM yy") & "]"

            g2bfNewRow = dtG2BF.NewRow()
            g2bfNewRow.Item("prod_code") = g2bfRow.Item("code").ToString.Trim
            g2bfNewRow.Item("prod_name") = g2bfRow.Item("product_name").ToString.Trim
            g2bfNewRow.Item("sysdate") = g2bfRow.Item("sysdate")
            g2bfNewRow.Item("tdate") = g2bfRow.Item("tdate")

            If g2bfRow.Item("type").ToString.Trim = "1" Then
                g2bfNewRow.Item("buy") = g2bfRow.Item("qty")
                g2bfNewRow.Item("sell") = 0

            ElseIf g2bfRow.Item("type").ToString.Trim = "2" Then
                g2bfNewRow.Item("buy") = 0
                g2bfNewRow.Item("sell") = g2bfRow.Item("qty")
            End If

            g2bfNewRow.Item("monthcode") = g2bfRow.Item("monthcode").ToString.Trim
            g2bfNewRow.Item("accno") = g2bfRow.Item("accno").ToString.Trim
            g2bfNewRow.Item("price") = g2bfRow.Item("price")
            g2bfNewRow.Item("settle_date") = g2bfRow.Item("settle_date")
            g2bfNewRow.Item("group_name") = groupName
            dtG2BF.Rows.Add(g2bfNewRow)

            g2bfRow.Item("checked") = "Y"

            tempRow = dtTempGroup.NewRow
            tempRow.Item("group_name") = groupName
            tempRow.Item("group_mcode") = g2bfRow.Item("settle_date")
            tempRow.Item("monthly_daily") = "D"
            tempRow.Item("product_name") = g2bfRow.Item("code").ToString.Trim
            tempRow.Item("fbuy") = g2bfNewRow.Item("buy")
            tempRow.Item("fsell") = g2bfNewRow.Item("sell")
            tempRow.Item("nbuy") = 0
            tempRow.Item("nsell") = 0
            tempRow.Item("checked") = "N"
            dtTempGroup.Rows.Add(tempRow)
        Next

        For Each row As DataRow In dtTempGroup.Rows
            Dim nbuy As Decimal = 0
            Dim nsell As Decimal = 0
            Dim fbuy As Decimal = 0
            Dim fsell As Decimal = 0

            tempRowArray = dtMain.Select("product_name='" & row.Item("product_name").ToString.Trim & "'")
            If tempRowArray.Length = 0 Then
                Dim nr As DataRow = dtMain.NewRow

                nr.Item("group_name") = row.Item("group_name")
                nr.Item("group_mcode") = row.Item("group_mcode")
                nr.Item("monthly_daily") = row.Item("monthly_daily")
                nr.Item("product_name") = row.Item("product_name")
                tempRowArray = dtTempGroup.Select("checked='N' and group_name='" & row.Item("group_name").ToString.Trim & "'")

                For Each dr As DataRow In tempRowArray
                    dr.Item("checked") = "Y"
                    nbuy += dr.Item("nbuy")
                    nsell += dr.Item("nsell")
                    fbuy += dr.Item("fbuy")
                    fsell += dr.Item("fsell")
                Next

                nr.Item("nbuy") = nbuy
                nr.Item("nsell") = nsell
                nr.Item("fbuy") = fbuy
                nr.Item("fsell") = fsell
                dtMain.Rows.Add(nr)
            End If
        Next

        For Each matchedProd As DataRow In dtMatchedProd.Rows
            tempRowArray = dtMain.Select("product_name='" & matchedProd.Item("product_name").ToString.Trim & "'")
            For Each row As DataRow In tempRowArray
                row.Item("matched") = "Y"
            Next
        Next
    End Sub
End Class
