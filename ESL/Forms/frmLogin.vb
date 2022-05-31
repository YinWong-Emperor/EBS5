Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Reflection

Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Dim clslogin As New clsLogin
    Dim lintNoOfTry As Integer = 0

    Public Sub CreateConnection()
        'create global connection
        clslogin.RD_CONG(CboBranch.Text)

        If GIsUAT Then
            GSubCreateConnection("UAT")
        Else
            GSubCreateConnection(clslogin.GFncGetBCode(CboBranch.Text))
        End If

        GSCnGLConn = GSubCreateESLConnection("GL")
        GSCnLiqConn = GSubCreateESLConnection("LIQ")
        GSCnBalConn = GSubCreateESLConnection("BAL", GStrBalDB)
        GStrG2BSPRODDB = GSubGetESLDB("PG2BS")
        GStrG2BFPRODDB = GSubGetESLDB("PG2BF")
        GStrG2BSDB = GSubGetESLDB("G2BS")
        GStrG2BFDB = GSubGetESLDB("G2BF")
        GStrG2BSLMTHDB = GSubGetESLDB("LG2BS")
        GStrG2BFLMTHDB = GSubGetESLDB("LG2BF")
        'Start v2.1.0.1 Chris
        GStrG2BSLYRDB = GSubGetESLDB("YG2BS")
        GStrG2BFLYRDB = GSubGetESLDB("YG2BF")
        'End v2.1.0.1 Chris
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim frm As New frmMenu
        CreateConnection()
        If chkAppInfo() = True Then
            If TxtNewP1.Visible = True Then
                If TxtNewP1.Text.Length < 6 Then
                    GSubShowInfo("Please enter password contains at least 6 characters")
                    TxtNewP1.Focus()
                    Exit Sub
                End If

                If TxtNewP1.Text <> TxtNewP2.Text Then
                    GSubShowInfo(GFncGetSysMsg(23))
                    TxtNewP2.Focus()
                Else
                    If clslogin.GFncChkPwdRepeat(TxtNewP1.Text, TxtNewP1.Text) = True Then
                        GSubShowInfo(GFncGetSysMsg(26))
                        TxtNewP1.Focus()
                    Else
                        Dim MyTrans As SqlTransaction
                        MyTrans = GSCnSqlConn.BeginTransaction
                        Try
                            If GFncRunSQL(GSCnSqlConn, MyTrans, "Update User_Information set UiPassword = '" & GFncGetMd5Hash(TxtNewP1.Text) & "', Uiexpire = '" & Format(DateAdd(DateInterval.Day, 30, Now), "yyyy/MM/dd") & "', UiFChgPwd = 0 where UiUserId = '" & txtUserID.Text & "'") > 0 Then 'And _
                                'GFncRunSQL(GSCnSqlConn, MyTrans, "Insert into password_history values ('" & txtUserID.Text & "',getdate(), '" & GFncGetMd5Hash(TxtNewP1.Text) & "','" & txtUserID.Text & "', getdate())") > 0 Then
                                MyTrans.Commit()
                                If clslogin.GFncChkLogIn(txtUserID.Text.Trim, TxtNewP1.Text.Trim) Then
                                    GStrloginID = txtUserID.Text.Trim
                                    GDteTradeDate = GFncGetTDate()
                                    'If clslogin.CHK_DATE(txtUserID.Text.Trim) = True Then
                                    frm.Show()
                                    Me.Hide()
                                    'End If
                                Else
                                    lintNoOfTry += 1
                                    GSubDisposeConnection(GSCnSqlConn)
                                    'GSubDisposeConnection(GSCnPriceConn)
                                End If
                            Else
                                MyTrans.Rollback()
                                GSubDisposeConnection(GSCnSqlConn)
                                'GSubDisposeConnection(GSCnPriceConn)
                            End If
                        Catch ex As Exception
                            If GSCnSqlConn.State <> ConnectionState.Closed Then
                                MyTrans.Rollback()
                                GSubDisposeConnection(GSCnSqlConn)
                                'GSubDisposeConnection(GSCnPriceConn)
                            End If
                        End Try
                    End If
                End If
            Else
                If clslogin.GFncChkLogIn(txtUserID.Text.Trim, txtPwd.Text.Trim) Then
                    GStrloginID = txtUserID.Text.Trim

                    'If clslogin.CHK_DATE(txtUserID.Text.Trim) = True Then
                    GDteTradeDate = GFncGetTDate()
                    frm.Show()
                    Me.Hide()
                    'End If
                Else
                    lintNoOfTry += 1
                    If lintNoOfTry > 3 Then
                        GSubShowWarn(GFncGetSysMsg(112))
                        Me.Close()
                    End If
                    GSubDisposeConnection(GSCnSqlConn)
                    'GSubDisposeConnection(GSCnPriceConn)
                End If
            End If

            GDtClientCode = GfncGetClientCode()

            'Else
            'CboBranch.Focus()
        End If
    End Sub

    'check application version match with DB required version
    Private Function chkAppInfo() As Boolean
        Dim lstrSQL As String = ""
        Dim ldtsApp As DataSet
        Dim ldtwApp As DataRow
        Dim lintDBVer As Integer = 0
        Dim lintAppVer As Integer = 0

        If UCase(GStrIsReportDB) = "Y" Then
            Return True
        End If
        Try
            lstrSQL = "Select * from APP_INFO"

            ldtsApp = GFncRtnDS(GSCnSqlConn, lstrSQL)

            If ldtsApp.Tables(0).Rows.Count > 0 Then
                ldtwApp = ldtsApp.Tables(0).Rows(0)
                lintDBVer = CType(Replace(ldtwApp.Item("app_ver"), ".", ""), Integer)
                lintAppVer = CType(Replace(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString, ".", ""), Integer)

                If ldtwApp("app_ver").ToString = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString Then
                    Return True
                ElseIf lintAppVer > lintDBVer Then
                    lstrSQL = "Update APP_INFO Set app_ver = '" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & "'"
                    GFncRunSQL(GSCnSqlConn, lstrSQL)
                    Return True
                    'Else
                    '    GSubShowWarn("Application version (" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & ") " & _
                    '                "not match with database required version (" & ldtwApp("app_ver").ToString & ")" & vbCrLf & _
                    '                "Please update your application version.")
                    'Return False
                Else
                    Return True
                End If
            Else
                'Return False
                Return True
            End If
        Catch ex As Exception
            GSubShowWarn(ex.Message)
            Return False
        End Try

    End Function

    'Encrypt Connection String in app.config file
    Private Shared Sub ProtectSection()

        ' Get the current configuration file.
        Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As ConnectionStringsSection

        section = _
            CType(config.GetSection("connectionStrings"), ConnectionStringsSection)

        If Not section.SectionInformation.IsProtected Then
            If Not section.ElementInformation.IsLocked Then
                ' Protect (encrypt)the section.
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider")

                ' Save the encrypted section.
                section.SectionInformation.ForceSave = True

                config.Save(ConfigurationSaveMode.Minimal)
            End If
        End If

        ' Display decrypted configuration 
        ' section. Note, the system
        ' uses the Rsa provider to decrypt
        ' the section transparently.
        'Dim sectionXml As String = _
        'section.SectionInformation.GetRawXml()

        'Console.WriteLine("Decrypted section:")
        'Console.WriteLine(sectionXml)

    End Sub 'ProtectSection

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub OnLoad()
        Dim myCulture As New CultureInfo("zh-HK")

        Application.CurrentCulture = myCulture
        GIsUAT = InStr(Assembly.GetExecutingAssembly.GetName.Name.ToString.ToLower, "uat") > 0

        GSubSetTextBoxGotFocus(Me)
        GSubSetControlMoveNext(Me)
        GSubSetSMTP()
        GSubCreateCConnection()

        Dim StrIP As String
        Dim StrBCode As String = ""
        Dim h As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName)
        StrIP = h.AddressList.GetValue(0).ToString

        Dim strSQL As String = ""
        Dim strBrhs As String = ""
        Dim intCount As Integer

        If GArrShowBrh.Count > 0 Then
            For intCount = 0 To GArrShowBrh.Count - 1
                strBrhs &= "'" & GArrShowBrh.Item(intCount).ToString & "',"
            Next
            strBrhs = Microsoft.VisualBasic.Left(strBrhs, Len(strBrhs) - 1)
        Else
            strBrhs = "''"
        End If

        If strBrhs = "'MLT'" Then
            strSQL = "Select cg.* from Config cg, Connection_information ci where cg.cfgbranchcode = ci.cifchrservertype " & _
                        "and ci.cifchrsystem = 'ESL' order by CfgBranchName"
        ElseIf GIsUAT Then
            strSQL = "Select * from Config where cfgbranchcode = 'ESL_UAT'"
        Else
            strSQL = "Select cg.* from Config cg, Connection_information ci where cg.CfgBranchCode IN (" & strBrhs & ") " & _
                        " and cg.cfgbranchcode = ci.cifchrservertype and ci.cifchrsystem = 'ESL' order by cg.CfgBranchName"
        End If

        Try
            Dim lscmCommand As New SqlCommand
            Dim ladpAdapter As SqlDataAdapter
            Dim dtsBranch As New DataSet
            Dim dtwBranch As DataRow

            If strSQL <> "" Then
                lscmCommand.Connection = GSCnConConn
                lscmCommand.CommandText = strSQL
                ladpAdapter = New SqlDataAdapter(lscmCommand)

                ladpAdapter.Fill(dtsBranch)
                lscmCommand = Nothing
                ladpAdapter = Nothing
            Else
                dtsBranch = Nothing
            End If

            'dtsBranch = GFncRtnDS(GSCnConConn, strSQL)

            CboBranch.Items.Clear()
            For Each dtwBranch In dtsBranch.Tables(0).Rows
                CboBranch.Items.Add(dtwBranch.Item("CfgBranchName"))
            Next
            dtsBranch.Dispose()

            If CboBranch.Items.Count > 0 Then
                CboBranch.SelectedIndex = 0
            End If

            'display application version
            lblVersion.Text = "Version " & Assembly.GetExecutingAssembly.GetName.Version.ToString
            If GIsUAT Then lblVersion.Text &= " (UAT)"

            GStrDomainUser = System.Security.Principal.WindowsIdentity.GetCurrent.Name.Replace("\", "/")
        Catch ex As Exception
            GSubShowWarn(ex.Message)
            End
        End Try

    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ProtectSection()
        OnLoad()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Get SQL connection file info from parameter path
        'If My.Application.CommandLineArgs.Count > 0 Then
        '    GStrConnFile = My.Application.CommandLineArgs(0)
        '    If InStr(GStrConnFile, "\", CompareMethod.Text) <= 0 And GStrConnFile <> "" Then
        '        GStrConnFile = Application.StartupPath & "\" & GStrConnFile
        '    End If
        'Else
        '    GStrConnFile = ""
        'End If
        'GStrConnFile = "C:\ESL\start.ini"
        'GStrConnFile = String.Format("C:\{0}\start.ini", System.Reflection.Assembly.GetExecutingAssembly.GetName.Name.ToString)
        'GStrConnFile = "\\10.130.12.13\ebs\EBS4\start.ini"
    End Sub

End Class
