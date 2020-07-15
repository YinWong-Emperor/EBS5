<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDayBegin
    Inherits ESL.frmBaseSrh

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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MyTextbox4 = New ESL.myTextbox
        Me.MyTextbox5 = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.MyTextbox6 = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.MyTextbox1 = New ESL.myTextbox
        Me.MyTextbox2 = New ESL.myTextbox
        Me.MyMaskedTextBox1 = New ESL.myMaskedTextBox
        Me.MyMaskedTextBox2 = New ESL.myMaskedTextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.date_cancel = New System.Windows.Forms.Button
        Me.date_ok = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblTDate = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Currency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valuedate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vdatestr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Enabled = False
        Me.btnClose.Location = New System.Drawing.Point(236, 334)
        Me.btnClose.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(146, 334)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Trade Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cut Date "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MyTextbox4)
        Me.GroupBox1.Controls.Add(Me.MyTextbox5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.MyTextbox6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 149)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Previous"
        '
        'MyTextbox4
        '
        Me.MyTextbox4.Enabled = False
        Me.MyTextbox4.ForeColor = System.Drawing.Color.Red
        Me.MyTextbox4.Location = New System.Drawing.Point(115, 106)
        Me.MyTextbox4.Name = "MyTextbox4"
        Me.MyTextbox4.Size = New System.Drawing.Size(244, 21)
        Me.MyTextbox4.TabIndex = 2
        '
        'MyTextbox5
        '
        Me.MyTextbox5.Enabled = False
        Me.MyTextbox5.ForeColor = System.Drawing.Color.Red
        Me.MyTextbox5.Location = New System.Drawing.Point(115, 65)
        Me.MyTextbox5.Name = "MyTextbox5"
        Me.MyTextbox5.Size = New System.Drawing.Size(244, 21)
        Me.MyTextbox5.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Interest Date  "
        '
        'MyTextbox6
        '
        Me.MyTextbox6.Enabled = False
        Me.MyTextbox6.ForeColor = System.Drawing.Color.Red
        Me.MyTextbox6.Location = New System.Drawing.Point(114, 20)
        Me.MyTextbox6.Name = "MyTextbox6"
        Me.MyTextbox6.Size = New System.Drawing.Size(244, 21)
        Me.MyTextbox6.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Trade Date "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Interest (Y/N)  "
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"N", "Y"})
        Me.ComboBox1.Location = New System.Drawing.Point(134, 221)
        Me.ComboBox1.MaxLength = 1
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(38, 23)
        Me.ComboBox1.TabIndex = 5
        '
        'MyTextbox1
        '
        Me.MyTextbox1.Enabled = False
        Me.MyTextbox1.ForeColor = System.Drawing.Color.Red
        Me.MyTextbox1.Location = New System.Drawing.Point(220, 183)
        Me.MyTextbox1.Name = "MyTextbox1"
        Me.MyTextbox1.Size = New System.Drawing.Size(153, 21)
        Me.MyTextbox1.TabIndex = 1
        '
        'MyTextbox2
        '
        Me.MyTextbox2.Enabled = False
        Me.MyTextbox2.ForeColor = System.Drawing.Color.Red
        Me.MyTextbox2.Location = New System.Drawing.Point(220, 256)
        Me.MyTextbox2.Name = "MyTextbox2"
        Me.MyTextbox2.Size = New System.Drawing.Size(153, 21)
        Me.MyTextbox2.TabIndex = 3
        '
        'MyMaskedTextBox1
        '
        Me.MyMaskedTextBox1.Location = New System.Drawing.Point(133, 184)
        Me.MyMaskedTextBox1.Mask = "00/00/0000"
        Me.MyMaskedTextBox1.Name = "MyMaskedTextBox1"
        Me.MyMaskedTextBox1.Size = New System.Drawing.Size(81, 21)
        Me.MyMaskedTextBox1.TabIndex = 1
        '
        'MyMaskedTextBox2
        '
        Me.MyMaskedTextBox2.Location = New System.Drawing.Point(133, 256)
        Me.MyMaskedTextBox2.Mask = "00/00/0000"
        Me.MyMaskedTextBox2.Name = "MyMaskedTextBox2"
        Me.MyMaskedTextBox2.Size = New System.Drawing.Size(81, 21)
        Me.MyMaskedTextBox2.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.ItemSize = New System.Drawing.Size(80, 20)
        Me.TabControl1.Location = New System.Drawing.Point(2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(445, 354)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TabPage1.Controls.Add(Me.date_cancel)
        Me.TabPage1.Controls.Add(Me.date_ok)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.MyMaskedTextBox2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.MyMaskedTextBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.MyTextbox2)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.MyTextbox1)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(437, 326)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Day Begin"
        '
        'date_cancel
        '
        Me.date_cancel.Location = New System.Drawing.Point(222, 293)
        Me.date_cancel.Name = "date_cancel"
        Me.date_cancel.Size = New System.Drawing.Size(75, 23)
        Me.date_cancel.TabIndex = 4
        Me.date_cancel.Text = "Cancel"
        Me.date_cancel.UseVisualStyleBackColor = True
        '
        'date_ok
        '
        Me.date_ok.Location = New System.Drawing.Point(134, 293)
        Me.date_ok.Name = "date_ok"
        Me.date_ok.Size = New System.Drawing.Size(75, 23)
        Me.date_ok.TabIndex = 3
        Me.date_ok.Text = "Ok"
        Me.date_ok.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LemonChiffon
        Me.TabPage2.Controls.Add(Me.btnBack)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Controls.Add(Me.lblTDate)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(437, 326)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Currency"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(340, 296)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(252, 296)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblTDate
        '
        Me.lblTDate.AutoSize = True
        Me.lblTDate.ForeColor = System.Drawing.Color.Red
        Me.lblTDate.Location = New System.Drawing.Point(90, 6)
        Me.lblTDate.Name = "lblTDate"
        Me.lblTDate.Size = New System.Drawing.Size(45, 15)
        Me.lblTDate.TabIndex = 1
        Me.lblTDate.Text = "Label6"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LemonChiffon
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Currency, Me.valuedate, Me.vdatestr})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridView1.Location = New System.Drawing.Point(17, 23)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(403, 269)
        Me.DataGridView1.TabIndex = 2
        '
        'Currency
        '
        Me.Currency.DataPropertyName = "d_currency"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.Currency.DefaultCellStyle = DataGridViewCellStyle8
        Me.Currency.Frozen = True
        Me.Currency.HeaderText = "Currency"
        Me.Currency.Name = "Currency"
        Me.Currency.ReadOnly = True
        Me.Currency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'valuedate
        '
        Me.valuedate.DataPropertyName = "d_vdate"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.valuedate.DefaultCellStyle = DataGridViewCellStyle9
        Me.valuedate.Frozen = True
        Me.valuedate.HeaderText = "Value Date"
        Me.valuedate.MaxInputLength = 10
        Me.valuedate.Name = "valuedate"
        Me.valuedate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'vdatestr
        '
        Me.vdatestr.DataPropertyName = "d_vdate_str"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.vdatestr.DefaultCellStyle = DataGridViewCellStyle10
        Me.vdatestr.HeaderText = ""
        Me.vdatestr.Name = "vdatestr"
        Me.vdatestr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vdatestr.Width = 150
        '
        'FrmDayBegin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(448, 365)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.Name = "FrmDayBegin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Day Begin"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MyTextbox4 As ESL.myTextbox
    Friend WithEvents MyTextbox5 As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MyTextbox6 As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents MyTextbox1 As ESL.myTextbox
    Friend WithEvents MyTextbox2 As ESL.myTextbox
    Friend WithEvents MyMaskedTextBox1 As ESL.myMaskedTextBox
    Friend WithEvents MyMaskedTextBox2 As ESL.myMaskedTextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents date_cancel As System.Windows.Forms.Button
    Friend WithEvents date_ok As System.Windows.Forms.Button
    Friend WithEvents lblTDate As System.Windows.Forms.Label
    Friend WithEvents Currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valuedate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vdatestr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button

End Class
