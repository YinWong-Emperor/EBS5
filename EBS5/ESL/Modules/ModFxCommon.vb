Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Module ModFxCommon

    Public Sub GSubCreateConnection(ByVal StrBranch As String)
        Dim strSettings As String = ""
        Dim strPriceSettings As String = ""

        'Dim DtrCon As SqlDataReader
        'DtrCon = GFncRtnCDR("Select * from Connection_Information where CIfChrSystem ='MACAUFX' and CIfChrServerType = '" & StrBranch & "'")
        'If DtrCon.HasRows = True Then
        '    DtrCon.Read()
        '    strSettings = DtrCon.Item("CIfChrConnection")
        '    If StrBranch <> "MST" Then
        '        GStrConDB = DtrCon.Item("CIfChrDatabase")
        '    End If
        'End If
        'DtrCon.Close()
        Dim dtsCon As DataSet

        Try
            dtsCon = GFncRtnDS(GSCnConConn, "Select * from Connection_Information where CIfChrSystem ='ESL' and CIfChrServerType = '" & StrBranch & "'")
            If dtsCon.Tables(0).Rows.Count > 0 Then
                strSettings = dtsCon.Tables(0).Rows(0).Item("CIfChrConnection")
                strPriceSettings = dtsCon.Tables(0).Rows(0).Item("CIfChrPriceFeed")
                If StrBranch <> "MST" Then
                    GStrConDB = dtsCon.Tables(0).Rows(0).Item("CIfChrDatabase")
                    GStrIsReportDB = dtsCon.Tables(0).Rows(0).Item("CIfChrIsReportDB")
                End If
            End If
            dtsCon.Dispose()
            GStrBCode = StrBranch

            'strSettings = ConfigurationManager.ConnectionStrings("DBConnection").ToString
            If StrBranch = "MST" Then
                If GSCnMaster Is Nothing Then
                    GSCnMaster = New SqlConnection(strSettings)
                    GSCnMaster.Open()
                Else
                    GSCnMaster = Nothing
                    GSCnMaster = New SqlConnection(strSettings)
                    GSCnMaster.Open()
                End If
            Else
                If GSCnSqlConn Is Nothing Then
                    GSCnSqlConn = New SqlConnection(strSettings)
                    GSCnSqlConn.Open()
                Else
                    GSCnSqlConn = Nothing
                    GSCnSqlConn = New SqlConnection(strSettings)
                    GSCnSqlConn.Open()
                End If

                'Try
                '    GSCnPriceConn = Nothing
                '    If strPriceSettings <> "" Then
                '        GSCnPriceConn = New SqlConnection(strPriceSettings)
                '        GSCnPriceConn.Open()
                '    End If
                'Catch ex As Exception
                '    GSubShowWarn("Price feed connection fail!")
                '    GSCnPriceConn = Nothing
                'End Try
            End If
        Catch excep As Exception
            GSubWriteErrLog(excep.Message)
        End Try
    End Sub

    Public Function GSubCreateESLConnection(ByVal StrBranch As String, Optional ByRef strDB As String = "") As SqlConnection
        Dim strSettings As String = ""
        Dim strPriceSettings As String = ""
        Dim dtsCon As DataSet
        Dim lSqlConn As SqlConnection = Nothing

        Try
            dtsCon = GFncRtnDS(GSCnSqlConn, "Select * from DB_Information where CIfChrSystem ='ESL' and CIfChrServerType = '" & StrBranch & "'")
            If dtsCon.Tables(0).Rows.Count > 0 Then
                strSettings = dtsCon.Tables(0).Rows(0).Item("CIfChrConnection")
                strDB = dtsCon.Tables(0).Rows(0).Item("CIfChrDataBase")
            End If
            dtsCon.Dispose()

            'strSettings = ConfigurationManager.ConnectionStrings("DBConnection").ToString

            If lSqlConn Is Nothing Then
                lSqlConn = New SqlConnection(strSettings)
                lSqlConn.Open()
            Else
                lSqlConn = Nothing
                lSqlConn = New SqlConnection(strSettings)
                lSqlConn.Open()
            End If

        Catch excep As Exception
            GSubWriteErrLog(excep.Message)
        End Try

        Return lSqlConn

    End Function
    Public Function GSubGetESLDB(ByVal StrBranch As String) As String
        Dim lstrDB As String = ""
        Dim ldtsCon As DataSet

        ldtsCon = GFncRtnDS(GSCnSqlConn, "Select * from DB_Information where CIfChrSystem ='ESL' and CIfChrServerType = '" & StrBranch & "'")
        If ldtsCon.Tables(0).Rows.Count > 0 Then
            lstrDB = ldtsCon.Tables(0).Rows(0).Item("CIfChrDataBase")
        End If
        ldtsCon.Dispose()

        Return lstrDB

    End Function

    Public Sub GSubSetSMTP()
        'Dim sReaderPath As StreamReader
        'Dim strRealPath As String = ""
        'Dim sReader As StreamReader
        'Dim lline As String
        'Dim key As String
        'Dim val As String

        'sReaderPath = New StreamReader(GStrConnFile)
        'If Not sReaderPath.EndOfStream Then
        '    strRealPath = sReaderPath.ReadLine
        '    sReader = New StreamReader(strRealPath)
        '    While sReader.Peek() > -1
        '        lline = sReader.ReadLine()
        '        key = Mid(lline, 1, InStr(lline, "=") - 1)
        '        val = Mid(lline, InStr(lline, "=") + 1, lline.Length - InStr(lline, "="))

        '        If (key = "emailip") Then
        '            GStrEIP = val
        '        ElseIf (key = "sender") Then
        '            GStrSender = val
        '        End If
        '    End While
        '    sReader.Close()
        'End If
        GStrEIP = System.Configuration.ConfigurationManager.AppSettings.Get("EmailHost")
        GStrSender = System.Configuration.ConfigurationManager.AppSettings.Get("EmailSender")

    End Sub

    Public Sub GSubCreateCConnection()
        Dim strSettings As String = ""
        Dim sReaderPath As StreamReader
        Dim strRealPath As String = ""
        Dim sReader As StreamReader
        Dim strTemp As String = ""
        Dim strIP As String = ""
        Dim strDB As String = ""
        Dim strUser As String = ""
        Dim strPWD As String = ""
        'Dim strIP As String = ConfigurationManager.AppSettings("MCFXIP").ToString
        'Dim strDB As String = ConfigurationManager.AppSettings("MCFXDB").ToString
        'Dim strUser As String = ConfigurationManager.AppSettings("MCFXUSER").ToString
        'Dim strPWD As String = ConfigurationManager.AppSettings("MCFXPWD").ToString

        Try
            ''read connection info from file
            'sReaderPath = New StreamReader(GStrConnFile)
            'If Not sReaderPath.EndOfStream Then
            '    strRealPath = sReaderPath.ReadLine
            '    sReader = New StreamReader(strRealPath)
            '    Do While Not sReader.EndOfStream
            '        strTemp = sReader.ReadLine()
            '        Select Case UCase(strTemp.Substring(0, InStr(strTemp, "=", CompareMethod.Text) - 1))
            '            'Case "MCFXIP"
            '            '    strIP = Replace(strTemp, "MCFXIP=", "", , , CompareMethod.Text).Trim
            '            'Case "MCFXDB"
            '            '    strDB = Replace(strTemp, "MCFXDB=", "", , , CompareMethod.Text).Trim
            '            'Case "MCFXUSER"
            '            '    strUser = Replace(strTemp, "MCFXUSER=", "", , , CompareMethod.Text).Trim
            '            'Case "MCFXPWD"
            '            '    strPWD = Replace(strTemp, "MCFXPWD=", "", , , CompareMethod.Text).Trim
            '            Case "MCFXBRH"
            '                GArrShowBrh.Add(Replace(strTemp, "MCFXBRH=", "", , , CompareMethod.Text).Trim)
            '        End Select
            '    Loop
            '    sReader.Close()

            Dim strBranch As String = ""
            strBranch = System.Configuration.ConfigurationManager.AppSettings.Get("Branch")
            GArrShowBrh.Add(strBranch)

            'strSettings = "Persist Security Info=False;data source=" & strIP & ";initial catalog=" & strDB & ";user id=EBSconn;password=123456"
            strSettings = System.Configuration.ConfigurationManager.AppSettings.Get("GSCnConConn")

            If GSCnConConn Is Nothing Then
                GSCnConConn = New SqlConnection(strSettings)
                GSCnConConn.Open()
            Else
                GSCnConConn = Nothing
                GSCnConConn = New SqlConnection(strSettings)
                GSCnConConn.Open()
            End If
            'End If
        Catch exFile As IOException

            GSubShowWarn("DB Connection File not found!")
            Application.Exit()
        Catch exSQL As SqlException
            GSubShowWarn(exSQL.ErrorCode & ": " & exSQL.Message)
            Application.Exit()
        Catch ex As Exception
            GSubShowWarn("Cannot access to DB Connection File!" & " " & ex.Message)
            Application.Exit()
        End Try
    End Sub

    'close sql connection and release resources
    Public Sub GSubDisposeConnection(ByRef SQLConn As SqlConnection)
        If Not IsNothing(SQLConn) Then
            If SQLConn.State = ConnectionState.Open Then
                SQLConn.Close()
            End If
            SQLConn.Dispose()
            SqlConnection.ClearAllPools()
            SQLConn = Nothing
        End If
    End Sub

    Public Function GFncGetTDate() As Date
        Dim strSQL As String = ""
        Dim dtTdate As Date
        'Dim reader As SqlDataReader
        Dim DtsReader As New DataSet

        strSQL = "Select * from sttxndate "
        DtsReader = GFncRtnDS(GSCnLiqConn, strSQL)

        If DtsReader.Tables(0).Rows.Count > 0 Then
            'reader.Read()
            dtTdate = DtsReader.Tables(0).Rows(0).Item("t2_date")
        Else
            dtTdate = CDate("1900/01/01")
        End If

        'reader.Close()
        DtsReader.Dispose()
        'CloseDRCon()
        Return dtTdate

    End Function

    Public Function GFncGetTDateUS() As Date
        Dim strSQL As String = ""
        Dim dtTdate As Date
        'Dim reader As SqlDataReader
        Dim DtsReader As New DataSet

        strSQL = "Select * from stcontrol_US "
        DtsReader = GFncRtnDS(GSCnLiqConn, strSQL)

        If DtsReader.Tables(0).Rows.Count > 0 Then
            'reader.Read()
            dtTdate = DtsReader.Tables(0).Rows(0).Item("tradeDate")
        Else
            dtTdate = CDate("1900/01/01")
        End If

        'reader.Close()
        DtsReader.Dispose()
        'CloseDRCon()
        Return dtTdate

    End Function

    Public Sub GSubWriteELog(ByVal StrError As String)

        GSubWriteErrLog(StrError, GStrEPath)

    End Sub

    'Public Function ReadMyAppSettings(ByVal StrGetType As String) As String

    '    Dim StrEPath As String = ""

    '    StrEPath = System.Configuration.ConfigurationSettings.AppSettings("EPath")

    '    Select Case StrGetType
    '        Case "EPath"
    '            ReadMyAppSettings = StrEPath
    '    End Select

    'End Function

    Public Function GFncSameUpdDate(ByVal strSQL As String, ByVal dteUpdDate As Date) As Boolean

        'Dim ldtrUpd As SqlDataReader
        Dim ldtsUpd As New DataSet

        ldtsUpd = GFncRtnDS(GSCnSqlConn, strSQL)
        If ldtsUpd.Tables(0).Rows.Count > 0 Then
            'ldtrUpd.Read()
            If Not IsDBNull(ldtsUpd.Tables(0).Rows(0).Item("lstupddte")) And Format(dteUpdDate, "yyyy/MM/dd") <> "0001/01/01" Then
                'dteUpdDate = ldtsUpd.Tables(0).Rows(0).Item("lstupddte")
                If Format(ldtsUpd.Tables(0).Rows(0).Item("lstupddte"), "yyyy/MM/dd HH:mm:ss") = _
                        Format(dteUpdDate, "yyyy/MM/dd HH:mm:ss") Then
                    GFncSameUpdDate = True
                Else
                    GFncSameUpdDate = False
                End If
            ElseIf IsDBNull(ldtsUpd.Tables(0).Rows(0).Item("lstupddte")) And Format(dteUpdDate, "yyyy/MM/dd") = "0001/01/01" Then
                GFncSameUpdDate = True
            Else
                GFncSameUpdDate = False
            End If

        End If
        ldtsUpd.Dispose()
        'CloseDRCon()

    End Function

    Public Function GFncGetServerDateTime() As Date
        Dim lstrSQL As String = ""
        Dim ldtsDt As DataSet
        Dim ldteDt As Date

        lstrSQL = "Select getdate() as dt"
        ldtsDt = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsDt.Tables(0).Rows.Count > 0 Then
            ldteDt = ldtsDt.Tables(0).Rows(0).Item("dt")
        Else
            ldteDt = CDate("1900/01/01")
        End If

        Return ldteDt

    End Function

    Public Function GFncIsTradeDateExpire() As Boolean
        'Dim lstrSQL As String = ""
        'Dim ldtsTDate As DataSet

        'lstrSQL = "Select d_tdate from [date]"
        'ldtsTDate = GFncRtnDS(GSCnSqlConn, lstrSQL)

        'If ldtsTDate.Tables(0).Rows.Count > 0 Then
        '    If Format(g_tdate, "yyyy/MM/dd") <> Format(ldtsTDate.Tables(0).Rows(0).Item("d_tdate"), "yyyy/MM/dd") Then
        'GFncIsTradeDateExpire = True
        '    Else
        GFncIsTradeDateExpire = False
        '    End If
        'Else
        'GFncIsTradeDateExpire = True
        'End If

        'If GFncIsTradeDateExpire Then
        '    GSubShowWarn(GFncGetSysMsg(60))
        '    Application.Exit()
        'End If

    End Function

    Public Function GFncExportRpt(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal strPath As String, ByVal strFileName As String) As Boolean
        Dim exportOpts As New ExportOptions()
        Dim diskOpts As New DiskFileDestinationOptions()

        exportOpts = rpt.ExportOptions

        ' Set the export format.
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
        exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

        ' Set the disk file options.
        If Right(strPath.Trim(), 1) <> "\" Then
            strPath &= "\"
        End If

        Try
            Directory.GetDirectories(strPath)
        Catch exDir As DirectoryNotFoundException
            Directory.CreateDirectory(strPath)
        Catch ex As Exception
            GFncExportRpt = False
            GSubWriteErrLog(ex.Message)
        End Try

        diskOpts.DiskFileName = strPath & strFileName & ".pdf"

        exportOpts.DestinationOptions = diskOpts

        Try
            ' Export the report.
            rpt.Export(exportOpts)
            Return True
        Catch exExp As Exception
            GSubShowError(exExp.Message)
            Return False
        End Try

    End Function

    Public Function GFncPrintRpt(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal strPrinter As String) As Boolean
        Try
            rpt.PrintOptions.PrinterName = strPrinter
            rpt.PrintToPrinter(1, False, 0, 0)
            Return True
        Catch ex As Exception
            GSubShowError(ex.Message)
            Return False
        End Try
    End Function

    Public Function GFncPrintRpt(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal strPrinter As String, ByVal intCopy As Integer) As Boolean
        Try
            rpt.PrintOptions.PrinterName = strPrinter
            rpt.PrintToPrinter(intCopy, False, 0, 0)
            Return True
        Catch ex As Exception
            GSubShowError(ex.Message)
            Return False
        End Try
    End Function

    Public Function GFncPrintRptSeparate(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal strPrinter As String, ByVal intCopy As Integer) As Boolean
        Try
            rpt.PrintOptions.PrinterName = strPrinter

            rpt.PrintToPrinter(intCopy, False, 0, 0)
            Return True
        Catch ex As Exception
            GSubShowError(ex.Message)
            Return False
        End Try
    End Function

    Public Function GFncPrintRpt(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal strPrinter As String, _
            ByVal intCopy As Integer, ByVal intStartPage As Integer, ByVal intEndPage As Integer) As Boolean
        Try
            rpt.PrintOptions.PrinterName = strPrinter
            rpt.PrintToPrinter(intCopy, False, intStartPage, intEndPage)
            Return True
        Catch ex As Exception
            GSubShowError(ex.Message)
            Return False
        End Try
    End Function

    Public Function GFncGetReportMaster() As DataSet
        Dim lstrSQL As String = ""
        Dim ldtsRptNames As DataSet

        lstrSQL = "Select * from report_master"
        ldtsRptNames = GFncRtnDS(GSCnSqlConn, lstrSQL)

        Return ldtsRptNames

    End Function

    Public Function GFncCheckFunctionAccess(ByVal lstrFncID As String) As Boolean
        Dim ldtsFncA As DataSet = Nothing
        Dim ldtsFncI As DataSet = Nothing
        Dim lstrSQL As String = "select * from function_info where fiobjectcode = '" & lstrFncID & "' "
        ldtsFncI = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsFncI.Tables(0).Rows.Count <= 0 Then
            Return False
        End If
        lstrSQL = " select * from function_access inner join function_info  on fiobjectkey = fncobjectkey " & _
                " where fiobjectcode = '" & lstrFncID & "' and fncuserid = '" & GStrloginID & "' "
        ldtsFncA = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsFncA.Tables(0).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    'FncID for specified buttons, empty string for all save button in commission functions
    Public Function GFncCheckCommStatus(Optional ByVal FncID As String = "") As Boolean
        Dim str As String = "select * from function_access a inner join function_info b on b.fiobjectkey = a.fncobjectkey " & _
           "where a.fncuserid = '*ALL' "
        If FncID <> "" Then
            str &= "and b.FIObjectCode = '" & FncID & "'"
        End If
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            MessageBox.Show("The commission is being approved, please use this function later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If
        Return False
    End Function

    'Public Function GFncCheckPrintButton(ByVal FncID As String) As Boolean
    '    If GFncCheckPostingTime() Then
    '        Dim str As String = "select * from function_access a inner join function_info b on b.fiobjectkey = a.fncobjectkey " & _
    '                         "where a.fncuserid = '*ALL' and b.FIObjectCode = '" & FncID & "'"
    '        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
    '        If dt.Rows.Count > 0 Then
    '            MessageBox.Show("Some commission has not been approved, please approve them before printing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Return True
    '        End If
    '    End If
    '    Return False
    'End Function

    Public Function GFncCheckPostingTime() As Boolean
        Dim str As String = "select max(d_date) as d_date from logtbl where d_type in " & _
            "(select distinct misc_code from misc_master where misc_type = 'commlog')"
        Dim logDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim logTime As Date = GFncNoNullDate(Nothing)
        If logDt.Rows.Count > 0 Then
            logTime = GFncNoNullDate(logDt.Rows(0).Item("d_date"))
        End If
        str = "select * from comm_last_posting_time order by d_date desc "
        Dim postDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim postTime As Date = GFncNoNullDate(Nothing)
        If postDt.Rows.Count > 0 Then
            postTime = GFncNoNullDate(postDt.Rows(0).Item("d_date"))
        End If
        If postTime >= logTime Then
            Return False
        Else
            MessageBox.Show("Some commission has not been approved, please approve them before printing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If
    End Function

    Public Function GFncBackup(ByVal lstrPath As String) As Boolean
        Dim ldtsBackup As DataSet
        Dim ldtsDB As DataSet
        Dim ldtwDB As DataRow
        Dim lstrSQL As String = ""
        Dim lstrFileFullPath As String
        Dim lSqlConn As SqlConnection = Nothing
        'Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If Right(lstrPath.Trim, 1) <> "\" Then
            lstrPath = lstrPath.Trim & "\"
        End If
        lstrSQL = " select * from DB_information order by cifchrservertype "
        ldtsDB = modCommon.GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsDB.Tables(0).Rows.Count <= 0 Then
            Return False
        End If

        Try
            'save current application version before backup DB
            lstrSQL = "Update APP_INFO Set app_ver = '" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & "'"
            GFncRunSQL(GSCnSqlConn, lstrSQL)
            lstrFileFullPath = lstrPath.Trim & Format(GDteTradeDate, "yyyyMMdd") & _
                                    "-" & Format(Now, "yyyyMMddHHmmss")
            For Each ldtwDB In ldtsDB.Tables(0).Rows
                If ldtwDB("cifchrisbackup") = "Y" Then
                    lSqlConn = GSubCreateESLConnection(ldtwDB("cifchrservertype"))
                    lstrSQL = "SP_BK_Database '" & lstrFileFullPath.Trim & _
                            "-" & ldtwDB("cifchrservertype").ToString.Trim & ".bak" & "',LStrResult"
                    ldtsBackup = modCommon.GFncRtnDS(lSqlConn, lstrSQL)
                    If ldtsBackup.Tables(0).Rows(0).Item(0) <> "OK" Then
                        Return False
                    End If
                End If
            Next

            'modCommon.GFncRunSQL(GSCnConConn, "Insert into DatabaseSave values ('" & TxtFileName.Text & "','" & Format(Now, "yyyy/MM/dd hh:mm:ss") & "','" & GStrBCode & "')")
            'Windows.Forms.Cursor.Current = Cursors.Default
            Return True
        Catch ex As Exception
            GSubShowWarn(ex.Message)
            'Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Return False

    End Function

End Module
