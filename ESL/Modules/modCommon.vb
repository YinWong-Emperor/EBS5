Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Net.Mail
Imports System.Globalization

Public Module modCommon

#Region "UI"
    'set textbox readonly backcolor and forecolor
    Public Sub GSubSetReadOnlyColor(ByVal ctl As Control)
        Dim mstBox As MaskedTextBox
        Dim txtBox As TextBox
        Dim rchBox As RichTextBox

        If TypeOf ctl Is MaskedTextBox Then
            mstBox = CType(ctl, MaskedTextBox)
            If mstBox.ReadOnly Then
                mstBox.ForeColor = System.Drawing.Color.Black
                mstBox.BackColor = System.Drawing.Color.LemonChiffon
            Else
                mstBox.ForeColor = System.Drawing.SystemColors.WindowText
                mstBox.BackColor = System.Drawing.SystemColors.Window
            End If
        End If
        If TypeOf ctl Is TextBox Then
            txtBox = CType(ctl, TextBox)
            If txtBox.ReadOnly Then
                txtBox.ForeColor = System.Drawing.Color.Black
                txtBox.BackColor = System.Drawing.Color.LemonChiffon
            Else
                txtBox.ForeColor = System.Drawing.SystemColors.WindowText
                txtBox.BackColor = System.Drawing.SystemColors.Window
            End If
        End If
        If TypeOf ctl Is RichTextBox Then
            rchBox = CType(ctl, RichTextBox)
            If rchBox.ReadOnly Then
                rchBox.ForeColor = System.Drawing.Color.Black
                rchBox.BackColor = System.Drawing.Color.LemonChiffon
            Else
                rchBox.ForeColor = System.Drawing.SystemColors.WindowText
                rchBox.BackColor = System.Drawing.SystemColors.Window
            End If
        End If

        If ctl.HasChildren Then
            ' Recursively call this method for each child control.
            Dim childControl As Control
            For Each childControl In ctl.Controls
                GSubSetReadOnlyColor(childControl)
            Next childControl
        End If
    End Sub

    Public Sub GSubSetControlMoveNext(ByVal ctl As Control)
        Try
            If TypeOf ctl Is RichTextBox Or TypeOf ctl Is MaskedTextBox Or _
                    TypeOf ctl Is TextBox Or _
                    TypeOf ctl Is DateTimePicker Then
                If TypeOf ctl Is TextBox Then
                    Dim cont As TextBox
                    cont = DirectCast(ctl, TextBox)
                    If cont.Multiline = False Then
                        AddHandler ctl.KeyDown, AddressOf LSubMyCtlKeyDown
                    End If
                ElseIf TypeOf ctl Is RichTextBox Then
                    Dim cont As RichTextBox
                    cont = DirectCast(ctl, RichTextBox)
                    If cont.Multiline = False Then
                        AddHandler ctl.KeyDown, AddressOf LSubMyCtlKeyDown
                    End If
                ElseIf TypeOf ctl Is MaskedTextBox Then
                    Dim cont As MaskedTextBox
                    cont = DirectCast(ctl, MaskedTextBox)
                    If cont.Multiline = False Then
                        AddHandler ctl.KeyDown, AddressOf LSubMyCtlKeyDown
                    End If
                Else
                    AddHandler ctl.KeyDown, AddressOf LSubMyCtlKeyDown
                End If
            End If

            If TypeOf ctl Is ComboBox Then
                AddHandler ctl.KeyDown, AddressOf LSubMyCboKeyDown
            End If

            If ctl.HasChildren Then
                ' Recursively call this method for each child control.
                Dim childControl As Control
                For Each childControl In ctl.Controls
                    GSubSetControlMoveNext(childControl)
                Next childControl
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LSubMyCboKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            sender.DroppedDown = Not sender.DroppedDown
        End If
        If sender.DroppedDown = False Then
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
            GSubMoveNextFld(e.KeyCode)
        End If
    End Sub

    Private Sub LSubMyCtlKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        GSubMoveNextFld(e.KeyCode)
    End Sub

    Public Sub GSubMoveNextFld(ByVal keyCode As Keys)
        If keyCode = Keys.Return Or keyCode = Keys.Enter Then
            SendKeys.Send(ChrW(Keys.Tab))
        End If
        If keyCode = Keys.Up Then
            SendKeys.Send("+" & ChrW(Keys.Tab))
        End If
    End Sub

    Public Sub GSubSetTextBoxGotFocus(ByVal ctlControl As Control)

        If TypeOf ctlControl Is RichTextBox Then
            AddHandler ctlControl.GotFocus, AddressOf LSubMyRtbGotFocus
        ElseIf TypeOf ctlControl Is TextBox Then
            AddHandler ctlControl.GotFocus, AddressOf LSubMyTbGotFocus
        ElseIf TypeOf ctlControl Is MaskedTextBox Then
            AddHandler ctlControl.GotFocus, AddressOf LSubMyMtbGotFocus
        End If
        If ctlControl.HasChildren Then
            ' Recursively call this method for each child control.
            Dim childControl As Control
            For Each childControl In ctlControl.Controls
                GSubSetTextBoxGotFocus(childControl)
            Next childControl
        End If

    End Sub

    Private Sub LSubMyRtbGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rchBox As RichTextBox = CType(sender, RichTextBox)
        rchBox.SelectAll()
    End Sub

    Private Sub LSubMyTbGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtBox As TextBox = CType(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub LSubMyMtbGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mstBox As MaskedTextBox = CType(sender, MaskedTextBox)
        mstBox.SelectAll()
    End Sub

    'Datagridview field format
    Public Sub FormatGridView(ByVal cols As System.Windows.Forms.DataGridViewColumnCollection)
        For Each col As DataGridViewColumn In cols
            If Not IsNothing(col.ValueType) Then
                Select Case col.ValueType.ToString
                    Case GetType(Integer).ToString(), GetType(Double).ToString(), GetType(Decimal).ToString()
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End Select
            End If
        Next
    End Sub

#End Region
#Region "Display Alert Message"

    Public Sub GSubShowWarn(ByVal strMsg As String)
        MessageBox.Show(strMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub GSubShowError(ByVal strMsg As String)
        MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Function GSubShowYNConfirm(ByVal strMsg As String, Optional ByVal YNDefault As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return MessageBox.Show(strMsg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, YNDefault)
    End Function

    Public Sub GSubShowInfo(ByVal strMsg As String)
        MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function GSubShowCustDelConfirm(ByVal strMsg As String, ByRef outRemark As String, Optional ByVal YNDefault As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Dim lcForm As New FrmCustDelConfirm()
        lcForm.StartPosition = FormStartPosition.CenterScreen
        lcForm.gMessage = strMsg
        lcForm.ShowDialog()
        outRemark = lcForm.gRemark
        Return lcForm.DialogResult
    End Function
#End Region
#Region "Crypto"
    ' Hash an input string and return the hash as
    ' a 32 character hexadecimal string.
    Public Function GFncGetMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function
#End Region
#Region "Retreive Database special function"
    Public Function GFncGetSysMsg(ByVal iMsgCode As Integer) As String

        Dim lstrSQL As String = ""
        Dim lscmCommand As New SqlCommand
        Dim ldtrReader As SqlDataReader
        Dim lstrMsg As String = ""

        lstrSQL = "Select * from system_messages Where sysMsgCode = " & iMsgCode & " and sysLang = '" & GStrSysLang & "' "
        lscmCommand.CommandText = lstrSQL
        lscmCommand.Connection = GSCnSqlConn
        ldtrReader = lscmCommand.ExecuteReader

        If ldtrReader.HasRows Then
            ldtrReader.Read()
            lstrMsg = ldtrReader("sysMsg")
        Else
            lstrMsg = iMsgCode
        End If
        ldtrReader.Close()
        Return lstrMsg

    End Function
    Public Function GfncGetMonth() As String
        'Dim ldtMonth As DataTable = GFncRtnDS(GSCnSqlConn, "select * from misc_master where misc_type = 'COMMMONTH' ").Tables(0)
        Dim ldtMonth As DataTable = GFncGetMiscMaster("COMMMONTH").Tables(0)
        Dim lstrMonth As String = Format(Now.Year, "0000") & Format(Now.Month, "00")
        If ldtMonth.Rows.Count > 0 Then
            lstrMonth = ldtMonth.Rows(0).Item("misc_code").ToString.Trim
        End If
        Return lstrMonth
    End Function
    Public Function GFncCheckStatus() As Boolean
        'Dim str As String = "select * from misc_master where misc_type = 'CommStatus' and misc_code = 'Locked'"
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim dt As DataTable = GFncGetMiscMaster("CommStatus", "Locked").Tables(0)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GFncCheckForm(ByVal fName As String) As Boolean
        Dim str As String = "select * from Function_Info where FIObjectCode like '" & fName & "%' and FIDesc in (" & _
            "select distinct misc_code from misc_master where misc_type = 'CommRelatedTable') "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GfncGetClientCode() As DataTable
        Dim strSQL As String = "select distinct(CLT_CODE) from STCLTMASTER order by CLT_CODE"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt
    End Function
    Public Function GFncGetG2sbRetTDate() As Date
        Dim strSQL As String = ""
        Dim dtTdate As Date
        Dim dts As New DataSet

        strSQL += " SELECT "
        strSQL += "   tradedate "
        strSQL += " FROM "
        strSQL += "   " & GStrG2BSDB & ".dbo.system_parameter "
        strSQL += " WHERE "
        strSQL += "   cmid = '366'"
        dts = GFncRtnDS(GSCnLiqConn, strSQL)

        If dts.Tables(0).Rows.Count > 0 Then
            dtTdate = dts.Tables(0).Rows(0).Item("tradedate")
        Else
            dtTdate = CDate("1900/01/01")
        End If

        dts.Dispose()
        Return dtTdate
    End Function

    Public Function GFncGetSystemStaticParam(ByVal paramType As String, ByVal paramName As String, _
                                             Optional ByVal sortBy As String = "") As DataSet
        Dim lscnCommand As SqlCommand = New SqlCommand("s_Get_SystemStaticParam", GSCnSqlConn)
        lscnCommand.CommandType = CommandType.StoredProcedure
        AddParameter(lscnCommand, "@ParamType", paramType)
        AddParameter(lscnCommand, "@ParaName", paramName)
        AddParameter(lscnCommand, "@sortBy", sortBy)
        Return GFncRtnDS(lscnCommand, "SystemStaticParam")
    End Function

    Public Function GFncGetReportParam(ByVal ReportName As String) As DataSet
        Dim ds As New DataSet
        Dim lscnCommand As SqlCommand = New SqlCommand("s_Get_ReportParam", GSCnSqlConn)
        lscnCommand.CommandType = CommandType.StoredProcedure
        AddParameter(lscnCommand, "@ReportName", ReportName)

        Return GFncRtnDS(lscnCommand, "ReportParam")

    End Function

    Public Function GFncGetMiscMaster(ByVal type As String, Optional ByVal code As String = "", Optional ByVal desc As String = "") As DataSet
        Dim ds As New DataSet
        Dim lscnCommand As SqlCommand = New SqlCommand("s_Get_MiscMaster", GSCnSqlConn)
        lscnCommand.CommandType = CommandType.StoredProcedure
        AddParameter(lscnCommand, "@type", type)
        AddParameter(lscnCommand, "@code", code)
        AddParameter(lscnCommand, "@desc", desc)

        Return GFncRtnDS(lscnCommand, "MiscMaster")

    End Function
#End Region

#Region "Write Log"
    Public Sub GSubWriteErrLog(ByVal StrMessage As String, Optional ByVal StrPath As String = "", Optional ByVal endProgram As Boolean = True)
        If StrPath = "" Then
            StrPath = GStrEPath
        End If
        Dim StmWriter As StreamWriter

        If Not System.IO.Directory.Exists(StrPath) Then
            System.IO.Directory.CreateDirectory(StrPath)
        End If
        StmWriter = File.AppendText(StrPath & "\" & Format(Now, "yyyyMM") & "Errorlog.txt")

        StmWriter.WriteLine(GStrDomainUser & " " & "Date/Time:" & Format(Now, "MM/dd/yyyy HH:mm:ss") & " - " & StrMessage)
        ' Close the writer and underlying file.
        StmWriter.Flush()
        StmWriter.Close()
        If (endProgram) Then
            GSubShowWarn("Internal System Error, System will be stopped! Please contact system administrator! " & StrMessage)
            End
        Else
            GSubShowWarn(StrMessage)
        End If

    End Sub
    Public Sub GSubWriteEventLog(ByVal StrMessage As String, ByVal StrPath As String, Optional ByVal FName As String = "")
        Dim StmWriter As StreamWriter

        If System.IO.Directory.Exists(StrPath) Then
            StmWriter = File.AppendText(StrPath & "\event" & Format(Now, "yyyyMMdd") & "log" & IIf(FName = "", "", "-" & FName) & ".txt")
        Else
            System.IO.Directory.CreateDirectory(StrPath)
            StmWriter = File.AppendText(StrPath & "\event" & Format(Now, "yyyyMMdd") & "log" & IIf(FName = "", "", "-" & FName) & ".txt")
        End If

        StmWriter.WriteLine(Format(Now, "MM/dd/yyyy HH:mm:ss, ") & GStrDomainUser & " - " & StrMessage)
        ' Close the writer and underlying file.
        StmWriter.Flush()
        StmWriter.Close()

    End Sub

    Public Function GFncFillLog(ByVal d_user As String, ByVal d_action As String, Optional ByVal d_o_tdate As Date = Nothing, _
        Optional ByVal d_type As String = "", Optional ByVal d_sno As String = "", Optional ByVal d_ano As String = "", Optional ByVal _
        d_ono As Integer = Nothing, Optional ByVal txmonth As String = Nothing, Optional ByVal d_log As String = "", Optional ByRef lstnTrans As SqlTransaction = Nothing) As Boolean
        Dim lstrSQL As String = ""
        If d_log <> "" Then
            lstrSQL = "INSERT INTO LOGTBL(D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_Oid, d_txmonth, D_LOG, D_O_TDATE) VALUES('" & _
                        d_user & "',getdate(),'" & d_action & "','" & d_type & "','" & d_sno & "','" & d_ano & "'," & d_ono & ",'" & _
                        txmonth & "', '" & d_log.Replace("'", "''") & "' "
            If d_o_tdate = Nothing Then
                lstrSQL += ", getdate())"
            Else
                lstrSQL += ", '" & Format(d_o_tdate, "yyyy/MM/dd") & "' )"
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) > 0 Then
                Return True
            Else
                Return False
            End If
        End If
        Return True
    End Function
    Public Function GfncOneFieldLog(ByVal lstrTitle As String, ByVal lstrFm As String, Optional ByVal lstrTo As String = Nothing) As String
        If IsNothing(lstrFm) Then
            lstrFm = ""
        End If
        If IsNothing(lstrTo) Then
            Return "[" & lstrTitle.Trim & "] = '" & lstrFm.Trim & "'"
        Else
            Return "[" & lstrTitle.Trim & "] = '" & lstrFm.Trim & "' To '" & lstrTo.Trim & "'"
        End If
    End Function
#End Region

#Region "Export CSV/Excel"
    Public Function GExportToExcel(ByVal strExptDir As String, ByVal strExptFilename As String, _
                            ByVal ldtsData As DataTable, ByVal strHeader As String, _
                            Optional ByVal colNedWrap As String = "") As Boolean

        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim rowCount As Integer = 2
        Dim colCount As Integer = 1
        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtcData As DataColumn

        Try
            If Not Directory.Exists(strExptDir) Then
                Directory.CreateDirectory(strExptDir)
            End If

            lstrFiles = System.IO.Directory.GetFiles(strExptDir, strExptFilename)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            xlApp = CreateObject("Excel.Application")
            xlWorkBook = xlApp.Workbooks.Add(True)

            Dim headerString As String = strHeader.Trim
            Dim val As String = ""
            colCount = 1
            Do While headerString.Length > 0
                If (InStr(headerString, ",") > 0) Then
                    val = Mid(headerString, 1, InStr(headerString, ",") - 1)
                    xlApp.cells(1, colCount).Value = val
                    headerString = Mid(headerString, InStr(headerString, ",") + 1, headerString.Length - InStr(headerString, ",")).Trim
                    colCount = colCount + 1
                Else
                    xlApp.cells(1, colCount).Value = headerString
                    headerString = ""
                End If
            Loop

            For Each ldtwData In ldtsData.Rows
                colCount = 1
                For Each ldtcData In ldtsData.Columns
                    If (ldtcData.DataType.Name = "String") Then
                        If (IsDBNull(ldtwData(ldtcData.ColumnName)) = False) Then
                            If (colNedWrap = ldtcData.ColumnName And colNedWrap <> "") Then
                                xlApp.cells(rowCount, colCount).Value = "'" & _
                                                           Trim(ldtwData(ldtcData.ColumnName))
                            Else
                                xlApp.cells(rowCount, colCount).Value = "'" & _
                                                           Trim(modCommon.GfncRemovePagingCharacters(ldtwData(ldtcData.ColumnName)))
                            End If
                        End If
                    Else
                        If (IsDBNull(ldtwData(ldtcData.ColumnName)) = False) Then
                            xlApp.cells(rowCount, colCount).Value = ldtwData(ldtcData.ColumnName)
                        End If
                    End If
                    colCount = colCount + 1
                Next
                rowCount = rowCount + 1
            Next

            xlWorkBook.SaveAs(strExptDir & strExptFilename)
            xlApp.Workbooks.Close()
            xlApp.Quit()
            xlWorkBook = Nothing
            xlApp = Nothing
            GC.Collect()

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try

    End Function

    Public Function GExportCSV(ByVal strExptDir As String, ByVal strExptFilename As String, _
                                ByVal ldtsData As DataSet, ByVal strHeader As String, ByVal bDateTimeformat As Boolean) As Boolean

        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtcData As DataColumn
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        Try
            If Not Directory.Exists(strExptDir) Then
                Directory.CreateDirectory(strExptDir)
            End If
            lstrFiles = System.IO.Directory.GetFiles(strExptDir, strExptFilename)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            'lsWriter = New StreamWriter(strExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))
            lsWriter = New StreamWriter(strExptDir & strExptFilename, False, System.Text.Encoding.UTF8)
            lstrColValue = strHeader
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()

            For Each ldtwData In ldtsData.Tables(0).Rows
                lstrColValue = ""
                For Each ldtcData In ldtsData.Tables(0).Columns
                    If (lstrColValue.Length > 0) Then
                        lstrColValue += ","
                    End If

                    If (ldtcData.DataType.Name = "String") Then
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            If ldtcData.ColumnName = "memo" Then
                                lstrColValue += "" & Trim(modCommon.GfncRemovePagingCharacters(Replace(ldtwData(ldtcData.ColumnName), ",", ";"))) & """"
                            Else
                                lstrColValue += "=""" & Trim(modCommon.GfncRemovePagingCharacters(Replace(ldtwData(ldtcData.ColumnName), ",", ";"))) & """"
                            End If

                        End If
                    ElseIf (ldtcData.DataType.Name = "DateTime") Then
                        If bDateTimeformat = True Then
                            If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                                lstrColValue += "="""""
                            Else
                                lstrColValue += Trim(ldtwData(ldtcData.ColumnName).ToString)
                            End If
                        End If

                    Else
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += Trim(CStr(ldtwData(ldtcData.ColumnName)))
                        End If
                    End If
                Next
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
            Next
            lstrColValue = ""
            lsWriter.WriteLine(lstrColValue)
            lstrColValue = "Total: " & ldtsData.Tables(0).Rows.Count & " "
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()

            lsWriter.Close()

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try

    End Function

    Public Function GExportCSV(ByVal strExptDir As String, ByVal strExptFilename As String, _
                                ByVal ldtsData As DataSet, ByVal strHeader As String, Optional ByVal sTitle As String() = Nothing, _
                                Optional ByVal encoding As String = "utf-8") As Boolean

        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtcData As DataColumn
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        Try
            If Not Directory.Exists(strExptDir) Then
                Directory.CreateDirectory(strExptDir)
            End If
            lstrFiles = System.IO.Directory.GetFiles(strExptDir, strExptFilename)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            'lsWriter = New StreamWriter(strExptDir & strExptFilename, False, System.Text.Encoding.UTF8)
            lsWriter = New StreamWriter(strExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(encoding))
            If Not (sTitle Is Nothing) Then
                If (sTitle.Length > 0) Then
                    'lstrColValue = "="" " & Date.Now & " "",="" " & sTitle & """"
                    lstrColValue = "="" " & String.Join(" "",="" ", sTitle) & """"
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()
                End If
            End If

            lstrColValue = strHeader
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()


            For Each ldtwData In ldtsData.Tables(0).Rows
                lstrColValue = ""
                For Each ldtcData In ldtsData.Tables(0).Columns
                    If (lstrColValue.Length > 0) Then
                        lstrColValue += ","
                    End If

                    If (ldtcData.DataType.Name = "String") Then
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += "=""" & Trim(GfncRemovePagingCharacters(Replace(ldtwData(ldtcData.ColumnName), ",", ";"))) & """"
                        End If
                    Else
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += Trim(CStr(ldtwData(ldtcData.ColumnName)))
                        End If
                    End If
                Next
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
            Next
            lstrColValue = ""
            lsWriter.WriteLine(lstrColValue)
            lstrColValue = "Total: "" " & ldtsData.Tables(0).Rows.Count & " """
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()

            lsWriter.Close()

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try

    End Function
#End Region

#Region "Email"
    'Public Function mySendEmail(ByVal myfrom As String, ByVal myTo As DataSet, ByVal mySub As String, ByVal myMessage As String, _
    '                            ByVal strEIP As String) As String

    '    Dim oMsg As New MailMessage
    '    Dim myCredentials As New System.Net.NetworkCredential


    '    myCredentials.UserName = ""
    '    myCredentials.Password = ""

    '    oMsg.IsBodyHtml = True

    '    Dim mySmtpsvr As New SmtpClient()
    '    mySmtpsvr.Host = strEIP
    '    mySmtpsvr.Port = 25

    '    mySmtpsvr.UseDefaultCredentials = False
    '    mySmtpsvr.Credentials = myCredentials

    '    '        Try
    '    oMsg.From = New MailAddress(myfrom, "")
    '    For i As Integer = 0 To myTo.Tables(0).Rows.Count - 1
    '        If myTo.Tables(0).Rows(i).Item(0).ToString <> "" And myTo.Tables(0).Rows(i).Item(0).ToString.IndexOf("@") > 0 Then
    '            oMsg.To.Add(myTo.Tables(0).Rows(i).Item(0).ToString)
    '        End If
    '    Next
    '    oMsg.Subject = mySub
    '    oMsg.Body = myMessage
    '    mySmtpsvr.Send(oMsg)
    '    'Catch ex As Exception
    '    '    GSubWriteError(Format(Now, "yyyy/MM/dd HH:mm:ss") & " email sender: " & ex.Message)
    '    '    Return " Send Fail ! Error: " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " email sender: " & ex.Message
    '    'End Try

    '    'Return ""

    'End Function
    Public Function mySendEmail(ByVal myfrom As String, ByVal myTo As String, ByVal mySub As String, ByVal myMessage As String, _
                            ByVal strEIP As String, Optional ByVal att As String = "") As String

        Dim oMsg As New MailMessage
        Dim myCredentials As New System.Net.NetworkCredential
        Dim arrReceiver() As String

        myCredentials.UserName = ""
        myCredentials.Password = ""
        arrReceiver = myTo.Split(",")

        oMsg.IsBodyHtml = True

        Dim mySmtpsvr As New SmtpClient()
        mySmtpsvr.Host = strEIP
        mySmtpsvr.Port = 25

        mySmtpsvr.UseDefaultCredentials = False
        mySmtpsvr.Credentials = myCredentials

        Try
            oMsg.From = New MailAddress(myfrom, "")
            For i As Integer = 0 To arrReceiver.Length - 1
                If arrReceiver(i) <> "" And arrReceiver(i).IndexOf("@") > 0 Then
                    oMsg.To.Add(arrReceiver(i))
                End If
            Next
            oMsg.Subject = mySub
            oMsg.Body = myMessage
            If att <> "" Then
                oMsg.Attachments.Add(New Attachment(att))
            End If
            mySmtpsvr.Send(oMsg)
        Catch ex As Exception
            GSubWriteErrLog(Format(Now, "yyyy/MM/dd HH:mm:ss") & " email sender: " & ex.Message)
            Return " Send Fail ! Error: " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " email sender: " & ex.Message
        End Try

        Return ""

    End Function
#End Region

#Region "Database Utilities"
    Public Function GFncReturnConnection(ByVal strConnName As String) As SqlConnection
        Dim lstrSettings As String
        Dim lscnConn As SqlConnection

        lstrSettings = ConfigurationManager.ConnectionStrings(strConnName).ToString

        lscnConn = New SqlConnection(lstrSettings)

        Return lscnConn

    End Function

    Public Function GFncSqlQuote(ByVal strSQL As String) As String
        Return Replace(strSQL, "'", "''")
    End Function

    Public Function GFncRtnDS(ByVal scnConn As SqlConnection, ByVal strSQL As String, ByVal intTimeOut As Integer) As DataSet
        Return GFncRtnDS(scnConn, strSQL, "", intTimeOut)
    End Function
    Public Function GFncRtnDS(ByVal scnConn As SqlConnection, ByVal strSQL As String, ByVal stnTrans As SqlTransaction) As DataSet
        Return GFncRtnDS(scnConn, strSQL, "", -1, stnTrans)
    End Function
    Public Function GFncRtnDS(ByVal scnConn As SqlConnection, ByVal strSQL As String, ByVal strTableName As String, ByVal stnTrans As SqlTransaction) As DataSet
        Return GFncRtnDS(scnConn, strSQL, strTableName, -1, stnTrans)
    End Function
    Public Function GFncRtnDS(ByVal scnConn As SqlConnection, ByVal strSQL As String, _
                              Optional ByVal strTableName As String = "", Optional ByVal intTimeOut As Integer = -1, _
                              Optional ByVal stnTrans As SqlTransaction = Nothing) As DataSet
        Dim ldtsDS As New DataSet
        Dim lscmCommand As New SqlCommand
        Dim ladpAdapter As SqlDataAdapter

        Try
            If strSQL <> "" Then
                lscmCommand.Connection = scnConn
                lscmCommand.CommandText = strSQL
                If (intTimeOut <> -1) Then
                    lscmCommand.CommandTimeout = intTimeOut
                Else
                    lscmCommand.CommandTimeout = GSqlCommandTimeout
                End If
                If Not stnTrans Is Nothing Then
                    lscmCommand.Transaction = stnTrans
                End If

                ladpAdapter = New SqlDataAdapter(lscmCommand)
                If (strTableName.Trim() <> "") Then
                    ladpAdapter.Fill(ldtsDS, strTableName)
                Else
                    ladpAdapter.Fill(ldtsDS)
                End If
                lscmCommand = Nothing
                ladpAdapter = Nothing
            Else
                ldtsDS = Nothing
            End If

        Catch ex As Exception
            If Not (stnTrans Is Nothing) Then
                stnTrans.Rollback()
            End If
            GSubWriteErrLog(String.Format("GFncRtnDS:[SQL:{0}][TableName:{1}][TimeOut:{2}]\r\n{3}", _
                                          strSQL, strTableName, intTimeOut, ex.Message))
        End Try

        Return ldtsDS
    End Function

    Public Function GFncRtnDS(ByVal lscmCommand As SqlCommand, Optional ByVal strTableName As String = "",
                              Optional ByVal intTimeOut As Integer = -1,
                              Optional ByVal stnTrans As SqlTransaction = Nothing) As DataSet
        Dim ldtsDS As New DataSet
        'Dim lscmCommand As New SqlCommand
        Dim ladpAdapter As SqlDataAdapter

        Try
            If Not lscmCommand Is Nothing Then
                If Not stnTrans Is Nothing Then
                    lscmCommand.Transaction = stnTrans
                End If
                If (intTimeOut <> -1) Then
                    lscmCommand.CommandTimeout = intTimeOut
                Else
                    lscmCommand.CommandTimeout = GSqlCommandTimeout     'use global timeout value
                End If
                ladpAdapter = New SqlDataAdapter(lscmCommand)
                If (strTableName.Trim() <> "") Then
                    ladpAdapter.Fill(ldtsDS, strTableName)
                Else
                    ladpAdapter.Fill(ldtsDS)
                End If
                lscmCommand = Nothing
                ladpAdapter = Nothing
            Else
                ldtsDS = Nothing
            End If

        Catch ex As Exception
            If Not lscmCommand.Transaction Is Nothing Then
                lscmCommand.Transaction.Rollback()
            End If
            GSubWriteErrLog(String.Format("GFncRtnDS:{0}\r\n{1}", _
                                          lscmCommand.CommandText,
                                          ex.Message))
        End Try

        Return ldtsDS
    End Function

    Public Function GFncRunSQL(ByVal myConnection As SqlConnection, ByVal StrSQL As String, _
                               Optional ByVal myTrans As SqlTransaction = Nothing, Optional ByVal intTimeOut As Integer = -1) As Long
        Dim myCommand As SqlCommand = myConnection.CreateCommand()
        If intTimeOut <> -1 Then
            myCommand.CommandTimeout = intTimeOut
        Else
            myCommand.CommandTimeout = GSqlCommandTimeout
        End If
        If Not myTrans Is Nothing Then
            myCommand.Transaction = myTrans
        End If
        myCommand.Connection = myConnection
        myCommand.CommandText = StrSQL
        GFncRunSQL = myCommand.ExecuteNonQuery()
        myCommand.Dispose()
    End Function
    Public Function GFncRunSQL(ByVal myConnection As SqlConnection, ByVal myTrans As SqlTransaction, ByVal StrSQL As String, ByVal intTimeOut As Integer) As Long
        Return GFncRunSQL(myConnection, StrSQL, myTrans, intTimeOut)
    End Function
    Public Function GFncRunSQL(ByVal myConnection As SqlConnection, ByVal myTrans As SqlTransaction, ByVal StrSQL As String) As Long
        Return GFncRunSQL(myConnection, StrSQL, myTrans)
    End Function
    Public Function GFncRunSQL(ByVal myConnection As SqlConnection, ByVal StrSQL As String, ByVal intTimeOut As Integer) As Long
        Return GFncRunSQL(myConnection, StrSQL, Nothing, intTimeOut)
    End Function
    Public Function GFncRtnDSTables(ByVal lscmCommand As SqlCommand, Optional ByVal strTableNames() As String = Nothing,
                          Optional ByVal intTimeOut As Integer = -1,
                          Optional ByVal stnTrans As SqlTransaction = Nothing) As DataSet
        Dim ldtsDS As New DataSet
        'Dim lscmCommand As New SqlCommand
        Dim ladpAdapter As SqlDataAdapter

        Try
            If Not lscmCommand Is Nothing Then
                If Not stnTrans Is Nothing Then
                    lscmCommand.Transaction = stnTrans
                End If
                If (intTimeOut <> -1) Then
                    lscmCommand.CommandTimeout = intTimeOut
                Else
                    lscmCommand.CommandTimeout = GSqlCommandTimeout
                End If
                ladpAdapter = New SqlDataAdapter(lscmCommand)
                If (strTableNames.Length > 0) Then
                    For i As Integer = 0 To strTableNames.Length - 1
                        ladpAdapter.TableMappings.Add(String.Format("Table{0}", IIf(i > 0, i, "")), strTableNames(i))
                    Next
                End If

                ladpAdapter.Fill(ldtsDS)
                lscmCommand = Nothing
                ladpAdapter = Nothing
            Else
                ldtsDS = Nothing
            End If

        Catch ex As Exception
            If Not lscmCommand.Transaction Is Nothing Then
                lscmCommand.Transaction.Rollback()
            End If
            GSubWriteErrLog(String.Format("GFncRtnDS:{0}\r\n{1}", _
                                          lscmCommand.CommandText,
                                          ex.Message))
        End Try

        Return ldtsDS
    End Function


    Public Function GFncExecuteNonQuery(ByVal sqlCmd As SqlCommand) As Boolean
        Try
            sqlCmd.CommandTimeout = GSqlCommandTimeout

            If sqlCmd.ExecuteNonQuery() <= 0 Then
                sqlCmd = Nothing
                Return False
            End If
            sqlCmd = Nothing
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                sqlCmd.Dispose()
                sqlCmd = Nothing
                GSubWriteErrLog(ex.Message, "", False)
                Return False
            End If
        End Try

    End Function
    Public Function GFncExecuteScalar(ByVal sqlCmd As SqlCommand) As Object
        Try
            Dim result As Object
            sqlCmd.CommandTimeout = GSqlCommandTimeout

            result = sqlCmd.ExecuteScalar()
            sqlCmd = Nothing
            Return result
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                sqlCmd.Dispose()
                sqlCmd = Nothing
            End If
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try

    End Function


    Public Sub AddParameter(ByRef lscmCommand As SqlCommand, ByVal parameterName As String,
                                 ByVal value As Object, Optional ByVal size As Integer = -1,
                                 Optional ByVal direct As ParameterDirection = ParameterDirection.Input)
        parameterName = parameterName.Trim()
        If String.IsNullOrEmpty(parameterName) Then
            Throw New Exception("Empty Parameter Name NOT supported")
        End If

        If Not parameterName.StartsWith("@") Then
            parameterName = "@" + parameterName
        End If
        Dim param As SqlParameter = lscmCommand.Parameters.AddWithValue(parameterName, value)
        param.Direction = direct
        If size.Equals(-1) Then
            param.Size = size
        End If
    End Sub

#End Region

#Region "Data Formating"
    Public Function IsEmptyDate(ByVal DtmInDate As Object) As Boolean

        If IsDBNull(DtmInDate) = True Then
            IsEmptyDate = True
        Else
            If IsNothing(DtmInDate) = True Then
                IsEmptyDate = True
            Else
                If DtmInDate = CDate("1900/01/01") Then
                    IsEmptyDate = True
                Else
                    If Format(DtmInDate, "yyyy/MM/dd") = "0001/01/01" Then
                        IsEmptyDate = True
                    Else
                        IsEmptyDate = False
                    End If
                End If
            End If
        End If

    End Function
    'return null to ""
    Public Function GFncNoNullString(ByVal objNull As Object) As String
        If IsDBNull(objNull) Then
            Return ""
        ElseIf IsNothing(objNull) Then
            Return ""
        Else
            Return objNull
        End If
    End Function
    'return null to 0
    Public Function GFncNoNullIntValue(ByVal objNull As Object) As Integer
        If IsDBNull(objNull) Then
            Return 0
        ElseIf IsNothing(objNull) Then
            Return 0
        Else
            Return objNull
        End If
    End Function
    'return null to 0
    Public Function GFncNoNullValue(ByVal objNull As Object) As Decimal
        If IsDBNull(objNull) Then
            Return 0
        ElseIf IsNothing(objNull) Then
            Return 0
        Else
            Return objNull
        End If
    End Function
    'return null to date 1900/01/01
    Public Function GFncNoNullDate(ByVal objNull As Object) As Date
        If IsDBNull(objNull) Then
            Return CDate("1900/01/01")
        ElseIf IsNothing(objNull) Then
            Return CDate("1900/01/01")
        ElseIf objNull.ToString.Trim = "" Then
            Return CDate("1900/01/01")
        Else
            Return objNull
        End If
    End Function
    Public Function GFncNoNullDateTime(ByVal objNull As Object) As DateTime
        If IsDBNull(objNull) Then
            Return DateTime.MinValue
        ElseIf IsNothing(objNull) Then
            Return DateTime.MinValue
        ElseIf objNull.ToString.Trim = "" Then
            Return DateTime.MinValue
        Else
            Return Convert.ToDateTime(objNull)
        End If
    End Function
    Public Function lFncGetMonthNumber(ByVal month As String) As String

        Select Case month.ToUpper
            Case "JAN"
                Return "01"
            Case "FEB"
                Return "02"
            Case "MAR"
                Return "03"
            Case "APR"
                Return "04"
            Case "MAY"
                Return "05"
            Case "JUN"
                Return "06"
            Case "JUL"
                Return "07"
            Case "AUG"
                Return "08"
            Case "SEP"
                Return "09"
            Case "OCT"
                Return "10"
            Case "NOV"
                Return "11"
            Case "DEC"
                Return "12"
        End Select

        Return ""

    End Function
    Public Function lFncGetMonthString(ByVal month As Integer) As String

        Select Case month
            Case 1
                Return "JAN"
            Case 2
                Return "FEB"
            Case 3
                Return "MAR"
            Case 4
                Return "APR"
            Case 5
                Return "MAY"
            Case 6
                Return "JUN"
            Case 7
                Return "JUL"
            Case 8
                Return "AUG"
            Case 9
                Return "SEP"
            Case 10
                Return "OCT"
            Case 11
                Return "NOV"
            Case 12
                Return "DEC"
        End Select

        Return ""

    End Function
    Public Function lFncGetMonthStringFull(ByVal month As Integer) As String
        Dim sMonthCode As String
        Select Case month
            Case 1
                sMonthCode = "January"
            Case 2
                sMonthCode = "February"
            Case 3
                sMonthCode = "March"
            Case 4
                sMonthCode = "April"
            Case 5
                sMonthCode = "May"
            Case 6
                sMonthCode = "Jun"
            Case 7
                sMonthCode = "July"
            Case 8
                sMonthCode = "August"
            Case 9
                sMonthCode = "September"
            Case 10
                sMonthCode = "October"
            Case 11
                sMonthCode = "November"
            Case 12
                sMonthCode = "December"
            Case Else
                sMonthCode = ""
        End Select

        Return sMonthCode
    End Function
    Public Function GfncSubString(ByVal str As String, ByVal intstart As Int16, _
    ByVal intLen As Int16) As String

        Dim strRtn As String = ""

        'If intstart >= str.Length Or intLen <= 0 Or intstart <= 0 Then
        If intstart >= str.Length Or intLen <= 0 Or intstart < 0 Then
            Return ""
        End If
        If intstart + intLen > str.Length Then
            strRtn = str.Substring(intstart, str.Length - intstart)
        Else
            strRtn = str.Substring(intstart, intLen)
        End If

        Return strRtn

    End Function
    Public Function GfncRemovePagingCharacters(ByVal strText As String)
        Return Replace(Replace(Replace(strText, Chr(10), ""), Chr(12), ""), Chr(13), "")
    End Function
    'return null to numeric with format
    Public Function GFncNullFormat(ByVal objNull As Object, ByVal strFormat As String) As String
        If IsDBNull(objNull) Then
            Return Format(0, strFormat)
        Else
            Return Format(objNull, strFormat)
        End If
    End Function
    Public Function GFncNoNullStrike(ByVal objNull As Object) As Decimal
        If IsDBNull(objNull) Then
            Return "0.000000"
        ElseIf IsNothing(objNull) Then
            Return "0.000000"
        Else
            Return objNull
        End If
    End Function
    Public Function GFncChkValidFileName(ByVal strFileName As String) As Boolean
        Dim arrInvalids As Char() = System.IO.Path.GetInvalidFileNameChars
        Dim chrInvalid As Char

        For Each chrInvalid In arrInvalids
            If strFileName.IndexOf(chrInvalid) > 0 Then
                Return False
            End If
        Next
        Return True

    End Function
    Public Function GFncReplaceFileName(ByVal strFileName As String, ByVal strReplaceChr As String) As String
        Dim arrInvalids As Char() = System.IO.Path.GetInvalidFileNameChars
        Dim chrInvalid As Char

        For Each chrInvalid In arrInvalids
            If strFileName.IndexOf(chrInvalid) > 0 Then
                strFileName = Replace(strFileName, chrInvalid, strReplaceChr)
            End If
        Next
        Return strFileName

    End Function
    Public Function GFncFormatDec(ByVal value As Decimal) As String
        Return Format(GFncNoNullValue(value), "###,###,###,##0.00")
    End Function
    Public Function GFncGetCulture() As String
        Dim sCulture = ConfigurationManager.AppSettings("Culture").ToString()
        Return sCulture
    End Function
    Public Function GFncGetFormatedDate(ByVal tdate As Date, ByVal format As String) As String
        Dim strCulture As String = GFncGetCulture()
        If String.IsNullOrEmpty(strCulture) Then
            strCulture = "en"
        End If
        Return tdate.ToString(format, New CultureInfo(strCulture))
    End Function
#End Region

#Region "UI Interactive"

    Public Sub GUIChangeEnablePropertyOfChildrenEditableControls(ByRef container As System.Windows.Forms.Control, ByVal isEnabled As Boolean)
        If container Is Nothing Or container.Controls Is Nothing Then Return

        For Each item As System.Windows.Forms.Control In container.Controls
            If item.TabStop Then item.Enabled = isEnabled
        Next
    End Sub


    ''' <summary>
    ''' 绑定单选项处理事件-文本改变时-自由事件
    ''' </summary>
    ''' <param name="sender">控件</param>
    ''' <param name="action">处理</param>
    Public Sub GUIBindDeal_ComboBox_TextChanged(sender As ComboBox, action As Action)
        AddHandler sender.TextChanged, (Sub(obj As Object, e As EventArgs) action())
    End Sub

    ''' <summary>
    ''' 绑定单选项处理事件-当第1个对象的选中索引改变时，修改第2个对象的选中索引
    ''' </summary>
    ''' <param name="sender1">控件1</param>
    ''' <param name="sender2">控件2</param>
    Public Sub GUIBindDeal_ComboBox_ChangeSencondIndex_When_FirstIndexChanged(sender1 As ComboBox, sender2 As ComboBox)
        AddHandler sender1.SelectedIndexChanged, (Sub(obj As Object, e As EventArgs)
                                                      If (sender1.SelectedIndex >= 0) Then
                                                          sender2.SelectedIndex = sender1.SelectedIndex
                                                      End If
                                                  End Sub)
    End Sub

    Public Sub GFncSelectDgvAfterUpdate(ByVal dgv As DataGridView, ByVal str As String, ByVal val As String, Optional ByVal sortByKey As Boolean = False)
        dgv.ClearSelection()
        Try
            If sortByKey Then
                Dim index As Integer = dgv.Rows.Count / 2
                While index >= 0
                    Dim value As String = GFncNoNullString(dgv.Rows(index).Cells(str).Value)
                    If value = val Then
                        dgv.Rows(index).Selected = True
                        Return
                    ElseIf value < val Then
                        index = index / 2
                    ElseIf value > val Then
                        index = index + index / 2
                    End If
                End While
            Else
                For Each dgvr As DataGridViewRow In dgv.Rows
                    If GFncNoNullString(dgvr.Cells(str).Value) = val Then
                        dgv.Rows(dgvr.Index).Selected = True
                        Return
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region


End Module
