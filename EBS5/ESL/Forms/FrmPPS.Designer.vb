<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPS
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
        Me.txtPath = New ESL.myTextbox
        Me.lblPath = New System.Windows.Forms.Label
        Me.btnPath = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.fdate = New ESL.myDateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Record_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ISN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Input_day = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Input_time = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Transaction_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Transaction_Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Transaction_Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bill_Account = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bill_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Input_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reserved = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Serial_number = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtValue_date = New ESL.myTextbox
        Me.txtMerchant_number = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnImport = New ESL.myButton(Me.components)
        Me.btnExport = New ESL.myButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnorecord = New ESL.myTextbox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(630, 372)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(682, 362)
        Me.btnSave.Size = New System.Drawing.Size(18, 10)
        Me.btnSave.TabIndex = 3
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(116, 389)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(329, 21)
        Me.txtPath.TabIndex = 1
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(65, 389)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(32, 15)
        Me.lblPath.TabIndex = 43
        Me.lblPath.Text = "Path"
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(451, 385)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(28, 27)
        Me.btnPath.TabIndex = 2
        Me.btnPath.Text = "..."
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(234, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 19)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Export PPS text file to Excel file"
        '
        'fdate
        '
        Me.fdate.CustomFormat = "dd MMM yyyy"
        Me.fdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fdate.Location = New System.Drawing.Point(116, 362)
        Me.fdate.Name = "fdate"
        Me.fdate.Size = New System.Drawing.Size(116, 21)
        Me.fdate.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 362)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Date"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Record_id, Me.ISN, Me.Input_day, Me.Input_time, Me.Transaction_code, Me.Transaction_Status, Me.Transaction_Amount, Me.Bill_Account, Me.Bill_Type, Me.Input_date, Me.Reserved, Me.Serial_number})
        Me.DataGridView1.Location = New System.Drawing.Point(25, 90)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(655, 266)
        Me.DataGridView1.TabIndex = 48
        '
        'Record_id
        '
        Me.Record_id.DataPropertyName = "Record_id"
        Me.Record_id.HeaderText = "Record id"
        Me.Record_id.Name = "Record_id"
        Me.Record_id.ReadOnly = True
        '
        'ISN
        '
        Me.ISN.DataPropertyName = "ISN"
        Me.ISN.HeaderText = "ISN"
        Me.ISN.Name = "ISN"
        Me.ISN.ReadOnly = True
        '
        'Input_day
        '
        Me.Input_day.DataPropertyName = "Input_day"
        Me.Input_day.HeaderText = "Input Day"
        Me.Input_day.Name = "Input_day"
        Me.Input_day.ReadOnly = True
        '
        'Input_time
        '
        Me.Input_time.DataPropertyName = "Input_time"
        Me.Input_time.HeaderText = "Input Time"
        Me.Input_time.Name = "Input_time"
        Me.Input_time.ReadOnly = True
        '
        'Transaction_code
        '
        Me.Transaction_code.DataPropertyName = "Transaction_code"
        Me.Transaction_code.HeaderText = "Transaction Code"
        Me.Transaction_code.Name = "Transaction_code"
        Me.Transaction_code.ReadOnly = True
        '
        'Transaction_Status
        '
        Me.Transaction_Status.DataPropertyName = "Transaction_Status"
        Me.Transaction_Status.HeaderText = "Transaction Status"
        Me.Transaction_Status.Name = "Transaction_Status"
        Me.Transaction_Status.ReadOnly = True
        '
        'Transaction_Amount
        '
        Me.Transaction_Amount.DataPropertyName = "Transaction_Amount"
        Me.Transaction_Amount.HeaderText = "Transaction Amount"
        Me.Transaction_Amount.Name = "Transaction_Amount"
        Me.Transaction_Amount.ReadOnly = True
        '
        'Bill_Account
        '
        Me.Bill_Account.DataPropertyName = "Bill_Account"
        Me.Bill_Account.HeaderText = "Bill Account"
        Me.Bill_Account.Name = "Bill_Account"
        Me.Bill_Account.ReadOnly = True
        '
        'Bill_Type
        '
        Me.Bill_Type.DataPropertyName = "Bill_Type"
        Me.Bill_Type.HeaderText = "Bill Type"
        Me.Bill_Type.Name = "Bill_Type"
        Me.Bill_Type.ReadOnly = True
        '
        'Input_date
        '
        Me.Input_date.DataPropertyName = "Input_date"
        Me.Input_date.HeaderText = "Input Date"
        Me.Input_date.Name = "Input_date"
        Me.Input_date.ReadOnly = True
        '
        'Reserved
        '
        Me.Reserved.DataPropertyName = "Reserved"
        Me.Reserved.HeaderText = "Reserved"
        Me.Reserved.Name = "Reserved"
        Me.Reserved.ReadOnly = True
        '
        'Serial_number
        '
        Me.Serial_number.DataPropertyName = "Serial_number"
        Me.Serial_number.HeaderText = "Serial Number"
        Me.Serial_number.Name = "Serial_number"
        Me.Serial_number.ReadOnly = True
        '
        'txtValue_date
        '
        Me.txtValue_date.Enabled = False
        Me.txtValue_date.Location = New System.Drawing.Point(98, 63)
        Me.txtValue_date.Name = "txtValue_date"
        Me.txtValue_date.Size = New System.Drawing.Size(126, 21)
        Me.txtValue_date.TabIndex = 50
        '
        'txtMerchant_number
        '
        Me.txtMerchant_number.Enabled = False
        Me.txtMerchant_number.Location = New System.Drawing.Point(341, 63)
        Me.txtMerchant_number.Name = "txtMerchant_number"
        Me.txtMerchant_number.Size = New System.Drawing.Size(128, 21)
        Me.txtMerchant_number.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Value Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Merchant Number"
        '
        'btnImport
        '
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(518, 373)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(50, 55)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Enabled = False
        Me.btnExport.Location = New System.Drawing.Point(574, 373)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(485, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 15)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Total no. of record"
        '
        'txtnorecord
        '
        Me.txtnorecord.Enabled = False
        Me.txtnorecord.Location = New System.Drawing.Point(611, 63)
        Me.txtnorecord.Name = "txtnorecord"
        Me.txtnorecord.Size = New System.Drawing.Size(69, 21)
        Me.txtnorecord.TabIndex = 55
        '
        'FrmPPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(705, 441)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtnorecord)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMerchant_number)
        Me.Controls.Add(Me.txtValue_date)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.txtPath)
        Me.KeyPreview = True
        Me.Name = "FrmPPS"
        Me.Text = "PPS"
        Me.Controls.SetChildIndex(Me.txtPath, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblPath, 0)
        Me.Controls.SetChildIndex(Me.btnPath, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.fdate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.txtValue_date, 0)
        Me.Controls.SetChildIndex(Me.txtMerchant_number, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnImport, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.txtnorecord, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPath As ESL.myTextbox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents btnPath As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fdate As ESL.myDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtValue_date As ESL.myTextbox
    Friend WithEvents txtMerchant_number As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnImport As ESL.myButton
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents Record_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ISN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Input_day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Input_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transaction_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transaction_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transaction_Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bill_Account As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bill_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Input_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Serial_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnorecord As ESL.myTextbox

End Class
