<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTopComm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTopComm))
        Me.nudFromMonth = New ESL.myNumericUpDown(Me.components)
        Me.nudFromYr = New ESL.myNumericUpDown(Me.components)
        Me.RBCash = New ESL.myRadioButton(Me.components)
        Me.RBMargin = New ESL.myRadioButton(Me.components)
        Me.RBFutures = New ESL.myRadioButton(Me.components)
        Me.nudTopMost = New ESL.myNumericUpDown(Me.components)
        Me.RBStock = New ESL.myRadioButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudToYr = New ESL.myNumericUpDown(Me.components)
        Me.nudToMonth = New ESL.myNumericUpDown(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnView = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.nudFromMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFromYr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTopMost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudToYr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudToMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(431, 267)
        Me.btnCancel.Size = New System.Drawing.Size(60, 55)
        Me.btnCancel.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(375, 267)
        '
        'nudFromMonth
        '
        Me.nudFromMonth.Location = New System.Drawing.Point(164, 112)
        Me.nudFromMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudFromMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFromMonth.Name = "nudFromMonth"
        Me.nudFromMonth.Size = New System.Drawing.Size(48, 21)
        Me.nudFromMonth.TabIndex = 7
        Me.nudFromMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudFromYr
        '
        Me.nudFromYr.Location = New System.Drawing.Point(98, 112)
        Me.nudFromYr.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.nudFromYr.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.nudFromYr.Name = "nudFromYr"
        Me.nudFromYr.Size = New System.Drawing.Size(60, 21)
        Me.nudFromYr.TabIndex = 6
        Me.nudFromYr.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'RBCash
        '
        Me.RBCash.AutoSize = True
        Me.RBCash.Checked = True
        Me.RBCash.Location = New System.Drawing.Point(184, 64)
        Me.RBCash.Name = "RBCash"
        Me.RBCash.Size = New System.Drawing.Size(55, 19)
        Me.RBCash.TabIndex = 4
        Me.RBCash.TabStop = True
        Me.RBCash.Text = "Cash"
        Me.RBCash.UseVisualStyleBackColor = True
        '
        'RBMargin
        '
        Me.RBMargin.AutoSize = True
        Me.RBMargin.Location = New System.Drawing.Point(245, 64)
        Me.RBMargin.Name = "RBMargin"
        Me.RBMargin.Size = New System.Drawing.Size(62, 19)
        Me.RBMargin.TabIndex = 5
        Me.RBMargin.Text = "Margin"
        Me.RBMargin.UseVisualStyleBackColor = True
        '
        'RBFutures
        '
        Me.RBFutures.AutoSize = True
        Me.RBFutures.Location = New System.Drawing.Point(67, 8)
        Me.RBFutures.Name = "RBFutures"
        Me.RBFutures.Size = New System.Drawing.Size(67, 19)
        Me.RBFutures.TabIndex = 2
        Me.RBFutures.Text = "Futures"
        Me.RBFutures.UseVisualStyleBackColor = True
        '
        'nudTopMost
        '
        Me.nudTopMost.Location = New System.Drawing.Point(98, 62)
        Me.nudTopMost.Name = "nudTopMost"
        Me.nudTopMost.Size = New System.Drawing.Size(48, 21)
        Me.nudTopMost.TabIndex = 3
        Me.nudTopMost.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'RBStock
        '
        Me.RBStock.AutoSize = True
        Me.RBStock.Checked = True
        Me.RBStock.Location = New System.Drawing.Point(6, 8)
        Me.RBStock.Name = "RBStock"
        Me.RBStock.Size = New System.Drawing.Size(55, 19)
        Me.RBStock.TabIndex = 1
        Me.RBStock.TabStop = True
        Me.RBStock.Text = "Stock"
        Me.RBStock.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Topmost"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(111, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Year"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(168, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Month"
        '
        'nudToYr
        '
        Me.nudToYr.Location = New System.Drawing.Point(270, 112)
        Me.nudToYr.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.nudToYr.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.nudToYr.Name = "nudToYr"
        Me.nudToYr.Size = New System.Drawing.Size(60, 21)
        Me.nudToYr.TabIndex = 8
        Me.nudToYr.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'nudToMonth
        '
        Me.nudToMonth.Location = New System.Drawing.Point(336, 112)
        Me.nudToMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudToMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudToMonth.Name = "nudToMonth"
        Me.nudToMonth.Size = New System.Drawing.Size(48, 21)
        Me.nudToMonth.TabIndex = 9
        Me.nudToMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(340, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Month"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(283, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Year"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnView.Location = New System.Drawing.Point(365, 267)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(60, 54)
        Me.btnView.TabIndex = 10
        Me.btnView.Text = "Enquiry"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnView.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBFutures)
        Me.GroupBox1.Controls.Add(Me.RBStock)
        Me.GroupBox1.Location = New System.Drawing.Point(309, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 37)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudTopMost)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.nudFromMonth)
        Me.GroupBox2.Controls.Add(Me.nudFromYr)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.RBCash)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.RBMargin)
        Me.GroupBox2.Controls.Add(Me.nudToYr)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.nudToMonth)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(468, 175)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(117, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(258, 22)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Client of Most Commission"
        '
        'FrmTopComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(503, 349)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnView)
        Me.KeyPreview = True
        Me.Name = "FrmTopComm"
        Me.Text = "Clients of Most Commission"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        CType(Me.nudFromMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFromYr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTopMost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudToYr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudToMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudFromMonth As ESL.myNumericUpDown
    Friend WithEvents nudFromYr As ESL.myNumericUpDown
    Friend WithEvents RBCash As ESL.myRadioButton
    Friend WithEvents RBMargin As ESL.myRadioButton
    Friend WithEvents RBFutures As ESL.myRadioButton
    Friend WithEvents nudTopMost As ESL.myNumericUpDown
    Friend WithEvents RBStock As ESL.myRadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudToYr As ESL.myNumericUpDown
    Friend WithEvents nudToMonth As ESL.myNumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnView As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
