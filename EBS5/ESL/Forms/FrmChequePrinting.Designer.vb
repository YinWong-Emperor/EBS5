<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChequePrinting
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChequePrinting))
        Me.dtpTxnDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.dgvClientCheque = New System.Windows.Forms.DataGridView()
        Me.Sequence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSort = New ESL.myButton(Me.components)
        Me.btnDetails = New ESL.myButton(Me.components)
        Me.btnPrint = New ESL.myButton(Me.components)
        CType(Me.dgvClientCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(516, 432)
        Me.btnCancel.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(461, 432)
        '
        'dtpTxnDate
        '
        Me.dtpTxnDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpTxnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTxnDate.Location = New System.Drawing.Point(85, 25)
        Me.dtpTxnDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpTxnDate.Name = "dtpTxnDate"
        Me.dtpTxnDate.Size = New System.Drawing.Size(233, 21)
        Me.dtpTxnDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Txn. Date"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(340, 21)
        Me.btnPrev.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(33, 29)
        Me.btnPrev.TabIndex = 2
        Me.btnPrev.Text = "<"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(379, 21)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(33, 29)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'dgvClientCheque
        '
        Me.dgvClientCheque.AllowUserToAddRows = False
        Me.dgvClientCheque.AllowUserToDeleteRows = False
        Me.dgvClientCheque.AllowUserToResizeRows = False
        Me.dgvClientCheque.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvClientCheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientCheque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sequence, Me.ClientCode, Me.TxnDate, Me.Amount, Me.CName})
        Me.dgvClientCheque.Location = New System.Drawing.Point(12, 79)
        Me.dgvClientCheque.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvClientCheque.Name = "dgvClientCheque"
        Me.dgvClientCheque.ReadOnly = True
        Me.dgvClientCheque.RowHeadersVisible = False
        Me.dgvClientCheque.RowTemplate.Height = 23
        Me.dgvClientCheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientCheque.Size = New System.Drawing.Size(555, 340)
        Me.dgvClientCheque.TabIndex = 4
        '
        'Sequence
        '
        Me.Sequence.DataPropertyName = "sequence"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Sequence.DefaultCellStyle = DataGridViewCellStyle1
        Me.Sequence.HeaderText = "Sequence"
        Me.Sequence.Name = "Sequence"
        Me.Sequence.ReadOnly = True
        Me.Sequence.Width = 80
        '
        'ClientCode
        '
        Me.ClientCode.DataPropertyName = "client_code"
        Me.ClientCode.HeaderText = "Client Code"
        Me.ClientCode.Name = "ClientCode"
        Me.ClientCode.ReadOnly = True
        '
        'TxnDate
        '
        Me.TxnDate.DataPropertyName = "txn_date"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TxnDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxnDate.HeaderText = "Txn. Date"
        Me.TxnDate.Name = "TxnDate"
        Me.TxnDate.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "amount"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle3
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'CName
        '
        Me.CName.DataPropertyName = "name"
        Me.CName.HeaderText = "Name"
        Me.CName.Name = "CName"
        Me.CName.ReadOnly = True
        Me.CName.Width = 150
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.ESL.My.Resources.Resources.btnDelete_Image
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(296, 432)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(49, 55)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = Global.ESL.My.Resources.Resources.btnNew_Image
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(188, 432)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(49, 55)
        Me.btnNew.TabIndex = 10
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = Global.ESL.My.Resources.Resources.btnEdit_Image
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(242, 432)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(49, 55)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpTxnDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnPrev)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 60)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'btnSort
        '
        Me.btnSort.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSort.Image = CType(resources.GetObject("btnSort.Image"), System.Drawing.Image)
        Me.btnSort.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSort.Location = New System.Drawing.Point(408, 432)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(49, 55)
        Me.btnSort.TabIndex = 14
        Me.btnSort.Text = "Sort"
        Me.btnSort.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'btnDetails
        '
        Me.btnDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetails.Image = CType(resources.GetObject("btnDetails.Image"), System.Drawing.Image)
        Me.btnDetails.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDetails.Location = New System.Drawing.Point(352, 432)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(49, 55)
        Me.btnDetails.TabIndex = 13
        Me.btnDetails.Text = "Details"
        Me.btnDetails.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDetails.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(461, 432)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(49, 55)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmChequePrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 500)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDetails)
        Me.Controls.Add(Me.btnSort)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.dgvClientCheque)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmChequePrinting"
        Me.Text = "Cheque Printing"
        Me.Controls.SetChildIndex(Me.dgvClientCheque, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnSort, 0)
        Me.Controls.SetChildIndex(Me.btnDetails, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        CType(Me.dgvClientCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpTxnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents dgvClientCheque As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSort As ESL.myButton
    Friend WithEvents btnDetails As ESL.myButton
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents Sequence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
