<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientProfile))
        Me.txtName = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAcc = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMargin = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtOccupation = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtIncome = New ESL.myTextbox
        Me.cbCapital = New ESL.myCheckBox(Me.components)
        Me.cbIPO = New ESL.myCheckBox(Me.components)
        Me.cbSpeculative = New ESL.myCheckBox(Me.components)
        Me.cbGrowth = New ESL.myCheckBox(Me.components)
        Me.cbHedging = New ESL.myCheckBox(Me.components)
        Me.cbLongTerm = New ESL.myCheckBox(Me.components)
        Me.cbMediumTerm = New ESL.myCheckBox(Me.components)
        Me.cbShortTerm = New ESL.myCheckBox(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSum = New ESL.myTextbox
        Me.rbTrader = New ESL.myRadioButton(Me.components)
        Me.rbInvestor = New ESL.myRadioButton(Me.components)
        Me.rbYes = New ESL.myRadioButton(Me.components)
        Me.rbNo = New ESL.myRadioButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnClear = New ESL.myButton(Me.components)
        Me.btnView = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(523, 495)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(299, 495)
        Me.btnSave.Visible = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(146, 63)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(188, 21)
        Me.txtName.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(361, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Account No."
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(439, 63)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(120, 21)
        Me.txtAcc.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Related Margin Account No."
        '
        'txtMargin
        '
        Me.txtMargin.Location = New System.Drawing.Point(214, 108)
        Me.txtMargin.Name = "txtMargin"
        Me.txtMargin.Size = New System.Drawing.Size(120, 21)
        Me.txtMargin.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Occupation"
        '
        'txtOccupation
        '
        Me.txtOccupation.Location = New System.Drawing.Point(142, 153)
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.Size = New System.Drawing.Size(192, 21)
        Me.txtOccupation.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Gross Income (per year)"
        '
        'txtIncome
        '
        Me.txtIncome.Location = New System.Drawing.Point(214, 198)
        Me.txtIncome.Name = "txtIncome"
        Me.txtIncome.Size = New System.Drawing.Size(120, 21)
        Me.txtIncome.TabIndex = 14
        '
        'cbCapital
        '
        Me.cbCapital.AutoSize = True
        Me.cbCapital.Location = New System.Drawing.Point(203, 245)
        Me.cbCapital.Name = "cbCapital"
        Me.cbCapital.Size = New System.Drawing.Size(135, 19)
        Me.cbCapital.TabIndex = 16
        Me.cbCapital.Text = "Capital Preservative"
        Me.cbCapital.UseVisualStyleBackColor = True
        '
        'cbIPO
        '
        Me.cbIPO.AutoSize = True
        Me.cbIPO.Location = New System.Drawing.Point(203, 270)
        Me.cbIPO.Name = "cbIPO"
        Me.cbIPO.Size = New System.Drawing.Size(46, 19)
        Me.cbIPO.TabIndex = 17
        Me.cbIPO.Text = "IPO"
        Me.cbIPO.UseVisualStyleBackColor = True
        '
        'cbSpeculative
        '
        Me.cbSpeculative.AutoSize = True
        Me.cbSpeculative.Location = New System.Drawing.Point(344, 245)
        Me.cbSpeculative.Name = "cbSpeculative"
        Me.cbSpeculative.Size = New System.Drawing.Size(89, 19)
        Me.cbSpeculative.TabIndex = 18
        Me.cbSpeculative.Text = "Speculative"
        Me.cbSpeculative.UseVisualStyleBackColor = True
        '
        'cbGrowth
        '
        Me.cbGrowth.AutoSize = True
        Me.cbGrowth.Location = New System.Drawing.Point(485, 245)
        Me.cbGrowth.Name = "cbGrowth"
        Me.cbGrowth.Size = New System.Drawing.Size(65, 19)
        Me.cbGrowth.TabIndex = 19
        Me.cbGrowth.Text = "Growth"
        Me.cbGrowth.UseVisualStyleBackColor = True
        '
        'cbHedging
        '
        Me.cbHedging.AutoSize = True
        Me.cbHedging.Location = New System.Drawing.Point(344, 270)
        Me.cbHedging.Name = "cbHedging"
        Me.cbHedging.Size = New System.Drawing.Size(73, 19)
        Me.cbHedging.TabIndex = 20
        Me.cbHedging.Text = "Hedging"
        Me.cbHedging.UseVisualStyleBackColor = True
        '
        'cbLongTerm
        '
        Me.cbLongTerm.AutoSize = True
        Me.cbLongTerm.Location = New System.Drawing.Point(203, 311)
        Me.cbLongTerm.Name = "cbLongTerm"
        Me.cbLongTerm.Size = New System.Drawing.Size(87, 19)
        Me.cbLongTerm.TabIndex = 21
        Me.cbLongTerm.Text = "Long-Term"
        Me.cbLongTerm.UseVisualStyleBackColor = True
        '
        'cbMediumTerm
        '
        Me.cbMediumTerm.AutoSize = True
        Me.cbMediumTerm.Location = New System.Drawing.Point(344, 311)
        Me.cbMediumTerm.Name = "cbMediumTerm"
        Me.cbMediumTerm.Size = New System.Drawing.Size(103, 19)
        Me.cbMediumTerm.TabIndex = 22
        Me.cbMediumTerm.Text = "Medium-Term"
        Me.cbMediumTerm.UseVisualStyleBackColor = True
        '
        'cbShortTerm
        '
        Me.cbShortTerm.AutoSize = True
        Me.cbShortTerm.Location = New System.Drawing.Point(485, 311)
        Me.cbShortTerm.Name = "cbShortTerm"
        Me.cbShortTerm.Size = New System.Drawing.Size(88, 19)
        Me.cbShortTerm.TabIndex = 23
        Me.cbShortTerm.Text = "Short-Term"
        Me.cbShortTerm.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 353)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Sum Likely to Invest (per year)"
        '
        'txtSum
        '
        Me.txtSum.Location = New System.Drawing.Point(214, 350)
        Me.txtSum.Name = "txtSum"
        Me.txtSum.Size = New System.Drawing.Size(120, 21)
        Me.txtSum.TabIndex = 24
        '
        'rbTrader
        '
        Me.rbTrader.AutoSize = True
        Me.rbTrader.Checked = True
        Me.rbTrader.Location = New System.Drawing.Point(6, 9)
        Me.rbTrader.Name = "rbTrader"
        Me.rbTrader.Size = New System.Drawing.Size(61, 19)
        Me.rbTrader.TabIndex = 26
        Me.rbTrader.TabStop = True
        Me.rbTrader.Text = "Trader"
        Me.rbTrader.UseVisualStyleBackColor = True
        '
        'rbInvestor
        '
        Me.rbInvestor.AutoSize = True
        Me.rbInvestor.Location = New System.Drawing.Point(73, 9)
        Me.rbInvestor.Name = "rbInvestor"
        Me.rbInvestor.Size = New System.Drawing.Size(68, 19)
        Me.rbInvestor.TabIndex = 27
        Me.rbInvestor.TabStop = True
        Me.rbInvestor.Text = "Investor"
        Me.rbInvestor.UseVisualStyleBackColor = True
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Checked = True
        Me.rbYes.Location = New System.Drawing.Point(6, 9)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(46, 19)
        Me.rbYes.TabIndex = 28
        Me.rbYes.TabStop = True
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(58, 9)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(41, 19)
        Me.rbNo.TabIndex = 29
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 398)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Trader or Investor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTrader)
        Me.GroupBox1.Controls.Add(Me.rbInvestor)
        Me.GroupBox1.Location = New System.Drawing.Point(189, 386)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(145, 30)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Investment Objective"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(39, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 15)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Investment Time Frame"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbYes)
        Me.GroupBox2.Controls.Add(Me.rbNo)
        Me.GroupBox2.Location = New System.Drawing.Point(228, 431)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(106, 30)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 443)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 15)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Knowledgeable Investor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(241, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 22)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Client Profile"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(355, 495)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(50, 55)
        Me.btnClear.TabIndex = 38
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnView.Location = New System.Drawing.Point(411, 495)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(50, 55)
        Me.btnView.TabIndex = 39
        Me.btnView.Text = "View"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(467, 495)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 40
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'FrmClientProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(606, 592)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSum)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbShortTerm)
        Me.Controls.Add(Me.cbMediumTerm)
        Me.Controls.Add(Me.cbLongTerm)
        Me.Controls.Add(Me.cbHedging)
        Me.Controls.Add(Me.cbGrowth)
        Me.Controls.Add(Me.cbSpeculative)
        Me.Controls.Add(Me.cbIPO)
        Me.Controls.Add(Me.cbCapital)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIncome)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOccupation)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMargin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAcc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.KeyPreview = True
        Me.Name = "FrmClientProfile"
        Me.Text = "Client Profile"
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.txtAcc, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtMargin, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtOccupation, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtIncome, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cbCapital, 0)
        Me.Controls.SetChildIndex(Me.cbIPO, 0)
        Me.Controls.SetChildIndex(Me.cbSpeculative, 0)
        Me.Controls.SetChildIndex(Me.cbGrowth, 0)
        Me.Controls.SetChildIndex(Me.cbHedging, 0)
        Me.Controls.SetChildIndex(Me.cbLongTerm, 0)
        Me.Controls.SetChildIndex(Me.cbMediumTerm, 0)
        Me.Controls.SetChildIndex(Me.cbShortTerm, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.txtSum, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnClear, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAcc As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMargin As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOccupation As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIncome As ESL.myTextbox
    Friend WithEvents cbCapital As ESL.myCheckBox
    Friend WithEvents cbIPO As ESL.myCheckBox
    Friend WithEvents cbSpeculative As ESL.myCheckBox
    Friend WithEvents cbGrowth As ESL.myCheckBox
    Friend WithEvents cbHedging As ESL.myCheckBox
    Friend WithEvents cbLongTerm As ESL.myCheckBox
    Friend WithEvents cbMediumTerm As ESL.myCheckBox
    Friend WithEvents cbShortTerm As ESL.myCheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSum As ESL.myTextbox
    Friend WithEvents rbTrader As ESL.myRadioButton
    Friend WithEvents rbInvestor As ESL.myRadioButton
    Friend WithEvents rbYes As ESL.myRadioButton
    Friend WithEvents rbNo As ESL.myRadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnClear As ESL.myButton
    Friend WithEvents btnView As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton

End Class
