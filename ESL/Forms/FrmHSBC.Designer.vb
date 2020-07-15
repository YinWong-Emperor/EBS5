<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHSBC
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHSBC))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tc = New System.Windows.Forms.TabControl()
        Me.tp1 = New System.Windows.Forms.TabPage()
        Me.dtgSList = New System.Windows.Forms.DataGridView()
        Me.tp2 = New System.Windows.Forms.TabPage()
        Me.dtgFList = New System.Windows.Forms.DataGridView()
        Me.btnExport = New ESL.myButton(Me.components)
        Me.btnLoad = New ESL.myButton(Me.components)
        Me.vdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accountno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ccy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cctype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chqdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fdescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tc.SuspendLayout()
        Me.tp1.SuspendLayout()
        CType(Me.dtgSList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp2.SuspendLayout()
        CType(Me.dtgFList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(652, 503)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(484, 503)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(260, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(208, 22)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Convert HSBC to AFE"
        '
        'tc
        '
        Me.tc.Controls.Add(Me.tp1)
        Me.tc.Controls.Add(Me.tp2)
        Me.tc.Location = New System.Drawing.Point(5, 69)
        Me.tc.Name = "tc"
        Me.tc.Padding = New System.Drawing.Point(163, 3)
        Me.tc.SelectedIndex = 0
        Me.tc.Size = New System.Drawing.Size(729, 413)
        Me.tc.TabIndex = 53
        '
        'tp1
        '
        Me.tp1.Controls.Add(Me.dtgSList)
        Me.tp1.Location = New System.Drawing.Point(4, 24)
        Me.tp1.Name = "tp1"
        Me.tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.tp1.Size = New System.Drawing.Size(721, 385)
        Me.tp1.TabIndex = 0
        Me.tp1.Text = "Stock"
        Me.tp1.UseVisualStyleBackColor = True
        '
        'dtgSList
        '
        Me.dtgSList.AllowUserToAddRows = False
        Me.dtgSList.AllowUserToDeleteRows = False
        Me.dtgSList.AllowUserToResizeColumns = False
        Me.dtgSList.AllowUserToResizeRows = False
        Me.dtgSList.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgSList.ColumnHeadersHeight = 22
        Me.dtgSList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vdate, Me.accno, Me.accountno, Me.ccy, Me.amount, Me.cctype, Me.chqdate, Me.description})
        Me.dtgSList.GridColor = System.Drawing.Color.Linen
        Me.dtgSList.Location = New System.Drawing.Point(14, 14)
        Me.dtgSList.MultiSelect = False
        Me.dtgSList.Name = "dtgSList"
        Me.dtgSList.ReadOnly = True
        Me.dtgSList.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgSList.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgSList.RowTemplate.Height = 24
        Me.dtgSList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgSList.Size = New System.Drawing.Size(701, 354)
        Me.dtgSList.TabIndex = 6
        '
        'tp2
        '
        Me.tp2.Controls.Add(Me.dtgFList)
        Me.tp2.Location = New System.Drawing.Point(4, 24)
        Me.tp2.Name = "tp2"
        Me.tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.tp2.Size = New System.Drawing.Size(721, 385)
        Me.tp2.TabIndex = 1
        Me.tp2.Text = "Futures"
        Me.tp2.UseVisualStyleBackColor = True
        '
        'dtgFList
        '
        Me.dtgFList.AllowUserToAddRows = False
        Me.dtgFList.AllowUserToDeleteRows = False
        Me.dtgFList.AllowUserToResizeColumns = False
        Me.dtgFList.AllowUserToResizeRows = False
        Me.dtgFList.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgFList.ColumnHeadersHeight = 22
        Me.dtgFList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.fdescription})
        Me.dtgFList.GridColor = System.Drawing.Color.Linen
        Me.dtgFList.Location = New System.Drawing.Point(3, 14)
        Me.dtgFList.MultiSelect = False
        Me.dtgFList.Name = "dtgFList"
        Me.dtgFList.ReadOnly = True
        Me.dtgFList.RowHeadersVisible = False
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgFList.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dtgFList.RowTemplate.Height = 24
        Me.dtgFList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgFList.Size = New System.Drawing.Size(715, 354)
        Me.dtgFList.TabIndex = 56
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Image = Global.ESL.My.Resources.Resources.export
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExport.Location = New System.Drawing.Point(596, 503)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 55
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLoad.Location = New System.Drawing.Point(540, 503)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(50, 55)
        Me.btnLoad.TabIndex = 53
        Me.btnLoad.Text = "Load"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'vdate
        '
        Me.vdate.DataPropertyName = "Vdate"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vdate.DefaultCellStyle = DataGridViewCellStyle1
        Me.vdate.HeaderText = "Value Date"
        Me.vdate.Name = "vdate"
        Me.vdate.ReadOnly = True
        Me.vdate.Width = 80
        '
        'accno
        '
        Me.accno.DataPropertyName = "Client_type"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.accno.DefaultCellStyle = DataGridViewCellStyle2
        Me.accno.HeaderText = "T Code"
        Me.accno.Name = "accno"
        Me.accno.ReadOnly = True
        Me.accno.Width = 60
        '
        'accountno
        '
        Me.accountno.DataPropertyName = "Accno"
        Me.accountno.HeaderText = "Account No"
        Me.accountno.Name = "accountno"
        Me.accountno.ReadOnly = True
        '
        'ccy
        '
        Me.ccy.DataPropertyName = "Ccy"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ccy.DefaultCellStyle = DataGridViewCellStyle3
        Me.ccy.HeaderText = "CCY"
        Me.ccy.Name = "ccy"
        Me.ccy.ReadOnly = True
        Me.ccy.Width = 40
        '
        'amount
        '
        Me.amount.DataPropertyName = "Amount"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle4.Format = "N2"
        Me.amount.DefaultCellStyle = DataGridViewCellStyle4
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        Me.amount.Width = 120
        '
        'cctype
        '
        Me.cctype.DataPropertyName = "Tran_type"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle5.Format = "N2"
        Me.cctype.DefaultCellStyle = DataGridViewCellStyle5
        Me.cctype.HeaderText = "Type"
        Me.cctype.Name = "cctype"
        Me.cctype.ReadOnly = True
        Me.cctype.Width = 50
        '
        'chqdate
        '
        Me.chqdate.DataPropertyName = "Chqdate"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle6.Format = "N2"
        Me.chqdate.DefaultCellStyle = DataGridViewCellStyle6
        Me.chqdate.HeaderText = "Chq Date"
        Me.chqdate.Name = "chqdate"
        Me.chqdate.ReadOnly = True
        Me.chqdate.Width = 80
        '
        'description
        '
        Me.description.DataPropertyName = "Description"
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        Me.description.Width = 165
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Vdate"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn1.HeaderText = "Value Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Accno"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn2.HeaderText = "Account No"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Ccy"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn3.HeaderText = "CCY"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 40
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Amount"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle11.Format = "N2"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn4.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Tran_type"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle12.Format = "N2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn5.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Chqdate"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle13.Format = "N2"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn6.HeaderText = "Chq Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'fdescription
        '
        Me.fdescription.DataPropertyName = "Description"
        Me.fdescription.HeaderText = "Description"
        Me.fdescription.Name = "fdescription"
        Me.fdescription.ReadOnly = True
        Me.fdescription.Width = 240
        '
        'FrmHSBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(739, 584)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tc)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(755, 622)
        Me.Name = "FrmHSBC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert HSBC"
        Me.Controls.SetChildIndex(Me.tc, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnLoad, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.tc.ResumeLayout(False)
        Me.tp1.ResumeLayout(False)
        CType(Me.dtgSList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp2.ResumeLayout(False)
        CType(Me.dtgFList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tc As System.Windows.Forms.TabControl
    Friend WithEvents tp1 As System.Windows.Forms.TabPage
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents btnLoad As ESL.myButton
    Friend WithEvents tp2 As System.Windows.Forms.TabPage
    Friend WithEvents dtgSList As System.Windows.Forms.DataGridView
    Friend WithEvents dtgFList As System.Windows.Forms.DataGridView
    Friend WithEvents vdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accountno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ccy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cctype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chqdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fdescription As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
