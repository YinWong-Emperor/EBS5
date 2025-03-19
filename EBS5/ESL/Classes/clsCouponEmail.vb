Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.io

Public Class clsCouponEmail

    Protected Friend Function FncLoadDGV() As DataTable
        Dim dt As DataTable
        dt = GFncRtnDS(GSCnSqlConn, "select *, '' as alert_type from coupon_email_list order by email_list_id").Tables(0)
        Dim dr As DataRow
        For Each dr In dt.Rows
            If dr("alert_type_id") <> 0 Then
                dr("alert_type") = FncGetAlertCombo(dr("alert_type_id"))
            End If
        Next
        Return dt
    End Function
    Protected Friend Function FncLoadCombo(ByVal str As String) As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select distinct " & str & " from coupon_email_list order by " & str).Tables(0)
    End Function
    Protected Friend Function FncLoadComboAlertID() As DataTable
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select type, value from coupon_alert_type order by type").Tables(0)
        Return GFncRtnDS(GSCnSqlConn, "select type, value from coupon_alert_type order by type").Tables(0)
        'Dim idrow, dr As DataRow
        'Dim targetDt As DataTable = New dtsEmail.emailDataTable
        'For Each dr In dt.Rows
        '    idrow = targetDt.NewRow
        '    idrow("alert") = GFncNoNullString(dr("type")) & GFncNoNullString(dr("value"))
        '    targetDt.Rows.Add(idrow)
        'Next
        'Return targetDt
    End Function
    Protected Friend Function FncGetAlertCombo(ByVal id As Integer) As String
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select type, value from coupon_alert_type where alert_type_id = " & id & " order by type").Tables(0)
        If dt.Rows.Count = 1 Then
            Return GFncNoNullString(dt.Rows(0).Item("type").ToString & dt.Rows(0).Item("value").ToString)
        Else
            Return String.Empty
        End If
    End Function
    Protected Friend Function FncGetAlertTxt(ByVal name As String) As Integer
        Dim str As String = "select alert_type_id from coupon_alert_type where type = '" & name.Substring(0, 1) & _
                                    "' and value = " & CDbl(name.Substring(1, name.IndexOf(":") - 1))
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count = 1 Then
            Return CInt(GFncNoNullString(dt.Rows(0).Item("alert_type_id")))
        Else
            Return -1
        End If
    End Function
    Protected Friend Function FncSearch(ByVal acc As String, ByVal id As String) As DataTable
        Dim dt As DataTable
        If acc = String.Empty And id = String.Empty Then
            dt = GFncRtnDS(GSCnSqlConn, "select *, '' as alert_type from coupon_email_list order by email_list_id").Tables(0)
        ElseIf acc <> String.Empty And id = String.Empty Then
            dt = GFncRtnDS(GSCnSqlConn, "select *, '' as alert_type from coupon_email_list where account_no like '" & acc & "%' order by email_list_id").Tables(0)
        ElseIf acc = String.Empty And id <> String.Empty Then
            dt = GFncRtnDS(GSCnSqlConn, "select *, '' as alert_type from coupon_email_list where sales_id like '" & id & "%' order by email_list_id").Tables(0)
        Else
            dt = GFncRtnDS(GSCnSqlConn, "select *, '' as alert_type from coupon_email_list where account_no like '" & acc & "%' and sales_id like '" & id & "%' order by email_list_id").Tables(0)
        End If
        Dim dr As DataRow
        For Each dr In dt.Rows
            If dr("alert_type_id") <> 0 Then
                dr("alert_type") = FncGetAlertCombo(dr("alert_type_id"))
            End If
        Next
        Return dt
    End Function
    Protected Friend Function FncDoubleInsert(ByVal acc As String, ByVal id As String) As Boolean
        Dim str As String = "select * from coupon_email_list where account_no = '" & acc & "' and sales_id = '" & id & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Friend Function FncCheckEmail(ByVal email As String) As Boolean
        If email = String.Empty Then
            Return False
        End If
        email = email.Trim
        'Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim pattern As String = "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$"
        Dim emailAddressMatch As Match = Regex.Match(email, pattern)
        If Not emailAddressMatch.Success Then
            Return False
        Else
            Dim domain As String = email.Substring(email.IndexOf("@") + 1, email.Length - email.IndexOf("@") - 1)
            If GetMailServer(domain) Then
                Dim sText As String() = email.Split(CType("@", Char))
                If GFncNoNullString(GetMailServer(sText(1))) = String.Empty Then
                    Return False
                End If
            Else
                Return False
            End If
        End If
        Return True
    End Function
    Private Function GetMailServer(ByVal sDomain As String) As Boolean
        Dim info As New ProcessStartInfo()
        Dim ns As Process
        info.UseShellExecute = False
        info.RedirectStandardInput = True
        info.RedirectStandardOutput = True
        info.FileName = "nslookup"
        info.CreateNoWindow = True
        info.Arguments = "-type=MX " + sDomain.ToUpper.Trim
        ns = Process.Start(info)
        Dim sout As StreamReader
        sout = ns.StandardOutput
        Dim reg As Regex = New Regex("mail exchanger = (?<server>[^\\\s]+)")
        Dim mailserver As String
        Dim response As String = ""
        Do While (sout.Peek() > -1) 
            response = sout.ReadLine()
            Dim amatch As Match = reg.Match(response)
            If (amatch.Success) Then
                mailserver = amatch.Groups("server").Value
                Return True
            End If
        Loop
        Return False
    End Function
    Protected Friend Function FncAdd(ByVal acc As String, ByVal id As String, ByVal alert As Integer, ByVal email As String, ByVal user As String) As Boolean
        Dim time As String = CStr(System.DateTime.Now)
        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        Dim str As String = "insert into coupon_email_list values ('" & email & "', " & alert & ", '" & acc & _
                            "', '" & id & "', ' " & time & "', '" & user & "')"
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
                GSubWriteErrLog("FncAddToCoupon_email_list: " & ex.Message)
            End If
            Return False
        End Try
    End Function
    Protected Friend Function FncEdit(ByVal acc As String, ByVal id As String, ByVal alert As Integer, ByVal email As String, ByVal user As String, ByVal oldAcc As String, ByVal oldsale As String) As Boolean
        Dim time As String = CStr(System.DateTime.Now)
        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))
        Dim str As String = "update coupon_email_list set email_addr = '" & email & "', alert_type_id = " & alert & _
                            ", account_no = '" & acc & "', sales_id = '" & id & "', lstupddate = '" & time & _
                            "', lstupdby = '" & user & "' where account_no = '" & oldAcc & "' and sales_id = '" & oldsale & "'"
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
                GSubWriteErrLog("FncEditCoupon_email_list: " & ex.Message)
            End If
            Return False
        End Try
    End Function
    Protected Friend Function FncDelete(ByVal acc As String, ByVal id As String) As Boolean
        Dim str As String = "delete from coupon_email_list where account_no = '" & acc & "' and sales_id = '" & id & "'"
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
                GSubWriteErrLog("DeleteFromCoupon_email_list: " & ex.Message)
            End If
            Return False
        End Try
    End Function
End Class
