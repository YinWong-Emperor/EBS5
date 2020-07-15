Imports System.Data.SqlClient

Public Class clsExchangeRate

    Protected Friend Function FncLoadDGV(ByVal lupdtdate As Date) As DataTable
        'Dim str As String = "select exid, system_type as type, currency_in as currency, ex_rate as rate, lupdtdate from exchangerate where currency_in <> 'HKD' and year(lupdtdate) = " & lupdtdate.Year & " and month(lupdtdate) = " & lupdtdate.Month & " and day(lupdtdate) = " & lupdtdate.Day & "order by exid"
        'Dim str As String = "select exid, tdate, system_type as type, currency_in as currency, ex_rate as rate, lupdtdate from exchangerate where currency_in <> 'HKD' and year(tdate) = " & lupdtdate.Year & " and month(tdate) = " & lupdtdate.Month & " and day(tdate) = " & lupdtdate.Day & "order by exid"
        'Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Return Me.FncSearch(lupdtdate)
    End Function

    Private Function FncSearch(ByVal lupdtdate As Date, Optional ByVal type As String = "") As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ExchangeRate", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数
        AddParameter(sqlCmd, "system_type", type)
        AddParameter(sqlCmd, "tdate", lupdtdate)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Protected Friend Function FncLoadCombo() As DataTable
        'Return GFncRtnDS(GSCnSqlConn, "select distinct system_type from exchangerate order by system_type").Tables(0)
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ExchangeRate_Type", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Protected Friend Function FncSearch(ByVal type As String, ByVal lupdtdate As Date) As DataTable
        'Dim str As String = "select exid, system_type as type, currency_in as currency, ex_rate as rate, lupdtdate from exchangerate where system_type like '%" & type & "%' and year(lupdtdate) = " & lupdtdate.Year & " and month(lupdtdate) = " & lupdtdate.Month & " and day(lupdtdate) = " & lupdtdate.Day & " and currency_in <> 'HKD' order by exid"
        'Dim str As String = "select exid, tdate, system_type as type, currency_in as currency, ex_rate as rate, lupdtdate from exchangerate where system_type like '%" & type & "%' and year(tdate) = " & lupdtdate.Year & " and month(tdate) = " & lupdtdate.Month & " and day(tdate) = " & lupdtdate.Day & " and currency_in <> 'HKD' order by exid"
        'Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Return Me.FncSearch(lupdtdate, type)
    End Function

    'Protected Friend Function FncDoubleInsert(ByVal type As String, ByVal currency As String, ByVal rate As String) As Boolean
    '    Dim str As String = "select 1 from exchangerate where system_type = '" & type & "' and currency_in = '" & currency & "' and ex_rate = " & rate
    '    Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Protected Friend Function FncEdit(ByVal exid As String, ByVal rate As String, ByVal type As String, ByVal currency As String) As Object

        'Dim MyTrans As SqlTransaction = GSCnSqlConn.BeginTransaction
        Dim time As String = CStr(System.DateTime.Now)

        time = time.Substring(time.LastIndexOf("/") + 1, time.IndexOf(" ") - time.LastIndexOf("/") - 1) & _
                "/" & time.Substring(time.IndexOf("/") + 1, time.LastIndexOf("/") - time.IndexOf("/") - 1) & _
                "/" & time.Substring(0, time.IndexOf("/")) & time.Substring(time.IndexOf(" "), time.Length - time.IndexOf(" "))

        'Dim str As String = "update exchangerate set ex_rate = " & rate & ", lupdtdate = '" & time & "' where exid = " & exid

        'Try
        '    GFncRunSQL(GSCnSqlConn, MyTrans, str)
        '    MyTrans.Commit()
        '    MyTrans = Nothing
        '    Return True
        'Catch ex As Exception
        '    MyTrans.Rollback()
        '    GSubWriteErrLog("FncEdit exchangerate: " & ex.Message)
        '    MyTrans = Nothing
        '    Return False
        'End Try

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_ExchangeRate", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "system_type", type)
        AddParameter(sqlCmd, "currency_in", currency)
        AddParameter(sqlCmd, "lupdtdate", time)
        AddParameter(sqlCmd, "ex_rate", rate)
        AddParameter(sqlCmd, "exid", exid)

        Return GFncExecuteScalar(sqlCmd)

    End Function
End Class
