Public Class FrmRptExternalAC

    Private gCls As New clsRptExternalAC
    Private gRpt As CrystalDecisions.CrystalReports.Engine.ReportClass = New rptExternalAC
    Private gFrm As New FrmRptDisplay

    Private Sub FrmRptExternalAC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbPreview.Checked = True
        lsubShowProcessing(False)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        lsubShowProcessing(True)
        Application.DoEvents()

        Dim PrintDialog1 As New PrintDialog
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.rbPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                lsubShowProcessing(False)
                Exit Sub
            End If
        End If

        Application.DoEvents()

        Dim lcDt As DataTable = gCls.GenReport()

        gRpt.SetDataSource(lcDt)
        gRpt.SetParameterValue("paraPrintUser", GStrloginID)
        gRpt.SetParameterValue("paraTitle", "")

        If rbPreview.Checked = True Then
            gFrm.GSubDisplayRpt(gRpt)
        ElseIf rbPrint.Checked = True Then
            GFncPrintRpt(gRpt, strPrinterName)
        ElseIf rbExport.Checked = True Then
            Dim lcPath As String = ""
            If lsubHandleSaveDialog(lcPath) = True Then
                If gCls.ExportToExcel(lcDt, lcPath) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            End If
        End If

        lsubShowProcessing(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Function lsubHandleSaveDialog(ByRef outPath As String) As Boolean
        Dim MyFileSave As New System.Windows.Forms.SaveFileDialog
        Dim bExOccured As Boolean
        Dim retVal As DialogResult


        Try
            ' does not add an extension to a file name if the user omits the extension
            MyFileSave.AddExtension = True
            MyFileSave.Filter = "Excel Files (*.xls)|*.xls"

            retVal = MyFileSave.ShowDialog()
            If retVal = Windows.Forms.DialogResult.OK Then

                If MyFileSave.CheckPathExists = True Then
                    outPath = MyFileSave.FileName
                    Return True
                Else
                    GSubShowInfo(GFncGetSysMsg(9))
                End If
            End If

            'Me.btnOK.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            bExOccured = True
            lsubShowProcessing(False)
            Windows.Forms.Cursor.Current = Cursors.Default

            ' Me.btnOK.Visible = False
        End Try

        Return False

    End Function

End Class
