<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunnerTaxableIncomeMasterSelect
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEnterEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancelEditing = New System.Windows.Forms.Button()
        Me.lblTip = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(555, 406)
        Me.btnCancel.Size = New System.Drawing.Size(54, 55)
        Me.btnCancel.Text = "Exit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(375, 406)
        Me.btnSave.Size = New System.Drawing.Size(54, 55)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMain)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 4, 10, 10)
        Me.GroupBox1.Size = New System.Drawing.Size(598, 376)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.AllowUserToResizeColumns = False
        Me.dgvMain.AllowUserToResizeRows = False
        Me.dgvMain.BackgroundColor = System.Drawing.Color.White
        Me.dgvMain.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDescription, Me.colAmount, Me.colITEM})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMain.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvMain.Location = New System.Drawing.Point(10, 18)
        Me.dgvMain.MultiSelect = False
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.RowHeadersWidth = 25
        Me.dgvMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvMain.RowTemplate.Height = 23
        Me.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMain.Size = New System.Drawing.Size(578, 348)
        Me.dgvMain.TabIndex = 1
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescription.DataPropertyName = "DESCPT"
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "AMOUNT"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Width = 200
        '
        'colITEM
        '
        Me.colITEM.DataPropertyName = "ITEM"
        Me.colITEM.HeaderText = "ITEM"
        Me.colITEM.Name = "colITEM"
        Me.colITEM.ReadOnly = True
        Me.colITEM.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.ESL.My.Resources.Resources.btnDelete_Image
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(495, 406)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(54, 55)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEnterEdit
        '
        Me.btnEnterEdit.Image = Global.ESL.My.Resources.Resources.btnEdit_Image
        Me.btnEnterEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEnterEdit.Location = New System.Drawing.Point(435, 384)
        Me.btnEnterEdit.Name = "btnEnterEdit"
        Me.btnEnterEdit.Size = New System.Drawing.Size(54, 55)
        Me.btnEnterEdit.TabIndex = 8
        Me.btnEnterEdit.Text = "Edit"
        Me.btnEnterEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEnterEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.ESL.My.Resources.Resources.add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.Location = New System.Drawing.Point(375, 384)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(54, 55)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancelEditing
        '
        Me.btnCancelEditing.CausesValidation = False
        Me.btnCancelEditing.Image = Global.ESL.My.Resources.Resources.back
        Me.btnCancelEditing.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelEditing.Location = New System.Drawing.Point(435, 407)
        Me.btnCancelEditing.Name = "btnCancelEditing"
        Me.btnCancelEditing.Size = New System.Drawing.Size(54, 55)
        Me.btnCancelEditing.TabIndex = 8
        Me.btnCancelEditing.Text = "Cancel"
        Me.btnCancelEditing.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelEditing.UseVisualStyleBackColor = True
        '
        'lblTip
        '
        Me.lblTip.ForeColor = System.Drawing.Color.Red
        Me.lblTip.Location = New System.Drawing.Point(19, 407)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Size = New System.Drawing.Size(290, 54)
        Me.lblTip.TabIndex = 9
        Me.lblTip.Text = "The value you are inputing is not a vaild Amount." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Must be a Numer and range bet" & _
    "ween:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 0.00 ~ 99999999999999.99)"
        Me.lblTip.Visible = False
        '
        'FrmRunnerTaxableIncomeMasterSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(624, 474)
        Me.Controls.Add(Me.lblTip)
        Me.Controls.Add(Me.btnCancelEditing)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEnterEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FrmRunnerTaxableIncomeMasterSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "x"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnEnterEdit, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancelEditing, 0)
        Me.Controls.SetChildIndex(Me.lblTip, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEnterEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancelEditing As System.Windows.Forms.Button
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTip As System.Windows.Forms.Label

End Class
