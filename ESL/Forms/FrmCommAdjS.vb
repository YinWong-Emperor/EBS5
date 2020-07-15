Public Class FrmCommAdjS

    Dim cls As New ClsCommAdjS
    Dim ldsDetail As DataSet

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        ShowGrid()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim tableNames As String() = New String(1) {"detail", "total"}

        Dim ldsDetail As DataSet
        Dim mth As String
        Dim strExFile As String

        ldsDetail = cls.lFncSearch(Me.nudYear.Value, Me.nudMonth.Value, Me.txtFromClient.Text, _
                                                                Me.txtToClient.Text, Me.cbZero.Checked, tableNames)
        Me.dtgDetail.DataSource = ldsDetail
        Me.dtgDetail.DataMember = "detail"
        Me.dtgTotal.DataSource = ldsDetail
        Me.dtgTotal.DataMember = "total"

        If (ldsDetail.Tables(0).Rows.Count = 0) Then
            GSubShowInfo(GFncGetSysMsg(2))
        Else
            If (CStr(Me.nudMonth.Value).Length = 1) Then
                mth = "0" & CStr(Me.nudMonth.Value)
            Else
                mth = CStr(Me.nudMonth.Value)
            End If

            strExFile = "Commission_Stock_" & CStr(Me.nudYear.Value) & "_" & mth & Format(Now(), "_yyyyMMddhhmmss") & ".csv"

            If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
                If (cls.lFncExptCommAdj(ldsDetail, strExFile) = True) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            End If
        End If

    End Sub

    Private Sub btnAdjSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjSave.Click

        Dim adjYear As String
        Dim adjMonth As String

        If IsNumeric(Me.txtAdjAdj.Text) = False Or IsNumeric(Me.txtAdjIPO.Text) = False Then
            GSubShowInfo(GFncGetSysMsg(18))
            Return
        End If

        adjYear = Me.txtAdjDate.Text
        adjMonth = Mid(adjYear, 6, adjYear.Length - 5)
        adjYear = Mid(adjYear, 1, 4)

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncSaveAdj(Me.txtAdjClient.Text, adjYear, adjMonth, Me.txtAdjAdj.Value, Me.txtAdjIPO.Value)) Then
                Me.lblAdjInfo.Text = GFncGetSysMsg(8)
                Me.txtAdjTtl.Text = CDbl(Me.txtAdjComm.Text) + Me.txtAdjAdj.Value + Me.txtAdjIPO.Value
            End If

        Else
            Me.txtAdjAdj.Focus()
        End If

    End Sub

    Private Sub btnAdjBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjBack.Click

        ShowFirstPage()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim ccCls As New ClsClientCodes
        Dim strCC As String = txtAddClient.Text.Trim()

        If (ccCls.FncIsClientCodeLengthValid(strCC) = False) Then
            ccCls.ShowMsg_ClientCodeLengthLimition()
            txtAddClient.Focus()
            Return
        End If

        If (ccCls.FncIsClientCodeExist(strCC) = False) Then
            ccCls.ShowMsg_InvalidClientCode()
            txtAddClient.Focus()
            Return
        End If

        If (cls.lFncIsClientExist(Me.txtAddClient.Text, Me.nudAddYear.Value, Me.nudAddMonth.Value) = True) Then
            GSubShowWarn("Client Code already exists!")
            Me.txtAddClient.Focus()
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncAddClient(Me.txtAddClient.Text, Me.nudAddYear.Value, Me.nudAddMonth.Value)) Then
                Me.lblInfo.Text = GFncGetSysMsg(8) & vbNewLine & _
                                    "Client Code : " & Me.txtAddClient.Text & vbNewLine & _
                                    "Month : " & Me.nudAddYear.Value & " Year " & Me.nudAddMonth.Value & " Month "
                Me.txtAddClient.Text = ""
                Me.nudAddYear.Value = GDteTradeDate.AddMonths(-1).Year
                Me.nudAddMonth.Value = GDteTradeDate.AddMonths(-1).Month
                Me.txtAddClient.Focus()
            End If

        Else
            Me.txtAddClient.Focus()
        End If

    End Sub

    Private Sub btnAddBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBack.Click
        ShowFirstPage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmCommAdjS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.nudYear.Value = GDteTradeDate.AddMonths(-1).Year
        Me.nudMonth.Value = GDteTradeDate.AddMonths(-1).Month
        ShowGrid()

    End Sub

    Private Sub ShowGrid()
        Dim tableNames As String() = New String(1) {"detail", "total"}

        If (txtFromClient.Text <> "" And txtFromClient.Text.Trim.Length < 8) Then
            txtFromClient.Text = txtFromClient.Text.PadLeft(8, "0")
        End If

        If (txtToClient.Text <> "" And txtToClient.Text.Trim.Length < 8) Then
            txtToClient.Text = txtToClient.Text.PadLeft(8, "0")
        End If

        Dim ds As DataSet = cls.lFncSearch(Me.nudYear.Value, Me.nudMonth.Value, Me.txtFromClient.Text, _
                                                        Me.txtToClient.Text, Me.cbZero.Checked, tableNames)
        Me.dtgDetail.DataSource = ds
        Me.dtgDetail.DataMember = "detail"

        Me.dtgTotal.DataSource = ds
        Me.dtgTotal.DataMember = "total"

    End Sub

    Private Sub ShowFirstPage()

        Me.tc.SelectedTab = Me.tp1
        Me.txtAdjAdj.Text = ""
        Me.txtAdjClient.Text = ""
        Me.txtAdjComm.Text = ""
        Me.txtAdjDate.Text = ""
        Me.txtAdjIPO.Text = ""
        Me.txtAdjName.Text = ""
        Me.txtAdjTtl.Text = ""
        Me.lblAdjInfo.Text = ""
        Me.txtAddClient.Text = ""
        Me.lblInfo.Text = ""

    End Sub

    Private Sub tc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tc.SelectedIndexChanged

        If (Me.tc.SelectedIndex = 0) Then
            ShowGrid()
        ElseIf (Me.tc.SelectedIndex = 1) Then
            If (IsNothing(Me.dtgDetail.CurrentRow)) Then
                Me.tc.SelectedIndex = 0
                GSubShowWarn("No current record!")
                Return
            End If

            Me.txtAdjClient.Text = Me.dtgDetail.Item(0, Me.dtgDetail.CurrentRow.Index).Value
            Me.txtAdjName.Text = Me.dtgDetail.Item(1, Me.dtgDetail.CurrentRow.Index).Value
            Me.txtAdjDate.Text = Me.dtgDetail.Item(2, Me.dtgDetail.CurrentRow.Index).Value
            Me.txtAdjComm.Text = Me.dtgDetail.Item(3, Me.dtgDetail.CurrentRow.Index).Value
            Me.txtAdjAdj.Text = Me.dtgDetail.Item(4, Me.dtgDetail.CurrentRow.Index).Value
            Me.txtAdjIPO.Text = Me.dtgDetail.Item(5, Me.dtgDetail.CurrentRow.Index).Value
            Me.txtAdjTtl.Text = Me.dtgDetail.Item(6, Me.dtgDetail.CurrentRow.Index).Value
            Me.lblAdjInfo.Text = ""
        Else
            Me.txtAddClient.Text = ""

            Me.nudAddYear.Value = GDteTradeDate.AddMonths(-1).Year
            Me.nudAddMonth.Value = GDteTradeDate.AddMonths(-1).Month
            Me.lblInfo.Text = ""
        End If

    End Sub

    Private Sub dtgDetail_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dtgDetail.DataBindingComplete
        FormatGridView(dtgDetail.Columns)
    End Sub

    Private Sub dtgTotal_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dtgTotal.DataBindingComplete
        FormatGridView(dtgTotal.Columns)
    End Sub

    Private Sub txtAdjAdj_Leave(sender As Object, e As EventArgs) Handles txtAdjAdj.Leave
        GetTotal()
    End Sub

    Private Sub txtAdjIPO_Leave(sender As Object, e As EventArgs) Handles txtAdjIPO.Leave
        GetTotal()
    End Sub

    Private Sub GetTotal()
        If IsNumeric(Me.txtAdjAdj.Text) = False Or IsNumeric(Me.txtAdjIPO.Text) = False Then
            Me.btnAdjBack.Focus()
            Return
        End If

        Dim total As Decimal = Convert.ToDecimal(Me.txtAdjComm.Text) + Me.txtAdjAdj.Value + Me.txtAdjIPO.Value
        Me.txtAdjTtl.Text = Convert.ToString(total)
    End Sub
End Class
