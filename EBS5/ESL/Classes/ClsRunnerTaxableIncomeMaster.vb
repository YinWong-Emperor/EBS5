Imports System.Text
Imports System.Data.SqlClient
Imports System.Linq
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRunnerTaxableIncomeMaster

#Region "TopForm"

    ''' <summary>
    ''' 获取RUNCONTROL当前月份
    ''' </summary>
    Protected Friend Function funcGetCurrentMonthFromGLRUNCONTROL() As Integer
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_CurMonth", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        '返回值
        Dim returnVal As SqlParameter = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int)
        returnVal.Direction = ParameterDirection.ReturnValue

        GFncExecuteNonQuery(sqlCmd)
        Return returnVal.Value
    End Function

    ''' <summary>
    ''' 获取RUNCONTROL当前年份
    ''' </summary>
    Protected Friend Function funcGetCurrentYearFromGLRUNCONTROL() As Integer
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_CurYear", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        '返回值
        Dim returnVal As SqlParameter = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int)
        returnVal.Direction = ParameterDirection.ReturnValue

        GFncExecuteNonQuery(sqlCmd)
        Return returnVal.Value
    End Function

    ''' <summary>
    ''' 获取Master列表
    ''' </summary>
    Protected Friend Function funcGetMasterList() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_MasterList", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

#End Region

#Region "Cut Off"


    ''' <summary>
    ''' 执行Monthly Cut Off
    ''' </summary>
    Protected Friend Function funcExecMonthlyCutOff() As Boolean
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_RunnerTaxableIncomeMaster_CutOff_Monthly", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "user", GStrloginID)

        Return GFncExecuteNonQuery(sqlCmd)
    End Function

    ''' <summary>
    ''' 执行Yearly Cut Off
    ''' </summary>
    Protected Friend Function funcExecYearlyCutOff() As Boolean
        '关键点备忘：w(ﾟДﾟ)w惊呆了~~   根据 v3狐狸仔的代码，发现 "Yearly-CutOff"与"Monthly-CutOff"很一致，除了【复杂替换里】，Last_Mpf和Last_Tax是更新为0

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_RunnerTaxableIncomeMaster_CutOff_Yearly", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "user", GStrloginID)

        Return GFncExecuteNonQuery(sqlCmd)
    End Function

#End Region

#Region "Description"

    ''' <summary>
    ''' 获取Taxable的Description
    ''' </summary>
    Protected Friend Function funcGetDescriptionOfTaxable() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_Description_Taxable", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    ''' <summary>
    ''' 获取Withheld的Description
    ''' </summary>
    Protected Friend Function funcGetDescriptionOfWithheld() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_Description_Withheld", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    ''' <summary>
    ''' 格式化Description的DataTable
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Friend Sub funcFormatDescription(ByRef dt As DataTable)
        If (dt Is Nothing Or dt.Rows.Count <= 0) Then Return

        dt.Columns.Add("DisplayColumn")
        For Each item As DataRow In dt.Rows
            'item("DisplayColumn") = (item("Descpt") + " - " + item("TmpDash") + " - " + item("Company")) ' This is v3's code. why? It's different from UI effect.
            item("DisplayColumn") = (item("Descpt").ToString().Trim() + item("TmpDash") + item("Company").ToString().Trim())
        Next

    End Sub

#End Region

#Region "Description - Selects"
    ''' <summary>
    ''' 获取Description - Selects
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Function funcGetDescriptionSelects(ByVal RUN_CODE As String,
                                                        ByVal RUN_MEMBER As String,
                                                        ByVal TYPE_ID As Integer,
                                                        ByVal TAXTYPE As String) As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_Description_Selects", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        ' 参数        
        AddParameter(sqlCmd, "RUN_CODE", RUN_CODE)
        AddParameter(sqlCmd, "RUN_MEMBER", RUN_MEMBER)
        AddParameter(sqlCmd, "TYPE_ID", TYPE_ID)
        AddParameter(sqlCmd, "TAXTYPE", TAXTYPE)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Protected Friend Function funcSyncDescriptionSelects(ByVal RUN_CODE As String,
                                                         ByVal RUN_MEMBER As String,
                                                         ByVal TYPE_ID As Integer,
                                                         ByVal TAXTYPE As String,
                                                         ByRef DT As DataTable) As Boolean
        '临时表
        Dim sqlTmpTable As SqlCommand = New SqlCommand("[s_Upd_RunnerTaxableIncomeMaster_Description_Selects_TmpTable]", GSCnSqlConn)
        sqlTmpTable.CommandType = CommandType.StoredProcedure
        GFncExecuteNonQuery(sqlTmpTable)

        '先将表同步到临时表
        Dim sbc As New SqlBulkCopy(GSCnSqlConn)
        sbc.DestinationTableName = "##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects"
        sbc.WriteToServer(DT)

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_RunnerTaxableIncomeMaster_Description_Selects", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RUN_CODE", RUN_CODE)
        AddParameter(sqlCmd, "RUN_MEMBER", RUN_MEMBER)
        AddParameter(sqlCmd, "TYPE_ID", TYPE_ID)
        AddParameter(sqlCmd, "TAXTYPE", TAXTYPE)
        AddParameter(sqlCmd, "UPDATEBY", GStrloginID)

        Return GFncExecuteNonQuery(sqlCmd)

    End Function

#End Region


#Region "获取目标记录"

    ''' <summary>
    ''' 获取目标记录
    ''' </summary>
    Protected Friend Function funcGetTargetOneRecord(TargetRunCode As String, TargetRunMember As String) As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_Details_TargetOneRecord", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "TargetRunCode", TargetRunCode)
        AddParameter(sqlCmd, "TargetRunMember", TargetRunMember)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

#End Region

#Region "新增记录"

    ''' <summary>
    ''' 新增记录
    ''' </summary>
    ''' <returns>成功与否</returns>
    Protected Friend Function funcInsNewRecord(RUN_CODE As String, RUN_MEMBER As String,
                                               Run_Name As String,
                                               REMARK As String,
                                               STK_TO As Decimal,
                                               ADJUST_TAX As Decimal,
                                               Mpf As Decimal,
                                               Vol As Decimal,
                                               PAY_DATE As DateTime,
                                               MPF_CO As Decimal,
                                               VOL_CO As Decimal,
                                               ABSENCE As Integer,
                                               HIDE As Integer,
                                               HSI_TO As Integer,
                                               HSIO_TO As Integer,
                                               HSI100_To As Integer,
                                               MHSI_To As Integer,
                                               RC_To As Integer,
                                               SF_To As Integer,
                                               EO_To As Integer,
                                               HSI100o_To As Integer,
                                               RCO_To As Integer
                                              ) As String


        Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_RunnerTaxableIncomeMaster_Details_TargetOneRecord", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RUN_CODE", RUN_CODE)
        AddParameter(sqlCmd, "RUN_MEMBER", RUN_MEMBER)
        AddParameter(sqlCmd, "Run_Name", Run_Name)
        AddParameter(sqlCmd, "REMARK", REMARK)
        AddParameter(sqlCmd, "STK_TO", STK_TO)
        AddParameter(sqlCmd, "ADJUST_TAX", ADJUST_TAX)
        AddParameter(sqlCmd, "Mpf", Mpf)
        AddParameter(sqlCmd, "Vol", Vol)
        AddParameter(sqlCmd, "PAY_DATE", PAY_DATE)
        AddParameter(sqlCmd, "MPF_CO", MPF_CO)
        AddParameter(sqlCmd, "VOL_CO", VOL_CO)
        AddParameter(sqlCmd, "ABSENCE", ABSENCE)
        AddParameter(sqlCmd, "HIDE", HIDE)
        AddParameter(sqlCmd, "HSI_TO", HSI_TO)
        AddParameter(sqlCmd, "HSIO_TO", HSIO_TO)
        AddParameter(sqlCmd, "HSI100_To", HSI100_To)
        AddParameter(sqlCmd, "MHSI_To", MHSI_To)
        AddParameter(sqlCmd, "RC_To", RC_To)
        AddParameter(sqlCmd, "SF_To", SF_To)
        AddParameter(sqlCmd, "EO_To", EO_To)
        AddParameter(sqlCmd, "HSI100o_To", HSI100o_To)
        AddParameter(sqlCmd, "RCO_To", RCO_To)
        AddParameter(sqlCmd, "UPDATEBY", GStrloginID)
        '返回值
        Dim returnVal As SqlParameter = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int)
        returnVal.Direction = ParameterDirection.ReturnValue

        Dim ret As Boolean = GFncExecuteNonQuery(sqlCmd)
        Select Case returnVal.Value
            Case 0
                Return "OK"
            Case -1
                Return "REPEAT"
            Case Else
                Return "UNKNOWN"
        End Select

    End Function

#End Region

#Region "修改记录"

    ''' <summary>
    ''' 修改记录
    ''' </summary>
    ''' <returns>成功与否</returns>
    Protected Friend Function funcUpdTargetRecord(RUN_CODE As String, RUN_MEMBER As String,
                                                   Run_Name As String,
                                                   REMARK As String,
                                                   STK_TO As Decimal,
                                                   ADJUST_TAX As Decimal,
                                                   Mpf As Decimal,
                                                   Vol As Decimal,
                                                   PAY_DATE As DateTime,
                                                   MPF_CO As Decimal,
                                                   VOL_CO As Decimal,
                                                   ABSENCE As Integer,
                                                   HIDE As Integer,
                                                   HSI_TO As Integer,
                                                   HSIO_TO As Integer,
                                                   HSI100_To As Integer,
                                                   MHSI_To As Integer,
                                                   RC_To As Integer,
                                                   SF_To As Integer,
                                                   EO_To As Integer,
                                                   HSI100o_To As Integer,
                                                   RCO_To As Integer
                                                  ) As String

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_RunnerTaxableIncomeMaster_Details_TargetOneRecord", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RUN_CODE", RUN_CODE)
        AddParameter(sqlCmd, "RUN_MEMBER", RUN_MEMBER)
        AddParameter(sqlCmd, "Run_Name", Run_Name)
        AddParameter(sqlCmd, "REMARK", REMARK)
        AddParameter(sqlCmd, "STK_TO", STK_TO)
        AddParameter(sqlCmd, "ADJUST_TAX", ADJUST_TAX)
        AddParameter(sqlCmd, "Mpf", Mpf)
        AddParameter(sqlCmd, "Vol", Vol)
        AddParameter(sqlCmd, "PAY_DATE", PAY_DATE)
        AddParameter(sqlCmd, "MPF_CO", MPF_CO)
        AddParameter(sqlCmd, "VOL_CO", VOL_CO)
        AddParameter(sqlCmd, "ABSENCE", ABSENCE)
        AddParameter(sqlCmd, "HIDE", HIDE)
        AddParameter(sqlCmd, "HSI_TO", HSI_TO)
        AddParameter(sqlCmd, "HSIO_TO", HSIO_TO)
        AddParameter(sqlCmd, "HSI100_To", HSI100_To)
        AddParameter(sqlCmd, "MHSI_To", MHSI_To)
        AddParameter(sqlCmd, "RC_To", RC_To)
        AddParameter(sqlCmd, "SF_To", SF_To)
        AddParameter(sqlCmd, "EO_To", EO_To)
        AddParameter(sqlCmd, "HSI100o_To", HSI100o_To)
        AddParameter(sqlCmd, "RCO_To", RCO_To)
        AddParameter(sqlCmd, "UPDATEBY", GStrloginID)
        '返回值
        Dim returnVal As SqlParameter = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int)
        returnVal.Direction = ParameterDirection.ReturnValue

        Dim ret As Boolean = GFncExecuteNonQuery(sqlCmd)
        Select Case returnVal.Value
            Case 0
                Return "OK"
            Case -2
                Return "NOT_EXIST"
            Case Else
                Return "UNKNOWN"
        End Select

    End Function

#End Region

#Region "删除记录"

    ''' <summary>
    ''' 删除记录
    ''' </summary>
    ''' <returns>成功与否</returns>
    Protected Friend Function funcDelTargetRecord(RUN_CODE As String, RUN_MEMBER As String) As String

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Del_RunnerTaxableIncomeMaster_Details_TargetOneRecord", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RUN_CODE", RUN_CODE)
        AddParameter(sqlCmd, "RUN_MEMBER", RUN_MEMBER)
        '返回值
        Dim returnVal As SqlParameter = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int)
        returnVal.Direction = ParameterDirection.ReturnValue

        Dim ret As Boolean = GFncExecuteNonQuery(sqlCmd)
        Select Case returnVal.Value
            Case 0
                Return "OK"
            Case -2
                Return "NOT_EXIST"
            Case Else
                Return "UNKNOWN"
        End Select

    End Function

#End Region


#Region "打印相关"

    ''' <summary>
    ''' 获取打印范围的RunCode列表
    ''' </summary>
    Protected Friend Function funcGetRunCodesForPrint() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_RunnerTaxableIncomeMaster_Print_RunCodes", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    ''' <summary>
    ''' 获取打印数据_Summary
    ''' </summary>
    Protected Friend Function funcGetPrintData_Summary(ByVal RecordOption_All_Or_Range As Boolean, Optional ByVal RangeFrom As String = "", Optional ByVal RangeTo As String = "", Optional ByVal Member As String = "") As DataTable

        '检查
        If RecordOption_All_Or_Range = False Then
            If String.IsNullOrWhiteSpace(RangeFrom) Then Throw New ArgumentException("采用Range时，RangeFrom不能为空", "RangeFrom")
            If String.IsNullOrWhiteSpace(RangeTo) Then Throw New ArgumentException("采用Range时，RangeTo不能为空", "RangeTo")
            If String.IsNullOrWhiteSpace(Member) Then Throw New ArgumentException("采用Range时，Member不能为空", "Member")
        End If

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_RunnerTaxableIncomeMaster_Summary", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RangeFrom", RangeFrom)
        AddParameter(sqlCmd, "RangeTo", RangeTo)
        AddParameter(sqlCmd, "Member", Member)
        AddParameter(sqlCmd, "RecordOption", IIf(RecordOption_All_Or_Range, 1, 2))

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    ''' <summary>
    ''' 获取打印数据_Details
    ''' </summary>
    Protected Friend Function funcGetPrintData_Details(ByVal ReportType_TaxableIncome_Or_WithheldRemuneration As Boolean, ByVal RecordOption_All_Or_Range As Boolean, Optional ByVal RangeFrom As String = "", Optional ByVal RangeTo As String = "", Optional ByVal Member As String = "") As DataTable

        '检查
        If RecordOption_All_Or_Range = False Then
            If String.IsNullOrWhiteSpace(RangeFrom) Then Throw New ArgumentException("采用Range时，RangeFrom不能为空", "RangeFrom")
            If String.IsNullOrWhiteSpace(RangeTo) Then Throw New ArgumentException("采用Range时，RangeTo不能为空", "RangeTo")
            If String.IsNullOrWhiteSpace(Member) Then Throw New ArgumentException("采用Range时，Member不能为空", "Member")
        End If

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_RunnerTaxableIncomeMaster_Detail", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RangeFrom", RangeFrom)
        AddParameter(sqlCmd, "RangeTo", RangeTo)
        AddParameter(sqlCmd, "Member", Member)
        AddParameter(sqlCmd, "RecordOption", IIf(RecordOption_All_Or_Range, 1, 2))
        AddParameter(sqlCmd, "ReportType", IIf(ReportType_TaxableIncome_Or_WithheldRemuneration, 1, 2))

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    ''' <summary>
    ''' 获取打印数据_Details
    ''' </summary>
    Protected Friend Function funcGetPrintData_AppendForRef(ByVal RecordOption_All_Or_Range As Boolean, Optional ByVal RangeFrom As String = "", Optional ByVal RangeTo As String = "", Optional ByVal Member As String = "") As DataTable

        '检查
        If RecordOption_All_Or_Range = False Then
            If String.IsNullOrWhiteSpace(RangeFrom) Then Throw New ArgumentException("采用Range时，RangeFrom不能为空", "RangeFrom")
            If String.IsNullOrWhiteSpace(RangeTo) Then Throw New ArgumentException("采用Range时，RangeTo不能为空", "RangeTo")
            If String.IsNullOrWhiteSpace(Member) Then Throw New ArgumentException("采用Range时，Member不能为空", "Member")
        End If

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_RunnerTaxableIncomeMaster_AppendForRef", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数        
        AddParameter(sqlCmd, "RangeFrom", RangeFrom)
        AddParameter(sqlCmd, "RangeTo", RangeTo)
        AddParameter(sqlCmd, "Member", Member)
        AddParameter(sqlCmd, "RecordOption", IIf(RecordOption_All_Or_Range, 1, 2))

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function



    ''' <summary>
    ''' 创建水晶报表对象
    ''' </summary>
    Public Function FncCreateRpt_TaxableIncome(ByVal ReportType_TaxableIncome_Or_WithheldRemuneration As Boolean, ByRef dt_summary As DataTable, ByRef dt_details As DataTable, Optional dt_summary_append As DataTable = Nothing) As ReportClass
        Dim rpt As New rptRunnerTaxableIncomeMaster_TaxableIncome
        Dim clsRpt As New ClsReports

        '数据源
        If ReportType_TaxableIncome_Or_WithheldRemuneration Then
            rpt.Database.Tables("DtsRunnerTaxableIncomeMasterSummary").SetDataSource(dt_summary)
            rpt.Database.Tables("DtsRunnerTaxableIncomeMasterDetail").SetDataSource(dt_details)
            rpt.Database.Tables("DtsRunnerTaxableIncomeMaster_Append").SetDataSource(dt_summary_append)
            rpt.Subreports("DetailMain").SetDataSource(dt_details)
            rpt.Subreports("DetailForAppendRef").SetDataSource(dt_summary_append)
        Else
            rpt.Database.Tables("DtsRunnerTaxableIncomeMasterSummary").SetDataSource(dt_summary)
            rpt.Database.Tables("DtsRunnerTaxableIncomeMasterDetail").SetDataSource(dt_details)
            rpt.Subreports("DetailMain02").SetDataSource(dt_details)
        End If

        '附加参数s
        clsRpt.AddParam(rpt, "ReportType_TaxableIncome_Or_WithheldRemuneration", ReportType_TaxableIncome_Or_WithheldRemuneration)

        Return rpt
    End Function


#End Region


End Class
