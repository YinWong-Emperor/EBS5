Public Class FrmRunnerTaxableIncomeMasterPrint


    '-----------Members-----------

    Dim cls As New ClsRunnerTaxableIncomeMaster

    ''' <summary>
    ''' 范围的数据
    ''' </summary>
    ''' <remarks></remarks>
    Dim RangeRunCodes As String()


    '-----------Control-----------

#Region "初始化"


    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <remarks></remarks>
    Sub Init()

        '加载范围
        Dim dt As DataTable = cls.funcGetRunCodesForPrint()
        Dim ret_dt As IQueryable(Of String) = dt.AsEnumerable().AsQueryable().Select(Function(x) x.Field(Of String)(0))
        cbxRangeFrom.DataSource = ret_dt.ToArray()
        cbxRangeFrom.SelectedIndex = -1
        cbxRangeTo.DataSource = ret_dt.ToArray()
        cbxRangeTo.SelectedIndex = -1
        Me.RangeRunCodes = ret_dt.ToArray()

        'Bind events
        '#TextChanged
        Dim action4RangeChoose As Action = Sub() rdbRangeChoose.Checked = True
        GUIBindDeal_ComboBox_TextChanged(cbxRangeFrom, action4RangeChoose)
        GUIBindDeal_ComboBox_TextChanged(cbxRangeTo, action4RangeChoose)
        '#IndexChanged
        GUIBindDeal_ComboBox_ChangeSencondIndex_When_FirstIndexChanged(cbxRangeFrom, cbxRangeTo)

        'Default value
        txtRangeMember.Text = String.Empty

    End Sub


#End Region

#Region "打印"

    ''' <summary>
    ''' 打印前的数据检查
    ''' </summary>
    ''' <returns>是否合法</returns>
    Function DataCheckBeforeDoPrint() As Boolean

        If rdbRangeChoose.Checked Then
            '检查RunCode合法性
            If (Not Me.RangeRunCodes.Contains(cbxRangeFrom.Text.Trim())) Or (Not Me.RangeRunCodes.Contains(cbxRangeTo.Text.Trim())) Then
                GSubShowInfo(GFncGetSysMsg(136))
                Return False
            End If

            '检查Member合法性
            If String.IsNullOrWhiteSpace(txtRangeMember.Text.Trim()) Then
                GSubShowInfo(GFncGetSysMsg(137))
                Return False
            End If

        End If

        Return True
    End Function

    ''' <summary>
    ''' 执行打印
    ''' </summary>
    Private Sub DoPrint()

        '##Combine CrystalReport
        Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

        Dim strRangeFrom As String = cbxRangeFrom.Text.Trim()
        Dim strRangeTo As String = cbxRangeTo.Text.Trim()
        Dim strMember As String = txtRangeMember.Text.Trim()
        Dim reportType As Boolean = rdbStatementOfTaxableIncome.Checked

        '##1 加载Summary和Details
        Dim dt_summary As DataTable, dt_details As DataTable, dt_summary_append As DataTable = Nothing

        If rdbRangeAll.Checked Then
            dt_summary = cls.funcGetPrintData_Summary(True)
            dt_details = cls.funcGetPrintData_Details(reportType, True)
        Else
            dt_summary = cls.funcGetPrintData_Summary(False, strRangeFrom, strRangeTo, strMember)
            dt_details = cls.funcGetPrintData_Details(reportType, False, strRangeFrom, strRangeTo, strMember)
        End If

        'Append: reportType为“Statement of Taxable Income”时，有个  “Ref. to statement of Withheld Remuneration”的小表
        If reportType = True Then
            If rdbRangeAll.Checked Then
                dt_summary_append = cls.funcGetPrintData_AppendForRef(True)
            Else
                dt_summary_append = cls.funcGetPrintData_AppendForRef(False, strRangeFrom, strRangeTo, strMember)
            End If
        End If


        '##2 设置数据源
        rpt = cls.FncCreateRpt_TaxableIncome(reportType, dt_summary, dt_details, dt_summary_append)

        '##3 Preview
        '弹水晶报表去预览
        Dim frm As New FrmRptDisplay
        frm.GSubDisplayRpt(rpt)

    End Sub

#End Region


    '------------------------------

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Init()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbxRangeFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRangeFrom.SelectedIndexChanged
        'v3狐狸仔的逻辑如此，具体需求不明 ： From下拉框切换的时候，member文本框必然为A
        Me.txtRangeMember.Text = "A"
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Me.DataCheckBeforeDoPrint() Then
            DoPrint()
        End If
    End Sub
End Class
