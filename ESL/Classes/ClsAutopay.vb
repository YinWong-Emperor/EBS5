Imports System.IO
Imports System.Data.SqlClient

Public Class ClsAutopay

    Protected Friend headerArray(13, 3) As String
    Protected Friend recordArray(10, 3) As String

    Protected Friend AutoPlanCode As Integer = 1
    Protected Friend FirstPartyAccNo As Integer = 2
    Protected Friend PaymentCode As Integer = 3
    Protected Friend FirstPartyRef As Integer = 4
    Protected Friend HValueDate As Integer = 5
    Protected Friend InputMedium As Integer = 6
    Protected Friend FileName As Integer = 7
    Protected Friend NoOfRec As Integer = 8
    Protected Friend MonetaryTotal As Integer = 9
    Protected Friend OverflowCount As Integer = 10
    Protected Friend OverflowAmount As Integer = 11
    Protected Friend HFiller As Integer = 12
    Dim CentreCode As Integer = 13

    Protected Friend RFiller As Integer = 1
    Protected Friend SecondPartyID As Integer = 2
    Protected Friend SecondPartyBankAcc As Integer = 3
    Protected Friend SecondPartyBankNo As Integer = 4
    Protected Friend SecondPartyBranch As Integer = 5
    Protected Friend SecondPartyAcc As Integer = 6
    Protected Friend Amount As Integer = 7
    Protected Friend RValueDate As Integer = 8
    Protected Friend SecondPartyIDCon As Integer = 9
    Protected Friend SecondPartyReference As Integer = 10

    Protected Friend start As Integer = 1
    Protected Friend strSize As Integer = 2
    Protected Friend descpt As Integer = 3

    Protected Friend Function checkAlphaNumeric(ByVal strInputText As String) As Boolean
        Dim intCounter As Integer
        Dim strCompare As String
        Dim strInput As String
        checkAlphaNumeric = False

        If (strInputText.Length > 0) Then
            For intCounter = 1 To strInputText.Length
                strCompare = Mid$(strInputText, intCounter, 1)
                strInput = Mid$(strInputText, intCounter + 1, strInputText.Length)
                If strCompare Like ("[A-Z]") Or strCompare Like ("[a-z]") Or strCompare Like ("#") _
                    Or strCompare Like ("-") Or strCompare Like (" ") Then
                    checkAlphaNumeric = True
                Else
                    checkAlphaNumeric = False
                    Exit Function
                End If
            Next intCounter
        Else
            checkAlphaNumeric = True
        End If
    End Function

    Protected Friend Function checkAlphabetic(ByVal strInputText As String) As Boolean
        Dim intCounter As Integer
        Dim strCompare As String
        Dim strInput As String
        checkAlphabetic = False

        If (strInputText.Length > 0) Then
            For intCounter = 1 To Len(strInputText)
                strCompare = Mid$(strInputText, intCounter, 1)
                strInput = Mid$(strInputText, intCounter + 1, strInputText.Length)
                If strCompare Like ("[A-Z]") Or strCompare Like ("[a-z]") Or strCompare Like ("-") Or strCompare Like (" ") Then
                    checkAlphabetic = True
                Else
                    checkAlphabetic = False
                    Exit Function
                End If
            Next intCounter
        Else
            checkAlphabetic = True
        End If
    End Function

    Protected Friend Function checkNumeric(ByVal strInputText As String) As Boolean
        Try
            Dim value As Decimal = CDec(strInputText)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Friend Sub loadArray()
        headerArray(AutoPlanCode, start) = 1
        headerArray(AutoPlanCode, strSize) = 1
        headerArray(AutoPlanCode, descpt) = "Autoplan Code"
        headerArray(FirstPartyAccNo, start) = 2
        headerArray(FirstPartyAccNo, strSize) = 12
        headerArray(FirstPartyAccNo, descpt) = "First Party Current Account Number"
        headerArray(PaymentCode, start) = 14
        headerArray(PaymentCode, strSize) = 3
        headerArray(PaymentCode, descpt) = "Payment Code assigned by APC"
        headerArray(FirstPartyRef, start) = 17
        headerArray(FirstPartyRef, strSize) = 12
        headerArray(FirstPartyRef, descpt) = "First Party Reference"
        headerArray(HValueDate, start) = 29
        headerArray(HValueDate, strSize) = 6
        headerArray(HValueDate, descpt) = "Value Date"
        headerArray(InputMedium, start) = 35
        headerArray(InputMedium, strSize) = 1
        headerArray(InputMedium, descpt) = "Input Medium"
        headerArray(FileName, start) = 36
        headerArray(FileName, strSize) = 8
        headerArray(FileName, descpt) = "File Name"
        headerArray(NoOfRec, start) = 44
        headerArray(NoOfRec, strSize) = 5
        headerArray(NoOfRec, descpt) = "Number of Record in the Batch"
        headerArray(MonetaryTotal, start) = 49
        headerArray(MonetaryTotal, strSize) = 10
        headerArray(MonetaryTotal, descpt) = "Monetary Total of all Records in the Batch"
        headerArray(OverflowCount, start) = 59
        headerArray(OverflowCount, strSize) = 7
        headerArray(OverflowCount, descpt) = "Overflow Count"
        headerArray(OverflowAmount, start) = 66
        headerArray(OverflowAmount, strSize) = 12
        headerArray(OverflowAmount, descpt) = "Overflow Amount"
        headerArray(HFiller, start) = 78
        headerArray(HFiller, strSize) = 2
        headerArray(HFiller, descpt) = "FILLER"
        headerArray(CentreCode, start) = 80
        headerArray(CentreCode, strSize) = 1
        headerArray(CentreCode, descpt) = "Centre Code"

        recordArray(RFiller, start) = 1
        recordArray(RFiller, strSize) = 1
        recordArray(RFiller, descpt) = "FILLER"
        recordArray(SecondPartyID, start) = 2
        recordArray(SecondPartyID, strSize) = 12
        recordArray(SecondPartyID, descpt) = "Second Party Identifier"
        recordArray(SecondPartyBankAcc, start) = 14
        recordArray(SecondPartyBankAcc, strSize) = 20
        recordArray(SecondPartyBankAcc, descpt) = "Second Party Bank Account Name"
        recordArray(SecondPartyBankNo, start) = 34
        recordArray(SecondPartyBankNo, strSize) = 3
        recordArray(SecondPartyBankNo, descpt) = "Second Party Bank Number"
        recordArray(SecondPartyBranch, start) = 37
        recordArray(SecondPartyBranch, strSize) = 3
        recordArray(SecondPartyBranch, descpt) = "Second Party Branch Number"
        recordArray(SecondPartyAcc, start) = 40
        recordArray(SecondPartyAcc, strSize) = 9
        recordArray(SecondPartyAcc, descpt) = "Second Party Account"
        recordArray(Amount, start) = 49
        recordArray(Amount, strSize) = 10
        recordArray(Amount, descpt) = "Amount in dollars and cents"
        recordArray(RValueDate, start) = 59
        recordArray(RValueDate, strSize) = 4
        recordArray(RValueDate, descpt) = "Value Date"
        recordArray(SecondPartyIDCon, start) = 63
        recordArray(SecondPartyIDCon, strSize) = 6
        recordArray(SecondPartyIDCon, descpt) = "Continuation of second party identifier if more than 12 characters"
        recordArray(SecondPartyReference, start) = 69
        recordArray(SecondPartyReference, strSize) = 12
        recordArray(SecondPartyReference, descpt) = "Second Party Reference"
    End Sub

    Protected Friend Sub InitManagerDTF(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientID"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientBankName"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientBankNo"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientBankBrh"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientAC"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "amt"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientIDCon"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "clientRef"
        DT.Columns.Add(Column)
    End Sub

    Protected Friend Sub GetDataFromFile(ByRef ldt As DataTable, ByRef openFileDialog As OpenFileDialog, _
                                         ByRef FirstPartyACVal As String, ByRef PaymentCodeVal As String, _
                                         ByRef FirstPartyRefVal As String, ByRef ValidationDateVal As Date)
        Dim strLine As String = ""
        Dim objReader As StreamReader

        ldt.Clear()
        objReader = New StreamReader(openFileDialog.FileName)
        strLine = objReader.ReadLine()
        assignHeader(strLine, FirstPartyACVal, PaymentCodeVal, FirstPartyRefVal, ValidationDateVal)
        While objReader.Peek <> -1
            strLine = objReader.ReadLine()
            insertRecord(ldt, strLine)
        End While
        objReader.Close()
    End Sub

    Private Function assignHeader(ByVal header As String, ByRef FirstPartyACVal As String, ByRef PaymentCodeVal As String, _
                                    ByRef FirstPartyRefVal As String, ByRef ValidationDateVal As Date) As Boolean
        Dim vdate As String = ""
        FirstPartyACVal = Mid(header, headerArray(FirstPartyAccNo, start), headerArray(FirstPartyAccNo, strSize))
        PaymentCodeVal = Mid(header, headerArray(PaymentCode, start), headerArray(PaymentCode, strSize))
        FirstPartyRefVal = Mid(header, headerArray(FirstPartyRef, start), headerArray(FirstPartyRef, strSize))
        vdate = Mid(header, headerArray(HValueDate, start), headerArray(HValueDate, strSize))
        ValidationDateVal = CDate("20" & Mid(vdate, 5, 2) & "/" & Mid(vdate, 3, 2) & "/" & Mid(vdate, 1, 2))
    End Function

    Private Function insertRecord(ByRef ldt As DataTable, ByVal record As String) As Boolean
        Try
            Dim ldrRecord As DataRow = ldt.NewRow
            ldrRecord("clientID") = Mid(record, recordArray(SecondPartyID, start), recordArray(SecondPartyID, strSize))
            ldrRecord("clientBankName") = Mid(record, recordArray(SecondPartyBankAcc, start), recordArray(SecondPartyBankAcc, strSize))
            ldrRecord("clientBankNo") = Mid(record, recordArray(SecondPartyBankNo, start), recordArray(SecondPartyBankNo, strSize))
            ldrRecord("clientBankBrh") = Mid(record, recordArray(SecondPartyBranch, start), recordArray(SecondPartyBranch, strSize))
            ldrRecord("clientAC") = Mid(record, recordArray(SecondPartyAcc, start), recordArray(SecondPartyAcc, strSize))
            ldrRecord("amt") = CDec(Mid(record, recordArray(Amount, start), recordArray(Amount, strSize))) / 100
            ldrRecord("clientIDCon") = Mid(record, recordArray(SecondPartyIDCon, start), recordArray(SecondPartyIDCon, strSize))
            ldrRecord("clientRef") = Mid(record, recordArray(SecondPartyReference, start), recordArray(SecondPartyReference, strSize))
            ldt.Rows.Add(ldrRecord)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Friend Function lFncGetFundOutS(ByVal dateFrom As String, ByVal dateTo As String, ByVal emptyTbl As Boolean) As DataTable

        Dim lstrSQL As String
        If (emptyTbl) Then
            lstrSQL = " 1<>1 "
        Else
            lstrSQL = " a.purpose = '0' and a.type = 1 and a.date >= '" & dateFrom & _
                      "' and a.date < '" & dateTo & "' order by a.date "
        End If

        lstrSQL = "select case when rtrim(c.bank_code_2) <> '' then 1 else 0 end as clt_check_s, rtrim(b.accno) as clt_code_s, rtrim(b.name_1) as clt_name_s, " & _
                    "c.bank_code_2 as bank_code_s, a.amt as fund_out_amt_s, a.date as tdate_s, a.notes as notes_s, " & _
                    "case when a.is_chq = 0 then 'Cheque' when a.is_chq = 1 then 'Cash' else 'Other' end as is_chq_s " & _
                    "from (select aid, cuid, purpose, type, amt, date, is_chq, notes from " & GStrG2BSDB & ".dbo.fund_move_client fmc " & _
                    "union select aid, cuid, purpose, type, amt, date, is_chq, notes from " & GStrG2BSDB & ".dbo.histcl_fund hcf" & _
                    " where [date] between '" & dateFrom & "' and '" & dateTo & "' ) a " & _
                    "inner join " & GStrG2BSDB & ".dbo.client_master b on a.aid = b.aid " & _
                    "inner join " & GStrG2BSDB & ".dbo.client_bal c on a.aid = c.aid " & _
                    "where " & lstrSQL
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "clt").Tables(0)

    End Function

    Protected Friend Function lFncGetFundOutF(ByVal dateFrom As String, ByVal dateTo As String, ByVal emptyTbl As Boolean) As DataTable

        Dim lstrSQL As String
        If (emptyTbl) Then
            lstrSQL = " 1<>1 "
        Else
            lstrSQL = " a.purpose = '0' and a.type = 1 and a.date >= '" & dateFrom & _
                      "' and a.date < '" & dateTo & "' order by a.date "
        End If

        lstrSQL = "select case when rtrim(c.bank_code_2) <> '' then 1 else 0 end  as clt_check_f, rtrim(b.accno) as clt_code_f, rtrim(b.name_1) as clt_name_f, " & _
                    "c.bank_code_2 as bank_code_f, a.amt as fund_out_amt_f, a.date as tdate_f, a.notes as notes_f, " & _
                    "case when a.is_chq = 0 then 'Cheque' when a.is_chq = 1 then 'Cash' else 'Other' end as is_chq_f " & _
                    "from (select aid, cuid, purpose, type, amt, date, is_chq, notes from " & GStrG2BFDB & ".dbo.fund_move_client fmc " & _
                    "union select aid, cuid, purpose, type, amt, date, is_chq, notes from " & GStrG2BFDB & ".dbo.histcl_fund hcf " & _
                    " where [date] between '" & dateFrom & "' and '" & dateTo & "' ) a " & _
                    "inner join " & GStrG2BFDB & ".dbo.client_master b on a.aid = b.aid " & _
                    "inner join " & GStrG2BFDB & ".dbo.client_bal c on a.aid = c.aid and a.cuid = c.cuid " & _
                    "where " & lstrSQL
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "clt").Tables(0)

    End Function

    Protected Friend Function lFncGetTDateS() As DataTable
        Dim lstrSQL As String

        lstrSQL = "select tdate, sec_fut from trade_date_hist "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "tDate").Tables(0)
    End Function

    Protected Friend Function lFncGetCommAccS() As String
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select misc_code from misc_master where misc_type = 'HSBC_comm_acc_s' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "commaccs")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item("misc_code")
        End If
        Return ""
    End Function

    Protected Friend Function lFncGetPayCodeS() As String
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select misc_code from misc_master where misc_type = 'HSBC_comm_paycode_s' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "paycodes")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item("misc_code")
        End If
        Return ""
    End Function

    Protected Friend Function lFncGetCommAccF() As String
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select misc_code from misc_master where misc_type = 'HSBC_comm_acc_f' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "commaccs")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item("misc_code")
        End If
        Return ""
    End Function

    Protected Friend Function lFncGetPayCodeF() As String
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select misc_code from misc_master where misc_type = 'HSBC_comm_paycode_f' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "paycodes")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item("misc_code")
        End If
        Return ""
    End Function

    Protected Friend Function lFncGetCutTime() As String
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select misc_code from misc_master where misc_type = 'HSBC_cut_time' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "paycodes")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item("misc_code")
        End If
        Return ""
    End Function

    Protected Friend Function lFncUpdateMisc(ByVal cut_time As String, ByVal comm_acc_s As String, ByVal pay_code_s As String, _
                                             ByVal comm_acc_f As String, ByVal pay_code_f As String) As Boolean
        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            lstrSQL = "update misc_master set misc_code = '" & cut_time & "' where misc_type = 'HSBC_cut_time' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            lstrSQL = "update misc_master set misc_code = '" & comm_acc_s & "' where misc_type = 'HSBC_comm_acc_s' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            lstrSQL = "update misc_master set misc_code = '" & pay_code_s & "' where misc_type = 'HSBC_comm_paycode_s' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            lstrSQL = "update misc_master set misc_code = '" & comm_acc_f & "' where misc_type = 'HSBC_comm_acc_f' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            lstrSQL = "update misc_master set misc_code = '" & pay_code_f & "' where misc_type = 'HSBC_comm_paycode_f' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing
            Return True

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

End Class
