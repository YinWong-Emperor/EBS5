Imports System.Data.SqlClient

Public Class ClsUserMnt

    Public Function IsUserExist(ByVal StrUserId As String) As Boolean

        'Dim DtrUser As SqlDataReader
        Dim DtSUser As New DataSet
        DtSUser = modCommon.GFncRtnDS(GSCnSqlConn, "Select * from User_Information where UiUserID = '" & StrUserId & "'")
        If DtSUser.Tables(0).Rows.Count > 0 Then
            IsUserExist = True
        Else
            IsUserExist = False
        End If
        DtSUser.Dispose()

    End Function

    Public Function IsOldPassOK(ByVal StrUserId As String, ByVal StrPass As String) As Boolean

        'Dim DtrPass As SqlDataReader
        Dim DtSPass As New DataSet
        DtSPass = modCommon.GFncRtnDS(GSCnSqlConn, "Select UiPassword from User_Information where UiUserID = '" & StrUserId & "'")
        If DtSPass.Tables(0).Rows.Count > 0 Then
            'DtrPass.Read()
            If modCommon.GFncGetMd5Hash(StrPass) <> DtSPass.Tables(0).Rows(0).Item("UiPassword") Then
                IsOldPassOK = False
            Else
                IsOldPassOK = True
            End If
        Else
            IsOldPassOK = False
        End If
        DtSPass.Dispose()

    End Function

    Public Function GFncUserType(ByVal StrUserID As String) As String

        'Dim DtrUser As SqlDataReader
        Dim DtSUser As New DataSet
        DtSUser = modCommon.GFncRtnDS(GSCnSqlConn, "Select UiUserType from User_Information where UiUserID = '" & StrUserID & "'")
        If DtSUser.Tables(0).Rows.Count > 0 Then
            'DtrUser.Read()
            GFncUserType = DtSUser.Tables(0).Rows(0).Item("UiUserType")
        Else
            GFncUserType = ""
        End If
        DtSUser.Dispose()

    End Function

    Public Sub SetMenuRight(ByVal MS As MenuStrip)

        Dim menu_Strip As MenuStrip = DirectCast(MS, MenuStrip)
        For Each child As ToolStripMenuItem In menu_Strip.Items
            If GetRights(GStrloginID, child.Name) = True Then
                child.Enabled = True
            Else
                child.Enabled = False
            End If

            'Call the metho drecursively to set the state of the subitems.
            SetMenuRightItem(child)
        Next child

    End Sub

    Private Sub SetMenuRightItem(ByVal item As ToolStripMenuItem)

        ' Apply the new locale to items contained in it.
        Dim menu_item As ToolStripMenuItem = DirectCast(item, ToolStripMenuItem)
        For Each child As ToolStripMenuItem In menu_item.DropDownItems
            If GetRights(GStrloginID, child.Name) = True Then
                child.Enabled = True
            Else
                child.Enabled = False
            End If
            SetMenuRightItem(child)
        Next child

    End Sub

    Public Function GetRights(ByVal StrUserID As String, ByVal StrObjectName As String) As Boolean

        If UCase(GStrIsReportDB) = "Y" Then
            Dim dtsARpt As DataSet = GFncRtnDS(GSCnSqlConn, "Select * from connection.dbo.Menu_Access_rpt where MnAMenuCode = '" & _
                        StrObjectName & "' and d_system = 'ESL' ")
            If dtsARpt.Tables(0).Rows.Count <= 0 Then
                Return False
            End If
        End If

        'Dim DtRAccess As SqlDataReader
        Dim DtSAccess As New DataSet
        DtSAccess = GFncRtnDS(GSCnSqlConn, "Select * from Menu_Access where MnAUserID = '" & StrUserID & "' and MnAMenuCode = '" & StrObjectName & "'")
        'DtRAccess.Read()
        If DtSAccess.Tables(0).Rows.Count > 0 Then
            GetRights = True
        Else
            GetRights = False
        End If


        'DtRAccess.Close()
        DtSAccess.Dispose()
        'CloseDRCon()

        'If GStrConDB <> "MACAUFX" Then
        '    If StrObjectName = "DatabaseBackupToolStripMenuItem" Then
        '        GetRights = False
        '    End If
        'End If


    End Function

End Class
