Public Class FrmTopComm

    Dim cls As New ClsTopComm
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay


    Private Sub FrmTopComm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.nudFromYr.Value = GDteTradeDate.AddMonths(-1).Year
        Me.nudToYr.Value = GDteTradeDate.Year
        Me.nudFromMonth.Value = GDteTradeDate.AddMonths(-1).Month
        Me.nudToMonth.Value = GDteTradeDate.Month

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim fromDate As Date
        Dim toDate As Date

        If (IsNumeric(Me.nudFromYr.Value) = False) _
            Or (IsNumeric(Me.nudFromMonth.Value) = False) _
            Or (IsNumeric(Me.nudToYr.Value) = False) _
            Or (IsNumeric(Me.nudToMonth.Value) = False) Then
            GSubShowInfo(GFncGetSysMsg(3))
            Me.nudTopMost.Focus()
            Return
        End If

        fromDate = New Date(Me.nudFromYr.Value, Me.nudFromMonth.Value, 1)
        toDate = New Date(Me.nudToYr.Value, Me.nudToMonth.Value + 1, 1)
        toDate = DateAdd(DateInterval.Day, -1, toDate)

        If (fromDate > toDate) Then
            GSubShowInfo(GFncGetSysMsg(3))
            Return
        End If


        If (Me.RBStock.Checked) Then
            If Me.RBCash.Checked Then
                rpt = cls.lFncTopComm(Me.nudTopMost.Value, fromDate, toDate, "Cash")
                frm.GSubDisplayRpt(rpt)
            Else
                rpt = cls.lFncTopComm(Me.nudTopMost.Value, fromDate, toDate, "Margin")
                frm.GSubDisplayRpt(rpt)
            End If
        Else
            rpt = cls.lFncTopCommF(Me.nudTopMost.Value, fromDate, toDate)
            frm.GSubDisplayRpt(rpt)
        End If

    End Sub

End Class
