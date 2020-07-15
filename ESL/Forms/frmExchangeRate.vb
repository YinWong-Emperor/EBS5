Public Class frmExchangeRate

    Dim cls As New clsExchangeRate
    Private pFormStatus As EnumFormStatus
    Private pIsGridSelected As Boolean
    Dim selectedFunction As Integer = 0
    Dim oldCode As String = String.Empty
    Dim currentExid As Long
    Dim currentType As String
    Dim currentCurrency As String

    Private Sub frmExchangeRate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTradeDate.Value = Now.Date
        loadDGV()
        setStatus(EnumFormStatus.Search)
    End Sub

    Private Sub loadDGV()
        Dim dt As DataTable
        dt = cls.FncSearch(cmbType.Text, dtpTradeDate.Value)
        dgvExchangeRate.DataSource = dt
        dgvExchangeRate.DefaultCellStyle.BackColor = Color.Linen
        dgvExchangeRate.ReadOnly = True
    End Sub

    Private Sub loadCombo()
        Me.cmbType.Items.Clear()
        Dim dt As DataTable = cls.FncLoadCombo()
        Me.cmbType.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbType.Items.Add(GFncNoNullString(dr.Item(0)))
        Next
        dt.Clear()
    End Sub

    Private Sub dgvExchangeRate_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvExchangeRate.SelectionChanged
        selectChanged()
    End Sub

    Private Sub selectChanged()
        pIsGridSelected = Not Me.dgvExchangeRate.CurrentRow Is Nothing

        If Me.dgvExchangeRate.Rows.Count > 0 Then
            setDetailsValue(
                Me.dgvExchangeRate.CurrentRow.Cells("exid").Value,
                Me.dgvExchangeRate.CurrentRow.Cells("type").Value,
                Me.dgvExchangeRate.CurrentRow.Cells("rate").Value,
                Me.dgvExchangeRate.CurrentRow.Cells("currency").Value)
        Else
            cleanBox()
        End If
        setStatus(pFormStatus)
    End Sub

    Private Sub setValue(ByVal id As Integer)
        setDetailsValue(
            Me.dgvExchangeRate.Rows(id).Cells("exid").Value,
            Me.dgvExchangeRate.Rows(id).Cells("type").Value,
            Me.dgvExchangeRate.Rows(id).Cells("rate").Value,
            Me.dgvExchangeRate.Rows(id).Cells("currency").Value)
    End Sub

    Private Sub setDetailsValue(ByVal exid As Long, ByVal type As String, ByVal reate As Decimal, ByVal currency As String)
        currentExid = exid
        currentType = type
        currentCurrency = currency
        nudRate.Value = reate
        lblCurrency.Text = String.Format("1 {0} to", currency)
    End Sub

    Private Sub cleanBox()
        lblCurrency.Text = ""
        nudRate.Value = 0
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If btnSave.Enabled Then
            setStatus(EnumFormStatus.Search)
            selectedFunction = 0
            oldCode = String.Empty

            If dgvExchangeRate.Rows.Count > 0 Then
                'Me.dgvExchangeRate.Rows(0).Selected = True
                dgvExchangeRate_SelectionChanged(Nothing, System.EventArgs.Empty)
                'setValue(0)
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub setStatus(ByVal status As EnumFormStatus)
        pFormStatus = status

        cmbType.Enabled = status = EnumFormStatus.Search
        dtpTradeDate.Enabled = status = EnumFormStatus.Search
        btnSearch.Enabled = status = EnumFormStatus.Search

        dgvExchangeRate.Enabled = status = EnumFormStatus.Search

        nudRate.Enabled = status = EnumFormStatus.Edit

        btnEdit.Enabled = status = EnumFormStatus.Search And pIsGridSelected
        btnSave.Enabled = status = EnumFormStatus.Edit
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If dgvExchangeRate.RowCount = 0 Then
            GSubShowWarn(GFncGetSysMsg(113))
            Exit Sub
        End If

        setStatus(EnumFormStatus.Edit)
        nudRate.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If nudRate.Value <= 0 Then
            GSubShowInfo("Rate can not be empty")
            Return
        End If


        If GSubShowYNConfirm("Confirm to Edit?") = Windows.Forms.DialogResult.Yes Then
            Dim result_str As String = cls.FncEdit(currentExid,
                                                    nudRate.Value,
                                                    currentType,
                                                    currentCurrency
                                                    ).ToString()
            If result_str = "2" Then
                GSubShowInfo("Record already existed")
                Return
            ElseIf result_str = "1" Then
                Dim exid As Long = currentExid
                loadDGV()
                Dim Idrow As Integer
                If Me.dgvExchangeRate.Rows.Count > 0 Then
                    For Idrow = 0 To Me.dgvExchangeRate.Rows.Count - 1
                        If dgvExchangeRate.Item("exid", Idrow).Value = exid Then
                            dgvExchangeRate.Rows(Idrow).Selected = True
                            setValue(Idrow)
                            Exit For
                        End If
                    Next
                End If
                setStatus(EnumFormStatus.Search)
            Else
                GSubShowInfo("Record save error.")
                Return
            End If

            'If Not cls.FncDoubleInsert(dgvExchangeRate.CurrentRow.Cells("type").Value.ToString(), dgvExchangeRate.CurrentRow.Cells("currency").Value.ToString(), txtRate.Text) Then

            '    If cls.FncEdit(dgvExchangeRate.CurrentRow.Cells("exid").Value.ToString(), txtRate.Text) Then
            '        Dim exid As String = dgvExchangeRate.CurrentRow.Cells("exid").ToString()
            '        loadDGV()
            '        loadCombo()
            '        Dim Idrow As Integer
            '        If Me.dgvExchangeRate.Rows.Count > 0 Then
            '            For Idrow = 0 To Me.dgvExchangeRate.Rows.Count - 1
            '                If GFncNoNullString(dgvExchangeRate.Item("exid", Idrow).Value) = exid Then
            '                    dgvExchangeRate.Rows(Idrow).Selected = True
            '                    dgvExchangeRate_SelectionChanged(Nothing, System.EventArgs.Empty)
            '                    setValue(Idrow)
            '                    Exit For
            '                End If
            '            Next
            '        End If
            '    End If
            'Else
            '    GSubShowInfo("Record already existed")
            '    Return
            'End If
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable
        dt = cls.FncSearch(CStr(GFncNoNullString(Me.cmbType.Text)), dtpTradeDate.Value)
        dgvExchangeRate.DataSource = dt
    End Sub

    Private Sub dgvExchangeRate_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvExchangeRate.DataSourceChanged
        selectChanged()
    End Sub
End Class
