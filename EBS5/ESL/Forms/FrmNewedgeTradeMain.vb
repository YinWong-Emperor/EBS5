Imports System.Data.SqlClient

Public Class FrmNewedgeTradeMain

    Dim cls As New ClsNewedgeTradeMain
    Dim dgvDecimalPlacesCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim ldtTrade As DataTable

    Private Sub dpTradeDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpTradeDate.ValueChanged

        getTrade()
        If (Me.dtgTrade.Rows.Count = 0) Then
            Me.txtMonthCode.Text = ""
            Me.txtCommodity.Text = ""
            Me.txtBuy.Text = ""
            Me.txtSell.Text = ""
            Me.txtPrice.Text = ""
            Me.txtPeriod.Text = ""
            Me.txtComm.Text = ""
            Me.txtClearing.Text = ""
            Me.txtLevy.Text = ""
        End If

        dgvDecimalPlacesCellStyle.Format = modGlobal.DecimalFormat
        Me.dtgTrade.Columns.Item("price").DefaultCellStyle = dgvDecimalPlacesCellStyle

    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click

        Dim curPeriod As String = ""
        Dim curComm As Double = 0
        Dim curClearing As Double = 0
        Dim curLevy As Double = 0
        Dim qty As Integer = 0
        Dim msg As String = ""
        Dim MyTrans As SqlTransaction = Nothing

        If (Me.dtgTrade.Rows.Count > 0) Then
            If (Me.txtPeriod.Text = "Electronic") Then
                curPeriod = "Floor"
            Else
                curPeriod = "Electronic"
            End If
            cls.lFncGetComm(curPeriod, Me.txtCommodity.Text, curComm, curClearing, curLevy)
            qty = Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(2).Value _
                    + Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(3).Value
            curComm = curComm * qty
            curClearing = curClearing * qty
            curLevy = curLevy * qty

            msg = GFncGetSysMsg(10) & vbNewLine & "Period : " & Me.txtPeriod.Text & " => " & curPeriod & vbNewLine & _
                    "Comm. : " & Me.txtComm.Text & " => " & curComm & vbNewLine & _
                    "Clearing. : " & Me.txtClearing.Text & " => " & curClearing & vbNewLine & _
                    "Levy : " & Me.txtLevy.Text & " => " & curLevy
            If (GSubShowYNConfirm(msg) = Windows.Forms.DialogResult.Yes) Then
                Try
                    MyTrans = GSCnSqlConn.BeginTransaction
                    cls.lFncUpdateTrade(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(0).Value, curPeriod, _
                                        curComm, curClearing, curLevy, MyTrans)
                    cls.lFncWriteLog(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(0).Value, _
                                        Me.txtPeriod.Text, Me.txtComm.Text, Me.txtClearing.Text, Me.txtLevy.Text, _
                                        curPeriod, curComm, curClearing, curLevy, MyTrans)
                    Me.txtPeriod.Text = curPeriod
                    Me.txtComm.Text = curComm
                    Me.txtClearing.Text = curClearing
                    Me.txtLevy.Text = curLevy
                    Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(7).Value = Me.txtPeriod.Text
                    Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(8).Value = Me.txtComm.Text
                    Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(9).Value = Me.txtClearing.Text
                    Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(10).Value = Me.txtLevy.Text

                    MyTrans.Commit()
                    MyTrans = Nothing

                Catch ex As Exception
                    If GSCnLiqConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                    End If
                    GSubWriteErrLog(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub getTrade()

        Dim lds As DataSet = Nothing

        Try
            lds = cls.lFncGetTrades(Format(Me.dpTradeDate.Value, "yyyy/MM/dd"), Me.cbxCounterParty.Text)
            ldtTrade = lds.Tables(0).Copy
            Me.dtgTrade.DataSource = lds
            Me.dtgTrade.DataMember = "trade"
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
        End Try

    End Sub

    Private Sub dtgTrade_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgTrade.SelectionChanged

        If (IsNothing(Me.dtgTrade.CurrentRow) = False) Then
            'no trade date empty
            Me.txtMonthCode.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(4).Value)
            Me.txtCommodity.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(5).Value)
            Me.txtBuy.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(2).Value)
            Me.txtSell.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(3).Value)
            Me.txtPrice.Text = GFncNoNullValue(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(6).Value).ToString(modGlobal.DecimalFormat)
            Me.txtPeriod.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(7).Value)
            Me.txtComm.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(8).Value)
            Me.txtClearing.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(9).Value)
            Me.txtLevy.Text = GFncNoNullString(Me.dtgTrade.Rows(Me.dtgTrade.CurrentRow.Index).Cells(10).Value)
        End If

    End Sub

    Private Sub FrmNewedgeTradeMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty.ValueMember = "misc_desc"
    End Sub

    Private Sub cbxCounterParty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCounterParty.SelectedIndexChanged

        getTrade()
        If (Me.dtgTrade.Rows.Count = 0) Then
            Me.txtMonthCode.Text = ""
            Me.txtCommodity.Text = ""
            Me.txtBuy.Text = ""
            Me.txtSell.Text = ""
            Me.txtPrice.Text = ""
            Me.txtPeriod.Text = ""
            Me.txtComm.Text = ""
            Me.txtClearing.Text = ""
            Me.txtLevy.Text = ""
        End If
    End Sub
End Class
