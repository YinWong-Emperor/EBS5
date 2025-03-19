Public Class FrmImportFuturesComm

    Dim cls As New ClsImportFuturesComm

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim nyear As String = ""
        Dim nmonth As String = ""
        Dim smonth As String = ""

        nyear = Me.nudYear.Value.ToString
        nmonth = Me.nudMonth.Value.ToString
        If (nmonth.Length = 1) Then
            nmonth = "0" & nmonth
        End If
        smonth = lFncGetMonthString(Me.nudMonth.Value)

        If (GSubShowYNConfirm(smonth & nyear & GFncGetSysMsg(32)) = Windows.Forms.DialogResult.No) Then
            Return
        End If

        If (cls.lFncTradeDateImported(nyear, nmonth) = True) Then
            If (GSubShowYNConfirm(smonth & nyear & GFncGetSysMsg(33) & GFncGetSysMsg(6)) = Windows.Forms.DialogResult.No) Then
                Return
            End If
        End If

        cls.lFncUpdateDataFromG2B(nyear, nmonth, smonth)
        GSubShowInfo(GFncGetSysMsg(8))

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmImportFuturesComm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim lastmonth As Date = DateAdd(DateInterval.Month, -1, Now)

        Me.nudYear.Value = Year(lastmonth)
        Me.nudMonth.Value = Month(lastmonth)

    End Sub

End Class
