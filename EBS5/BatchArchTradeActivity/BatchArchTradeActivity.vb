Imports System.Configuration
Imports ESL

Module BatchArchTradeActivity

    Private cls As New ESL.clsITA
    Private LogStr As String = "Run Time: {0}s, Archive Data on or before: {1}, Status: {2}, No. of Records: {3}"
    Private ExeTime As DateTime = Nothing
    Private FinTime As DateTime = Nothing
    Private LogPath As String = ConfigurationSettings.AppSettings.GetValues("EventLogPath")(0).ToString()

    Sub Main()
        Dim result As Boolean = True
        Dim records As Long = 0
        Dim days As Integer = 0
        Try
            cls.IsBatch = True
            ExeTime = DateTime.Now
            Dim frm As New ESL.frmLogin
            frm.OnLoad()
            frm.CreateConnection()
            days = ESL.GFncNoNullIntValue(cls.FncGetReportParameters("Housekeep", "RetentPeriod"))
            If days > 0 Then
                records = cls.FncHouseKeep(days)
            End If
        Catch ex As Exception
            result = False
            ESL.GSubWriteEventLog("Error: " & ex.Message, LogPath)
        Finally
            FinTime = DateTime.Now
            If result Then
                ESL.GSubWriteEventLog(String.Format(LogStr, FinTime.Subtract(ExeTime).TotalSeconds, ExeTime.AddDays(days * (-1)).ToString("dd/MM/yyyy"), "Success", records), LogPath)
            Else
                ESL.GSubWriteEventLog(String.Format(LogStr, FinTime.Subtract(ExeTime).TotalSeconds, ExeTime.AddDays(days * (-1)).ToString("dd/MM/yyyy"), "Fail", "0"), LogPath)
            End If
            End
        End Try
    End Sub

End Module
