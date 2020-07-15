<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptTradingActAlert
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ddlRptName = New ESL.myComboBox(Me.components)
        Me.lblRptName = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New ESL.myTextbox()
        Me.ambDays = New ESL.myAmountBox()
        Me.lblDays = New System.Windows.Forms.Label()
        Me.ambTimes = New ESL.myAmountBox()
        Me.lblTimes = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.ddlChannel = New ESL.myComboBox(Me.components)
        Me.lblRptDate = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(847, 321)
        Me.btnCancel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Image = Global.ESL.My.Resources.Resources.document_new
        Me.btnSave.Location = New System.Drawing.Point(781, 321)
        Me.btnSave.Size = New System.Drawing.Size(60, 55)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Generate"
        Me.btnSave.Visible = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(323, 25)
        Me.lblTitle.TabIndex = 55
        Me.lblTitle.Text = "{0} Trading Activity Alert Reports"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ddlRptName)
        Me.GroupBox1.Controls.Add(Me.lblRptName)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(880, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report"
        '
        'ddlRptName
        '
        Me.ddlRptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlRptName.FormattingEnabled = True
        Me.ddlRptName.Location = New System.Drawing.Point(144, 20)
        Me.ddlRptName.Name = "ddlRptName"
        Me.ddlRptName.Size = New System.Drawing.Size(730, 23)
        Me.ddlRptName.TabIndex = 1
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Location = New System.Drawing.Point(6, 23)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(84, 15)
        Me.lblRptName.TabIndex = 0
        Me.lblRptName.Text = "Report Name:"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(144, 20)
        Me.dtpFrom.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(100, 21)
        Me.dtpFrom.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblEmail)
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.ambDays)
        Me.GroupBox2.Controls.Add(Me.lblDays)
        Me.GroupBox2.Controls.Add(Me.ambTimes)
        Me.GroupBox2.Controls.Add(Me.lblTimes)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 128)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Predefined Parameters"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(6, 77)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(120, 15)
        Me.lblEmail.TabIndex = 0
        Me.lblEmail.Text = "Email Recipient List:"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.Linen
        Me.txtEmail.Enabled = False
        Me.txtEmail.Location = New System.Drawing.Point(10, 95)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(865, 21)
        Me.txtEmail.TabIndex = 1
        '
        'ambDays
        '
        Me.ambDays.BackColor = System.Drawing.Color.Linen
        Me.ambDays.DecimalPoints = 0
        Me.ambDays.Enabled = False
        Me.ambDays.EnabledRemoveTrailingZero = False
        Me.ambDays.Location = New System.Drawing.Point(834, 47)
        Me.ambDays.Name = "ambDays"
        Me.ambDays.ReadOnly = True
        Me.ambDays.Size = New System.Drawing.Size(40, 21)
        Me.ambDays.TabIndex = 5
        Me.ambDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDays
        '
        Me.lblDays.AutoSize = True
        Me.lblDays.Location = New System.Drawing.Point(6, 50)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(129, 15)
        Me.lblDays.TabIndex = 4
        Me.lblDays.Text = "Last n Calendar Days:"
        '
        'ambTimes
        '
        Me.ambTimes.BackColor = System.Drawing.Color.Linen
        Me.ambTimes.DecimalPoints = 0
        Me.ambTimes.Enabled = False
        Me.ambTimes.EnabledRemoveTrailingZero = False
        Me.ambTimes.Location = New System.Drawing.Point(834, 20)
        Me.ambTimes.Name = "ambTimes"
        Me.ambTimes.ReadOnly = True
        Me.ambTimes.Size = New System.Drawing.Size(40, 21)
        Me.ambTimes.TabIndex = 3
        Me.ambTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTimes
        '
        Me.lblTimes.AutoSize = True
        Me.lblTimes.Location = New System.Drawing.Point(6, 23)
        Me.lblTimes.Name = "lblTimes"
        Me.lblTimes.Size = New System.Drawing.Size(113, 15)
        Me.lblTimes.TabIndex = 2
        Me.lblTimes.Text = "m Times of Orders:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblChannel)
        Me.GroupBox3.Controls.Add(Me.lblTo)
        Me.GroupBox3.Controls.Add(Me.dtpTo)
        Me.GroupBox3.Controls.Add(Me.ddlChannel)
        Me.GroupBox3.Controls.Add(Me.lblRptDate)
        Me.GroupBox3.Controls.Add(Me.dtpFrom)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 226)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(880, 82)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Report Criteria"
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Location = New System.Drawing.Point(6, 50)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(102, 15)
        Me.lblChannel.TabIndex = 4
        Me.lblChannel.Text = "Trading Channel:"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(251, 23)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(17, 15)
        Me.lblTo.TabIndex = 2
        Me.lblTo.Text = "to"
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(274, 20)
        Me.dtpTo.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpTo.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(100, 21)
        Me.dtpTo.TabIndex = 3
        '
        'ddlChannel
        '
        Me.ddlChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlChannel.FormattingEnabled = True
        Me.ddlChannel.Location = New System.Drawing.Point(144, 47)
        Me.ddlChannel.Name = "ddlChannel"
        Me.ddlChannel.Size = New System.Drawing.Size(228, 23)
        Me.ddlChannel.TabIndex = 5
        '
        'lblRptDate
        '
        Me.lblRptDate.AutoSize = True
        Me.lblRptDate.Location = New System.Drawing.Point(6, 23)
        Me.lblRptDate.Name = "lblRptDate"
        Me.lblRptDate.Size = New System.Drawing.Size(76, 15)
        Me.lblRptDate.TabIndex = 0
        Me.lblRptDate.Text = "Report Date:"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(12, 361)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(492, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 909
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(14, 343)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 908
        Me.lblProcess.Text = "Processing"
        '
        'frmRptTradingActAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(904, 385)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.KeyPreview = True
        Me.Name = "frmRptTradingActAlert"
        Me.Text = " "
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ddlRptName As ESL.myComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTimes As System.Windows.Forms.Label
    Friend WithEvents ambDays As ESL.myAmountBox
    Friend WithEvents lblDays As System.Windows.Forms.Label
    Friend WithEvents ambTimes As ESL.myAmountBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As ESL.myTextbox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ddlChannel As ESL.myComboBox
    Friend WithEvents lblRptDate As System.Windows.Forms.Label
    Friend WithEvents lblChannel As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label

End Class
