Imports System.Data.SqlClient
'Imports System.Security.Cryptography
'Imports System.Text

Public Class clsLogin

    Protected Friend Function GFncChkLogIn(ByVal strUserID As String, ByVal strPwd As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lcmdLogin As New SqlCommand
        'Dim ldtrLogin As SqlDataReader
        Dim ldtsLogin As New DataSet
        Dim lblnLogin As Boolean = False

        lstrSQL = "Select * from user_information Where uiUserID = '" & strUserID & "' "

        'ldtrLogin = GFncRtnDR(lstrSQL)
        ldtsLogin = GFncRtnDS(GSCnSqlConn, lstrSQL)

        'If ldtrLogin.HasRows Then
        If ldtsLogin.Tables(0).Rows.Count > 0 Then
            'ldtrLogin.Read()
            'If ldtrLogin.Item("UiActive") = False Then
            If ldtsLogin.Tables(0).Rows(0).Item("UiActive") = False Then
                GSubShowInfo(GFncGetSysMsg(15))
                lblnLogin = False
            Else
                'If GFncGetMd5Hash(strPwd) = ldtrLogin("uiPassword") Then
                If GFncGetMd5Hash(strPwd) = ldtsLogin.Tables(0).Rows(0).Item("uiPassword") Then
                    If GFncChkExpire(strUserID) = True Then
                        GSubShowInfo(GFncGetSysMsg(17))
                        lblnLogin = False
                        frmLogin.Label1.Visible = True
                        frmLogin.Label2.Visible = True
                        frmLogin.TxtNewP1.Visible = True
                        frmLogin.TxtNewP2.Visible = True
                        frmLogin.txtPwd.ReadOnly = True
                        frmLogin.txtUserID.ReadOnly = True
                        frmLogin.TxtNewP1.Focus()
                    Else
                        'If ldtrLogin.Item("UiFChgPwd") = True Then
                        If ldtsLogin.Tables(0).Rows(0).Item("UiFChgPwd") = True Then
                            lblnLogin = False
                            frmLogin.Label1.Visible = True
                            frmLogin.Label2.Visible = True
                            frmLogin.TxtNewP1.Visible = True
                            frmLogin.TxtNewP2.Visible = True
                            frmLogin.txtPwd.ReadOnly = True
                            frmLogin.txtUserID.ReadOnly = True
                            frmLogin.TxtNewP1.Focus()
                        Else
                            lblnLogin = True
                            Dim MyTrans As SqlTransaction
                            MyTrans = GSCnSqlConn.BeginTransaction
                            Try
                                If GFncRunSQL(GSCnSqlConn, MyTrans, "Update User_Information set UiNoOfTry = 0 where UiUserId = '" & strUserID & "'") > 0 Then
                                    MyTrans.Commit()
                                Else
                                    MyTrans.Rollback()
                                End If
                                'CloseDRCon()
                            Catch ex As Exception
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    MyTrans.Rollback()
                                End If
                            End Try
                        End If
                    End If

                    If UCase(ldtsLogin.Tables(0).Rows(0).Item("UiUserType")) = "ADMINISTRATOR" Then
                        GBlnIsAdmin = True
                    End If
                Else
                    GSubShowWarn(GFncGetSysMsg(21))

                    lblnLogin = False
                    frmLogin.txtPwd.Focus()

                    Dim MyTrans As SqlTransaction
                    MyTrans = GSCnSqlConn.BeginTransaction
                    Try
                        If GFncRunSQL(GSCnSqlConn, MyTrans, "Update User_Information set UiNoOfTry = UiNoOfTry + 1 where UiUserId = '" & strUserID & "'") > 0 Then
                            MyTrans.Commit()
                        Else
                            MyTrans.Rollback()
                        End If
                    Catch ex As Exception
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            MyTrans.Rollback()
                        End If
                    End Try
                    'CloseDRCon()
                End If
                GFncChk3TimesLock(strUserID)
            End If
        Else
            GSubShowWarn(GFncGetSysMsg(22))
        End If

        'ldtrLogin.Close()
        ldtsLogin.Dispose()
        Return lblnLogin

    End Function

    Protected Friend Function GFncChk3TimesLock(ByVal strUserID As String) As Boolean

        'Dim DtrTimes As SqlDataReader
        Dim DtsTimes As New DataSet
        DtsTimes = GFncRtnDS(GSCnSqlConn, "Select UiNoOfTry from User_information where UiUserId = '" & strUserID & "'")
        If DtsTimes.Tables(0).Rows.Count > 0 Then
            'DtrTimes.Read()
            If DtsTimes.Tables(0).Rows(0).Item("UiNoOfTry") > 300 Then
                Dim MyTrans As SqlTransaction
                MyTrans = GSCnSqlConn.BeginTransaction
                Try
                    If GFncRunSQL(GSCnSqlConn, MyTrans, "Update User_Information set UiActive = 0 where UiUserID = '" & strUserID & "'") > 0 Then
                        MyTrans.Commit()
                        Return True
                    Else
                        MyTrans.Rollback()
                    End If
                Catch ex As Exception
                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        MyTrans.Rollback()
                    End If
                End Try

                GFncChk3TimesLock = True
            Else
                GFncChk3TimesLock = False
            End If
        End If
        'DtrTimes.Close()
        DtsTimes.Dispose()
        'CloseDRCon()

    End Function

    Protected Friend Function GFncChkActive(ByVal strUserID As String) As Boolean

        'Dim DtrActive As SqlDataReader
        Dim DtsActive As New DataSet
        DtsActive = GFncRtnDS(GSCnSqlConn, "Select UiActive from User_information where UiUserId = '" & strUserID & "'")
        If DtsActive.Tables(0).Rows.Count Then
            'DtrActive.Read()
            If DtsActive.Tables(0).Rows(0).Item("UiActive") = 1 Then
                GFncChkActive = True
            Else
                GFncChkActive = False
            End If
        End If
        'DtrActive.Close()
        DtsActive.Dispose()
        'CloseDRCon()

    End Function

    Protected Friend Function GFncChkDayEndRight(ByVal strUserID As String) As Boolean

        'Dim DtrMA As SqlDataReader
        Dim DtsMA As New DataSet
        DtsMA = GFncRtnDS(GSCnSqlConn, "Select * from menu_access where MnAMenuCode = 'DayendToolStripMenuItem' " & _
                        " and  MnAUserId = '" & strUserID & "'")
        If DtsMA.Tables(0).Rows.Count > 0 Then
            'DtrMA.Read()
            'Dim DtrDE As SqlDataReader
            Dim DtsDE As New DataSet
            DtsDE = GFncRtnDS(GSCnSqlConn, "Select *, getdate() as nowdatetime from dayendinfo where deirunUser = '" & strUserID & "'")
            If DtsDE.Tables(0).Rows.Count > 0 Then
                'DtrDE.Read()
                'If Math.Abs(DateDiff(DateInterval.Second, DtsDE.Tables(0).Rows(0).Item("deiactivecounter"), DtsDE.Tables(0).Rows(0).Item("nowdatetime"))) > 60 Then
                GFncChkDayEndRight = True
                'Else
                '    GFncChkDayEndRight = False
                'End If
            Else
                GFncChkDayEndRight = False
            End If
            'DtrDE.Close()
            DtsDE.Dispose()
        Else
            GFncChkDayEndRight = False
        End If
        DtsMA.Dispose()
        'CloseDRCon()

    End Function

    Protected Friend Function GFncChkLen(ByVal StrUid As String) As Boolean

        If Len(StrUid) < 6 Or Len(StrUid) > 10 Then
            GSubShowInfo(GFncGetSysMsg(16))
            GFncChkLen = False
        Else
            GFncChkLen = True
        End If

    End Function

    Protected Friend Function GFncChkExpire(ByVal strUserID As String) As Boolean

        'Dim DtrExpire As SqlDataReader
        Dim DtsExpire As New DataSet

        If UCase(GStrIsReportDB) = "Y" Then
            Return False
        End If

        DtsExpire = GFncRtnDS(GSCnSqlConn, "Select UiExpire from User_information where UiUserId = '" & strUserID & "'")
        'If DtrExpire.HasRows = True Then
        If DtsExpire.Tables(0).Rows.Count > 0 Then
            'DtrExpire.Read()
            'If Not IsEmptyDate(DtrExpire.Item("UiExpire")) Then
            '    If DtrExpire.Item("UiExpire") < Now Then
            If Not IsEmptyDate(DtsExpire.Tables(0).Rows(0).Item("UiExpire")) Then
                If DtsExpire.Tables(0).Rows(0).Item("UiExpire") < Now Then
                    GFncChkExpire = True
                Else
                    GFncChkExpire = False
                End If
            Else
                GFncChkExpire = True
            End If
        End If
        'DtrExpire.Close()
        DtsExpire.Dispose()
        'CloseDRCon()

    End Function

    Protected Friend Function GFncChkPwdRepeat(ByVal struserID As String, ByVal StrPass As String) As Boolean

        ''Dim DtrPwdHis As SqlDataReader
        'Dim DtsPwdHis As New DataSet
        'Dim DtwPwdHis As DataRow
        'Dim DtcPwdHis As DataRowCollection
        'DtsPwdHis = GFncRtnDS(GSCnSqlConn, "Select Top 30 * from Password_History where PwHChrUserId = '" & struserID & "' order by PwHDtmChangeDate desc")
        GFncChkPwdRepeat = False
        'DtcPwdHis = DtsPwdHis.Tables(0).Rows
        'For Each DtwPwdHis In DtcPwdHis
        '    'If DtsPwdHis.Tables(0).Rows(0).Item("PwHChrPassword") = GFncGetMd5Hash(StrPass) Then
        '    If DtwPwdHis.Item("PwHChrPassword") = GFncGetMd5Hash(StrPass) Then
        '        GFncChkPwdRepeat = True
        '        Exit For
        '    End If
        'Next
        'DtsPwdHis.Dispose()
        ''CloseDRCon()

    End Function

    Protected Friend Function FD_SFILE() As Boolean

        Dim l_quit As Boolean

        If Dir("\EI.SYS") = "" Then
            l_quit = False
        Else
            l_quit = True
        End If

        If l_quit = True Then
            If Dir("\NC\NC.EXE") = "" Then
                l_quit = False
            Else
                l_quit = True
            End If
        End If

        If l_quit = True Then
            If Dir("\DOS\FLOW.SYS") Then
                l_quit = False
            Else
                l_quit = True
            End If
        End If

        If l_quit = False Then
            GSubShowInfo(GFncGetSysMsg(18))
            FD_SFILE = False
        Else
            FD_SFILE = False
        End If

    End Function

    Protected Friend Function CHK_DATE(ByVal lstruserID As String) As Boolean

        'Dim l_return = False
        'Dim l_interest = False
        'Dim l_value_date As Date = Nothing
        'Dim l_escape As Boolean = True
        'Dim l_cursor As Integer = 1

        ''Dim DtrDayEnd As SqlDataReader
        'Dim DtsDayEnd As New DataSet
        ''DtrDayEnd = GFncRtnDR("Select * from Date")
        ''DtrDayEnd.Read()
        'DtsDayEnd = GFncRtnDS(GSCnSqlConn, "Select * from [Date]")

        ''If IsEmptyDate(DtrDayEnd.Item("D_TDATE")) = False And InStr("DN", DtrDayEnd.Item("D_DAY_NIG")) > 0 Then
        'If IsEmptyDate(DtsDayEnd.Tables(0).Rows(0).Item("D_TDATE")) = False And InStr("DN", DtsDayEnd.Tables(0).Rows(0).Item("D_DAY_NIG")) > 0 Then
        'Else
        '    'check dayend/day begin right
        '    'If Not GFncChkDayEndRight(lstruserID) Then
        '    '    GSubShowInfo(GFncGetSysMsg(20))
        '    '    Return False
        '    'End If
        '    'If DtrDayEnd.Item("D_DAY_NIG") = "E" Or DtrDayEnd.Item("D_DAY_NIG") = "B" Then
        '    If DtsDayEnd.Tables(0).Rows(0).Item("D_DAY_NIG") = "E" Or DtsDayEnd.Tables(0).Rows(0).Item("D_DAY_NIG") = "B" Then
        '        'If Not gfncUpdateDN() Then
        '        GSubShowInfo(GFncGetSysMsg(20))
        '        Return False
        '        'End If
        '    Else
        '    Dim frmdb As New FrmDayBegin
        '    'frmdb.MyTextbox6.Text = Format(DtrDayEnd.Item("D_L_TDATE"), "ddd  dd  MMM  [ yyyy ]")
        '    'frmdb.MyTextbox5.Text = Format(DtrDayEnd.Item("D_L_INT_CA"), "ddd  dd  MMM  [ yyyy ]") & " [ Claim ]"
        '    'frmdb.MyTextbox4.Text = Format(DtrDayEnd.Item("D_L_INT_CU"), "ddd  dd  MMM  [ yyyy ]") & "  [  Cut  ]"
        '    frmdb.MyTextbox6.Text = Format(DtsDayEnd.Tables(0).Rows(0).Item("D_L_TDATE"), "ddd  dd  MMM  [ yyyy ]")
        '    frmdb.MyTextbox5.Text = Format(DtsDayEnd.Tables(0).Rows(0).Item("D_L_INT_CA"), "ddd  dd  MMM  [ yyyy ]") & " [ Claim ]"
        '    frmdb.MyTextbox4.Text = Format(DtsDayEnd.Tables(0).Rows(0).Item("D_L_INT_CU"), "ddd  dd  MMM  [ yyyy ]") & "  [  Cut  ]"
        '        If Not frmdb.ShowDialog() = DialogResult.OK Then
        '            Return False
        '        End If

        '    End If

        'End If



        Return True

    End Function


    '    Protected Friend Function insertUser(ByVal ds As DataSet) As Boolean
    'Dim strSQL As String = ""
    '        Dim cmd As New SqlCommand
    '        Dim dr As DataRow
    '        Dim myTrans As SqlTransaction

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            dr = ds.Tables(0).Rows(0)

    '            strSQL = "Insert into user_information (uiUserID,uiPassword,uiLastName,uiFirstName," & _
    '                        "uiDeptCode uiTitle,uiCreateDt,uiCreateUser,uiModifyDt,uiModifyUser) VALUES " & _
    '                        "('" & sqlQuote(dr("uiUserID")) & "','" & getMd5Hash(dr("uiPassword")) & "'," & _
    '                        "'" & sqlQuote(dr("uiLastName")) & "','" & sqlQuote(dr("uiFirstName")) & "'," & _
    '                        "'" & sqlQuote(dr("uiDeptCode")) & "','" & sqlQuote(dr("uiTitle")) & "'," & _
    '                        "getdate(),'" & sqlQuote(dr("uiCreateUser")) & "',NULL,'') "

    '            cmd.CommandText = strSQL
    '            cmd.Connection = _sqlconn
    '            myTrans = _sqlconn.BeginTransaction("insertUser")
    '            cmd.Transaction = myTrans

    '            Try
    '                cmd.ExecuteNonQuery()
    '                myTrans.Commit()
    '                Return True
    '            Catch ex As Exception
    '                If _sqlconn.State <> ConnectionState.Closed Then
    '                    myTrans.Rollback("insertUser")
    '                End If
    '            End Try
    '        End If

    '        Return False

    '    End Function

    '    Protected Friend Function deleteUser(ByVal strUserID As String) As Boolean
    '        Dim strSQL As String = ""
    '        Dim cmd As New SqlCommand
    '        Dim myTrans As SqlTransaction

    '        strSQL = "Delete from user_information Where uiUserID = '" & sqlQuote(strUserID) & "' "

    '        cmd.CommandText = strSQL
    '        cmd.Connection = _sqlconn
    '        myTrans = _sqlconn.BeginTransaction("deleteUser")
    '        cmd.Transaction = myTrans

    '        Try
    '            cmd.ExecuteNonQuery()
    '            myTrans.Commit()
    '            Return True
    '        Catch ex As Exception
    '            If _sqlconn.State <> ConnectionState.Closed Then
    '                myTrans.Rollback("deleteUser")
    '            End If
    '        End Try

    '        Return False

    '    End Function

    '    Protected Friend Function updateUser(ByVal ds As DataSet) As Boolean
    '        Dim strSQL As String = ""
    '        Dim cmd As New SqlCommand
    '        Dim myTrans As SqlTransaction
    '        Dim dr As DataRow

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            dr = ds.Tables(0).Rows(0)

    '            strSQL = "Update user_information set uiPassword = '" & getMd5Hash(dr("uiPassword")) & "', " & _
    '                    "uiLastName = '" & sqlQuote(dr("uiLastName")) & "', uiFirstName = '" & sqlQuote(dr("uiFirstName")) & "', " & _
    '                    "uiDeptCode = '" & sqlQuote(dr("uiDeptCode")) & "', uiTitle = '" & sqlQuote(dr("uiTitle")) & "', " & _
    '                    "uiModifyDt = getDate(), uiModifyUser = '" & sqlQuote(dr("uiModifyUser")) & "' Where " & _
    '                    "uiUserID = '" & sqlQuote(dr("uiUserID")) & "' "

    '            cmd.CommandText = strSQL
    '            cmd.Connection = _sqlconn
    '            myTrans = _sqlconn.BeginTransaction("updateUser")
    '            cmd.Transaction = myTrans

    '            Try
    '                cmd.ExecuteNonQuery()
    '                myTrans.Commit()
    '                Return True
    '            Catch ex As Exception
    '                If _sqlconn.State <> ConnectionState.Closed Then
    '                    myTrans.Rollback("updateUser")
    '                End If
    '            End Try

    '        End If
    '        Return False

    '    End Function

    '    Protected Friend Function getUserInfo(ByVal strUserID As String) As DataSet
    '        Dim strSQL As String = ""
    '        Dim cmd As New SqlCommand
    '        Dim adp As SqlDataAdapter
    '        Dim ds As New DataSet

    '        strSQL = "Select * from user_information Where uiUserID = '" & sqlQuote(strUserID) & "' "

    '        cmd.CommandText = strSQL
    '        cmd.Connection = _sqlconn
    '        adp = New SqlDataAdapter(cmd)

    '        adp.Fill(ds)
    '        Return ds

    '    End Function

    Protected Friend Sub RD_CONG(ByVal StrBranch As String)

        Dim DtsCong As New DataSet

        DtsCong = GFncRtnDS(GSCnConConn, "Select * from Config where CfgBranchName = '" & StrBranch & "'")
        If DtsCong.Tables(0).Rows.Count > 0 Then
            With DtsCong.Tables(0).Rows(0)
                g_branch_name = .Item("CfgBranchName")
                g_company = .Item("CfgCompany")
                g_version = .Item("CfgVersion")
                '20071105 not use
                'g_dir = .Item("CfgDir")
                '20071105 end
                ' g_cutoff = CDate(.Item("Cfgcutoff"))
                GStrEPath = .Item("CfgErrorPath")
                GStrBCode = .Item("CfgBranchCode")
                GStrBPath = .Item("CfgBKDir")
                'GStrMonthlyDB = .Item("cfgmonthlydb")
                'GStrYesterdayDB = IIf(IsDBNull(.Item("cfgyesterdaydb")), "", .Item("cfgyesterdaydb"))

                'market close time
                'If UCase(.Item("CfgTimeFlag")) = "S" Then
                '    GDecCloseBUTime = .Item("CfgSummerTime_bu")
                '    GDecCloseFXTime = .Item("CfgSummerTime_fx")
                'Else
                '    GDecCloseBUTime = .Item("CfgWinterTime_bu")
                '    GDecCloseFXTime = .Item("CfgWinterTime_fx")
                'End If
                'GStrCloseBUHour = Left(Right("0" & CStr(GDecCloseBUTime).Trim, 4), 2)
                'GStrCloseBUMins = Right(CStr(GDecCloseBUTime).Trim, 2)
                'GStrCloseFXHour = Left(Right("0" & CStr(GDecCloseFXTime).Trim, 4), 2)
                'GStrCloseFXMins = Right(CStr(GDecCloseFXTime).Trim, 2)

                If Microsoft.VisualBasic.Right(.Item("CfgRptExportPath"), 1) <> "\" Then
                    GStrRptExpPath = .Item("CfgRptExportPath") & "\"
                Else
                    GStrRptExpPath = .Item("CfgRptExportPath")
                End If
            End With
        End If

        DtsCong.Dispose()

    End Sub

    Protected Friend Function GFncGetBCode(ByVal StrBranch As String) As String

        'Dim DtrCong As SqlDataReader

        'DtrCong = GFncRtnCDR("Select * from Config where CfgBranchName = '" & StrBranch & "'")
        'DtrCong.Read()

        'GFncGetBCode = DtrCong.Item("CfgBranchCode")

        'DtrCong.Close()
        Dim dtsCong As DataSet

        dtsCong = GFncRtnDS(GSCnConConn, "Select * from Config where CfgBranchName = '" & GFncSqlQuote(StrBranch) & "'")

        If dtsCong.Tables(0).Rows.Count > 0 Then
            GFncGetBCode = dtsCong.Tables(0).Rows(0).Item("CfgBranchCode")
        Else
            GFncGetBCode = ""
        End If
        dtsCong.Dispose()

    End Function

End Class
