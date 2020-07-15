<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrLmtRpt
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudday = New System.Windows.Forms.NumericUpDown
        Me.nudMth = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbCSV = New ESL.myRadioButton(Me.components)
        Me.rbPrinter = New ESL.myRadioButton(Me.components)
        Me.rbPreview = New ESL.myRadioButton(Me.components)
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbAll = New ESL.myRadioButton(Me.components)
        Me.rbCash = New ESL.myRadioButton(Me.components)
        Me.rbMargin = New ESL.myRadioButton(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtClientFrom = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbAE = New ESL.myCheckBox(Me.components)
        Me.cbClient = New ESL.myCheckBox(Me.components)
        Me.comboAEFrom = New ESL.myComboBox(Me.components)
        Me.comboAETo = New ESL.myComboBox(Me.components)
        Me.txtClientTo = New ESL.myTextbox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbSortAE = New ESL.myRadioButton(Me.components)
        Me.rbSortClient = New ESL.myRadioButton(Me.components)
        CType(Me.nudday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(329, 386)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(273, 386)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(347, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "days"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "months"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "A/C having trades within"
        '
        'nudday
        '
        Me.nudday.Location = New System.Drawing.Point(291, 73)
        Me.nudday.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudday.Name = "nudday"
        Me.nudday.Size = New System.Drawing.Size(50, 21)
        Me.nudday.TabIndex = 20
        '
        'nudMth
        '
        Me.nudMth.Location = New System.Drawing.Point(180, 73)
        Me.nudMth.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudMth.Name = "nudMth"
        Me.nudMth.Size = New System.Drawing.Size(50, 21)
        Me.nudMth.TabIndex = 19
        Me.nudMth.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(89, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(235, 22)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Client Account Statistics"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCSV)
        Me.GroupBox1.Controls.Add(Me.rbPrinter)
        Me.GroupBox1.Controls.Add(Me.rbPreview)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 272)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 107)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display"
        '
        'rbCSV
        '
        Me.rbCSV.AutoSize = True
        Me.rbCSV.Location = New System.Drawing.Point(24, 70)
        Me.rbCSV.Name = "rbCSV"
        Me.rbCSV.Size = New System.Drawing.Size(99, 19)
        Me.rbCSV.TabIndex = 2
        Me.rbCSV.Text = "Export to CSV"
        Me.rbCSV.UseVisualStyleBackColor = True
        '
        'rbPrinter
        '
        Me.rbPrinter.AutoSize = True
        Me.rbPrinter.Location = New System.Drawing.Point(24, 45)
        Me.rbPrinter.Name = "rbPrinter"
        Me.rbPrinter.Size = New System.Drawing.Size(157, 19)
        Me.rbPrinter.TabIndex = 1
        Me.rbPrinter.Text = "Send to Printer Directory"
        Me.rbPrinter.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(24, 20)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(143, 19)
        Me.rbPreview.TabIndex = 0
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Print Preview Window"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(273, 386)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 24
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbAll)
        Me.GroupBox2.Controls.Add(Me.rbCash)
        Me.GroupBox2.Controls.Add(Me.rbMargin)
        Me.GroupBox2.Location = New System.Drawing.Point(38, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 52)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Client Type"
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Location = New System.Drawing.Point(234, 20)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(38, 19)
        Me.rbAll.TabIndex = 2
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbCash
        '
        Me.rbCash.AutoSize = True
        Me.rbCash.Location = New System.Drawing.Point(133, 20)
        Me.rbCash.Name = "rbCash"
        Me.rbCash.Size = New System.Drawing.Size(55, 19)
        Me.rbCash.TabIndex = 1
        Me.rbCash.Text = "Cash"
        Me.rbCash.UseVisualStyleBackColor = True
        '
        'rbMargin
        '
        Me.rbMargin.AutoSize = True
        Me.rbMargin.Checked = True
        Me.rbMargin.Location = New System.Drawing.Point(24, 20)
        Me.rbMargin.Name = "rbMargin"
        Me.rbMargin.Size = New System.Drawing.Size(62, 19)
        Me.rbMargin.TabIndex = 0
        Me.rbMargin.TabStop = True
        Me.rbMargin.Text = "Margin"
        Me.rbMargin.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(249, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 15)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "To"
        '
        'txtClientFrom
        '
        Me.txtClientFrom.Enabled = False
        Me.txtClientFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientFrom.Location = New System.Drawing.Point(139, 100)
        Me.txtClientFrom.MaxLength = 8
        Me.txtClientFrom.Name = "txtClientFrom"
        Me.txtClientFrom.Size = New System.Drawing.Size(104, 21)
        Me.txtClientFrom.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(249, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 15)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "To"
        '
        'cbAE
        '
        Me.cbAE.AutoSize = True
        Me.cbAE.Location = New System.Drawing.Point(39, 129)
        Me.cbAE.Name = "cbAE"
        Me.cbAE.Size = New System.Drawing.Size(74, 19)
        Me.cbAE.TabIndex = 46
        Me.cbAE.Text = "AE Code"
        Me.cbAE.UseVisualStyleBackColor = True
        '
        'cbClient
        '
        Me.cbClient.AutoSize = True
        Me.cbClient.Location = New System.Drawing.Point(39, 102)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(58, 19)
        Me.cbClient.TabIndex = 43
        Me.cbClient.Text = "Client"
        Me.cbClient.UseVisualStyleBackColor = True
        '
        'comboAEFrom
        '
        Me.comboAEFrom.Enabled = False
        Me.comboAEFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAEFrom.FormattingEnabled = True
        Me.comboAEFrom.Location = New System.Drawing.Point(139, 127)
        Me.comboAEFrom.Name = "comboAEFrom"
        Me.comboAEFrom.Size = New System.Drawing.Size(104, 23)
        Me.comboAEFrom.TabIndex = 47
        '
        'comboAETo
        '
        Me.comboAETo.Enabled = False
        Me.comboAETo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAETo.FormattingEnabled = True
        Me.comboAETo.Location = New System.Drawing.Point(276, 127)
        Me.comboAETo.Name = "comboAETo"
        Me.comboAETo.Size = New System.Drawing.Size(104, 23)
        Me.comboAETo.TabIndex = 48
        '
        'txtClientTo
        '
        Me.txtClientTo.Enabled = False
        Me.txtClientTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientTo.Location = New System.Drawing.Point(276, 100)
        Me.txtClientTo.Name = "txtClientTo"
        Me.txtClientTo.Size = New System.Drawing.Size(104, 21)
        Me.txtClientTo.TabIndex = 45
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbSortAE)
        Me.GroupBox3.Controls.Add(Me.rbSortClient)
        Me.GroupBox3.Location = New System.Drawing.Point(38, 214)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 52)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sort By"
        '
        'rbSortAE
        '
        Me.rbSortAE.AutoSize = True
        Me.rbSortAE.Location = New System.Drawing.Point(133, 20)
        Me.rbSortAE.Name = "rbSortAE"
        Me.rbSortAE.Size = New System.Drawing.Size(40, 19)
        Me.rbSortAE.TabIndex = 1
        Me.rbSortAE.Text = "AE"
        Me.rbSortAE.UseVisualStyleBackColor = True
        '
        'rbSortClient
        '
        Me.rbSortClient.AutoSize = True
        Me.rbSortClient.Checked = True
        Me.rbSortClient.Location = New System.Drawing.Point(24, 20)
        Me.rbSortClient.Name = "rbSortClient"
        Me.rbSortClient.Size = New System.Drawing.Size(57, 19)
        Me.rbSortClient.TabIndex = 0
        Me.rbSortClient.TabStop = True
        Me.rbSortClient.Text = "Client"
        Me.rbSortClient.UseVisualStyleBackColor = True
        '
        'FrmCrLmtRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(425, 475)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtClientFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbAE)
        Me.Controls.Add(Me.cbClient)
        Me.Controls.Add(Me.comboAEFrom)
        Me.Controls.Add(Me.comboAETo)
        Me.Controls.Add(Me.txtClientTo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudday)
        Me.Controls.Add(Me.nudMth)
        Me.KeyPreview = True
        Me.Name = "FrmCrLmtRpt"
        Me.Text = "Client Account Statistics"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.nudMth, 0)
        Me.Controls.SetChildIndex(Me.nudday, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.txtClientTo, 0)
        Me.Controls.SetChildIndex(Me.comboAETo, 0)
        Me.Controls.SetChildIndex(Me.comboAEFrom, 0)
        Me.Controls.SetChildIndex(Me.cbClient, 0)
        Me.Controls.SetChildIndex(Me.cbAE, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtClientFrom, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        CType(Me.nudday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudday As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPrinter As ESL.myRadioButton
    Friend WithEvents rbPreview As ESL.myRadioButton
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAll As ESL.myRadioButton
    Friend WithEvents rbCash As ESL.myRadioButton
    Friend WithEvents rbMargin As ESL.myRadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtClientFrom As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbAE As ESL.myCheckBox
    Friend WithEvents cbClient As ESL.myCheckBox
    Friend WithEvents comboAEFrom As ESL.myComboBox
    Friend WithEvents comboAETo As ESL.myComboBox
    Friend WithEvents txtClientTo As ESL.myTextbox
    Friend WithEvents rbCSV As ESL.myRadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSortAE As ESL.myRadioButton
    Friend WithEvents rbSortClient As ESL.myRadioButton

End Class
