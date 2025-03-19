Public Class frmRptLargeCashDepositLog

    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim cls As New clsRptLargeCashDepositLog

    Private Sub lsubEnableForm(ByVal bEnable As Boolean, Optional ByVal radOption As Boolean = True)
        Me.btnCancel.Visible = bEnable
        Me.btnPrint.Visible = bEnable
        Me.DTPFrom.Enabled = bEnable
        Me.DTPTo.Enabled = bEnable
        Me.cmbCurrency.Enabled = bEnable
        Me.amtAmount.Enabled = Not radOption
        Me.amtMax.Enabled = radOption
        Me.amtMin.Enabled = radOption
    End Sub


    Private Sub frmRptLargeCashDepositLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFrom.Value = GDteTradeDate
        Me.DTPTo.Value = GDteTradeDate

        Dim dt As DataTable = cls.lfncGetCurrency().Tables(0)
        dt.Rows.Add("<<ALL>>")
        Me.cmbCurrency.DataSource = dt
        Me.cmbCurrency.ValueMember = "name_s"
        'Me.cmbCurrency.Items.Insert(0, "<<ALL>>")

        Me.radRange.Checked = True
        lsubEnableForm(True)
        lsubShowProcessing(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        Me.pbarProcess.Visible = blnShow
        Me.lblProcess.Visible = blnShow
    End Sub
    Private Function isInputValid() As Boolean



        If radRange.Checked = True Then
            If GFncNoNullString(Me.amtMin.Text) = "" Then
                Me.amtMin.Text = "0.00"
            End If

            If GFncNoNullString(Me.amtMax.Text) = "" Then
                Me.amtMax.Text = "0.00"
            End If

            If GFncNoNullString(Me.amtMin.Text).Replace(",", "") = "0.00" AndAlso GFncNoNullString(Me.amtMax.Text).Replace(",", "") = "0.00" Then
                Return True
            End If

            If GFncNoNullString(Me.amtMin.Text).Replace(",", "").StartsWith("-") Then
                GSubShowWarn("No negative amount is allowed!")
                Me.amtMin.Focus()
                Return False
            End If

            If GFncNoNullString(Me.amtMax.Text).Replace(",", "").StartsWith("-") Then
                GSubShowWarn("No negative amount is allowed!")
                Me.amtMax.Focus()
                Return False
            End If

            If Val(GFncNoNullString(Me.amtMin.Text).Replace(",", "")) > Val(GFncNoNullString(Me.amtMax.Text).Replace(",", "")) Then
                GSubShowWarn("Min. amount should NOT larger than Max. amount!")
                Me.amtMin.Focus()
                Return False
            End If

            'If GFncNoNullString(Me.amtMax.Text).Replace(",", "") = "0.00" OrElse GFncNoNullString(Me.amtMax.Text).Replace(",", "").StartsWith("-") Then
            '    GSubShowWarn("No negative amount is allowed!")
            '    Me.amtMin.Focus()
            '    Return False
            'End If

            'If GFncNoNullString(Me.amtMin.Text) = "" OrElse GFncNoNullString(Me.amtMax.Text) = "" _
            'OrElse GFncNoNullString(Me.amtMin.Text) = "0.00" OrElse GFncNoNullString(Me.amtMax.Text) = "0.00" Then
            '    Return False
            'End If
        End If

        If radPoint.Checked = True Then
            If GFncNoNullString(Me.amtAmount.Text) = "" Then
                Me.amtAmount.Text = "0.00"
            End If
        End If

        Return True
    End Function

    Private Sub handlePrint()
        Dim ldecMax As Decimal = 0
        Dim ldecMin As Decimal = 0

        If radRange.Checked = True Then
            ldecMax = GFncNoNullValue(Me.amtMax.Text.Trim)
            ldecMin = GFncNoNullValue(Me.amtMin.Text.Trim)
        Else
            ldecMin = GFncNoNullValue(Me.amtAmount.Text.Trim)
        End If
        rpt = cls.genReport(Me.DTPFrom.Value, Me.DTPTo.Value, Me.cmbCurrency.Text.Trim, ldecMin, ldecMax)

        frm.GSubDisplayRpt(rpt)
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If isInputValid() Then
            lsubShowProcessing(True)
            Application.DoEvents()
            lsubEnableForm(False)
            handlePrint()
            lsubShowProcessing(False)
            lsubEnableForm(True, radRange.Checked)
        End If
    End Sub

    Private Sub lsubEnableRadOptions(ByVal bEnabled As Boolean)
        Me.amtMin.Enabled = bEnabled
        Me.amtMax.Enabled = bEnabled
        Me.amtAmount.Enabled = Not bEnabled
        Me.amtAmount.Text = ""
        Me.amtMin.Text = ""
        Me.amtMax.Text = ""
    End Sub

    Private Sub radRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRange.CheckedChanged
        lsubEnableRadOptions(radRange.Checked)
    End Sub
End Class
