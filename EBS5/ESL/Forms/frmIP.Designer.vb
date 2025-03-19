<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIP
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
        Me.dtpPeriod = New ESL.myDateTimePicker()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImport = New ESL.myButton(Me.components)
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.dgvIP = New System.Windows.Forms.DataGridView()
        Me.UID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FROMIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COUNCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COUNDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvIP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(601, 340)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(545, 340)
        Me.btnSave.Text = "Import"
        Me.btnSave.Visible = True
        '
        'dtpPeriod
        '
        Me.dtpPeriod.CustomFormat = "MM/yyyy"
        Me.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriod.Location = New System.Drawing.Point(154, 21)
        Me.dtpPeriod.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpPeriod.MinDate = New Date(1960, 1, 1, 0, 0, 0, 0)
        Me.dtpPeriod.Name = "dtpPeriod"
        Me.dtpPeriod.ShowUpDown = True
        Me.dtpPeriod.Size = New System.Drawing.Size(120, 21)
        Me.dtpPeriod.TabIndex = 847
        Me.dtpPeriod.Value = New Date(2010, 1, 1, 0, 0, 0, 0)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(335, 25)
        Me.lblTitle.TabIndex = 848
        Me.lblTitle.Text = "Import IP / Country Mapping Data"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnImport)
        Me.GroupBox1.Controls.Add(Me.lblPeriod)
        Me.GroupBox1.Controls.Add(Me.dtpPeriod)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(634, 55)
        Me.GroupBox1.TabIndex = 849
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import"
        '
        'btnImport
        '
        Me.btnImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImport.Location = New System.Drawing.Point(367, 17)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(261, 25)
        Me.btnImport.TabIndex = 848
        Me.btnImport.Text = "Load IP / Country Mapping Data (CSV)"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(6, 26)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(142, 15)
        Me.lblPeriod.TabIndex = 54
        Me.lblPeriod.Text = "Data Referencing Period"
        '
        'dgvIP
        '
        Me.dgvIP.AllowUserToAddRows = False
        Me.dgvIP.AllowUserToDeleteRows = False
        Me.dgvIP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgvIP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIP.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UID, Me.FROMIP, Me.TOIP, Me.COUNCODE, Me.COUNDESC})
        Me.dgvIP.Location = New System.Drawing.Point(17, 98)
        Me.dgvIP.MultiSelect = False
        Me.dgvIP.Name = "dgvIP"
        Me.dgvIP.RowHeadersVisible = False
        Me.dgvIP.RowTemplate.Height = 24
        Me.dgvIP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIP.Size = New System.Drawing.Size(634, 235)
        Me.dgvIP.TabIndex = 850
        '
        'UID
        '
        Me.UID.DataPropertyName = "UID"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        Me.UID.DefaultCellStyle = DataGridViewCellStyle2
        Me.UID.Frozen = True
        Me.UID.HeaderText = "ROWNO"
        Me.UID.Name = "UID"
        Me.UID.ReadOnly = True
        Me.UID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UID.Visible = False
        '
        'FROMIP
        '
        Me.FROMIP.DataPropertyName = "FROMIP"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        Me.FROMIP.DefaultCellStyle = DataGridViewCellStyle3
        Me.FROMIP.Frozen = True
        Me.FROMIP.HeaderText = "IP Range Start"
        Me.FROMIP.Name = "FROMIP"
        Me.FROMIP.ReadOnly = True
        Me.FROMIP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FROMIP.Width = 120
        '
        'TOIP
        '
        Me.TOIP.DataPropertyName = "TOIP"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.TOIP.DefaultCellStyle = DataGridViewCellStyle4
        Me.TOIP.Frozen = True
        Me.TOIP.HeaderText = "IP Range End"
        Me.TOIP.Name = "TOIP"
        Me.TOIP.ReadOnly = True
        Me.TOIP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TOIP.Width = 120
        '
        'COUNCODE
        '
        Me.COUNCODE.DataPropertyName = "COUNCODE"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        Me.COUNCODE.DefaultCellStyle = DataGridViewCellStyle5
        Me.COUNCODE.Frozen = True
        Me.COUNCODE.HeaderText = "Code"
        Me.COUNCODE.Name = "COUNCODE"
        Me.COUNCODE.ReadOnly = True
        Me.COUNCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COUNCODE.Width = 60
        '
        'COUNDESC
        '
        Me.COUNDESC.DataPropertyName = "COUNDESC"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        Me.COUNDESC.DefaultCellStyle = DataGridViewCellStyle6
        Me.COUNDESC.Frozen = True
        Me.COUNDESC.HeaderText = "Country / Territory Description"
        Me.COUNDESC.Name = "COUNDESC"
        Me.COUNDESC.ReadOnly = True
        Me.COUNDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COUNDESC.Width = 300
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(14, 336)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(97, 15)
        Me.lblRecord.TabIndex = 851
        Me.lblRecord.Text = "No. of records: 0"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(17, 380)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(492, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 853
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(14, 362)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 852
        Me.lblProcess.Text = "Processing"
        '
        'frmIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(663, 402)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.lblRecord)
        Me.Controls.Add(Me.dgvIP)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.KeyPreview = True
        Me.Name = "frmIP"
        Me.Text = " "
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dgvIP, 0)
        Me.Controls.SetChildIndex(Me.lblRecord, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvIP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpPeriod As ESL.myDateTimePicker
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents btnImport As ESL.myButton
    Friend WithEvents dgvIP As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecord As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents UID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FROMIP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOIP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COUNCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COUNDESC As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
