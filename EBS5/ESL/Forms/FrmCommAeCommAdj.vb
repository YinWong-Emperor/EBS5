Public Class FrmCommAeCommAdj

    Dim cls As New ClsCommAeCommAdj
    Dim LoadFlag As Boolean
    Dim ActionFlag As String
    Dim AEtbl As DataTable
    Dim id As Double

    Private Sub FrmCommAeCommAdj_shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        LoadFlag = True
        id = 0
        LoadTxmonth()
        ObjEnable(False)
        Me.rbSrchSec.Checked = True
        GetAE()
        LoadFlag = False
        Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub LoadTxmonth()
        Dim txmonth As String = GfncGetMonth()
        Dim month As String = Val(txmonth.Substring(4, 2))
        Dim year As String = Val(txmonth.Substring(0, 4))
        ' cls.GetLatestDate(year, month)
        For yr As Integer = CInt(year) - 3 To CInt(year) + 3
            Me.comboSrchYr.Items.Add(yr)
        Next
        For mon As Integer = 1 To 12
            Me.comboSrchMonth.Items.Add(mon)
        Next
        Me.comboSrchYr.Text = year
        Me.comboSrchMonth.Text = month
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        'search
        Me.comboSrchYr.Enabled = False
        Me.comboSrchMonth.Enabled = False
        Me.txtSrchAE.Enabled = Not blnflag
        'grid 
        Me.dtgAdjAmt.Enabled = Not blnflag
        'edit
        Me.txtAEname.Enabled = False
        Me.txtmonth.Enabled = False
        Me.txtAmt.Enabled = blnflag
        Me.txtReason.Enabled = blnflag
        If ActionFlag = "New" Then
            Me.comboAE.Enabled = blnflag
        Else
            Me.comboAE.Enabled = False
        End If
        'button
        Me.btnNew.Enabled = Not blnflag
        Me.btnEnquiry.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        'radio button
        Me.rbSrchSec.Enabled = Not blnflag
        Me.rbSrchFut.Enabled = Not blnflag
        Me.rbFut.Enabled = False
        Me.rbSec.Enabled = False
    End Sub

    Private Sub EmptyFields()
        Me.comboAE.Text = ""
        comboAE_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        Me.txtAEname.Text = ""
        Me.txtmonth.Text = ""
        Me.txtAmt.Text = 0.0
        Me.txtReason.Text = ""
        Me.rbSec.Checked = True
    End Sub

    Private Sub GetAE()
        Dim ds As DataSet = cls.FncGetAE()
        AEtbl = ds.Tables(0)
    End Sub
    Private Sub GetAeByMonth(ByVal Month As String, ByVal Trade As String)
        Me.comboAE.Items.Clear()
        Dim lstrSQL As String = ""
        If Trade = cls.Sec Then
            lstrSQL = "txmonth='" & Me.comboSrchYr.Text & Format(Val(Me.comboSrchMonth.Text), "00") & "' and inSec=1 "
        Else
            lstrSQL = "txmonth='" & Me.comboSrchYr.Text & Format(Val(Me.comboSrchMonth.Text), "00") & "' and inFut=1 "
        End If
        Dim AElist() As DataRow = AEtbl.Select(lstrSQL, "ae_no asc")
        For row As Integer = 0 To AElist.Length - 1
            Me.comboAE.Items.Add(AElist(row).Item("ae_no"))
        Next
    End Sub

    Private Sub comboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAE.SelectedIndexChanged, comboAE.LostFocus
        If LoadFlag = False And ActionFlag = "New" Then
            If Me.comboAE.Text.Trim.Length > 0 Then
                Me.comboAE.Text = Me.comboAE.Text.ToUpper
                Dim AE As DataRow() = AEtbl.Select("ae_no='" & Me.comboAE.Text & "'")
                If AE.Length > 0 Then
                    Me.txtAEname.Text = AE(0).Item("ae_name")
                    Return
                End If
            Else
                Me.txtAEname.Text = ""
            End If
            Me.txtAEname.Text = ""
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ActionFlag <> "" Then
            ActionFlag = ""
            Me.dtgAdjAmt_SelectionChanged(Nothing, System.EventArgs.Empty)
            ObjEnable(False)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnquiry.Click
        If LoadFlag = False Then
            If (Me.comboSrchMonth.Text.Length > 0 And Me.comboSrchMonth.Text <> "00") And Me.comboSrchYr.Text.Length > 0 Then
                Dim Type As String = ""
                If Me.rbSrchFut.Checked Then
                    Type = cls.Fut
                Else
                    Type = cls.Sec
                End If
                Me.dtgAdjAmt.DataSource = cls.FncEnquiry(Me.comboSrchYr.Text & Format(Val(Me.comboSrchMonth.Text), "00"), Me.txtSrchAE.Text, Type).Tables("AdjTbl")
                GetAeByMonth(Me.comboSrchYr.Text & Format(Val(Me.comboSrchMonth.Text), "00"), Type)
                lsubGoRecord()
                Me.dtgAdjAmt_SelectionChanged(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub
    Private Sub lsubGoRecord()
        If LoadFlag = False Then
            If dtgAdjAmt.Rows.Count > 0 And id > 0 Then
                For row As Integer = 0 To Me.dtgAdjAmt.Rows.Count - 1
                    If dtgAdjAmt.Rows(row).Cells("cjid").Value = id Then
                        dtgAdjAmt.Rows(row).Cells("ae_no").Selected = True
                        Exit For
                    End If
                Next
                Me.dtgAdjAmt_SelectionChanged(Nothing, System.EventArgs.Empty)
                id = 0
            End If
        End If
    End Sub
    Private Sub comboSrchMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchMonth.SelectedIndexChanged
        If LoadFlag = False And comboSrchMonth.Text.Length > 0 And comboSrchYr.Text.Length > 0 Then
            Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub comboSrchYr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchYr.SelectedIndexChanged
        If LoadFlag = False And comboSrchYr.Text.Length > 0 And comboSrchYr.Text.Length > 0 Then
            Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        EmptyFields()
        Me.comboAE.SelectedIndex = -1
        Me.txtAEname.Text = ""
        If rbSrchFut.Checked Then
            rbFut.Checked = True
        Else
            rbSec.Checked = True
        End If
        If Me.dtgAdjAmt.Rows.Count > 0 Then
            Me.comboAE.SelectedIndex = Me.comboAE.FindString(Me.dtgAdjAmt.CurrentRow.Cells("ae_no").Value)
        End If
        ActionFlag = "New"
        ObjEnable(True)
        Me.txtmonth.Text = Me.comboSrchYr.Text & Format(Val(Me.comboSrchMonth.Text), "00")
        Me.comboAE.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dtgAdjAmt.Rows.Count <= 0 Then
            GSubShowInfo(GFncGetSysMsg(80))
            Return
        End If
        ObjEnable(True)
        ActionFlag = "Edit"
        Me.txtAmt.Focus()
    End Sub

    Private Sub dtgAdjAmt_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAdjAmt.SelectionChanged
        If Me.dtgAdjAmt.RowCount > 0 Then
            Me.comboAE.Text = dtgAdjAmt.CurrentRow.Cells("ae_no").Value
            Me.txtAEname.Text = dtgAdjAmt.CurrentRow.Cells("ae_name").Value
            Me.txtmonth.Text = dtgAdjAmt.CurrentRow.Cells("txmonth").Value
            Me.txtAmt.Text = dtgAdjAmt.CurrentRow.Cells("adj_amt").Value
            Me.txtReason.Text = dtgAdjAmt.CurrentRow.Cells("reason").Value
            If dtgAdjAmt.CurrentRow.Cells("TradeType").Value = "Securities" Then
                Me.rbSec.Checked = True
            Else
                Me.rbFut.Checked = True
            End If
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        Else
            EmptyFields()
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ae As String = ""
        Dim month As String = ""
        Dim amt As Double = 0
        Dim reason As String = ""
        Dim Trade As String = ""
        'Dim rid As Double = 0
        ae = Me.comboAE.Text
        month = Me.txtmonth.Text
        amt = Me.txtAmt.Text
        reason = Me.txtReason.Text
        If Me.rbFut.Checked Then
            Trade = cls.Fut
        ElseIf Me.rbSec.Checked Then
            Trade = cls.Sec
        End If
        If reason.Trim.Length <= 0 Then
            GSubShowInfo(GFncGetSysMsg(59))
        End If
        If ActionFlag = "Edit" And dtgAdjAmt.Rows.Count > 0 Then
            id = Me.dtgAdjAmt.CurrentRow.Cells("cjid").Value
        End If
        Select Case ActionFlag
            Case "New"
                If cls.ValidateAEComm(ae, month) = False Then
                    GSubShowInfo(GFncGetSysMsg(57))
                    Return
                End If
                'If cls.ValidateDuplicate(" and ae_no='" & ae & "' and txmonth ='" & month & "' ") Then
                '    GSubShowInfo(GFncGetSysMsg(58))
                '    Return
                'End If
                If AEtbl.Select("ae_no='" & ae & "' ").Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                id = cls.NewRecord(ae, month, amt, reason, Trade)
                Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                ActionFlag = ""
                ObjEnable(False)
                Me.dtgAdjAmt_SelectionChanged(Nothing, System.EventArgs.Empty)
            Case "Edit"
                If cls.ValidateAEComm(ae, month) = False Then
                    GSubShowInfo(GFncGetSysMsg(57))
                    Return
                End If
                If dtgAdjAmt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                If cls.ValidateExist(id) = False Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(39), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                cls.EditRecord(ae, month, id, amt, reason, Trade)
                Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                ActionFlag = ""
                ObjEnable(False)
                Me.dtgAdjAmt_SelectionChanged(Nothing, System.EventArgs.Empty)
        End Select
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dtgAdjAmt.Rows.Count > 0 Then
            If cls.ValidateExist(Me.dtgAdjAmt.CurrentRow.Cells("cjid").Value) = False Then
                GSubShowInfo(GFncGetSysMsg(14))
                Return
            End If
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Dim Trade As String
            If Me.rbFut.Checked Then
                Trade = cls.Fut
            Else
                Trade = cls.Sec
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            cls.DelRecord(Me.dtgAdjAmt.CurrentRow.Cells("ae_no").Value, Me.dtgAdjAmt.CurrentRow.Cells("txmonth").Value, _
                Me.dtgAdjAmt.CurrentRow.Cells("cjid").Value, Trade, GFncNoNullString(Me.dtgAdjAmt.CurrentRow.Cells("TradeType").Value).Trim)
            Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
            Me.dtgAdjAmt_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            GSubShowInfo(GFncGetSysMsg(14))
        End If
    End Sub


    Private Sub rbSrchFut_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchFut.CheckedChanged
        If LoadFlag = False And rbSrchFut.Checked = True Then
            Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchSec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchSec.CheckedChanged
        If LoadFlag = False And rbSrchSec.Checked = True Then
            Me.btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

End Class
