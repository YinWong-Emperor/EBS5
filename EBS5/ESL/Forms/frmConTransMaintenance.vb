Public Class frmConTransMaintenance

    Dim cls As New clsConTransMaintenance
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim oldGroupName As String
    Private peFormStatus As EnumFormStatus
    Private pbIsClientSelected As Boolean
    Private pbIsClientHasData As Boolean
    Private pbIsGroupSelected As Boolean


#Region "Load Data"
    Private Sub loadPrintPeriod()
        Dim tempdate As Date = cls.FncGetEndPeriod()
        Dim tempdate2 As Date = cls.FncGetEndPeriod()
        tempdate2 = New Date(tempdate2.Year, tempdate2.Month, 1)
        MyDateTimePicker1.Value = tempdate2
        tempdate = New Date(tempdate.Year, tempdate.Month, tempdate.Day)
        MyDateTimePicker2.Value = tempdate

    End Sub
    Private Sub loadList()
        Dim dt As DataTable
        Me.lbGroup.Items.Clear()
        dt = cls.FncLoadGroup()
        For Each dr As DataRow In dt.Rows
            Me.lbGroup.Items.Add(dr("list_name").ToString.Trim)
        Next
        dt.Clear()
        ' 有数据时选中第一个
        If lbGroup.Items.Count > 0 Then
            Me.lbGroup.SetSelected(0, True)
        End If
    End Sub
    Private Sub loadCombo()
        Dim dt As DataTable
        Me.cmbClient.Items.Clear()
        Me.cmbClient.Items.Add("")
        dt = cls.FncLoadClient()
        For Each dr As DataRow In dt.Rows
            Me.cmbClient.Items.Add(dr("clt_code").ToString.Trim)
        Next
        dt.Clear()
    End Sub

#End Region

#Region "Set Status"
    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub
    Private Sub SetStatus(ByVal status As EnumFormStatus)
        peFormStatus = status
        SetEnabled()
    End Sub
    Private Sub SetEnabled()
        Dim status As EnumFormStatus = peFormStatus

        ' 设置搜索状态
        Me.btnPrint.Enabled = status = EnumFormStatus.Search
        Me.lbGroup.Enabled = status = EnumFormStatus.Search


        ' 设置编辑状态
        Me.btnAdd.Enabled = status = EnumFormStatus.Edit Or status = EnumFormStatus.New
        Me.txtGroup.Enabled = status = EnumFormStatus.New
        Me.cmbClient.Enabled = status = EnumFormStatus.Edit Or status = EnumFormStatus.New
        ' Client List 显示时不能Delete，内容超出时又可以滚动
        If status = EnumFormStatus.Edit Or status = EnumFormStatus.New Then
            Me.lbClient.SelectionMode = SelectionMode.One
        Else
            Me.lbClient.SelectionMode = SelectionMode.None
        End If

        ' 设置按钮状态
        Me.btnEdit.Enabled = status = EnumFormStatus.Search And pbIsGroupSelected
        Me.btnNew.Enabled = status = EnumFormStatus.Search

        Me.btnSave.Enabled = (status = EnumFormStatus.Edit Or status = EnumFormStatus.New) And pbIsClientHasData
        Me.btnUP.Enabled = (status = EnumFormStatus.Edit Or status = EnumFormStatus.New) And pbIsClientSelected
        Me.btnDown.Enabled = (status = EnumFormStatus.Edit Or status = EnumFormStatus.New) And pbIsClientSelected

    End Sub
    Private Function exsitClient(ByVal client As String) As Boolean
        For i As Integer = 0 To Me.lbClient.Items.Count - 1
            If Me.lbClient.Items(i).ToString.Trim = client Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub lsubChangeRow(ByVal strUpDown As String)
        If Me.lbClient.Items.Count > 0 Then
            Dim client As String = Me.lbClient.Text.Trim
            Dim idx As Integer
            For idx = 0 To Me.lbClient.Items.Count - 1
                If Me.lbClient.Items(idx).ToString.Trim = client Then
                    Exit For
                End If
            Next
            If strUpDown = "UP" Then
                If idx > 0 Then
                    Me.lbClient.Items(idx) = Me.lbClient.Items(idx - 1)
                    Me.lbClient.Items(idx - 1) = client
                    Me.lbClient.SetSelected(idx - 1, True)
                End If
            ElseIf strUpDown = "DN" Then
                If idx < Me.lbClient.Items.Count - 1 Then
                    Me.lbClient.Items(idx) = Me.lbClient.Items(idx + 1)
                    Me.lbClient.Items(idx + 1) = client
                    Me.lbClient.SetSelected(idx + 1, True)
                End If
            End If
        End If
    End Sub


#End Region

#Region "Event"
    Private Sub frmConTransMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadList()
        loadCombo()
        loadPrintPeriod()
        lsubShowProcessing(False)
    End Sub

    Private Sub lbGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGroup.SelectedIndexChanged
        pbIsGroupSelected = Not lbGroup.SelectedItem Is Nothing
        Try
            Me.txtGroup.Text = Me.lbGroup.Text.Trim
            If Me.lbGroup.Text.Trim <> "" Then
                Dim dt As DataTable
                Me.lbClient.Items.Clear()
                dt = cls.FncLoadClient(Me.lbGroup.Text.Trim)
                For Each dr As DataRow In dt.Rows
                    Me.lbClient.Items.Add(dr("clt_code").ToString.Trim)
                Next
                dt.Clear()
            End If
        Catch ex As Exception
            Me.lbClient.Items.Clear()
        End Try
        pbIsClientHasData = Me.lbClient.Items.Count > 0
        SetEnabled()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.txtGroup.Text = ""
        Me.lbClient.Items.Clear()
        Me.cmbClient.Text = ""
        Me.oldGroupName = ""
        pbIsClientHasData = Me.lbClient.Items.Count > 0
        SetStatus(EnumFormStatus.New)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.txtGroup.Text = "" Then
            GSubShowInfo("Please select a group first")
            Return
        End If
        SetStatus(EnumFormStatus.Edit)
        oldGroupName = txtGroup.Text.Trim
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not peFormStatus = EnumFormStatus.Search Then
            Me.txtGroup.Text = ""
            Me.cmbClient.Text = ""
            Me.lbClient.Items.Clear()
            loadList()
            SetStatus(EnumFormStatus.Search)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim group As String = Me.txtGroup.Text.Trim
        ' check form
        If Me.txtGroup.Text.Trim = "" Then
            GSubShowWarn("Please input the List Name!")
            Return
        End If

        
        If Me.lbClient.Items.Count = 0 Then
            If peFormStatus = EnumFormStatus.New Then
                GSubShowWarn("No clients in the group, cannot save! ")
                Return
            End If
            If GSubShowYNConfirm("No clients in the group, do you confirm to save?") = Windows.Forms.DialogResult.No Then
                Return
            End If
        ElseIf GSubShowYNConfirm("Confirm to save?") = Windows.Forms.DialogResult.No Then
            Return
        End If
        If cls.FncSave(Me.txtGroup.Text, Me.lbClient, Me.oldGroupName) Then
            GSubShowInfo(GFncGetSysMsg(8))
            loadList()
            ' Try Select Group
            For i As Integer = 0 To Me.lbGroup.Items.Count - 1
                If Me.lbGroup.Items(i).ToString.Trim = group Then
                    Me.lbGroup.SetSelected(i, True)
                    Exit For
                End If
            Next
            SetStatus(EnumFormStatus.Search)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim ccCls As New ClsClientCodes
        Dim clientCode As String = Me.cmbClient.Text.Trim

        '1 <原逻辑>
        If clientCode = "" Then Return

        '2
        If (ccCls.FncIsClientCodeLengthValid(clientCode) = False) Then
            ccCls.ShowMsg_ClientCodeLengthLimition()
            cmbClient.Focus()
            Return
        End If

        '3
        If (ccCls.FncIsClientCodeExist(clientCode) = False) Then
            ccCls.ShowMsg_InvalidClientCode()
            cmbClient.Focus()
            Return
        End If

        '4
        If (Me.lbClient.Items.Contains(clientCode) = True) Then
            GSubShowWarn("Client already exists!")
            cmbClient.Focus()
            Return
        End If

        'pass
        Me.lbClient.Items.Add(clientCode)
        pbIsClientHasData = Me.lbClient.Items.Count > 0
        SetEnabled()

    End Sub


    Private Sub lbClient_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbClient.KeyUp
        If e.KeyValue = System.Windows.Forms.Keys.Delete Then
            Dim client As String = Me.lbClient.Text.Trim
            For i As Integer = 0 To Me.lbClient.Items.Count - 1
                If Me.lbClient.Items(i).ToString.Trim = client Then
                    Me.lbClient.Items.RemoveAt(i)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click
        lsubChangeRow("UP")
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        lsubChangeRow("DN")
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
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
                lsubShowProcessing(False)
                Exit Sub
            End If
        End If
        Application.DoEvents()

        If Me.rbtAll.Checked Then
            rpt = cls.FncGenRpt(CDate(Me.MyDateTimePicker1.Text), CDate(Me.MyDateTimePicker2.Text))
        ElseIf Me.rbtCurrent.Checked Then
            rpt = cls.FncGenRpt(CDate(Me.MyDateTimePicker1.Text), CDate(Me.MyDateTimePicker2.Text), Me.lbGroup.Text.Trim)
        End If
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub MyDateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyDateTimePicker2.ValueChanged
        If Me.MyDateTimePicker2.Value < Me.MyDateTimePicker1.Value Then
            Me.MyDateTimePicker2.Value = Me.MyDateTimePicker1.Value
        End If
    End Sub

    Private Sub MyDateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyDateTimePicker1.ValueChanged
        If Me.MyDateTimePicker2.Value < Me.MyDateTimePicker1.Value Then
            Me.MyDateTimePicker1.Value = Me.MyDateTimePicker2.Value
        End If
    End Sub

    Private Sub lbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbClient.SelectedIndexChanged
        pbIsClientSelected = Not lbClient.SelectedItem Is Nothing
        SetEnabled()
    End Sub

    Private Sub lbClient_DataSourceChanged(sender As Object, e As EventArgs) Handles lbClient.DataSourceChanged
        pbIsClientSelected = Not lbClient.SelectedItem Is Nothing
        SetEnabled()
    End Sub

    Private Sub lbGroup_DataSourceChanged(sender As Object, e As EventArgs) Handles lbGroup.DataSourceChanged
        pbIsGroupSelected = Not lbGroup.SelectedItem Is Nothing
        SetEnabled()
    End Sub
#End Region

    Private Sub cmbClient_Leave(sender As Object, e As EventArgs) Handles cmbClient.Leave
        'Dim code As String = Me.cmbClient.Text.Trim
        'If code.Length > 0 Then
        '    Me.cmbClient.Text = code.PadLeft(8, "0")
        'End If
    End Sub
End Class
