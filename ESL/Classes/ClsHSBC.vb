Imports System.Data.SqlClient
Imports System.IO

Public Class ClsHSBC

    Protected Friend Function lFncGetData(ByVal tables() As String) As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_HSBC", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            ' parms
            AddParameter(sqlCmd, "g2bsDB", GStrG2BSDB.Trim)
            AddParameter(sqlCmd, "g2bfDB", GStrG2BFDB.Trim)

            Return GFncRtnDSTables(sqlCmd, tables)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncSearchHSBCExist(ByVal valdate As String, ByVal cltno As String,
                                          ByVal curcy As String, ByVal amt As Decimal,
                                          ByVal tran_type As String, ByVal chq_date As String) As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_HSBC_Exist", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            ' parms
            AddParameter(sqlCmd, "valdate", valdate.Trim)
            AddParameter(sqlCmd, "cltno", cltno.Trim)
            AddParameter(sqlCmd, "curcy", curcy.Trim)
            AddParameter(sqlCmd, "amt", amt)
            AddParameter(sqlCmd, "tran_type", tran_type.Trim)
            AddParameter(sqlCmd, "chq_date", chq_date.Trim)

            Return GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncInsHSBC(ByVal valdate As String, ByVal cltno As String,
                                          ByVal curcy As String, ByVal amt As Decimal,
                                          ByVal tran_type As String, ByVal chq_date As String,
                                          ByVal description As String) As Boolean
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_HSBC", GSCnSqlConn)

            Using (sqlCmd)
                sqlCmd.CommandType = CommandType.StoredProcedure
                ' parms
                AddParameter(sqlCmd, "valdate", valdate.Trim)
                AddParameter(sqlCmd, "cltno", cltno.Trim)
                AddParameter(sqlCmd, "curcy", curcy.Trim)
                AddParameter(sqlCmd, "amt", amt)
                AddParameter(sqlCmd, "tran_type", tran_type.Trim)
                AddParameter(sqlCmd, "chq_date", chq_date.Trim)
                AddParameter(sqlCmd, "description", description.Trim)
                AddParameter(sqlCmd, "user", GStrloginID)

                GFncRtnDS(sqlCmd)
            End Using
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    'Check & format HSBC table for exporting
    Public Function lFncExptHSBC(ByVal stocks As List(Of HSBCEntity), ByVal strExptDir As String, ByVal strExFile As String) As Boolean
        Try
            Dim dtData As DataTable = New DataTable()
            dtData.Columns.Add("ValueDate")
            dtData.Columns.Add("T Code")
            dtData.Columns.Add("Account No")
            dtData.Columns.Add("Ccy")
            dtData.Columns.Add("Amount")
            dtData.Columns.Add("Chq Cash")
            dtData.Columns.Add("Chq Date")
            dtData.Columns.Add("Chq No")
            dtData.Columns.Add("Description")
            'Start 20190114 Chris
            dtData.Columns.Add("Internal Remark")
            'End 20190114 Chris

            For Each stock As HSBCEntity In stocks
                Dim row As DataRow = dtData.NewRow
                row.Item("ValueDate") = stock.Vdate.Trim
                row.Item("T Code") = stock.Client_type.Trim
                row.Item("Account No") = stock.Accno.Trim
                row.Item("Ccy") = stock.Ccy.Trim
                row.Item("Amount") = Math.Round(stock.Amount, 2)
                row.Item("Chq Cash") = stock.Tran_type.Trim
                row.Item("Chq Date") = stock.Chqdate.Trim
                row.Item("Chq No") = ""
                row.Item("Description") = stock.Description.Trim
                'Start 20190114 Chris
                row.Item("Internal Remark") = stock.Internal_remark.Trim
                'End 20190114 Chris

                dtData.Rows.Add(row)
                lFncInsHSBC(stock.Vdate, stock.Accno, stock.Ccy, stock.Amount,
                                stock.Tran_type, stock.Chqdate, stock.Description)
            Next

            Return lFncExpt(strExptDir, strExFile, dtData)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    'Export excel file
    Protected Friend Function lFncExpt(ByVal strExptDir As String, ByVal strExFile As String, ByVal dtData As DataTable) As Boolean
        Try
            'Start 20190114 Chris
            'Dim lcHeader As String = "ValueDate, T Code, Account No, Ccy, Amount, Chq Cash, Chq Date, Chq No, Description"
            Dim lcHeader As String = "ValueDate, T Code, Account No, Ccy, Amount, Chq Cash, Chq Date, Chq No, Description, Internal Remark"
            'End 20190114 Chris
            Return GExportToExcel(strExptDir, strExFile, dtData, lcHeader, "Description")
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    'Check digit value for account_no in csv file
    Private Function CheckDigitVal(ByRef accno As String, ByVal checkdigit As Integer) As Boolean
        Dim odddigit As Integer = DigitSum(accno, True)
        Dim evendigit As Integer = DigitSum(accno, False)
        Dim result As Integer = (odddigit * 3) + evendigit

        result = result Mod 10
        result = 10 - result
        result = result Mod 10

        If (result <> checkdigit) Then
            Return False
        Else
            Return True
        End If
    End Function

    'Get odd or even sum value
    Private Function DigitSum(ByVal accno As String, ByVal isodd As Boolean) As Integer
        Dim sumTemp As Integer = 0
        Dim i As Long

        For i = IIf(isodd, 1, 2) To Len(accno) Step 2
            sumTemp = sumTemp + Convert.ToInt32(Mid(accno, i, 1))
        Next i
        Return sumTemp
    End Function

    'Format csv data into entity for showing and inserting
    Public Function lFncFormatLst(ByRef reader As StreamReader, ByVal ldsLst As DataSet, ByRef stocks As List(Of HSBCEntity), ByRef fetures As List(Of HSBCEntity)) As Boolean
        Dim lineCount As Integer = 0

        Do While reader.Peek() >= 0
            lineCount = lineCount + 1
            Dim l As String = reader.ReadLine().Replace("""", "")
            Dim entity As HSBCEntity = New HSBCEntity()
            Dim ls As String() = l.Split(",")

            'first line should be removed
            If lineCount = 1 Or ls.Length < 28 Then
                Continue Do
            End If

            'check customer reference field is length 11
            'Start 20190114 Chris
            'If ls(6).Length <> 11 Then
            If Not (ls(6).Length = 10 Or ls(6).Length = 11) Then
                'End 20190114 Chris
                Continue Do
            End If

            'Start 20190114 Chris
            'Dim accno As String = ls(6).Substring(2)
            Dim accno As String = ls(6).Substring(ls(6).Length - 9)
            'End 20190114 Chris
            'get check digit value
            Dim checkdigit = accno.Substring(accno.Length - 1, 1)
            'get accno
            accno = accno.Substring(0, accno.Length - 1)

            'check first 2 digit for import company, 01 = ESL, 02 = EFL
            'Start 20190114 Chris
            'If Not (ls(6).StartsWith("01") Or ls(6).StartsWith("02")) Then
            If Not (ls(1).EndsWith("001") Or ls(1).EndsWith("002")) Then
                'End 20190114 Chris
                Continue Do
            End If


            'Start 20190114 Chris
            ''check first 2 digit for table: 01 = #tmpclts, 02 = #tmpcltf
            'Dim tbName As String = IIf(ls(6).StartsWith("01"), "#tmpclts", "#tmpcltf")
            'check last 3 digit for table: 001 = #tmpclts, 002 = #tmpcltf
            Dim tbName As String = IIf(ls(1).EndsWith("001"), "#tmpclts", "#tmpcltf")
            'End 20190114 Chris
            Dim q = (From rd In ldsLst.Tables(tbName).AsEnumerable
                    Where rd.Field(Of String)("accno").Trim = accno
                    Select rd).FirstOrDefault()

            If Not IsNothing(q) Then
                entity.Accno = q("accno").ToString().Trim() 'ls(6)
                entity.C_type = q("ctype").ToString().Trim()
            End If

            'If can't find the record
            If IsNothing(q) Or IsNothing(entity.Accno) Then
                Continue Do
            End If

            entity.Client_type = IIf(entity.C_type = 1, "UCM", "UCC")

            ' check check digit
            If Not CheckDigitVal(entity.Accno, checkdigit) Then
                Continue Do
            End If

            'set date
            Dim tdate As DateTime = Convert.ToDateTime(ls(13))
            'to british
            'Start 20190114 Chris
            'Dim brithish_date As String = tdate.ToString("dd/MM/yyyy")
            Dim brithish_date As String = tdate.ToString("dd/MM/yyyy")
            'End 20190114 Chris
            'to taiwan
            Dim taiwan_date As String = tdate.ToString("yyyy/MM/dd")

            Dim tran_type As String = ls(11)
            Dim chq_date As String = ""

            If (tran_type.Length < 4) Then
                Continue Do
            End If

            If (tran_type.Substring(0, 4) = "BPAY") Then
                'not cheque
                tran_type = "Cash"
                chq_date = ""
            Else
                'is cheque
                tran_type = "Cheque"
                chq_date = taiwan_date
                'Start 20190114 Chris
                Continue Do
                'End 20190114 Chris
            End If
            'Start 20190114 Chris
            'entity.Vdate = taiwan_date 'brithish_date 'ls(13)
            entity.Vdate = brithish_date
            'End 20190114 Chris
            entity.Tran_type = tran_type
            entity.Ccy = ls(7)
            entity.Amount = Convert.ToDecimal(ls(10))
            entity.Chqdate = chq_date
            entity.Description = "HSBC BILL PAYMENT - CASH TRFR DEPOSIT" & vbCrLf & "匯豐銀行繳費服務 - 現金轉帳存款"
            'Start 20190114 Chris
            entity.Internal_remark = ""
            'End 20190114 Chris
            Dim HSBC_record As DataSet = Nothing

            'Start 20190114 Chris
            'If ls(6).StartsWith("01") Then
            If ls(1).EndsWith("001") Then
                'End 20190114 Chris
                HSBC_record = lFncSearchHSBCExist(entity.Vdate, entity.Accno, entity.Ccy, entity.Amount, entity.Tran_type, entity.Chqdate)

                If HSBC_record.Tables(0).Rows.Count > 0 Then
                    Dim msg As String = String.Format("Account No.: {0}, Amount: {1:N} exist! Do you want to continue import this record? Yes / No", entity.Accno, entity.Amount)
                    If GSubShowYNConfirm(msg) = Windows.Forms.DialogResult.No Then
                        Continue Do
                    End If
                End If

                stocks.Add(entity)
            Else
                fetures.Add(entity)
            End If

        Loop
    End Function

End Class

Public Class HSBCEntity
    Private _vdate As String

    Public Property Vdate() As String
        Get
            Return _vdate
        End Get
        Set(ByVal Value As String)
            _vdate = Value
        End Set
    End Property

    Private _accno As String
    Public Property Accno() As String
        Get
            Return _accno
        End Get
        Set(ByVal Value As String)
            _accno = Value
        End Set
    End Property

    Private _ccy As String
    Public Property Ccy() As String
        Get
            Return _ccy
        End Get
        Set(ByVal Value As String)
            _ccy = Value
        End Set
    End Property

    Private _amount As Decimal
    Public Property Amount() As Decimal
        Get
            Return _amount
        End Get
        Set(ByVal Value As Decimal)
            _amount = Value
        End Set
    End Property

    Private _c_ctype As String
    Public Property C_type() As String
        Get
            Return _c_ctype
        End Get
        Set(ByVal Value As String)
            _c_ctype = Value
        End Set
    End Property

    Private _tran_type As String
    Public Property Tran_type() As String
        Get
            Return _tran_type
        End Get
        Set(ByVal Value As String)
            _tran_type = Value
        End Set
    End Property

    Private _chqdate As String
    Public Property Chqdate() As String
        Get
            Return _chqdate
        End Get
        Set(ByVal Value As String)
            _chqdate = Value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _client_type As String
    Public Property Client_type() As String
        Get
            Return _client_type
        End Get
        Set(ByVal Value As String)
            _client_type = Value
        End Set
    End Property

    'Start 20190114 Chris
    Private _internal_remark As String
    Public Property Internal_remark() As String
        Get
            Return _internal_remark
        End Get
        Set(ByVal Value As String)
            _internal_remark = Value
        End Set
    End Property
    'End 20190114 Chris

End Class