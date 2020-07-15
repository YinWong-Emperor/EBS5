Public Class FrmCommProd

    Dim cls As New ClsCommProd
    Dim dtPCode As DataTable
    Dim dtPGM As DataTable
    Dim strMode As String
    Dim intPGid As Integer

    Private Sub FrmCommProd_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        Dim MaxDate As String = GfncGetMonth()
        For year As Integer = Val(MaxDate.Substring(0, 4)) - 5 To Val(MaxDate.Substring(0, 4)) + 5
            Me.comboSrcYr.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.comboSrcMonth.Items.Add(month)
        Next
        Me.comboSrcYr.Text = MaxDate.Substring(0, 4)
        Me.comboSrcMonth.Text = Val(MaxDate.Substring(4, 2))
        Me.txtMonth.Enabled = False
        dtPCode = cls.GetProductCode
        For Each ldrPCode As DataRow In dtPCode.Rows
            Me.cboPCode.Items.Add(ldrPCode("product_code"))
        Next
        Me.strMode = "SEARCH"
        btnSearch_Click(Nothing, System.EventArgs.Empty)
    End Sub
    Private Sub lsubEnable(ByVal bln As Boolean)
        If Not bln Then
            Me.strMode = "SEARCH"
        End If
        If Me.TabControl1.SelectedIndex = 1 Then
            If Me.strMode = "NEW" Then
                Me.txtBPGroup.Text = ""
                Me.txtBPGroup.Visible = True
                Me.cboBPgroup.Visible = False
            Else
                Me.txtBPGroup.Visible = False
                Me.cboBPgroup.Visible = True
            End If
            If bln Then
                Me.dgdBPCode.Columns("product_flag").DefaultCellStyle.BackColor = Color.White
            Else
                Me.dgdBPCode.Columns("product_flag").DefaultCellStyle.BackColor = Color.Linen
            End If
            Me.dgdBPCode.ReadOnly = Not bln
            Me.dgdBPCode.Columns("product_flag").ReadOnly = Not bln
            Me.dgdBPCode.Columns("bpcode").ReadOnly = True
            Me.dgdBPCode.Columns("Bpcname").ReadOnly = True
            Me.dgdBPCode.Columns("market").ReadOnly = True
            Me.dgdBPCode.Columns("bpcode").DefaultCellStyle.BackColor = Color.Linen
            Me.dgdBPCode.Columns("Bpcname").DefaultCellStyle.BackColor = Color.Linen
            Me.dgdBPCode.Columns("market").DefaultCellStyle.BackColor = Color.Linen
            Me.btnDelete.Enabled = False
            Me.CBAll.Enabled = bln
        Else
            Me.btnDelete.Enabled = Not bln
        End If
        Me.btnSave.Visible = True
        Me.btnSave.Enabled = bln
        Me.btnNew.Enabled = Not bln
        Me.btnEdit.Enabled = Not bln
        If bln Then
            If Me.strMode = "NEW" Then
                Me.cboPGroup.Enabled = True
                Me.cboPCode.Enabled = True
                Me.cboBPgroup.Enabled = True
            Else
                Me.cboPCode.Enabled = True
                Me.cboPGroup.Enabled = False
                Me.cboBPgroup.Enabled = False
            End If
        Else
            Me.cboBPgroup.Enabled = True
            Me.cboPCode.Enabled = False
            Me.cboPGroup.Enabled = False
        End If
        Me.comboSrcMonth.Enabled = False
        Me.comboSrcYr.Enabled = False
        Me.txtSrcProd.Enabled = Not bln
        Me.btnSearch.Enabled = Not bln
        'Me.cboBPgroup.Enabled = bln
        Me.txtBMonth.Enabled = False
        Me.dgdPCode.Enabled = Not bln
        Me.dgdPGroup.Enabled = Not bln
        Me.dgdPCode.ReadOnly = True
        Me.dgdPGroup.ReadOnly = True
        Me.dgdPCode.DefaultCellStyle.BackColor = Color.Linen
        Me.dgdPGroup.DefaultCellStyle.BackColor = Color.Linen
    End Sub

    Private Sub lsubClearField()
        Me.cboPGroup.Text = ""
        Me.cboPCode.Text = ""
        Me.cboBPgroup.Text = ""
        Me.txtMonth.Text = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        Me.txtBMonth.Text = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        If Me.TabControl1.SelectedIndex = 1 Then
            For lintCnt As Integer = 0 To Me.dgdBPCode.Rows.Count - 1
                Me.dgdBPCode.Rows(lintCnt).Cells("product_flag").Value = 0
            Next
        End If
    End Sub

    Private Sub lsubSetProd()
        Dim lstrMonth As String = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        Dim ldtProduct As DataTable = cls.GetProduct(lstrMonth)
        Dim ldtProduct1 As DataTable = ldtProduct.Copy
        Dim ldtProduct2 As DataTable = ldtProduct.Copy
        Me.cboBPgroup.DataSource = ldtProduct1
        Me.cboBPgroup.DisplayMember = "product_group"
        Me.cboPGroup.DataSource = ldtProduct2
        Me.cboPGroup.DisplayMember = "product_group"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.strMode = "SEARCH" Then
            Me.Close()
        Else
            lsubShowPCode()
            Me.lsubEnable(False)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim lstrMonth As String = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        Dim ldtPG As DataTable = cls.GetProduct(lstrMonth, IIf(Me.txtSrcProd.Text.Trim <> "", _
                    " and product_group like '%" & Me.txtSrcProd.Text.Trim & "%' ", ""))
        lsubEnable(False)
        Me.lsubClearField()
        lsubSetProd()
        Me.dgdPCode.DataSource = cls.GetProductGroup(lstrMonth, " and product_group = '' ")
        Me.dgdPGroup.DataSource = ldtPG
    End Sub

    Private Sub lsubShowPG(ByVal strPG As String)
        Dim lstrMonth As String = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        Me.dgdPCode.DataSource = cls.GetProductGroup(lstrMonth, " and product_group = '" & strPG & "' ")
    End Sub

    Private Sub dgdPGroup_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdPGroup.SelectionChanged
        If Me.dgdPGroup.Rows.Count > 0 Then
            If Me.dgdPGroup.SelectedCells.Count > 0 Then
                Me.lsubShowPG(Me.dgdPGroup.Rows(Me.dgdPGroup.SelectedCells(0).RowIndex).Cells("product_group").Value)
            End If
        End If
    End Sub

    Private Sub dgdPCode_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdPCode.SelectionChanged
        lsubShowPCode()
    End Sub

    Private Sub lsubShowPCode()
        If Me.dgdPGroup.Rows.Count > 0 Then
            If Me.dgdPCode.SelectedCells.Count > 0 Then
                'Me.cboPGroup.Text = Me.dgdPCode.CurrentRow.Cells("PCGroup").Value
                'Me.cboPCode.Text = Me.dgdPCode.CurrentRow.Cells("pcCode").Value
                'Me.txtMonth.Text = Me.dgdPCode.CurrentRow.Cells("pcMonth").Value
                Me.cboPGroup.Text = Me.dgdPCode.Rows(Me.dgdPCode.SelectedCells(0).RowIndex).Cells("PCGroup").Value
                Me.cboPCode.Text = Me.dgdPCode.Rows(Me.dgdPCode.SelectedCells(0).RowIndex).Cells("pcCode").Value
                Me.txtMonth.Text = Me.dgdPCode.Rows(Me.dgdPCode.SelectedCells(0).RowIndex).Cells("pcMonth").Value
                intPGid = Me.dgdPCode.Rows(Me.dgdPCode.SelectedCells(0).RowIndex).Cells("pcpgid").Value
            End If
        End If
    End Sub

    Private Sub cboPCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPCode.SelectedIndexChanged
        Dim ldrPCode As DataRow() = dtPCode.Select(" product_code = '" & Me.cboPCode.Text & "' ")
        Me.lblName.Text = ""
        If ldrPCode.Length > 0 Then
            Me.lblName.Text = ldrPCode(0).Item("product_name")
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Me.strMode = "MODIFY"
        Me.lsubEnable(True)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        lsubClearField()
        If Me.dgdPGroup.Rows.Count > 0 Then
            If Me.dgdPGroup.SelectedCells.Count > 0 Then
                Me.cboPGroup.Text = Me.dgdPGroup.Rows(Me.dgdPGroup.SelectedCells(0).RowIndex).Cells("product_group").Value
            End If
        End If
        Me.strMode = "NEW"
        Me.lsubEnable(True)
    End Sub

    Private Function lfncCheck() As Boolean
        Dim lstrMonth As String = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        If Me.TabControl1.SelectedIndex = 0 Then
            If Me.cboPGroup.Text.Trim = "" Then
                GSubShowWarn(GFncGetSysMsg(53))
                Me.cboPGroup.Focus()
                Return False
            End If
            Dim ldtPG As DataTable = cls.GetProductGroup(lstrMonth, " and product_group = '" & Me.cboPGroup.Text.Trim & "' and a.product_code = '" & Me.cboPCode.Text.Trim & "' ")
            If ldtPG.Rows.Count > 0 Then
                If strMode = "MODIFY" Then
                    If intPGid <> ldtPG.Rows(0).Item("pgid") Then
                        GSubShowWarn(GFncGetSysMsg(54))
                        Me.cboPCode.Focus()
                        Return False
                    End If
                Else
                    GSubShowWarn(GFncGetSysMsg(54))
                    Me.cboPCode.Focus()
                    Return False
                End If
            End If
        Else
            If strMode = "NEW" Then
                If Me.txtBPGroup.Text.Trim = "" Then
                    GSubShowWarn(GFncGetSysMsg(53))
                    Me.cboBPgroup.Focus()
                    Return False
                End If
                Dim ldtPG As DataTable = cls.GetProductGroup(lstrMonth, " and product_group = '" & Me.txtBPGroup.Text.Trim & "'")
                If ldtPG.Rows.Count > 0 Then
                    GSubShowWarn(GFncGetSysMsg(54))
                    Me.cboPCode.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lstrSQL As String
        If Not lfncCheck() Then
            Return
        End If
        If Me.TabControl1.SelectedIndex = 1 Then
            If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                If cls.lfncUpdBatch(Me.txtBMonth.Text, Me.txtBPGroup.Text, Me.dgdBPCode) Then
                    Me.lsubSetProd()
                    If Me.strMode = "NEW" Then
                        Me.cboBPgroup.Text = Me.txtBPGroup.Text
                    End If
                    Me.lsubMoveRecord(Me.cboBPgroup.Text)
                    Me.lsubEnable(False)
                End If
            End If
        Else
            Dim logStr As String = ""
            If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                If strMode = "MODIFY" Then
                    lstrSQL = " update draft_comm_product_group set product_code = '" & Me.cboPCode.Text.Trim & _
                        "' where pgid = " & intPGid
                    Dim proDt As DataTable = GFncRtnDS(GSCnSqlConn, "select product_code from draft_comm_product_group " & _
                        "where pgid = " & intPGid).Tables(0)
                    If proDt.Rows.Count > 0 Then
                        logStr = GfncOneFieldLog("Product Code", GFncNoNullString(proDt.Rows(0).Item("product_code")).Trim, Me.cboPCode.Text.Trim)
                    Else
                        logStr = GfncOneFieldLog("Product Code", Me.cboPCode.Text.Trim)
                    End If
                Else
                    lstrSQL = "insert into draft_comm_product_group (txmonth, product_group, product_code) values ('" & _
                        Me.txtMonth.Text.Trim & "','" & Me.cboPGroup.Text.Trim & "','" & Me.cboPCode.Text.Trim & "')"
                    logStr = GfncOneFieldLog("Product Group", Me.cboPGroup.Text.Trim) & " " & GfncOneFieldLog("Product Code", Me.cboPCode.Text.Trim)
                End If
                If cls.lfncUpd(lstrSQL, logStr, strMode.Substring(0, 1), Me.txtMonth.Text.Trim, intPGid) Then
                    Me.lsubMoveRecord(Me.cboPGroup.Text, Me.cboPCode.Text)
                    Me.lsubEnable(False)
                End If
            End If
        End If
    End Sub

    Private Sub lsubMoveRecord(ByVal strPG As String, Optional ByVal strPC As String = "")
        If Me.TabControl1.SelectedIndex = 0 Then
            Me.txtSrcProd.Text = ""
            btnSearch_Click(Nothing, System.EventArgs.Empty)
            For lintCnt As Integer = 0 To Me.dgdPGroup.Rows.Count - 1
                If Me.dgdPGroup.Rows(lintCnt).Cells("product_group").Value = strPG Then
                    Me.dgdPGroup.Rows(lintCnt).Cells("product_group").Selected = True
                    Me.lsubShowPG(Me.dgdPGroup.Rows(Me.dgdPGroup.SelectedCells(0).RowIndex).Cells("product_group").Value)
                    lsubShowPCode()
                End If
            Next
            For lintCnt As Integer = 0 To Me.dgdPCode.Rows.Count - 1
                If Me.dgdPCode.Rows(lintCnt).Cells("pcCode").Value = strPC Then
                    Me.dgdPCode.Rows(lintCnt).Cells("pcCode").Selected = True
                End If
            Next
        Else
            lsubSetProd()
            Me.cboBPgroup.Text = strPG
            lsubSelectPCode(strPG)
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If strMode <> "SEARCH" Then
            e.Cancel = True
        End If
        If Me.TabControl1.SelectedIndex = 1 Then
            Me.txtBMonth.Text = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
            lsubShowBatch()
            lsubSelectPCode(Me.cboBPgroup.Text)
            Me.lsubEnable(False)
        End If
    End Sub

    Private Sub lsubSelectPCode(ByVal strPG As String)
        Dim lintCnt As Integer
        Dim lstrMonth As String = Format(Val(Me.comboSrcYr.Text), "0000") & Format(Val(Me.comboSrcMonth.Text), "00")
        Dim ldtPG As DataTable = cls.GetProductGroup(lstrMonth, " and product_group = '" & strPG & "' ")
        For lintCnt = 0 To Me.dgdBPCode.Rows.Count - 1
            Me.dgdBPCode.Rows(lintCnt).Cells("product_flag").Value = 0
        Next
        For Each ldrPG As DataRow In ldtPG.Rows
            For lintCnt = 0 To Me.dgdBPCode.Rows.Count - 1
                If Me.dgdBPCode.Rows(lintCnt).Cells("Bpcode").Value = ldrPG("product_code") Then
                    Me.dgdBPCode.Rows(lintCnt).Cells("product_flag").Value = 1
                End If
            Next
        Next
    End Sub

    Private Sub lsubShowBatch()
        Dim ldt As New DataTable
        Dim ldtPC As DataTable = cls.GetProductCode()
        cls.lsubInitDT(ldt)
        For Each ldrPC As DataRow In ldtPC.Rows
            Dim ldr As DataRow = ldt.NewRow
            ldr("product_code") = ldrPC("product_code")
            ldr("product_name") = ldrPC("product_name")
            ldr("market") = ldrPC("market")
            ldr("product_flag") = 0
            ldt.Rows.Add(ldr)
        Next
        Me.dgdBPCode.DataSource = ldt
        If Me.dgdPGroup.Rows.Count > 0 Then
            If Me.dgdPGroup.SelectedCells.Count > 0 Then
                Me.cboBPgroup.Text = Me.dgdPGroup.Rows(Me.dgdPGroup.SelectedCells(0).RowIndex).Cells("product_group").Value
            End If
        End If
    End Sub

    Private Sub cboBPgroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBPgroup.SelectedIndexChanged
        lsubSelectPCode(Me.cboBPgroup.Text)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.cboPGroup.Text.Trim <> "" And Me.cboPCode.Text.Trim <> "" Then
            If (GSubShowYNConfirm(GFncGetSysMsg(11) & " (Group: " & Me.cboPGroup.Text & " Code: " & Me.cboPCode.Text & ")") = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                Dim logStr As String = GfncOneFieldLog("Product Group", Me.cboPGroup.Text.Trim) & " " & GfncOneFieldLog("Product Code", Me.cboPCode.Text.Trim)
                If cls.lfncUpd("delete from draft_comm_product_group " & " where product_group = '" & Me.cboPGroup.Text.Trim & _
                    "' " & " and product_code = '" & Me.cboPCode.Text.Trim & "'", logStr, "D", Me.txtMonth.Text.Trim, intPGid) Then
                    Me.lsubMoveRecord(Me.cboPGroup.Text, Me.cboPCode.Text)
                End If
            End If
        End If
    End Sub

    Private Sub CBAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBAll.CheckedChanged
        For lintCnt As Integer = 0 To Me.dgdBPCode.Rows.Count - 1
            Me.dgdBPCode.Rows(lintCnt).Cells("product_flag").Value = Me.CBAll.Checked
        Next
    End Sub
End Class
