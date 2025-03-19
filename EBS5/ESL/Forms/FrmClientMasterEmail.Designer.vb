<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientMasterMail
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
        Me.txtClientFrom = New ESL.myTextbox
        Me.txtClientTo = New ESL.myTextbox
        Me.cbClient = New ESL.myCheckBox(Me.components)
        Me.cbAE = New ESL.myCheckBox(Me.components)
        Me.comboAEFrom = New ESL.myComboBox(Me.components)
        Me.comboAETo = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExportS = New ESL.myButton(Me.components)
        Me.btnExportF = New ESL.myButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.cbOpen = New ESL.myCheckBox(Me.components)
        Me.cbActiveClient = New ESL.myCheckBox(Me.components)
        Me.cbClose = New ESL.myCheckBox(Me.components)
        Me.dtpTo2 = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom2 = New System.Windows.Forms.DateTimePicker
        Me.lbSuspendCode = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(536, 299)
        Me.btnCancel.TabIndex = 12
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(480, 299)
        '
        'txtClientFrom
        '
        Me.txtClientFrom.Enabled = False
        Me.txtClientFrom.Location = New System.Drawing.Point(97, 132)
        Me.txtClientFrom.Name = "txtClientFrom"
        Me.txtClientFrom.Size = New System.Drawing.Size(121, 21)
        Me.txtClientFrom.TabIndex = 2
        '
        'txtClientTo
        '
        Me.txtClientTo.Enabled = False
        Me.txtClientTo.Location = New System.Drawing.Point(224, 132)
        Me.txtClientTo.Name = "txtClientTo"
        Me.txtClientTo.Size = New System.Drawing.Size(121, 21)
        Me.txtClientTo.TabIndex = 3
        '
        'cbClient
        '
        Me.cbClient.AutoSize = True
        Me.cbClient.Location = New System.Drawing.Point(6, 134)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(58, 19)
        Me.cbClient.TabIndex = 1
        Me.cbClient.Text = "Client"
        Me.cbClient.UseVisualStyleBackColor = True
        '
        'cbAE
        '
        Me.cbAE.AutoSize = True
        Me.cbAE.Location = New System.Drawing.Point(6, 176)
        Me.cbAE.Name = "cbAE"
        Me.cbAE.Size = New System.Drawing.Size(74, 19)
        Me.cbAE.TabIndex = 4
        Me.cbAE.Text = "AE Code"
        Me.cbAE.UseVisualStyleBackColor = True
        '
        'comboAEFrom
        '
        Me.comboAEFrom.Enabled = False
        Me.comboAEFrom.FormattingEnabled = True
        Me.comboAEFrom.Location = New System.Drawing.Point(97, 174)
        Me.comboAEFrom.Name = "comboAEFrom"
        Me.comboAEFrom.Size = New System.Drawing.Size(121, 23)
        Me.comboAEFrom.TabIndex = 5
        '
        'comboAETo
        '
        Me.comboAETo.Enabled = False
        Me.comboAETo.FormattingEnabled = True
        Me.comboAETo.Location = New System.Drawing.Point(224, 174)
        Me.comboAETo.Name = "comboAETo"
        Me.comboAETo.Size = New System.Drawing.Size(121, 23)
        Me.comboAETo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Record Range"
        '
        'btnExportS
        '
        Me.btnExportS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportS.Location = New System.Drawing.Point(424, 299)
        Me.btnExportS.Name = "btnExportS"
        Me.btnExportS.Size = New System.Drawing.Size(50, 55)
        Me.btnExportS.TabIndex = 10
        Me.btnExportS.Text = "Export (S)"
        Me.btnExportS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportS.UseVisualStyleBackColor = True
        '
        'btnExportF
        '
        Me.btnExportF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportF.Location = New System.Drawing.Point(480, 299)
        Me.btnExportF.Name = "btnExportF"
        Me.btnExportF.Size = New System.Drawing.Size(50, 55)
        Me.btnExportF.TabIndex = 11
        Me.btnExportF.Text = "Export (F)"
        Me.btnExportF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportF.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(122, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 22)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Export Client Master (Email Only)"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "yyyy/MM/dd"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(97, 221)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(121, 21)
        Me.dtpFrom.TabIndex = 8
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "yyyy/MM/dd"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(224, 221)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(121, 21)
        Me.dtpTo.TabIndex = 9
        '
        'cbOpen
        '
        Me.cbOpen.AutoSize = True
        Me.cbOpen.Location = New System.Drawing.Point(6, 223)
        Me.cbOpen.Name = "cbOpen"
        Me.cbOpen.Size = New System.Drawing.Size(85, 19)
        Me.cbOpen.TabIndex = 7
        Me.cbOpen.Text = "Open Date"
        Me.cbOpen.UseVisualStyleBackColor = True
        '
        'cbActiveClient
        '
        Me.cbActiveClient.AutoSize = True
        Me.cbActiveClient.Checked = True
        Me.cbActiveClient.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActiveClient.Location = New System.Drawing.Point(6, 93)
        Me.cbActiveClient.Name = "cbActiveClient"
        Me.cbActiveClient.Size = New System.Drawing.Size(119, 19)
        Me.cbActiveClient.TabIndex = 16
        Me.cbActiveClient.Text = "Active Client Only"
        Me.cbActiveClient.UseVisualStyleBackColor = True
        '
        'cbClose
        '
        Me.cbClose.AutoSize = True
        Me.cbClose.Location = New System.Drawing.Point(6, 267)
        Me.cbClose.Name = "cbClose"
        Me.cbClose.Size = New System.Drawing.Size(88, 19)
        Me.cbClose.TabIndex = 17
        Me.cbClose.Text = "Close Date"
        Me.cbClose.UseVisualStyleBackColor = True
        '
        'dtpTo2
        '
        Me.dtpTo2.CustomFormat = "yyyy/MM/dd"
        Me.dtpTo2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo2.Location = New System.Drawing.Point(224, 265)
        Me.dtpTo2.Name = "dtpTo2"
        Me.dtpTo2.Size = New System.Drawing.Size(121, 21)
        Me.dtpTo2.TabIndex = 19
        '
        'dtpFrom2
        '
        Me.dtpFrom2.CustomFormat = "yyyy/MM/dd"
        Me.dtpFrom2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom2.Location = New System.Drawing.Point(97, 265)
        Me.dtpFrom2.Name = "dtpFrom2"
        Me.dtpFrom2.Size = New System.Drawing.Size(121, 21)
        Me.dtpFrom2.TabIndex = 18
        '
        'lbSuspendCode
        '
        Me.lbSuspendCode.Enabled = False
        Me.lbSuspendCode.FormattingEnabled = True
        Me.lbSuspendCode.ItemHeight = 15
        Me.lbSuspendCode.Location = New System.Drawing.Point(351, 72)
        Me.lbSuspendCode.Name = "lbSuspendCode"
        Me.lbSuspendCode.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lbSuspendCode.Size = New System.Drawing.Size(243, 214)
        Me.lbSuspendCode.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(348, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "With Suspend Reasons Only:"
        '
        'FrmClientMasterMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(598, 358)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbClose)
        Me.Controls.Add(Me.dtpTo2)
        Me.Controls.Add(Me.lbSuspendCode)
        Me.Controls.Add(Me.dtpFrom2)
        Me.Controls.Add(Me.cbActiveClient)
        Me.Controls.Add(Me.cbOpen)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboAETo)
        Me.Controls.Add(Me.btnExportF)
        Me.Controls.Add(Me.btnExportS)
        Me.Controls.Add(Me.comboAEFrom)
        Me.Controls.Add(Me.cbAE)
        Me.Controls.Add(Me.cbClient)
        Me.Controls.Add(Me.txtClientTo)
        Me.Controls.Add(Me.txtClientFrom)
        Me.KeyPreview = True
        Me.Name = "FrmClientMasterMail"
        Me.Text = "Export Client Master"
        Me.Controls.SetChildIndex(Me.txtClientFrom, 0)
        Me.Controls.SetChildIndex(Me.txtClientTo, 0)
        Me.Controls.SetChildIndex(Me.cbClient, 0)
        Me.Controls.SetChildIndex(Me.cbAE, 0)
        Me.Controls.SetChildIndex(Me.comboAEFrom, 0)
        Me.Controls.SetChildIndex(Me.btnExportS, 0)
        Me.Controls.SetChildIndex(Me.btnExportF, 0)
        Me.Controls.SetChildIndex(Me.comboAETo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dtpFrom, 0)
        Me.Controls.SetChildIndex(Me.dtpTo, 0)
        Me.Controls.SetChildIndex(Me.cbOpen, 0)
        Me.Controls.SetChildIndex(Me.cbActiveClient, 0)
        Me.Controls.SetChildIndex(Me.dtpFrom2, 0)
        Me.Controls.SetChildIndex(Me.lbSuspendCode, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dtpTo2, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.cbClose, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtClientFrom As ESL.myTextbox
    Friend WithEvents txtClientTo As ESL.myTextbox
    Friend WithEvents cbClient As ESL.myCheckBox
    Friend WithEvents cbAE As ESL.myCheckBox
    Friend WithEvents comboAEFrom As ESL.myComboBox
    Friend WithEvents comboAETo As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportS As ESL.myButton
    Friend WithEvents btnExportF As ESL.myButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbOpen As ESL.myCheckBox
    Friend WithEvents cbActiveClient As ESL.myCheckBox
    Friend WithEvents cbClose As ESL.myCheckBox
    Friend WithEvents dtpTo2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbSuspendCode As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
