Imports System.Text
Imports System.Data.SqlClient
Imports System.Linq
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsChequePrinting

    Public Function FncSearch(
                            ByVal txnDate As DateTime,
                            Optional ByVal orderby As String = "") As DataTable

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ChequePrinting", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数
        AddParameter(sqlCmd, "txnDate", txnDate)

        Dim dt As DataTable = GFncRtnDS(sqlCmd).Tables(0)
        Dim dv As DataView = dt.DefaultView

        If orderby <> "" Then
            dv.Sort = orderby
        End If

        Return dv.Table
    End Function

    Public Function FncListClientCodes() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ChequePrinting_ClientCodes", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Public Function FncListSequenceNos() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ChequePrinting_SequenceNos", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function


    Public Function FncDelete(ByVal sequence As Integer, ByVal txnDate As DateTime) As Boolean
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Del_ChequePrinting", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "sequence", sequence)
        AddParameter(sqlCmd, "txn_date", txnDate)

        Return GFncExecuteNonQuery(sqlCmd)

    End Function

    Public Function FncInsert(
                                ByVal pSequence As Integer,
                                ByVal pClient_code As String,
                                ByVal pTxn_date As DateTime,
                                ByVal pAmount As Decimal,
                                ByVal pName As String,
                                ByVal pUpdateby As String,
                                ByVal pEntrydate As DateTime) As Object

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_ChequePrinting", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "sequence", pSequence)
        AddParameter(sqlCmd, "client_code", pClient_code)
        AddParameter(sqlCmd, "txn_date", pTxn_date)
        AddParameter(sqlCmd, "amount", pAmount)
        AddParameter(sqlCmd, "name", pName)
        AddParameter(sqlCmd, "updateby", pUpdateby)
        AddParameter(sqlCmd, "entrydate", pEntrydate)

        Return GFncExecuteScalar(sqlCmd)
    End Function
    Public Function FncUpdate(
                                ByVal pSequence As Integer,
                                ByVal pClient_code As String,
                                ByVal pTxn_date As DateTime,
                                ByVal pAmount As Decimal,
                                ByVal pName As String,
                                ByVal pUpdateby As String,
                                ByVal pEntrydate As DateTime) As Boolean

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_ChequePrinting", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "sequence", pSequence)
        AddParameter(sqlCmd, "client_code", pClient_code)
        AddParameter(sqlCmd, "txn_date", pTxn_date)
        AddParameter(sqlCmd, "amount", pAmount)
        AddParameter(sqlCmd, "name", pName)
        AddParameter(sqlCmd, "updateby", pUpdateby)
        AddParameter(sqlCmd, "entrydate", pEntrydate)

        Return GFncExecuteNonQuery(sqlCmd)
    End Function



    ''' <summary>
    ''' 加载打印数据
    ''' </summary>
    ''' <param name="OpgPrtSeq">Print Sequence<para/> #1=SequenceNo<para/> #2=ClientCode</param>
    ''' <param name="OpgPrtRec">Record Range<para/> #1=AllRecords<para/> #2=ClientCode<para/>#3=SequenceNo</param>
    Public Function FncLoadPrintData(ByVal Txn_Date As DateTime?, _
                                     ByVal OpgPrtSeq As Integer, ByVal OpgPrtRec As Integer, _
                                     ClientCodeFrom As String, ClientCodeTo As String, _
                                     SequenceNoFrom As Integer, SequenceNoTo As Integer) _
                                     As DataTable

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ChequePrinting_Listing", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "Txn_Date", Txn_Date)
        AddParameter(sqlCmd, "OpgPrtSeq", OpgPrtSeq)
        AddParameter(sqlCmd, "OpgPrtRec", OpgPrtRec)
        AddParameter(sqlCmd, "ClientCodeFrom", ClientCodeFrom)
        AddParameter(sqlCmd, "ClientCodeTo", ClientCodeTo)
        AddParameter(sqlCmd, "SequenceNoFrom", SequenceNoFrom)
        AddParameter(sqlCmd, "SequenceNoTo", SequenceNoTo)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    ''' <summary>
    ''' 创建水晶报表对象
    ''' </summary>
    Public Function FncCreateRpt(ByRef dt As DataTable, ByVal targetDate As DateTime, ByVal ClientCodeFrom As String, ByVal ClientCodeTo As String, ByVal SequenceNoFrom As Integer?, ByVal SequenceNoTo As Integer?) As ReportClass

        Dim rpt As New rptChequePrinting
        Dim clsRpt As New ClsReports

        rpt.SetDataSource(dt)

        'title remark
        Dim title_remark As StringBuilder = New StringBuilder
        title_remark.Append("TRANSACTION DATE: ")
        'title_remark.Append(Format(GDteTradeDate, "dd/MM/yyyy"))       '特殊处理，此处不用GDteTradeDate，详情请咨询BA
        title_remark.Append(Format(targetDate, "dd/MM/yyyy"))           '特殊处理，此处要用targetDate，详情请咨询BA
        clsRpt.AddParam(rpt, "paraTitleRemark", title_remark.ToString())

        Return rpt

    End Function

End Class
