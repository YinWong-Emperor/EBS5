Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO



Public Class FrmRptStockMonitor


    Public cls As New clsRptStockMonitor
    Public dtTrans As DataTable
    Public dtTrans2 As DataTable
    Public dtStock As DataTable
    Public dtHSI As DataTable
    Public dtClient As DataTable


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If Me.txtPath.Text = "" Then
            MessageBox.Show("Please input the file path! ")
            Return
        End If

        Dim rpt As ReportClass = New rptStockMonitor
        Dim strStartDay As String
        strStartDay = dtpStartDate.Value.Date
        Dim strEndDay As String
        strEndDay = dtpEnddate.Value.Date
        If IsNothing(dtStock) Then
            dtStock = cls.lfncGetLotsInfo()
        End If
        If IsNothing(dtHSI) Then
            dtHSI = cls.lfncGetHSI
        End If
        If IsNothing(dtClient) Then
            dtClient = cls.lfncGetName
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)

        'start_date,end_date,id,name,no,txdate
        Dim dt As DataTable = New DtsRptStockMonitor.dtsRptStockMonitorDataTable()

        cls.lfncCreateTable(dtTrans)
        For lint As Int16 = 0 To Me.LBfile.Items.Count - 1
            cls.lFncGetfile(Me.LBfile.Items(lint).ToString, "15:57:00", dtHSI, dtClient, dtStock, dtTrans, Val(Me.txtLot.Text))
        Next
        cls.lfncCreateTable2(dtTrans2)
        For lint As Int16 = 0 To Me.LBfile.Items.Count - 1
            cls.lFncGetfile2(Me.LBfile.Items(lint).ToString, "15:57:00", dtHSI, dtClient, dtStock, dtTrans2, Val(Me.txtLot.Text))
        Next

        Dim ldtTmp As DataTable = cls.lsubFindResult(dtTrans, Val(Me.txtDays.Text))
        If MyCheckBox1.Checked Then
            For Each ldrTmp As DataRow In ldtTmp.Rows
                For Each ldr As DataRow In dtTrans.Rows
                    If ldr("client_id") = ldrTmp("client_id") And ldr("stock_no") = ldrTmp("stock_no") Then
                        Dim ldte As String = ldr("input_date").substring(6, 4) & "-" & _
                          ldr("input_date").substring(3, 2) & "-" & _
                          ldr("input_date").substring(0, 2) & _
                           " " & ldr("input_time")
                        dt.Rows.Add(New Object() {strStartDay, strEndDay, ldr("client_id"), ldr("client_name"), _
                            GFncNoNullString(ldr("stock")), ldte, ldr("QTY"), ldr("LOT"), ldr("Price"), ldr("BS"), ldr("Handler"), ldr("match")})
                    End If
                Next
            Next
        Else

            For Each ldrTmp As DataRow In ldtTmp.Rows
                For Each ldr As DataRow In dtTrans2.Rows
                    If ldr("client_id") = ldrTmp("client_id") And ldr("stock_no") = ldrTmp("stock_no") Then
                        Dim ldte As String = ldr("input_date").substring(6, 4) & "-" & _
                          ldr("input_date").substring(3, 2) & "-" & _
                          ldr("input_date").substring(0, 2) & _
                           " " & ldr("input_time")
                        dt.Rows.Add(New Object() {strStartDay, strEndDay, ldr("client_id"), ldr("client_name"), _
                            GFncNoNullString(ldr("stock")), ldte, ldr("QTY"), ldr("LOT"), ldr("Price"), ldr("BS"), ldr("Handler"), ldr("match")})
                    End If

                Next
            Next
        End If
        dt = cls.lfncSort(dt)

        'dt.Rows.Add(New Object() {strStartDay, strEndDay, "1", "test", 10, strEndDay})
        'dt.Rows.Add(New Object() {strStartDay, strEndDay, "2", "test", 10, strEndDay})
        'dt.Rows.Add(New Object() {strStartDay, strEndDay, 3, "test", 10, strEndDay})

        rpt.SetDataSource(dt)

        rpt.SetParameterValue("paraPrintUser", Trim(GStrloginID))
        If MyCheckBox1.Checked = True Then
            rpt.SetParameterValue("paraShowMatch", "Show Match Results Only")
        Else
            rpt.SetParameterValue("paraShowMatch", "")
        End If
        rpt.SetParameterValue("paraTitle", " From " & Me.dtpStartDate.Value & " To " & Me.dtpEndDate.Value & " (Same client Same stock for " & Me.txtLot.Text & " lots in " & Me.txtDays.Text & " days! (Exclude stock of HSI) ) ")

        Dim frm As New FrmRptDisplay
        frm.GSubDisplayRpt(rpt)

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)

    End Sub
    Private Sub lsubSetFile()

        Me.LBfile.Items.Clear()
        If Me.txtPath.Text <> "" Then
            Dim lArrFiles As String() = Directory.GetFiles(Me.txtPath.Text)
            If lArrFiles.Length > 0 Then
                For lint As Int16 = 0 To lArrFiles.Length - 1
                    lArrFiles(lint) = lArrFiles(lint).Trim
                    If lArrFiles(lint).Substring(lArrFiles(lint).Length - 4) = ".csv" Then
                        Dim lstrFileName As String = ""
                        lstrFileName = lArrFiles(lint).Substring(lArrFiles(lint).LastIndexOfAny("\") + 1, _
                                    lArrFiles(lint).Length - lArrFiles(lint).LastIndexOfAny("\") - 1)
                        If lstrFileName.Length < 8 Then
                            Continue For
                        End If
                        If Not IsNumeric(lstrFileName.Substring(0, 8)) Then
                            Continue For
                        End If
                        Try
                            Dim lDte As Date = lstrFileName.Substring(6, 2) & _
                                                      "/" & lstrFileName.Substring(4, 2) & "/" & lstrFileName.Substring(0, 4)
                            If lDte >= Me.dtpStartDate.Value And lDte <= Me.dtpEndDate.Value Then
                                Me.LBfile.Items.Add(lArrFiles(lint))
                            End If
                        Catch ex As Exception

                        End Try
                    End If

                Next
            End If
        End If

    End Sub
    Private Sub btn_file_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_file.Click
        Me.FolderBrowserDialog1.ShowDialog()
        Me.txtPath.Text = Me.FolderBrowserDialog1.SelectedPath.ToString
        lsubSetFile()
    End Sub

    Private Sub FrmRptStockMonitor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtStock = cls.lfncGetLotsInfo()
        dtHSI = cls.lfncGetHSI
        dtClient = cls.lfncGetName
        lsubShowProcessing(False)
        Me.dtpEndDate.Value = GDteTradeDate
        Me.dtpStartDate.Value = GDteTradeDate
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub dtpEndDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.TextChanged
        lsubSetFile()
    End Sub

    Private Sub dtpStartDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.TextChanged
        lsubSetFile()
    End Sub

    Private Sub txtLot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLot.TextChanged

    End Sub
End Class
