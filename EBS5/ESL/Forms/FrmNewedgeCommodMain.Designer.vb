<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewedgeCommodMain
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgCommod = New System.Windows.Forms.DataGridView
        Me.cdid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ric_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.commodity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.floor_comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.floor_clearing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.floor_levy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.electronic_comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.electronic_clearing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.electronic_levy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nbclearinge = New ESL.myNumericBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.nbClearingf = New ESL.myNumericBox
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.nblevye = New ESL.myNumericBox
        Me.nbcomme = New ESL.myNumericBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.nblevyf = New ESL.myNumericBox
        Me.txtcommod = New ESL.myTextbox
        Me.txtriccode = New ESL.myTextbox
        Me.nbcommf = New ESL.myNumericBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnReset = New ESL.myButton(Me.components)
        CType(Me.dtgCommod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(523, 391)
        Me.btnCancel.TabIndex = 14
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(411, 391)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Visible = True
        '
        'dtgCommod
        '
        Me.dtgCommod.AllowUserToAddRows = False
        Me.dtgCommod.AllowUserToDeleteRows = False
        Me.dtgCommod.AllowUserToResizeRows = False
        Me.dtgCommod.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgCommod.ColumnHeadersHeight = 40
        Me.dtgCommod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cdid, Me.ric_code, Me.commodity, Me.floor_comm, Me.floor_clearing, Me.floor_levy, Me.electronic_comm, Me.electronic_clearing, Me.electronic_levy})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgCommod.DefaultCellStyle = DataGridViewCellStyle15
        Me.dtgCommod.Location = New System.Drawing.Point(17, 60)
        Me.dtgCommod.MultiSelect = False
        Me.dtgCommod.Name = "dtgCommod"
        Me.dtgCommod.ReadOnly = True
        Me.dtgCommod.RowHeadersVisible = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        Me.dtgCommod.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dtgCommod.RowTemplate.Height = 24
        Me.dtgCommod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgCommod.Size = New System.Drawing.Size(556, 216)
        Me.dtgCommod.TabIndex = 0
        '
        'cdid
        '
        Me.cdid.DataPropertyName = "cdid"
        Me.cdid.HeaderText = "CdID"
        Me.cdid.Name = "cdid"
        Me.cdid.ReadOnly = True
        Me.cdid.Visible = False
        Me.cdid.Width = 50
        '
        'ric_code
        '
        Me.ric_code.DataPropertyName = "ric_code"
        Me.ric_code.HeaderText = "RIC Code"
        Me.ric_code.Name = "ric_code"
        Me.ric_code.ReadOnly = True
        Me.ric_code.Width = 48
        '
        'commodity
        '
        Me.commodity.DataPropertyName = "commodity"
        Me.commodity.HeaderText = "Commodity"
        Me.commodity.Name = "commodity"
        Me.commodity.ReadOnly = True
        Me.commodity.Width = 128
        '
        'floor_comm
        '
        Me.floor_comm.DataPropertyName = "floor_comm"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.floor_comm.DefaultCellStyle = DataGridViewCellStyle9
        Me.floor_comm.HeaderText = "Comm (Floor)"
        Me.floor_comm.Name = "floor_comm"
        Me.floor_comm.ReadOnly = True
        Me.floor_comm.Width = 60
        '
        'floor_clearing
        '
        Me.floor_clearing.DataPropertyName = "floor_clearing"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.floor_clearing.DefaultCellStyle = DataGridViewCellStyle10
        Me.floor_clearing.HeaderText = "Clearing (Floor)"
        Me.floor_clearing.Name = "floor_clearing"
        Me.floor_clearing.ReadOnly = True
        Me.floor_clearing.Width = 60
        '
        'floor_levy
        '
        Me.floor_levy.DataPropertyName = "floor_levy"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.floor_levy.DefaultCellStyle = DataGridViewCellStyle11
        Me.floor_levy.HeaderText = "Levy (Floor)"
        Me.floor_levy.Name = "floor_levy"
        Me.floor_levy.ReadOnly = True
        Me.floor_levy.Width = 60
        '
        'electronic_comm
        '
        Me.electronic_comm.DataPropertyName = "electronic_comm"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.electronic_comm.DefaultCellStyle = DataGridViewCellStyle12
        Me.electronic_comm.HeaderText = "Comm (Electronic)"
        Me.electronic_comm.Name = "electronic_comm"
        Me.electronic_comm.ReadOnly = True
        Me.electronic_comm.Width = 60
        '
        'electronic_clearing
        '
        Me.electronic_clearing.DataPropertyName = "electronic_clearing"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.electronic_clearing.DefaultCellStyle = DataGridViewCellStyle13
        Me.electronic_clearing.HeaderText = "Clearing (Electronic)"
        Me.electronic_clearing.Name = "electronic_clearing"
        Me.electronic_clearing.ReadOnly = True
        Me.electronic_clearing.Width = 60
        '
        'electronic_levy
        '
        Me.electronic_levy.DataPropertyName = "electronic_levy"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.electronic_levy.DefaultCellStyle = DataGridViewCellStyle14
        Me.electronic_levy.HeaderText = "Levy (Electronic)"
        Me.electronic_levy.Name = "electronic_levy"
        Me.electronic_levy.ReadOnly = True
        Me.electronic_levy.Width = 60
        '
        'nbclearinge
        '
        Me.nbclearinge.Enabled = False
        Me.nbclearinge.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbclearinge.Location = New System.Drawing.Point(393, 334)
        Me.nbclearinge.Name = "nbclearinge"
        Me.nbclearinge.Size = New System.Drawing.Size(122, 20)
        Me.nbclearinge.TabIndex = 7
        Me.nbclearinge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(265, 337)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 14)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Clearing (Electronic)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 363)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 14)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Levy (Floor)"
        '
        'nbClearingf
        '
        Me.nbClearingf.Enabled = False
        Me.nbClearingf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbClearingf.Location = New System.Drawing.Point(119, 334)
        Me.nbClearingf.Name = "nbClearingf"
        Me.nbClearingf.Size = New System.Drawing.Size(122, 20)
        Me.nbClearingf.TabIndex = 4
        Me.nbClearingf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(299, 391)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(243, 391)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 9
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(265, 363)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Levy (Electronic)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 337)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Clearing (Floor)"
        '
        'nblevye
        '
        Me.nblevye.Enabled = False
        Me.nblevye.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nblevye.Location = New System.Drawing.Point(393, 360)
        Me.nblevye.Name = "nblevye"
        Me.nblevye.Size = New System.Drawing.Size(122, 20)
        Me.nblevye.TabIndex = 8
        Me.nblevye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbcomme
        '
        Me.nbcomme.Enabled = False
        Me.nbcomme.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbcomme.Location = New System.Drawing.Point(393, 308)
        Me.nbcomme.Name = "nbcomme"
        Me.nbcomme.Size = New System.Drawing.Size(122, 20)
        Me.nbcomme.TabIndex = 6
        Me.nbcomme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(265, 311)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Commission (Electronic)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 311)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Commission (Floor)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(265, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Commodity"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 285)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ric Code"
        '
        'nblevyf
        '
        Me.nblevyf.Enabled = False
        Me.nblevyf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nblevyf.Location = New System.Drawing.Point(119, 360)
        Me.nblevyf.Name = "nblevyf"
        Me.nblevyf.Size = New System.Drawing.Size(122, 20)
        Me.nblevyf.TabIndex = 5
        Me.nblevyf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcommod
        '
        Me.txtcommod.Enabled = False
        Me.txtcommod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcommod.Location = New System.Drawing.Point(330, 282)
        Me.txtcommod.Name = "txtcommod"
        Me.txtcommod.Size = New System.Drawing.Size(243, 20)
        Me.txtcommod.TabIndex = 2
        '
        'txtriccode
        '
        Me.txtriccode.Enabled = False
        Me.txtriccode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtriccode.Location = New System.Drawing.Point(119, 282)
        Me.txtriccode.Name = "txtriccode"
        Me.txtriccode.Size = New System.Drawing.Size(122, 20)
        Me.txtriccode.TabIndex = 1
        '
        'nbcommf
        '
        Me.nbcommf.Enabled = False
        Me.nbcommf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbcommf.Location = New System.Drawing.Point(119, 308)
        Me.nbcommf.Name = "nbcommf"
        Me.nbcommf.Size = New System.Drawing.Size(122, 20)
        Me.nbcommf.TabIndex = 3
        Me.nbcommf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(262, 22)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Futures Commodity Master"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(355, 391)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(467, 390)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(50, 55)
        Me.btnReset.TabIndex = 13
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'FrmNewedgeCommodMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(591, 476)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.dtgCommod)
        Me.Controls.Add(Me.nbclearinge)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nbClearingf)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.nbcommf)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtriccode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcommod)
        Me.Controls.Add(Me.nblevye)
        Me.Controls.Add(Me.nblevyf)
        Me.Controls.Add(Me.nbcomme)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.KeyPreview = True
        Me.Name = "FrmNewedgeCommodMain"
        Me.Text = "Futures Commodity Master"
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.nbcomme, 0)
        Me.Controls.SetChildIndex(Me.nblevyf, 0)
        Me.Controls.SetChildIndex(Me.nblevye, 0)
        Me.Controls.SetChildIndex(Me.txtcommod, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtriccode, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.nbcommf, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.nbClearingf, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.nbclearinge, 0)
        Me.Controls.SetChildIndex(Me.dtgCommod, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        CType(Me.dtgCommod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgCommod As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nblevye As ESL.myNumericBox
    Friend WithEvents nbcomme As ESL.myNumericBox
    Friend WithEvents nblevyf As ESL.myNumericBox
    Friend WithEvents txtcommod As ESL.myTextbox
    Friend WithEvents txtriccode As ESL.myTextbox
    Friend WithEvents nbcommf As ESL.myNumericBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nbClearingf As ESL.myNumericBox
    Friend WithEvents nbclearinge As ESL.myNumericBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnReset As ESL.myButton
    Friend WithEvents cdid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ric_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commodity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents floor_comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents floor_clearing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents floor_levy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents electronic_comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents electronic_clearing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents electronic_levy As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
