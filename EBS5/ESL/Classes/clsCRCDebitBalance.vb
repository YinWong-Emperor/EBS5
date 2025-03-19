Imports System.Text
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class clsCRCDebitBalance

    Public Function FncSearch(ByVal acCode As String) As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CRCDebitBalance", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        ' 参数     
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "acCode", acCode)
        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Public Function FncTotalSearch(ByVal acCode As String) As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CRCDebitBalance_Total", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "acCode", acCode)
        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Public Function FncUpdate(ByVal run_code As String, ByVal setoff As Boolean, ByVal typeB As Decimal, ByVal typeC As Decimal, ByVal remark As String) As Boolean

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_CRCDebitBalance", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "run_code", run_code)
        AddParameter(sqlCmd, "setoff", IIf(setoff, 1, 0))
        AddParameter(sqlCmd, "typeB", typeB)
        AddParameter(sqlCmd, "typeC", typeC)
        AddParameter(sqlCmd, "remark", remark)


        Return GFncExecuteNonQuery(sqlCmd)
    End Function


    Public Function FncLoadRunnerCodes() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerCodes", GSCnLiqConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function


    ''' <summary>
    ''' 加载打印数据
    ''' </summary>
    Public Function FncLoadPrintData(ByVal runnerCodeFrom As String, ByVal runnerCodeTo As String, ByVal addition As Boolean) As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_CRCDebitBalance", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "runnerCodeFrom", runnerCodeFrom)
        AddParameter(sqlCmd, "runnerCodeTo", runnerCodeTo)
        AddParameter(sqlCmd, "addition", addition)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function


    ''' <summary>
    ''' 创建水晶报表对象
    ''' </summary>
    Public Function FncCreateRpt(ByRef dt As DataTable, ByVal runnerCodeFrom As String, ByVal runnerCodeTo As String, ByVal addition As Boolean) As ReportClass

        Dim rpt As New rptCRCDB
        Dim clsRpt As New ClsReports

        rpt.SetDataSource(dt)

        'title remark
        Dim title_remark As StringBuilder = New StringBuilder
        title_remark.Append("[Transaction Date: ")
        title_remark.Append(Format(GDteTradeDate, "dd/MM/yyyy"))
        title_remark.Append("] ")
        If addition = True Then title_remark.Append("[Deduct B > 0 or Deduct C > 0 Only] ")
        If (String.IsNullOrEmpty(runnerCodeFrom) = False) Then title_remark.Append(String.Format("[AE From {0}] ", runnerCodeFrom))
        If (String.IsNullOrEmpty(runnerCodeTo) = False) Then title_remark.Append(String.Format("[AE To {0}] ", runnerCodeTo))
        clsRpt.AddParam(rpt, "paraTitleRemark", title_remark.ToString())

        '[running total fields]
        'o(>_<)o Because of some Fields from [s_Rpt_CRCDebitBalance]<mst[view_ae_db_mst_crc] table> were String Type,not Numbers Type,
        'then CrystalReport DesignView cannot write a friendly formula, so I put the SUM formula here:
        Dim sum_dr As Decimal = dt.AsEnumerable().AsQueryable().Sum(Function(o) o.Field(Of Decimal)("dr"))
        Dim sum_mv As Decimal = dt.AsEnumerable().AsQueryable().Sum(Function(o) o.Field(Of Decimal)("mv"))

        Dim sum_actr As Decimal
        If Not sum_dr = 0 And Not sum_mv = 0 Then
            sum_actr = (sum_dr / sum_mv)
        Else
            sum_actr = 0
        End If
        clsRpt.AddParam(rpt, "para_Sum_dr", sum_dr.ToString("N"))
        clsRpt.AddParam(rpt, "para_Sum_mv", sum_mv.ToString("N"))
        clsRpt.AddParam(rpt, "para_Sum_actr", sum_actr.ToString("P"))
        clsRpt.AddParam(rpt, "para_Sum_bal", dt.AsEnumerable().AsQueryable().Sum(Function(o) o.Field(Of Decimal)("bal")).ToString("N"))
        clsRpt.AddParam(rpt, "para_Sum_ddbstr", dt.AsEnumerable().AsQueryable().Sum(Function(o) CDec(o.Field(Of String)("dd_b_str"))).ToString("N"))
        clsRpt.AddParam(rpt, "para_Sum_ddcstr", dt.AsEnumerable().AsQueryable().Sum(Function(o) CDec(o.Field(Of String)("dd_c_str"))).ToString("N"))

        Return rpt

    End Function



End Class
