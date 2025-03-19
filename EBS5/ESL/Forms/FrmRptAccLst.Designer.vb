<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptAccLst
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RBMargin = New ESL.myRadioButton(Me.components)
        Me.RBCash = New ESL.myRadioButton(Me.components)
        Me.RBAll = New ESL.myRadioButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboFrm = New ESL.myComboBox(Me.components)
        Me.CboTo = New ESL.myComboBox(Me.components)
        Me.radRunCode = New ESL.myRadioButton(Me.components)
        Me.radAll = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.PrintDlg = New System.Windows.Forms.PrintDialog()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(507, 397)
        Me.btnCancel.Size = New System.Drawing.Size(50, 58)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(443, 397)
        Me.btnSave.Size = New System.Drawing.Size(50, 49)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Visible = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Record Range"
        '
        'RBMargin
        '
        Me.RBMargin.AutoSize = True
        Me.RBMargin.Checked = True
        Me.RBMargin.Location = New System.Drawing.Point(114, 147)
        Me.RBMargin.Name = "RBMargin"
        Me.RBMargin.Size = New System.Drawing.Size(89, 19)
        Me.RBMargin.TabIndex = 0
        Me.RBMargin.TabStop = True
        Me.RBMargin.Text = "Margin Only"
        Me.RBMargin.UseVisualStyleBackColor = True
        '
        'RBCash
        '
        Me.RBCash.AutoSize = True
        Me.RBCash.Location = New System.Drawing.Point(248, 147)
        Me.RBCash.Name = "RBCash"
        Me.RBCash.Size = New System.Drawing.Size(82, 19)
        Me.RBCash.TabIndex = 1
        Me.RBCash.TabStop = True
        Me.RBCash.Text = "Cash Only"
        Me.RBCash.UseVisualStyleBackColor = True
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.Location = New System.Drawing.Point(386, 147)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(38, 19)
        Me.RBAll.TabIndex = 2
        Me.RBAll.TabStop = True
        Me.RBAll.Text = "All"
        Me.RBAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.RBAll)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.RBCash)
        Me.GroupBox1.Controls.Add(Me.RBMargin)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 315)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Record Range"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(114, 186)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 100)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(15, 64)
        Me.RBPrint.Name = "RBPrint"
        Me.RBPrint.Size = New System.Drawing.Size(147, 19)
        Me.RBPrint.TabIndex = 1
        Me.RBPrint.TabStop = True
        Me.RBPrint.Text = "Send to Printer directly"
        Me.RBPrint.UseVisualStyleBackColor = True
        '
        'RBPreview
        '
        Me.RBPreview.AutoSize = True
        Me.RBPreview.Checked = True
        Me.RBPreview.Location = New System.Drawing.Point(15, 30)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(143, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Print Preview Window"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Print Report"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.CboFrm)
        Me.GroupBox3.Controls.Add(Me.CboTo)
        Me.GroupBox3.Controls.Add(Me.radRunCode)
        Me.GroupBox3.Controls.Add(Me.radAll)
        Me.GroupBox3.Location = New System.Drawing.Point(114, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(399, 107)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Range Option"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "To"
        '
        'CboFrm
        '
        Me.CboFrm.FormattingEnabled = True
        Me.CboFrm.Location = New System.Drawing.Point(134, 63)
        Me.CboFrm.Name = "CboFrm"
        Me.CboFrm.Size = New System.Drawing.Size(106, 23)
        Me.CboFrm.TabIndex = 10
        '
        'CboTo
        '
        Me.CboTo.FormattingEnabled = True
        Me.CboTo.Location = New System.Drawing.Point(272, 63)
        Me.CboTo.Name = "CboTo"
        Me.CboTo.Size = New System.Drawing.Size(121, 23)
        Me.CboTo.TabIndex = 11
        '
        'radRunCode
        '
        Me.radRunCode.AutoSize = True
        Me.radRunCode.Location = New System.Drawing.Point(27, 66)
        Me.radRunCode.Name = "radRunCode"
        Me.radRunCode.Size = New System.Drawing.Size(99, 19)
        Me.radRunCode.TabIndex = 1
        Me.radRunCode.Text = "Runner Code"
        Me.radRunCode.UseVisualStyleBackColor = True
        '
        'radAll
        '
        Me.radAll.AutoSize = True
        Me.radAll.Checked = True
        Me.radAll.Location = New System.Drawing.Point(27, 30)
        Me.radAll.Name = "radAll"
        Me.radAll.Size = New System.Drawing.Size(38, 19)
        Me.radAll.TabIndex = 0
        Me.radAll.TabStop = True
        Me.radAll.Text = "All"
        Me.radAll.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(65, 393)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 15
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(68, 412)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(352, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 14
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(102, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(377, 22)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "PRINT SECURITIES ACCOUNT LISTING  "
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(443, 397)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 58)
        Me.btnPrint.TabIndex = 56
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmRptAccLst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(589, 464)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmRptAccLst"
        Me.Text = "Account Listing (Securities)"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBMargin As ESL.myRadioButton
    Friend WithEvents RBCash As ESL.myRadioButton
    Friend WithEvents RBAll As ESL.myRadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboFrm As ESL.myComboBox
    Friend WithEvents CboTo As ESL.myComboBox
    Friend WithEvents radRunCode As ESL.myRadioButton
    Friend WithEvents radAll As ESL.myRadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton

End Class
