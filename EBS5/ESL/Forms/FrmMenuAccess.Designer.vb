<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuAccess
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.level_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.level_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Level_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.level_4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccessFlag = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.menucode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnModify = New System.Windows.Forms.Button
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgdFnc = New System.Windows.Forms.DataGridView
        Me.Fnc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FncAccess = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.fnccode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fnckey = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgdFnc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(683, 423)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(631, 423)
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(67, 22)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(171, 23)
        Me.ComboBox1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "User ID"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LemonChiffon
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.level_1, Me.level_2, Me.Level_3, Me.level_4, Me.AccessFlag, Me.menucode})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.Size = New System.Drawing.Size(703, 325)
        Me.DataGridView1.TabIndex = 8
        '
        'level_1
        '
        Me.level_1.DataPropertyName = "level_1"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.level_1.DefaultCellStyle = DataGridViewCellStyle1
        Me.level_1.HeaderText = "Level 1"
        Me.level_1.Name = "level_1"
        Me.level_1.ReadOnly = True
        Me.level_1.Width = 200
        '
        'level_2
        '
        Me.level_2.DataPropertyName = "level_2"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.level_2.DefaultCellStyle = DataGridViewCellStyle2
        Me.level_2.HeaderText = "Level 2"
        Me.level_2.Name = "level_2"
        Me.level_2.ReadOnly = True
        Me.level_2.Width = 150
        '
        'Level_3
        '
        Me.Level_3.DataPropertyName = "level_3"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.Level_3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Level_3.HeaderText = "Level 3"
        Me.Level_3.Name = "Level_3"
        Me.Level_3.ReadOnly = True
        Me.Level_3.Width = 130
        '
        'level_4
        '
        Me.level_4.DataPropertyName = "level_4"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.level_4.DefaultCellStyle = DataGridViewCellStyle4
        Me.level_4.HeaderText = "Level 4"
        Me.level_4.Name = "level_4"
        Me.level_4.ReadOnly = True
        Me.level_4.Width = 130
        '
        'AccessFlag
        '
        Me.AccessFlag.DataPropertyName = "menuflag"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.NullValue = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.AccessFlag.DefaultCellStyle = DataGridViewCellStyle5
        Me.AccessFlag.FalseValue = "0"
        Me.AccessFlag.HeaderText = "Right"
        Me.AccessFlag.Name = "AccessFlag"
        Me.AccessFlag.TrueValue = "1"
        Me.AccessFlag.Width = 50
        '
        'menucode
        '
        Me.menucode.HeaderText = "menucode"
        Me.menucode.Name = "menucode"
        Me.menucode.ReadOnly = True
        Me.menucode.Visible = False
        '
        'btnModify
        '
        Me.btnModify.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModify.Location = New System.Drawing.Point(570, 423)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(55, 55)
        Me.btnModify.TabIndex = 9
        Me.btnModify.Text = "Modify"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(331, 21)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(171, 23)
        Me.ComboBox2.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Same As"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(588, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 19)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "For All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 51)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(718, 365)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(710, 337)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu Access Control"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LemonChiffon
        Me.TabPage2.Controls.Add(Me.dgdFnc)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(710, 337)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Function Access Control"
        '
        'dgdFnc
        '
        Me.dgdFnc.AllowUserToAddRows = False
        Me.dgdFnc.AllowUserToDeleteRows = False
        Me.dgdFnc.AllowUserToResizeColumns = False
        Me.dgdFnc.AllowUserToResizeRows = False
        Me.dgdFnc.BackgroundColor = System.Drawing.Color.LemonChiffon
        Me.dgdFnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdFnc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fnc, Me.FncAccess, Me.fnccode, Me.fnckey})
        Me.dgdFnc.Location = New System.Drawing.Point(3, 3)
        Me.dgdFnc.Name = "dgdFnc"
        Me.dgdFnc.RowHeadersVisible = False
        Me.dgdFnc.RowTemplate.Height = 24
        Me.dgdFnc.Size = New System.Drawing.Size(707, 331)
        Me.dgdFnc.TabIndex = 0
        '
        'Fnc
        '
        Me.Fnc.DataPropertyName = "fidesc"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.Fnc.DefaultCellStyle = DataGridViewCellStyle6
        Me.Fnc.HeaderText = "Function"
        Me.Fnc.Name = "Fnc"
        Me.Fnc.ReadOnly = True
        Me.Fnc.Width = 400
        '
        'FncAccess
        '
        Me.FncAccess.DataPropertyName = "FncRight"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.NullValue = False
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.FncAccess.DefaultCellStyle = DataGridViewCellStyle7
        Me.FncAccess.FalseValue = "0"
        Me.FncAccess.HeaderText = "Right"
        Me.FncAccess.Name = "FncAccess"
        Me.FncAccess.TrueValue = "1"
        Me.FncAccess.Width = 50
        '
        'fnccode
        '
        Me.fnccode.DataPropertyName = "fiobjectcode"
        Me.fnccode.HeaderText = "code"
        Me.fnccode.Name = "fnccode"
        Me.fnccode.Visible = False
        '
        'fnckey
        '
        Me.fnckey.DataPropertyName = "fiobjectkey"
        Me.fnckey.HeaderText = "key"
        Me.fnckey.Name = "fnckey"
        Me.fnckey.Visible = False
        '
        'FrmMenuAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(744, 488)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.KeyPreview = True
        Me.Name = "FrmMenuAccess"
        Me.Text = "Access Control"
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnModify, 0)
        Me.Controls.SetChildIndex(Me.ComboBox2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgdFnc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents level_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents level_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Level_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents level_4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccessFlag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents menucode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgdFnc As System.Windows.Forms.DataGridView
    Friend WithEvents Fnc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FncAccess As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents fnccode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fnckey As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
