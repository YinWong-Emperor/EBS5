Imports System.IO



Public Class FrmPPS
    Dim MHDT As New DataTable
    Dim RHDT As New DataTable
    Dim RTDT As New DataTable
    Dim D1DT As New DataTable
    Dim MTDT As New DataTable


    Private Sub InitMHDT(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Record_id"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Value_date"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "merchant_number"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Filler"
        DT.Columns.Add(Column)

    End Sub

    Private Sub InitRHDT(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Record_id"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Value_date"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "pos_id"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Filler"
        DT.Columns.Add(Column)


    End Sub
    Private Sub InitD1DT(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Record_id"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "isn"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "input_day"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "input_time"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "transaction_code"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "transaction_status"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "transaction_amount"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "bill_account"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "bill_type"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "input_date"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "reserved"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "serial_number"
        DT.Columns.Add(Column)


    End Sub
    Private Sub InitRTDT(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Record_id"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "start_input"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "end_input"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "debit_count"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "debit_amount"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "pps_payment"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "pps_cancellation"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Filler"
        DT.Columns.Add(Column)

    End Sub
    
    Private Sub InitMTDT(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Record_id"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "terminal_count"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "debit_count"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "debit_amount"
        DT.Columns.Add(Column)


        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "pps_payment"
        DT.Columns.Add(Column)


        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "pps_cancellation"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Filler"
        DT.Columns.Add(Column)

    End Sub



    Private Function exportExcel(ByVal depth As Integer, ByVal ldtMH As DataTable, ByVal ldtRH As DataTable, _
                                ByVal ldtRT As DataTable, ByVal ldtD1 As DataTable, ByVal ldtMT As DataTable, _
                                ByVal fileName As String) As Boolean
        Dim startRow As Integer = 2
        Dim save_ok As Boolean = False
        'Dim myStream As IO.Stream = Nothing
        'Dim openFileDialog1 As New OpenFileDialog()


        ''openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory()
        'openFileDialog1.InitialDirectory = Me.txtPath.Text
        ''openFileDialog1.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*"
        'openFileDialog1.FilterIndex = 1
        'openFileDialog1.RestoreDirectory = True

        'If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        '    Try
        '        Me.txtPath.Text = openFileDialog1.InitialDirectory()
        '        'Me.txtPath.Text = openFileDialog1.FileName()
        '        'Diagnostics.Process.Start(file)
        '    Catch Ex As Exception
        '        'GSubShowInfo(GFncGetSysMsg(55))
        '    Finally
        '        ' Check this again, since we need to make sure we didn't throw an exception on open.
        '        If (myStream IsNot Nothing) Then
        '            myStream.Close()
        '        End If
        '    End Try
        'End If

        If Me.txtPath.Text.Length > 0 Then
            Me.btnImport.Enabled = True
        Else
            Me.btnImport.Enabled = False
        End If

        Dim file_type As String = ""

        If ldtMH.Rows.Count > 0 Then
            If ldtMH.Rows(0).Item("merchant_number") = "400009813" Then
                file_type = "EFL"

            End If
            If ldtMH.Rows(0).Item("merchant_number") = "400009815" Then
                file_type = "ESL"
            End If

        End If

        Dim strExDir As String = fileName.Substring(0, fileName.LastIndexOf("\") + 1)
        Dim strExFile As String = fileName.Substring(fileName.LastIndexOf("\") + 1, fileName.Length - fileName.LastIndexOf("\") - 1) & file_type & dtos(Me.fdate.Value)
        Dim strFiles() As String

        Dim xlApp As Object = Nothing
        Dim xlWorkBook As Object = Nothing
        Dim xlWorkSheet As Object = Nothing
        Dim xlRange As Object = Nothing
        Dim xlRangeBorder As Object = Nothing
        Dim root_id As String = ""
        'Dim root_president As String = ""
        Dim GTotal(20) As String
        Dim total_lot As Decimal = 0
        Dim sub_total_row As Integer = 0
        Dim total_comm As Decimal = 0


        Try



            strFiles = System.IO.Directory.GetFiles(strExDir, strExFile)
            For Each strFile As String In strFiles
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next

            xlApp = CreateObject("Excel.Application")
            xlWorkBook = xlApp.Workbooks.Add()
            xlWorkBook.Activate()
            xlApp.Visible = False
            'xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
            xlWorkSheet = xlWorkBook.Worksheets(1)

            Dim sub_total_start As Integer = startRow

            xlWorkSheet.Cells(1, 1) = "ValueDate"
            xlWorkSheet.Cells(1, 2) = "T Code"
            xlWorkSheet.Cells(1, 3) = "Account No"
            xlWorkSheet.Cells(1, 4) = "Ccy"
            xlWorkSheet.Cells(1, 5) = "Amount"
            xlWorkSheet.Cells(1, 6) = "Chq Cash"
            xlWorkSheet.Cells(1, 7) = "Chq Date"
            xlWorkSheet.Cells(1, 8) = "Chq No"
            xlWorkSheet.Cells(1, 9) = "Description"

            Dim i As Integer = 0
            'clearArray(GTotal)

            For i = 0 To ldtD1.Rows.Count - 1
                Application.DoEvents()


                Dim columnName As String = ""
                Dim column_letter As String = ""


                'xlWorkSheet.Cells(startRow, 1) = ldtD1.Rows(i).Item("input_date")
                xlWorkSheet.Cells(startRow, 1) = Me.fdate.Value.Date
                If file_type = "ESL" Then
                    If ldtD1.Rows(i).Item("bill_account").ToString.Trim.Substring(0, 1) = "0" Then
                        xlWorkSheet.Cells(startRow, 2) = "UCM"
                    End If
                    If ldtD1.Rows(i).Item("bill_account").ToString.Trim.Substring(0, 1) = "8" Then
                        xlWorkSheet.Cells(startRow, 2) = "UCC"
                    End If
                End If
                If file_type = "EFL" Then
                    xlWorkSheet.Cells(startRow, 2) = ""
                End If
                If ldtD1.Rows(i).Item("bill_account").ToString.Length > 0 Then
                    xlWorkSheet.Cells(startRow, 3) = "'" & GFncNoNullString(ldtD1.Rows(i).Item("bill_account")).ToString.Substring(0, 8)
                Else
                    xlWorkSheet.Cells(startRow, 3) = ""
                End If
                Dim tmp_h As Integer = 0
                Dim tmp_d As String = 0
                Dim tmp_hd As Double = 0
                If ldtD1.Rows(i).Item("transaction_amount").ToString.Length > 0 Then
                    tmp_h = Val(ldtD1.Rows(i).Item("transaction_amount").ToString.Substring(0, 6))
                    tmp_d = ldtD1.Rows(i).Item("transaction_amount").ToString.Substring(6, 2)
                    tmp_hd = Val(tmp_h & "." & tmp_d)
                Else
                    tmp_hd = 0
                End If
                xlWorkSheet.Cells(startRow, 5) = tmp_hd
                xlWorkSheet.Cells(startRow, 4) = "HKD"
                xlWorkSheet.Cells(startRow, 6) = "Cash"
                xlWorkSheet.Cells(startRow, 9) = "CASH TRFR DEPOSIT - PPS PAYMENT" & vbLf & "現金轉帳存款 - 繳費靈"

                startRow += 1


            Next

            xlWorkBook.SaveAs(strExDir & strExFile)
            xlWorkBook.Close()
            xlApp.Quit()

            GC.Collect()
            GC.WaitForPendingFinalizers()

            GSubShowInfo(GFncGetSysMsg(28) & " - file save at c:\itas\")
            Return True


        Catch ex As Exception
            GSubShowInfo(GFncGetSysMsg(29) & " - " & ex.Message)
            Try
                xlWorkBook.close()
            Catch ex1 As Exception

            End Try
            Try
                xlApp.Quit()
            Catch ex1 As Exception

            End Try
            GC.Collect()
            If save_ok = True Then
                GSubWriteErrLog(ex.Message)
            Else

            End If

        End Try

        Return False
    End Function


    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click
        Dim myStream As IO.Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory()
        openFileDialog1.InitialDirectory = Me.txtPath.Text
        openFileDialog1.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Me.txtPath.Text = openFileDialog1.FileName()
                'Diagnostics.Process.Start(file)
            Catch Ex As Exception
                'GSubShowInfo(GFncGetSysMsg(55))
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
        If Me.txtPath.Text.Length > 0 Then
            Me.btnImport.Enabled = True
        Else
            Me.btnImport.Enabled = False
        End If
    End Sub
    Function dtos(ByVal fdate As Date) As String

        Dim y As String = ""
        Dim m As String = ""
        Dim d As String = ""
        Dim ymd As String = ""
        y = Year(fdate).ToString
        m = "00" & Month(fdate).ToString
        m = m.Substring(m.Length - 2, 2)
        d = "00" & fdate.Day.ToString
        d = d.Substring(d.Length - 2, 2)
        ymd = y & m & d
        Return ymd
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmPPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitMHDT(MHDT)
        InitRHDT(RHDT)
        InitRTDT(RTDT)
        InitD1DT(D1DT)
        InitMTDT(MTDT)
        Me.btnPath.Focus()
    End Sub


    Private Sub txtPath_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Leave
        If Me.txtPath.Text.Length > 0 Then
            Me.btnImport.Enabled = True
        Else
            Me.btnImport.Enabled = False
        End If
    End Sub

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If GSubShowYNConfirm(GFncGetSysMsg(82)) = Windows.Forms.DialogResult.Yes Then
            MHDT.Clear()
            RHDT.Clear()
            RTDT.Clear()
            D1DT.Clear()
            MTDT.Clear()


            Dim strDBTYPE As String = ""
            Dim strDBNAME As String = ""
            Dim strDBPATH As String = ""
            Dim strDBIP As String = ""
            Dim strDBUSR As String = ""
            Dim strDBPWD As String = ""
            Dim sReaderPath As StreamReader = Nothing
            Dim strRealPath As String = ""
            Dim sReader As StreamReader = Nothing
            Dim strTemp As String = ""


            sReaderPath = New StreamReader(Me.txtPath.Text.Trim)
            If Not sReaderPath.EndOfStream Then
                'strRealPath = sReaderPath.ReadLine
                'Do While Not sReader.EndOfStream
                Do While Not sReaderPath.EndOfStream
                    'strTemp = sReader.ReadLine()
                    strTemp = sReaderPath.ReadLine
                    'If strTemp = "" Or strTemp.Length <= 0 Then

                    'Else
                    Dim record_id As String = ""
                    Dim value_date As String = ""
                    Dim merchant_number As String = ""
                    Dim filler As String = ""
                    Dim pos_id As String = ""
                    Dim start_input As String = ""
                    Dim end_input As String = ""
                    Dim debit_count As String = ""
                    Dim debit_amount As String = ""
                    Dim pps_payment As String = ""
                    Dim pps_cancellation As String = ""
                    Dim ISN As String = ""
                    Dim input_day As String = ""
                    Dim input_time As String = ""
                    Dim transaction_code As String = ""
                    Dim transaction_status As String = ""
                    Dim bill_account As String = ""
                    Dim bill_type As String = ""
                    Dim input_date As String = ""
                    Dim transaction_amount As String = ""
                    Dim reserved As String = ""
                    Dim serial_number As String = ""
                    Dim terminal_count As String = ""
                    Dim check_account As String = ""
                    If strTemp.Substring(0, 2) = "MH" Then
                        record_id = strTemp.Substring(0, 2)
                        value_date = strTemp.Substring(2, 8)
                        merchant_number = strTemp.Substring(10, 9)
                        filler = strTemp.Substring(19, 60)

                        Dim ldrMH As DataRow = MHDT.NewRow
                        ldrMH("Record_id") = record_id
                        ldrMH("value_date") = value_date
                        ldrMH("merchant_number") = merchant_number
                        ldrMH("filler") = filler
                        MHDT.Rows.Add(ldrMH)
                    End If
                    If strTemp.Substring(0, 2) = "RH" Then
                        record_id = strTemp.Substring(0, 2)
                        value_date = strTemp.Substring(2, 8)
                        pos_id = strTemp.Substring(10, 15)
                        filler = strTemp.Substring(25, 54)

                        Dim ldrRH As DataRow = RHDT.NewRow
                        ldrRH("Record_id") = record_id
                        ldrRH("Value_date") = value_date
                        ldrRH("pos_id") = pos_id
                        ldrRH("filler") = filler
                        RHDT.Rows.Add(ldrRH)
                    End If

                    If strTemp.Substring(0, 2) = "RT" Then

                        record_id = strTemp.Substring(0, 2)
                        start_input = strTemp.Substring(2, 6)
                        end_input = strTemp.Substring(8, 6)
                        debit_count = strTemp.Substring(14, 6)
                        debit_amount = strTemp.Substring(20, 11)
                        pps_payment = strTemp.Substring(31, 6)
                        pps_cancellation = strTemp.Substring(37, 6)
                        filler = strTemp.Substring(43, 36)

                        Dim ldrRT As DataRow = RTDT.NewRow
                        ldrRT("Record_id") = record_id
                        ldrRT("start_input") = start_input
                        ldrRT("end_input") = end_input
                        ldrRT("debit_count") = debit_count
                        ldrRT("debit_amount") = debit_amount
                        ldrRT("pps_payment") = pps_payment
                        ldrRT("pps_cancellation") = pps_cancellation
                        ldrRT("filler") = filler

                        RTDT.Rows.Add(ldrRT)
                    End If

                    If strTemp.Substring(0, 2) = "D1" Then

                        record_id = strTemp.Substring(0, 2)
                        ISN = strTemp.Substring(2, 6)
                        input_day = strTemp.Substring(8, 2)
                        input_time = strTemp.Substring(10, 4)
                        transaction_code = strTemp.Substring(14, 4)
                        transaction_status = strTemp.Substring(18, 1)
                        transaction_amount = strTemp.Substring(19, 8)
                        bill_account = strTemp.Substring(27, 25)
                        check_account = bill_account.Substring(0, 8)
                        bill_type = strTemp.Substring(52, 2)
                        input_date = strTemp.Substring(54, 8)
                        reserved = strTemp.Substring(62, 11)
                        serial_number = strTemp.Substring(73, 6)


                        Dim checkdigit As Integer
                        Dim odddigit As Integer
                        Dim evendigit As Integer
                        Dim accnolength As Integer = 8

                        If (check_account.Length <= 0 Or check_account.Length > accnolength) Then
                            GSubShowInfo(GFncGetSysMsg(16))
                            Return
                        Else
                            If (check_account.Length < accnolength) Then
                                Dim i As Integer

                                i = check_account.Length
                                Do Until i = accnolength
                                    check_account = "0" & check_account
                                    i = i + 1
                                Loop
                            End If
                        End If

                        odddigit = CInt(Mid(check_account, 1, 1)) + CInt(Mid(check_account, 3, 1)) + _
                                        CInt(Mid(check_account, 5, 1)) + CInt(Mid(check_account, 7, 1))
                        evendigit = CInt(Mid(check_account, 2, 1)) + CInt(Mid(check_account, 4, 1)) + _
                                        CInt(Mid(check_account, 6, 1)) + CInt(Mid(check_account, 8, 1))
                        checkdigit = (odddigit * 3) + evendigit
                        checkdigit = checkdigit Mod 10
                        checkdigit = 10 - checkdigit
                        checkdigit = checkdigit Mod 10

                        If Val(bill_account.Substring(8, 1)) = checkdigit Then

                        Else
                            GSubShowInfo("Account : " & bill_account.Trim & " - Check digit error!")
                        End If
                        ' Me.txtCheckDigit.Text = checkdigit


                        Dim ldrD1 As DataRow = D1DT.NewRow
                        ldrD1("Record_id") = record_id
                        ldrD1("ISN") = ISN
                        ldrD1("input_day") = input_day
                        ldrD1("input_time") = input_time
                        ldrD1("transaction_code") = transaction_code
                        ldrD1("transaction_status") = transaction_status
                        ldrD1("transaction_amount") = transaction_amount
                        ldrD1("bill_account") = bill_account
                        ldrD1("bill_type") = bill_type
                        ldrD1("input_date") = input_date
                        ldrD1("reserved") = reserved
                        ldrD1("serial_number") = serial_number
                        D1DT.Rows.Add(ldrD1)

                    End If


                    If strTemp.Substring(0, 2) = "MT" Then
                        record_id = strTemp.Substring(0, 2)
                        terminal_count = strTemp.Substring(2, 3)
                        debit_count = strTemp.Substring(5, 6)
                        debit_amount = strTemp.Substring(11, 11)
                        pps_payment = strTemp.Substring(22, 6)
                        pps_cancellation = strTemp.Substring(28, 6)
                        filler = strTemp.Substring(34, 45)

                        Dim ldrMT As DataRow = MTDT.NewRow
                        ldrMT("Record_id") = record_id
                        ldrMT("terminal_count") = terminal_count
                        ldrMT("debit_count") = debit_count
                        ldrMT("debit_amount") = debit_amount
                        ldrMT("pps_payment") = pps_payment
                        ldrMT("pps_cancellation") = pps_cancellation
                        ldrMT("filler") = filler
                        MTDT.Rows.Add(ldrMT)
                        Exit Do
                    End If
                    ' End If
                Loop

                sReaderPath.Close()
            End If
            If D1DT.Select().Length > 0 Then
                Me.txtnorecord.Text = D1DT.Select().Length
                GSubShowInfo("Import Successfully!")
            Else
                Me.txtnorecord.Text = 0
                Dim ldrD1 As DataRow = D1DT.NewRow
                ldrD1("input_date") = System.DateTime.Today.ToString("dd/MMM/yyyy")
                D1DT.Rows.Add(ldrD1)
                GSubShowInfo("Import Successfully! - No Record")
            End If
            Me.DataGridView1.DataSource = D1DT


            If MHDT.Rows.Count > 0 Then

                Me.txtValue_date.Text = MHDT.Rows(0).Item("value_date")
                Me.txtMerchant_number.Text = MHDT.Rows(0).Item("merchant_number")
            Else

                Me.txtValue_date.Text = ""
                Me.txtMerchant_number.Text = ""
            End If
            If Me.DataGridView1.RowCount > 0 Then
                Me.btnExport.Enabled = True
            Else
                Me.btnExport.Enabled = False
            End If
        End If
        
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes Then
            If exportExcel(1, MHDT, RHDT, RTDT, D1DT, MTDT, "c:\itas\AFEImport") = True Then

            Else

            End If

        End If
    End Sub
End Class
