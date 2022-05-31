Public Class FrmRunnerTaxableIncomeMasterDetails

    '----------Members-----------

    Dim cls As New ClsRunnerTaxableIncomeMaster


    ''' <summary>
    ''' 当前窗体模式
    ''' </summary>
    ''' <remarks></remarks>
    Private CurrentFormMode As DetailsFormMode?

    ''' <summary>
    ''' 当前的数据主键
    ''' </summary>
    Private Current_RUN_CODE As String
    ''' <summary>
    ''' 当前的数据主键
    ''' </summary>
    Private Current_RUN_MEMBER As String


    '----------Enums-------------

#Region "窗体模式"

    ''' <summary>
    ''' 窗体模式
    ''' </summary>
    Public Enum DetailsFormMode
        ''' <summary>
        ''' 查看(Detail按钮)
        ''' </summary>
        ViewOnly = 0

        ''' <summary>
        ''' 添加
        ''' </summary>
        Add

        ''' <summary>
        ''' 编辑
        ''' </summary>
        Edit

        ''' <summary>
        ''' 预编辑(点击edit按钮后再正式为Edit)
        ''' </summary>
        PreEdit

        ''' <summary>
        ''' 删除
        ''' </summary>
        Delete

    End Enum

#End Region


    '----------Control-----------

#Region "初始化"

    ''' <summary>
    ''' 添加模式的初始化
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub Init_Add()
        Me.CurrentFormMode = DetailsFormMode.Add

        '加载默认数值
        Me.txtDate_Year.Text = cls.funcGetCurrentYearFromGLRUNCONTROL()
        Me.txtDate_Month.Text = cls.funcGetCurrentMonthFromGLRUNCONTROL()
        Me.txtRunnerMember.Text = "A"
    End Sub

    ''' <summary>
    ''' 编辑模式的初始化
    ''' </summary>
    ''' <param name="RUN_CODE"></param>
    ''' <remarks></remarks>
    Protected Friend Sub Init_Edit(ByVal RUN_CODE As String, ByVal RUN_MEMBER As String)
        Me.CurrentFormMode = DetailsFormMode.Edit
        Me.Current_RUN_CODE = RUN_CODE
        Me.Current_RUN_MEMBER = RUN_MEMBER

        Me.LoadTargetRecord()
    End Sub

    ''' <summary>
    ''' 预编辑模式的初始化
    ''' </summary>
    ''' <param name="RUN_CODE"></param>
    ''' <remarks></remarks>
    Private Sub Init_PreEdit(ByVal RUN_CODE As String, ByVal RUN_MEMBER As String)
        Me.CurrentFormMode = DetailsFormMode.PreEdit
        Me.Current_RUN_CODE = RUN_CODE
        Me.Current_RUN_MEMBER = RUN_MEMBER

        '此处不可以不再LoadTargetRecord，直接使用当前已经加载并且显示中的数据
        'Me.LoadTargetRecord()

    End Sub

    ''' <summary>
    ''' 删除模式的初始化
    ''' </summary>
    ''' <param name="RUN_CODE"></param>
    ''' <remarks></remarks>
    Protected Friend Sub Init_Delete(ByVal RUN_CODE As String, ByVal RUN_MEMBER As String)
        Me.CurrentFormMode = DetailsFormMode.Delete
        Me.Current_RUN_CODE = RUN_CODE
        Me.Current_RUN_MEMBER = RUN_MEMBER

        Me.LoadTargetRecord()
    End Sub

    ''' <summary>
    ''' 查看模式的初始化
    ''' </summary>
    ''' <param name="RUN_CODE"></param>
    ''' <remarks></remarks>
    Protected Friend Sub Init_ViewOnly(ByVal RUN_CODE As String, ByVal RUN_MEMBER As String)
        Me.CurrentFormMode = DetailsFormMode.ViewOnly
        Me.Current_RUN_CODE = RUN_CODE
        Me.Current_RUN_MEMBER = RUN_MEMBER

        Me.LoadTargetRecord()
    End Sub


#End Region

#Region "加载指定的一条记录的数据"

    Protected Friend Sub LoadTargetRecord()

        '加载数据
        Dim dt As DataTable = cls.funcGetTargetOneRecord(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER)
        If (dt Is Nothing Or dt.Rows.Count <= 0) Then
            'GSubShowInfo(xxx)
            '临时
            MsgBox("No Appropriate Record!")
            Return
        End If
        Dim dr As DataRow = dt.Rows(0)

        '填充控件
        txtRunnerCode.Text = dr("RUN_CODE").ToString().Trim()
        txtRunnerMember.Text = dr("RUN_MEMBER").ToString().Trim()
        txtName.Text = dr("Run_Name").ToString().Trim()
        txtDate_Month.Text = dr.Field(Of Integer)("TXN_MONTH")
        txtDate_Year.Text = dr.Field(Of Integer)("TXN_YEAR")
        txtStatementH.Text = dr("REMARK").ToString().Trim()

        mnbxSecurities.Text = dr.Field(Of Decimal)("STK_TO")
        mnbxAdjustToTaxableIncome.Text = dr.Field(Of Decimal)("ADJUST_TAX")
        mnbxMPFContributions.Text = dr.Field(Of Decimal)("Mpf")
        mnbxVoluntaryContributions.Text = dr.Field(Of Decimal)("Vol")
        mdtpPaymentDate.Value = dr.Field(Of DateTime)("PAY_DATE")
        mnbxMPFContributionsByCompany.Text = dr.Field(Of Decimal)("MPF_CO")
        mnbxVoluntaryContributionsByCompany.Text = dr.Field(Of Decimal)("VOL_CO")
        mnbxLeaveDays.Text = dr.Field(Of Integer)("ABSENCE")
        cbxHide.Checked = (dr("HIDE").ToString().Trim() = "1")

        mnbxHSI.Text = dr.Field(Of Integer)("HSI_TO")
        mnbxHSIOptions.Text = dr.Field(Of Integer)("HSIO_TO")
        mnbxDowJones.Text = dr.Field(Of Integer)("HSI100_To")
        mnbxMHSI.Text = dr.Field(Of Integer)("MHSI_To")
        mnbxMHSIOptions.Text = dr.Field(Of Integer)("RC_To")
        mnbxStockFutures.Text = dr.Field(Of Integer)("SF_To")
        mnbxEOptions.Text = dr.Field(Of Integer)("EO_To")
        mnbxHSI100Options.Text = dr.Field(Of Integer)("HSI100o_To")
        mnbxHShares.Text = dr.Field(Of Integer)("RCO_To")

        mnbxCumulatedMPF_Taxable.Text = dr.Field(Of Decimal)("LAST_MPF")
        mnbxCumulatedTax_Taxable.Text = dr.Field(Of Decimal)("LAST_TAX")
        mnbxBoughtForward_Withheld.Text = dr.Field(Of Decimal)("LAST_REMUN")

    End Sub


    ''' <summary>
    ''' 其他初始化
    ''' </summary>
    ''' <remarks></remarks>
    Sub OtherInits()
        '检查
        If Me.CurrentFormMode Is Nothing Then
            Throw New ApplicationException("未正确初始化，未指定模式，CurrentFormMode")
        End If

        '处理控件
        Select Case Me.CurrentFormMode
            Case DetailsFormMode.Add
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx02, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx03, False)
                dgvTaxable.Enabled = True
                dgvWithheld.Enabled = True
                btnEnterEdit.Visible = False
                btnDelete.Visible = False
            Case DetailsFormMode.Edit
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx01, True)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx02, True)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx03, True)
                btnDelete.Visible = False
                btnEnterEdit.Visible = False
                txtRunnerCode.Enabled = False
                txtRunnerMember.Enabled = False
                txtName.Enabled = True
                txtStatementH.Enabled = True
            Case DetailsFormMode.PreEdit
                btnDelete.Visible = False
                btnEnterEdit.Visible = True
                GUIChangeEnablePropertyOfChildrenEditableControls(pan00, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx01, False)
            Case DetailsFormMode.Delete
                btnSave.Visible = False
                btnEnterEdit.Visible = False
                btnDelete.Visible = True
                GUIChangeEnablePropertyOfChildrenEditableControls(pan00, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx01, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx02, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx03, False)
                dgvTaxable.Enabled = True
                dgvWithheld.Enabled = True
                btnSelect_Taxable.Enabled = True
                btnSelect_Withheld.Enabled = True
            Case Else   ' View Only
                btnEnterEdit.Visible = False
                btnSave.Visible = False
                btnDelete.Visible = False
                GUIChangeEnablePropertyOfChildrenEditableControls(pan00, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx01, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx02, False)
                GUIChangeEnablePropertyOfChildrenEditableControls(gbx03, False)
                dgvTaxable.Enabled = True
                dgvWithheld.Enabled = True
                btnSelect_Taxable.Enabled = True
                btnSelect_Withheld.Enabled = True
        End Select
        Me.Refresh()

        '加载Descriptions
        LoadDataList_Taxable()
        LoadDataList_withheld()

    End Sub


    Sub LoadDataList_Taxable()
        '保留选中索引
        Dim lastIndex As Integer = -1
        If dgvTaxable.CurrentRow IsNot Nothing Then
            lastIndex = dgvTaxable.CurrentRow.Index
        End If

        '加载数据源
        Dim dt_taxable As DataTable = cls.funcGetDescriptionOfTaxable()
        cls.funcFormatDescription(dt_taxable)
        '绑定数据源
        dgvTaxable.DataSource = dt_taxable

        '还原选中项
        lastIndex = Math.Min(lastIndex, dgvTaxable.Rows.Count - 1)         '兼容delete后
        If lastIndex >= 0 Then
            dgvTaxable.CurrentCell = Nothing
            dgvTaxable.ClearSelection()
            dgvTaxable.CurrentCell = dgvTaxable.Rows(lastIndex).Cells("ColmunDescription_dgvTaxable")
        End If
    End Sub

    Sub LoadDataList_withheld()
        '保留选中索引
        Dim lastIndex As Integer = -1
        If dgvWithheld.CurrentRow IsNot Nothing Then
            lastIndex = dgvWithheld.CurrentRow.Index
        End If

        '加载数据源
        Dim dt_withheld As DataTable = cls.funcGetDescriptionOfWithheld()
        cls.funcFormatDescription(dt_withheld)
        '绑定数据源
        dgvWithheld.DataSource = dt_withheld

        '还原选中项
        lastIndex = Math.Min(lastIndex, dgvWithheld.Rows.Count - 1)         '兼容delete后
        If lastIndex >= 0 Then
            dgvWithheld.CurrentCell = Nothing
            dgvWithheld.ClearSelection()
            dgvWithheld.CurrentCell = dgvWithheld.Rows(lastIndex).Cells("ColmunDescription_dgvWithheld")
        End If
    End Sub

#End Region

#Region "执行"

    Sub DoAction_Add()

        '数据检查
        Dim strRunnerCode = txtRunnerCode.Text.Trim()
        If String.IsNullOrWhiteSpace(strRunnerCode) Then
            GSubShowInfo(GFncGetSysMsg(131))
            txtRunnerCode.Focus()
            Return
        End If

        Dim strRunnerMember = txtRunnerMember.Text.Trim()
        If String.IsNullOrWhiteSpace(strRunnerMember) Then
            GSubShowInfo(GFncGetSysMsg(132))
            txtRunnerMember.Focus()
            Return
        End If

        Dim strRunnerName = txtName.Text.Trim()
        If String.IsNullOrWhiteSpace(strRunnerName) Then
            GSubShowInfo(GFncGetSysMsg(133))
            txtName.Focus()
            Return
        End If
        '【重复键】的检查，交由存储过程处理


        '更新到DB
        Dim execRet As String = _
        cls.funcInsNewRecord(strRunnerCode,
                                strRunnerMember,
                                strRunnerName,
                                txtStatementH.Text.Trim(), _
                                mnbxSecurities.Text.Trim(), _
                                mnbxAdjustToTaxableIncome.Text.Trim(), _
                                mnbxMPFContributions.Text.Trim(), _
                                mnbxVoluntaryContributions.Text.Trim(), _
                                mdtpPaymentDate.Value, _
                                mnbxMPFContributionsByCompany.Text.Trim(), _
                                mnbxVoluntaryContributionsByCompany.Text.Trim(), _
                                mnbxLeaveDays.Text.Trim(), _
                                IIf(cbxHide.Checked, 1, 0), _
                                mnbxHSI.Text.Trim(), _
                                mnbxHSIOptions.Text.Trim(), _
                                mnbxDowJones.Text.Trim(), _
                                mnbxMHSI.Text.Trim(), _
                                mnbxMHSIOptions.Text.Trim(), _
                                mnbxStockFutures.Text.Trim(), _
                                mnbxEOptions.Text.Trim(), _
                                mnbxHSI100Options.Text.Trim(), _
                                mnbxHShares.Text.Trim()
                                )

        Select Case execRet
            Case "OK"
                '添加成功之后，切换到PreEdit模式
                Init_PreEdit(strRunnerCode, strRunnerMember)
                OtherInits()

            Case "REPEAT"
                GSubShowInfo(GFncGetSysMsg(134))
            Case Else
                MsgBox(execRet)
        End Select

    End Sub

    Sub DoAction_Edit()

        '数据检查
        Dim strRunnerCode = txtRunnerCode.Text.Trim()
        If String.IsNullOrWhiteSpace(strRunnerCode) Then
            GSubShowInfo(GFncGetSysMsg(131))
            txtRunnerCode.Focus()
            Return
        End If

        Dim strRunnerMember = txtRunnerMember.Text.Trim()
        If String.IsNullOrWhiteSpace(strRunnerMember) Then
            GSubShowInfo(GFncGetSysMsg(132))
            txtRunnerMember.Focus()
            Return
        End If

        Dim strRunnerName = txtName.Text.Trim()
        If String.IsNullOrWhiteSpace(strRunnerName) Then
            GSubShowInfo(GFncGetSysMsg(133))
            txtName.Focus()
            Return
        End If


        '更新到DB
        Dim execRet As String = _
        cls.funcUpdTargetRecord(strRunnerCode,
                                strRunnerMember,
                                strRunnerName,
                                txtStatementH.Text.Trim(), _
                                mnbxSecurities.Text.Trim(), _
                                mnbxAdjustToTaxableIncome.Text.Trim(), _
                                mnbxMPFContributions.Text.Trim(), _
                                mnbxVoluntaryContributions.Text.Trim(), _
                                mdtpPaymentDate.Value, _
                                mnbxMPFContributionsByCompany.Text.Trim(), _
                                mnbxVoluntaryContributionsByCompany.Text.Trim(), _
                                mnbxLeaveDays.Text.Trim(), _
                                IIf(cbxHide.Checked, 1, 0), _
                                mnbxHSI.Text.Trim(), _
                                mnbxHSIOptions.Text.Trim(), _
                                mnbxDowJones.Text.Trim(), _
                                mnbxMHSI.Text.Trim(), _
                                mnbxMHSIOptions.Text.Trim(), _
                                mnbxStockFutures.Text.Trim(), _
                                mnbxEOptions.Text.Trim(), _
                                mnbxHSI100Options.Text.Trim(), _
                                mnbxHShares.Text.Trim()
                                )

        Select Case execRet
            Case "OK"
                '修改成功之后，切换到PreEdit模式
                Init_PreEdit(strRunnerCode, strRunnerMember)
                OtherInits()

            Case "NOT_EXIST"
                GSubShowInfo(GFncGetSysMsg(135))

            Case Else
                MsgBox(execRet)
        End Select

    End Sub

    Sub DoAction_EnterEdit()
        Init_Edit(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER)
        OtherInits()
    End Sub

    Sub DoAction_Delete()

        '确认操作
        If GSubShowYNConfirm(GFncGetSysMsg(11)) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        '更新到DB
        Dim execRet As String = _
        cls.funcDelTargetRecord(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER)

        Select Case execRet
            Case "OK"
                '保存成功之后，关闭
                Me.Close()

            Case "NOT_EXIST"
                GSubShowInfo(GFncGetSysMsg(135))

            Case Else
                MsgBox(execRet)
        End Select
    End Sub

#End Region


    '----------------------------

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRunnerTaxableIncomeMasterDetails_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        OtherInits()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case Me.CurrentFormMode
            Case DetailsFormMode.Add
                DoAction_Add()
            Case DetailsFormMode.Edit
                DoAction_Edit()
        End Select
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DoAction_Delete()
    End Sub

    Private Sub btnEnterEdit_Click(sender As Object, e As EventArgs) Handles btnEnterEdit.Click
        DoAction_EnterEdit()
    End Sub

    Private Sub btnSelect_Taxable_Click(sender As Object, e As EventArgs) Handles btnSelect_Taxable.Click
        If dgvTaxable.CurrentRow Is Nothing Then Return

        '标题
        Dim strDescpt As String = CType(dgvTaxable.CurrentRow.DataBoundItem, DataRowView)("Descpt").ToString().Trim()
        Dim strCompany As String = CType(dgvTaxable.CurrentRow.DataBoundItem, DataRowView)("Company").ToString().Trim()
        Dim formTitle As String = strDescpt.Clone()
        If Not String.IsNullOrWhiteSpace(strCompany) Then
            formTitle += " - " + strCompany
        End If

        '其他信息
        Dim TYPE_ID As String = CType(dgvTaxable.CurrentRow.DataBoundItem, DataRowView)("TYPE_ID").ToString().Trim()
        Dim TaxType As String = IIf(TYPE_ID = "22", "2", "0")

        '显示窗体
        Dim newForm As New FrmRunnerTaxableIncomeMasterSelect
        newForm.Init_Basic(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER,
                           formTitle, Me.CurrentFormMode <> DetailsFormMode.Edit,
                           TYPE_ID,
                           TaxType)
        newForm.ShowDialog()

        '重新加载数据
        LoadDataList_Taxable()
    End Sub

    Private Sub btnSelect_Withheld_Click(sender As Object, e As EventArgs) Handles btnSelect_Withheld.Click
        If dgvWithheld.CurrentRow Is Nothing Then Return

        '标题
        Dim strDescpt As String = CType(dgvWithheld.CurrentRow.DataBoundItem, DataRowView)("Descpt").ToString().Trim()
        Dim strCompany As String = CType(dgvWithheld.CurrentRow.DataBoundItem, DataRowView)("Company").ToString().Trim()
        Dim formTitle As String = strDescpt.Clone()
        If Not String.IsNullOrWhiteSpace(strCompany) Then
            formTitle += " - " + strCompany
        End If

        '其他信息
        Dim TYPE_ID As String = CType(dgvWithheld.CurrentRow.DataBoundItem, DataRowView)("TYPE_ID").ToString().Trim()
        Dim TaxType As String = "1"

        '显示窗体
        Dim newForm As New FrmRunnerTaxableIncomeMasterSelect
        newForm.Init_Basic(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER,
                           formTitle, Me.CurrentFormMode <> DetailsFormMode.Edit,
                           TYPE_ID,
                           TaxType)
        newForm.ShowDialog(Me)

        '重新加载数据
        LoadDataList_withheld()
    End Sub
End Class
