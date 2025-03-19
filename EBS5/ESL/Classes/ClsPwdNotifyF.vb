Imports System.IO
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Resources

Public Class ClsPwdNotifyF

    Protected Friend displayhtml As String = "1"
    Protected Friend displaytext As String = "2"
    Protected Friend strLangE As String = "1"
    Protected Friend strLangT As String = "2"
    Protected Friend strLangS As String = "3"
    Protected Friend strEIP As String
    Protected Friend emailSender As String

    Protected Friend Function getClientInfo(ByVal accno As String) As DataSet

        Dim lstrsql As String

        lstrsql = "select rtrim(name_1) as name_1, rtrim(name_1_c) as name_1_c, rtrim(email) as email, tradecode " & _
                    "from " & GStrG2BFPRODDB & ".dbo.client_master cm, " & GStrG2BFPRODDB & ".dbo.client_tradecode ct, " & _
                    GStrG2BFPRODDB & ".dbo.clientadd_master ca " & _
                    "where cm.aid = ct.aid and cm.aid = ca.aid and accno = '" & accno & "'"
        Return GFncRtnDS(GSCnSqlConn, lstrsql, 0)

    End Function

    Protected Friend Function validateEmail(ByVal email As String) As Boolean

        Return (InStr(email, "@") > 0)

    End Function

    Protected Friend Function isErrorDomain(ByVal email As String) As Boolean

        Dim lstrsql As String
        Dim lds As DataSet

        lstrsql = "select email from InvalidEmail "
        lds = GFncRtnDS(GSCnSqlConn, lstrsql, 0)

        If (lds.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0

            While i < lds.Tables(0).Rows.Count
                If (InStr(email, LCase(lds.Tables(0).Rows(i).Item("email"))) > 0) Then
                    Return True
                End If
                i = i + 1
            End While
            Return False
        End If

        Return False

    End Function

    Protected Friend Sub getEmailSetting()

        'Dim lline As String
        'Dim key As String
        'Dim val As String
        'Dim sReaderPath As StreamReader

        Try
            'sReaderPath = New StreamReader(GStrConnFile)
            'If Not sReaderPath.EndOfStream Then
            '    lline = sReaderPath.ReadLine
            '    sReaderPath.Close()

            '    sReaderPath = New StreamReader(lline)

            '    sReaderPath.BaseStream.Seek(0, SeekOrigin.Begin)
            '    While sReaderPath.Peek() > -1
            '        lline = sReaderPath.ReadLine()
            '        key = Mid(lline, 1, InStr(lline, "=") - 1)
            '        val = Mid(lline, InStr(lline, "=") + 1, lline.Length - InStr(lline, "="))

            '        If (key = "emailip") Then
            '            strEIP = val
            '        ElseIf (key = "sender") Then
            '            emailSender = val
            '        End If
            '    End While
            '    sReaderPath.Close()
            'End If
            strEIP = System.Configuration.ConfigurationManager.AppSettings.Get("EmailHost")
            emailSender = System.Configuration.ConfigurationManager.AppSettings.Get("EmailSender")
        Catch ex As Exception
            GSubShowWarn("Get Email Setting Fail!" & " " & ex.Message)
            Application.Exit()
        End Try

    End Sub

    Public Sub clearTempImage()

        Dim di As IO.DirectoryInfo
        Dim diar1 As IO.FileInfo()
        Dim dra As IO.FileInfo

        If (IO.Directory.Exists(Application.StartupPath & "\images") = True) Then
            di = New IO.DirectoryInfo(Application.StartupPath & "\images")
            diar1 = di.GetFiles()

            For Each dra In diar1
                dra.Delete()
            Next
        End If

    End Sub

    Public Function getHtmlContent(ByVal displayLang As String, ByVal username As String, ByVal tradecode As String) As String

        Dim content As String = ""

        If (displayLang = strLangE) Then
            content = setClientInfo(My.Resources.htmlE.ToString, username, tradecode)
        ElseIf (displayLang = strLangT) Then
            content = setClientInfo(My.Resources.htmlT.ToString, username, tradecode)
        ElseIf (displayLang = strLangS) Then
            content = setClientInfo(My.Resources.htmlS.ToString, username, tradecode)
        End If

        Return content

    End Function

    Public Function getTxtContent(ByVal displayLang As String, ByVal username As String, ByVal tradecode As String) As String

        Dim content As String = ""

        If (displayLang = strLangE) Then
            content = setClientInfo(My.Resources.textE.ToString, username, tradecode)
        ElseIf (displayLang = strLangT) Then
            content = setClientInfo(My.Resources.textT.ToString, username, tradecode)
        ElseIf (displayLang = strLangS) Then
            content = setClientInfo(My.Resources.textS.ToString, username, tradecode)
        End If

        Return content

    End Function

    Public Function setClientInfo(ByVal content As String, ByVal username As String, ByVal tradecode As String) As String

        'for replace trade code
        If (InStr(content, "%USERNAME%") > 0) Then
            content = content.Replace("%USERNAME%", username)
        End If

        If (InStr(content, "%TRADE_CODE%") > 0) Then
            content = content.Replace("%TRADE_CODE%", tradecode)
        End If

        Return content

    End Function

    Public Sub generateImage(ByVal lang As String)

        If (IO.Directory.Exists(Application.StartupPath & "\images") = False) Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\images")
        End If

        If (lang = strLangE) Then
            My.Resources.en_but_guide.Save(Application.StartupPath & "\images\en_but_guide.jpg")
            My.Resources.en_but_hk_dl.Save(Application.StartupPath & "\images\en_but_hk_dl.jpg")
            My.Resources.en_but_dl.Save(Application.StartupPath & "\images\en_but_dl.jpg")
            My.Resources.en_but_install.Save(Application.StartupPath & "\images\en_but_install.jpg")
            My.Resources.en_subtitle_local_rule.Save(Application.StartupPath & "\images\en_subtitle_local_rule.jpg")
            My.Resources.en_subtitle_global_rule.Save(Application.StartupPath & "\images\en_subtitle_global_rule.jpg")
            My.Resources.en_login_demo.Save(Application.StartupPath & "\images\en_login_demo.jpg")
            My.Resources.en_subtitle_password.Save(Application.StartupPath & "\images\en_subtitle_password.jpg")
            My.Resources.en_subtitle_spec.Save(Application.StartupPath & "\images\en_subtitle_spec.jpg")
            My.Resources.en_title_platform_dl.Save(Application.StartupPath & "\images\en_title_platform_dl.jpg")
            My.Resources.en_title_platform_install.Save(Application.StartupPath & "\images\en_title_platform_install.jpg")
            My.Resources.en_title_platform_login.Save(Application.StartupPath & "\images\en_title_platform_login.jpg")
            My.Resources.en_title_platform_operation.Save(Application.StartupPath & "\images\en_title_platform_operation.jpg")
        ElseIf (lang = strLangT) Then
            My.Resources.tc_but_guide.Save(Application.StartupPath & "\images\tc_but_guide.jpg")
            My.Resources.tc_but_hk_dl.Save(Application.StartupPath & "\images\tc_but_hk_dl.jpg")
            My.Resources.tc_but_dl.Save(Application.StartupPath & "\images\tc_but_dl.jpg")
            My.Resources.tc_but_install.Save(Application.StartupPath & "\images\tc_but_install.jpg")
            My.Resources.tc_subtitle_local_rule.Save(Application.StartupPath & "\images\tc_subtitle_local_rule.jpg")
            My.Resources.tc_subtitle_global_rule.Save(Application.StartupPath & "\images\tc_subtitle_global_rule.jpg")
            My.Resources.tc_login_demo.Save(Application.StartupPath & "\images\tc_login_demo.jpg")
            My.Resources.tc_subtitle_password.Save(Application.StartupPath & "\images\tc_subtitle_password.jpg")
            My.Resources.tc_subtitle_spec.Save(Application.StartupPath & "\images\tc_subtitle_spec.jpg")
            My.Resources.tc_title_platform_dl.Save(Application.StartupPath & "\images\tc_title_platform_dl.jpg")
            My.Resources.tc_title_platform_install.Save(Application.StartupPath & "\images\tc_title_platform_install.jpg")
            My.Resources.tc_title_platform_login.Save(Application.StartupPath & "\images\tc_title_platform_login.jpg")
            My.Resources.tc_title_platform_operation.Save(Application.StartupPath & "\images\tc_title_platform_operation.jpg")
        ElseIf (lang = strLangS) Then
            My.Resources.sc_but_guide.Save(Application.StartupPath & "\images\sc_but_guide.jpg")
            My.Resources.sc_but_hk_dl.Save(Application.StartupPath & "\images\sc_but_hk_dl.jpg")
            My.Resources.sc_but_dl.Save(Application.StartupPath & "\images\sc_but_dl.jpg")
            My.Resources.sc_but_install.Save(Application.StartupPath & "\images\sc_but_install.jpg")
            My.Resources.sc_subtitle_local_rule.Save(Application.StartupPath & "\images\sc_subtitle_local_rule.jpg")
            My.Resources.sc_subtitle_global_rule.Save(Application.StartupPath & "\images\sc_subtitle_global_rule.jpg")
            My.Resources.sc_login_demo.Save(Application.StartupPath & "\images\sc_login_demo.jpg")
            My.Resources.sc_subtitle_password.Save(Application.StartupPath & "\images\sc_subtitle_password.jpg")
            My.Resources.sc_subtitle_spec.Save(Application.StartupPath & "\images\sc_subtitle_spec.jpg")
            My.Resources.sc_title_platform_dl.Save(Application.StartupPath & "\images\sc_title_platform_dl.jpg")
            My.Resources.sc_title_platform_install.Save(Application.StartupPath & "\images\sc_title_platform_install.jpg")
            My.Resources.sc_title_platform_login.Save(Application.StartupPath & "\images\sc_title_platform_login.jpg")
            My.Resources.sc_title_platform_operation.Save(Application.StartupPath & "\images\sc_title_platform_operation.jpg")
        End If

        My.Resources.all_caution.Save(Application.StartupPath & "\images\all_caution.jpg")
        My.Resources.all_icon.Save(Application.StartupPath & "\images\all_icon.jpg")
        My.Resources.all_logo.Save(Application.StartupPath & "\images\all_logo.jpg")
        'My.Resources.en_subtitle_rule.Save(Application.StartupPath & "\images\subtitle_rule.jpg")

    End Sub

    Public Sub mySendEmail(ByVal myfrom As String, ByVal myTo As String, ByVal mySub As String, ByVal username As String, _
                                ByVal trade_code As String, ByVal displayFormat As String, ByVal displayLang As String, _
                                ByVal accno As String)

        Dim accname As String = username
        Dim oMsg As New MailMessage
        Dim myCredentials As New System.Net.NetworkCredential
        Dim myMessage As String = ""
        Dim HTMLAlternate As AlternateView = Nothing
        Dim PictureResource = Nothing
        'Dim imagePath As String = Application.StartupPath & ""

        myCredentials.UserName = ""
        myCredentials.Password = ""

        Dim mySmtpsvr As New SmtpClient()
        mySmtpsvr.Host = strEIP
        mySmtpsvr.Port = 25

        mySmtpsvr.UseDefaultCredentials = False
        mySmtpsvr.Credentials = myCredentials

        If (displayFormat = displayhtml) Then
            oMsg.IsBodyHtml = True
        Else
            oMsg.IsBodyHtml = False
        End If

        If (displayLang = strLangS) Then
            accname = StrConv(username, VbStrConv.SimplifiedChinese, 2052)
        End If

        Try
            oMsg.From = New MailAddress(myfrom, "")
            oMsg.To.Add(myTo)
            oMsg.Subject = mySub

            If (displayFormat = displayhtml) Then
                clearTempImage()

                oMsg.IsBodyHtml = True

                myMessage = getHtmlContent(displayLang, accname, trade_code)
                generateImage(displayLang)
                oMsg.Body = myMessage

                HTMLAlternate = AlternateView.CreateAlternateViewFromString(myMessage, Nothing, "text/html")
                Dim di As IO.DirectoryInfo
                Dim diar1 As IO.FileInfo()
                Dim dra As IO.FileInfo

                If (IO.Directory.Exists(Application.StartupPath & "\images") = False) Then
                    GSubWriteErrLog(Format(Now, "yyyy/MM/dd HH:mm:ss") & Application.StartupPath & "\images not exist")
                End If

                di = New IO.DirectoryInfo(Application.StartupPath & "\images")
                diar1 = di.GetFiles()

                For Each dra In diar1
                    Dim IDName As String = Right(dra.FullName, dra.FullName.Length - dra.DirectoryName.Length - 1)
                    IDName = Left(IDName, IDName.Length - 4)
                    Dim FullyQualifiedPathString As String = dra.FullName
                    PictureResource = New LinkedResource(FullyQualifiedPathString)
                    PictureResource.ContentId = IDName
                    HTMLAlternate.LinkedResources.Add(PictureResource)
                Next
                oMsg.AlternateViews.Add(HTMLAlternate)
            Else
                oMsg.IsBodyHtml = False
                oMsg.Body = getTxtContent(displayLang, accname, trade_code)
            End If

            mySmtpsvr.Send(oMsg)

            lFncWriteLog(accno, username, myTo)

            If Not (HTMLAlternate Is Nothing) Then
                HTMLAlternate.Dispose()
                clearTempImage()
            End If

            GSubShowInfo(GFncGetSysMsg(4) & myTo)
        Catch ex As Exception
            GSubWriteErrLog(Format(Now, "yyyy/MM/dd HH:mm:ss") & " email sender: " & ex.Message)
        End Try

    End Sub

    Protected Friend Function lFncWriteLog(ByVal accno As String, ByVal accname As String, ByVal email As String) As Long

        Dim lstrSQL As String = ""

        lstrSQL = "insert into LOGTBL(D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, D_TXMONTH, D_LOG) " & _
                        "values ('" & GStrloginID & "', getdate(), 'S', 'PwdNotifyF', '', '" & accno & "', getdate(), '', " & _
                        "'', '[Client]= ''" & GFncSqlQuote(accname) & "'' [Email]=''" & email & "'' ') "
        Return GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Return 0

    End Function

End Class
