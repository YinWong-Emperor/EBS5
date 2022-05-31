Public Class FrmFatcaAccMaster

    Dim cls As New ClsFatcaAccMaster
    Private _dataset As DataSet

    Private Sub frmFatcaAccMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        lFnEnableEdit(False)
    End Sub

    Private Sub lFnEnableEdit(ByVal bool As Boolean)
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnSearch.Click

        Me.btnSearch.Enabled = False

        _dataset = Nothing
        Me.dgvAccMaster.DataSource = Nothing
        Me.dgvAccMaster.Refresh()

        _dataset = cls.lFnSearchAccMaster(txtSearchAccNo.Text.Trim, _
                                        txtSearchAccName.Text.Trim, _
                                        txtSearchBRID.Text.Trim, _
                                        txtSearchCCDRef.Text.Trim, _
                                        txtSearchPersonID.Text.Trim)

        If _dataset IsNot Nothing Then
            Me.dgvAccMaster.AutoGenerateColumns = False
            Me.dgvAccMaster.VirtualMode = True
            Me.dgvAccMaster.AllowUserToDeleteRows = False
            Me.dgvAccMaster.DataSource = _dataset
            Me.dgvAccMaster.DataMember = "cltMaster"
            Me.dgvAccMaster.Refresh()
        End If

        Me.btnSearch.Enabled = True
    End Sub
    Private Sub dgvAccMaster_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvAccMaster.CellDoubleClick

        With FrmFatcaIJAccProfile
            If _dataset IsNot Nothing Then
                Dim selectRowsIdx As Integer
                selectRowsIdx = dgvAccMaster.SelectedRows(0).Index
                .SetAccNo(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("Account_No")))
                .SetAccName(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("Account_Name")))
                .SetClientType(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("client_type")))
                .SetAENo(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("AE_No")))
                .SetBranchName(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("Branch")))
                .SetClientNature(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("Client_Nature")))
                .SetPersonID(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("PersonID")))
                .SetCCDRef(GetCol(Me._dataset.Tables(0).Rows(selectRowsIdx).Item("CCD_REF")))
            End If

            .tcFatcaIJAccProfileMain.SelectedIndex = 0
            .MdiParent = Me.MdiParent
            .Activate()
            .Show()

        End With
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function GetCol(ByVal argValue As System.Object) As String
        GetCol = IIf(Not IsDBNull(argValue), argValue.ToString, String.Empty)
    End Function


    Private Sub dgvAccMaster_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvAccMaster.CellContentClick

    End Sub

    Private Sub txtSearchCCDRef_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCCDRef.KeyUp
        InvokecCDRefInputValidation()
    End Sub

    Private Sub txtSearchCCDRef_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtSearchCCDRef.PreviewKeyDown
        InvokecCDRefInputValidation()
    End Sub
    Private Sub InvokecCDRefInputValidation()
        Dim checkCCDRefTextField As String
        checkCCDRefTextField = txtSearchCCDRef.Text.Trim

        Dim temp As Integer

        If Not String.IsNullOrEmpty(checkCCDRefTextField) And _
           Not Int32.TryParse(checkCCDRefTextField, temp) Then
            MsgBox("CCD Ref does not accept characters", MsgBoxStyle.OkOnly)
            txtSearchCCDRef.Text = String.Empty
        End If
    End Sub
End Class