<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpFutureAndStock
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImport = New ESL.myButton(Me.components)
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.UID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INVESTTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTYDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACCNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTYDETAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDERNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Errors = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(767, 340)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(711, 340)
        Me.btnSave.Text = "Import"
        Me.btnSave.Visible = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(259, 25)
        Me.lblTitle.TabIndex = 54
        Me.lblTitle.Text = "Import {0} Trading Activity"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(17, 380)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(492, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 855
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(14, 362)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 854
        Me.lblProcess.Text = "Processing"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnImport)
        Me.GroupBox1.Controls.Add(Me.lblPeriod)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 55)
        Me.GroupBox1.TabIndex = 856
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import"
        '
        'btnImport
        '
        Me.btnImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImport.Location = New System.Drawing.Point(522, 21)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(261, 25)
        Me.btnImport.TabIndex = 848
        Me.btnImport.Text = "Load Trading Activity Log (CSV)"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(6, 26)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(262, 15)
        Me.lblPeriod.TabIndex = 54
        Me.lblPeriod.Text = "Login Location Lookup Referencing Period: {0}"
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.AllowUserToDeleteRows = False
        Me.dgvLog.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgvLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvLog.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UID, Me.INVESTTYPE, Me.ACTYDATE, Me.USERID, Me.ACCNO, Me.ACTYDETAIL, Me.ORDERNO, Me.Errors})
        Me.dgvLog.Location = New System.Drawing.Point(17, 98)
        Me.dgvLog.MultiSelect = False
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.RowHeadersVisible = False
        Me.dgvLog.RowTemplate.Height = 24
        Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLog.Size = New System.Drawing.Size(800, 235)
        Me.dgvLog.TabIndex = 857
        '
        'UID
        '
        Me.UID.DataPropertyName = "UID"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Linen
        Me.UID.DefaultCellStyle = DataGridViewCellStyle10
        Me.UID.Frozen = True
        Me.UID.HeaderText = "ROWNO"
        Me.UID.Name = "UID"
        Me.UID.ReadOnly = True
        Me.UID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UID.Visible = False
        '
        'INVESTTYPE
        '
        Me.INVESTTYPE.DataPropertyName = "INVESTTYPE"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Linen
        Me.INVESTTYPE.DefaultCellStyle = DataGridViewCellStyle11
        Me.INVESTTYPE.Frozen = True
        Me.INVESTTYPE.HeaderText = "Type"
        Me.INVESTTYPE.Name = "INVESTTYPE"
        Me.INVESTTYPE.ReadOnly = True
        Me.INVESTTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.INVESTTYPE.Visible = False
        Me.INVESTTYPE.Width = 120
        '
        'ACTYDATE
        '
        Me.ACTYDATE.DataPropertyName = "ACTYDATE"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle12.Format = "G"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.ACTYDATE.DefaultCellStyle = DataGridViewCellStyle12
        Me.ACTYDATE.Frozen = True
        Me.ACTYDATE.HeaderText = "Activity Date"
        Me.ACTYDATE.Name = "ACTYDATE"
        Me.ACTYDATE.ReadOnly = True
        Me.ACTYDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ACTYDATE.Width = 180
        '
        'USERID
        '
        Me.USERID.DataPropertyName = "USERID"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Linen
        Me.USERID.DefaultCellStyle = DataGridViewCellStyle13
        Me.USERID.Frozen = True
        Me.USERID.HeaderText = "User ID"
        Me.USERID.Name = "USERID"
        Me.USERID.ReadOnly = True
        Me.USERID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ACCNO
        '
        Me.ACCNO.DataPropertyName = "ACCNO"
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Linen
        Me.ACCNO.DefaultCellStyle = DataGridViewCellStyle14
        Me.ACCNO.Frozen = True
        Me.ACCNO.HeaderText = "Account No."
        Me.ACCNO.Name = "ACCNO"
        Me.ACCNO.ReadOnly = True
        Me.ACCNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ACTYDETAIL
        '
        Me.ACTYDETAIL.DataPropertyName = "ACTYDETAIL"
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.Linen
        Me.ACTYDETAIL.DefaultCellStyle = DataGridViewCellStyle15
        Me.ACTYDETAIL.Frozen = True
        Me.ACTYDETAIL.HeaderText = "Activity Details"
        Me.ACTYDETAIL.Name = "ACTYDETAIL"
        Me.ACTYDETAIL.ReadOnly = True
        Me.ACTYDETAIL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ACTYDETAIL.Width = 300
        '
        'ORDERNO
        '
        Me.ORDERNO.DataPropertyName = "ORDERNO"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Linen
        Me.ORDERNO.DefaultCellStyle = DataGridViewCellStyle16
        Me.ORDERNO.Frozen = True
        Me.ORDERNO.HeaderText = "Order No."
        Me.ORDERNO.Name = "ORDERNO"
        Me.ORDERNO.ReadOnly = True
        Me.ORDERNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ORDERNO.Width = 90
        '
        'Errors
        '
        Me.Errors.DataPropertyName = "Errors"
        Me.Errors.Frozen = True
        Me.Errors.HeaderText = "Errors"
        Me.Errors.Name = "Errors"
        Me.Errors.ReadOnly = True
        Me.Errors.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Errors.Visible = False
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(14, 336)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(97, 15)
        Me.lblRecord.TabIndex = 858
        Me.lblRecord.Text = "No. of records: 0"
        '
        'frmImpFutureAndStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(829, 404)
        Me.Controls.Add(Me.lblRecord)
        Me.Controls.Add(Me.dgvLog)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.lblTitle)
        Me.KeyPreview = True
        Me.Name = "frmImpFutureAndStock"
        Me.Text = " "
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.dgvLog, 0)
        Me.Controls.SetChildIndex(Me.lblRecord, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImport As ESL.myButton
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents dgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecord As System.Windows.Forms.Label
    Friend WithEvents UID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVESTTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACTYDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACCNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACTYDETAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDERNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Errors As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
