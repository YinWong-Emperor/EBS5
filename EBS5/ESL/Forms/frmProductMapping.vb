Public Class frmProductMapping

    Dim cls As New clsProductMapping
    Dim action As String = ""
    Private piIsOption As Integer
    Private psG2BFCode As String
    Private psNewedgeCode As String
    Private psCounterParty As String


    Private Sub frmProductMapping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCmb()
        btnSearch_Click(Nothing, System.EventArgs.Empty)
        setBtn(True)
    End Sub

    Private Sub LoadCmb()
        Dim dt As DataTable = cls.FncLoadProduct()
        Me.cmbSECode.Items.Clear()
        Me.cmbECode.Items.Clear()
        Me.cmbSECode.Items.Add("")
        Me.cmbECode.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbSECode.Items.Add(GFncNoNullString(dr("d_code")).Trim)
            Me.cmbECode.Items.Add(GFncNoNullString(dr("d_code")).Trim)
        Next
        dt = Nothing
        dt = cls.FncLoadNewedge()
        Me.cmbNName.Items.Clear()
        Me.cmbNName.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbNName.Items.Add(GFncNoNullString(dr("product")).Trim)
        Next
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.Items.Clear()
        Me.cbxSECounterParty.Items.Clear()
        Me.cbxSECounterParty.Items.Add("")
        dt = clsFR.GetCounterParty()
        For Each dr As DataRow In dt.Rows
            Me.cbxCounterParty.Items.Add(dr("misc_desc"))
            Me.cbxSECounterParty.Items.Add(dr("misc_desc"))
        Next

    End Sub

    Private Sub setBtn(ByVal flag As Boolean)
        Me.btnSearch.Enabled = flag
        Me.btnNew.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.cmbSECode.Enabled = flag
        Me.txtSEName.Enabled = flag
        Me.txtSNName.Enabled = flag
        Me.cmbECode.Enabled = Not flag
        Me.txtEName.Enabled = Not flag
        Me.cmbNName.Enabled = Not flag
        Me.dgvMapping.Enabled = flag
        Me.cbxCounterParty.Enabled = Not flag
        Me.cbxSECounterParty.Enabled = flag
        Me.chkIsOption.Enabled = Not flag
    End Sub

    Private Sub dgvMapping_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMapping.SelectionChanged
        Try
            Me.cmbECode.Text = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("d_code").Value).Trim
            psG2BFCode = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("d_code").Value).Trim
            Me.txtEName.Text = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("d_desc").Value).Trim
            Me.cmbNName.Text = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("d_newedge_code").Value).Trim
            psNewedgeCode = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("d_newedge_code").Value).Trim
            Me.cbxCounterParty.Text = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("counterparty").Value).Trim
            psCounterParty = GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("counterparty").Value).Trim
            If GFncNoNullString(Me.dgvMapping.CurrentRow.Cells("d_isoption").Value).Trim() = "No" Then
                Me.chkIsOption.Checked = False
                piIsOption = 0
            Else
                Me.chkIsOption.Checked = True
                piIsOption = 1
            End If


        Catch ex As Exception
            Me.cmbECode.Text = ""
            Me.txtEName.Text = ""
            Me.cmbNName.Text = ""
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable = cls.FncSearch(Me.cmbSECode.Text.Trim, Me.txtSEName.Text.Trim, _
                Me.txtSNName.Text.Trim, Me.cbxSECounterParty.Text.Trim)
        Me.dgvMapping.DataSource = dt
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            setBtn(True)
            action = ""
            dgvMapping_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        action = "A"
        setBtn(False)
        Me.cmbECode.Text = ""
        Me.txtEName.Text = ""
        Me.cmbNName.Text = ""
        Me.chkIsOption.Checked = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        action = "M"
        setBtn(False)
        Me.cmbECode.Enabled = False
        Me.cbxCounterParty.Enabled = False

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        setBtn(False)
        Me.cmbECode.Enabled = False
        Me.cmbNName.Enabled = False
        Me.txtEName.Enabled = False
        Me.cbxCounterParty.Enabled = False

        Dim op = MessageBox.Show("Confirm to Delete?", "", MessageBoxButtons.YesNo)
        If op = Windows.Forms.DialogResult.Yes Then
            If cls.FncDelete(Me.cmbECode.Text.Trim, Me.cbxCounterParty.Text.Trim, piIsOption) Then
                LoadCmb()
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                dgvMapping_SelectionChanged(Nothing, System.EventArgs.Empty)
                GSubShowInfo("Deleted successfully")
            Else
                MessageBox.Show("Delete Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        setBtn(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.cmbECode.Text.Trim = "" Then
            MessageBox.Show("G2BF Product Code can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbECode.Focus()
            Return
        End If
        If Me.cmbNName.Text.Trim = "" Then
            MessageBox.Show("Product Name can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbNName.Focus()
            Return
        End If
        If Me.cbxCounterParty.Text.Trim = "" Then
            MessageBox.Show("Party can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbNName.Focus()
            Return
        End If
        setBtn(True)
        Dim eCode As String = Me.cmbECode.Text.Trim
        Dim nName As String = Me.cmbNName.Text.Trim
        Dim CounterParty As String = Me.cbxCounterParty.Text.Trim
        Dim iIsOption As Integer = Me.chkIsOption.CheckState
        If Not ((psG2BFCode = eCode And psNewedgeCode = nName And psCounterParty = CounterParty And piIsOption = iIsOption) And action = "M") Then

            If cls.FncCheckExistNName(nName, eCode, action, CounterParty, iIsOption) Then
                MessageBox.Show("Existing Product Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                setBtn(False)
                Me.cmbNName.Focus()
                Return
            End If
        End If


        If action = "A" Then
            If cls.FncCheckExistEcode(eCode, CounterParty, iIsOption) Then
                MessageBox.Show("Existing G2BF Product Code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                setBtn(False)
                Me.cmbECode.Focus()
                Return
            End If
            If cls.FncInsert(eCode, Me.txtEName.Text.Trim, nName, CounterParty, iIsOption) Then
                LoadCmb()
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                For i As Integer = 0 To Me.dgvMapping.Rows.Count - 1
                    If GFncNoNullString(Me.dgvMapping.Rows(i).Cells("d_code").Value).Trim = eCode Then
                        Me.dgvMapping.Rows(i).Cells("d_code").Selected = True
                        dgvMapping_SelectionChanged(Nothing, System.EventArgs.Empty)
                        GSubShowInfo("Insert successfully")
                        Exit For
                    End If
                Next
            Else
                MessageBox.Show("Insertion Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                setBtn(False)
                Return
            End If
        ElseIf action = "M" Then
            If cls.FncUpdate(eCode, Me.txtEName.Text.Trim, nName, CounterParty, iIsOption, piIsOption) Then
                LoadCmb()
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                For i As Integer = 0 To Me.dgvMapping.Rows.Count - 1
                    If GFncNoNullString(Me.dgvMapping.Rows(i).Cells("d_code").Value).Trim = eCode And _
                        GFncNoNullString(Me.dgvMapping.Rows(i).Cells("counterparty").Value).Trim = CounterParty Then
                        Me.dgvMapping.Rows(i).Cells("d_code").Selected = True
                        dgvMapping_SelectionChanged(Nothing, System.EventArgs.Empty)
                        GSubShowInfo("Update successfully")
                        Exit For
                    End If
                Next
            Else
                MessageBox.Show("Update Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                setBtn(False)
                Return
            End If
        End If
        action = ""
    End Sub
End Class
