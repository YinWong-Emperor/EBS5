<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommApprove
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvLogs = New System.Windows.Forms.DataGridView
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_user = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D_action = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_ae = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_AC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_o_tdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_oid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d_log = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbMonth = New System.Windows.Forms.Label
        Me.txtStatus = New ESL.myTextbox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.txtPosting = New ESL.myTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMonth = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnLock = New ESL.myButton(Me.components)
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtLog = New ESL.myTextbox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCommMonth = New ESL.myTextbox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtOID = New ESL.myTextbox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTradeDate = New ESL.myTextbox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAccount = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAE = New ESL.myTextbox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFunction = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAction = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLogDate = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUser = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LbRecords = New System.Windows.Forms.Label
        Me.btnPrint = New ESL.myButton(Me.components)
        CType(Me.dgvLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Image = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(645, 573)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Image = Nothing
        Me.btnSave.Location = New System.Drawing.Point(567, 573)
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Text = "Approve"
        Me.btnSave.Visible = True
        '
        'dgvLogs
        '
        Me.dgvLogs.AllowUserToAddRows = False
        Me.dgvLogs.AllowUserToDeleteRows = False
        Me.dgvLogs.AllowUserToResizeRows = False
        Me.dgvLogs.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.misc_desc, Me.d_user, Me.d_date, Me.D_action, Me.d_type, Me.d_ae, Me.d_AC, Me.d_o_tdate, Me.d_oid, Me.d_txmonth, Me.d_log})
        Me.dgvLogs.Location = New System.Drawing.Point(10, 20)
        Me.dgvLogs.MultiSelect = False
        Me.dgvLogs.Name = "dgvLogs"
        Me.dgvLogs.ReadOnly = True
        Me.dgvLogs.RowHeadersVisible = False
        Me.dgvLogs.RowTemplate.Height = 24
        Me.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLogs.Size = New System.Drawing.Size(704, 240)
        Me.dgvLogs.TabIndex = 6
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "misc_desc"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        Me.misc_desc.DefaultCellStyle = DataGridViewCellStyle1
        Me.misc_desc.HeaderText = "Function"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        Me.misc_desc.Width = 180
        '
        'd_user
        '
        Me.d_user.DataPropertyName = "d_user"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        Me.d_user.DefaultCellStyle = DataGridViewCellStyle2
        Me.d_user.HeaderText = "User"
        Me.d_user.Name = "d_user"
        Me.d_user.ReadOnly = True
        Me.d_user.Width = 80
        '
        'd_date
        '
        Me.d_date.DataPropertyName = "d_date"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        Me.d_date.DefaultCellStyle = DataGridViewCellStyle3
        Me.d_date.HeaderText = "Date"
        Me.d_date.Name = "d_date"
        Me.d_date.ReadOnly = True
        Me.d_date.Width = 120
        '
        'D_action
        '
        Me.D_action.DataPropertyName = "d_action"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.D_action.DefaultCellStyle = DataGridViewCellStyle4
        Me.D_action.HeaderText = "Action"
        Me.D_action.Name = "D_action"
        Me.D_action.ReadOnly = True
        Me.D_action.Width = 60
        '
        'd_type
        '
        Me.d_type.DataPropertyName = "d_type"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        Me.d_type.DefaultCellStyle = DataGridViewCellStyle5
        Me.d_type.HeaderText = "Type"
        Me.d_type.Name = "d_type"
        Me.d_type.ReadOnly = True
        Me.d_type.Visible = False
        Me.d_type.Width = 5
        '
        'd_ae
        '
        Me.d_ae.DataPropertyName = "d_ae"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        Me.d_ae.DefaultCellStyle = DataGridViewCellStyle6
        Me.d_ae.HeaderText = "AE"
        Me.d_ae.Name = "d_ae"
        Me.d_ae.ReadOnly = True
        Me.d_ae.Width = 80
        '
        'd_AC
        '
        Me.d_AC.DataPropertyName = "d_AC"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Linen
        Me.d_AC.DefaultCellStyle = DataGridViewCellStyle7
        Me.d_AC.HeaderText = "Account"
        Me.d_AC.Name = "d_AC"
        Me.d_AC.ReadOnly = True
        Me.d_AC.Width = 80
        '
        'd_o_tdate
        '
        Me.d_o_tdate.DataPropertyName = "d_o_tdate"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.d_o_tdate.DefaultCellStyle = DataGridViewCellStyle8
        Me.d_o_tdate.HeaderText = "TDate"
        Me.d_o_tdate.Name = "d_o_tdate"
        Me.d_o_tdate.ReadOnly = True
        Me.d_o_tdate.Width = 80
        '
        'd_oid
        '
        Me.d_oid.DataPropertyName = "d_oid"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Linen
        Me.d_oid.DefaultCellStyle = DataGridViewCellStyle9
        Me.d_oid.HeaderText = "OID"
        Me.d_oid.Name = "d_oid"
        Me.d_oid.ReadOnly = True
        Me.d_oid.Width = 90
        '
        'd_txmonth
        '
        Me.d_txmonth.DataPropertyName = "d_txmonth"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Linen
        Me.d_txmonth.DefaultCellStyle = DataGridViewCellStyle10
        Me.d_txmonth.HeaderText = "Month"
        Me.d_txmonth.Name = "d_txmonth"
        Me.d_txmonth.ReadOnly = True
        Me.d_txmonth.Width = 80
        '
        'd_log
        '
        Me.d_log.DataPropertyName = "d_log"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Linen
        Me.d_log.DefaultCellStyle = DataGridViewCellStyle11
        Me.d_log.HeaderText = "Log"
        Me.d_log.Name = "d_log"
        Me.d_log.ReadOnly = True
        Me.d_log.Width = 500
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbMonth)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtPosting)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMonth)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 79)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Log Infomation"
        '
        'lbMonth
        '
        Me.lbMonth.AutoSize = True
        Me.lbMonth.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.lbMonth.ForeColor = System.Drawing.Color.Red
        Me.lbMonth.Location = New System.Drawing.Point(262, 50)
        Me.lbMonth.Name = "lbMonth"
        Me.lbMonth.Size = New System.Drawing.Size(65, 18)
        Me.lbMonth.TabIndex = 15
        Me.lbMonth.Text = "Label14"
        Me.lbMonth.Visible = False
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.Linen
        Me.txtStatus.Location = New System.Drawing.Point(176, 47)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(80, 21)
        Me.txtStatus.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(129, 15)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Current Locked Status"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(639, 46)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtPosting
        '
        Me.txtPosting.BackColor = System.Drawing.Color.Linen
        Me.txtPosting.Location = New System.Drawing.Point(561, 20)
        Me.txtPosting.Name = "txtPosting"
        Me.txtPosting.ReadOnly = True
        Me.txtPosting.Size = New System.Drawing.Size(153, 21)
        Me.txtPosting.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(375, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Last Approved Time"
        '
        'txtMonth
        '
        Me.txtMonth.BackColor = System.Drawing.Color.Linen
        Me.txtMonth.Location = New System.Drawing.Point(176, 17)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.ReadOnly = True
        Me.txtMonth.Size = New System.Drawing.Size(80, 21)
        Me.txtMonth.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Current Commission Month"
        '
        'btnLock
        '
        Me.btnLock.Location = New System.Drawing.Point(489, 573)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(75, 23)
        Me.btnLock.TabIndex = 11
        Me.btnLock.Text = "Lock"
        Me.btnLock.UseVisualStyleBackColor = True
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(6, 581)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(393, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 57
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(3, 563)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 56
        Me.lblProcess.Text = "Processing"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLog)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCommMonth)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtOID)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTradeDate)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtAccount)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtAE)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFunction)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtAction)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtLogDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtUser)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 372)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(720, 188)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detailed Logs"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.Linen
        Me.txtLog.Location = New System.Drawing.Point(67, 98)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(647, 84)
        Me.txtLog.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 15)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Logs"
        '
        'txtCommMonth
        '
        Me.txtCommMonth.BackColor = System.Drawing.Color.Linen
        Me.txtCommMonth.Location = New System.Drawing.Point(462, 44)
        Me.txtCommMonth.Name = "txtCommMonth"
        Me.txtCommMonth.Size = New System.Drawing.Size(100, 21)
        Me.txtCommMonth.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(375, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 15)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Comm. Month"
        '
        'txtOID
        '
        Me.txtOID.BackColor = System.Drawing.Color.Linen
        Me.txtOID.Location = New System.Drawing.Point(614, 44)
        Me.txtOID.Name = "txtOID"
        Me.txtOID.Size = New System.Drawing.Size(100, 21)
        Me.txtOID.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(568, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "OID"
        '
        'txtTradeDate
        '
        Me.txtTradeDate.BackColor = System.Drawing.Color.Linen
        Me.txtTradeDate.Location = New System.Drawing.Point(462, 17)
        Me.txtTradeDate.Name = "txtTradeDate"
        Me.txtTradeDate.Size = New System.Drawing.Size(100, 21)
        Me.txtTradeDate.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(375, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Trade Date"
        '
        'txtAccount
        '
        Me.txtAccount.BackColor = System.Drawing.Color.Linen
        Me.txtAccount.Location = New System.Drawing.Point(243, 44)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(126, 21)
        Me.txtAccount.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(173, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Account"
        '
        'txtAE
        '
        Me.txtAE.BackColor = System.Drawing.Color.Linen
        Me.txtAE.Location = New System.Drawing.Point(67, 44)
        Me.txtAE.Name = "txtAE"
        Me.txtAE.Size = New System.Drawing.Size(100, 21)
        Me.txtAE.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "AE"
        '
        'txtFunction
        '
        Me.txtFunction.BackColor = System.Drawing.Color.Linen
        Me.txtFunction.Location = New System.Drawing.Point(67, 71)
        Me.txtFunction.Name = "txtFunction"
        Me.txtFunction.Size = New System.Drawing.Size(647, 21)
        Me.txtFunction.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Function"
        '
        'txtAction
        '
        Me.txtAction.BackColor = System.Drawing.Color.Linen
        Me.txtAction.Location = New System.Drawing.Point(614, 17)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(100, 21)
        Me.txtAction.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(568, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Action"
        '
        'txtLogDate
        '
        Me.txtLogDate.BackColor = System.Drawing.Color.Linen
        Me.txtLogDate.Location = New System.Drawing.Point(243, 17)
        Me.txtLogDate.Name = "txtLogDate"
        Me.txtLogDate.Size = New System.Drawing.Size(126, 21)
        Me.txtLogDate.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Log Date"
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.Linen
        Me.txtUser.Location = New System.Drawing.Point(67, 17)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(100, 21)
        Me.txtUser.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "User"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LbRecords)
        Me.GroupBox3.Controls.Add(Me.dgvLogs)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 88)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(720, 278)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Logs"
        '
        'LbRecords
        '
        Me.LbRecords.AutoSize = True
        Me.LbRecords.Location = New System.Drawing.Point(10, 267)
        Me.LbRecords.Name = "LbRecords"
        Me.LbRecords.Size = New System.Drawing.Size(0, 15)
        Me.LbRecords.TabIndex = 7
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(410, 573)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 60
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmCommApprove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(733, 609)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnLock)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmCommApprove"
        Me.Text = "Commission Approve Function"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.btnLock, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        CType(Me.dgvLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvLogs As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLock As ESL.myButton
    Friend WithEvents txtPosting As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUser As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccount As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAE As ESL.myTextbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFunction As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAction As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLogDate As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTradeDate As ESL.myTextbox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLog As ESL.myTextbox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCommMonth As ESL.myTextbox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOID As ESL.myTextbox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LbRecords As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents txtStatus As ESL.myTextbox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents lbMonth As System.Windows.Forms.Label
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_user As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D_action As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_ae As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_AC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_o_tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_oid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_log As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
