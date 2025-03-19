Imports System.Configuration
Imports System.IO
'Imports System.IO.Compression
Imports Ionic.Zip

Module BatchImportTradeActivity

    Private cls As New ESL.clsITA
    Private dtLog As DataTable = Nothing
    Private LogStr As String = "Run Time: {0}s, Investment Type: {1}, File Name: {2}, Status: {3}, Error: {4}"
    Private ErrorPath As String = ""
    Private strTradeActivitySender As String = ""
    Dim ExeTime As DateTime = Nothing
    Public Sub Main()
        Dim TradeMod As String = ""
        Dim ImportFilePath As String = ""
        Dim ZPath As String = ""
        Dim result As Boolean = True
        Dim EmailSubjectPrefix As String = ""
        Try
            cls.IsBatch = True
            ExeTime = DateTime.Now
            ImportFilePath = ConfigurationSettings.AppSettings.GetValues("ImportFilePath")(0).ToString()
            EmailSubjectPrefix = ConfigurationSettings.AppSettings.GetValues("EmailSubjectPrefix")(0).ToString()
            Dim frm As New ESL.frmLogin
            frm.OnLoad()
            frm.CreateConnection()
            strTradeActivitySender = cls.FncLoadEmailSndr
            ErrorPath = String.Format(ImportFilePath, "Errors")
            cls.EventPath = ErrorPath
            Dim FPath As String = String.Format(ImportFilePath, "Futures")
            Dim OPath As String = String.Format(ImportFilePath, "StockOptions")
            ZPath = String.Format(ImportFilePath, "Zip")
            If Directory.Exists(FPath) Then
                TradeMod = "F"
                result = ImportFiles(FPath, TradeMod) AndAlso result
            End If
            If Directory.Exists(OPath) Then
                TradeMod = "O"
                result = ImportFiles(OPath, TradeMod) AndAlso result
            End If
        Catch ex As Exception
            Dim FinTime As DateTime = DateTime.Now
            ESL.GSubWriteEventLog(String.Format(LogStr, FinTime.Subtract(ExeTime).TotalSeconds, IIf(TradeMod = "F", "Futures", "Stock Options"), cls.ImportFileNameTrade, "Fail", ex.Message), ErrorPath)
            result = False
        Finally
            Try
                If Not Directory.Exists(ZPath) Then
                    Directory.CreateDirectory(ZPath)
                End If
                Dim Zip As ZipFile = New ZipFile()
                Dim zipFileName As String = ZPath & "\BatchImportTradeActivity" & Format(Now, "yyyyMMddHHmmss") & ".zip"
                If File.Exists(zipFileName) Then
                    File.Delete(zipFileName)
                End If
                For Each str As String In Directory.GetFiles(ErrorPath)
                    Zip.AddFile(str, "")
                Next
                Zip.Save(zipFileName)
                For Each str As String In Directory.GetFiles(ErrorPath)
                    If File.Exists(str) Then
                        File.Delete(str)
                    End If
                Next
                ESL.mySendEmail(strTradeActivitySender, cls.FncLoadEmailTo(result), EmailSubjectPrefix & " - [" & If(result, "SUCCESS", "FAIL") & "] - Import Trade Activity on " & Format(DateTime.Now, "MMM dd, yyyy"), "The batch job has been executed, please check the attached log files.", ESL.GStrEIP, zipFileName)
            Catch ep As Exception
                ESL.GSubWriteEventLog(ep.Message, ErrorPath)
            End Try
            End
        End Try
    End Sub

    Private Function ImportFiles(ByVal Path As String, ByVal TradeMod As String) As Boolean
        Dim msg As String = ""
        Dim FinTime As DateTime = Nothing
        Dim ErrorCount As Integer = 0
        Dim result As Boolean = True
        Dim HPath As String = Path & "\History\" & Format(Now, "yyyyMMddHHmmss")
        If Directory.Exists(Path) Then
            For Each Str As String In Directory.GetFiles(Path)
                dtLog = cls.FncLoadTrade()
                result = True
                ErrorCount = 0
                ExeTime = DateTime.Now
                msg = cls.FncValidateTradeInput(Str, dtLog, TradeMod, ErrorCount)
                If msg <> "" Then
                    dtLog.Clear()
                    ESL.GSubWriteEventLog(vbCrLf & msg, ErrorPath, TradeMod & "-" & cls.ImportFileNameTrade)
                    result = False
                Else
                    result = cls.FncInsertActivity(dtLog, TradeMod & "-" & cls.ImportFileNameTrade)
                    If Not result Then
                        ErrorCount += 1
                    End If
                End If
                FinTime = DateTime.Now
                If result Then
                    ESL.GSubWriteEventLog(String.Format(LogStr, FinTime.Subtract(ExeTime).TotalSeconds, IIf(TradeMod = "F", "Futures", "Stock Options"), cls.ImportFileNameTrade, "Success", "0"), ErrorPath)
                Else
                    ESL.GSubWriteEventLog(String.Format(LogStr, FinTime.Subtract(ExeTime).TotalSeconds, IIf(TradeMod = "F", "Futures", "Stock Options"), cls.ImportFileNameTrade, "Fail", ErrorCount & ", log file: " & "event" & Format(Now, "yyyyMMdd") & "log-" & TradeMod & "-" & cls.ImportFileNameTrade & ".txt"), ErrorPath)
                End If
                If Not Directory.Exists(HPath) Then
                    Directory.CreateDirectory(HPath)
                End If
                File.Move(Str, Str.Replace(Path, HPath))
            Next
        End If
        Return result
    End Function

End Module
