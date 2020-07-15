<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDailyIPOAdj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDailyIPOAdj))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tc = New System.Windows.Forms.TabControl()
        Me.tp1 = New System.Windows.Forms.TabPage()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudMonth = New ESL.myNumericUpDown(Me.components)
        Me.nudYear = New ESL.myNumericUpDown(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtToClient = New ESL.myTextbox()
        Me.txtFromClient = New ESL.myTextbox()
        Me.btnView = New ESL.myButton(Me.components)
        Me.btnExport = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.dtgIPO = New System.Windows.Forms.DataGridView()
        Me.tp2 = New System.Windows.Forms.TabPage()
        Me.txtIPO = New ESL.myAmountBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dpIPOAdj = New ESL.myDateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIPOBack = New ESL.myButton(Me.components)
        Me.btnSaveIPO = New ESL.myButton(Me.components)
        Me.txtAddClient = New ESL.myTextbox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.adjIPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adjDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tc.SuspendLayout()
        Me.tp1.SuspendLayout()
        CType(Me.nudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgIPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(503, 464)
        Me.btnCancel.Size = New System.Drawing.Size(53, 55)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(441, 463)
        Me.btnSave.Size = New System.Drawing.Size(53, 55)
        '
        'tc
        '
        Me.tc.Controls.Add(Me.tp1)
        Me.tc.Controls.Add(Me.tp2)
        Me.tc.Location = New System.Drawing.Point(2, 72)
        Me.tc.Name = "tc"
        Me.tc.SelectedIndex = 0
        Me.tc.Size = New System.Drawing.Size(579, 385)
        Me.tc.TabIndex = 6
        '
        'tp1
        '
        Me.tp1.Controls.Add(Me.lblTotal)
        Me.tp1.Controls.Add(Me.Label7)
        Me.tp1.Controls.Add(Me.Label6)
        Me.tp1.Controls.Add(Me.Label5)
        Me.tp1.Controls.Add(Me.nudMonth)
        Me.tp1.Controls.Add(Me.nudYear)
        Me.tp1.Controls.Add(Me.Label4)
        Me.tp1.Controls.Add(Me.Label3)
        Me.tp1.Controls.Add(Me.Label2)
        Me.tp1.Controls.Add(Me.txtToClient)
        Me.tp1.Controls.Add(Me.txtFromClient)
        Me.tp1.Controls.Add(Me.btnView)
        Me.tp1.Controls.Add(Me.btnExport)
        Me.tp1.Controls.Add(Me.btnDelete)
        Me.tp1.Controls.Add(Me.dtgIPO)
        Me.tp1.Location = New System.Drawing.Point(4, 24)
        Me.tp1.Name = "tp1"
        Me.tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.tp1.Size = New System.Drawing.Size(571, 357)
        Me.tp1.TabIndex = 0
        Me.tp1.Text = "Client Interest Listing"
        Me.tp1.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(102, 255)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 15)
        Me.lblTotal.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(176, 326)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(289, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Month"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(176, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Year"
        '
        'nudMonth
        '
        Me.nudMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudMonth.Location = New System.Drawing.Point(214, 286)
        Me.nudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMonth.Name = "nudMonth"
        Me.nudMonth.Size = New System.Drawing.Size(60, 20)
        Me.nudMonth.TabIndex = 13
        Me.nudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudYear
        '
        Me.nudYear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudYear.Location = New System.Drawing.Point(105, 286)
        Me.nudYear.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.nudYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(60, 20)
        Me.nudYear.TabIndex = 12
        Me.nudYear.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Client Range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 291)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "IPO Total"
        '
        'txtToClient
        '
        Me.txtToClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToClient.Location = New System.Drawing.Point(214, 321)
        Me.txtToClient.Name = "txtToClient"
        Me.txtToClient.Size = New System.Drawing.Size(65, 20)
        Me.txtToClient.TabIndex = 8
        '
        'txtFromClient
        '
        Me.txtFromClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromClient.Location = New System.Drawing.Point(105, 321)
        Me.txtFromClient.Name = "txtFromClient"
        Me.txtFromClient.Size = New System.Drawing.Size(65, 20)
        Me.txtFromClient.TabIndex = 7
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnView.Location = New System.Drawing.Point(373, 291)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(53, 55)
        Me.btnView.TabIndex = 1
        Me.btnView.Text = "Enquiry"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Image = Global.ESL.My.Resources.Resources.export
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExport.Location = New System.Drawing.Point(497, 292)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(53, 54)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.ESL.My.Resources.Resources.edit_delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(435, 291)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(53, 55)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dtgIPO
        '
        Me.dtgIPO.AllowUserToAddRows = False
        Me.dtgIPO.AllowUserToDeleteRows = False
        Me.dtgIPO.AllowUserToResizeRows = False
        Me.dtgIPO.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgIPO.ColumnHeadersHeight = 20
        Me.dtgIPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.adjIPOID, Me.accno, Me.adjDate, Me.ipo})
        Me.dtgIPO.GridColor = System.Drawing.Color.Linen
        Me.dtgIPO.Location = New System.Drawing.Point(0, 20)
        Me.dtgIPO.MultiSelect = False
        Me.dtgIPO.Name = "dtgIPO"
        Me.dtgIPO.ReadOnly = True
        Me.dtgIPO.RowHeadersVisible = False
        Me.dtgIPO.RowTemplate.Height = 24
        Me.dtgIPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgIPO.Size = New System.Drawing.Size(568, 216)
        Me.dtgIPO.TabIndex = 0
        '
        'tp2
        '
        Me.tp2.Controls.Add(Me.txtIPO)
        Me.tp2.Controls.Add(Me.lblInfo)
        Me.tp2.Controls.Add(Me.Label9)
        Me.tp2.Controls.Add(Me.Label8)
        Me.tp2.Controls.Add(Me.dpIPOAdj)
        Me.tp2.Controls.Add(Me.Label1)
        Me.tp2.Controls.Add(Me.btnIPOBack)
        Me.tp2.Controls.Add(Me.btnSaveIPO)
        Me.tp2.Controls.Add(Me.txtAddClient)
        Me.tp2.Location = New System.Drawing.Point(4, 24)
        Me.tp2.Name = "tp2"
        Me.tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.tp2.Size = New System.Drawing.Size(571, 357)
        Me.tp2.TabIndex = 1
        Me.tp2.Text = "IPO Adjustment"
        Me.tp2.UseVisualStyleBackColor = True
        '
        'txtIPO
        '
        Me.txtIPO.DecimalPoints = 2
        Me.txtIPO.EnabledRemoveTrailingZero = False
        Me.txtIPO.IntLen = 9
        Me.txtIPO.Location = New System.Drawing.Point(156, 117)
        Me.txtIPO.Name = "txtIPO"
        Me.txtIPO.Size = New System.Drawing.Size(159, 21)
        Me.txtIPO.TabIndex = 10
        Me.txtIPO.Text = "0.00"
        Me.txtIPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(36, 182)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(0, 14)
        Me.lblInfo.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "IPO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Date"
        '
        'dpIPOAdj
        '
        Me.dpIPOAdj.CustomFormat = "dd/MM/yyyy"
        Me.dpIPOAdj.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpIPOAdj.Location = New System.Drawing.Point(156, 70)
        Me.dpIPOAdj.Name = "dpIPOAdj"
        Me.dpIPOAdj.Size = New System.Drawing.Size(159, 21)
        Me.dpIPOAdj.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Client Code"
        '
        'btnIPOBack
        '
        Me.btnIPOBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIPOBack.Image = Global.ESL.My.Resources.Resources.back
        Me.btnIPOBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIPOBack.Location = New System.Drawing.Point(497, 96)
        Me.btnIPOBack.Name = "btnIPOBack"
        Me.btnIPOBack.Size = New System.Drawing.Size(53, 55)
        Me.btnIPOBack.TabIndex = 4
        Me.btnIPOBack.Text = "Back"
        Me.btnIPOBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIPOBack.UseVisualStyleBackColor = True
        '
        'btnSaveIPO
        '
        Me.btnSaveIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveIPO.Image = Global.ESL.My.Resources.Resources.add
        Me.btnSaveIPO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveIPO.Location = New System.Drawing.Point(435, 96)
        Me.btnSaveIPO.Name = "btnSaveIPO"
        Me.btnSaveIPO.Size = New System.Drawing.Size(53, 55)
        Me.btnSaveIPO.TabIndex = 3
        Me.btnSaveIPO.Text = "Save"
        Me.btnSaveIPO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveIPO.UseVisualStyleBackColor = True
        '
        'txtAddClient
        '
        Me.txtAddClient.Location = New System.Drawing.Point(156, 23)
        Me.txtAddClient.MaxLength = 8
        Me.txtAddClient.Name = "txtAddClient"
        Me.txtAddClient.Size = New System.Drawing.Size(159, 21)
        Me.txtAddClient.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(188, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(203, 22)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Daily IPO Adjustment"
        '
        'adjIPOID
        '
        Me.adjIPOID.DataPropertyName = "adjIPOID"
        Me.adjIPOID.HeaderText = "ipoID"
        Me.adjIPOID.Name = "adjIPOID"
        Me.adjIPOID.ReadOnly = True
        Me.adjIPOID.Visible = False
        Me.adjIPOID.Width = 10
        '
        'accno
        '
        Me.accno.DataPropertyName = "accno"
        Me.accno.HeaderText = "Client Code"
        Me.accno.Name = "accno"
        Me.accno.ReadOnly = True
        Me.accno.Width = 150
        '
        'adjDate
        '
        Me.adjDate.DataPropertyName = "adjDate"
        DataGridViewCellStyle1.Format = "dd/MM/yyyy"
        Me.adjDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.adjDate.HeaderText = "Date"
        Me.adjDate.Name = "adjDate"
        Me.adjDate.ReadOnly = True
        Me.adjDate.Width = 150
        '
        'ipo
        '
        Me.ipo.DataPropertyName = "ipo"
        DataGridViewCellStyle2.Format = "N2"
        Me.ipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ipo.HeaderText = "IPO"
        Me.ipo.Name = "ipo"
        Me.ipo.ReadOnly = True
        Me.ipo.Width = 200
        '
        'FrmDailyIPOAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(583, 541)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tc)
        Me.KeyPreview = True
        Me.Name = "FrmDailyIPOAdj"
        Me.Text = "Daily IPO Adjustment"
        Me.Controls.SetChildIndex(Me.tc, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.tc.ResumeLayout(False)
        Me.tp1.ResumeLayout(False)
        Me.tp1.PerformLayout()
        CType(Me.nudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgIPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp2.ResumeLayout(False)
        Me.tp2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tc As System.Windows.Forms.TabControl
    Friend WithEvents tp1 As System.Windows.Forms.TabPage
    Friend WithEvents tp2 As System.Windows.Forms.TabPage
    Friend WithEvents txtToClient As ESL.myTextbox
    Friend WithEvents txtFromClient As ESL.myTextbox
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnView As ESL.myButton
    Friend WithEvents dtgIPO As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnIPOBack As ESL.myButton
    Friend WithEvents btnSaveIPO As ESL.myButton
    Friend WithEvents txtAddClient As ESL.myTextbox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudMonth As ESL.myNumericUpDown
    Friend WithEvents nudYear As ESL.myNumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dpIPOAdj As ESL.myDateTimePicker
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents txtIPO As ESL.myAmountBox
    Friend WithEvents adjIPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents adjDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ipo As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
