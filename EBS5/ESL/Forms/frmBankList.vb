Imports CrystalDecisions.Shared
Public Class frmBankList

    Dim cls As New clsBankList
    Dim action As String = ""
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim repledgeDt As DataTable = Nothing

    Private Sub frmBankList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MessageBox.Show("Load Data process will take you 1 to 2 minutes!" & vbCrLf & "Click ""OK"" to start loading.", "Information", MessageBoxButtons.OK)
        Me.dtpStart2.Value = Format(GDteTradeDate, "yyyy/MM/dd")
        Me.dtpEnd2.Value = Format(GDteTradeDate, "yyyy/MM/dd")
        btnSearch_Click(Nothing, System.EventArgs.Empty)
        btnSearch2_Click(Nothing, System.EventArgs.Empty)
        LoadCmb()
        lsubShowProcessing(False)
        repledgeDt = cls.FncGetRepledged()

        radPrintSummary.Checked = True
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable = cls.FncSearchBank(Me.cmbSBank.Text.Trim, Me.cmbSStock.Text.Trim)
        Me.dgvBank.DataSource = dt
    End Sub

    Private Sub LoadCmb()
        Dim dt As DataTable = cls.FncGetBank
        Me.cmbSBank.Items.Clear()
        Me.cmbSBank2.Items.Clear()
        Me.cmbSBank.Items.Add("")
        Me.cmbSBank2.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbSBank.Items.Add(GFncNoNullString(dr("d_bank")).Trim)
            Me.cmbSBank2.Items.Add(GFncNoNullString(dr("d_bank")).Trim)
        Next
        dt = Nothing
        dt = cls.FncGetStock
        Me.cmbSStock.Items.Clear()
        Me.cmbStock.Items.Clear()
        Me.cmbSStock2.Items.Clear()
        Me.cmbSStock.Items.Add("")
        Me.cmbStock.Items.Add("")
        Me.cmbSStock2.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbSStock.Items.Add(GFncNoNullString(dr("stk_code")).Trim)
            Me.cmbStock.Items.Add(GFncNoNullString(dr("stk_code")).Trim)
            Me.cmbSStock2.Items.Add(GFncNoNullString(dr("stk_code")).Trim)
        Next
        dt = Nothing
        Dim exDay As Date = GDteTradeDate.AddMonths(-1)
        dt = cls.FncGetStock2()
        Me.cmbStock2.Items.Clear()
        Me.cmbStock2.Items.Add("")
        For Each dr As DataRow In dt.Rows
            If GFncNoNullDate(dr("date_ex")) <= exDay Then
                Me.cmbStock2.Items.Add(GFncNoNullString(dr("stk_code")).Trim)
            End If
        Next
    End Sub

    Private Sub dgvBank_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvBank.SelectionChanged
        Dim dt As DataTable
        Try
            Me.txtBank.Text = GFncNoNullString(Me.dgvBank.CurrentRow.Cells("d_bank").Value).Trim
            Me.txtName.Text = GFncNoNullString(Me.dgvBank.CurrentRow.Cells("d_bank_name").Value).Trim
            dt = cls.FncSearchStock(Me.txtBank.Text.Trim)
            Me.dgvStock.DataSource = dt
            If Me.cmbSStock.Text.Trim <> "" Then
                For i As Integer = 0 To Me.dgvStock.Rows.Count - 1
                    If GFncNoNullString(Me.dgvStock.Rows(i).Cells("d_stock").Value).Trim = Me.cmbSStock.Text.Trim Then
                        Me.dgvStock.Rows(i).Cells("d_stock").Selected = True
                        dgvStock_SelectionChanged(Nothing, System.EventArgs.Empty)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Me.txtBank.Text = ""
            Me.txtName.Text = ""
            dt = cls.FncSearchStock("")
            Me.dgvStock.DataSource = dt
        End Try
    End Sub

    Private Sub dgvStock_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvStock.SelectionChanged
        Try
            Me.cmbStock.Text = GFncNoNullString(Me.dgvStock.CurrentRow.Cells("d_stock").Value).Trim
            Me.txtRatio.Text = GFncNoNullValue(Me.dgvStock.CurrentRow.Cells("d_ratio").Value)
            Me.txtSeq.Text = GFncNoNullValue(Me.dgvStock.CurrentRow.Cells("d_seq").Value)
        Catch ex As Exception
            Me.cmbStock.Text = ""
            Me.txtRatio.Text = 0.0
            Me.txtSeq.Text = -1
        End Try
    End Sub

    Private Sub setBtn(ByVal flag As Boolean)
        Me.btnSearch.Enabled = flag
        Me.cmbSBank.Enabled = flag
        Me.cmbSStock.Enabled = flag
        Me.btnNew.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.txtBank.Enabled = Not flag
        Me.txtName.Enabled = Not flag
        Me.cmbStock.Enabled = Not flag
        Me.txtRatio.Enabled = Not flag
        Me.cmbSStock.Text = ""
        Me.cmbSBank.Text = ""
        Me.dgvStock.Enabled = flag
        Me.dgvBank.Enabled = flag
        Me.btnReport.Enabled = flag
        Me.btnImport.Enabled = flag
        If Me.TabPage2.Focus Then
            Me.btnImport.Enabled = False
        End If
        Me.btnSearch2.Enabled = flag
        Me.dtpStart2.Enabled = flag
        Me.dtpEnd2.Enabled = flag
        Me.cmbSBank2.Enabled = flag
        Me.cmbSStock2.Enabled = flag
        Me.cmbStock2.Enabled = Not flag
        Me.cmbBank2.Enabled = Not flag
        Me.ambQty.Enabled = Not flag
        Me.dgvRepledged.Enabled = flag
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled And Me.TabPage1.Focus Then
            btnSearch_Click(Nothing, System.EventArgs.Empty)
            setBtn(True)
            action = ""
        ElseIf Me.btnSave.Enabled And Me.TabPage2.Focus Then
            btnSearch2_Click(Nothing, System.EventArgs.Empty)
            setBtn(True)
            action = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        setBtn(False)
        If Me.TabPage1.Focus Then
            Me.txtBank.Text = ""
            Me.txtName.Text = ""
            Me.cmbStock.Text = ""
            Me.txtRatio.Text = 0.0
            Me.txtSeq.Text = -1
            action = "A"
        ElseIf Me.TabPage2.Focus Then
            Me.cmbStock2.Text = ""
            Me.cmbBank2.Text = ""
            Me.ambQty.Text = ""
            Me.ambValue.Text = ""
            Me.ambRatio.Text = ""
            Me.ambAmount.Text = ""
            action = "AS"
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setBtn(False)
        If Me.TabPage1.Focus Then
            Me.txtBank.Enabled = False
            action = "M"
        ElseIf Me.TabPage2.Focus Then
            Me.cmbStock2.Enabled = False
            Me.cmbBank2.Enabled = False
            action = "MS"
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        setBtn(False)
        If Me.TabPage1.Focus Then
            Me.txtBank.Enabled = False
            Me.txtName.Enabled = False
            Me.cmbStock.Enabled = False
            Me.txtRatio.Enabled = False
            Dim op = MessageBox.Show("Confirm to delete?", "", MessageBoxButtons.YesNo)
            If op = Windows.Forms.DialogResult.Yes Then
                If cls.FncDelete(CInt(Me.txtSeq.Text)) Then
                    btnSearch_Click(Nothing, System.EventArgs.Empty)
                    MessageBox.Show("Deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Deletion failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    setBtn(True)
                    Return
                End If
            End If
            LoadCmb()
        ElseIf Me.TabPage2.Focus Then
            Me.cmbBank2.Enabled = False
            Me.cmbStock2.Enabled = False
            Me.ambQty.Enabled = False
            Dim op = MessageBox.Show("Confirm to delete?", "", MessageBoxButtons.YesNo)
            If op = Windows.Forms.DialogResult.Yes Then
                If cls.FncDelete2(CInt(Me.ambSeq2.Text)) Then
                    btnSearch2_Click(Nothing, System.EventArgs.Empty)
                    MessageBox.Show("Deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Deletion failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    setBtn(True)
                    Return
                End If
            End If
        End If
        setBtn(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.TabPage1.Focus Then
            If Me.txtBank.Text.Trim = "" Then
                Me.txtBank.Focus()
                MessageBox.Show("Bank can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Me.txtRatio.Text.Trim = "" Then
                Me.txtRatio.Focus()
                MessageBox.Show("Ratio can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Me.cmbStock.Text.Trim = "" Then
                Me.cmbStock.Focus()
                MessageBox.Show("Stock can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim op = MessageBox.Show("Confirm to save?", "", MessageBoxButtons.YesNo)
            If op = Windows.Forms.DialogResult.No Then
                Return
            End If
        ElseIf Me.TabPage2.Focus Then
            If Me.cmbStock2.Text.Trim = "" Then
                Me.cmbStock2.Focus()
                MessageBox.Show("Stock can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Me.cmbBank2.Text.Trim = "" Then
                Me.cmbBank2.Focus()
                MessageBox.Show("Bank can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Me.ambQty.Text.Trim = "" Then
                Me.ambQty.Focus()
                MessageBox.Show("Repledge Quantity can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            ElseIf CInt(Me.ambQty.Text.Trim) = 0 Then
                Me.ambQty.Focus()
                MessageBox.Show("Repledge Quantity can not be 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim op = MessageBox.Show("Confirm to save?", "", MessageBoxButtons.YesNo)
            If op = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If
        Dim bank As String = Me.txtBank.Text.Trim
        If action = "A" Then
            If cls.FncCheckExist(bank, Me.cmbStock.Text.Trim) Then
                MessageBox.Show("Record already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim seq As Integer = cls.FncAdd(bank, Me.txtName.Text.Trim, Me.cmbStock.Text.Trim, Math.Round(CDbl(Me.txtRatio.Text), 2))
            If seq <> -1 Then
                MessageBox.Show("Insert successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbSBank.Text = bank
                Me.cmbSStock.Text = Me.cmbStock.Text.Trim
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Me.cmbSBank.Text = ""
                Me.cmbSStock.Text = ""
                LoadCmb()
            Else
                MessageBox.Show("Insertion failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        ElseIf action = "M" Then
            If cls.FncCheckExist(bank, Me.cmbStock.Text.Trim, CInt(Me.txtSeq.Text)) Then
                MessageBox.Show("Record already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cls.FncEdit(CInt(Me.txtSeq.Text), Me.txtName.Text.Trim, Me.cmbStock.Text.Trim, Math.Round(CDbl(Me.txtRatio.Text), 2), bank) Then
                MessageBox.Show("Update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbSBank.Text = bank
                Me.cmbSStock.Text = Me.cmbStock.Text.Trim
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Me.cmbSBank.Text = ""
                Me.cmbSStock.Text = ""
                LoadCmb()
            Else
                MessageBox.Show("Save failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        ElseIf action = "AS" Then
            Dim seq As Integer = cls.FncAdd2(Me.cmbBank2.Text.Trim, Me.cmbStock2.Text.Trim, CDbl(Me.ambRatio.Text.Trim), CDbl(Me.ambQty.Text.Trim), _
                CDbl(Me.ambAmount.Text.Trim))
            If seq <> -1 Then
                MessageBox.Show("Insert successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbSBank.Text = bank
                Me.cmbSStock.Text = Me.cmbStock.Text.Trim
                btnSearch2_Click(Nothing, System.EventArgs.Empty)
                If Me.dgvRepledged.Rows.Count > 0 Then
                    For i As Integer = 0 To Me.dgvRepledged.Rows.Count - 1
                        If GFncNoNullValue(Me.dgvRepledged.Rows(i).Cells("seq").Value) = seq Then
                            Me.dgvRepledged.Rows(i).Cells("stk_code").Selected = True
                            dgvRepledged_SelectionChanged(Nothing, System.EventArgs.Empty)
                            Exit For
                        End If
                    Next
                End If
                Me.cmbSBank.Text = ""
                Me.cmbSStock.Text = ""
            Else
                MessageBox.Show("Insertion failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        ElseIf action = "MS" Then
            Dim seq As Integer = CInt(Me.ambSeq2.Text)
            If cls.FncEdit2(seq, CDbl(Me.ambQty.Text.Trim), CDbl(Me.ambAmount.Text.Trim)) Then
                MessageBox.Show("Update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbSBank.Text = bank
                Me.cmbSStock.Text = Me.cmbStock.Text.Trim
                btnSearch2_Click(Nothing, System.EventArgs.Empty)
                If Me.dgvRepledged.Rows.Count > 0 Then
                    For i As Integer = 0 To Me.dgvRepledged.Rows.Count - 1
                        If GFncNoNullValue(Me.dgvRepledged.Rows(i).Cells("seq").Value) = seq Then
                            Me.dgvRepledged.Rows(i).Cells("stk_code").Selected = True
                            dgvRepledged_SelectionChanged(Nothing, System.EventArgs.Empty)
                            Exit For
                        End If
                    Next
                End If
                Me.cmbSBank.Text = ""
                Me.cmbSStock.Text = ""
            Else
                MessageBox.Show("Save failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
        action = ""
        setBtn(True)
    End Sub

    Private Sub txtRatio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRatio.Leave
        If Not IsNumeric(Me.txtRatio.Text) Then
            Me.txtRatio.Focus()
            MessageBox.Show("Ratio must be numeric", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf CDbl(Me.txtRatio.Text) < 0 Or CDbl(Me.txtRatio.Text) > 100 Then
            Me.txtRatio.Focus()
            MessageBox.Show("Ratio must be within the range from 0 to 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
    End Sub

    Private Sub txtBank_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBank.Leave
        If Me.btnSave.Enabled And Me.txtBank.Text.Trim <> "" Then
            Me.txtName.Text = cls.FncGetName(Me.txtBank.Text.Trim)
            If Me.txtName.Text.Trim <> "" Then
                Me.txtName.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
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

        If Me.TabPage1.Focus Then
            rpt = cls.FncGenReport(repledgeDt)
        ElseIf Me.TabPage2.Focus Then
            rpt = cls.FncGenReport2(repledgeDt, CDbl(Me.ambPre.Text.Trim) / 100)
        ElseIf Me.TabPage3.Focus Then
            If radPrintSummary.Checked Then
                rpt = cls.FncGenReport(repledgeDt)
            Else
                rpt = cls.FncGenReport3()
            End If
        End If

        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If
        lsubShowProcessing(False)
    End Sub

    Private Sub btnSearch2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch2.Click
        Me.dgvRepledged.DataSource = cls.FncSearch2(Me.cmbSStock2.Text.Trim, Me.cmbSBank2.Text.Trim, CDate(Me.dtpStart2.Value), CDate(Me.dtpEnd2.Value))
    End Sub

    Private Sub cmbStock2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStock2.SelectedIndexChanged
        Dim mktValue As Double = 0.0
        Me.cmbBank2.Items.Clear()
        If Me.cmbStock2.Text.Trim <> "" Then
            Dim dt As DataTable = cls.FncGetBank2(Me.cmbStock2.Text.Trim)
            If IsNothing(dt) Then
                MessageBox.Show("The selected stock can not be repledged to any bank")
                Me.cmbStock2.Focus()
                Return
            ElseIf dt.Rows.Count = 0 Then
                MessageBox.Show("The selected stock can not be repledged to any bank")
                Me.cmbStock2.Focus()
                Return
            Else
                Me.cmbBank2.Items.Add("")
                For Each dr As DataRow In dt.Rows
                    Me.cmbBank2.Items.Add(GFncNoNullString(dr("d_bank")).Trim)
                Next
                Me.cmbBank2.Text = ""
            End If
            Me.ambTotal.Text = ""
            Me.ambValue.Text = ""
            Me.ambAva.Text = ""
            Dim amountDt As DataTable = cls.FncGetMarketValue(Me.cmbStock2.Text.Trim, repledgeDt)
            If amountDt.Rows.Count > 0 Then
                Me.ambTotal.Text = Format(CDbl(GFncNoNullValue(amountDt.Rows(0).Item("qty"))), "###,###,###,##0")
                Me.ambValue.Text = Format(GFncNoNullValue(amountDt.Rows(0).Item("mktValue")), "###,###,###,###,##0.00")
                Me.ambAva.Text = Format(CDbl(GFncNoNullValue(amountDt.Rows(0).Item("availableQty"))), "###,###,###,##0")
            Else
                Me.ambTotal.Text = "0.00"
                Me.ambValue.Text = "0.00"
                Me.ambAva.Text = "0.00"
            End If
        Else
            Me.ambTotal.Text = ""
            Me.ambValue.Text = ""
            Me.ambAva.Text = ""
        End If
    End Sub

    Private Sub cmbBank2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBank2.SelectedIndexChanged
        If Me.cmbBank2.Text.Trim <> "" And Me.cmbStock2.Text.Trim <> "" Then
            Dim dt As DataTable = cls.FncGetRate(Me.cmbBank2.Text.Trim, Me.cmbStock2.Text.Trim)
            If Not IsNothing(dt) Then
                Me.ambRatio.Text = Format(CDbl(GFncNoNullValue(dt.Rows(0).Item("d_ratio"))), "##0.00")
                If Me.ambQty.Text.Trim <> "" Then
                    Dim price As Double = CDbl(Me.ambValue.Text.Trim) / CDbl(Me.ambTotal.Text.Trim)
                    Me.ambAmount.Text = Format(CDbl(price * CDbl(Me.ambQty.Text.Trim)) * CDbl(Me.ambRatio.Text.Trim) / 100, "###,###,###,###,##0.00")
                End If
            Else
                Me.ambAmount.Text = ""
                Me.ambRatio.Text = ""
            End If
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Me.TabControl1.SelectedTab.Name <> Me.TabPage1.Name And Me.btnSave.Enabled Then
            e.Cancel = True
            Return
        End If
        If Me.TabControl1.SelectedTab.Name <> Me.TabPage2.Name And Me.btnSave.Enabled Then
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub dgvRepledged_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvRepledged.SelectionChanged
        Try
            Me.ambSeq2.Text = GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("seq").Value)
            Me.cmbStock2.Text = GFncNoNullString(Me.dgvRepledged.CurrentRow.Cells("stk_code").Value).Trim
            cmbStock2_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Me.cmbBank2.Text = GFncNoNullString(Me.dgvRepledged.CurrentRow.Cells("bank").Value).Trim
            Me.ambQty.Text = Format(CDbl(GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("qty").Value)), "###,###,###,##0")
            Me.ambRatio.Text = Format(CDbl(GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("ratio").Value)), "##0.00")
            Me.ambAmount.Text = Format(CDbl(GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("RValue").Value)), "###,###,###,###,##0.00")
        Catch ex As Exception
            Me.ambSeq2.Text = ""
            Me.cmbStock2.Text = ""
            Me.cmbBank2.Text = ""
            Me.ambQty.Text = ""
            Me.ambRatio.Text = ""
            Me.ambAmount.Text = ""
        End Try
    End Sub

    Private Sub ambQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ambQty.Leave
        Dim price As Double = CDbl(Me.ambValue.Text.Trim) / CDbl(Me.ambTotal.Text.Trim)
        Dim qty As Double = 0.0
        Dim total As Double = 0.0
        If action = "MS" Then
            If CDbl(Me.ambQty.Text.Trim.Replace("%", "")) * CDbl(GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("qty").Value)) < 0 Then
                Me.ambQty.Focus()
                MessageBox.Show("Repledge Quantity can not changed to a different sign", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
        If Me.ambQty.Text.Trim = "" Then
            Me.ambQty.Focus()
            MessageBox.Show("Repledge Quantity can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf CDbl(Me.ambQty.Text.Trim.Replace("%", "")) = 0 Then
            Me.ambQty.Focus()
            MessageBox.Show("Repledge Quantity can not be 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf Me.ambQty.Text.Trim.Contains("%") Then
            qty = CDbl(Me.ambQty.Text.Trim.Replace("%", "")) / 100
            If qty > 1 Or qty < -1 Or qty = 0 Then
                Me.ambQty.Focus()
                MessageBox.Show("Wrong Repledge Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                total = CDbl(Me.ambAva.Text.Trim)
                If action = "MS" Then
                    total += CDbl(GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("qty").Value))
                End If
                Me.ambQty.Text = Format(total * qty, "###,###,###,##0")
                Me.ambAmount.Text = Format(CDbl(Me.ambQty.Text.Trim) * price * CDbl(Me.ambRatio.Text.Trim) / 100, "###,###,###,##0.00")
            End If
        Else
            qty = CDbl(Me.ambQty.Text.Trim)
            total = CDbl(Me.ambAva.Text.Trim)
            If action = "MS" Then
                total += CDbl(GFncNoNullValue(Me.dgvRepledged.CurrentRow.Cells("qty").Value))
            End If
            If qty > total And qty > 0 Then
                Me.ambQty.Focus()
                MessageBox.Show("Wrong Repledge Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            ElseIf qty < 0 And qty < total - CDbl(Me.ambTotal.Text) Then
                Me.ambQty.Focus()
                MessageBox.Show("Wrong Repledge Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            ElseIf Me.ambRatio.Text.Trim <> "" Then
                Me.ambAmount.Text = Format(CDbl(price * qty) * CDbl(Me.ambRatio.Text.Trim) / 100, "###,###,###,###,##0.00")
            End If
        End If
    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Dim myStream As IO.Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = Me.txtFile.Text
        openFileDialog1.Filter = "Excel File (*.xls)|*.xls|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Me.txtFile.Text = openFileDialog1.FileName()
            Catch Ex As Exception
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim Path As String = Me.txtFile.Text
        Dim FileName As String = Path.Substring(Path.LastIndexOf("\") + 1).Replace(".xls", "")
        If FileName.Trim.Length < 0 Or (Path.EndsWith(".xls") = False And Path.EndsWith(".xlsx") = False) Then
            GSubShowError(GFncGetSysMsg(113))
            Return
        End If
        Dim op1 = MessageBox.Show("Confirm to import?", "", MessageBoxButtons.YesNo)
        If op1 = Windows.Forms.DialogResult.No Then
            Return
        Else
            lsubShowProcessing(True)
            setBtn(False)
            Dim msg As String = ""
            Dim dt As DataTable = New dtsRepledge.bankListDataTable
            msg = cls.FncGetdata(Path, dt)
            If msg <> "" Then
                lsubShowProcessing(False)
                setBtn(True)
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf IsNothing(dt) Then
                lsubShowProcessing(False)
                setBtn(True)
                MessageBox.Show("Nothing can be imported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf dt.Rows.Count <= 1 Then
                lsubShowProcessing(False)
                setBtn(True)
                MessageBox.Show("Nothing can be imported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If cls.FncRunSQL(dt) Then
                MessageBox.Show("Import successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                lsubShowProcessing(False)
                setBtn(True)
                MessageBox.Show("Import failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            btnSearch_Click(Nothing, System.EventArgs.Empty)
            lsubShowProcessing(False)
            setBtn(True)
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim saveFileDialog As SaveFileDialog = Nothing
        Dim result As DialogResult = Nothing

        result = MessageBox.Show("Confirm to Export?", "", MessageBoxButtons.YesNo)

        If result = Windows.Forms.DialogResult.Yes Then
            saveFileDialog = New SaveFileDialog
            saveFileDialog.Filter = "Excel File (*.xls)|*.xls|All files (*.*)|*.*"
            result = saveFileDialog.ShowDialog

            If result = Windows.Forms.DialogResult.OK Then
                If cls.FncExportToExcel(IO.Path.GetDirectoryName(saveFileDialog.FileName), _
                                            IO.Path.GetFileName(saveFileDialog.FileName)) Then

                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowError(GFncGetSysMsg(29))
                End If
            End If
        End If
    End Sub
End Class
