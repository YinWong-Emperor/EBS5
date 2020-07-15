Imports System.Threading
Imports System.Configuration

Public Class FrmImportData

    Private peFormStatus As EnumFormStatus
    Dim cls As New ClsImportData
    Dim importThread As Thread
    Dim progressThread As Thread

    Dim importThreadLock As Object = New Object()
    Dim progressThreadLock As Object = New Object()
    Private backupPath As String
    Private backupEnabled As String

    Private EmailSubjectPrefix As String = ""
    Private EmailFrom As String = ""
    Private EmailTo As String = ""
    Public DoImportIsDone = False

#Region "进度条更新"
    ' 用来区分每次Import，用于查询进度
    Private pImportCurrentGroup As String
    Private pImportCurrentStep As Integer
    Private pImportStepId As Integer
    Private pImportIsDone As Boolean
    'Private pFirstStepTimeoutCount As Integer = 60
    'Private pFirstStepCheckCount As Integer = 0
    Private Delegate Sub DlgSetProgress()
    Private importProgressHistories As DataTable
    Private DoneCount As Integer

    Private Sub SetProgress()

        If InvokeRequired Then
            Dim setPgs As DlgSetProgress
            setPgs = New DlgSetProgress(AddressOf Me.SetProgress)
            ' 从DB查询进度
            SyncLock progressThreadLock
                importProgressHistories = cls.FncGetProgress(pImportCurrentGroup, pImportStepId)
            End SyncLock
            Me.Invoke(setPgs)
        Else

            If importProgressHistories Is Nothing Then
                Return
            End If

            Try

                '有状态更新
                If importProgressHistories.Rows.Count > 0 Then
                    Dim currentStep As Integer
                    Dim totleStep As Integer
                    Dim message As String
                    Dim group As String
                    Dim createDate As Date

                    Dim percentNum As Integer

                    For Each row As DataRow In importProgressHistories.Rows
                        group = GFncNoNullString(row("group"))
                        Dim tempDoneCount As Integer = GFncNoNullIntValue(row("DoneCount"))
                        If tempDoneCount < DoneCount Then
                            showProgressText("Import data canceled or throw errors!")
                            InitData()
                            Return
                        End If
                        DoneCount = tempDoneCount

                        If Len(group) <= 0 Then
                            Continue For
                        End If

                        pImportStepId = GFncNoNullIntValue(row("id"))
                        currentStep = GFncNoNullIntValue(row("current_step"))
                        totleStep = GFncNoNullIntValue(row("totle_step"))
                        message = GFncNoNullString(row("message"))
                        createDate = GFncNoNullDate(row("create_date"))

                        If currentStep = 0 Or totleStep = 0 Then
                            showProgressText(String.Format("{0}", message))
                        Else
                            percentNum = pgbImport.Maximum * currentStep / totleStep
                            Me.pgbImport.Value = percentNum
                            showProgressText(String.Format("{2}", currentStep, totleStep, message))
                        End If

                        pImportCurrentStep = currentStep

                        ' 完成进度
                        'If currentStep > 0 And currentStep = totleStep Then
                        If currentStep = -1 And totleStep = -1 Then
                            pImportIsDone = True
                            SetStatus(EnumFormStatus.Search)
                            'cls.FncDeleteProgress()
                            'showProgressText("Import data done!")
                        End If
                    Next
                    importProgressHistories = Nothing

                End If

                '已经检查加1次
                'pFirstStepCheckCount = pFirstStepCheckCount + 1
                'If pFirstStepCheckCount > pFirstStepTimeoutCount And pImportCurrentStep <= 0 Then
                '    showProgressText("Import error: timeout(" + pFirstStepTimeoutCount + "s)")
                '    CancelImport()
                'End If
            Catch ex As Exception
                GSubWriteErrLog("ImportData Set Progress Error:" + ex.Message, "", True)
            End Try
        End If
    End Sub

    Private Sub showProgressText(ByVal message As String, Optional ByVal isError As Boolean = False)
        Me.txtMessage.AppendText(String.Format("{0} -> {1}{2}", Format(Now, "HH:mm:ss"), message, Chr(13) + Chr(10)))

        If isError Then
            GSubWriteErrLog(message, "", False)
        Else
            Dim logMessage As String = String.Format("{0} -> {1}", Format(Now, "yyyy-MM-dd HH:mm:ss"), message)
            GSubWriteEventLog(logMessage, GStrEPath)
        End If
    End Sub

#End Region

#Region "事件"

    Private Sub FrmImportData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnLoad()
    End Sub

    Public Sub OnLoad()
        InitData()
    End Sub

    Public Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Enabled Then
            GSubWriteEventLog(String.Format("{0} -> Import data, CurrentTradeDate:{1}, NextTradeDate:{2}", Format(Now, "yyyy-MM-dd HH:mm:ss"), lblCurrentTradeDate.Text, lblNextTradeDate.Text), GStrEPath)
            SetStatus(EnumFormStatus.Loading)
            '用一个Group来区分每一次Import
            pImportCurrentGroup = Guid.NewGuid().ToString()
            showProgressText("Begin import data!")
            importThread = New Thread(New ThreadStart(AddressOf DoImport))
            importThread.Start()
            progressThread = New Thread(New ThreadStart(AddressOf DoImportProgress))
            progressThread.Start()
        Else
            DoImportIsDone = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Not peFormStatus = EnumFormStatus.Loading Then
            Me.Close()
        Else
            If GSubShowYNConfirm("Do you confirm to cancel the import data?") = Windows.Forms.DialogResult.Yes Then
                CancelImport()
                showProgressText("User canceled")
            End If
        End If
    End Sub

#End Region

    Private Sub InitData()
        pImportCurrentGroup = ""
        pImportCurrentStep = 0
        pImportStepId = 0
        pImportIsDone = True
        DoneCount = 0

        Me.lblNextTradeDate.Text = Format(GDteTradeDate, "dd/MM/yyyy")
        Me.lblCurrentTradeDate.Text = ""

        Dim data As DataTable
        data = cls.FncGetTradeData()
        If data.Rows.Count > 0 Then
            Dim tradeDate As Date = GFncNoNullDate(data.Rows(0)("tradedate"))
            Dim procflag As Boolean = data.Rows(0)("procflag")
            'backupPath = GFncNoNullString(data.Rows(0)("backuppath"))
            'backupEnabled = GFncNoNullString(data.Rows(0)("backupenabled"))

            Me.lblCurrentTradeDate.Text = Format(tradeDate, "dd/MM/yyyy")
            If Not procflag Then
                Dim groupTB As Object = cls.FncGetExecutingGroup()
                If Not groupTB = Nothing And Not groupTB = "" Then
                    SetStatus(EnumFormStatus.Loading)
                    showProgressText(String.Format("Continue to import data of date {0}!", Format(GDteTradeDate, "dd/MM/yyyy")))
                    GSubWriteEventLog(String.Format("Continue to import data of date {0}!", Format(GDteTradeDate, "dd/MM/yyyy")), GStrEPath)
                    pImportCurrentGroup = groupTB
                    progressThread = New Thread(New ThreadStart(AddressOf DoImportProgress))
                    progressThread.Start()
                Else
                    SetStatus(EnumFormStatus.Invalid)
                    txtMessage.Text = String.Format("{0} data import failed!", Format(GDteTradeDate, "dd/MM/yyyy"))
                    GSubWriteEventLog(String.Format("{0} data import failed!", Format(GDteTradeDate, "dd/MM/yyyy")), GStrEPath)
                    txtMessage.ReadOnly = False
                    txtMessage.Enabled = False
                    txtMessage.ForeColor = Color.Red
                End If
            ElseIf tradeDate >= GDteTradeDate Then
                txtMessage.Text = String.Format("Already imported {0} data!", Format(GDteTradeDate, "dd/MM/yyyy"))
                GSubWriteEventLog(String.Format("Already imported {0} data!", Format(GDteTradeDate, "dd/MM/yyyy")), GStrEPath)
                txtMessage.ReadOnly = False
                txtMessage.Enabled = False
                txtMessage.ForeColor = Color.Red
                SetStatus(EnumFormStatus.Invalid)
            Else
                SetStatus(EnumFormStatus.Search)
            End If


            'If procflag And tradeDate < GDteTradeDate Then
            '    Me.lblCurrentTradeDate.Text = Format(tradeDate, "dd/MM/yyyy")
            '    SetStatus(EnumFormStatus.Search)
            'Else
            '    Me.lblCurrentTradeDate.Text = Format(tradeDate, "dd/MM/yyyy") + " X "
            '    SetStatus(EnumFormStatus.Invalid)
            'End If
        Else
            SetStatus(EnumFormStatus.Invalid)

        End If

        EmailSubjectPrefix = ConfigurationSettings.AppSettings.GetValues("ImportData_EmailSubjectPrefix")(0).ToString()
        EmailFrom = ConfigurationSettings.AppSettings.GetValues("ImportData_EmailSender")(0).ToString()
        EmailTo = ConfigurationSettings.AppSettings.GetValues("ImportData_EmailTo")(0).ToString()
    End Sub
    Private Sub SetMessage()
    End Sub
    Private Sub CancelImport()
        'pImportIsDone = True

        ' ''停止进程任务
        ''SyncLock importThreadLock
        ''    If Not IsNothing(importThread) Then
        ''        If importThread.IsAlive Then
        ''            importThread.Join(5000)
        ''        End If
        ''        importThread = Nothing
        ''    End If
        ''End SyncLock
        ''SyncLock progressThreadLock
        ''    If Not IsNothing(progressThread) Then
        ''        If progressThread.IsAlive Then
        ''            progressThread.Join(5000)
        ''        End If
        ''        progressThread = Nothing
        ''    End If
        ''End SyncLock
        'SetStatus(EnumFormStatus.Search)
        InitData()
    End Sub

    Private Sub DoImport()
        Dim result As String

        'If backupEnabled = "1" Then
        '    ImportMessageHandle("Begin backup database!")
        '    If Not GFncBackup(backupPath) Then
        '        ImportErrorHandle("Import backup Error!")
        '        Return
        '    Else
        '        ImportMessageHandle("Backup database Finished!")
        '    End If
        'End If

        Try
            result = cls.FncImportData(pImportCurrentGroup, GDteTradeDate)
        Finally
            pImportIsDone = True
        End Try

        If Not result Is Nothing Then
            ImportErrorHandle("Import Error: " + result)
            mySendEmail(EmailFrom, EmailTo, EmailSubjectPrefix & " - [FAIL] - Liq. Data Imported " & Format(GDteTradeDate, "dd/MM/yyyy"), "Import Error: " & result, GStrEIP)
            Return
        Else
            Dim actionTarget As Action
            actionTarget = Sub() ImportDoneHandle()
            Me.Invoke(actionTarget)
            mySendEmail(EmailFrom, EmailTo, EmailSubjectPrefix & " - [SUCCESS] - Liq. Data Imported " & Format(GDteTradeDate, "dd/MM/yyyy"), "Liq. Data Imported sucessfully ", GStrEIP)
        End If
        DoImportIsDone = True
    End Sub

    Private Sub ImportDoneHandle()

        'GSubShowInfo("Import data success!")
        Dim Message As String = "Import data success!"
        Dim messageTarget As Action(Of String)
        messageTarget = Sub(s) showProgressText(s, False)
        Me.Invoke(messageTarget, New Object() {Message})

        Me.lblNextTradeDate.Text = Format(GDteTradeDate, "dd/MM/yyyy")
        Me.lblCurrentTradeDate.Text = ""
        Dim data As DataTable
        data = cls.FncGetTradeData()
        If data.Rows.Count > 0 Then
            Dim tradeDate As Date = GFncNoNullDate(data.Rows(0)("tradedate"))
            Dim procflag As Boolean = data.Rows(0)("procflag")
            Me.lblCurrentTradeDate.Text = Format(tradeDate, "dd/MM/yyyy")
        End If

        SetStatus(EnumFormStatus.Invalid)
    End Sub

    Private Sub ImportMessageHandle(ByVal message As String)
        ' 转主线程处理UI信息
        Dim messageTarget As Action(Of String)
        messageTarget = Sub(s) showProgressText(s)
        Me.Invoke(messageTarget, New Object() {message})
    End Sub

    Private Sub ImportErrorHandle(ByVal message As String)
        ' 转主线程处理UI信息
        Dim messageTarget As Action(Of String)
        messageTarget = Sub(s) showProgressText(s, True)
        Me.Invoke(messageTarget, New Object() {message})

        Dim messageTarget2 As Action
        messageTarget2 = Sub() CancelImport()
        Me.Invoke(messageTarget2)

    End Sub

    Private Sub DoImportProgress()
        ' 初始化变量
        'pFirstStepCheckCount = 0
        pImportCurrentStep = 0
        pImportIsDone = False
        While Not pImportIsDone
            Thread.Sleep(1000)
            SetProgress()
        End While
    End Sub

    Private Sub SetStatus(ByVal status As EnumFormStatus)
        peFormStatus = status

        pgbImport.Visible = status = EnumFormStatus.Loading
        Me.btnCancel.Enabled = Not status = EnumFormStatus.Loading
        Me.btnSave.Enabled = status = EnumFormStatus.Search

    End Sub

End Class