Public Class FrmRptFutPL

    Dim cls As New ClsRptFutPL

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Me.dpEndRptDate.Value.Date >= Now().Date) Then
            GSubShowInfo(GFncGetSysMsg(97))
            Me.dpEndRptDate.Focus()
            Return
        End If
        lsubShowProcessing(True)
        lsubShowButton(False)
        Me.dpEndRptDate.Enabled = False
        Dim ldtClient As DataTable = cls.lFncGetClientPL(Me.dpEndRptDate.Value)
        ExportExcel(ldtClient)
        lsubShowProcessing(False)
        lsubShowButton(True)
        Me.dpEndRptDate.Enabled = True
        GSubShowInfo(GFncGetSysMsg(28))
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        Me.pbarProcess.Visible = blnShow
        Me.lblProcess.Visible = blnShow
    End Sub

    Private Sub lsubShowButton(ByVal blnShow As Boolean)
        Me.btnSave.Visible = blnShow
        Me.btnCancel.Visible = blnShow
    End Sub

    Private Sub ExportExcel(ByVal ldt As DataTable)
        Dim FileName As String = "FuturesPL"
        Dim strFiles() As String
        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim xlWorkSheet As Object

        xlApp = CreateObject("Excel.Application")
        xlWorkBook = xlApp.Workbooks.Add()
        xlWorkSheet = xlWorkBook.Worksheets(1)

        Try
            strFiles = System.IO.Directory.GetFiles(GStrExptDir, FileName & ".xls")
            For Each strFile As String In strFiles
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next
            xlWorkSheet.Cells(1, 1) = "A/C"
            xlWorkSheet.Cells(1, 2) = "A/C Name"
            xlWorkSheet.Cells(1, 3) = "AE"
            xlWorkSheet.Cells(1, 4) = "AE Name"
            xlWorkSheet.Cells(1, 5) = "w1_Profit_Loss_comm"
            xlWorkSheet.Cells(1, 6) = "w2_Profit_Loss_comm"
            xlWorkSheet.Cells(1, 7) = "w3_Profit_Loss_comm"
            xlWorkSheet.Cells(1, 8) = "w4_Profit_Loss_comm"
            xlWorkSheet.Cells(1, 9) = "w5_Profit_Loss_comm"
            xlWorkSheet.Cells(1, 10) = "Total"
            xlWorkSheet.Cells(1, 12) = "w1_floating"
            xlWorkSheet.Cells(1, 13) = "w2_floating"
            xlWorkSheet.Cells(1, 14) = "w3_floating"
            xlWorkSheet.Cells(1, 15) = "w4_floating"
            xlWorkSheet.Cells(1, 16) = "w5_floating"
            xlWorkSheet.Cells(1, 18) = "w1_profit_loss"
            xlWorkSheet.Cells(1, 19) = "w2_profit_loss"
            xlWorkSheet.Cells(1, 20) = "w3_profit_loss"
            xlWorkSheet.Cells(1, 21) = "w4_profit_loss"
            xlWorkSheet.Cells(1, 22) = "w5_profit_loss"
            xlWorkSheet.Cells(1, 23) = "Total"
            xlWorkSheet.Cells(1, 25) = "w1_comm"
            xlWorkSheet.Cells(1, 26) = "w2_comm"
            xlWorkSheet.Cells(1, 27) = "w3_comm"
            xlWorkSheet.Cells(1, 28) = "w4_comm"
            xlWorkSheet.Cells(1, 29) = "w5_comm"
            xlWorkSheet.Cells(1, 30) = "Total"

            Dim ldr As DataRow() = ldt.Select(" 1=1 ", " pl_comm_total asc ")
            For i As Integer = 0 To ldr.Length - 1
                xlWorkSheet.Cells(i + 2, 1) = ldr(i).Item("accno")
                xlWorkSheet.Cells(i + 2, 2) = ldr(i).Item("accname")
                xlWorkSheet.Cells(i + 2, 3) = ldr(i).Item("aeno")
                xlWorkSheet.Cells(i + 2, 4) = ldr(i).Item("aename")
                xlWorkSheet.Cells(i + 2, 5) = ldr(i).Item("pl_comm_w1")
                xlWorkSheet.Cells(i + 2, 6) = ldr(i).Item("pl_comm_w2")
                xlWorkSheet.Cells(i + 2, 7) = ldr(i).Item("pl_comm_w3")
                xlWorkSheet.Cells(i + 2, 8) = ldr(i).Item("pl_comm_w4")
                xlWorkSheet.Cells(i + 2, 9) = ldr(i).Item("pl_comm_w5")
                xlWorkSheet.Cells(i + 2, 10) = ldr(i).Item("pl_comm_total")
                xlWorkSheet.Cells(i + 2, 12) = ldr(i).Item("floating_w1")
                xlWorkSheet.Cells(i + 2, 13) = ldr(i).Item("floating_w2")
                xlWorkSheet.Cells(i + 2, 14) = ldr(i).Item("floating_w3")
                xlWorkSheet.Cells(i + 2, 15) = ldr(i).Item("floating_w4")
                xlWorkSheet.Cells(i + 2, 16) = ldr(i).Item("floating_w5")
                xlWorkSheet.Cells(i + 2, 18) = ldr(i).Item("pl_w1")
                xlWorkSheet.Cells(i + 2, 19) = ldr(i).Item("pl_w2")
                xlWorkSheet.Cells(i + 2, 20) = ldr(i).Item("pl_w3")
                xlWorkSheet.Cells(i + 2, 21) = ldr(i).Item("pl_w4")
                xlWorkSheet.Cells(i + 2, 22) = ldr(i).Item("pl_w5")
                xlWorkSheet.Cells(i + 2, 23) = ldr(i).Item("pl_w1") + ldr(i).Item("pl_w2") + ldr(i).Item("pl_w3") _
                                             + ldr(i).Item("pl_w4") + ldr(i).Item("pl_w5")
                xlWorkSheet.Cells(i + 2, 25) = ldr(i).Item("comm_w1")
                xlWorkSheet.Cells(i + 2, 26) = ldr(i).Item("comm_w2")
                xlWorkSheet.Cells(i + 2, 27) = ldr(i).Item("comm_w3")
                xlWorkSheet.Cells(i + 2, 28) = ldr(i).Item("comm_w4")
                xlWorkSheet.Cells(i + 2, 29) = ldr(i).Item("comm_w5")
                xlWorkSheet.Cells(i + 2, 30) = ldr(i).Item("comm_w1") + ldr(i).Item("comm_w2") _
                                             + ldr(i).Item("comm_w3") + ldr(i).Item("comm_w4") _
                                             + ldr(i).Item("comm_w5")
            Next

            xlWorkBook.SaveAs(GStrExptDir & FileName & ".xls")
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            GC.Collect()
        Catch ex As Exception
            xlWorkBook.close()
            xlApp.Quit()
            GC.Collect()

            GSubShowInfo(GFncGetSysMsg(89))
        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub FrmRptFutPL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lsubShowProcessing(False)
        lsubShowButton(True)
        Me.dpEndRptDate.Enabled = True
        Me.dpEndRptDate.Value = DateAdd(DateInterval.Day, -1, Now)
    End Sub

End Class
