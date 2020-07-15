<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonthToDate
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
        Me.cbClientTurnoverS = New ESL.myCheckBox(Me.components)
        Me.cbMarginInOutS = New ESL.myCheckBox(Me.components)
        Me.cbNewClientF = New ESL.myCheckBox(Me.components)
        Me.cbNewClientS = New ESL.myCheckBox(Me.components)
        Me.cbClientTurnoverF = New ESL.myCheckBox(Me.components)
        Me.dpFrom = New ESL.myDateTimePicker()
        Me.dpTo = New ESL.myDateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbEIEHK = New ESL.myCheckBox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLstTxnStock = New System.Windows.Forms.Label()
        Me.lblLstTxnFutures = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(474, 271)
        Me.btnCancel.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Image = Global.ESL.My.Resources.Resources.export
        Me.btnSave.Location = New System.Drawing.Point(422, 271)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Export"
        Me.btnSave.Visible = True
        '
        'cbClientTurnoverS
        '
        Me.cbClientTurnoverS.AutoSize = True
        Me.cbClientTurnoverS.Checked = True
        Me.cbClientTurnoverS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbClientTurnoverS.Location = New System.Drawing.Point(16, 19)
        Me.cbClientTurnoverS.Name = "cbClientTurnoverS"
        Me.cbClientTurnoverS.Size = New System.Drawing.Size(149, 19)
        Me.cbClientTurnoverS.TabIndex = 0
        Me.cbClientTurnoverS.Text = "Stock Clients Turnover"
        Me.cbClientTurnoverS.UseVisualStyleBackColor = True
        '
        'cbMarginInOutS
        '
        Me.cbMarginInOutS.AutoSize = True
        Me.cbMarginInOutS.Checked = True
        Me.cbMarginInOutS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMarginInOutS.Location = New System.Drawing.Point(16, 89)
        Me.cbMarginInOutS.Name = "cbMarginInOutS"
        Me.cbMarginInOutS.Size = New System.Drawing.Size(201, 19)
        Me.cbMarginInOutS.TabIndex = 4
        Me.cbMarginInOutS.Text = "Stock Margin In/Out (China Dev.)"
        Me.cbMarginInOutS.UseVisualStyleBackColor = True
        '
        'cbNewClientF
        '
        Me.cbNewClientF.AutoSize = True
        Me.cbNewClientF.Checked = True
        Me.cbNewClientF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNewClientF.Location = New System.Drawing.Point(257, 54)
        Me.cbNewClientF.Name = "cbNewClientF"
        Me.cbNewClientF.Size = New System.Drawing.Size(138, 19)
        Me.cbNewClientF.TabIndex = 3
        Me.cbNewClientF.Text = "Futures New Clients"
        Me.cbNewClientF.UseVisualStyleBackColor = True
        '
        'cbNewClientS
        '
        Me.cbNewClientS.AutoSize = True
        Me.cbNewClientS.Checked = True
        Me.cbNewClientS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNewClientS.Location = New System.Drawing.Point(16, 54)
        Me.cbNewClientS.Name = "cbNewClientS"
        Me.cbNewClientS.Size = New System.Drawing.Size(126, 19)
        Me.cbNewClientS.TabIndex = 2
        Me.cbNewClientS.Text = "Stock New Clients"
        Me.cbNewClientS.UseVisualStyleBackColor = True
        '
        'cbClientTurnoverF
        '
        Me.cbClientTurnoverF.AutoSize = True
        Me.cbClientTurnoverF.Checked = True
        Me.cbClientTurnoverF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbClientTurnoverF.Location = New System.Drawing.Point(257, 19)
        Me.cbClientTurnoverF.Name = "cbClientTurnoverF"
        Me.cbClientTurnoverF.Size = New System.Drawing.Size(161, 19)
        Me.cbClientTurnoverF.TabIndex = 1
        Me.cbClientTurnoverF.Text = "Futures Clients Turnover"
        Me.cbClientTurnoverF.UseVisualStyleBackColor = True
        '
        'dpFrom
        '
        Me.dpFrom.CustomFormat = "dd/MM/yyyy"
        Me.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFrom.Location = New System.Drawing.Point(16, 136)
        Me.dpFrom.Name = "dpFrom"
        Me.dpFrom.Size = New System.Drawing.Size(100, 21)
        Me.dpFrom.TabIndex = 6
        '
        'dpTo
        '
        Me.dpTo.CustomFormat = "dd/MM/yyyy"
        Me.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpTo.Location = New System.Drawing.Point(136, 136)
        Me.dpTo.Name = "dpTo"
        Me.dpTo.Size = New System.Drawing.Size(100, 21)
        Me.dpTo.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(141, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 22)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Month To Date Report"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(116, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "To"
        '
        'cbEIEHK
        '
        Me.cbEIEHK.AutoSize = True
        Me.cbEIEHK.Checked = True
        Me.cbEIEHK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEIEHK.Location = New System.Drawing.Point(257, 89)
        Me.cbEIEHK.Name = "cbEIEHK"
        Me.cbEIEHK.Size = New System.Drawing.Size(104, 19)
        Me.cbEIEHK.TabIndex = 5
        Me.cbEIEHK.Text = "EIEHK Clients"
        Me.cbEIEHK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(222, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Please specific period (DD / MM / YYYY)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(254, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Stock last trade date : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(254, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Futures last trade date : "
        '
        'lblLstTxnStock
        '
        Me.lblLstTxnStock.AutoSize = True
        Me.lblLstTxnStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblLstTxnStock.Location = New System.Drawing.Point(377, 131)
        Me.lblLstTxnStock.Name = "lblLstTxnStock"
        Me.lblLstTxnStock.Size = New System.Drawing.Size(13, 15)
        Me.lblLstTxnStock.TabIndex = 17
        Me.lblLstTxnStock.Text = "  "
        '
        'lblLstTxnFutures
        '
        Me.lblLstTxnFutures.AutoSize = True
        Me.lblLstTxnFutures.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblLstTxnFutures.Location = New System.Drawing.Point(389, 146)
        Me.lblLstTxnFutures.Name = "lblLstTxnFutures"
        Me.lblLstTxnFutures.Size = New System.Drawing.Size(13, 15)
        Me.lblLstTxnFutures.TabIndex = 17
        Me.lblLstTxnFutures.Text = "  "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblLstTxnFutures)
        Me.GroupBox1.Controls.Add(Me.lblLstTxnStock)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbEIEHK)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dpTo)
        Me.GroupBox1.Controls.Add(Me.dpFrom)
        Me.GroupBox1.Controls.Add(Me.cbClientTurnoverF)
        Me.GroupBox1.Controls.Add(Me.cbNewClientS)
        Me.GroupBox1.Controls.Add(Me.cbNewClientF)
        Me.GroupBox1.Controls.Add(Me.cbMarginInOutS)
        Me.GroupBox1.Controls.Add(Me.cbClientTurnoverS)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 198)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'FrmMonthToDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(554, 339)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmMonthToDate"
        Me.Text = "Month To Date Report"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbClientTurnoverS As ESL.myCheckBox
    Friend WithEvents cbMarginInOutS As ESL.myCheckBox
    Friend WithEvents cbNewClientF As ESL.myCheckBox
    Friend WithEvents cbNewClientS As ESL.myCheckBox
    Friend WithEvents cbClientTurnoverF As ESL.myCheckBox
    Friend WithEvents dpFrom As ESL.myDateTimePicker
    Friend WithEvents dpTo As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbEIEHK As ESL.myCheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLstTxnStock As System.Windows.Forms.Label
    Friend WithEvents lblLstTxnFutures As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
