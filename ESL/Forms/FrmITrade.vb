Public Class FrmITrade

    Dim cls As New ClsITrade
    Dim tradeDate As String

    Private Sub FrmITrade_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim lds As DataSet = Nothing
        Dim ldr As DataRow = Nothing
        Dim lastTrade As Date = Nothing
        Dim tmpDate As Date = Nothing

        lds = cls.lFncGetLastTradeDate()
        ldr = lds.Tables("lastTradeDate").Rows(0)
        lastTrade = ldr("lasttrade")
        tradeDate = Format(lastTrade, "dd-MM-yyyy")

        tmpDate = New Date(Year(lastTrade), Month(lastTrade), 1)
        tmpDate = DateAdd(DateInterval.Month, -2, tmpDate)
        Me.dpLastFrom.Value = tmpDate

        tmpDate = New Date(Year(lastTrade), Month(lastTrade), 1)
        tmpDate = DateAdd(DateInterval.Month, -1, tmpDate)
        Me.dpThisFrom.Value = tmpDate

        tmpDate = DateAdd(DateInterval.Day, -1, tmpDate)
        Me.dpLastTo.Value = tmpDate

        tmpDate = New Date(Year(lastTrade), Month(lastTrade), 1)
        tmpDate = DateAdd(DateInterval.Day, -1, tmpDate)
        Me.dpThisTo.Value = tmpDate

        Me.lblLastTradeDate.Text = "Stock last trade date" & vbNewLine & Format(lastTrade, "dd-MMM-yyyy")

        loadClient()
        lfuncEnable(False)
        Me.lbAccno.Focus()
    End Sub

    Private Sub btnExportTurnover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportTurnover.Click
        Dim strExFile As String = "itradeTurnover_" & Format(Me.dpThisFrom.Value, "yyyyMMdd") & "_" & _
                                    Format(Me.dpThisTo.Value, "yyyyMMdd") & ".csv"        

        Dim strExFile2 As String = "iTradeEquity_" & tradeDate & ".csv"

        If (Me.lbAccno.Items.Count = 0) Then
            GSubShowInfo(GFncGetSysMsg(2))
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportTurnover(Me.dpLastFrom.Value, Me.dpLastTo.Value, Me.dpThisFrom.Value, Me.dpThisTo.Value, _
                                        strExFile, strExFile2) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
                Me.lbAccno.Focus()
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lfuncEnable(True)
        Me.txtAccno.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncSaveClientList(Me.lbAccno) = True) Then
                GSubShowInfo(GFncGetSysMsg(8))
                Me.lbAccno.SelectedIndex = 0
                Me.lbAccno.Focus()
                lfuncEnable(False)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (Me.btnSave.Enabled) Then
            loadClient()
            lfuncEnable(False)
            Me.txtAccno.Text = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lfuncEnable(ByVal flag As Boolean)
        Me.txtAccno.Enabled = flag
        Me.btnAdd.Enabled = flag
        Me.btnUp.Enabled = flag
        Me.btnDown.Enabled = flag
        Me.dpLastFrom.Enabled = Not flag
        Me.dpLastTo.Enabled = Not flag
        Me.dpThisFrom.Enabled = Not flag
        Me.dpThisTo.Enabled = Not flag
        Me.btnExportClient.Enabled = Not flag
        Me.btnExportTurnover.Enabled = Not flag
        Me.btnEdit.Enabled = Not flag
        Me.btnSave.Enabled = flag
    End Sub

    Private Sub loadClient()
        Dim lds As DataSet = Nothing
        Dim ldr As DataRow = Nothing

        lds = cls.lFncGetITradeList()
        Me.lbAccno.Items.Clear()
        For Each ldr In lds.Tables("clientList").Rows
            Me.lbAccno.Items.Add(ldr("client_code"))
        Next
        Me.lbAccno.SelectedIndex = 0
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If Me.lbAccno.SelectedIndex < 1 Then
            Exit Sub
        End If

        Dim i As Int16 = Me.lbAccno.SelectedIndex
        Dim s As String = Me.lbAccno.Items(i)
        Me.lbAccno.Items.RemoveAt(i)
        Me.lbAccno.Items.Insert(i - 1, s)
        Me.lbAccno.SelectedIndex = i - 1
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If Me.lbAccno.SelectedIndex > Me.lbAccno.Items.Count - 2 Or Me.lbAccno.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim i As Int16 = Me.lbAccno.SelectedIndex
        Dim s As String = Me.lbAccno.Items(i)
        Me.lbAccno.Items.RemoveAt(i)
        Me.lbAccno.Items.Insert(i + 1, s)
        Me.lbAccno.SelectedIndex = i + 1
    End Sub

    Private Sub lbAccno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbAccno.KeyDown
        If (Me.btnSave.Enabled) Then
            If (Asc(e.KeyCode) = 52) Then
                Me.lbAccno.Items.RemoveAt(Me.lbAccno.SelectedIndex)
                Me.lbAccno.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim accno As String
        Dim i As Integer

        If (Me.txtAccno.Text.Trim.Length <> 8) Then
            GSubShowInfo(GFncGetSysMsg(90))
            Me.txtAccno.Focus()
            Return
        End If

        accno = Me.txtAccno.Text.Substring(0, 1)
        If ((accno <> "0") And (accno <> "8")) Then
            GSubShowInfo(GFncGetSysMsg(91))
            Me.txtAccno.Focus()
            Return
        End If

        accno = Me.txtAccno.Text

        For i = 0 To Me.lbAccno.Items.Count - 1
            If (accno = Trim(Me.lbAccno.Items(i))) Then
                Me.lbAccno.ClearSelected()
                Me.lbAccno.SelectedIndex = i
                Me.lbAccno.Focus()
                Return
            End If
        Next i

        Me.lbAccno.Items.Add(accno)
        Me.lbAccno.SelectedIndex = Me.lbAccno.Items.Count - 1
        Me.lbAccno.Focus()
        Me.txtAccno.Text = ""
        Me.txtAccno.Focus()
        lfuncEnable(True)
    End Sub

    Private Sub btnExportClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportClient.Click        
        Dim strExFile As String = "iTradeClient_" & tradeDate & ".csv"

        If (Me.lbAccno.Items.Count = 0) Then
            GSubShowInfo(GFncGetSysMsg(2))
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportClient(strExFile) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
                Me.lbAccno.Focus()
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub

    Private Sub btnExportAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportAll.Click
        Dim strExFile As String = "itradeTurnoverAll_" & Format(Me.dpThisFrom.Value, "yyyyMMdd") & "_" & _
                                    Format(Me.dpThisTo.Value, "yyyyMMdd") & ".csv"        
        Dim strExFile2 As String = "iTradeEquityAll_" & tradeDate & ".csv"

        If (Me.lbAccno.Items.Count = 0) Then
            GSubShowInfo(GFncGetSysMsg(2))
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportTurnoverAll(Me.dpLastFrom.Value, Me.dpLastTo.Value, Me.dpThisFrom.Value, Me.dpThisTo.Value, _
                                        strExFile, strExFile2) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
                Me.lbAccno.Focus()
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub

    Private Sub btnEquity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquity.Click
        Dim strExFile As String = "itradeTurnover_" & Format(Me.dpThisFrom.Value, "yyyyMMdd") & "_" & _
                                   Format(Me.dpThisTo.Value, "yyyyMMdd") & ".csv"

        Dim strExFile2 As String = "iTradeEquity_" & tradeDate & ".csv"

        If (Me.lbAccno.Items.Count = 0) Then
            GSubShowInfo(GFncGetSysMsg(2))
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportEquilty(Me.dpLastFrom.Value, Me.dpLastTo.Value, Me.dpThisFrom.Value, Me.dpThisTo.Value, _
                                        strExFile, strExFile2) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
                Me.lbAccno.Focus()
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub

    Private Sub btnEquityAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquityAll.Click
        Dim strExFile As String = "itradeTurnoverAll_" & Format(Me.dpThisFrom.Value, "yyyyMMdd") & "_" & _
                                       Format(Me.dpThisTo.Value, "yyyyMMdd") & ".csv"

        Dim strExFile2 As String = "iTradeEquityAll_" & tradeDate & ".csv"

        If (Me.lbAccno.Items.Count = 0) Then
            GSubShowInfo(GFncGetSysMsg(2))
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportEquityAll(Me.dpLastFrom.Value, Me.dpLastTo.Value, Me.dpThisFrom.Value, Me.dpThisTo.Value, _
                                        strExFile, strExFile2) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
                Me.lbAccno.Focus()
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub
End Class
