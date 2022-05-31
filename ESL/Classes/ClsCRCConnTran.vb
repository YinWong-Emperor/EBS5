Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ClsCRCConnTran

    Protected Friend Function lFncGetGroupList() As DataSet
        Dim lstrSQL As String = ""
        lstrSQL = "SELECT DISTINCT list_name as lname FROM contran order by list_name "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "Group")
    End Function

    Protected Friend Function getGroupClientList(ByVal groupName As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "SELECT * FROM contran WHERE list_name = '" & Trim(groupName) & "' ORDER BY seq_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "groupclientlist")
        Return lds
    End Function

    Protected Friend Function getIPOList(ByVal ipoYear As Integer, ByVal ipoMonth As Integer, ByVal accFrom As String, ByVal accTo As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select client_code, loan_date, ipo_loan from ipoloan " & _
                    " where year(loan_date) = " & CStr(ipoYear) & " and month(loan_date) = " & CStr(ipoMonth)
        If (accFrom.Trim.Length > 0) Then
            lstrSQL = lstrSQL & " and client_code >=  '" & accFrom.Trim & "'"
        End If
        If (accTo.Trim.Length > 0) Then
            lstrSQL = lstrSQL & " and client_code <=  '" & accTo.Trim & "'"
        End If
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "ipolist")
        'lds = GFncRtnDS(GSCnLiqConn, lstrSQL, "ipolist")
        Return lds
    End Function


    Protected Friend Function delIPOList(ByVal client_code As String, ByVal loan_date As Date) As Boolean
        Dim lstrSQL As String
        lstrSQL = "delete from ipoloan where client_code = '" & client_code.Trim & "' and year(loan_date) = " & _
                    loan_date.Year & " and month(loan_date) = " & loan_date.Month & " and day(loan_date) = " & _
        loan_date.Day
        If GFncRunSQL(GSCnSqlConn, lstrSQL) < 0 Then
            'If GFncRunSQL(GSCnLiqConn, lstrSQL) < 0 Then
            Return False
        End If
        Return True
    End Function

    Protected Friend Function addIPOList(ByVal client_code As String, ByVal loan_date As Date, ByVal ipo_loan As String) As Boolean
        Dim lstrSQL As String
        lstrSQL = "insert into ipoloan values ('" & client_code & "','" & loan_date.Year & _
"/" & loan_date.Month & "/" & loan_date.Day & "'," & ipo_loan & ")"
        If GFncRunSQL(GSCnSqlConn, lstrSQL) < 0 Then
            'If GFncRunSQL(GSCnLiqConn, lstrSQL) < 0 Then
            Return False
        End If
        Return True
    End Function
    Protected Friend Function FncGetEndDate() As Date
        Return CDate(GFncRtnDS(GSCnLiqConn, "select t2_date from IBSSTTXNDATE").Tables(0).Rows(0).Item("t2_date"))
    End Function

    Protected Friend Function FncGetGroupList() As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select list_name,clt_code from contran order by list_name,clt_code").Tables(0)
    End Function

    Protected Friend Function FncGetClientMaster() As DataTable
        Return GFncRtnDS(GSCnLiqConn, "select clt_code,clt_name from STCLTMASTER").Tables(0)
    End Function

    Protected Friend Function FncGetMinimum(ByVal startDate As String, ByVal endDate As String, ByVal type As String) As DataTable
        Dim tempdt As DataTable
        Dim tempdt2 As DataTable
        tempdt = FncGetGroupList()
        Dim sqlStr As String
        Try
            If type = "ipo_loan" Then
                sqlStr = "Create table #temp (list_name varchar(20),client_code varchar(10))"
                GFncRunSQL(GSCnSqlConn, sqlStr)
                For Each dr As DataRow In tempdt.Rows
                    sqlStr = "insert into #temp values ('" & dr.Item(0).ToString.Trim & "','" & dr.Item(1).ToString.Trim & "')"
                    GFncRunSQL(GSCnSqlConn, sqlStr)
                Next
                sqlStr = "select list_name,min(sum_bal) as min_bal from (select sum(case when " & type & " >0 then 0 else " & _
                            type & " end) as sum_bal,list_name,loan_date from ipoloan,#temp where ipoloan.client_code = #temp.client_code collate Chinese_Taiwan_Stroke_CI_AS " & _
                            "and loan_date between '" & startDate & "' and '" & endDate & "' group by list_name,loan_date) tmp group by list_name"
                tempdt = GFncRtnDS(GSCnSqlConn, sqlStr).Tables(0)
            Else
                sqlStr = "Create table #temp (list_name varchar(20),client_code varchar(10))"
                GFncRunSQL(GSCnBalConn, sqlStr)
                For Each dr As DataRow In tempdt.Rows
                    sqlStr = "insert into #temp values ('" & dr.Item(0).ToString.Trim & "','" & dr.Item(1).ToString.Trim & "')"
                    GFncRunSQL(GSCnBalConn, sqlStr)
                Next
                sqlStr = "select list_name,min(sum_bal) as min_bal from (select sum(case when " & type & " >0 then 0 else " & _
                type & " end) as sum_bal,list_name,tdate from acbal,#temp where accno = #temp.client_code " & _
                "and tdate between '" & startDate & "' and '" & endDate & "' group by list_name,tdate) tmp group by list_name"
                tempdt = GFncRtnDS(GSCnBalConn, sqlStr).Tables(0)
            End If
        Catch ex As Exception
        Finally
            sqlStr = "drop table #temp"
            If type = "ipo_loan" Then
                GFncRunSQL(GSCnSqlConn, sqlStr)
            Else
                GFncRunSQL(GSCnBalConn, sqlStr)
            End If
        End Try
        sqlStr = "select distinct list_name, 0.00 as min_bal from contran"
        tempdt2 = GFncRtnDS(GSCnSqlConn, sqlStr).Tables(0)
        For Each dr2 As DataRow In tempdt2.Rows
            For Each dr As DataRow In tempdt.Rows
                If dr.Item(0) = dr2.Item(0) Then
                    dr2.Item(1) = dr.Item(1)
                End If
            Next
        Next

        Return tempdt2
    End Function

    Protected Friend Function FncGetBal(ByVal tin1 As Date, ByVal tin2 As Date, ByVal type As String) As DataTable
        Dim startDate As String = Format(tin1, "yyyy/MM/dd")
        Dim endDate As String = Format(tin2, "yyyy/MM/dd")
        Dim tempdt As DataTable
        Dim tempdt2 As DataTable

        Dim sqlStr As String = "select list_name as list, clt_code as client, '' as name"
        For i As Integer = 1 To 25
            sqlStr = sqlStr & ", 0.00 as balance" & i
        Next
        'Sort by Account Group Name then Account No.
        'sqlStr = sqlStr & ", 0.00 as min from contran order by list_name"
        sqlStr = sqlStr & ", 0.00 as min from contran order by list_name, clt_code"
        Dim dt As DataTable = New DtsConnectedTransaction.CRCConTransDataTable
        dt = GFncRtnDS(GSCnSqlConn, sqlStr).Tables(0)

        Dim timeDt As DataTable
        If type = "ipo_loan" Then
            timeDt = GFncRtnDS(GSCnSqlConn, "select distinct loan_date from ipoloan where loan_date between '" & startDate & "' and '" & endDate & "' order by loan_date").Tables(0)
        Else
            timeDt = GFncRtnDS(GSCnBalConn, "select distinct tdate from acbal where tdate between '" & startDate & "' and '" & endDate & "' order by tdate").Tables(0)
        End If
        Dim day As Integer = timeDt.Rows.Count
        If day = 0 Then
            Return Nothing
        End If

        tempdt = FncGetClientMaster()
        For Each dr As DataRow In dt.Rows
            For Each dr2 As DataRow In tempdt.Rows
                If dr2.Item(0) = dr.Item(1) Then
                    dr.Item(2) = dr2.Item(1)
                End If
            Next
        Next

        tempdt = FncGetGroupList()
        Try
            If type = "ipo_loan" Then
                sqlStr = "Create table #temp (list_name varchar(20),client_code varchar(10))"
                GFncRunSQL(GSCnSqlConn, sqlStr)
                For Each dr As DataRow In tempdt.Rows
                    sqlStr = "insert into #temp values ('" & dr.Item(0).ToString.Trim & "','" & dr.Item(1).ToString.Trim & "')"
                    GFncRunSQL(GSCnSqlConn, sqlStr)
                Next
                Dim count As Integer = 3
                For Each dr As DataRow In timeDt.Rows

                    sqlStr = "select b.list_name,b.client_code,a.ipo_loan as balance from ipoloan a,#temp b where a.client_code = b.client_code collate Chinese_Taiwan_Stroke_CI_AS and a.loan_date = '" & _
                    Format(dr.Item(0), "yyyy/MM/dd") & "' order by b.list_name,b.client_code"
                    tempdt2 = GFncRtnDS(GSCnSqlConn, sqlStr).Tables(0)
                    For Each dr2 As DataRow In tempdt2.Rows
                        For Each dr3 As DataRow In dt.Rows
                            If dr3.Item(0) = dr2.Item(0) And dr3.Item(1) = dr2.Item(1) Then
                                If dr2.Item(2) < 0 Then
                                    dr3.Item(count) = dr2.Item(2)
                                End If
                            End If
                        Next

                    Next
                    count += 1
                Next

            Else
                sqlStr = "Create table #temp (list_name varchar(20),client_code varchar(10))"
                GFncRunSQL(GSCnBalConn, sqlStr)
                For Each dr As DataRow In tempdt.Rows
                    sqlStr = "insert into #temp values ('" & dr.Item(0).ToString.Trim & "','" & dr.Item(1).ToString.Trim & "')"
                    GFncRunSQL(GSCnBalConn, sqlStr)
                Next
                Dim count As Integer = 3
                For Each dr As DataRow In timeDt.Rows

                    sqlStr = "select b.list_name,b.client_code,a." & type & " as balance from acbal a,#temp b where a.accno = b.client_code collate Chinese_Taiwan_Stroke_CI_AS and a.tdate = '" & _
                    Format(dr.Item(0), "yyyy/MM/dd") & "' order by b.list_name,b.client_code"
                    tempdt2 = GFncRtnDS(GSCnBalConn, sqlStr).Tables(0)
                    For Each dr2 As DataRow In tempdt2.Rows
                        For Each dr3 As DataRow In dt.Rows
                            If dr3.Item(0) = dr2.Item(0) And dr3.Item(1) = dr2.Item(1) Then
                                If dr2.Item(2) < 0 Then
                                    dr3.Item(count) = dr2.Item(2)
                                End If
                            End If
                        Next

                    Next
                    count += 1
                Next


            End If
        Catch ex As Exception
        Finally
            sqlStr = "drop table #temp"
            If type = "ipo_loan" Then
                GFncRunSQL(GSCnSqlConn, sqlStr)
            Else
                GFncRunSQL(GSCnBalConn, sqlStr)
            End If
        End Try
        Dim mtin1 As Date
        If tin1.Month < 4 Then
            mtin1 = New Date(tin1.Year - 1, 4, 1)
        Else
            mtin1 = New Date(tin1.Year, 4, 1)
        End If

        Dim mt1 As String = Format(mtin1, "yyyy/MM/dd")
        Dim mt2 As String = Format(tin2, "yyyy/MM/dd")
        tempdt = FncGetMinimum(mt1, mt2, type)
        Dim list As String = ""
        Dim listcount As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr.Item(0) = list Then
            Else
                dr.Item("min") = tempdt.Rows(listcount).Item(1)
                list = dr.Item(0)
                listcount += 1
            End If
        Next

        Return dt
    End Function

    'Protected Friend Function FncGenReport(ByVal tin1 As Date, ByVal tin2 As Date, ByVal type As String) As ReportClass
    '    Dim t1 As String = Format(tin1, "yyyy/MM/dd")
    '    Dim t2 As String = Format(tin2, "yyyy/MM/dd")
    '    Dim rpt As ReportClass = New rptCRCConTrans
    '    Dim str As String = "select list_name as list, clt_code as client, '' as name"
    '    For i As Integer = 1 To 23
    '        str = str & ", 0.00 as balance" & i
    '    Next
    '    str = str & ", 0.00 as min from contran order by list_name"
    '    Dim dt As DataTable = New DtsConnectedTransaction.CRCConTransDataTable
    '    dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
    '    Dim timeDt As DataTable
    '    If type = "ipo_loan" Then
    '        timeDt = GFncRtnDS(GSCnSqlConn, "select distinct loan_date as tdate from ipoloan where loan_date between '" & t1 & "' and '" & t2 & "' order by loan_date").Tables(0)
    '    Else
    '        timeDt = GFncRtnDS(GSCnBalConn, "select distinct tdate from acbal where tdate between '" & t1 & "' and '" & t2 & "' order by tdate").Tables(0)
    '    End If
    '    Dim day As Integer = timeDt.Rows.Count
    '    If day = 0 Then
    '        Return Nothing
    '    End If

    '    Dim str1 As String = "select a.clt_code, a.clt_name"
    '    Dim str2 As String = " from STCLTMASTER a "
    '    For i As Integer = 0 To day - 1
    '        If type = "ipo_loan" Then
    '            str = "select client_code as accno, " & type & " as balance into #m" & i + 1 & " from ipoloan where loan_date = '" & Format(CDate(GFncNoNullString(timeDt.Rows(i).Item("tdate")).Trim), "yyyy/MM/dd") & "'"
    '            GFncRunSQL(GSCnSqlConn, str)
    '        Else
    '            str = "select accno, " & type & " as balance into #m" & i + 1 & " from acbal where tdate = '" & Format(CDate(GFncNoNullString(timeDt.Rows(i).Item("tdate")).Trim), "yyyy/MM/dd") & "'"
    '            GFncRunSQL(GSCnBalConn, str)
    '        End If
    '        GFncRunSQL(GSCnLiqConn, str)
    '        str1 = str1 & ", #m" & i + 1 & ".balance as balance" & i + 1
    '        str2 = str2 & "left join #m" & i + 1 & " on a.clt_code = #m" & i + 1 & ".accno "
    '    Next
    '    str = str1 & str2 & "order by a.clt_code"
    '    Dim tempDT As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)
    '    For i As Integer = 0 To day - 1
    '        str = "drop table #m" & i + 1
    '        GFncRunSQL(GSCnLiqConn, str)
    '    Next
    '    For Each dr As DataRow In dt.Rows
    '        For i As Integer = 0 To day - 1
    '            If dr("balance" & i + 1) > 0 Then
    '                dr("balance" & i + 1) = 0
    '            End If
    '        Next
    '    Next
    '    Dim clt As String = ""
    '    Dim list As String = dt.Rows(0).Item("list").ToString.Trim
    '    Dim minimum(22) As Double
    '    Dim startRow As Integer = 0
    '    Dim current As Integer = -1


    '    '''''''''''''''''
    '    Dim mtin1 As Date
    '    If tin1.Month < 4 Then
    '        mtin1 = New Date(tin1.Year - 1, 4, 1)
    '    Else
    '        mtin1 = New Date(tin1.Year, 4, 1)
    '        'mtin1.AddMonths(2)
    '        'AddMonths(4 - mtin1.Month)
    '        'mtin1.AddDays(1 - mtin1.Day)
    '    End If

    '    Dim mt1 As String = Format(mtin1, "yyyy/MM/dd")
    '    Dim mt2 As String = Format(tin2, "yyyy/MM/dd")
    '    't1 = "2008/06/01"
    '    't2 = "2008/06/10"
    '    Dim mrpt As ReportClass = New rptCRCConTrans
    '    Dim mstr As String = "select list_name as list, clt_code as client, '' as name"
    '    For i As Integer = 1 To 23
    '        mstr = mstr & ", 0.00 as balance" & i
    '    Next
    '    mstr = mstr & ", 0.00 as min from contran order by list_name"
    '    Dim mdt As DataTable = New DtsConnectedTransaction.CRCConTransDataTable
    '    mdt = GFncRtnDS(GSCnSqlConn, mstr).Tables(0)
    '    Dim mtimeDt As DataTable
    '    If type = "ipo_loan" Then
    '        mtimeDt = GFncRtnDS(GSCnLiqConn, "select distinct loan_date as tdate from ipoloan where loan_date between '" & mt1 & "' and '" & mt2 & "' order by tdate").Tables(0)
    '    Else
    '        mtimeDt = GFncRtnDS(GSCnLiqConn, "select distinct tdate from acbal where tdate between '" & mt1 & "' and '" & mt2 & "' order by tdate").Tables(0)
    '    End If
    '    Dim mday As Integer = mtimeDt.Rows.Count
    '    If mday = 0 Then
    '        Return Nothing
    '    End If

    '    Dim mstr1 As String = "select a.clt_code, a.clt_name"
    '    Dim mstr2 As String = " from STCLTMASTER a "
    '    For i As Integer = 0 To mday - 1
    '        If type = "ipo_loan" Then
    '            mstr = "select client_code as accno, " & type & " as balance into #m" & i + 1 & " from ipoloan where loan_date = '" & Format(CDate(GFncNoNullString(mtimeDt.Rows(i).Item("tdate")).Trim), "yyyy/MM/dd") & "'"

    '        Else
    '            mstr = "select accno, " & type & " as balance into #m" & i + 1 & " from acbal where tdate = '" & Format(CDate(GFncNoNullString(mtimeDt.Rows(i).Item("tdate")).Trim), "yyyy/MM/dd") & "'"
    '        End If
    '        GFncRunSQL(GSCnLiqConn, mstr)
    '        mstr1 = mstr1 & ", #m" & i + 1 & ".balance as balance" & i + 1
    '        mstr2 = mstr2 & "left join #m" & i + 1 & " on a.clt_code = #m" & i + 1 & ".accno "
    '    Next
    '    mstr = mstr1 & mstr2 & "order by a.clt_code"
    '    Dim mtempDT As DataTable = GFncRtnDS(GSCnLiqConn, mstr).Tables(0)
    '    For i As Integer = 0 To mday - 1
    '        mstr = "drop table #m" & i + 1
    '        GFncRunSQL(GSCnLiqConn, mstr)
    '    Next
    '    For Each dr As DataRow In mtempDT.Rows
    '        For i As Integer = 0 To mday - 1
    '            If dr("balance" & i + 1).ToString.Trim <> "" Then
    '                If dr("balance" & i + 1) > 0 Then
    '                    dr("balance" & i + 1) = 0
    '                End If
    '            End If
    '        Next
    '    Next
    '    For Each dr As DataRow In tempDT.Rows
    '        For i As Integer = 0 To day - 1
    '            If dr("balance" & i + 1).ToString.Trim <> "" Then
    '                If dr("balance" & i + 1) > 0 Then
    '                    dr("balance" & i + 1) = 0
    '                End If
    '            End If
    '        Next
    '    Next

    '    ''''''''''''''''''''''

    '    For Each dr As DataRow In dt.Rows
    '        current += 1
    '        If dr("list").ToString.Trim <> list Or current = dt.Rows.Count - 1 Then
    '            list = dr("list").ToString.Trim
    '            dt.Rows(startRow).Item("min") = getMin(minimum, mday)
    '            startRow = current
    '        End If

    '        clt = dr("client").ToString.Trim
    '        For Each tempdr As DataRow In mtempDT.Rows
    '            If tempdr("clt_code").ToString.Trim > clt Then
    '                Exit For
    '            End If
    '            If tempdr("clt_code").ToString.Trim = clt Then
    '                For i As Integer = 0 To mday - 1
    '                    If tempdr("balance" & i + 1).ToString.Trim <> "" Then
    '                        If tempdr("balance" & i + 1) < 0 Then
    '                            minimum(i) += tempdr("balance" & i + 1)
    '                        End If
    '                    End If
    '                Next
    '                Exit For
    '            End If
    '        Next
    '        For Each tempdr As DataRow In tempDT.Rows
    '            If tempdr("clt_code").ToString.Trim > clt Then
    '                Exit For
    '            End If
    '            If tempdr("clt_code").ToString.Trim = clt Then
    '                dr("name") = GFncNoNullString(tempdr("clt_name").ToString.Trim)
    '                For i As Integer = 0 To day - 1
    '                    dr("balance" & i + 1) = GFncNoNullValue(tempdr("balance" & i + 1))
    '                Next
    '                Exit For
    '            End If
    '        Next
    '    Next



    '    rpt.SetDataSource(dt)
    '    rpt.SetParameterValue("user", Trim(GStrloginID))
    '    rpt.SetParameterValue("day", day)
    '    If type = "led_bal" Then
    '        rpt.SetParameterValue("Type", "Ledger Balance")
    '    ElseIf type = "ava_bal" Then
    '        rpt.SetParameterValue("Type", "Available Balance")
    '    Else
    '        rpt.SetParameterValue("Type", "IPO Loan")
    '    End If

    '    For i As Integer = 0 To 7
    '        If i + 16 < day Then
    '            rpt.SetParameterValue("day" & i + 1 & "", GFncNoNullString(timeDt.Rows(i).Item("tdate")) & vbCrLf & GFncNoNullString(timeDt.Rows(i + 8).Item("tdate")) & vbCrLf & GFncNoNullString(timeDt.Rows(i + 16).Item("tdate")))
    '        ElseIf i + 8 < day Then
    '            rpt.SetParameterValue("day" & i + 1 & "", GFncNoNullString(timeDt.Rows(i).Item("tdate")) & vbCrLf & GFncNoNullString(timeDt.Rows(i + 8).Item("tdate")))
    '        ElseIf i < day Then
    '            rpt.SetParameterValue("day" & i + 1 & "", GFncNoNullString(timeDt.Rows(i).Item("tdate")))
    '        Else
    '            rpt.SetParameterValue("day" & i + 1 & "", "")
    '        End If
    '    Next
    '    Return rpt
    'End Function

    Protected Friend Function FncGenReport1(ByVal tin1 As Date, ByVal tin2 As Date, ByVal type As String) As ReportClass
        Dim rpt As ReportClass = New rptCRCConTrans
        Dim str As String = "select list_name as list, clt_code as client, '' as name"
        Dim t1 As String = Format(tin1, "yyyy/MM/dd")
        Dim t2 As String = Format(tin2, "yyyy/MM/dd")
        Dim dt As DataTable = New DtsConnectedTransaction.CRCConTransDataTable
        dt = FncGetBal(tin1, tin2, type)
        Dim timeDt As DataTable
        If type = "ipo_loan" Then
            timeDt = GFncRtnDS(GSCnSqlConn, "select distinct loan_date as tdate from ipoloan where loan_date between '" & t1 & "' and '" & t2 & "' order by loan_date").Tables(0)
        Else
            timeDt = GFncRtnDS(GSCnBalConn, "select distinct tdate from acbal where tdate between '" & t1 & "' and '" & t2 & "' order by tdate").Tables(0)
        End If
        Dim day As Integer = timeDt.Rows.Count
        If day = 0 Then
            Return Nothing
        End If


        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("day", day)
        If type = "led_bal" Then
            rpt.SetParameterValue("Type", "Ledger Balance")
        ElseIf type = "ava_bal" Then
            rpt.SetParameterValue("Type", "Available Balance")
        Else
            rpt.SetParameterValue("Type", "IPO Loan")
        End If

        For i As Integer = 0 To 7
            If i + 16 < day Then
                rpt.SetParameterValue("day" & i + 1 & "", GFncNoNullString(timeDt.Rows(i).Item("tdate")) & vbCrLf & GFncNoNullString(timeDt.Rows(i + 8).Item("tdate")) & vbCrLf & GFncNoNullString(timeDt.Rows(i + 16).Item("tdate")))
            ElseIf i + 8 < day Then
                rpt.SetParameterValue("day" & i + 1 & "", GFncNoNullString(timeDt.Rows(i).Item("tdate")) & vbCrLf & GFncNoNullString(timeDt.Rows(i + 8).Item("tdate")))
            ElseIf i < day Then
                rpt.SetParameterValue("day" & i + 1 & "", GFncNoNullString(timeDt.Rows(i).Item("tdate")))
            Else
                rpt.SetParameterValue("day" & i + 1 & "", "")
            End If
        Next
        Return rpt
    End Function

    Private Function getMin(ByRef min() As Double, ByVal length As Integer) As Double
        Dim i As Integer = 1
        Dim minimum As Double = min(0)
        min(0) = 0
        While i <= length - 1
            If minimum > min(i) Then
                minimum = min(i)
            End If
            min(i) = 0
            i += 1
        End While
        Return minimum
    End Function

    Protected Friend Function FncExport1(ByVal tin1 As Date, ByVal tin2 As Date, ByVal type As String) As Boolean
        Dim rpt As ReportClass = New rptCRCConTrans
        Dim t1 As String = Format(tin1, "yyyy/MM/dd")
        Dim t2 As String = Format(tin2, "yyyy/MM/dd")
        Dim str As String = "select list_name as list, clt_code as client, '' as name"
        For i As Integer = 1 To 23
            str = str & ", 0.00 as balance" & i
        Next
        str = str & ", 0.00 as min from contran order by list_name"
        Dim dt As DataTable = New DtsConnectedTransaction.CRCConTransDataTable
        dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim tempdt As DataTable = FncGetBal(tin1, tin2, type)
        Dim timeDt As DataTable
        If type = "ipo_loan" Then
            timeDt = GFncRtnDS(GSCnSqlConn, "select distinct loan_date as tdate from ipoloan where loan_date between '" & t1 & "' and '" & t2 & "' order by loan_date").Tables(0)
        Else
            timeDt = GFncRtnDS(GSCnBalConn, "select distinct tdate from acbal where tdate between '" & t1 & "' and '" & t2 & "' order by tdate").Tables(0)
        End If
        Dim day As Integer = timeDt.Rows.Count
        If day = 0 Then
            Return Nothing
        End If

        Dim strExFile As String = "CRCCT_" & type & Format(Now(), "yyyyMMdd") & ".xls"
        Dim strFiles() As String
        Dim alignCentre As Integer = -4108
        Dim alignRight As Integer = -4152
        Dim edgeTop As Integer = 8
        Dim edgeBottom As Integer = 9
        Dim edgeLeft As Integer = 1
        Dim edgeRight As Integer = 2
        Dim continuous As Integer = 1
        Dim ldouble As Integer = -4119
        Dim dot As Integer = -4118
        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim xlWorkSheet As Object
        Dim xlRange As Object
        xlApp = CreateObject("Excel.Application")
        xlWorkBook = xlApp.Workbooks.Add()
        xlWorkBook.Activate()
        xlApp.Visible = False
        'xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
        xlWorkSheet = xlWorkBook.Worksheets(1)
        Try
            strFiles = System.IO.Directory.GetFiles(GStrExptDir, strExFile)
            For Each strFile As String In strFiles
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next
            xlWorkSheet.Columns("A:A").ColumnWidth = 20
            xlWorkSheet.Columns("B:B").ColumnWidth = 12
            xlWorkSheet.Columns("C:C").ColumnWidth = 35
            xlWorkSheet.Columns("D:D").ColumnWidth = 14
            xlWorkSheet.Columns("E:E").ColumnWidth = 14
            xlWorkSheet.Columns("F:F").ColumnWidth = 14
            xlWorkSheet.Columns("G:G").ColumnWidth = 14
            xlWorkSheet.Columns("H:H").ColumnWidth = 14
            xlWorkSheet.Columns("I:I").ColumnWidth = 14
            xlWorkSheet.Columns("J:J").ColumnWidth = 14
            xlWorkSheet.Columns("K:K").ColumnWidth = 14
            xlWorkSheet.Columns("L:L").ColumnWidth = 14
            xlWorkSheet.Columns("M:M").ColumnWidth = 14
            xlWorkSheet.Columns("N:N").ColumnWidth = 14
            xlWorkSheet.Columns("O:O").ColumnWidth = 14
            xlWorkSheet.Columns("P:P").ColumnWidth = 14
            xlWorkSheet.Columns("Q:Q").ColumnWidth = 14
            xlWorkSheet.Columns("R:R").ColumnWidth = 14
            xlWorkSheet.Columns("S:S").ColumnWidth = 14
            xlWorkSheet.Columns("T:T").ColumnWidth = 14
            xlWorkSheet.Columns("U:U").ColumnWidth = 14
            xlWorkSheet.Columns("V:V").ColumnWidth = 14
            xlWorkSheet.Columns("W:W").ColumnWidth = 14
            xlWorkSheet.Columns("X:X").ColumnWidth = 14
            xlWorkSheet.Columns("Y:Y").ColumnWidth = 14
            xlWorkSheet.Columns("Z:Z").ColumnWidth = 14

            xlWorkSheet.Cells(1, 1) = "Client Group"
            xlWorkSheet.Cells(1, 2) = "Client Code"
            xlWorkSheet.Cells(1, 3) = "Client Name"
            For i As Integer = 4 To day + 3
                xlWorkSheet.Cells(1, i) = timeDt.Rows(i - 4).Item("tdate").ToString.Substring(0, timeDt.Rows(i - 4).Item("tdate").ToString.IndexOf(" ")).Trim
            Next
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 3 + day))
            xlRange.Font.Bold = True
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 3

            Dim row As Integer = 2
            Dim clt As String = ""
            Dim list As String = tempdt.Rows(0).Item("list").ToString.Trim
            Dim startRow As Integer = 0
            Dim count As Integer = 0
            For Each dr As DataRow In tempdt.Rows
                If dr("list").ToString.Trim <> list Then
                    xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row, 1), xlWorkSheet.Cells(row, 3 + day))
                    xlRange.Borders(edgeBottom).LineStyle = continuous
                    xlRange.Borders(edgeBottom).Weight = 2
                    list = dr("list").ToString.Trim
                    row += 1
                End If
                row += 1
                'clt = dr("client").ToString.Trim
                'For Each tempdr As DataRow In tempdt.Rows
                'If tempdr("client").ToString.Trim > clt Then
                'Exit For
                'End If
                'If tempdr("client").ToString.Trim = clt Then
                xlWorkSheet.Cells(row, 1) = "=""" & dr("list").ToString.Trim & """"
                xlWorkSheet.Cells(row, 2) = "=""" & dr("client").ToString.Trim & """"
                xlWorkSheet.Cells(row, 3) = dr("name").ToString.Trim
                For i As Integer = 0 To day - 1
                    xlWorkSheet.Cells(row, 4 + i) = GFncNoNullValue(dr("balance" & i + 1))
                Next
                'Exit For
                'End If
            Next
            'Next
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(row, day + 3))
            xlRange.Font.Name = "Times New Roman"
            xlRange.NumberFormat = "#,##0.00_);(#,##0.00)"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(3, 3), xlWorkSheet.Cells(row, 3))
            xlRange.Font.Size = 10

            xlWorkBook.SaveAs(GStrExptDir & strExFile)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            GC.Collect()
            GC.WaitForPendingFinalizers()
            Return True
        Catch ex As Exception
            xlWorkBook.close()
            xlApp.Quit()
            GC.Collect()
            GSubWriteErrLog(ex.Message)
            GSubShowInfo(GFncGetSysMsg(89))
        End Try
    End Function

    'Protected Friend Function FncExport(ByVal tin1 As Date, ByVal tin2 As Date, ByVal type As String) As Boolean
    '    Dim t1 As String = Format(tin1, "yyyy/MM/dd")
    '    Dim t2 As String = Format(tin2, "yyyy/MM/dd")
    '    t1 = "2008/06/01"
    '    t2 = "2008/06/10"
    '    Dim rpt As ReportClass = New rptCRCConTrans
    '    Dim str As String = "select list_name as list, clt_code as client, '' as name"
    '    For i As Integer = 1 To 25
    '        str = str & ", 0.00 as balance" & i
    '    Next
    '    str = str & ", 0.00 as min from contran order by list_name"
    '    Dim dt As DataTable = New DtsConnectedTransaction.CRCConTransDataTable
    '    dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
    '    Dim timeDt As DataTable
    '    If type = "ipo_loan" Then
    '        timeDt = GFncRtnDS(GSCnLiqConn, "select distinct loan_date as tdate from ipoloan where loan_date between '" & t1 & "' and '" & t2 & "' order by tdate").Tables(0)
    '    Else
    '        timeDt = GFncRtnDS(GSCnLiqConn, "select distinct tdate from acbal where tdate between '" & t1 & "' and '" & t2 & "' order by tdate").Tables(0)
    '    End If
    '    Dim day As Integer = timeDt.Rows.Count
    '    If day = 0 Then
    '        Return Nothing
    '    End If

    '    Dim str1 As String = "select a.clt_code, a.clt_name"
    '    Dim str2 As String = " from STCLTMASTER a "
    '    For i As Integer = 0 To day - 1
    '        If type = "ipo_loan" Then
    '            str = "select client_code as accno, " & type & " as balance into #m" & i + 1 & " from ipoloan where loan_date = '" & Format(CDate(GFncNoNullString(timeDt.Rows(i).Item("tdate")).Trim), "yyyy/MM/dd") & "'"

    '        Else
    '            str = "select accno, " & type & " as balance into #m" & i + 1 & " from acbal where tdate = '" & Format(CDate(GFncNoNullString(timeDt.Rows(i).Item("tdate")).Trim), "yyyy/MM/dd") & "'"
    '        End If
    '        GFncRunSQL(GSCnLiqConn, str)
    '        str1 = str1 & ", #m" & i + 1 & ".balance as balance" & i + 1
    '        str2 = str2 & "left join #m" & i + 1 & " on a.clt_code = #m" & i + 1 & ".accno "
    '    Next
    '    str = str1 & str2 & "order by a.clt_code"
    '    Dim tempDT As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)
    '    For i As Integer = 0 To day - 1
    '        str = "drop table #m" & i + 1
    '        GFncRunSQL(GSCnLiqConn, str)
    '    Next
    '    For Each dr As DataRow In dt.Rows
    '        For i As Integer = 0 To day - 1
    '            If dr("balance" & i + 1) > 0 Then
    '                dr("balance" & i + 1) = 0
    '            End If
    '        Next
    '    Next

    '    Dim strExFile As String = "CRCCT_" & type & Format(Now(), "yyyyMMdd") & ".xls"
    '    Dim strFiles() As String
    '    Dim alignCentre As Integer = -4108
    '    Dim alignRight As Integer = -4152
    '    Dim edgeTop As Integer = 8
    '    Dim edgeBottom As Integer = 9
    '    Dim edgeLeft As Integer = 1
    '    Dim edgeRight As Integer = 2
    '    Dim continuous As Integer = 1
    '    Dim ldouble As Integer = -4119
    '    Dim dot As Integer = -4118
    '    Dim xlApp As Object
    '    Dim xlWorkBook As Object
    '    Dim xlWorkSheet As Object
    '    Dim xlRange As Object
    '    xlApp = CreateObject("Excel.Application")
    '    xlWorkBook = xlApp.Workbooks.Add()
    '    xlWorkBook.Activate()
    '    xlApp.Visible = False
    '    xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
    '    Try
    '        strFiles = System.IO.Directory.GetFiles(GStrExptDir, strExFile)
    '        For Each strFile As String In strFiles
    '            Application.DoEvents()
    '            System.IO.File.Delete(strFile)
    '        Next
    '        xlWorkSheet.Columns("A:A").ColumnWidth = 20
    '        xlWorkSheet.Columns("B:B").ColumnWidth = 12
    '        xlWorkSheet.Columns("C:C").ColumnWidth = 35
    '        xlWorkSheet.Columns("D:D").ColumnWidth = 14
    '        xlWorkSheet.Columns("E:E").ColumnWidth = 14
    '        xlWorkSheet.Columns("F:F").ColumnWidth = 14
    '        xlWorkSheet.Columns("G:G").ColumnWidth = 14
    '        xlWorkSheet.Columns("H:H").ColumnWidth = 14
    '        xlWorkSheet.Columns("I:I").ColumnWidth = 14
    '        xlWorkSheet.Columns("J:J").ColumnWidth = 14
    '        xlWorkSheet.Columns("K:K").ColumnWidth = 14
    '        xlWorkSheet.Columns("L:L").ColumnWidth = 14
    '        xlWorkSheet.Columns("M:M").ColumnWidth = 14
    '        xlWorkSheet.Columns("N:N").ColumnWidth = 14
    '        xlWorkSheet.Columns("O:O").ColumnWidth = 14
    '        xlWorkSheet.Columns("P:P").ColumnWidth = 14
    '        xlWorkSheet.Columns("Q:Q").ColumnWidth = 14
    '        xlWorkSheet.Columns("R:R").ColumnWidth = 14
    '        xlWorkSheet.Columns("S:S").ColumnWidth = 14
    '        xlWorkSheet.Columns("T:T").ColumnWidth = 14
    '        xlWorkSheet.Columns("U:U").ColumnWidth = 14
    '        xlWorkSheet.Columns("V:V").ColumnWidth = 14
    '        xlWorkSheet.Columns("W:W").ColumnWidth = 14
    '        xlWorkSheet.Columns("X:X").ColumnWidth = 14
    '        xlWorkSheet.Columns("Y:Y").ColumnWidth = 14
    '        xlWorkSheet.Columns("Z:Z").ColumnWidth = 14

    '        xlWorkSheet.Cells(1, 1) = "Client Group"
    '        xlWorkSheet.Cells(1, 2) = "Client Code"
    '        xlWorkSheet.Cells(1, 3) = "Client Name"
    '        For i As Integer = 4 To day + 3
    '            xlWorkSheet.Cells(1, i) = timeDt.Rows(i - 4).Item("tdate").ToString.Substring(0, timeDt.Rows(i - 4).Item("tdate").ToString.IndexOf(" ")).Trim
    '        Next
    '        xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 3 + day))
    '        xlRange.Font.Bold = True
    '        xlRange.Borders(edgeBottom).LineStyle = continuous
    '        xlRange.Borders(edgeBottom).Weight = 3

    '        Dim row As Integer = 2
    '        Dim clt As String = ""
    '        Dim list As String = dt.Rows(0).Item("list").ToString.Trim
    '        Dim startRow As Integer = 0
    '        For Each dr As DataRow In dt.Rows
    '            If dr("list").ToString.Trim <> list Then
    '                xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row, 1), xlWorkSheet.Cells(row, 3 + day))
    '                xlRange.Borders(edgeBottom).LineStyle = continuous
    '                xlRange.Borders(edgeBottom).Weight = 2
    '                list = dr("list").ToString.Trim
    '                row += 1
    '            End If
    '            row += 1
    '            clt = dr("client").ToString.Trim
    '            For Each tempdr As DataRow In tempDT.Rows
    '                If tempdr("clt_code").ToString.Trim > clt Then
    '                    Exit For
    '                End If
    '                If tempdr("clt_code").ToString.Trim = clt Then
    '                    xlWorkSheet.Cells(row, 1) = "=""" & dr("list").ToString.Trim & """"
    '                    xlWorkSheet.Cells(row, 2) = "=""" & clt & """"
    '                    xlWorkSheet.Cells(row, 3) = tempdr("clt_name").ToString.Trim
    '                    For i As Integer = 0 To day - 1
    '                        xlWorkSheet.Cells(row, 4 + i) = GFncNoNullValue(tempdr("balance" & i + 1))
    '                    Next
    '                    Exit For
    '                End If
    '            Next
    '        Next
    '        xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(row, day + 3))
    '        xlRange.Font.Name = "Times New Roman"
    '        xlRange.NumberFormat = "#,##0.00_);(#,##0.00)"

    '        xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(3, 3), xlWorkSheet.Cells(row, 3))
    '        xlRange.Font.Size = 10

    '        xlWorkBook.SaveAs(GStrExptDir & strExFile)
    '        xlWorkBook.Close()
    '        xlApp.Quit()
    '        releaseObject(xlWorkSheet)
    '        releaseObject(xlWorkBook)
    '        releaseObject(xlApp)
    '        GC.Collect()
    '        GC.WaitForPendingFinalizers()
    '        Return True
    '    Catch ex As Exception
    '        xlWorkBook.close()
    '        xlApp.Quit()
    '        GC.Collect()
    '        GSubWriteErrLog(ex.Message)
    '        GSubShowInfo(GFncGetSysMsg(89))
    '    End Try
    'End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class
