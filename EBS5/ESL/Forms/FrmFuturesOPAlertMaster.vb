Imports System.Data.SqlClient

Public Class FrmFuturesOPAlertMaster
    Dim cls As New ClsFuturesOPAlertMaster
    Dim EditCode As String
    Dim EmailFlag As String
    Dim AdjEmail As String
    Dim SysDay As Date
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not Me.btnEdit.Enabled Then
            EnableRow(EditCode, False)
            btnEnquiry_Click(Nothing, System.EventArgs.Empty)
            EnableEdit(False)
            SetFocus()
        Else
            If EmailFlag <> "" Then
                EnableEmail(False)
                Me.txtEmail.Text = ""
                EmailFlag = ""
                btnRefresh_Click(Nothing, System.EventArgs.Empty)
                Me.DtgMail.Focus()
            Else
                Me.Close()
            End If
        End If

    End Sub


    Private Sub FrmFuturesOPAlertMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        GetMarket()
        SysDay = cls.GetSysdate()
        btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        btnRefresh_Click(Nothing, System.EventArgs.Empty)
        lsubShowProcessing(False)
        Me.txtSysdate.Text = SysDay.ToShortDateString

    End Sub

    Private Sub GetMarket()
        Me.cboMarket.Items.Add("")
        Dim DT As DataTable = cls.GetMkt.Tables(0)
        For Each Dr As DataRow In DT.Rows
            Me.cboMarket.Items.Add(Dr.Item("market"))
        Next
    End Sub

    Private Sub btnEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnquiry.Click
        Dim condition As String = ""
        If Me.cboMarket.Text.Length > 0 Then
            condition += " and market ='" & Me.cboMarket.Text.Trim & "' "
        End If
        If Me.txtProductName.Text.Length > 0 Then
            condition += " and upper(product_name) like '%" & Me.txtProductName.Text.Trim.ToUpper & "%' "
        End If
        If Me.txtProductCode.Text.Length > 0 Then
            condition += " and upper(product_code) like '%" & Me.txtProductCode.Text.Trim.ToUpper & "%' "
        End If
        Me.dtgOPAlert.DataSource = cls.SearchAlert(condition).Tables(0)
        For row As Integer = 0 To dtgOPAlert.RowCount - 1
            For col As Integer = 0 To dtgOPAlert.ColumnCount - 1
                Me.dtgOPAlert.Rows(row).Cells(col).ReadOnly = True
            Next
        Next
      
    End Sub
    Private Sub EnableEdit(ByVal blnflag As Boolean)
        Me.btnEdit.Enabled = Not blnflag
        Me.btnEnquiry.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.txtProductCode.ReadOnly = blnflag
        Me.txtProductName.ReadOnly = blnflag
        Me.cboMarket.Enabled = Not blnflag

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dtgOPAlert.SelectedRows.Count > 0 Then
            EnableRow(Me.dtgOPAlert.CurrentRow.Cells("dtgProductCode").Value.ToString.Trim, True)
            EnableEdit(True)
        End If

    End Sub

    Private Sub EnableRow(ByVal code As String, ByVal blnflag As Boolean) 'True when edit
        Dim rowindex As Integer
        For i As Integer = 0 To dtgOPAlert.RowCount - 1
            If dtgOPAlert.Rows(i).Cells("dtgProductCode").Value.ToString.Trim = code Then
                rowindex = i
                'Exit For
            End If
            For col As Integer = 0 To dtgOPAlert.ColumnCount - 1
                dtgOPAlert.Rows(i).Cells(col).ReadOnly = True
            Next
        Next
        EditCode = code
        Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").ReadOnly = Not blnflag
        Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").ReadOnly = Not blnflag
        Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").ReadOnly = Not blnflag
        Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").ReadOnly = Not blnflag
        Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").ReadOnly = Not blnflag
        Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").ReadOnly = Not blnflag
        If blnflag Then
            For i As Integer = 0 To dtgOPAlert.ColumnCount - 1
                Me.dtgOPAlert.Rows(rowindex).Cells(i).Style.BackColor = Color.Linen
                Me.dtgOPAlert.Rows(rowindex).Cells(i).Style.SelectionBackColor = Color.Linen
                Me.dtgOPAlert.Rows(rowindex).Cells(i).Style.SelectionForeColor = Color.Black
            Next
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Style.BackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Style.SelectionBackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Style.SelectionForeColor = Color.Black
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Style.BackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Style.SelectionBackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Style.SelectionForeColor = Color.Black
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").Style.BackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").Style.SelectionBackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").Style.SelectionForeColor = Color.Black
            Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").Style.BackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").Style.SelectionBackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").Style.SelectionForeColor = Color.Black
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Style.BackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Style.SelectionBackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Style.SelectionForeColor = Color.Black
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").Style.BackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").Style.SelectionBackColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").Style.SelectionForeColor = Color.Black

        Else
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Style.BackColor = Color.Linen
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Style.SelectionBackColor = Color.Blue
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Style.SelectionForeColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Style.BackColor = Color.Linen
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Style.SelectionBackColor = Color.Blue
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Style.SelectionForeColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").Style.BackColor = Color.Linen
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").Style.SelectionBackColor = Color.Blue
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert").Style.SelectionForeColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").Style.BackColor = Color.Linen
            Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").Style.SelectionBackColor = Color.Blue
            Me.dtgOPAlert.Rows(rowindex).Cells("month_alert").Style.SelectionForeColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Style.BackColor = Color.Linen
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Style.SelectionBackColor = Color.Blue
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Style.SelectionForeColor = Color.White
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").Style.BackColor = Color.Linen
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").Style.SelectionBackColor = Color.Blue
            Me.dtgOPAlert.Rows(rowindex).Cells("dtgAlert2").Style.SelectionForeColor = Color.White
        End If

        Me.dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Selected = True
        Me.btnEdit.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
    End Sub


    Private Sub SetFocus()
        For i As Integer = 0 To dtgOPAlert.RowCount - 1
            If dtgOPAlert.Rows(i).Cells("dtgProductCode").Value.ToString.Trim = EditCode Then
                dtgOPAlert.Rows(i).Cells("dtgProductCode").Selected = True
                EditCode = ""
                Exit Sub
            End If
        Next

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Condition As String
        If Me.btnEdit.Enabled = False Then
            If GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Dim rowindex As Integer
            For i As Integer = 0 To dtgOPAlert.RowCount - 1
                If dtgOPAlert.Rows(i).Cells("dtgProductCode").Value.ToString.Trim = EditCode Then
                    rowindex = i
                    Exit For
                End If
            Next
            If IsNumeric(dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Value) Then
                Return
            End If

            Dim positionLimit As Object = dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit").Value
            If IsDBNull(positionLimit) Then
                positionLimit = 0
            End If

            Dim positionLimit2 As Object = dtgOPAlert.Rows(rowindex).Cells("dtgPositionLimit2").Value
            If IsDBNull(positionLimit2) Then
                positionLimit2 = 0
            End If

            Condition = " gross_net='" & GetGrossNetCode(dtgOPAlert.Rows(rowindex).Cells("dtgCboGrossNet").Value.ToString.Trim) & "', " & _
                              " position_limit=" & positionLimit & ", " & _
                           " email_alert = '" & GetAlert(dtgOPAlert.Rows(rowindex).Cells("dtgalert").Value) & "', " & _
                           " month_alert = '" & GetAlert(dtgOPAlert.Rows(rowindex).Cells("month_alert").Value) & "', " & _
                        " position_limit_2=" & positionLimit2 & ", " & _
                        " email_alert_2 = '" & GetAlert(dtgOPAlert.Rows(rowindex).Cells("dtgalert2").Value) & "' "

            cls.ModifyProductMaster(EditCode, Condition)
            EnableRow(EditCode, False)
            EnableEdit(False)
            btnEnquiry_Click(Nothing, System.EventArgs.Empty)
            SetFocus()
        End If

        If EmailFlag <> "" Then
            Select Case EmailFlag
                Case "New"
                    If Me.txtEmail.Text.Length <= 0 Or EmailValidation(txtEmail.Text) = False Then
                        GSubShowInfo(GFncGetSysMsg(19))
                        Me.txtEmail.Focus()
                        Return
                    End If
                    If GSubShowYNConfirm(GFncGetSysMsg(47), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Me.txtEmail.Focus()
                        Return
                    End If
                    AdjEmail = Me.txtEmail.Text.ToLower.Trim
                    cls.EmailAdd(Me.txtEmail.Text.ToLower.Trim)
                    EnableEmail(False)
                    btnRefresh_Click(Nothing, System.EventArgs.Empty)
                    EmailFlag = ""
                    SetEmailFocus()
                    ' Me.DtgMail.Focus()

                Case "Adjust"
                    If Me.txtEmail.Text.Length <= 0 Or EmailValidation(txtEmail.Text) = False Then
                        GSubShowInfo(GFncGetSysMsg(19))
                        Me.txtEmail.Focus()
                        Return
                    End If
                    If GSubShowYNConfirm(GFncGetSysMsg(39), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Me.txtEmail.Focus()
                        Return
                    End If
                    cls.EmailAdjust(AdjEmail, Me.txtEmail.Text)
                    AdjEmail = Me.txtEmail.Text
                    
                    EnableEmail(False)
                    btnRefresh_Click(Nothing, System.EventArgs.Empty)
                    EmailFlag = ""
                    SetEmailFocus()
                    'Me.DtgMail.Focus()

            End Select
        End If

        'If Me.TabControl.SelectedTab.Name = Me.TpErrorReport.Name Then

        '    Dim strPrinterName As String = ""
        '    Dim intFromPage As Integer = 0
        '    Dim intToPage As Integer = 0
        '    Dim shtCopies As Short = 1
        '    Dim RptType As String = ""
        '    If Me.RBPrint.Checked = True Then
        '        'printDlg.AllowSomePages = True
        '        If PrintDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '            strPrinterName = PrintDlg.PrinterSettings.PrinterName
        '            shtCopies = PrintDlg.PrinterSettings.Copies
        '            If PrintDlg.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
        '                intFromPage = PrintDlg.PrinterSettings.FromPage
        '                intToPage = PrintDlg.PrinterSettings.ToPage
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End If
        '    lsubShowProcessing(True)
        '    Application.DoEvents()
        '    'If Me.RBTradeRpt.Checked Then
        '    If Me.RBFullRpt.Checked Then
        '        RptType = "Full"
        '    Else
        '        RptType = "Error"
        '    End If

        '    rpt = cls.PrintErrRpt(SysDay, RptType)
        '    'ElseIf Me.RBTA_futRpt.Checked Then

        '    '    ' rpt = cls.PrintFutRpt(Me.CboYr.Text & Format(CInt(Me.CboMonth.Text), "00"))
        '    'End If
        '    Windows.Forms.Cursor.Current = Cursors.WaitCursor

        '    If Me.RBPreview.Checked = True Then
        '        frm.GSubDisplayRpt(rpt)
        '    ElseIf Me.RBPrint.Checked = True Then
        '        If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
        '            GSubShowInfo(GFncGetSysMsg(104))
        '        End If
        '    End If
        '    Windows.Forms.Cursor.Current = Cursors.Default
        '    lsubShowProcessing(False)
        'End If
    End Sub

    Private Function GetGrossNetCode(ByVal val As String) As Char
        Select Case val
            Case "Gross"
                Return "G"
            Case "Net"
                Return "N"
            Case Else
                Return "N"
        End Select
    End Function

    Private Function GetAlert(ByVal val As String) As Integer
        Select Case val
            Case "True"
                Return 1
            Case "False"
                Return 0
            Case Else
                Return 0
        End Select
    End Function

    Private Sub cboMarket_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMarket.SelectedIndexChanged
        btnEnquiry_Click(Nothing, System.EventArgs.Empty)

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        DtgMail.DataSource = cls.EmailRefresh
    End Sub

    Private Sub DtgMail_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtgMail.SelectionChanged
        If Me.DtgMail.Rows.Count > 0 Then
            Me.txtEmail.Text = Me.DtgMail.CurrentRow.Cells("dtgEmail").Value.ToString.Trim
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        EnableEmail(True)

        Me.txtEmail.Text = ""
        EmailFlag = "New"
        Me.txtEmail.Focus()
    End Sub

    Private Sub EnableEmail(ByVal blnflag As Boolean)
        Me.txtEmail.ReadOnly = Not blnflag
        Me.btnRefresh.Enabled = Not blnflag
        Me.DtgMail.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnAdd.Enabled = Not blnflag
        Me.btnModify.Enabled = Not blnflag
        Me.btnDel.Enabled = Not blnflag
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        DtgMail.Focus()
        If txtEmail.Text.Length > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            cls.EmailDel(Me.txtEmail.Text.Trim)
            btnRefresh_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        EnableEmail(True)
        EmailFlag = "Adjust"
        Me.txtEmail.Focus()
        AdjEmail = Me.txtEmail.Text
    End Sub

    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl.Selecting
        If Me.btnAdd.Enabled = False And Me.TabControl.SelectedTab.Name <> Me.TabMail.Name Then
            e.Cancel = True
            Return
        End If
        If Me.btnEdit.Enabled = False And Me.TabControl.SelectedTab.Name <> Me.TabMaster.Name Then
            e.Cancel = True
            Return
        End If
        'If Me.TabControl.SelectedTab.Name = Me.TpErrorReport.Name Then
        '    btnSave.Enabled = True
        'Else
        '    btnSave.Enabled = False
        'End If
    End Sub

    Private Function EmailValidation(ByVal Email As String) As Boolean
        If Email.Contains(" ") Or Email.Contains("@") = False Then
            Return False
        Else
            Return True
        End If

    End Function


    Private Sub btnErrEnq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnErrEnq.Click
        Dim record As String
        Dim condition As String = ""
        If txtParty.Text.Length > 0 Then
            condition += " and upper(counterparty) like '%" & txtParty.Text.ToUpper.Trim & "%' "
        End If
        If txtRptProduct.Text.Length > 0 Then
            condition += " and upper(code) like '%" & txtRptProduct.Text.ToUpper.Trim & "%' "
        End If
        If RBError.Checked Then
            record = "Error"
        Else
            record = "All"
        End If
        'SysDay = cls.GetSysdate()

        Me.DtgErrorReport.DataSource = cls.GetError(condition, record).Tables(0)
        ErrorColor()
    End Sub

    Private Sub ErrorColor()
        For row As Integer = 0 To DtgErrorReport.RowCount - 1
            For col As Integer = 0 To DtgErrorReport.ColumnCount - 1
                If DtgErrorReport.Rows(row).Cells("dtgqty").Value > DtgErrorReport.Rows(row).Cells("dtgPositLimit").Value Then
                    DtgErrorReport.Rows(row).Cells(col).Style.BackColor = Color.DarkRed
                    DtgErrorReport.Rows(row).Cells(col).Style.ForeColor = Color.White
                    DtgErrorReport.Rows(row).Cells(col).Style.SelectionBackColor = Color.DarkRed
                    DtgErrorReport.Rows(row).Cells(col).Style.SelectionForeColor = Color.White
                Else
                    DtgErrorReport.Rows(row).Cells(col).Style.BackColor = Color.Linen
                    DtgErrorReport.Rows(row).Cells(col).Style.ForeColor = Color.Black
                    DtgErrorReport.Rows(row).Cells(col).Style.SelectionBackColor = Color.Linen
                    DtgErrorReport.Rows(row).Cells(col).Style.SelectionForeColor = Color.Black
                End If
            Next
        Next
    End Sub

    Private Sub TpErrorReport_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl.SelectedIndexChanged
        btnErrEnq_Click(Nothing, System.EventArgs.Empty)
        'ErrorColor()

    End Sub

    Private Sub RBAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAll.CheckedChanged
        If RBAll.Checked Then
            btnErrEnq_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub RBError_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBError.CheckedChanged
        If RBError.Checked Then
            btnErrEnq_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    

    Private Sub dtgOPAlert_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgOPAlert.Sorted
        If btnEdit.Enabled = False Then
            EnableRow(EditCode, True)
        Else
            For i As Integer = 0 To dtgOPAlert.RowCount - 1
                For col As Integer = 0 To dtgOPAlert.ColumnCount - 1
                    dtgOPAlert.Rows(i).Cells(col).ReadOnly = True
                Next
            Next
        End If
    End Sub

    Private Sub SetEmailFocus()
        For i As Integer = 0 To Me.DtgMail.RowCount - 1
            If Me.DtgMail.Rows(i).Cells("dtgEmail").Value.ToString.Trim = AdjEmail Then
                DtgMail.Rows(i).Cells("dtgEmail").Selected = True
                DtgMail_SelectionChanged(Nothing, System.EventArgs.Empty)
                AdjEmail = ""
                Exit Sub
            End If
        Next

    End Sub

    Private Sub DtgErrorReport_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtgErrorReport.Sorted
        ErrorColor()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim RptType As String = ""
        If Me.RBPrint.Checked = True Then
            'printDlg.AllowSomePages = True
            If PrintDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDlg.PrinterSettings.PrinterName
                shtCopies = PrintDlg.PrinterSettings.Copies
                If PrintDlg.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDlg.PrinterSettings.FromPage
                    intToPage = PrintDlg.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        lsubShowProcessing(True)
        Application.DoEvents()
        'If Me.RBTradeRpt.Checked Then
        If Me.RBFullRpt.Checked Then
            RptType = "Full"
        Else
            RptType = "Error"
        End If

        rpt = cls.PrintErrRpt(SysDay, RptType)
        'ElseIf Me.RBTA_futRpt.Checked Then

        '    ' rpt = cls.PrintFutRpt(Me.CboYr.Text & Format(CInt(Me.CboMonth.Text), "00"))
        'End If
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If Me.RBPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf Me.RBPrint.Checked = True Then
            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)

    End Sub

    Private Sub DGdUSBPrice_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgOPAlert.DataError

        If e.Exception.Message <> "" Then
            e.Cancel = True
            GSubShowWarn(GFncGetSysMsg(46))
        End If
    End Sub

    'Private Sub dtgOPAlert_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgOPAlert.KeyDown
    '    'Select Case e.KeyCode

    '    '    Case ChrW(Keys.D0), ChrW(Keys.D1), ChrW(Keys.D2), ChrW(Keys.D3), _
    '    '        ChrW(Keys.D4), ChrW(Keys.D5), ChrW(Keys.D6), ChrW(Keys.D7), _
    '    '        ChrW(Keys.D8), ChrW(Keys.D9), ChrW(Keys.Enter), ChrW(Keys.Escape), _
    '    '        ChrW(Keys.Return), ChrW(Keys.Back), ChrW(Keys.Up), ChrW(Keys.Down), _
    '    '        ChrW(Keys.Left), ChrW(Keys.Right), "."c, "+"c, "-"c
    '    '        'pass the check
    '    '    Case Else
    '    '        'not pass the check
    '    '        e.Handled = True
    '    'End Select
    'End Sub

    'Private Sub dtgOPAlert_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgOPAlert.KeyPress
    '    Select Case e.KeyChar

    '        Case ChrW(Keys.D0), ChrW(Keys.D1), ChrW(Keys.D2), ChrW(Keys.D3), _
    '            ChrW(Keys.D4), ChrW(Keys.D5), ChrW(Keys.D6), ChrW(Keys.D7), _
    '            ChrW(Keys.D8), ChrW(Keys.D9), ChrW(Keys.Enter), ChrW(Keys.Escape), _
    '            ChrW(Keys.Return), ChrW(Keys.Back), ChrW(Keys.Up), ChrW(Keys.Down), _
    '            ChrW(Keys.Left), ChrW(Keys.Right), "."c, "+"c, "-"c
    '            'pass the check
    '        Case Else
    '            'not pass the check
    '            e.Handled = True
    '    End Select
    'End Sub

    ''   Private Sub myKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgOPAlert.CellValueChanged
    ''If e.ColumnIndex = dtgPositionLimit.Index Then
    ''    dtgOPAlert.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Val(dtgOPAlert.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
    ''End If
    ''Select Case e.KeyChar

    ''    Case ChrW(Keys.D0), ChrW(Keys.D1), ChrW(Keys.D2), ChrW(Keys.D3), _
    ''        ChrW(Keys.D4), ChrW(Keys.D5), ChrW(Keys.D6), ChrW(Keys.D7), _
    ''        ChrW(Keys.D8), ChrW(Keys.D9), ChrW(Keys.Enter), ChrW(Keys.Escape), _
    ''        ChrW(Keys.Return), ChrW(Keys.Back), ChrW(Keys.Up), ChrW(Keys.Down), _
    ''        ChrW(Keys.Left), ChrW(Keys.Right), "."c, "+"c, "-"c
    ''        'pass the check
    ''    Case Else
    ''        'not pass the check
    ''        e.Handled = True
    ''End Select
    ''  End Sub

End Class
