<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExptClientBal
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
        Me.btnNewGroup = New ESL.myButton(Me.components)
        Me.txtGroup = New ESL.myTextbox
        Me.btnEditGroup = New ESL.myButton(Me.components)
        Me.btnAddAcc = New ESL.myButton(Me.components)
        Me.txtAcc = New ESL.myTextbox
        Me.rb1 = New ESL.myRadioButton(Me.components)
        Me.rb2 = New ESL.myRadioButton(Me.components)
        Me.rb3 = New ESL.myRadioButton(Me.components)
        Me.btnDown = New ESL.myButton(Me.components)
        Me.btnUp = New ESL.myButton(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblSelAcc = New System.Windows.Forms.Label
        Me.lbSelAcc = New ESL.myListBox(Me.components)
        Me.btnMove = New ESL.myButton(Me.components)
        Me.cbSelAcc = New ESL.myCheckBox(Me.components)
        Me.btnExport = New ESL.myButton(Me.components)
        Me.btnReset = New ESL.myButton(Me.components)
        Me.lbGroup = New ESL.myListBox(Me.components)
        Me.lbAcc = New ESL.myListBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblAccCount = New System.Windows.Forms.Label
        Me.dpledger = New ESL.myDateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(518, 447)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(406, 447)
        Me.btnSave.Visible = True
        '
        'btnNewGroup
        '
        Me.btnNewGroup.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnNewGroup.Location = New System.Drawing.Point(33, 70)
        Me.btnNewGroup.Name = "btnNewGroup"
        Me.btnNewGroup.Size = New System.Drawing.Size(77, 24)
        Me.btnNewGroup.TabIndex = 6
        Me.btnNewGroup.Text = "New Group"
        Me.btnNewGroup.UseVisualStyleBackColor = True
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(33, 100)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(150, 21)
        Me.txtGroup.TabIndex = 7
        '
        'btnEditGroup
        '
        Me.btnEditGroup.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnEditGroup.Location = New System.Drawing.Point(110, 70)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.Size = New System.Drawing.Size(73, 24)
        Me.btnEditGroup.TabIndex = 8
        Me.btnEditGroup.Text = "Edit Group"
        Me.btnEditGroup.UseVisualStyleBackColor = True
        '
        'btnAddAcc
        '
        Me.btnAddAcc.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnAddAcc.Location = New System.Drawing.Point(207, 70)
        Me.btnAddAcc.Name = "btnAddAcc"
        Me.btnAddAcc.Size = New System.Drawing.Size(150, 24)
        Me.btnAddAcc.TabIndex = 10
        Me.btnAddAcc.Text = "Add Client"
        Me.btnAddAcc.UseVisualStyleBackColor = True
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(207, 100)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(150, 21)
        Me.txtAcc.TabIndex = 9
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Checked = True
        Me.rb1.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.rb1.Location = New System.Drawing.Point(33, 355)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(478, 18)
        Me.rb1.TabIndex = 11
        Me.rb1.TabStop = True
        Me.rb1.Text = "[accbal.xls] = ledger balance, interest, margin value, margin ratio, market value" & _
            " and actual ratio"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.rb2.Location = New System.Drawing.Point(33, 379)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(255, 18)
        Me.rb2.TabIndex = 12
        Me.rb2.Text = "[accbalsummary.xls] = ledger balance + interest"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb3
        '
        Me.rb3.AutoSize = True
        Me.rb3.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.rb3.Location = New System.Drawing.Point(33, 403)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(386, 18)
        Me.rb3.TabIndex = 13
        Me.rb3.Text = "[accbal_date.xls] = ledger balance, available balance for specific trade day"
        Me.rb3.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnDown.Location = New System.Drawing.Point(333, 234)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(24, 92)
        Me.btnDown.TabIndex = 14
        Me.btnDown.Text = "Dn"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnUp.Location = New System.Drawing.Point(333, 142)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(24, 92)
        Me.btnUp.TabIndex = 15
        Me.btnUp.Text = "Up"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblSelAcc)
        Me.Panel1.Controls.Add(Me.lbSelAcc)
        Me.Panel1.Controls.Add(Me.btnMove)
        Me.Panel1.Controls.Add(Me.cbSelAcc)
        Me.Panel1.Location = New System.Drawing.Point(378, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(190, 256)
        Me.Panel1.TabIndex = 16
        '
        'lblSelAcc
        '
        Me.lblSelAcc.AutoSize = True
        Me.lblSelAcc.Location = New System.Drawing.Point(9, 238)
        Me.lblSelAcc.Name = "lblSelAcc"
        Me.lblSelAcc.Size = New System.Drawing.Size(0, 15)
        Me.lblSelAcc.TabIndex = 22
        '
        'lbSelAcc
        '
        Me.lbSelAcc.FormattingEnabled = True
        Me.lbSelAcc.ItemHeight = 15
        Me.lbSelAcc.Location = New System.Drawing.Point(60, 40)
        Me.lbSelAcc.Name = "lbSelAcc"
        Me.lbSelAcc.Size = New System.Drawing.Size(109, 184)
        Me.lbSelAcc.TabIndex = 21
        '
        'btnMove
        '
        Me.btnMove.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnMove.Location = New System.Drawing.Point(17, 40)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(37, 24)
        Me.btnMove.TabIndex = 17
        Me.btnMove.Text = "<"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'cbSelAcc
        '
        Me.cbSelAcc.AutoSize = True
        Me.cbSelAcc.Location = New System.Drawing.Point(17, 15)
        Me.cbSelAcc.Name = "cbSelAcc"
        Me.cbSelAcc.Size = New System.Drawing.Size(141, 19)
        Me.cbSelAcc.TabIndex = 17
        Me.cbSelAcc.Text = "For Selected Account"
        Me.cbSelAcc.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnExport.Location = New System.Drawing.Point(350, 447)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 17
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnReset.Location = New System.Drawing.Point(462, 447)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(50, 55)
        Me.btnReset.TabIndex = 18
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lbGroup
        '
        Me.lbGroup.FormattingEnabled = True
        Me.lbGroup.ItemHeight = 15
        Me.lbGroup.Location = New System.Drawing.Point(33, 142)
        Me.lbGroup.Name = "lbGroup"
        Me.lbGroup.Size = New System.Drawing.Size(150, 184)
        Me.lbGroup.TabIndex = 19
        '
        'lbAcc
        '
        Me.lbAcc.FormattingEnabled = True
        Me.lbAcc.ItemHeight = 15
        Me.lbAcc.Location = New System.Drawing.Point(207, 142)
        Me.lbAcc.Name = "lbAcc"
        Me.lbAcc.Size = New System.Drawing.Size(126, 184)
        Me.lbAcc.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Group"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(177, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(249, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Export Client Balance List"
        '
        'lblAccCount
        '
        Me.lblAccCount.AutoSize = True
        Me.lblAccCount.Location = New System.Drawing.Point(204, 329)
        Me.lblAccCount.Name = "lblAccCount"
        Me.lblAccCount.Size = New System.Drawing.Size(0, 15)
        Me.lblAccCount.TabIndex = 23
        '
        'dpledger
        '
        Me.dpledger.CustomFormat = "dd MMM yyyy"
        Me.dpledger.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpledger.Location = New System.Drawing.Point(424, 401)
        Me.dpledger.Name = "dpledger"
        Me.dpledger.Size = New System.Drawing.Size(101, 21)
        Me.dpledger.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(204, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Client"
        '
        'FrmExptClientBal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(601, 539)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dpledger)
        Me.Controls.Add(Me.lblAccCount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbAcc)
        Me.Controls.Add(Me.lbGroup)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.rb3)
        Me.Controls.Add(Me.rb2)
        Me.Controls.Add(Me.rb1)
        Me.Controls.Add(Me.txtAcc)
        Me.Controls.Add(Me.btnAddAcc)
        Me.Controls.Add(Me.btnEditGroup)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.btnNewGroup)
        Me.KeyPreview = True
        Me.Name = "FrmExptClientBal"
        Me.Text = "Export Client Balance List"
        Me.Controls.SetChildIndex(Me.btnNewGroup, 0)
        Me.Controls.SetChildIndex(Me.txtGroup, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnEditGroup, 0)
        Me.Controls.SetChildIndex(Me.btnAddAcc, 0)
        Me.Controls.SetChildIndex(Me.txtAcc, 0)
        Me.Controls.SetChildIndex(Me.rb1, 0)
        Me.Controls.SetChildIndex(Me.rb2, 0)
        Me.Controls.SetChildIndex(Me.rb3, 0)
        Me.Controls.SetChildIndex(Me.btnUp, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.btnDown, 0)
        Me.Controls.SetChildIndex(Me.lbGroup, 0)
        Me.Controls.SetChildIndex(Me.lbAcc, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lblAccCount, 0)
        Me.Controls.SetChildIndex(Me.dpledger, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNewGroup As ESL.myButton
    Friend WithEvents txtGroup As ESL.myTextbox
    Friend WithEvents btnEditGroup As ESL.myButton
    Friend WithEvents btnAddAcc As ESL.myButton
    Friend WithEvents txtAcc As ESL.myTextbox
    Friend WithEvents rb1 As ESL.myRadioButton
    Friend WithEvents rb2 As ESL.myRadioButton
    Friend WithEvents rb3 As ESL.myRadioButton
    Friend WithEvents btnDown As ESL.myButton
    Friend WithEvents btnUp As ESL.myButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbSelAcc As ESL.myCheckBox
    Friend WithEvents btnMove As ESL.myButton
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents btnReset As ESL.myButton
    Friend WithEvents lbSelAcc As ESL.myListBox
    Friend WithEvents lbGroup As ESL.myListBox
    Friend WithEvents lbAcc As ESL.myListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSelAcc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAccCount As System.Windows.Forms.Label
    Friend WithEvents dpledger As ESL.myDateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
