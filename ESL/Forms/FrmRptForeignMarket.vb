Public Class FrmRptForeignMarket
    Private gCls As New clsRptForeignMarket
    Private gClsExportForeignMarket As New clsExportForeignMarket

    Private htMarketComm As New Hashtable

    Private Sub FrmRptForeignMarket_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtMarkets As DataTable
        Dim dtThirdParty As DataTable

        Dim sMarket As String
        Dim sPlatform As String

        htMarketComm.Add("MAMK", 267)
        htMarketComm.Add("SG", 37)
        htMarketComm.Add("SSE", 240)
        htMarketComm.Add("SZEN", 240)
        htMarketComm.Add("US", 37)

        lsubShowProcessing(False)

        dtMarkets = gCls.GetMarkets()
        dtThirdParty = gCls.GetThirdParty()

        If dtMarkets.Rows.Count > 0 Then
            For Each row As DataRow In dtMarkets.Rows
                If Not row.IsNull(dtMarkets.Columns("name_s")) Then
                    sMarket = row("name_s").ToString.Trim()
                    If sMarket = "MAMK" Or sMarket = "SG" Or sMarket = "SSE" Or sMarket = "SZEN" Or sMarket = "US" Then
                        cboMarkets.Items.Add(sMarket)
                    End If
                End If

            Next
        End If

        If dtThirdParty.Rows.Count > 0 Then
            For Each row As DataRow In dtThirdParty.Rows
                If Not row.IsNull(dtThirdParty.Columns("platform")) Then
                    sPlatform = row("platform").ToString.Trim()
                    If sPlatform = "IB" Then
                        cboMarkets.Items.Add(sPlatform)
                    End If
                End If

            Next
        End If

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim lstrSQL As String = String.Empty
        Dim sMarket As String = String.Empty

        Dim sComm As String = String.Empty
        Dim deMarketComm As DictionaryEntry
        Dim strExFile As String = String.Empty
        sMarket = Me.cboMarkets.Text.Trim

        For Each deMarketComm In htMarketComm
            If deMarketComm.Key = sMarket Then
                sComm = deMarketComm.Value
            End If
        Next
        lsubShowProcessing(True)
        Application.DoEvents()
        strExFile = "foreign_market_" & sMarket & ".csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then

            If sMarket = "MAMK" Or sMarket = "SSE" Or sMarket = "SZEN" Then
                If sMarket = "MAMK" Or sMarket = "SZEN" Then
                    If (gClsExportForeignMarket.lFncForeignMarketByMarket(lstrSQL, sMarket, sComm, strExFile)) Then
                        GSubShowInfo(GFncGetSysMsg(28))
                    Else
                        GSubShowInfo(GFncGetSysMsg(29))
                    End If
                ElseIf sMarket = "SSE" Then
                    If (gClsExportForeignMarket.lFncForeignMarketByMarketSSE(lstrSQL, sMarket, sComm, strExFile)) Then
                        GSubShowInfo(GFncGetSysMsg(28))
                    Else
                        GSubShowInfo(GFncGetSysMsg(29))
                    End If

                End If


            ElseIf sMarket = "SG" Then

                If (gClsExportForeignMarket.lFncForeignMarketByMarketSG(lstrSQL, sMarket, sComm, strExFile)) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            ElseIf sMarket = "US" Then

                If (gClsExportForeignMarket.lFncForeignMarketByMarketUS(lstrSQL, sMarket, sComm, strExFile)) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            ElseIf sMarket = "IB" Then
                If (gClsExportForeignMarket.lFncForeignMarketByMarketIB(lstrSQL, sMarket, sComm, strExFile)) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            End If
        End If



            lsubShowProcessing(False)
            Application.DoEvents()
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
