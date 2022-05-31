<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptOverTrade
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.CB1000 = New ESL.myCheckBox(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnModify = New System.Windows.Forms.Button
        Me.btnDown = New System.Windows.Forms.Button
        Me.BtnUp = New System.Windows.Forms.Button
        Me.dgdSign = New System.Windows.Forms.DataGridView
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sign_by = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btnLModify = New System.Windows.Forms.Button
        Me.chkZero = New System.Windows.Forms.CheckBox
        Me.txtSGroup = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnLSearch = New System.Windows.Forms.Button
        Me.txtSName = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSAE = New ESL.myTextbox
        Me.dgdLimit = New System.Windows.Forms.DataGridView
        Me.run_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.overtrade_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.overtrade_limit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgdSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgdLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(466, 351)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(413, 351)
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(29, 278)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 20
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(32, 296)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(405, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(479, 68)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(146, 30)
        Me.RBPrint.Name = "RBPrint"
        Me.RBPrint.Size = New System.Drawing.Size(108, 19)
        Me.RBPrint.TabIndex = 1
        Me.RBPrint.Text = "Direct to printer"
        Me.RBPrint.UseVisualStyleBackColor = True
        '
        'RBPreview
        '
        Me.RBPreview.AutoSize = True
        Me.RBPreview.Checked = True
        Me.RBPreview.Location = New System.Drawing.Point(20, 30)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'CB1000
        '
        Me.CB1000.AutoSize = True
        Me.CB1000.Checked = True
        Me.CB1000.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB1000.Location = New System.Drawing.Point(32, 37)
        Me.CB1000.Name = "CB1000"
        Me.CB1000.Size = New System.Drawing.Size(205, 19)
        Me.CB1000.TabIndex = 22
        Me.CB1000.Text = "Exclude Total Margin Call < 1000"
        Me.CB1000.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 409)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.CB1000)
        Me.TabPage1.Controls.Add(Me.lblProcess)
        Me.TabPage1.Controls.Add(Me.pbarPrint)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(532, 381)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Linen
        Me.TabPage2.Controls.Add(Me.btnModify)
        Me.TabPage2.Controls.Add(Me.btnDown)
        Me.TabPage2.Controls.Add(Me.BtnUp)
        Me.TabPage2.Controls.Add(Me.dgdSign)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(532, 381)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Signature"
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(453, 127)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(58, 23)
        Me.btnModify.TabIndex = 33
        Me.btnModify.Text = "Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(453, 98)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(58, 23)
        Me.btnDown.TabIndex = 32
        Me.btnDown.Text = "Down"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'BtnUp
        '
        Me.BtnUp.Location = New System.Drawing.Point(453, 67)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(58, 23)
        Me.BtnUp.TabIndex = 31
        Me.BtnUp.Text = "Up"
        Me.BtnUp.UseVisualStyleBackColor = True
        '
        'dgdSign
        '
        Me.dgdSign.AllowUserToDeleteRows = False
        Me.dgdSign.BackgroundColor = System.Drawing.Color.Linen
        Me.dgdSign.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgdSign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdSign.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Title, Me.sign_by, Me.seq})
        Me.dgdSign.Location = New System.Drawing.Point(5, 6)
        Me.dgdSign.MultiSelect = False
        Me.dgdSign.Name = "dgdSign"
        Me.dgdSign.RowHeadersVisible = False
        Me.dgdSign.RowHeadersWidth = 20
        Me.dgdSign.RowTemplate.Height = 24
        Me.dgdSign.Size = New System.Drawing.Size(444, 274)
        Me.dgdSign.TabIndex = 0
        '
        'Title
        '
        Me.Title.DataPropertyName = "title"
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.Width = 170
        '
        'sign_by
        '
        Me.sign_by.DataPropertyName = "sign_by"
        Me.sign_by.HeaderText = "By"
        Me.sign_by.Name = "sign_by"
        Me.sign_by.Width = 170
        '
        'seq
        '
        Me.seq.DataPropertyName = "seq"
        Me.seq.HeaderText = "Sort Seq"
        Me.seq.Name = "seq"
        Me.seq.Width = 80
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Linen
        Me.TabPage3.Controls.Add(Me.btnLModify)
        Me.TabPage3.Controls.Add(Me.chkZero)
        Me.TabPage3.Controls.Add(Me.txtSGroup)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.btnLSearch)
        Me.TabPage3.Controls.Add(Me.txtSName)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.txtSAE)
        Me.TabPage3.Controls.Add(Me.dgdLimit)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(532, 381)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Over Trade Limit"
        '
        'btnLModify
        '
        Me.btnLModify.Location = New System.Drawing.Point(467, 38)
        Me.btnLModify.Name = "btnLModify"
        Me.btnLModify.Size = New System.Drawing.Size(59, 23)
        Me.btnLModify.TabIndex = 9
        Me.btnLModify.Text = "Modify"
        Me.btnLModify.UseVisualStyleBackColor = True
        '
        'chkZero
        '
        Me.chkZero.AutoSize = True
        Me.chkZero.Location = New System.Drawing.Point(413, 11)
        Me.chkZero.Name = "chkZero"
        Me.chkZero.Size = New System.Drawing.Size(51, 19)
        Me.chkZero.TabIndex = 8
        Me.chkZero.Text = "Zero"
        Me.chkZero.UseVisualStyleBackColor = True
        '
        'txtSGroup
        '
        Me.txtSGroup.Location = New System.Drawing.Point(269, 9)
        Me.txtSGroup.Name = "txtSGroup"
        Me.txtSGroup.Size = New System.Drawing.Size(137, 21)
        Me.txtSGroup.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Group"
        '
        'btnLSearch
        '
        Me.btnLSearch.Location = New System.Drawing.Point(467, 9)
        Me.btnLSearch.Name = "btnLSearch"
        Me.btnLSearch.Size = New System.Drawing.Size(59, 23)
        Me.btnLSearch.TabIndex = 5
        Me.btnLSearch.Text = "Search"
        Me.btnLSearch.UseVisualStyleBackColor = True
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(91, 9)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.Size = New System.Drawing.Size(137, 21)
        Me.txtSName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(5, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "AE"
        '
        'txtSAE
        '
        Me.txtSAE.Location = New System.Drawing.Point(27, 9)
        Me.txtSAE.Name = "txtSAE"
        Me.txtSAE.Size = New System.Drawing.Size(62, 21)
        Me.txtSAE.TabIndex = 1
        '
        'dgdLimit
        '
        Me.dgdLimit.AllowUserToAddRows = False
        Me.dgdLimit.AllowUserToDeleteRows = False
        Me.dgdLimit.BackgroundColor = System.Drawing.Color.Linen
        Me.dgdLimit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgdLimit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdLimit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.run_code, Me.ae_name, Me.overtrade_group, Me.overtrade_limit})
        Me.dgdLimit.Location = New System.Drawing.Point(5, 36)
        Me.dgdLimit.Name = "dgdLimit"
        Me.dgdLimit.RowHeadersVisible = False
        Me.dgdLimit.RowTemplate.Height = 24
        Me.dgdLimit.Size = New System.Drawing.Size(442, 280)
        Me.dgdLimit.TabIndex = 0
        '
        'run_code
        '
        Me.run_code.DataPropertyName = "run_code"
        Me.run_code.HeaderText = "AE"
        Me.run_code.Name = "run_code"
        Me.run_code.Width = 80
        '
        'ae_name
        '
        Me.ae_name.DataPropertyName = "run_name"
        Me.ae_name.HeaderText = "Name"
        Me.ae_name.Name = "ae_name"
        '
        'overtrade_group
        '
        Me.overtrade_group.DataPropertyName = "overtrade_group"
        Me.overtrade_group.HeaderText = "OT Group"
        Me.overtrade_group.MaxInputLength = 20
        Me.overtrade_group.Name = "overtrade_group"
        Me.overtrade_group.Width = 120
        '
        'overtrade_limit
        '
        Me.overtrade_limit.DataPropertyName = "overtrade_limit"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.overtrade_limit.DefaultCellStyle = DataGridViewCellStyle1
        Me.overtrade_limit.HeaderText = "OT Limit"
        Me.overtrade_limit.Name = "overtrade_limit"
        Me.overtrade_limit.Width = 120
        '
        'FrmRptOverTrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(544, 416)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.Name = "FrmRptOverTrade"
        Me.Text = "Over Trade Report"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgdSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgdLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents CB1000 As ESL.myCheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgdSign As System.Windows.Forms.DataGridView
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents BtnUp As System.Windows.Forms.Button
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sign_by As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgdLimit As System.Windows.Forms.DataGridView
    Friend WithEvents btnLSearch As System.Windows.Forms.Button
    Friend WithEvents txtSName As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSAE As ESL.myTextbox
    Friend WithEvents txtSGroup As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkZero As System.Windows.Forms.CheckBox
    Friend WithEvents btnLModify As System.Windows.Forms.Button
    Friend WithEvents run_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents overtrade_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents overtrade_limit As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
