Imports System.Linq

Public Class frmCRCDebitBalance

    Dim cls As New clsCRCDebitBalance
    Dim changeStatus As Boolean = True

    Private Sub frmCRCDebitBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        Me.AutoScroll = False

        'Load AE List
        Me.tabCRCBAD.SelectedIndex = 0
        Me.dgv_Binding()

    End Sub


    Private Sub ReLoadPrintTab()

        '---Load Runner Codes---
        Dim runderCodes As DataTable = cls.FncLoadRunnerCodes()
        Dim retRunderCodes As IQueryable(Of String) = runderCodes.AsEnumerable().AsQueryable().Select(Function(x) x.Field(Of String)(0))

        cbbPrintRange_CodeFrom.DataSource = retRunderCodes.ToArray()
        cbbPrintRange_CodeFrom.SelectedIndex = -1
        cbbPrintRange_CodeTo.DataSource = retRunderCodes.ToArray()
        cbbPrintRange_CodeTo.SelectedIndex = -1

        rbPrintRange_All.Checked = True
        '-----------------------
    End Sub

    Private Sub plAEDtl_Paint(sender As Object, e As PaintEventArgs) Handles plAEDtl.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.plAEDtl.ClientRectangle, Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid)
    End Sub

#Region "List"

    'Binding AE List
    Private Sub dgv_Binding()

        'List
        Dim dt As DataTable = cls.FncSearch(Me.txtAECode.Text)
        Me.dgvAEListing.AutoGenerateColumns = False
        Me.dgvAEListing.DataSource = dt

        'Total
        Dim dt_total As DataTable = cls.FncTotalSearch(Me.txtAECode.Text)
        Me.dgvTotal.AutoGenerateColumns = False
        Me.dgvTotal.ColumnHeadersVisible = False
        Me.dgvTotal.DataSource = dt_total

    End Sub

    'Ae Code Changed
    Private Sub txtAECode_TextChanged(sender As Object, e As EventArgs) Handles txtAECode.TextChanged
        Me.dgv_Binding()
        'If Me.dgvAEListing.RowCount <= 0 Then
        '    Me.tabCRCBAD.TabPages.Remove(Me.tlpAEDtl)
        'Else
        '    If Not Me.tabCRCBAD.TabPages.Contains(Me.tlpAEDtl) Then
        '        Me.tabCRCBAD.TabPages.Insert(1, Me.tlpAEDtl)
        '    End If
        'End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.txtAECode.Text = ""
    End Sub

#End Region


#Region "Detail"

    Private Sub resetDTLData()

        If dgvAEListing.CurrentRow Is Nothing Then
            Me.txtAECodeShow.Text = ""
            Me.txtName.Text = ""
            Me.txtDebitBalS.Text = ""
            Me.txtMarketValue.Text = ""
            Me.txtDebitBalF.Text = ""
            Me.txtActualRatio.Text = ""
            Me.txtTotalDebit.Text = ""
            Me.chkSetOff.Checked = False
            Me.chkSetOff.Text = False
            Me.nudTypeC.Value = 0
            Me.nudTypeB.Value = 0
            Me.updateTotalCount()
            Me.rtxtRemark.Text = ""
            Me.ChangeDTLPageStatus("Null")
        Else
            Dim cells As DataGridViewCellCollection = dgvAEListing.CurrentRow.Cells
            Me.txtAECodeShow.Text = cells("run_code").Value.ToString()
            Me.txtName.Text = cells("rname").Value.ToString()
            Me.txtDebitBalS.Text = Format(cells("dr").Value.ToString(), "Standard")
            Me.txtMarketValue.Text = Format(cells("mv").Value.ToString(), "Standard")
            Me.txtDebitBalF.Text = Format(cells("fdr").Value.ToString(), "Standard")
            Me.txtActualRatio.Text = Format(cells("actr").Value.ToString().Replace("%", ""), "Standard") + "%"
            Me.txtTotalDebit.Text = Format((cells("fdr").Value + cells("dr").Value).ToString(), "Standard")
            Me.chkSetOff.Checked = IIf(cells("seto").Value = "T", True, False)
            Me.chkSetOff.Text = IIf(cells("seto").Value = "T", "Yes", "No")
            Me.nudTypeC.Value = cells("c_type").Value
            Me.nudTypeB.Value = cells("b_type").Value
            Me.updateTotalCount()
            Me.rtxtRemark.Text = cells("remarks").Value.ToString()
            Me.ChangeDTLPageStatus("")
        End If

    End Sub

    Private Sub tabCRCBAD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCRCBAD.SelectedIndexChanged
        If Me.tabCRCBAD.SelectedTab.Name = "tlpAEDtl" Then
            Me.resetDTLData()
        ElseIf Me.tabCRCBAD.SelectedTab.Name = "tlpAEListing" Then
            Me.dgv_Binding()
        ElseIf Me.tabCRCBAD.SelectedTab.Name = "tlpPrint" Then
            Me.ReLoadPrintTab()
        End If
    End Sub


    Private Sub tabCRCBAD_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabCRCBAD.Selecting
        e.Cancel = (Not changeStatus)
    End Sub

    Private Sub ChangeDTLPageStatus(ByVal flag As String)

        If flag = "Edit" Then
            Me.btnEdit.Enabled = False
            Me.changeStatus = False
            Me.btnExit2.Enabled = False

            Me.btnSaveDtl.Enabled = True
            Me.btnCancelDtl.Enabled = True

            Me.chkSetOff.Enabled = True
            Me.nudTypeC.ReadOnly = False
            Me.nudTypeC.BackColor = Color.Blue
            Me.nudTypeC.ForeColor = Color.White
            Me.nudTypeB.ReadOnly = False
            Me.nudTypeB.BackColor = Color.Blue
            Me.nudTypeB.ForeColor = Color.White
            Me.nudTypeC.Enabled = True
            Me.nudTypeB.Enabled = True
            Me.rtxtRemark.Enabled = True
            Me.rtxtRemark.BackColor = Color.Blue
            Me.rtxtRemark.ForeColor = Color.White
        ElseIf flag = "Null" Then
            Me.btnEdit.Enabled = False
            Me.changeStatus = True
            Me.btnExit2.Enabled = True

            Me.btnSaveDtl.Enabled = False
            Me.btnCancelDtl.Enabled = False

            Me.chkSetOff.Enabled = False
            Me.nudTypeC.ReadOnly = True
            Me.nudTypeC.BackColor = TextBox.DefaultBackColor
            Me.nudTypeC.ForeColor = Color.Black
            Me.nudTypeB.ReadOnly = True
            Me.nudTypeB.BackColor = TextBox.DefaultBackColor
            Me.nudTypeB.ForeColor = Color.Black
            Me.rtxtRemark.Enabled = False
            Me.rtxtRemark.BackColor = TextBox.DefaultBackColor
            Me.rtxtRemark.ForeColor = Color.Black
            Me.nudTypeC.Enabled = False
            Me.nudTypeB.Enabled = False
        Else
            Me.btnEdit.Enabled = True
            Me.changeStatus = True
            Me.btnExit2.Enabled = True

            Me.btnSaveDtl.Enabled = False
            Me.btnCancelDtl.Enabled = False

            Me.chkSetOff.Enabled = False
            Me.nudTypeC.ReadOnly = True
            Me.nudTypeC.BackColor = TextBox.DefaultBackColor
            Me.nudTypeC.ForeColor = Color.Black
            Me.nudTypeB.ReadOnly = True
            Me.nudTypeB.BackColor = TextBox.DefaultBackColor
            Me.nudTypeB.ForeColor = Color.Black
            Me.rtxtRemark.Enabled = False
            Me.rtxtRemark.BackColor = TextBox.DefaultBackColor
            Me.rtxtRemark.ForeColor = Color.Black
            Me.nudTypeC.Enabled = False
            Me.nudTypeB.Enabled = False
        End If


    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Me.ChangeDTLPageStatus("Edit")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancelDtl.Click
        If GSubShowYNConfirm("Do you want to abort? Yes / No") = DialogResult.Yes Then
            Me.ChangeDTLPageStatus("")
            Me.resetDTLData()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSaveDtl.Click

        If Not IsNumeric(Me.nudTypeC.Value) Then
            GSubShowWarn("C Type can not be empty")
            Me.nudTypeC.Focus()
            Return
        End If

        If Not IsNumeric(Me.nudTypeB.Value) Then
            GSubShowWarn("B Type can not be empty")
            Me.nudTypeB.Focus()
            Return
        End If


        If GSubShowYNConfirm("Do you want to save the record? Yes / No") = DialogResult.Yes Then
            If cls.FncUpdate(Me.txtAECodeShow.Text.Trim(), Me.chkSetOff.Checked, Me.nudTypeB.Value, Me.nudTypeC.Value, Me.rtxtRemark.Text) Then
                Me.ChangeDTLPageStatus("")
            End If
        End If
    End Sub

    Private Function changeTxt2Double(ByVal txt As TextBox) As String
        Dim result As String = ""
        If txt.Text.Trim = "" Or txt.Text.Trim = "." Then
            Return "0.00"
        End If

        If IsNumeric(txt.Text) Then
            Dim decType As Decimal = CDec(txt.Text)
            If decType >= 1000000000.0 Then
                decType = 999999999.99
            End If

            result = decType.ToString("n")
        End If
        Return result
    End Function

    Private Sub updateTotalCount()
        Dim totalCount As Decimal = Me.nudTypeB.Value + Me.nudTypeC.Value
        Me.txtDtlTotal.Text = totalCount.ToString("n")
    End Sub

    Private Sub nudTypeC_Leave(sender As Object, e As EventArgs) Handles nudTypeC.Leave, nudTypeB.Leave
        If sender.GetType Is nudTypeB.GetType Then
            Dim txt As UpDownBase = CType(sender, UpDownBase)
            If txt.Text = "" Then
                txt.Text = "0.00"
            End If
        End If
        Me.updateTotalCount()
    End Sub

    Private Sub chkSetOff_CheckedChanged(sender As Object, e As EventArgs) Handles chkSetOff.CheckedChanged
        Me.chkSetOff.Text = IIf(Me.chkSetOff.Checked, "Yes", "No")
    End Sub

#End Region



    Private Sub cbbPrintRange_TextChanged(sender As Object, e As EventArgs) Handles cbbPrintRange_CodeFrom.TextChanged, cbbPrintRange_CodeTo.TextChanged
        rbPrintRange_RunnerCode.Checked = True
    End Sub

    Private Sub cbxPrintRange_Code_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbPrintRange_CodeFrom.SelectedIndexChanged, cbbPrintRange_CodeTo.SelectedIndexChanged
        If sender Is cbbPrintRange_CodeFrom And cbbPrintRange_CodeTo.Items.Count > 0 Then
            cbbPrintRange_CodeTo.SelectedIndex = cbbPrintRange_CodeFrom.SelectedIndex
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
        Dim frm As New FrmRptDisplay

        'Set cursor
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        'Parse data
        Dim codeFrom As String = cbbPrintRange_CodeFrom.Text.Trim()
        Dim codeTo As String = cbbPrintRange_CodeTo.Text.Trim()
        Dim addition As Boolean = cbxPrintRange_Addition.Checked
        If rbPrintRange_All.Checked Then
            codeTo = ""
            codeFrom = ""
        End If

        Try
            'Get target datas
            Dim dt As DataTable = cls.FncLoadPrintData(codeFrom, codeTo, addition)

            'Get target ReportClass
            rpt = cls.FncCreateRpt(dt, codeFrom, codeTo, addition)

            'Show report
            frm.GSubDisplayRpt(rpt)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
        End Try

        'Restore cursor
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    'Exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click, btnExit2.Click, btnExit_print.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class