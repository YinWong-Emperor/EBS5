Public Class frmFutureProductMaster

    Dim cls As New ClsFutureProductMaster
    Private peFormStatus As EnumFormStatus
    Private pbIsGridSelected As Boolean

    ' model
    Dim currentID As Integer
    Dim currentCounterParty As String
    Dim currentProductCode As String
    Dim currentProductName As String
    Dim currentIsOption As Boolean
    Dim currentStrikeDecPla As Integer
    Dim currentPriceDecPla As Integer
    Dim currentContractSize As Integer


    Private Sub frmFutureProductMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCmb()
        btnSearch_Click(Nothing, System.EventArgs.Empty)
        SetStatus(EnumFormStatus.Search)
    End Sub

    Private Sub LoadCmb()
        Dim counterParties() As String = {"ADM", "MAREX", "Newedge"}

        Me.cmbSEProductType.Items.Clear()
        Me.cmbECounterParty.Items.Clear()
        Me.cmbSECounterParty.Items.Clear()
        Me.cmbSEProductType.Items.Add("")
        Me.cmbSECounterParty.Items.Add("")

        ' Counter Party
        For Each value As String In counterParties
            Me.cmbECounterParty.Items.Add(GFncNoNullString(value))
            Me.cmbSECounterParty.Items.Add(GFncNoNullString(value))
        Next

        Me.cmbSEProductType.Items.Add("Futures")
        Me.cmbSEProductType.Items.Add("Options")

    End Sub
    Private Sub SetStatus(ByVal status As EnumFormStatus)
        peFormStatus = status

        ' …Ë÷√À—À˜◊¥Ã¨
        cmbECounterParty.Enabled = status = EnumFormStatus.New
        txtEProductCode.Enabled = status = EnumFormStatus.New
        chkEIsOption.Enabled = status = EnumFormStatus.New
        nudEContractSize.Enabled = status = EnumFormStatus.Edit Or status = EnumFormStatus.New
        nudEPriceDecPla.Enabled = status = EnumFormStatus.Edit Or status = EnumFormStatus.New
        txtEProductName.Enabled = status = EnumFormStatus.Edit Or status = EnumFormStatus.New
        nudEStrikeDecPla.Enabled = status = EnumFormStatus.Edit Or status = EnumFormStatus.New

        ' …Ë÷√±‡º≠◊¥Ã¨
        cmbSECounterParty.Enabled = status = EnumFormStatus.Search
        cmbSEProductType.Enabled = status = EnumFormStatus.Search
        txtSEProductCode.Enabled = status = EnumFormStatus.Search
        txtSEProductName.Enabled = status = EnumFormStatus.Search
        btnSearch.Enabled = status = EnumFormStatus.Search
        dgvFutureProdcuts.Enabled = status = EnumFormStatus.Search

        ' …Ë÷√∞¥≈•◊¥Ã¨
        Me.btnNew.Enabled = status = EnumFormStatus.Search
        Me.btnEdit.Enabled = status = EnumFormStatus.Search And pbIsGridSelected
        Me.btnDelete.Enabled = status = EnumFormStatus.Search And pbIsGridSelected
        Me.btnCancel.Enabled = status = EnumFormStatus.Search Or status = EnumFormStatus.New Or status = EnumFormStatus.Edit
        Me.btnSave.Enabled = status = EnumFormStatus.New Or status = EnumFormStatus.Edit

    End Sub

    Private Function GetDgvSelectedString(ByVal columnName As String) As String
        Return GFncNoNullString(Me.dgvFutureProdcuts.CurrentRow.Cells(columnName).Value).Trim
    End Function

    Private Function GetDgvSelectedValue(ByVal columnName As String) As Decimal
        Return GFncNoNullValue(GetDgvSelectedString(columnName))
    End Function

    Private Function GetDgvRowStringByIndex(ByVal index As Integer, ByVal columnName As String) As String
        Return GFncNoNullString(Me.dgvFutureProdcuts.Rows(index).Cells(columnName).Value).Trim
    End Function

    Private Function GetDgvRowValueByIndex(ByVal index As Integer, ByVal columnName As String) As Decimal
        Return GFncNoNullValue(GetDgvRowStringByIndex(index, columnName))
    End Function

    Private Function formatDecimalShow(ByVal number As Decimal) As String
        Return Format(number, "#0.##########")
    End Function

    Private Sub dgvFutureProduct_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFutureProdcuts.SelectionChanged
        SelectChanged()
    End Sub


    Private Sub SelectChanged()
        pbIsGridSelected = Not Me.dgvFutureProdcuts.CurrentRow Is Nothing

        If (pbIsGridSelected) Then
            Try
                currentID = GetDgvSelectedValue("ID")
                currentCounterParty = GetDgvSelectedString("CounterParty")
                currentProductCode = GetDgvSelectedString("ProductCode")
                currentProductName = GetDgvSelectedString("ProductName")
                currentIsOption = GetDgvSelectedString("IsOption")
                currentStrikeDecPla = GetDgvSelectedValue("StrikeDecPla")
                currentPriceDecPla = GetDgvSelectedValue("PriceDecPla")
                currentContractSize = GetDgvSelectedValue("ContractSize")

                Me.cmbECounterParty.Text = currentCounterParty
                Me.txtEProductCode.Text = currentProductCode
                Me.txtEProductName.Text = currentProductName
                Me.chkEIsOption.Checked = currentIsOption
                Me.nudEStrikeDecPla.Text = formatDecimalShow(currentStrikeDecPla)
                Me.nudEPriceDecPla.Text = formatDecimalShow(currentPriceDecPla)
                Me.nudEContractSize.Text = formatDecimalShow(currentContractSize)

            Catch ex As Exception
                GSubWriteErrLog(ex.Message, "", False)
                SetEditDefaultValue()
            End Try
        Else
            SetStatus(EnumFormStatus.Search)
            SetEditDefaultValue()
        End If
        SetStatus(EnumFormStatus.Search)
    End Sub

    Private Sub SetEditDefaultValue()
        Me.cmbECounterParty.Text = Me.cmbECounterParty.Items(0)
        Me.txtEProductCode.Text = ""
        Me.txtEProductName.Text = ""
        Me.chkEIsOption.Checked = False
        Me.nudEStrikeDecPla.Value = Me.nudEStrikeDecPla.Minimum
        Me.nudEPriceDecPla.Value = Me.nudEPriceDecPla.Minimum
        Me.nudEContractSize.Value = Me.nudEContractSize.Minimum
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetStatus(EnumFormStatus.Loading)

        Dim dt As DataTable = cls.FncSearch(
            Me.cmbSECounterParty.Text.Trim,
            IIf(Me.cmbSEProductType.Text = "", Nothing, Me.cmbSEProductType.Text = "Options"),
            Me.txtSEProductCode.Text.Trim,
            Me.txtSEProductName.Text.Trim)

        Me.dgvFutureProdcuts.DataSource = dt

        SetStatus(EnumFormStatus.Search)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            SetStatus(EnumFormStatus.Search)
            dgvFutureProduct_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        SetEditDefaultValue()
        SetStatus(EnumFormStatus.New)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetStatus(EnumFormStatus.Edit)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        SetStatus(EnumFormStatus.Loading)

        If GSubShowYNConfirm("Confirm to Delete?") = Windows.Forms.DialogResult.Yes Then
            If cls.FncDelete(currentID) Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                dgvFutureProduct_SelectionChanged(Nothing, System.EventArgs.Empty)
                GSubShowInfo("Deleted successfully")
            End If
        End If
        SetStatus(EnumFormStatus.Search)
    End Sub

    Private Sub TrySelectRow(ByVal counterParty As String, ByVal productCode As String, ByVal isOption As Boolean)
        For i As Integer = 0 To Me.dgvFutureProdcuts.Rows.Count - 1
            If GetDgvRowStringByIndex(i, "CounterParty") = counterParty And
            GetDgvRowStringByIndex(i, "ProductCode") = productCode And
            GetDgvRowStringByIndex(i, "IsOption") = isOption Then
                Me.dgvFutureProdcuts.Rows(i).Cells("CounterParty").Selected = True
                dgvFutureProduct_SelectionChanged(Nothing, System.EventArgs.Empty)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Me.cmbECounterParty.Text.Trim = "" Then
            GSubShowWarn("CounterParty can not be empty")
            Me.cmbECounterParty.Focus()
            Return
        End If
        If Me.txtEProductCode.Text.Trim = "" Then
            GSubShowWarn("Product Code can not be empty")
            Me.txtEProductCode.Focus()
            Return
        End If
        If Me.txtEProductName.Text.Trim = "" Then
            GSubShowWarn("Product Name can not be empty")
            Me.txtEProductName.Focus()
            Return
        End If
        If Me.nudEPriceDecPla.Text.Trim = "" Then
            GSubShowWarn("Price Decimal Places can not be empty")
            Me.nudEPriceDecPla.Focus()
            Return
        End If
        If Me.nudEStrikeDecPla.Text.Trim = "" Then
            GSubShowWarn("Strike Decimal Places can not be empty")
            Me.nudEStrikeDecPla.Focus()
            Return
        End If
        If Me.nudEContractSize.Text.Trim = "" Then
            GSubShowWarn("Contract Size can not be empty")
            Me.nudEContractSize.Focus()
            Return
        End If
        If Me.nudEContractSize.Value = 0 Then
            GSubShowWarn("Contract Size can not be zero")
            Me.nudEContractSize.Focus()
            Return
        End If

        Dim vID As Integer = currentID
        Dim vCounterParty As String = Me.cmbECounterParty.Text.Trim
        Dim vProductCode As String = Me.txtEProductCode.Text.Trim
        Dim vProductName As String = Me.txtEProductName.Text.Trim
        Dim vIsOption As Boolean = Me.chkEIsOption.Checked
        Dim vPriceDecPla As Integer = Me.nudEPriceDecPla.Text.Trim
        Dim vStrikeDecPla As Integer = Me.nudEStrikeDecPla.Text.Trim
        Dim vContractSize As Integer = Me.nudEContractSize.Text.Trim


        If peFormStatus = EnumFormStatus.New Then
            SetStatus(EnumFormStatus.Loading)

            If cls.FncInsert(
                            vCounterParty,
                            vProductCode,
                            vProductName,
                            vIsOption,
                            vStrikeDecPla,
                            vPriceDecPla,
                            vContractSize) Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                TrySelectRow(vCounterParty, vProductCode, vIsOption)
                SetStatus(EnumFormStatus.Search)
                GSubShowInfo("Insert successfully")
            Else
                SetStatus(EnumFormStatus.New)
                Return
            End If
        ElseIf peFormStatus = EnumFormStatus.Edit Then
            SetStatus(EnumFormStatus.Loading)

            If cls.FncUpdate(
                            vID,
                            vCounterParty,
                            vProductCode,
                            vProductName,
                            vIsOption,
                            vStrikeDecPla,
                            vPriceDecPla,
                            vContractSize) Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                TrySelectRow(vCounterParty, vProductCode, vIsOption)
                SetStatus(EnumFormStatus.Search)
                GSubShowInfo("Update successfully")
            Else
                SetStatus(EnumFormStatus.Edit)
                Return
            End If
        End If
    End Sub

    Private Sub dgvFutureProdcuts_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvFutureProdcuts.DataSourceChanged
        SelectChanged()
    End Sub

End Class
