Imports System.Data.SqlClient
Public Class clsCouponAlertType

    Protected Friend Function FncLoadDGV() As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select * from coupon_alert_type order by alert_type_id").Tables(0)
    End Function
    Protected Friend Function FncSearch(ByVal type As Char) As DataTable
        If type = Nothing Then
            Return GFncRtnDS(GSCnSqlConn, "select * from coupon_alert_type order by alert_type_id").Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, "select * from coupon_alert_type where type = '" & type & "' order by alert_type_id").Tables(0)
        End If
    End Function
    Protected Friend Function FncDoubleInsert(ByVal type As Char, ByVal value As Double) As Boolean
        Dim str As String = "select * from coupon_alert_type where type = '" & type & "' and value = " & value
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Friend Function FncAdd(ByVal type As Char, ByVal value As Double, ByVal user As String) As Boolean
        Dim time As String = CStr(System.DateTime.Now)
        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        Dim str As String = "insert into coupon_alert_type values ('" & type & "', " & value & ", '" & time & "', '" & user & "')"
        Dim MyTrans As SqlTransaction = Nothing
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
                GSubWriteErrLog("FncAddToCoupon_plan_master: " & ex.Message)
            End If
            Return False
        End Try
    End Function
    Protected Friend Function FncEdit(ByVal type As Char, ByVal value As Double, ByVal user As String, ByVal oldType As Char, ByVal oldValue As Double) As Boolean
        Dim time As String = CStr(System.DateTime.Now)
        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        Dim str As String = "update coupon_alert_type set type = '" & type & "', value = " & value & ", lstupddate = '" & _
                            time & "', lstupdby = '" & user & "' where type = '" & oldType & "' and value = " & oldValue
        Dim MyTrans As SqlTransaction = Nothing
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
                GSubWriteErrLog("FncEditCoupon_plan_master: " & ex.Message)
            End If
            Return False
        End Try
    End Function
    Protected Friend Function FncDelete(ByVal type As Char, ByVal value As Double) As Boolean
        Dim str As String = "delete from coupon_alert_type where type = '" & type & "' and value = " & value
        Dim MyTrans As SqlTransaction = Nothing
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
                GSubWriteErrLog("DeleteFromCoupon_plan_master: " & ex.Message)
            End If
            Return False
        End Try
    End Function
End Class
