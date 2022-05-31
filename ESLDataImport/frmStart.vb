Imports System.Configuration
Imports System.Threading
Imports System.Threading.Tasks

Public Class frmStart

    Private LogPath As String = ""

    Private Sub frmStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnLoad()
    End Sub

    Private Sub OnLoad()
        Me.Hide()
        Dim result As Boolean = False
        Dim sProdSourceDate As String = DateTime.Today.ToString()
        Try
            Dim IsBackgroundMode As Boolean = Convert.ToBoolean(ConfigurationSettings.AppSettings.GetValues("IsBackgroundMode")(0))
            LogPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Logs")
            ESL.GSubWriteEventLog("ESLImport Started", LogPath)
            Dim frm As New ESL.frmLogin
            frm.OnLoad()
            frm.CreateConnection()
            ESL.GDteTradeDate = ESL.GFncGetTDate()
            ESL.GSubWriteEventLog(String.Format("Log path={0}", ESL.GStrEPath), LogPath)
            Dim frmImportData As New ESL.FrmImportData()
            frmImportData.Show()
            If (IsBackgroundMode) Then
                frmImportData.Hide()
            End If
            frmImportData.btnSave_Click(Nothing, System.EventArgs.Empty)
            While Not frmImportData.DoImportIsDone
                Application.DoEvents()
            End While
            ESL.GSubWriteEventLog("ESLImport Finished", LogPath)
        Catch ex As Exception
            ESL.GSubWriteEventLog("Error: " & ex.Message, LogPath)
        Finally
            End
        End Try
    End Sub

End Class
