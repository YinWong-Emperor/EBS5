Imports System.Data.SqlClient
Imports System.IO

Public Class ClsMenuAccess

    Protected Friend Function lfncGetFnc(ByVal lstrUserID As String) As DataSet
        Dim lstrSQL As String
        Dim ldtsFA As DataSet

        lstrSQL = " select a.*, 1 as fncright from function_info a inner join function_access b " & _
              " on fiobjectkey = fncobjectkey " & _
              " where fncuserid = '" & lstrUserID & "' " & _
              " union " & _
              " select a.* , 0 as fncright from function_info a " & _
              " where not exists ( select * from function_access b " & _
              " where a.fiobjectkey = b.fncobjectkey " & _
              " and fncuserid = '" & lstrUserID & "' ) " & _
              " order by a.fidesc "

        ldtsFA = GFncRtnDS(GSCnSqlConn, lstrSQL)

        Return ldtsFA

    End Function
    Protected Friend Function lfncUserDS() As DataSet
        Dim lstrSQL As String
        Dim ldtsAcc As DataSet

        lstrSQL = "select uiuserid from user_information order by uiuserid "
        ldtsAcc = GFncRtnDS(GSCnSqlConn, lstrSQL)

        Return ldtsAcc

    End Function
    Protected Friend Function lfncMADS() As DataSet
        Dim lstrSQL As String
        Dim ldtsMA As DataSet

        lstrSQL = "select level_1, level_2, level_3, level_4, menuflag, menucode from #MA "
        ldtsMA = GFncRtnDS(GSCnSqlConn, lstrSQL, "MA")

        Return ldtsMA

    End Function
    Protected Friend Sub lSubDropTemp()
        Dim lstrSQL As String

        lstrSQL = " drop table #MA "
        GFncRunSQL(GSCnSqlConn, lstrSQL)

    End Sub
    Protected Friend Sub lSubCreateTemp()
        Dim lstrSQL As String

        lstrSQL = " select cast( '' as nvarchar(100)) as level_1, cast( '' as nvarchar(100)) as level_2, " & _
                " cast( '' as nvarchar(100)) as level_3,cast( '' as nvarchar(100)) as level_4, " & _
                " cast(0 as integer) as menuflag,  mnamenucode as menucode  into #MA from menu_access where 1= 0 "
        GFncRunSQL(GSCnSqlConn, lstrSQL)

    End Sub
    Protected Friend Function lfncReplace(ByVal lstr As String) As String
        lstr = Replace(lstr, "'", "")
        lstr = Replace(lstr, "&", "")

        Return lstr

    End Function
    Protected Friend Function lfncSaveMA(ByVal ldtsMA As DataSet, ByVal lstrUserID As String) As Boolean
        Dim MyTrans As SqlTransaction
        Dim lstrSQL As String
        MyTrans = GSCnSqlConn.BeginTransaction
        Try

            lstrSQL = " delete from menu_access where mnauserid = '" & lstrUserID & "' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL)

            Dim ldtwMA As DataRow
            For Each ldtwMA In ldtsMA.Tables(0).Rows
                If ldtwMA("menuflag") = 1 Then
                    lstrSQL = " insert into menu_access (mnauserid, mnamenucode) values ('" & lstrUserID & "', '" & _
                                ldtwMA("menucode") & "' ) "
                    GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL)
                End If
            Next

            MyTrans.Commit()
            Return True

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                MyTrans.Rollback()
                GSubWriteErrLog(ex.Message)
            End If
            Return False
        End Try

    End Function
    Protected Friend Function lfncSaveFnc(ByVal ldtsFnc As DataSet, ByVal lstrUserID As String) As Boolean
        Dim MyTrans As SqlTransaction
        Dim lstrSQL As String
        MyTrans = GSCnSqlConn.BeginTransaction
        Try

            lstrSQL = " delete from function_access where fncuserid = '" & lstrUserID & "' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL)

            Dim ldtwFnc As DataRow
            For Each ldtwFnc In ldtsFnc.Tables(0).Rows
                If ldtwFnc("fncright") = 1 Then
                    lstrSQL = " insert into function_access (fncuserid,fncobjectkey) values ('" & lstrUserID & "', '" & _
                                ldtwFnc("fIobjectkey") & "' ) "
                    GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL)
                End If
            Next

            MyTrans.Commit()
            Return True

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                MyTrans.Rollback()
                GSubWriteErrLog(ex.Message)
            End If
            Return False
        End Try

    End Function
  
    Protected Friend Sub lSubFindRight(ByVal lstrUserID As String)
        Dim lstrSQL As String

        lstrSQL = " update #MA set menuflag = 0 "
        GFncRunSQL(GSCnSqlConn, lstrSQL)

        lstrSQL = "update #MA set menuflag = 1 from menu_access a where a.mnauserid = '" & lstrUserID & "' " & _
                " and #MA.menucode = a.mnamenucode "
        GFncRunSQL(GSCnSqlConn, lstrSQL)

    End Sub
    Protected Friend Sub lSubGetMenu(ByVal MS As MenuStrip)
        Dim lstrSQL As String

        Dim menu_Strip As MenuStrip = DirectCast(MS, MenuStrip)
        For Each child As ToolStripMenuItem In menu_Strip.Items
            lstrSQL = " insert into #MA (level_1, menucode) values ('" & Me.lfncReplace(child.Text) & "' , '" & Trim(child.Name) & "' ) "
            GFncRunSQL(GSCnSqlConn, lstrSQL)

            Dim menu_item1 As ToolStripMenuItem = DirectCast(child, ToolStripMenuItem)
            For Each child1 As ToolStripMenuItem In menu_item1.DropDownItems
                lstrSQL = " insert into #MA (level_1, level_2, menucode) values ('" & Me.lfncReplace(child.Text) & "' , '" & _
                        Me.lfncReplace(child1.Text) & "' , '" & Trim(child1.Name) & "' ) "
                GFncRunSQL(GSCnSqlConn, lstrSQL)

                Dim menu_item2 As ToolStripMenuItem = DirectCast(child1, ToolStripMenuItem)
                For Each child2 As ToolStripMenuItem In menu_item2.DropDownItems
                    lstrSQL = " insert into #MA (level_1, level_2, level_3, menucode) values ('" & lfncReplace(child.Text) & "' , '" & _
                                            Me.lfncReplace(child1.Text) & "' , ' " & Me.lfncReplace(child2.Text) & "' , '" & Trim(child2.Name) & "' ) "
                    GFncRunSQL(GSCnSqlConn, lstrSQL)

                    Dim menu_item3 As ToolStripMenuItem = DirectCast(child2, ToolStripMenuItem)
                    For Each child3 As ToolStripMenuItem In menu_item3.DropDownItems
                        lstrSQL = " insert into #MA (level_1, level_2, level_3, level_4,  menucode) values ('" & _
                                    Me.lfncReplace(child.Text) & "' , '" & Me.lfncReplace(child1.Text) & "' , ' " & _
                                    Me.lfncReplace(child2.Text) & "' , ' " & Me.lfncReplace(child3.Text) & "' , '" & Trim(child3.Name) & "' ) "
                        GFncRunSQL(GSCnSqlConn, lstrSQL)

                    Next child3

                Next child2

            Next child1

        Next child

    End Sub


End Class
