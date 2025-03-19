<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmITAM
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmITAM))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgvITAP = New System.Windows.Forms.DataGridView()
        Me.UID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARACODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARADESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARAVAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MINVAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAXVAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DISPSEQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnModify = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ambValue = New ESL.myAmountBox()
        Me.ambID = New ESL.myAmountBox()
        Me.ambMax = New ESL.myAmountBox()
        Me.ambMin = New ESL.myAmountBox()
        Me.txtType = New ESL.myTextbox()
        Me.txtValue = New ESL.myTextbox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtDesc = New ESL.myTextbox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtModule = New ESL.myTextbox()
        Me.lblModule = New System.Windows.Forms.Label()
        CType(Me.dgvITAP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(741, 443)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(685, 443)
        Me.btnSave.Visible = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(394, 25)
        Me.lblTitle.TabIndex = 53
        Me.lblTitle.Text = "Trading Activity Parameter Maintenance"
        '
        'dgvITAP
        '
        Me.dgvITAP.AllowUserToAddRows = False
        Me.dgvITAP.AllowUserToDeleteRows = False
        Me.dgvITAP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgvITAP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvITAP.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvITAP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvITAP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UID, Me.MODNAME, Me.PARACODE, Me.PARADESC, Me.PARAVAL, Me.VALTYPE, Me.MINVAL, Me.MAXVAL, Me.DISPSEQ})
        Me.dgvITAP.Location = New System.Drawing.Point(17, 37)
        Me.dgvITAP.MultiSelect = False
        Me.dgvITAP.Name = "dgvITAP"
        Me.dgvITAP.RowHeadersVisible = False
        Me.dgvITAP.RowTemplate.Height = 24
        Me.dgvITAP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvITAP.Size = New System.Drawing.Size(775, 269)
        Me.dgvITAP.TabIndex = 54
        '
        'UID
        '
        Me.UID.DataPropertyName = "UID"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UID.DefaultCellStyle = DataGridViewCellStyle2
        Me.UID.Frozen = True
        Me.UID.HeaderText = "UID"
        Me.UID.Name = "UID"
        Me.UID.ReadOnly = True
        Me.UID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UID.Visible = False
        '
        'MODNAME
        '
        Me.MODNAME.DataPropertyName = "MODULE"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MODNAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.MODNAME.Frozen = True
        Me.MODNAME.HeaderText = "Module"
        Me.MODNAME.Name = "MODNAME"
        Me.MODNAME.ReadOnly = True
        Me.MODNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MODNAME.Width = 150
        '
        'PARACODE
        '
        Me.PARACODE.DataPropertyName = "PARACODE"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PARACODE.DefaultCellStyle = DataGridViewCellStyle4
        Me.PARACODE.Frozen = True
        Me.PARACODE.HeaderText = "Code"
        Me.PARACODE.Name = "PARACODE"
        Me.PARACODE.ReadOnly = True
        Me.PARACODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PARACODE.Visible = False
        '
        'PARADESC
        '
        Me.PARADESC.DataPropertyName = "PARADESC"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PARADESC.DefaultCellStyle = DataGridViewCellStyle5
        Me.PARADESC.Frozen = True
        Me.PARADESC.HeaderText = "Parameter Description"
        Me.PARADESC.Name = "PARADESC"
        Me.PARADESC.ReadOnly = True
        Me.PARADESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PARADESC.Width = 300
        '
        'PARAVAL
        '
        Me.PARAVAL.DataPropertyName = "PARAVAL"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PARAVAL.DefaultCellStyle = DataGridViewCellStyle6
        Me.PARAVAL.Frozen = True
        Me.PARAVAL.HeaderText = "Parameter Value"
        Me.PARAVAL.Name = "PARAVAL"
        Me.PARAVAL.ReadOnly = True
        Me.PARAVAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PARAVAL.Width = 300
        '
        'VALTYPE
        '
        Me.VALTYPE.DataPropertyName = "VALTYPE"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.VALTYPE.DefaultCellStyle = DataGridViewCellStyle7
        Me.VALTYPE.Frozen = True
        Me.VALTYPE.HeaderText = "VALTYPE"
        Me.VALTYPE.Name = "VALTYPE"
        Me.VALTYPE.ReadOnly = True
        Me.VALTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VALTYPE.Visible = False
        '
        'MINVAL
        '
        Me.MINVAL.DataPropertyName = "MINVAL"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MINVAL.DefaultCellStyle = DataGridViewCellStyle8
        Me.MINVAL.Frozen = True
        Me.MINVAL.HeaderText = "MINVAL"
        Me.MINVAL.Name = "MINVAL"
        Me.MINVAL.ReadOnly = True
        Me.MINVAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MINVAL.Visible = False
        '
        'MAXVAL
        '
        Me.MAXVAL.DataPropertyName = "MAXVAL"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MAXVAL.DefaultCellStyle = DataGridViewCellStyle9
        Me.MAXVAL.Frozen = True
        Me.MAXVAL.HeaderText = "MAXVAL"
        Me.MAXVAL.Name = "MAXVAL"
        Me.MAXVAL.ReadOnly = True
        Me.MAXVAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MAXVAL.Visible = False
        '
        'DISPSEQ
        '
        Me.DISPSEQ.DataPropertyName = "DISPSEQ"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.DISPSEQ.DefaultCellStyle = DataGridViewCellStyle10
        Me.DISPSEQ.Frozen = True
        Me.DISPSEQ.HeaderText = "DISPSEQ"
        Me.DISPSEQ.Name = "DISPSEQ"
        Me.DISPSEQ.ReadOnly = True
        Me.DISPSEQ.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DISPSEQ.Visible = False
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModify.Location = New System.Drawing.Point(629, 443)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(50, 55)
        Me.btnModify.TabIndex = 55
        Me.btnModify.Text = "Modify"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ambValue)
        Me.GroupBox1.Controls.Add(Me.ambID)
        Me.GroupBox1.Controls.Add(Me.ambMax)
        Me.GroupBox1.Controls.Add(Me.ambMin)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.txtValue)
        Me.GroupBox1.Controls.Add(Me.lblValue)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.lblDesc)
        Me.GroupBox1.Controls.Add(Me.txtModule)
        Me.GroupBox1.Controls.Add(Me.lblModule)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 312)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 123)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Details"
        '
        'ambValue
        '
        Me.ambValue.DecimalPoints = 0
        Me.ambValue.EnabledRemoveTrailingZero = False
        Me.ambValue.Location = New System.Drawing.Point(122, 93)
        Me.ambValue.MaxLength = 200
        Me.ambValue.Name = "ambValue"
        Me.ambValue.ReadOnly = True
        Me.ambValue.Size = New System.Drawing.Size(648, 21)
        Me.ambValue.TabIndex = 69
        Me.ambValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ambValue.Visible = False
        '
        'ambID
        '
        Me.ambID.DecimalPoints = 0
        Me.ambID.EnabledRemoveTrailingZero = False
        Me.ambID.Location = New System.Drawing.Point(328, 23)
        Me.ambID.Name = "ambID"
        Me.ambID.ReadOnly = True
        Me.ambID.Size = New System.Drawing.Size(50, 21)
        Me.ambID.TabIndex = 68
        Me.ambID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ambID.Visible = False
        '
        'ambMax
        '
        Me.ambMax.DecimalPoints = 0
        Me.ambMax.EnabledRemoveTrailingZero = False
        Me.ambMax.Location = New System.Drawing.Point(496, 23)
        Me.ambMax.Name = "ambMax"
        Me.ambMax.ReadOnly = True
        Me.ambMax.Size = New System.Drawing.Size(50, 21)
        Me.ambMax.TabIndex = 67
        Me.ambMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ambMax.Visible = False
        '
        'ambMin
        '
        Me.ambMin.DecimalPoints = 0
        Me.ambMin.EnabledRemoveTrailingZero = False
        Me.ambMin.Location = New System.Drawing.Point(440, 23)
        Me.ambMin.Name = "ambMin"
        Me.ambMin.ReadOnly = True
        Me.ambMin.Size = New System.Drawing.Size(50, 21)
        Me.ambMin.TabIndex = 66
        Me.ambMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ambMin.Visible = False
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(384, 23)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(50, 21)
        Me.txtType.TabIndex = 65
        Me.txtType.Visible = False
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(122, 88)
        Me.txtValue.MaxLength = 200
        Me.txtValue.Name = "txtValue"
        Me.txtValue.ReadOnly = True
        Me.txtValue.Size = New System.Drawing.Size(648, 21)
        Me.txtValue.TabIndex = 64
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(9, 91)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 15)
        Me.lblValue.TabIndex = 63
        Me.lblValue.Text = "Value"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(122, 50)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(648, 39)
        Me.txtDesc.TabIndex = 62
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(9, 46)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(70, 15)
        Me.lblDesc.TabIndex = 61
        Me.lblDesc.Text = "Description"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(122, 23)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.ReadOnly = True
        Me.txtModule.Size = New System.Drawing.Size(200, 21)
        Me.txtModule.TabIndex = 60
        '
        'lblModule
        '
        Me.lblModule.AutoSize = True
        Me.lblModule.Location = New System.Drawing.Point(9, 23)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(47, 15)
        Me.lblModule.TabIndex = 54
        Me.lblModule.Text = "Module"
        '
        'frmITAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(803, 505)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.dgvITAP)
        Me.Controls.Add(Me.lblTitle)
        Me.KeyPreview = True
        Me.Name = "frmITAM"
        Me.Text = " "
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dgvITAP, 0)
        Me.Controls.SetChildIndex(Me.btnModify, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        CType(Me.dgvITAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgvITAP As System.Windows.Forms.DataGridView
    Friend WithEvents btnModify As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents txtType As ESL.myTextbox
    Friend WithEvents txtValue As ESL.myTextbox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtDesc As ESL.myTextbox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtModule As ESL.myTextbox
    Friend WithEvents ambMin As ESL.myAmountBox
    Friend WithEvents ambMax As ESL.myAmountBox
    Friend WithEvents ambID As ESL.myAmountBox
    Friend WithEvents ambValue As ESL.myAmountBox
    Friend WithEvents UID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARACODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARADESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARAVAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MINVAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAXVAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISPSEQ As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
