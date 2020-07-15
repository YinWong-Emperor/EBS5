<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewedgeCommDiff
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbxCounterParty = New System.Windows.Forms.ComboBox
        Me.dtgProduct = New System.Windows.Forms.DataGridView
        Me.monthcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cal_comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cal_clearing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cal_levy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cap_comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cap_clearing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cap_levy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DtDate = New ESL.myDateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.Label7 = New System.Windows.Forms.Label
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(526, 408)
        Me.btnCancel.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(474, 408)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxCounterParty)
        Me.GroupBox1.Controls.Add(Me.dtgProduct)
        Me.GroupBox1.Controls.Add(Me.DtDate)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 266)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbxCounterParty
        '
        Me.cbxCounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounterParty.FormattingEnabled = True
        Me.cbxCounterParty.Location = New System.Drawing.Point(127, 18)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(115, 23)
        Me.cbxCounterParty.TabIndex = 29
        '
        'dtgProduct
        '
        Me.dtgProduct.AllowUserToAddRows = False
        Me.dtgProduct.AllowUserToDeleteRows = False
        Me.dtgProduct.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.monthcode, Me.product, Me.cal_comm, Me.cal_clearing, Me.cal_levy, Me.cap_comm, Me.cap_clearing, Me.cap_levy})
        Me.dtgProduct.Location = New System.Drawing.Point(6, 47)
        Me.dtgProduct.Name = "dtgProduct"
        Me.dtgProduct.ReadOnly = True
        Me.dtgProduct.RowHeadersVisible = False
        Me.dtgProduct.RowTemplate.Height = 24
        Me.dtgProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgProduct.Size = New System.Drawing.Size(536, 208)
        Me.dtgProduct.TabIndex = 1
        '
        'monthcode
        '
        Me.monthcode.DataPropertyName = "monthcode"
        Me.monthcode.HeaderText = "Month Code"
        Me.monthcode.Name = "monthcode"
        Me.monthcode.ReadOnly = True
        '
        'product
        '
        Me.product.DataPropertyName = "product"
        Me.product.HeaderText = "Product"
        Me.product.Name = "product"
        Me.product.ReadOnly = True
        '
        'cal_comm
        '
        Me.cal_comm.DataPropertyName = "cal_comm"
        Me.cal_comm.HeaderText = "Cal Comm"
        Me.cal_comm.Name = "cal_comm"
        Me.cal_comm.ReadOnly = True
        '
        'cal_clearing
        '
        Me.cal_clearing.DataPropertyName = "cal_clearing"
        Me.cal_clearing.HeaderText = "Cal Clearing"
        Me.cal_clearing.Name = "cal_clearing"
        Me.cal_clearing.ReadOnly = True
        '
        'cal_levy
        '
        Me.cal_levy.DataPropertyName = "cal_levy"
        Me.cal_levy.HeaderText = "Cal Levy"
        Me.cal_levy.Name = "cal_levy"
        Me.cal_levy.ReadOnly = True
        '
        'cap_comm
        '
        Me.cap_comm.DataPropertyName = "cap_comm"
        Me.cap_comm.HeaderText = "Cap Comm"
        Me.cap_comm.Name = "cap_comm"
        Me.cap_comm.ReadOnly = True
        '
        'cap_clearing
        '
        Me.cap_clearing.DataPropertyName = "cap_clearing"
        Me.cap_clearing.HeaderText = "Cap Clearing"
        Me.cap_clearing.Name = "cap_clearing"
        Me.cap_clearing.ReadOnly = True
        '
        'cap_levy
        '
        Me.cap_levy.DataPropertyName = "cap_levy"
        Me.cap_levy.HeaderText = "Cap Levy"
        Me.cap_levy.Name = "cap_levy"
        Me.cap_levy.ReadOnly = True
        '
        'DtDate
        '
        Me.DtDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate.Location = New System.Drawing.Point(6, 20)
        Me.DtDate.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.DtDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtDate.Name = "DtDate"
        Me.DtDate.Size = New System.Drawing.Size(115, 21)
        Me.DtDate.TabIndex = 0
        Me.DtDate.Value = New Date(2008, 9, 22, 0, 0, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 333)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(549, 68)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(181, 30)
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
        Me.RBPreview.Location = New System.Drawing.Point(69, 30)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(24, 405)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 28
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(27, 423)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(409, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(370, 22)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Futures Commission Difference Report"
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'FrmNewedgeCommDiff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(606, 507)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.Label7)
        Me.KeyPreview = True
        Me.Name = "FrmNewedgeCommDiff"
        Me.Text = "Futures Commission Difference Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dtgProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtgProduct As System.Windows.Forms.DataGridView
    Friend WithEvents DtDate As ESL.myDateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents monthcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cal_comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cal_clearing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cal_levy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cap_comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cap_clearing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cap_levy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents cbxCounterParty As System.Windows.Forms.ComboBox

End Class
