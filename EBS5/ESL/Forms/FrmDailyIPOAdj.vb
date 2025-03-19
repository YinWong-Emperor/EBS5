Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FrmDailyIPOAdj

    Dim cls As New ClsDailyIPOAdj

    Private Sub FrmDailyIPOAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.nudYear.Value = Year(Now())
        Me.nudMonth.Value = Month(Now())
        ShowGrid()

    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

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
                                                        Me.txtToClient.Text, tableNames)
        Me.dtgIPO.DataSource = ds
        Me.dtgIPO.DataMember = "detail"
        Me.lblTotal.Text = ""

        If (ds.Tables("total").Rows.Count > 0) Then
            If (IsNumeric(ds.Tables("total").Rows(0)(0))) Then
                Me.lblTotal.Text = Format(ds.Tables("total").Rows(0)(0), "Standard")
            Else
                Me.lblTotal.Text = ""
            End If
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dtgIPO.CurrentRow Is Nothing Then
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncDeleteIPOAdj(Me.dtgIPO.Item(0, Me.dtgIPO.CurrentRow.Index).Value) = True) Then
                GSubShowInfo(GFncGetSysMsg(13))
                ShowGrid()
            Else
                GSubShowInfo(GFncGetSysMsg(14))
            End If
        End If

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim tableNames As String() = New String(1) {"detail", "total"}
        Dim strExFile = "DailyIPO_" & CStr(Me.nudYear.Value) & "_" + CStr(Me.nudMonth.Value) + Format(Now(), "_yyyyMMddhhmmss") & ".csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExptIPOAdj(Me.nudYear.Value, Me.nudMonth.Value, Me.txtFromClient.Text, _
                Me.txtToClient.Text, tableNames, strExFile) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If

    End Sub

    Private Sub btnSaveIPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveIPO.Click
        Dim ccCls As New ClsClientCodes
        Dim cfCls As New ClsCommAdjF
        Dim strCC As String = txtAddClient.Text.Trim()

        If (ccCls.FncIsClientCodeLengthValid(strCC) = False) Then
            GSubShowInfo(GFncGetSysMsg(16))
            txtAddClient.Focus()
            Return
        End If

        If (ccCls.FncIsClientCodeExist(strCC) = False And cfCls.FncIsClientCodeExist(strCC) = False) Then
            ccCls.ShowMsg_InvalidClientCode()
            txtAddClient.Focus()
            Return
        End If

        If (cls.lFncIsClientExist(Me.txtAddClient.Text, Me.dpIPOAdj.Value) = True) Then
            GSubShowInfo(GFncGetSysMsg(7))
            Me.txtAddClient.Focus()
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncAddIPOAdj(Me.txtAddClient.Text, Me.dpIPOAdj.Value, Me.txtIPO.Text)) Then
                Me.lblInfo.Text = GFncGetSysMsg(8) & vbNewLine & _
                                    "Client Code : " & Me.txtAddClient.Text & vbNewLine & _
                                    "Date : " & Format(Me.dpIPOAdj.Value, "dd/MM/yyyy") & vbNewLine & _
                                    "IPO : " & Me.txtIPO.Text
                Me.txtAddClient.Text = ""
                Me.dpIPOAdj.Value = Now()
                Me.txtIPO.Text = ""
                Me.txtAddClient.Focus()
            End If
        Else
            Me.txtAddClient.Focus()
        End If

    End Sub

    Private Sub btnIPOBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIPOBack.Click

        Me.tc.SelectedTab = Me.tp1

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub tc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tc.SelectedIndexChanged

        If (Me.tc.SelectedIndex = 0) Then
            ShowGrid()
        ElseIf (Me.tc.SelectedIndex = 1) Then
            Me.txtAddClient.Text = ""
            Me.dpIPOAdj.Value = Now()
            Me.txtIPO.Text = ""
            Me.lblInfo.Text = ""
        End If

    End Sub

    Private Sub dtgIPO_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dtgIPO.DataBindingComplete
        FormatGridView(dtgIPO.Columns)
    End Sub
End Class
