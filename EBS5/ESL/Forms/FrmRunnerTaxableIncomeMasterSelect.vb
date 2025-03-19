Public Class FrmRunnerTaxableIncomeMasterSelect

    '----------Members----------

    Dim cls As New ClsRunnerTaxableIncomeMaster


    ''' <summary>
    ''' 当前窗体模式
    ''' </summary>
    ''' <remarks></remarks>
    Private CurrentFormMode As SelectFormMode?

    ''' <summary>
    ''' 当前的数据主键
    ''' </summary>
    Private Current_RUN_CODE As String
    ''' <summary>
    ''' 当前的数据主键
    ''' </summary>
    Private Current_RUN_MEMBER As String
    ''' <summary>
    ''' 当前的数据信息引用
    ''' </summary>
    Private Current_TYPE_ID As Integer
    ''' <summary>
    ''' 当前的数据信息引用
    ''' </summary>
    Private Current_TAXTYPE As String

    ''' <summary>
    ''' 上一次的列表数据源
    ''' </summary>
    ''' <remarks></remarks>
    Private Last_DataSource As DataTable


    '----------Enums------------

#Region "窗体模式"

    ''' <summary>
    ''' 窗体模式
    ''' </summary>
    Public Enum SelectFormMode

        ''' <summary>
        ''' 预备状态
        ''' </summary>
        ''' <remarks></remarks>
        StandBy = 0

        ''' <summary>
        ''' 只能查看，不允许其他操作
        ''' </summary>
        ViewOnly

        ''' <summary>
        ''' 修改中(新增或修改)
        ''' </summary>
        Modifing

    End Enum

#End Region


    '----------Control----------

#Region "初始化"

    ''' <summary>
    ''' 基础的初始化
    ''' </summary>
    Protected Friend Sub Init_Basic(ByVal RUN_CODE As String, ByVal RUN_MEMBER As String,
                                    ByVal FormTitle As String, ByVal viewOnly As Boolean,
                                    ByVal TYPE_ID As Integer,
                                    ByVal TAXTYPE As String)

        '数据
        Me.Current_RUN_CODE = RUN_CODE
        Me.Current_RUN_MEMBER = RUN_MEMBER
        Me.Current_TYPE_ID = TYPE_ID
        Me.Current_TAXTYPE = TAXTYPE

        'UI
        Me.Text = FormTitle

        '模式
        If viewOnly Then
            Me.CurrentFormMode = SelectFormMode.ViewOnly
        Else
            Me.CurrentFormMode = SelectFormMode.StandBy
        End If

    End Sub

    ''' <summary>
    ''' 其他初始化
    ''' </summary>
    ''' <remarks></remarks>
    Sub OtherInits()

        '根据模式呈现不同的状态
        Select Case Me.CurrentFormMode
            Case SelectFormMode.ViewOnly
                btnAdd.Enabled = False
                btnEnterEdit.Enabled = False
                btnCancelEditing.Enabled = False
                btnCancelEditing.Visible = False
                btnDelete.Enabled = False
                btnSave.Enabled = False
                btnSave.Visible = False
                btnCancel.Enabled = True
                dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Case SelectFormMode.StandBy
                btnAdd.Enabled = True
                btnEnterEdit.Enabled = True
                btnCancelEditing.Enabled = False
                btnCancelEditing.Visible = False
                btnDelete.Enabled = True
                btnSave.Enabled = False
                btnSave.Visible = False
                btnCancel.Enabled = True
                dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Case SelectFormMode.Modifing
                btnAdd.Enabled = False
                btnEnterEdit.Enabled = False
                btnCancelEditing.Enabled = True
                btnCancelEditing.Visible = True
                btnDelete.Enabled = False
                btnSave.Enabled = True
                btnSave.Visible = True
                btnCancel.Enabled = False
                dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect

        End Select

    End Sub

    Sub ReLoadSelectDatas()
        '保留选中索引
        Dim lastIndex As Integer = -1
        If dgvMain.CurrentRow IsNot Nothing Then
            lastIndex = dgvMain.CurrentRow.Index
        End If

        '加载数据源
        Me.Last_DataSource = cls.funcGetDescriptionSelects(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER, Me.Current_TYPE_ID, Me.Current_TAXTYPE)
        '绑定数据源
        dgvMain.DataSource = Me.Last_DataSource.Copy()

        '还原选中项
        lastIndex = Math.Min(lastIndex, dgvMain.Rows.Count - 1)         '兼容delete后
        If lastIndex >= 0 Then
            dgvMain.CurrentCell = Nothing
            dgvMain.ClearSelection()
            dgvMain.CurrentCell = dgvMain.Rows(lastIndex).Cells(0)
        End If
    End Sub

#End Region

#Region "新增行"

    ''' <summary>
    ''' 新增行
    ''' </summary>
    Sub DoAction_Add()
        Dim dt As DataTable = CType(dgvMain.DataSource, DataTable)
        Dim newRow As DataRow = dt.Rows.Add("", "0.00", -1)
        Dim Last_NewRowIndex = dt.Rows.IndexOf(newRow)
        dgvMain.CurrentCell = dgvMain.Rows(Last_NewRowIndex).Cells(0)

        dgvMain.BeginEdit(False)

        Me.CurrentFormMode = SelectFormMode.Modifing
        OtherInits()
    End Sub
#End Region

#Region "删除当前行"

    ''' <summary>
    ''' 删除当前行
    ''' </summary>
    Sub DoAction_Delete()
        If dgvMain.CurrentCell Is Nothing Then Return

        '确认操作
        If GSubShowYNConfirm(GFncGetSysMsg(11)) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        '同步更新到DB
        'Dim targetITEM As Integer = CType(dgvMain.CurrentRow.DataBoundItem, DataRowView)("ITEM")
        Me.Last_DataSource.Rows.RemoveAt(dgvMain.CurrentRow.Index)
        If Helper_SyncDataToDB(Me.Last_DataSource) Then
            Me.CurrentFormMode = SelectFormMode.StandBy
            OtherInits()

            '成功之后重新加载
            ReLoadSelectDatas()
        End If

    End Sub

#End Region

#Region "开始编辑"

    ''' <summary>
    ''' 开始编辑
    ''' </summary>
    Sub DoAction_EnterEdit()
        If dgvMain.CurrentCell Is Nothing Then Return

        dgvMain.BeginEdit(False)

        Me.CurrentFormMode = SelectFormMode.Modifing
        OtherInits()
    End Sub

#End Region

#Region "取消编辑"

    ''' <summary>
    ''' 取消编辑
    ''' </summary>
    Sub DoAction_CancelEditing()

        dgvMain.CancelEdit()

        Me.CurrentFormMode = SelectFormMode.StandBy
        OtherInits()

        '还原datasource
        ReLoadSelectDatas()
    End Sub

#End Region

#Region "保存当前编辑结果"

    ''' <summary>
    ''' 保存当前编辑结果
    ''' </summary>
    Sub DoAction_Save()

        '结束当前单元格的编辑状态
        If dgvMain.EndEdit() <> True Then Return

        '同步数据
        If Helper_SyncDataToDB(CType(dgvMain.DataSource, DataTable)) Then
            Me.CurrentFormMode = SelectFormMode.StandBy
            OtherInits()

            '成功之后重新加载
            ReLoadSelectDatas()
        End If

    End Sub

    ''' <summary>
    ''' 同步数据
    ''' </summary>
    Function Helper_SyncDataToDB(ByRef dt As DataTable) As Boolean
        Return cls.funcSyncDescriptionSelects(Me.Current_RUN_CODE, Me.Current_RUN_MEMBER, Current_TYPE_ID, Me.Current_TAXTYPE, dt)
    End Function

#End Region


    '----------------------------

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'UI
        btnAdd.Location = btnSave.Location
        btnEnterEdit.Location = btnCancelEditing.Location

        OtherInits()
        ReLoadSelectDatas()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        DoAction_Add()
    End Sub

    Private Sub btnCancelEditing_Click(sender As Object, e As EventArgs) Handles btnCancelEditing.Click
        DoAction_CancelEditing()
    End Sub

    Private Sub btnEnterEdit_Click(sender As Object, e As EventArgs) Handles btnEnterEdit.Click
        DoAction_EnterEdit()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DoAction_Save()
    End Sub

    Private Sub dgvMain_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellEnter

        '编辑模式下的处理
        If Me.CurrentFormMode <> SelectFormMode.Modifing Then Return

        dgvMain.CurrentCell = dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex)
        dgvMain.BeginEdit(False)

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DoAction_Delete()
    End Sub

    Private Sub dgvMain_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvMain.CellValidating

        If (dgvMain.CurrentCell IsNot Nothing And Me.CurrentFormMode = SelectFormMode.Modifing And e.ColumnIndex = 1) Then '第2列

            'Amount数字类型
            Dim checkedNumberValue As Decimal
            If Decimal.TryParse(e.FormattedValue.ToString(), checkedNumberValue) = False Then
                e.Cancel = True
                lblTip.Visible = True
                Return
            End If

        End If

        lblTip.Visible = False

    End Sub

    Private Sub dgvMain_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellEndEdit

        '编辑状态
        If (dgvMain.CurrentCell IsNot Nothing And Me.CurrentFormMode = SelectFormMode.Modifing) Then

            Select Case e.ColumnIndex

                Case 1  'Amount数字范围
                    Dim checkedNumberValue As Decimal
                    If Decimal.TryParse(dgvMain.CurrentCell.Value.ToString(), checkedNumberValue) Then
                        'If (checkedNumberValue < 0) Then dgvMain.CurrentCell.Value = 0D
                        If (checkedNumberValue < -99999999999999.99D) Then dgvMain.CurrentCell.Value = -99999999999999.99D
                        If (checkedNumberValue > 99999999999999.99D) Then dgvMain.CurrentCell.Value = 99999999999999.99D
                    End If

                Case 0  'Description字符长度
                    If dgvMain.CurrentCell.Value.ToString.Length > 40 Then
                        dgvMain.CurrentCell.Value = dgvMain.CurrentCell.Value.ToString.Substring(0, 40)
                    End If

            End Select
        End If

    End Sub


End Class
