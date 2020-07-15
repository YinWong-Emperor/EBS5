Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class FrmCIESPerformanceLetter
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim valid As Boolean = True
        Dim people1, call1, people2, call2 As String
        people1 = ""
        people2 = ""
        call1 = ""
        call2 = ""

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If Me.rbtPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        Application.DoEvents()

        If GFncNoNullString(Me.phone1.Text) = "" Or GFncNoNullString(Me.ppl1.Text) = "" Then
            GSubShowWarn("At least one contact should be entered!")
            valid = False
        End If

        If AllDigits(Me.phone1.Text) And AllDigits(Me.phone2.Text) Then
            call1 = GFncNoNullString(Me.phone1.Text)
            call2 = GFncNoNullString(Me.phone2.Text)
        Else
            GSubShowWarn("Phone number should contain digits only")
            valid = False
        End If

        If AllLetters(Me.ppl1.Text) And AllLetters(Me.ppl2.Text) Then
            people1 = GFncNoNullString(Me.ppl1.Text)
            people2 = GFncNoNullString(Me.ppl2.Text)
        Else
            GSubShowWarn("Name should contain letters only")
            valid = False
        End If



        If valid Then
            rpt = FncGenReport(Me.txtClientCode.Text, Me.dtpTrade.Value, people1, call1, people2, call2)

            If rbtPreview.Checked = True Then
                frm.GSubDisplayRpt(rpt)
            ElseIf rbtPrint.Checked = True Then
                GFncPrintRpt(rpt, strPrinterName)
            End If
            Windows.Forms.Cursor.Current = Cursors.Default
        End If

    End Sub

    Public Function FncGenReport(ByVal clientCode As String, ByVal FM_TradeDate As Date, ByVal ppl1 As String, ByVal phone1 As String, ByVal ppl2 As String, ByVal phone2 As String)

        Dim rpt As New rptCIESPerformanceLetter
        Dim query As String
        Dim nameDT As DataTable
        Dim PerformanceDT As DataTable

        query = "select * from CIES_performance_detail where clt_code = '" & clientCode & "' and Trade_Date = '" & Format(DateAdd("yyyy", +1, FM_TradeDate), "yyyy/MM/dd") & "'"
        PerformanceDT = GFncRtnDS(GSCnLiqConn, query).Tables(0)

        query = "select CLT_NAME from STCLTMASTER where clt_code = '" & clientCode & "'"
        nameDT = GFncRtnDS(GSCnLiqConn, query).Tables(0)

        rpt.SetDataSource(PerformanceDT)
        rpt.SetParameterValue("ppl1", ppl1)
        rpt.SetParameterValue("phone1", phone1)
        rpt.SetParameterValue("ppl2", ppl2)
        rpt.SetParameterValue("phone2", phone2)
        rpt.SetParameterValue("ClientName", nameDT.Rows(0).Item("CLT_NAME"))
        Return rpt
    End Function

    Private Function AllDigits(ByVal txt As String) As Boolean
        Dim ch As String
        Dim i As Integer

        AllDigits = True
        For i = 1 To Len(txt)
            ' See if the next character is a non-digit.
            ch = Mid$(txt, i, 1)
            If ch < "0" Or ch > "9" Then
                ' This is not a digit.
                AllDigits = False
                Exit For
            End If
        Next i
    End Function

    Private Function AllLetters(ByVal txt As String) As Boolean
        Dim ch As String
        Dim i As Integer

        AllLetters = True
        txt = UCase$(txt)
        For i = 1 To Len(txt)
            ' See if the next character is a non-digit.
            ch = Mid$(txt, i, 1)
            If ch < "A" Or ch > "Z" Then
                ' This is not a letter.
                AllLetters = False
                Exit For
            End If
        Next i
    End Function

End Class
