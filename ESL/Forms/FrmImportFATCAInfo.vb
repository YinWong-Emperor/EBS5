Imports modCommon

Public Class FrmImportFATCAInfo
    Dim cls As New ClsImportFATCAInfo

    Private Sub btnLoadExcel_Click(sender As Object, e As EventArgs) Handles btnLoadExcel.Click
        cls.dtFatcaType = cls.FncGetValidFatcaType()
        cls.dtClientType = cls.FncGetValidClientType()
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim filename As String = ""
        Dim dt As DataTable = New DataTable
        Dim Tradedate As DateTime = cls.lFncTradeDateFromDB()
        Dim isImported As Boolean = False
        Try
            openFileDialog1.Filter = "Excel (*.xlsx, *.xls) |*.xlsx; *.xls"
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                filename = openFileDialog1.FileName
                If (GSubShowYNConfirm("FATCA Info " & GFncGetFormatedDate(Tradedate, modGlobal.SystemDateFormat) & GFncGetSysMsg(32))) = Windows.Forms.DialogResult.Yes Then

                    isImported = cls.lFncTradeDateImported(Tradedate)

                    dt = cls.lFncGetFATCAInfoFromExcel(filename)
                    If (dt.Rows.Count > 0) Then
                        cls.lFncUploadData(dt, Tradedate, isImported)
                        GSubShowInfo(GFncGetSysMsg(8))
                    End If
                End If
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class