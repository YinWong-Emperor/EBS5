Public Class FrmMonthToDate

    Dim cls As New ClsMonthToDate

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        
        Me.Cursor = Cursors.WaitCursor
        Me.btnSave.Enabled = False

        If (Me.cbClientTurnoverS.Checked = True) Then
            cls.lExptTurnoverS(Me.dpFrom.Value, Me.dpTo.Value)
        End If

        If (Me.cbClientTurnoverF.Checked = True) Then
            cls.lExptTurnoverF(Me.dpFrom.Value, Me.dpTo.Value)
        End If

        If (Me.cbNewClientS.Checked = True) Then
            cls.lExptNewClientS(Me.dpFrom.Value, Me.dpTo.Value)
        End If

        If (Me.cbNewClientF.Checked = True) Then
            cls.lExptNewClientF(Me.dpFrom.Value, Me.dpTo.Value)
        End If

        If (Me.cbMarginInOutS.Checked = True) Then
            cls.lExptMarginS(Me.dpFrom.Value, Me.dpTo.Value)
        End If

        If (Me.cbEIEHK.Checked = True) Then
            cls.lExptEIEHK(Me.dpFrom.Value, Me.dpTo.Value)
        End If

        Me.btnSave.Enabled = True
        Me.Cursor = Cursors.Default
        GSubShowInfo(GFncGetSysMsg(28))

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub FrmMonthToDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'datepicker:
        Me.dpFrom.Value = New DateTime(Year(GDteTradeDate), Month(GDteTradeDate) - 1, 1)
        Me.dpTo.Value = DateAdd(DateInterval.Day, -1, New DateTime(Year(GDteTradeDate), Month(GDteTradeDate), 1))

        'last trade date informations:
        lblLstTxnStock.Text = cls.funcGetLastTradeDateOfStock().ToString("dd/MM/yyyy")
        lblLstTxnFutures.Text = cls.funcGetLastTradeDateOfFutures().ToString("dd/MM/yyyy")

    End Sub

End Class
