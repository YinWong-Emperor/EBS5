Imports System.IO
Imports Ionic.Zip

Public Class frmRptTradingActAlert

    Public FrmMod As String = ""
    Private strTradeActivitySender As String = ""
    Private cls As New clsITA

    Private Sub frmRptTradingActAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadForm(True)
    End Sub

    Private Sub loadForm(Optional ByVal loadTitle As Boolean = False)
        Dim str As String = IIf(FrmMod = "F", "Futures", "Stock Options")
        If loadTitle Then
            Me.Text = str & " Trading Activity Alert Reports" & vbTab & Me.Text
        End If
        Me.lblTitle.Text = String.Format("{0} Trading Activity Alert Reports", str)
        LoadReportTypes()
        strTradeActivitySender = cls.FncLoadEmailSndr
        SetControls(True)
        Me.dtpFrom.Value = GDteTradeDate
        Me.dtpTo.Value = GDteTradeDate
    End Sub

    Private Sub ShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub SetControls(ByVal flg As Boolean)
        ShowProcessing(Not flg)
        If Not flg Then
            Cursor.Current = Cursors.WaitCursor
        Else
            Cursor.Current = Cursors.Default
        End If
        Me.btnSave.Enabled = flg
        Me.btnCancel.Enabled = flg
        Dim rpt As String = Me.ddlRptName.SelectedValue
        Select Case rpt
            Case "All", "RptAlt01", "RptAlt02", "RptAlt03"
                Me.lblChannel.Visible = True
                Me.ddlChannel.Visible = True
            Case "RptAlt04", "RptAlt05"
                Me.lblChannel.Visible = False
                Me.ddlChannel.Visible = False
        End Select
        LoadCriteria()
    End Sub

    Private Sub LoadCriteria(Optional ByVal rpt As String = "")
        If rpt = "" Then
            Me.lblTimes.Text = "m Times of Orders:"
            Me.ambTimes.Text = ""
            Me.lblDays.Text = "Last n Calendar Days:"
            Me.ambDays.Text = ""
            Me.lblEmail.Text = "Email Recipient List:"
            Me.txtEmail.Text = ""
            rpt = GFncNoNullString(Me.ddlRptName.SelectedValue)
        End If
        Dim dt As DataTable = cls.FncGetReportCriteria(rpt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Select Case GFncNoNullString(dr("PARACODE"))
                    Case "OrdRatio", "QtyRatio"
                        Me.lblTimes.Text = GFncNoNullString(dr("ParaDesc"))
                        Me.ambTimes.Text = GFncNoNullIntValue(dr("ParaVal"))
                    Case "AvgForDay", "AvgForDay", "NoTradInDay", "TimeIntvl"
                        Me.lblDays.Text = GFncNoNullString(dr("ParaDesc"))
                        Me.ambDays.Text = GFncNoNullIntValue(dr("ParaVal"))
                    Case "EmailLst"
                        Me.lblEmail.Text = GFncNoNullString(dr("ParaDesc"))
                        Me.txtEmail.Text = GFncNoNullString(dr("ParaVal"))
                End Select
            Next
        End If
        Select Case rpt
            Case "All"
                Me.GroupBox2.Visible = False
                Me.GroupBox3.Location = New Point(17, 96)
            Case Else
                Me.GroupBox2.Visible = True
                Me.GroupBox2.Location = New Point(17, 96)
                Me.GroupBox3.Location = New Point(17, 226)
        End Select
        Select Case rpt
            Case "RptAlt01", "RptAlt02"
                Me.lblTimes.Visible = True
                Me.ambTimes.Visible = True
                Me.lblTimes.Location = New Point(6, 23)
                Me.ambTimes.Location = New Point(834, 20)
                Me.lblDays.Visible = True
                Me.ambDays.Visible = True
                Me.lblDays.Location = New Point(6, 50)
                Me.ambDays.Location = New Point(834, 47)
                Me.lblEmail.Location = New Point(6, 77)
                Me.txtEmail.Location = New Point(10, 95)
            Case "RptAlt03", "RptAlt04"
                Me.lblTimes.Visible = False
                Me.ambTimes.Visible = False
                Me.lblDays.Visible = True
                Me.ambDays.Visible = True
                Me.lblDays.Location = New Point(6, 23)
                Me.ambDays.Location = New Point(834, 20)
                Me.lblEmail.Location = New Point(6, 50)
                Me.txtEmail.Location = New Point(10, 68)
            Case "RptAlt05"
                Me.lblTimes.Visible = False
                Me.ambTimes.Visible = False
                Me.lblDays.Visible = False
                Me.ambDays.Visible = False
                Me.lblEmail.Location = New Point(6, 23)
                Me.txtEmail.Location = New Point(10, 41)
        End Select
    End Sub

    Private Sub LoadReportTypes()
        Dim dt As DataTable = cls.FncGetValueForDropDown("SurveilRpt")
        Me.ddlRptName.DisplayMember = "ValDesc"
        Me.ddlRptName.ValueMember = "ValCode"
        Me.ddlRptName.DataSource = dt
        Me.ddlRptName.SelectedIndex = 0
        Dim dtChannel As DataTable = cls.FncGetValueForDropDown("TradCh")
        Me.ddlChannel.DisplayMember = "ValDesc"
        Me.ddlChannel.ValueMember = "ValCode"
        Me.ddlChannel.DataSource = dtChannel
        Me.ddlChannel.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ddlReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRptName.SelectedIndexChanged
        SetControls(True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SetControls(False)
        Dim ContainsReports As Boolean = False
        Dim result As Boolean = True
        Dim lst As List(Of AlertReport) = New List(Of AlertReport)
        If Me.ddlRptName.SelectedValue = "All" Then
            For i As Integer = 1 To Me.ddlRptName.Items.Count - 1
                lst.Add(New AlertReport(GFncNoNullString(Me.ddlRptName.Items(i)("ValDesc")), GFncNoNullString(Me.ddlRptName.Items(i)("ValCode"))))
            Next
        Else
            lst.Add(New AlertReport(Me.ddlRptName.Text, Me.ddlRptName.SelectedValue))
        End If
        Try
            Dim Path As String = GStrExptDir & "TradingActAlertRpt\"
            If Not Directory.Exists(Path) Then
                Directory.CreateDirectory(Path)
            End If
            For Each rpt As AlertReport In lst
                Dim rptPath As String = Path & rpt.ID & "\"
                Dim zipFileName As String = String.Format("{0}{1}-{2}.zip", Path, rpt.ID, Format(Now, "yyyyMMddHHmmss"))
                Dim Zip As ZipFile = New ZipFile()
                Dim ZipFlag As Boolean = False
                For i As Integer = 0 To dtpTo.Value.Subtract(dtpFrom.Value).Days
                    Dim day As Date = GFncNoNullDateTime(dtpFrom.Value.ToString("yyyy/MM/dd 00:00:00")).AddDays(i)
                    Dim dt As DataTable = cls.FncGetReport(FrmMod, rpt.Name, day, IIf(Me.ddlChannel.Enabled, Me.ddlChannel.SelectedValue, "B"))
                    If Not Directory.Exists(rptPath) Then
                        Directory.CreateDirectory(rptPath)
                    End If
                    Dim FileName As String = String.Format("{0}-{1}.csv", rpt.ID, day.ToString("yyyyMMdd"))
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim writer As StreamWriter = New StreamWriter(rptPath & FileName)
                        writer.WriteLine(cls.FncWriteReportHeader(rpt.Name, IIf(Me.ddlChannel.Enabled, Me.ddlChannel.SelectedValue, "B")))
                        For Each dr As DataRow In dt.Rows
                            writer.WriteLine(String.Format("""{0}""", String.Join(""",""", dr.ItemArray.Select(Function(v) GFncNoNullString(v).Replace("""", """""")))))
                        Next
                        writer.Flush()
                        writer.Dispose()
                        writer.Close()
                        ZipFlag = True
                        Zip.AddFile(rptPath & FileName, "")
                    End If
                Next
                If ZipFlag Then
                    ContainsReports = True
                    Zip.Save(zipFileName)
                    For Each str As String In Directory.GetFiles(rptPath)
                        If File.Exists(str) Then
                            File.Delete(str)
                        End If
                    Next
                    mySendEmail(strTradeActivitySender, cls.FncGetReportParameters(rpt.Name, "EmailLst"), "Trading Activity Alert Report (" & rpt.ID & " - " & Format(DateTime.Now, "MMM dd, yyyy") & ")", " The reports have been generated, please check the attached files.", GStrEIP, zipFileName)
                End If
            Next
        Catch ex As Exception
            result = False
            GSubWriteELog(ex.Message)
        Finally
            Dim ReportPara As String = String.Format("Report ID: {0}, Report Date: {1} to {2}", Me.ddlRptName.SelectedValue, Me.dtpFrom.Value.ToString("dd/MM/yyyy"), Me.dtpTo.Value.ToString("dd/MM/yyyy"))
            If Me.ddlChannel.Enabled Then
                ReportPara = String.Format("{0}, Channel: {1}", ReportPara, Me.ddlChannel.SelectedValue)
            End If
            cls.WriteReportLog(FrmMod, Me.ddlRptName.Text, ReportPara, result)
            SetControls(True)
        End Try
        If ContainsReports Then
            GSubShowInfo(GFncGetSysMsg(104))
        Else
            GSubShowWarn("Report is not available for the selected period!")
        End If
    End Sub

    Public Class AlertReport

        Public Sub New(ByVal strID As String, ByVal strName As String)
            ID = strID.Substring(0, strID.IndexOf(" "))
            Name = strName
        End Sub

        Public Property ID As String
        Public Property Name As String
    End Class

End Class
