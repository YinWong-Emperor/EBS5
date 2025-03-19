Imports System.IO
Imports System.Data
Imports System.Net.Mail
Imports System.Text

Public Class ClsPwdNotifyS

    Protected Friend strLangE As String = "1"
    Protected Friend strLangT As String = "2"
    Protected Friend strLangS As String = "3"
    Protected Friend strTradeAFE As String = "AFE"
    Protected Friend strTradeTTL As String = "TTL"
    Protected Friend strTradeBoth As String = "AFETTL"
    Protected Friend strEIP As String
    Protected Friend emailSender As String

    Protected Friend Function getClientInfo(ByVal accno As String) As DataSet
        Dim lstrsql As String = "select rtrim(name_1) as name_1, rtrim(name_1_c) as name_1_c, rtrim(email) as email " & _
                                                 "from " & GStrG2BSPRODDB & ".dbo.client_master cm, " & GStrG2BSPRODDB & ".dbo.clientadd_master ca " & _
                                                 "where cm.aid = ca.aid and accno = '" & accno & "'"
        Return GFncRtnDS(GSCnSqlConn, lstrsql, 0)
    End Function

    Protected Friend Function validateEmail(ByVal email As String) As Boolean
        Dim Expression As New RegularExpressions.Regex("\S+@\S+\.\S+")
        Return Expression.IsMatch(email)
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

    Protected Friend Function getTxtContent(ByVal displayLang As String, ByVal username As String, _
    ByVal tradecode As String, ByVal strTrade As String) As String

        Dim content As String = ""

        'If (displayLang = strLangE) Then
        '    content = setClientInfo(My.Resources.secTextE.ToString, username, tradecode)
        'ElseIf (displayLang = strLangT) Then
        '    content = setClientInfo(My.Resources.secTextT.ToString, username, tradecode)
        'ElseIf (displayLang = strLangS) Then
        '    content = setClientInfo(My.Resources.secTextS.ToString, username, tradecode)
        'End If

        If (displayLang = strLangE) Then
            Select Case strTrade
                Case strTradeBoth
                    content = setClientInfo(My.Resources.PN_template_eng_both.ToString, username, tradecode)
                Case strTradeTTL
                    content = setClientInfo(My.Resources.PN_template_eng_ttl_only.ToString, username, tradecode)
                Case Else
                    content = setClientInfo(My.Resources.PN_template_eng_afe_only.ToString, username, tradecode)
            End Select
        ElseIf (displayLang = strLangT) Then
            Select Case strTrade
                Case strTradeBoth
                    content = setClientInfo(My.Resources.PN_template_tc_both.ToString, username, tradecode)
                Case strTradeTTL
                    content = setClientInfo(My.Resources.PN_template_tc_ttl_only.ToString, username, tradecode)
                Case Else
                    content = setClientInfo(My.Resources.PN_template_tc_afe_only.ToString, username, tradecode)
            End Select
        ElseIf (displayLang = strLangS) Then
            Select Case strTrade
                Case strTradeBoth
                    content = setClientInfo(My.Resources.PN_template_sc_both.ToString, username, tradecode)
                Case strTradeTTL
                    content = setClientInfo(My.Resources.PN_template_sc_ttl_only.ToString, username, tradecode)
                Case Else
                    content = setClientInfo(My.Resources.PN_template_sc_afe_only.ToString, username, tradecode)
            End Select
        End If

        Return content

    End Function

    Protected Friend Function setClientInfo(ByVal content As String, ByVal username As String, ByVal password As String) As String

        If (InStr(content, "%USERNAME%") > 0) Then
            content = content.Replace("%USERNAME%", username)
        End If

        If (InStr(content, "%TRADE_CODE%") > 0) Then
            content = content.Replace("%TRADE_CODE%", password)
        End If

        Return content

    End Function

    Public Sub mySendEmail(ByVal myfrom As String, ByVal myTo As String, ByVal mySub As String, ByVal username As String, _
                                ByVal password As String, ByVal displayLang As String, ByVal accno As String, _
                                ByVal strTrade As String)

        Dim accname As String = username
        Dim oMsg As New MailMessage
        Dim myCredentials As New System.Net.NetworkCredential
        Dim myMessage As String = ""

        myCredentials.UserName = ""
        myCredentials.Password = ""

        Dim mySmtpsvr As New SmtpClient()
        mySmtpsvr.Host = strEIP
        mySmtpsvr.Port = 25

        mySmtpsvr.UseDefaultCredentials = False
        mySmtpsvr.Credentials = myCredentials

        If (displayLang = strLangS) Then
            accname = StrConv(username, VbStrConv.SimplifiedChinese, 2052)
        End If

        oMsg.IsBodyHtml = False

        Try
            oMsg.From = New MailAddress(myfrom, "")
            oMsg.To.Add(myTo)
            oMsg.Subject = mySub
            oMsg.Body = getTxtContent(displayLang, accname, password, strTrade)
            mySmtpsvr.Send(oMsg)

            lFncWriteLog(accno, username, myTo)
            GSubShowInfo(GFncGetSysMsg(4) & myTo)

        Catch exFormat As FormatException
            GSubShowInfo(GFncGetSysMsg(19))
        Catch ex As Exception
            GSubWriteErrLog(Format(Now, "yyyy/MM/dd HH:mm:ss") & " email sender: " & ex.Message)
        End Try

    End Sub

    Protected Friend Function lFncWriteLog(ByVal accno As String, ByVal accname As String, ByVal email As String) As Long
        Dim lstrSQL As String = "insert into LOGTBL(D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, D_TXMONTH, D_LOG) " & _
                                                    "values ('" & GStrloginID & "', getdate(), 'S', 'PwdNotifyS', '', '" & accno & "', getdate(), '', " & _
                                                    "'', '[Client]= ''" & GFncSqlQuote(accname) & "'' [Email]=''" & email & "'' ') "

        Return GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
    End Function

End Class
