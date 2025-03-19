Public Class FrmRunnerTaxableIncomeMaster

    '----------Members----------

    Dim cls As New ClsRunnerTaxableIncomeMaster

    ''' <summary>
    ''' 当前年份、当前月份
    ''' </summary>
    ''' <remarks></remarks>
    Dim curMonth As Integer, curYear As Integer

    ''' <summary>
    ''' 列表数据源
    ''' </summary>
    ''' <remarks></remarks>
    Dim MasterList As DataTable


    '----------Control----------

#Region "窗体加载时"

    Sub OnFormLoad()

        '加载状态
        Me.curMonth = cls.funcGetCurrentMonthFromGLRUNCONTROL()
        Me.curYear = cls.funcGetCurrentYearFromGLRUNCONTROL()

        '处理控件状态
        Me.txtYear.Text = Me.curYear
        Me.txtMonth.Text = Me.curMonth

        If curMonth = 3 Then
            Me.btnMonthCut.Enabled = False
            Me.btnYearCut.Enabled = True
        Else
            Me.btnMonthCut.Enabled = True
            Me.btnYearCut.Enabled = False
        End If

        '加载列表
        LoadDataList()
    End Sub

    Sub LoadDataList()
        '保留选中索引
        Dim lastIndex As Integer = -1
        If dgvMain.CurrentRow IsNot Nothing Then
            lastIndex = dgvMain.CurrentRow.Index
        End If

        '加载数据源
        Me.MasterList = cls.funcGetMasterList()
        '绑定数据源
        dgvMain.DataSource = Me.MasterList

        '还原选中项
        lastIndex = Math.Min(lastIndex, dgvMain.Rows.Count - 1)         '兼容delete后
        If lastIndex >= 0 Then
            dgvMain.CurrentCell = Nothing
            dgvMain.ClearSelection()
            dgvMain.CurrentCell = dgvMain.Rows(lastIndex).Cells(0)
            dgvMain.FirstDisplayedCell = dgvMain.CurrentCell
        End If
    End Sub



    ''' <summary>
    ''' 找到目标行并选中
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns>目标索引（如果小于0则表示没找到匹配的行）</returns>
    Function FoundTargetRow(ByVal code As String, ByVal name As String) As Integer
        '增强判断
        If (Me.MasterList Is Nothing Or Me.MasterList.Rows.Count <= 0) Then
            Return -1
        End If

        code = code.Trim()
        name = name.Trim()

        '按照v3狐狸仔的逻辑，均空的时候，返回第一条记录
        If (String.IsNullOrEmpty(code) And String.IsNullOrEmpty(name)) Then
            dgvMain.ClearSelection()
            dgvMain.Rows(0).Selected = True
            Return 0
        End If

        '进行匹配
        Dim ret As DataRow
        If ((Not String.IsNullOrEmpty(code)) And (Not String.IsNullOrEmpty(name))) Then
            ret = Me.MasterList _
                    .AsEnumerable() _
                    .FirstOrDefault(Function(x) (x.Field(Of String)("RUN_CODE").Trim().IndexOf(code, StringComparison.OrdinalIgnoreCase) >= 0) And (x.Field(Of String)("RUN_NAME").Trim().IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0))
        ElseIf (Not String.IsNullOrEmpty(code)) Then
            ret = Me.MasterList _
                    .AsEnumerable() _
                    .FirstOrDefault(Function(x) (x.Field(Of String)("RUN_CODE").Trim().IndexOf(code, StringComparison.OrdinalIgnoreCase) >= 0))

        ElseIf (Not String.IsNullOrEmpty(name)) Then
            ret = Me.MasterList _
                    .AsEnumerable() _
                    .FirstOrDefault(Function(x) (x.Field(Of String)("RUN_NAME").Trim().IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0))

        Else    '两者都为空
            '* 按照v3狐狸仔的逻辑，均空的时候，返回第一条记录
            ret = Me.MasterList.Rows(0)

        End If

        '有匹配的结果
        If ret IsNot Nothing Then
            Dim index As Integer = Me.MasterList.Rows.IndexOf(ret)

            dgvMain.ClearSelection()
            dgvMain.Rows(index).Selected = True
            dgvMain.FirstDisplayedCell = dgvMain.Rows(index).Cells(0)

            Return index
        End If

        '无匹配的结果
        Return -1
    End Function

#End Region

#Region "Monthly Cut Off"

    Sub MonthlyCutOff()
        If cls.funcExecMonthlyCutOff() Then
            GSubShowInfo(GFncGetSysMsg(130))
        End If
    End Sub

#End Region

#Region "Yearly Cut Off"

    Sub YearlyCutOff()
        If cls.funcExecYearlyCutOff() Then
            GSubShowInfo(GFncGetSysMsg(130))
        End If
    End Sub

#End Region


    '----------------------------

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRunnerTaxableIncomeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnFormLoad()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim newForm As New FrmRunnerTaxableIncomeMasterFindRecord
        newForm.SetFoundAction(AddressOf Me.FoundTargetRow)
        newForm.ShowDialog(Me)
    End Sub

    Private Sub btnMonthCut_Click(sender As Object, e As EventArgs) Handles btnMonthCut.Click
        '确认操作
        If GSubShowYNConfirm(GFncGetSysMsg(138)) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            MonthlyCutOff()
        Catch ex As Exception
        End Try
        Me.Enabled = True
        Me.Cursor = Cursors.Default
        OnFormLoad()
    End Sub

    Private Sub btnYearCut_Click(sender As Object, e As EventArgs) Handles btnYearCut.Click
        '确认操作
        If GSubShowYNConfirm(GFncGetSysMsg(139)) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            YearlyCutOff()
        Catch ex As Exception
        End Try
        Me.Enabled = True
        Me.Cursor = Cursors.Default
        OnFormLoad()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim newForm As New FrmRunnerTaxableIncomeMasterDetails
        newForm.Init_Add()
        newForm.ShowDialog(Me)

        LoadDataList()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvMain.CurrentRow Is Nothing Then Return

        Dim newForm As New FrmRunnerTaxableIncomeMasterDetails
        newForm.Init_Edit(dgvMain.CurrentRow.Cells("colCode").Value.ToString(), dgvMain.CurrentRow.Cells("colMember").Value.ToString())
        newForm.ShowDialog(Me)

        LoadDataList()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvMain.CurrentRow Is Nothing Then Return

        Dim newForm As New FrmRunnerTaxableIncomeMasterDetails
        newForm.Init_Delete(dgvMain.CurrentRow.Cells("colCode").Value.ToString(), dgvMain.CurrentRow.Cells("colMember").Value.ToString())
        newForm.ShowDialog(Me)

        LoadDataList()
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        If dgvMain.CurrentRow Is Nothing Then Return

        Dim newForm As New FrmRunnerTaxableIncomeMasterDetails
        newForm.Init_ViewOnly(dgvMain.CurrentRow.Cells("colCode").Value.ToString(), dgvMain.CurrentRow.Cells("colMember").Value.ToString())
        newForm.ShowDialog(Me)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim newForm As New FrmRunnerTaxableIncomeMasterPrint
        newForm.ShowDialog(Me)
    End Sub
End Class
