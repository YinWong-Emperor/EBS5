Public Class FrmCommScheme

    Dim cls As New ClsCommScheme

    Private Sub FrmCommScheme_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        Dim lstrMonth As String = GfncGetMonth()
        Dim year As Integer = Val(lstrMonth.Substring(0, 4))
        Dim month As Integer = Val(lstrMonth.Substring(4, 2))
        For i As Integer = year - 5 To year + 5
            Me.cboYearFrom.Items.Add(i)
            Me.cboYearTo.Items.Add(i)
        Next
        For i As Integer = 1 To 12
            Me.cboMonthFrom.Items.Add(i)
            Me.cboMonthTo.Items.Add(i)
        Next
        Dim ldteDate As Date = Convert.ToDateTime(lstrMonth.Substring(0, 4) & "/" & lstrMonth.Substring(4, 2) & "/01")
        Me.cboYearFrom.Text = lstrMonth.Substring(0, 4)
        Me.cboMonthFrom.Text = Val(Format(ldteDate, "MM"))
        Me.cboYearTo.Text = Format(ldteDate.AddMonths(1), "yyyy")
        Me.cboMonthTo.Text = Val(Format(ldteDate.AddMonths(1), "MM"))
        'Me.cboYearFrom.Text = Format(ldteDate.AddMonths(-1), "yyyy")
        'Me.cboMonthFrom.Text = Val(Format(ldteDate.AddMonths(-1), "MM"))
        'Me.cboYearTo.Text = year
        'Me.cboMonthTo.Text = month
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Dim dateTO As String = ""
        dateTO = Me.cboYearTo.Text & Format(Val(Me.cboMonthTo.Text), "00")
        If (GSubShowYNConfirm(dateTO & GFncGetSysMsg(32), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If GFncCheckCommStatus() Then
                Return
            End If
            cls.lFncCopyScheme(Me.cboYearFrom.Text & Format(CInt(Me.cboMonthFrom.Text), "00"), Me.cboYearTo.Text & Format(CInt(Me.cboMonthTo.Text), "00"))
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
