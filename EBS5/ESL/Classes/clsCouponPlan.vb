Imports System.Data.SqlClient
Public Class clsCouponPlan

    Protected Friend Function FncLoadDGV() As DataTable
        Dim str As String = "select plan_code, round((price / 1000),2) as price, round((turnover_limit/100000000),2) as turnover_limit, " & _
                            "grace_value_percentage, grace_period, expiry_extension_period " & _
                            "from coupon_plan_master order by coupon_plan_id"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function
    Protected Friend Function FncLoadCombo() As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select distinct plan_code from coupon_plan_master order by plan_code").Tables(0)
    End Function
    Protected Friend Function FncSearch(ByVal code As String) As DataTable
        If code <> String.Empty Then
            Dim str As String = "select plan_code, round((price / 1000),2) as price, round((turnover_limit/100000000),2) as turnover_limit, " & _
                            "grace_value_percentage, grace_period, expiry_extension_period " & _
                            "from coupon_plan_master where plan_code like '" & code & "%' order by coupon_plan_id"
            Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Else
            Return FncLoadDGV()
        End If
    End Function
    Protected Friend Function FncDoubleInsert(ByVal code As String) As Boolean
        Dim str As String = "select * from coupon_plan_master where plan_code = '" & code & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Friend Function FncAdd(ByVal code As String, ByVal price As Double, ByVal turnover As Double, _
                                        ByVal value As Integer, ByVal period As Integer, ByVal expiry As Integer, _
                                        ByVal user As String) As Boolean

        Dim time As String = CStr(System.DateTime.Now)
        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        Dim str As String = "insert into coupon_plan_master values ('" & code & "', " & price & ", " & turnover & ", " & value & _
                                    ", " & period & ", " & expiry & ", '" & time & "', '" & user & "')"
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
    Protected Friend Function FncEdit(ByVal code As String, ByVal price As Double, ByVal turnover As Double, _
                                        ByVal value As Integer, ByVal period As Integer, ByVal expiry As Integer, _
                                        ByVal user As String, ByVal oldCode As String) As Boolean
        Dim time As String = CStr(System.DateTime.Now)
        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        Dim str As String = "update coupon_plan_master set plan_code = '" & code & "', price = " & price & _
                            ", turnover_limit = " & turnover & ", grace_value_percentage = " & value & _
                            ", grace_period = " & period & ", expiry_extension_period = " & expiry & _
                            ", lstupddate = '" & time & "', lstupdby = '" & user & "' where plan_code = '" & oldCode & "'"
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
    Protected Friend Function FncDelete(ByVal code As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim str As String = "delete from coupon_plan_master where plan_code = '" & code & "'"
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
