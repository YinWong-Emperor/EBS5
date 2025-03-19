Public Class frmRptNotOptedOutEmailList

    Private cls As New clsRptNotOptedOutClientListEmailOnly

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim orderBy As String = ""
        Dim targetDB1 As String = ""
        Dim targetDB2 As String = ""
        Dim strExFile As String = "NotOptedOutEmailList"

        targetDB1 = GStrG2BFPRODDB
        targetDB2 = GStrG2BSPRODDB
        strExFile = "NotOptedOutEmailList.csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportNotOptedOutClientList(strExFile, targetDB1, targetDB2) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub
End Class
