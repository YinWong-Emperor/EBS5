<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommAeCommAdj
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgAdjAmt = New System.Windows.Forms.DataGridView
        Me.cjid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TradeType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.adj_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comboSrchYr = New ESL.myComboBox(Me.components)
        Me.comboSrchMonth = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSrchAE = New ESL.myTextbox
        Me.btnEnquiry = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.txtmonth = New ESL.myTextbox
        Me.comboAE = New ESL.myComboBox(Me.components)
        Me.txtAmt = New ESL.myAmountBox
        Me.txtReason = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAEname = New ESL.myTextbox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchFut = New ESL.myRadioButton(Me.components)
        Me.rbSrchSec = New ESL.myRadioButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbFut = New ESL.myRadioButton(Me.components)
        Me.rbSec = New ESL.myRadioButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dtgAdjAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(577, 373)
        Me.btnCancel.TabIndex = 14
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(526, 373)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Visible = True
        '
        'dtgAdjAmt
        '
        Me.dtgAdjAmt.AllowUserToAddRows = False
        Me.dtgAdjAmt.AllowUserToDeleteRows = False
        Me.dtgAdjAmt.AllowUserToResizeRows = False
        Me.dtgAdjAmt.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgAdjAmt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgAdjAmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAdjAmt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cjid, Me.txmonth, Me.ae_no, Me.ae_name, Me.TradeType, Me.adj_amt, Me.reason})
        Me.dtgAdjAmt.Location = New System.Drawing.Point(12, 35)
        Me.dtgAdjAmt.MultiSelect = False
        Me.dtgAdjAmt.Name = "dtgAdjAmt"
        Me.dtgAdjAmt.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgAdjAmt.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgAdjAmt.RowHeadersVisible = False
        Me.dtgAdjAmt.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgAdjAmt.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgAdjAmt.RowTemplate.Height = 24
        Me.dtgAdjAmt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAdjAmt.Size = New System.Drawing.Size(627, 220)
        Me.dtgAdjAmt.TabIndex = 5
        '
        'cjid
        '
        Me.cjid.DataPropertyName = "cjid"
        Me.cjid.HeaderText = "cjid"
        Me.cjid.Name = "cjid"
        Me.cjid.ReadOnly = True
        Me.cjid.Visible = False
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "txmonth"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        Me.txmonth.Visible = False
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.Width = 80
        '
        'ae_name
        '
        Me.ae_name.DataPropertyName = "ae_name"
        Me.ae_name.HeaderText = "Name"
        Me.ae_name.Name = "ae_name"
        Me.ae_name.ReadOnly = True
        Me.ae_name.Width = 160
        '
        'TradeType
        '
        Me.TradeType.DataPropertyName = "SecFut"
        Me.TradeType.HeaderText = "Trade"
        Me.TradeType.Name = "TradeType"
        Me.TradeType.ReadOnly = True
        Me.TradeType.Width = 70
        '
        'adj_amt
        '
        Me.adj_amt.DataPropertyName = "adj_amt"
        Me.adj_amt.HeaderText = "Adjust Amount"
        Me.adj_amt.Name = "adj_amt"
        Me.adj_amt.ReadOnly = True
        Me.adj_amt.Width = 130
        '
        'reason
        '
        Me.reason.DataPropertyName = "reason"
        Me.reason.HeaderText = "Reason"
        Me.reason.Name = "reason"
        Me.reason.ReadOnly = True
        Me.reason.Width = 180
        '
        'comboSrchYr
        '
        Me.comboSrchYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrchYr.FormattingEnabled = True
        Me.comboSrchYr.Location = New System.Drawing.Point(72, 6)
        Me.comboSrchYr.Name = "comboSrchYr"
        Me.comboSrchYr.Size = New System.Drawing.Size(66, 23)
        Me.comboSrchYr.TabIndex = 0
        '
        'comboSrchMonth
        '
        Me.comboSrchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrchMonth.FormattingEnabled = True
        Me.comboSrchMonth.Location = New System.Drawing.Point(144, 6)
        Me.comboSrchMonth.Name = "comboSrchMonth"
        Me.comboSrchMonth.Size = New System.Drawing.Size(51, 23)
        Me.comboSrchMonth.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "txmonth"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "AE"
        '
        'txtSrchAE
        '
        Me.txtSrchAE.Location = New System.Drawing.Point(229, 6)
        Me.txtSrchAE.Name = "txtSrchAE"
        Me.txtSrchAE.Size = New System.Drawing.Size(100, 21)
        Me.txtSrchAE.TabIndex = 2
        '
        'btnEnquiry
        '
        Me.btnEnquiry.Location = New System.Drawing.Point(551, 4)
        Me.btnEnquiry.Name = "btnEnquiry"
        Me.btnEnquiry.Size = New System.Drawing.Size(88, 25)
        Me.btnEnquiry.TabIndex = 4
        Me.btnEnquiry.Text = "Enquiry"
        Me.btnEnquiry.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(470, 373)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(368, 373)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 10
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(419, 373)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Adjust"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'txtmonth
        '
        Me.txtmonth.Location = New System.Drawing.Point(529, 264)
        Me.txtmonth.Name = "txtmonth"
        Me.txtmonth.Size = New System.Drawing.Size(98, 21)
        Me.txtmonth.TabIndex = 21
        '
        'comboAE
        '
        Me.comboAE.FormattingEnabled = True
        Me.comboAE.Location = New System.Drawing.Point(119, 264)
        Me.comboAE.Name = "comboAE"
        Me.comboAE.Size = New System.Drawing.Size(119, 23)
        Me.comboAE.TabIndex = 6
        '
        'txtAmt
        '
        Me.txtAmt.DecimalPoints = 2
        Me.txtAmt.Location = New System.Drawing.Point(119, 321)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(119, 21)
        Me.txtAmt.TabIndex = 8
        Me.txtAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(119, 345)
        Me.txtReason.MaxLength = 100
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(508, 21)
        Me.txtReason.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "AE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 324)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Adjust Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 348)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Reason"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(473, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "txmonth"
        '
        'txtAEname
        '
        Me.txtAEname.Location = New System.Drawing.Point(244, 264)
        Me.txtAEname.Name = "txtAEname"
        Me.txtAEname.Size = New System.Drawing.Size(223, 21)
        Me.txtAEname.TabIndex = 29
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchFut)
        Me.GroupBox1.Controls.Add(Me.rbSrchSec)
        Me.GroupBox1.Location = New System.Drawing.Point(335, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(169, 35)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'rbSrchFut
        '
        Me.rbSrchFut.AutoSize = True
        Me.rbSrchFut.Location = New System.Drawing.Point(93, 11)
        Me.rbSrchFut.Name = "rbSrchFut"
        Me.rbSrchFut.Size = New System.Drawing.Size(67, 19)
        Me.rbSrchFut.TabIndex = 1
        Me.rbSrchFut.TabStop = True
        Me.rbSrchFut.Text = "Futures"
        Me.rbSrchFut.UseVisualStyleBackColor = True
        '
        'rbSrchSec
        '
        Me.rbSrchSec.AutoSize = True
        Me.rbSrchSec.Location = New System.Drawing.Point(6, 11)
        Me.rbSrchSec.Name = "rbSrchSec"
        Me.rbSrchSec.Size = New System.Drawing.Size(80, 19)
        Me.rbSrchSec.TabIndex = 0
        Me.rbSrchSec.TabStop = True
        Me.rbSrchSec.Text = "Securities"
        Me.rbSrchSec.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFut)
        Me.GroupBox2.Controls.Add(Me.rbSec)
        Me.GroupBox2.Location = New System.Drawing.Point(119, 283)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(169, 35)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'rbFut
        '
        Me.rbFut.AutoSize = True
        Me.rbFut.Location = New System.Drawing.Point(93, 11)
        Me.rbFut.Name = "rbFut"
        Me.rbFut.Size = New System.Drawing.Size(67, 19)
        Me.rbFut.TabIndex = 1
        Me.rbFut.TabStop = True
        Me.rbFut.Text = "Futures"
        Me.rbFut.UseVisualStyleBackColor = True
        '
        'rbSec
        '
        Me.rbSec.AutoSize = True
        Me.rbSec.Location = New System.Drawing.Point(6, 12)
        Me.rbSec.Name = "rbSec"
        Me.rbSec.Size = New System.Drawing.Size(80, 19)
        Me.rbSec.TabIndex = 0
        Me.rbSec.TabStop = True
        Me.rbSec.Text = "Securities"
        Me.rbSec.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 291)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 15)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Trade Type"
        '
        'FrmCommAeCommAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(645, 431)
        Me.Controls.Add(Me.txtAEname)
        Me.Controls.Add(Me.comboAE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.txtAmt)
        Me.Controls.Add(Me.txtmonth)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnEnquiry)
        Me.Controls.Add(Me.txtSrchAE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboSrchMonth)
        Me.Controls.Add(Me.comboSrchYr)
        Me.Controls.Add(Me.dtgAdjAmt)
        Me.KeyPreview = True
        Me.Name = "FrmCommAeCommAdj"
        Me.Text = "AE Commission Adjustment"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.dtgAdjAmt, 0)
        Me.Controls.SetChildIndex(Me.comboSrchYr, 0)
        Me.Controls.SetChildIndex(Me.comboSrchMonth, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtSrchAE, 0)
        Me.Controls.SetChildIndex(Me.btnEnquiry, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.txtmonth, 0)
        Me.Controls.SetChildIndex(Me.txtAmt, 0)
        Me.Controls.SetChildIndex(Me.txtReason, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.comboAE, 0)
        Me.Controls.SetChildIndex(Me.txtAEname, 0)
        CType(Me.dtgAdjAmt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgAdjAmt As System.Windows.Forms.DataGridView
    Friend WithEvents comboSrchYr As ESL.myComboBox
    Friend WithEvents comboSrchMonth As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSrchAE As ESL.myTextbox
    Friend WithEvents btnEnquiry As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents txtmonth As ESL.myTextbox
    Friend WithEvents comboAE As ESL.myComboBox
    Friend WithEvents txtAmt As ESL.myAmountBox
    Friend WithEvents txtReason As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAEname As ESL.myTextbox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchSec As ESL.myRadioButton
    Friend WithEvents rbSrchFut As ESL.myRadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFut As ESL.myRadioButton
    Friend WithEvents rbSec As ESL.myRadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cjid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TradeType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents adj_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reason As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
