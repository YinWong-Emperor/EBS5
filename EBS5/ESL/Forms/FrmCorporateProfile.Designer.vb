<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCorporateProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCorporateProfile))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAcc = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPrincipal = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMargin = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFund = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNature = New ESL.myTextbox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbOver5 = New ESL.myRadioButton(Me.components)
        Me.rbUnder1 = New ESL.myRadioButton(Me.components)
        Me.rb1to5 = New ESL.myRadioButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbShortTerm = New ESL.myCheckBox(Me.components)
        Me.cbMediumTerm = New ESL.myCheckBox(Me.components)
        Me.cbLongTerm = New ESL.myCheckBox(Me.components)
        Me.cbHedging = New ESL.myCheckBox(Me.components)
        Me.cbSpeculative = New ESL.myCheckBox(Me.components)
        Me.cbIPO = New ESL.myCheckBox(Me.components)
        Me.cbCapital = New ESL.myCheckBox(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbYes = New ESL.myRadioButton(Me.components)
        Me.rbNo = New ESL.myRadioButton(Me.components)
        Me.txtSum = New ESL.myTextbox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbTrader = New ESL.myRadioButton(Me.components)
        Me.rbInvestor = New ESL.myRadioButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnView = New ESL.myButton(Me.components)
        Me.btnClear = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(542, 511)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(318, 511)
        Me.btnSave.Visible = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(394, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Account No."
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(472, 63)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(120, 21)
        Me.txtAcc.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Company Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(135, 63)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(242, 21)
        Me.txtName.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Principal Place of Business"
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Location = New System.Drawing.Point(196, 143)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(396, 21)
        Me.txtPrincipal.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Related Margin Account No."
        '
        'txtMargin
        '
        Me.txtMargin.Location = New System.Drawing.Point(196, 103)
        Me.txtMargin.Name = "txtMargin"
        Me.txtMargin.Size = New System.Drawing.Size(181, 21)
        Me.txtMargin.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Funds"
        '
        'txtFund
        '
        Me.txtFund.Location = New System.Drawing.Point(196, 223)
        Me.txtFund.Name = "txtFund"
        Me.txtFund.Size = New System.Drawing.Size(396, 21)
        Me.txtFund.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Nature of Business"
        '
        'txtNature
        '
        Me.txtNature.Location = New System.Drawing.Point(196, 183)
        Me.txtNature.Name = "txtNature"
        Me.txtNature.Size = New System.Drawing.Size(396, 21)
        Me.txtNature.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbOver5)
        Me.GroupBox1.Controls.Add(Me.rbUnder1)
        Me.GroupBox1.Controls.Add(Me.rb1to5)
        Me.GroupBox1.Location = New System.Drawing.Point(180, 255)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 30)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'rbOver5
        '
        Me.rbOver5.AutoSize = True
        Me.rbOver5.Location = New System.Drawing.Point(271, 9)
        Me.rbOver5.Name = "rbOver5"
        Me.rbOver5.Size = New System.Drawing.Size(75, 19)
        Me.rbOver5.TabIndex = 28
        Me.rbOver5.TabStop = True
        Me.rbOver5.Text = "> 5 years"
        Me.rbOver5.UseVisualStyleBackColor = True
        '
        'rbUnder1
        '
        Me.rbUnder1.AutoSize = True
        Me.rbUnder1.Checked = True
        Me.rbUnder1.Location = New System.Drawing.Point(6, 9)
        Me.rbUnder1.Name = "rbUnder1"
        Me.rbUnder1.Size = New System.Drawing.Size(81, 19)
        Me.rbUnder1.TabIndex = 26
        Me.rbUnder1.TabStop = True
        Me.rbUnder1.Text = "0 to 1 year"
        Me.rbUnder1.UseVisualStyleBackColor = True
        '
        'rb1to5
        '
        Me.rb1to5.AutoSize = True
        Me.rb1to5.Location = New System.Drawing.Point(105, 9)
        Me.rb1to5.Name = "rb1to5"
        Me.rb1to5.Size = New System.Drawing.Size(142, 19)
        Me.rb1to5.TabIndex = 27
        Me.rb1to5.TabStop = True
        Me.rb1to5.Text = ">1 year and < 5 years"
        Me.rb1to5.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 15)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Investment Experience"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 346)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 15)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Investment Time Frame"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 306)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 15)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Investment Objective"
        '
        'cbShortTerm
        '
        Me.cbShortTerm.AutoSize = True
        Me.cbShortTerm.Location = New System.Drawing.Point(470, 346)
        Me.cbShortTerm.Name = "cbShortTerm"
        Me.cbShortTerm.Size = New System.Drawing.Size(88, 19)
        Me.cbShortTerm.TabIndex = 42
        Me.cbShortTerm.Text = "Short-Term"
        Me.cbShortTerm.UseVisualStyleBackColor = True
        '
        'cbMediumTerm
        '
        Me.cbMediumTerm.AutoSize = True
        Me.cbMediumTerm.Location = New System.Drawing.Point(328, 345)
        Me.cbMediumTerm.Name = "cbMediumTerm"
        Me.cbMediumTerm.Size = New System.Drawing.Size(103, 19)
        Me.cbMediumTerm.TabIndex = 41
        Me.cbMediumTerm.Text = "Medium-Term"
        Me.cbMediumTerm.UseVisualStyleBackColor = True
        '
        'cbLongTerm
        '
        Me.cbLongTerm.AutoSize = True
        Me.cbLongTerm.Location = New System.Drawing.Point(190, 345)
        Me.cbLongTerm.Name = "cbLongTerm"
        Me.cbLongTerm.Size = New System.Drawing.Size(87, 19)
        Me.cbLongTerm.TabIndex = 40
        Me.cbLongTerm.Text = "Long-Term"
        Me.cbLongTerm.UseVisualStyleBackColor = True
        '
        'cbHedging
        '
        Me.cbHedging.AutoSize = True
        Me.cbHedging.Location = New System.Drawing.Point(516, 305)
        Me.cbHedging.Name = "cbHedging"
        Me.cbHedging.Size = New System.Drawing.Size(73, 19)
        Me.cbHedging.TabIndex = 39
        Me.cbHedging.Text = "Hedging"
        Me.cbHedging.UseVisualStyleBackColor = True
        '
        'cbSpeculative
        '
        Me.cbSpeculative.AutoSize = True
        Me.cbSpeculative.Location = New System.Drawing.Point(327, 305)
        Me.cbSpeculative.Name = "cbSpeculative"
        Me.cbSpeculative.Size = New System.Drawing.Size(89, 19)
        Me.cbSpeculative.TabIndex = 37
        Me.cbSpeculative.Text = "Speculative"
        Me.cbSpeculative.UseVisualStyleBackColor = True
        '
        'cbIPO
        '
        Me.cbIPO.AutoSize = True
        Me.cbIPO.Location = New System.Drawing.Point(439, 305)
        Me.cbIPO.Name = "cbIPO"
        Me.cbIPO.Size = New System.Drawing.Size(46, 19)
        Me.cbIPO.TabIndex = 36
        Me.cbIPO.Text = "IPO"
        Me.cbIPO.UseVisualStyleBackColor = True
        '
        'cbCapital
        '
        Me.cbCapital.AutoSize = True
        Me.cbCapital.Location = New System.Drawing.Point(190, 305)
        Me.cbCapital.Name = "cbCapital"
        Me.cbCapital.Size = New System.Drawing.Size(135, 19)
        Me.cbCapital.TabIndex = 35
        Me.cbCapital.Text = "Capital Preservative"
        Me.cbCapital.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 466)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 15)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Knowledgeable Investor"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbYes)
        Me.GroupBox2.Controls.Add(Me.rbNo)
        Me.GroupBox2.Location = New System.Drawing.Point(180, 453)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(106, 30)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
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
        'txtSum
        '
        Me.txtSum.Location = New System.Drawing.Point(196, 383)
        Me.txtSum.Name = "txtSum"
        Me.txtSum.Size = New System.Drawing.Size(181, 21)
        Me.txtSum.TabIndex = 45
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbTrader)
        Me.GroupBox3.Controls.Add(Me.rbInvestor)
        Me.GroupBox3.Location = New System.Drawing.Point(180, 414)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(145, 30)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 426)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 15)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Trader or Investor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(32, 386)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 15)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Sum Likely to Invest"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(200, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(227, 22)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Corporate Client Profile"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(486, 511)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 54
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnView.Location = New System.Drawing.Point(430, 511)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(50, 55)
        Me.btnView.TabIndex = 53
        Me.btnView.Text = "View"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(374, 511)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(50, 55)
        Me.btnClear.TabIndex = 52
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'FrmCorporateProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(640, 615)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtSum)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbShortTerm)
        Me.Controls.Add(Me.cbMediumTerm)
        Me.Controls.Add(Me.cbLongTerm)
        Me.Controls.Add(Me.cbHedging)
        Me.Controls.Add(Me.cbSpeculative)
        Me.Controls.Add(Me.cbIPO)
        Me.Controls.Add(Me.cbCapital)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFund)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNature)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPrincipal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMargin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAcc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.KeyPreview = True
        Me.Name = "FrmCorporateProfile"
        Me.Text = "Corporate Client Profile"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtAcc, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtMargin, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtPrincipal, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtNature, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtFund, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cbCapital, 0)
        Me.Controls.SetChildIndex(Me.cbIPO, 0)
        Me.Controls.SetChildIndex(Me.cbSpeculative, 0)
        Me.Controls.SetChildIndex(Me.cbHedging, 0)
        Me.Controls.SetChildIndex(Me.cbLongTerm, 0)
        Me.Controls.SetChildIndex(Me.cbMediumTerm, 0)
        Me.Controls.SetChildIndex(Me.cbShortTerm, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.txtSum, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.btnClear, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAcc As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrincipal As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMargin As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFund As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNature As ESL.myTextbox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbUnder1 As ESL.myRadioButton
    Friend WithEvents rb1to5 As ESL.myRadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbShortTerm As ESL.myCheckBox
    Friend WithEvents cbMediumTerm As ESL.myCheckBox
    Friend WithEvents cbLongTerm As ESL.myCheckBox
    Friend WithEvents cbHedging As ESL.myCheckBox
    Friend WithEvents cbSpeculative As ESL.myCheckBox
    Friend WithEvents cbIPO As ESL.myCheckBox
    Friend WithEvents cbCapital As ESL.myCheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbYes As ESL.myRadioButton
    Friend WithEvents rbNo As ESL.myRadioButton
    Friend WithEvents txtSum As ESL.myTextbox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTrader As ESL.myRadioButton
    Friend WithEvents rbInvestor As ESL.myRadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbOver5 As ESL.myRadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnView As ESL.myButton
    Friend WithEvents btnClear As ESL.myButton

End Class
