Imports System.Data.SqlClient
Public Class clsCoupon

    Protected Friend Function FncLoadDGV() As DataTable
        Dim str As String = "select a.coupon_info_id, a.coupon_value_id, a.account_no, b.value_consumed, " & _
                            "b.grace_value_consumed, a.coupon_plan_id, c.plan_code, " & _
                            "round(a.turnover_limit / 100000000, 2) as turnover_limit, a.grace_value_percentage, " & _
                            "round(a.grace_value / 100000000, 2) as grace_value, a.grace_period, a.expiry_extension_period, " & _
                            "a.purchase_date, a.expiry_date, a.grace_expiry, a.status, a.creation_date, " & _
                            "a.created_by, a.lstupddate, a.lstupdby, c.price from coupon_info_list a left join coupon_value_list b on " & _
                            "a.coupon_value_id = b.coupon_value_id left join coupon_plan_master c on " & _
                            "a.coupon_plan_id = c.coupon_plan_id where a.status = 'Active' order by a.coupon_info_id"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function
    Protected Friend Function FncLoadAcc() As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select distinct account_no from coupon_info_list order by account_no").Tables(0)
    End Function
    Protected Friend Function FncSearch(ByVal acc As String, ByVal status As String) As DataTable
        Dim str As String = String.Empty
        If acc = String.Empty And status = String.Empty Then
            Return FncLoadDGV()
        ElseIf status = String.Empty Then
            str = "select a.coupon_info_id, a.coupon_value_id, a.account_no, b.value_consumed, b.grace_value_consumed, a.coupon_plan_id, c.plan_code, " & _
                    "round(a.turnover_limit / 100000000, 2) as turnover_limit, a.grace_value_percentage, round(a.grace_value / 100000000, 2) as grace_value, " & _
                    "a.grace_period, a.expiry_extension_period, a.purchase_date, a.expiry_date, a.grace_expiry, a.status, a.creation_date, " & _
                    "a.created_by, a.lstupddate, a.lstupdby, c.price from coupon_info_list a left join coupon_value_list b on a.coupon_value_id = b.coupon_value_id " & _
                    "left join coupon_plan_master c on a.coupon_plan_id = c.coupon_plan_id where a.account_no like '" & acc & "%' order by a.coupon_info_id"
        ElseIf acc = String.Empty Then
            str = "select a.coupon_info_id, a.coupon_value_id, a.account_no, b.value_consumed, b.grace_value_consumed, a.coupon_plan_id, c.plan_code, " & _
                    "round(a.turnover_limit / 100000000, 2) as turnover_limit, a.grace_value_percentage, round(a.grace_value / 100000000, 2) as grace_value, " & _
                    "a.grace_period, a.expiry_extension_period, a.purchase_date, a.expiry_date, a.grace_expiry, a.status, a.creation_date, " & _
                    "a.created_by, a.lstupddate, a.lstupdby, c.price from coupon_info_list a left join coupon_value_list b on a.coupon_value_id = b.coupon_value_id " & _
                    "left join coupon_plan_master c on a.coupon_plan_id = c.coupon_plan_id where a.status = '" & status & "' order by a.coupon_info_id"
        Else
            str = "select a.coupon_info_id, a.coupon_value_id, a.account_no, b.value_consumed, b.grace_value_consumed, a.coupon_plan_id, c.plan_code, " & _
                    "round(a.turnover_limit / 100000000, 2) as turnover_limit, a.grace_value_percentage, round(a.grace_value / 100000000, 2) as grace_value, " & _
                    "a.grace_period, a.expiry_extension_period, a.purchase_date, a.expiry_date, a.grace_expiry, a.status, a.creation_date, " & _
                    "a.created_by, a.lstupddate, a.lstupdby, c.price from coupon_info_list a left join coupon_value_list b on a.coupon_value_id = b.coupon_value_id " & _
                    "left join coupon_plan_master c on a.coupon_plan_id = c.coupon_plan_id where a.account_no like '" & acc & "%' and a.status = '" & status & "' order by a.coupon_info_id"
        End If
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Return dt
    End Function
    Protected Friend Function FncGetPlan(ByVal plan As String) As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select * from coupon_plan_master where plan_code = '" & plan & "'").Tables(0)
    End Function
    Protected Friend Function FncDoubleInsert(ByVal acc As String, ByVal id As Integer, ByVal MyTrans As SqlTransaction) As Boolean
        Dim str As String = "select * from coupon_info_list where account_no = '" & acc & "' and coupon_plan_id = '" & id & "' and status = 'Active'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str, MyTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Friend Function FncInsert(ByVal vc As Double, ByVal gvc As Double, ByVal user As String, ByVal MyTrans As SqlTransaction) As Integer
        'Dim MyTrans As SqlTransaction = GSCnSqlConn.BeginTransaction
        Dim time As String = CStr(System.DateTime.Now)
        time = changeFormat(time)
        Dim str As String = "insert into coupon_value_list values (" & vc & ", " & gvc & ", '" & time & "', '" & user & "')"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            'MyTrans.Commit()
            'MyTrans = Nothing
            Return CInt(GFncRtnDS(GSCnSqlConn, "Select max(coupon_value_id) as maxautono FROM coupon_value_list", MyTrans).Tables(0).Rows(0).Item(0))
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    'MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncInsertIntoCoupon_value_list: " & ex.Message)
            End If
            'MyTrans.Rollback()
            'MyTrans = Nothing
            Return -1
        End Try
    End Function
    Protected Friend Function FncDelete(ByVal id As Integer)
        Dim time As String = CStr(System.DateTime.Now)
        time = changeFormat(time)
        Dim str As String = "delect from coupon_value_list where coupon_value_id = " & id
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncDeleteFromCoupon_value_list: " & ex.Message)
            End If
        End Try
        Return Nothing
    End Function
    Protected Friend Function FncVoid(ByVal acc As String, ByVal id As Integer) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim str As String = "update coupon_info_list set status = 'Void' where account_no = '" & acc & "' and coupon_plan_id = " & id
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            MyTrans.Commit()
            MyTrans = Nothing
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncVoidCoupon_value_list: " & ex.Message)
            End If
            Return False
        End Try
    End Function
    Protected Friend Function FncAdd(ByVal vid As Integer, ByVal acc As String, ByVal pid As Integer, ByVal limit As Double, ByVal gvp As Integer, ByVal gp As Integer, _
                                    ByVal eep As Integer, ByVal pd As Date, ByVal ed As Date, ByVal gv As Double, ByVal cd As Date, ByVal cuser As String, _
                                    ByVal user As String, ByVal MyTrans As SqlTransaction) As Boolean
        'Dim MyTrans As SqlTransaction = GSCnSqlConn.BeginTransaction
        Dim time As String = CStr(System.DateTime.Now)
        Dim str As String = "insert into coupon_info_list values (" & vid & ", '" & acc & "', " & pid & ", " & limit & ", " & gvp & _
                            ", " & gp & ", " & eep & ", '" & changeFormat(pd) & "', '" & changeFormat(ed) & "', " & gv & ", '', 'Active', '" & _
                            changeFormat(cd) & "', '" & cuser & "', '" & changeFormat(time) & "', '" & user & "')"
        Try
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            'MyTrans.Commit()
            'MyTrans = Nothing
            Return True
        Catch ex As Exception
            'MyTrans.Rollback()
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    'MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncAddToCoupon_info_list: " & ex.Message)
            End If
            'MyTrans = Nothing
            Return False
        End Try
    End Function
    'Protected Friend Function FncEdit(ByVal vid As Integer, ByVal acc As String, ByVal pid As Integer, ByVal limit As Double, ByVal gvp As Integer, ByVal gp As Integer, _
    '                                ByVal eep As Integer, ByVal pd As Date, ByVal ed As Date, ByVal gv As Double, ByVal cd As Date, ByVal cuser As String, _
    '                                ByVal user As String, ByVal oldAcc As String, ByVal oldPlan As Integer) As Boolean
    '    Dim MyTrans As SqlTransaction = GSCnSqlConn.BeginTransaction
    '    Dim time As String = CStr(System.DateTime.Now)
    '    Dim str As String = "update coupon_info_list set  (" & vid & ", '" & acc & "', " & pid & ", " & limit & ", " & gvp & _
    '                        ", " & gp & ", " & eep & ", '" & changeFormat(pd) & "', '" & changeFormat(ed) & "', " & gv & ", '', 'Active', '" & _
    '                        changeFormat(cd) & "', '" & cuser & "', '" & changeFormat(time) & "', '" & user & "')"
    '    Try
    '        GFncRunSQL(GSCnSqlConn, MyTrans, str)
    '        MyTrans.Commit()
    '        MyTrans = Nothing
    '        Return True
    '    Catch ex As Exception
    '        MyTrans.Rollback()
    '        GSubWriteErrLog("FncEditCoupon_info_list: " & ex.Message)
    '        MyTrans = Nothing
    '        Return False
    '    End Try
    'End Function
    Private Function changeFormat(ByVal time As String) As String
        time = time & " "
        Dim result = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/"))
        If time.IndexOf(" ") <> time.Length - 1 Then
            result = result & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        End If
        Return result
    End Function
End Class
