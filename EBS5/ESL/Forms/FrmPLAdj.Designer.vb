<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPLAdj
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPLAdj))
        Me.tabctrlMain = New System.Windows.Forms.TabControl
        Me.View = New System.Windows.Forms.TabPage
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.Grid_adjTDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grid_AdjOpnBal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grid_counterparty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grid_AdjNopnBal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grid_lupduser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grid_lupddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grid_AdjRemark = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SearchCriteria = New System.Windows.Forms.GroupBox
        Me.txtSearchTDate = New System.Windows.Forms.DateTimePicker
        Me.txtSearchCounterParty = New ESL.myComboBox(Me.components)
        Me.showAll = New ESL.myButton(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Add = New System.Windows.Forms.TabPage
        Me.txtLUpdUser = New ESL.myAmountBox
        Me.txtLUpdDate = New ESL.myAmountBox
        Me.txtTDate = New ESL.myDateTimePicker
        Me.txtCounterparty = New ESL.myComboBox(Me.components)
        Me.txtRemarks = New ESL.myTextbox
        Me.txtPLAdjCounter = New ESL.myAmountBox
        Me.txtPLAdj = New ESL.myAmountBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnAddModify = New ESL.myButton(Me.components)
        Me.btnAddDelete = New ESL.myButton(Me.components)
        Me.btnAddSave = New ESL.myButton(Me.components)
        Me.btnAddBack = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.tabctrlMain.SuspendLayout()
        Me.View.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchCriteria.SuspendLayout()
        Me.Add.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(655, 489)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(603, 489)
        '
        'tabctrlMain
        '
        Me.tabctrlMain.Controls.Add(Me.View)
        Me.tabctrlMain.Controls.Add(Me.Add)
        Me.tabctrlMain.Location = New System.Drawing.Point(14, 37)
        Me.tabctrlMain.Name = "tabctrlMain"
        Me.tabctrlMain.SelectedIndex = 0
        Me.tabctrlMain.Size = New System.Drawing.Size(695, 445)
        Me.tabctrlMain.TabIndex = 6
        '
        'View
        '
        Me.View.Controls.Add(Me.DataGridView)
        Me.View.Controls.Add(Me.SearchCriteria)
        Me.View.Location = New System.Drawing.Point(4, 24)
        Me.View.Name = "View"
        Me.View.Padding = New System.Windows.Forms.Padding(3)
        Me.View.Size = New System.Drawing.Size(687, 417)
        Me.View.TabIndex = 0
        Me.View.Text = "View"
        Me.View.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.BackgroundColor = System.Drawing.Color.Linen
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Grid_adjTDate, Me.Grid_AdjOpnBal, Me.Grid_counterparty, Me.Grid_AdjNopnBal, Me.Grid_lupduser, Me.Grid_lupddate, Me.Grid_AdjRemark})
        Me.DataGridView.Location = New System.Drawing.Point(12, 9)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowTemplate.Height = 24
        Me.DataGridView.Size = New System.Drawing.Size(669, 277)
        Me.DataGridView.TabIndex = 1
        '
        'Grid_adjTDate
        '
        Me.Grid_adjTDate.DataPropertyName = "adjTdate"
        Me.Grid_adjTDate.HeaderText = "Adj.TradeDate"
        Me.Grid_adjTDate.Name = "Grid_adjTDate"
        Me.Grid_adjTDate.ReadOnly = True
        '
        'Grid_AdjOpnBal
        '
        Me.Grid_AdjOpnBal.DataPropertyName = "AdjOpnBal"
        Me.Grid_AdjOpnBal.HeaderText = "G2BF PL Adj."
        Me.Grid_AdjOpnBal.Name = "Grid_AdjOpnBal"
        Me.Grid_AdjOpnBal.ReadOnly = True
        '
        'Grid_counterparty
        '
        Me.Grid_counterparty.DataPropertyName = "counterparty"
        Me.Grid_counterparty.HeaderText = "Counterparty"
        Me.Grid_counterparty.Name = "Grid_counterparty"
        Me.Grid_counterparty.ReadOnly = True
        '
        'Grid_AdjNopnBal
        '
        Me.Grid_AdjNopnBal.DataPropertyName = "AdjNopnBal"
        Me.Grid_AdjNopnBal.HeaderText = "PL Adj."
        Me.Grid_AdjNopnBal.Name = "Grid_AdjNopnBal"
        Me.Grid_AdjNopnBal.ReadOnly = True
        '
        'Grid_lupduser
        '
        Me.Grid_lupduser.DataPropertyName = "lupduser"
        Me.Grid_lupduser.HeaderText = "Last Update User"
        Me.Grid_lupduser.Name = "Grid_lupduser"
        Me.Grid_lupduser.ReadOnly = True
        '
        'Grid_lupddate
        '
        Me.Grid_lupddate.DataPropertyName = "lupddate"
        Me.Grid_lupddate.HeaderText = "Last update Date"
        Me.Grid_lupddate.Name = "Grid_lupddate"
        Me.Grid_lupddate.ReadOnly = True
        '
        'Grid_AdjRemark
        '
        Me.Grid_AdjRemark.DataPropertyName = "AdjRemark"
        Me.Grid_AdjRemark.HeaderText = "Remarks"
        Me.Grid_AdjRemark.Name = "Grid_AdjRemark"
        Me.Grid_AdjRemark.ReadOnly = True
        '
        'SearchCriteria
        '
        Me.SearchCriteria.Controls.Add(Me.txtSearchTDate)
        Me.SearchCriteria.Controls.Add(Me.txtSearchCounterParty)
        Me.SearchCriteria.Controls.Add(Me.showAll)
        Me.SearchCriteria.Controls.Add(Me.btnSearch)
        Me.SearchCriteria.Controls.Add(Me.Label2)
        Me.SearchCriteria.Controls.Add(Me.Label1)
        Me.SearchCriteria.Location = New System.Drawing.Point(57, 292)
        Me.SearchCriteria.Name = "SearchCriteria"
        Me.SearchCriteria.Size = New System.Drawing.Size(578, 109)
        Me.SearchCriteria.TabIndex = 0
        Me.SearchCriteria.TabStop = False
        Me.SearchCriteria.Text = "Search Criteria"
        '
        'txtSearchTDate
        '
        Me.txtSearchTDate.CustomFormat = "MM/dd/yyyy"
        Me.txtSearchTDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtSearchTDate.Location = New System.Drawing.Point(170, 34)
        Me.txtSearchTDate.Name = "txtSearchTDate"
        Me.txtSearchTDate.Size = New System.Drawing.Size(161, 21)
        Me.txtSearchTDate.TabIndex = 7
        '
        'txtSearchCounterParty
        '
        Me.txtSearchCounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSearchCounterParty.FormattingEnabled = True
        Me.txtSearchCounterParty.Location = New System.Drawing.Point(170, 72)
        Me.txtSearchCounterParty.Name = "txtSearchCounterParty"
        Me.txtSearchCounterParty.Size = New System.Drawing.Size(161, 23)
        Me.txtSearchCounterParty.TabIndex = 6
        '
        'showAll
        '
        Me.showAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.showAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showAll.Image = CType(resources.GetObject("showAll.Image"), System.Drawing.Image)
        Me.showAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.showAll.Location = New System.Drawing.Point(485, 36)
        Me.showAll.Name = "showAll"
        Me.showAll.Size = New System.Drawing.Size(59, 55)
        Me.showAll.TabIndex = 4
        Me.showAll.Text = "Show All"
        Me.showAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.showAll.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSearch.Location = New System.Drawing.Point(410, 36)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(59, 55)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Counterparty"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Trade Date"
        '
        'Add
        '
        Me.Add.Controls.Add(Me.txtLUpdUser)
        Me.Add.Controls.Add(Me.txtLUpdDate)
        Me.Add.Controls.Add(Me.txtTDate)
        Me.Add.Controls.Add(Me.txtCounterparty)
        Me.Add.Controls.Add(Me.txtRemarks)
        Me.Add.Controls.Add(Me.txtPLAdjCounter)
        Me.Add.Controls.Add(Me.txtPLAdj)
        Me.Add.Controls.Add(Me.Label8)
        Me.Add.Controls.Add(Me.Label7)
        Me.Add.Controls.Add(Me.Label6)
        Me.Add.Controls.Add(Me.btnAddModify)
        Me.Add.Controls.Add(Me.btnAddDelete)
        Me.Add.Controls.Add(Me.btnAddSave)
        Me.Add.Controls.Add(Me.btnAddBack)
        Me.Add.Controls.Add(Me.btnAdd)
        Me.Add.Controls.Add(Me.Label9)
        Me.Add.Controls.Add(Me.Label5)
        Me.Add.Controls.Add(Me.Label4)
        Me.Add.Controls.Add(Me.Label3)
        Me.Add.Location = New System.Drawing.Point(4, 24)
        Me.Add.Name = "Add"
        Me.Add.Padding = New System.Windows.Forms.Padding(3)
        Me.Add.Size = New System.Drawing.Size(687, 417)
        Me.Add.TabIndex = 1
        Me.Add.Text = "Add"
        Me.Add.UseVisualStyleBackColor = True
        '
        'txtLUpdUser
        '
        Me.txtLUpdUser.DecimalPoints = 2
        Me.txtLUpdUser.Location = New System.Drawing.Point(467, 40)
        Me.txtLUpdUser.Name = "txtLUpdUser"
        Me.txtLUpdUser.Size = New System.Drawing.Size(134, 21)
        Me.txtLUpdUser.TabIndex = 54
        Me.txtLUpdUser.Text = " "
        Me.txtLUpdUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLUpdDate
        '
        Me.txtLUpdDate.DecimalPoints = 2
        Me.txtLUpdDate.Location = New System.Drawing.Point(467, 93)
        Me.txtLUpdDate.Name = "txtLUpdDate"
        Me.txtLUpdDate.Size = New System.Drawing.Size(134, 21)
        Me.txtLUpdDate.TabIndex = 53
        Me.txtLUpdDate.Text = " "
        Me.txtLUpdDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTDate
        '
        Me.txtTDate.CustomFormat = "MM/dd/yyyy"
        Me.txtTDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtTDate.Location = New System.Drawing.Point(189, 43)
        Me.txtTDate.Name = "txtTDate"
        Me.txtTDate.Size = New System.Drawing.Size(135, 21)
        Me.txtTDate.TabIndex = 52
        '
        'txtCounterparty
        '
        Me.txtCounterparty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCounterparty.FormattingEnabled = True
        Me.txtCounterparty.Location = New System.Drawing.Point(189, 83)
        Me.txtCounterparty.Name = "txtCounterparty"
        Me.txtCounterparty.Size = New System.Drawing.Size(135, 23)
        Me.txtCounterparty.TabIndex = 49
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(189, 219)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(257, 56)
        Me.txtRemarks.TabIndex = 48
        '
        'txtPLAdjCounter
        '
        Me.txtPLAdjCounter.DecimalPoints = 2
        Me.txtPLAdjCounter.Location = New System.Drawing.Point(189, 174)
        Me.txtPLAdjCounter.Name = "txtPLAdjCounter"
        Me.txtPLAdjCounter.Size = New System.Drawing.Size(134, 21)
        Me.txtPLAdjCounter.TabIndex = 47
        Me.txtPLAdjCounter.Text = " "
        Me.txtPLAdjCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPLAdj
        '
        Me.txtPLAdj.DecimalPoints = 2
        Me.txtPLAdj.Location = New System.Drawing.Point(189, 128)
        Me.txtPLAdj.Name = "txtPLAdj"
        Me.txtPLAdj.Size = New System.Drawing.Size(134, 21)
        Me.txtPLAdj.TabIndex = 46
        Me.txtPLAdj.Text = " "
        Me.txtPLAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 15)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "PL Adj. (Counterparty)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(342, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Last Updated User"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(342, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Last Updated Date"
        '
        'btnAddModify
        '
        Me.btnAddModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddModify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddModify.Location = New System.Drawing.Point(503, 328)
        Me.btnAddModify.Name = "btnAddModify"
        Me.btnAddModify.Size = New System.Drawing.Size(50, 55)
        Me.btnAddModify.TabIndex = 38
        Me.btnAddModify.Text = "Modify"
        Me.btnAddModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddModify.UseVisualStyleBackColor = True
        '
        'btnAddDelete
        '
        Me.btnAddDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDelete.Location = New System.Drawing.Point(399, 328)
        Me.btnAddDelete.Name = "btnAddDelete"
        Me.btnAddDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnAddDelete.TabIndex = 36
        Me.btnAddDelete.Text = "Delete"
        Me.btnAddDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddDelete.UseVisualStyleBackColor = True
        '
        'btnAddSave
        '
        Me.btnAddSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSave.Location = New System.Drawing.Point(555, 328)
        Me.btnAddSave.Name = "btnAddSave"
        Me.btnAddSave.Size = New System.Drawing.Size(50, 55)
        Me.btnAddSave.TabIndex = 37
        Me.btnAddSave.Text = "Save"
        Me.btnAddSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddSave.UseVisualStyleBackColor = True
        '
        'btnAddBack
        '
        Me.btnAddBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBack.Location = New System.Drawing.Point(607, 328)
        Me.btnAddBack.Name = "btnAddBack"
        Me.btnAddBack.Size = New System.Drawing.Size(50, 55)
        Me.btnAddBack.TabIndex = 35
        Me.btnAddBack.Text = "Back"
        Me.btnAddBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddBack.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(451, 328)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 34
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(59, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Remarks"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Counterparty"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "G2BF PL Adj."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Trade Date"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(722, 22)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "PL Adjustment"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmPLAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(721, 548)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tabctrlMain)
        Me.KeyPreview = True
        Me.Name = "FrmPLAdj"
        Me.Text = "PL Adjustment"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.tabctrlMain, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.tabctrlMain.ResumeLayout(False)
        Me.View.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchCriteria.ResumeLayout(False)
        Me.SearchCriteria.PerformLayout()
        Me.Add.ResumeLayout(False)
        Me.Add.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabctrlMain As System.Windows.Forms.TabControl
    Friend WithEvents View As System.Windows.Forms.TabPage
    Friend WithEvents SearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Add As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents btnAddModify As ESL.myButton
    Friend WithEvents btnAddDelete As ESL.myButton
    Friend WithEvents btnAddBack As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents showAll As ESL.myButton
    Friend WithEvents btnAddSave As ESL.myButton
    Friend WithEvents txtPLAdjCounter As ESL.myAmountBox
    Friend WithEvents txtPLAdj As ESL.myAmountBox
    Friend WithEvents txtRemarks As ESL.myTextbox
    Friend WithEvents txtSearchCounterParty As ESL.myComboBox
    Friend WithEvents txtCounterparty As ESL.myComboBox
    Friend WithEvents txtSearchTDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Grid_adjTDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid_AdjOpnBal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid_counterparty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid_AdjNopnBal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid_lupduser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid_lupddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid_AdjRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents txtTDate As ESL.myDateTimePicker
    Friend WithEvents txtLUpdUser As ESL.myAmountBox
    Friend WithEvents txtLUpdDate As ESL.myAmountBox

End Class
