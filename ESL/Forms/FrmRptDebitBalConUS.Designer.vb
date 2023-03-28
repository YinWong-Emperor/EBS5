<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptDebitBalConUS
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
        Me.CBDrBal = New ESL.myCheckBox(Me.components)
        Me.CBMC_Amt = New ESL.myCheckBox(Me.components)
        Me.txtPathXLS = New ESL.myTextbox()
        Me.CBExportXLS = New ESL.myCheckBox(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBDebitBal = New ESL.myRadioButton(Me.components)
        Me.RBAEName = New ESL.myRadioButton(Me.components)
        Me.RBMarginCall = New ESL.myRadioButton(Me.components)
        Me.txtPath = New ESL.myTextbox()
        Me.CBExport = New ESL.myCheckBox(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboFrm = New ESL.myComboBox(Me.components)
        Me.CboTo = New ESL.myComboBox(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbMarginCash = New ESL.myRadioButton(Me.components)
        Me.rbCash = New ESL.myRadioButton(Me.components)
        Me.rbMargin = New ESL.myRadioButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.abDrBal = New ESL.myAmountBox()
        Me.abMC_Amt = New ESL.myAmountBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(505, 327)
        Me.btnCancel.TabIndex = 10
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(453, 327)
        Me.btnSave.TabIndex = 9
        '
        'CBDrBal
        '
        Me.CBDrBal.AutoSize = True
        Me.CBDrBal.Checked = True
        Me.CBDrBal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBDrBal.Location = New System.Drawing.Point(14, 59)
        Me.CBDrBal.Name = "CBDrBal"
        Me.CBDrBal.Size = New System.Drawing.Size(130, 19)
        Me.CBDrBal.TabIndex = 3
        Me.CBDrBal.Text = "Debit Balance >= $"
        Me.CBDrBal.UseVisualStyleBackColor = True
        '
        'CBMC_Amt
        '
        Me.CBMC_Amt.AutoSize = True
        Me.CBMC_Amt.Location = New System.Drawing.Point(14, 35)
        Me.CBMC_Amt.Name = "CBMC_Amt"
        Me.CBMC_Amt.Size = New System.Drawing.Size(159, 19)
        Me.CBMC_Amt.TabIndex = 2
        Me.CBMC_Amt.Text = "Margin Call Amount >= $"
        Me.CBMC_Amt.UseVisualStyleBackColor = True
        '
        'txtPathXLS
        '
        Me.txtPathXLS.Location = New System.Drawing.Point(148, 108)
        Me.txtPathXLS.Name = "txtPathXLS"
        Me.txtPathXLS.Size = New System.Drawing.Size(270, 21)
        Me.txtPathXLS.TabIndex = 44
        '
        'CBExportXLS
        '
        Me.CBExportXLS.AutoSize = True
        Me.CBExportXLS.Location = New System.Drawing.Point(14, 110)
        Me.CBExportXLS.Name = "CBExportXLS"
        Me.CBExportXLS.Size = New System.Drawing.Size(134, 19)
        Me.CBExportXLS.TabIndex = 5
        Me.CBExportXLS.Text = "Export To Excel (xls)"
        Me.CBExportXLS.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBDebitBal)
        Me.GroupBox1.Controls.Add(Me.RBAEName)
        Me.GroupBox1.Controls.Add(Me.RBMarginCall)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 68)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort Option"
        '
        'RBDebitBal
        '
        Me.RBDebitBal.AutoSize = True
        Me.RBDebitBal.Location = New System.Drawing.Point(281, 30)
        Me.RBDebitBal.Name = "RBDebitBal"
        Me.RBDebitBal.Size = New System.Drawing.Size(102, 19)
        Me.RBDebitBal.TabIndex = 2
        Me.RBDebitBal.Text = "Debit Balance"
        Me.RBDebitBal.UseVisualStyleBackColor = True
        '
        'RBAEName
        '
        Me.RBAEName.AutoSize = True
        Me.RBAEName.Checked = True
        Me.RBAEName.Location = New System.Drawing.Point(35, 30)
        Me.RBAEName.Name = "RBAEName"
        Me.RBAEName.Size = New System.Drawing.Size(77, 19)
        Me.RBAEName.TabIndex = 0
        Me.RBAEName.TabStop = True
        Me.RBAEName.Text = "AE Name"
        Me.RBAEName.UseVisualStyleBackColor = True
        '
        'RBMarginCall
        '
        Me.RBMarginCall.AutoSize = True
        Me.RBMarginCall.Location = New System.Drawing.Point(133, 30)
        Me.RBMarginCall.Name = "RBMarginCall"
        Me.RBMarginCall.Size = New System.Drawing.Size(131, 19)
        Me.RBMarginCall.TabIndex = 1
        Me.RBMarginCall.Text = "Margin Call Amount"
        Me.RBMarginCall.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(148, 82)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(270, 21)
        Me.txtPath.TabIndex = 40
        '
        'CBExport
        '
        Me.CBExport.AutoSize = True
        Me.CBExport.Location = New System.Drawing.Point(14, 84)
        Me.CBExport.Name = "CBExport"
        Me.CBExport.Size = New System.Drawing.Size(137, 19)
        Me.CBExport.TabIndex = 4
        Me.CBExport.Text = "Export To Excel (csv)"
        Me.CBExport.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(11, 327)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 38
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(14, 345)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(404, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 37
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 247)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(541, 68)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(199, 30)
        Me.RBPrint.Name = "RBPrint"
        Me.RBPrint.Size = New System.Drawing.Size(108, 19)
        Me.RBPrint.TabIndex = 1
        Me.RBPrint.Text = "Direct to printer"
        Me.RBPrint.UseVisualStyleBackColor = True
        '
        'RBPreview
        '
        Me.RBPreview.AutoSize = True
        Me.RBPreview.Checked = True
        Me.RBPreview.Location = New System.Drawing.Point(84, 30)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Runner Code"
        '
        'CboFrm
        '
        Me.CboFrm.FormattingEnabled = True
        Me.CboFrm.Location = New System.Drawing.Point(99, 6)
        Me.CboFrm.Name = "CboFrm"
        Me.CboFrm.Size = New System.Drawing.Size(106, 23)
        Me.CboFrm.TabIndex = 0
        '
        'CboTo
        '
        Me.CboTo.FormattingEnabled = True
        Me.CboTo.Location = New System.Drawing.Point(238, 6)
        Me.CboTo.Name = "CboTo"
        Me.CboTo.Size = New System.Drawing.Size(121, 23)
        Me.CboTo.TabIndex = 1
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbMarginCash)
        Me.GroupBox3.Controls.Add(Me.rbCash)
        Me.GroupBox3.Controls.Add(Me.rbMargin)
        Me.GroupBox3.Location = New System.Drawing.Point(85, 127)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(255, 40)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'rbMarginCash
        '
        Me.rbMarginCash.AutoSize = True
        Me.rbMarginCash.Checked = True
        Me.rbMarginCash.Location = New System.Drawing.Point(135, 13)
        Me.rbMarginCash.Name = "rbMarginCash"
        Me.rbMarginCash.Size = New System.Drawing.Size(119, 19)
        Me.rbMarginCash.TabIndex = 2
        Me.rbMarginCash.TabStop = True
        Me.rbMarginCash.Text = "Margin and Cash"
        Me.rbMarginCash.UseVisualStyleBackColor = True
        '
        'rbCash
        '
        Me.rbCash.AutoSize = True
        Me.rbCash.Location = New System.Drawing.Point(74, 13)
        Me.rbCash.Name = "rbCash"
        Me.rbCash.Size = New System.Drawing.Size(55, 19)
        Me.rbCash.TabIndex = 1
        Me.rbCash.Text = "Cash"
        Me.rbCash.UseVisualStyleBackColor = True
        '
        'rbMargin
        '
        Me.rbMargin.AutoSize = True
        Me.rbMargin.Location = New System.Drawing.Point(6, 13)
        Me.rbMargin.Name = "rbMargin"
        Me.rbMargin.Size = New System.Drawing.Size(62, 19)
        Me.rbMargin.TabIndex = 0
        Me.rbMargin.Text = "Margin"
        Me.rbMargin.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Client Type"
        '
        'abDrBal
        '
        Me.abDrBal.DecimalPoints = 2
        Me.abDrBal.EnabledRemoveTrailingZero = False
        Me.abDrBal.IntLen = 9
        Me.abDrBal.Location = New System.Drawing.Point(148, 57)
        Me.abDrBal.Name = "abDrBal"
        Me.abDrBal.Size = New System.Drawing.Size(106, 21)
        Me.abDrBal.TabIndex = 51
        Me.abDrBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'abMC_Amt
        '
        Me.abMC_Amt.DecimalPoints = 2
        Me.abMC_Amt.Enabled = False
        Me.abMC_Amt.EnabledRemoveTrailingZero = False
        Me.abMC_Amt.IntLen = 9
        Me.abMC_Amt.Location = New System.Drawing.Point(180, 33)
        Me.abMC_Amt.Name = "abMC_Amt"
        Me.abMC_Amt.Size = New System.Drawing.Size(106, 21)
        Me.abMC_Amt.TabIndex = 52
        Me.abMC_Amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmRptDebitBalConUS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(567, 401)
        Me.Controls.Add(Me.abMC_Amt)
        Me.Controls.Add(Me.abDrBal)
        Me.Controls.Add(Me.txtPathXLS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CBDrBal)
        Me.Controls.Add(Me.CBMC_Amt)
        Me.Controls.Add(Me.CBExportXLS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.CBExport)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboFrm)
        Me.Controls.Add(Me.CboTo)
        Me.KeyPreview = True
        Me.Name = "FrmRptDebitBalConUS"
        Me.Text = "Debit Balance Concentration Report (Included Same Day US)"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.CboTo, 0)
        Me.Controls.SetChildIndex(Me.CboFrm, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.CBExport, 0)
        Me.Controls.SetChildIndex(Me.txtPath, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.CBExportXLS, 0)
        Me.Controls.SetChildIndex(Me.CBMC_Amt, 0)
        Me.Controls.SetChildIndex(Me.CBDrBal, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtPathXLS, 0)
        Me.Controls.SetChildIndex(Me.abDrBal, 0)
        Me.Controls.SetChildIndex(Me.abMC_Amt, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBDrBal As ESL.myCheckBox
    Friend WithEvents CBMC_Amt As ESL.myCheckBox
    Friend WithEvents txtPathXLS As ESL.myTextbox
    Friend WithEvents CBExportXLS As ESL.myCheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBDebitBal As ESL.myRadioButton
    Friend WithEvents RBAEName As ESL.myRadioButton
    Friend WithEvents RBMarginCall As ESL.myRadioButton
    Friend WithEvents txtPath As ESL.myTextbox
    Friend WithEvents CBExport As ESL.myCheckBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboFrm As ESL.myComboBox
    Friend WithEvents CboTo As ESL.myComboBox
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMargin As ESL.myRadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbMarginCash As ESL.myRadioButton
    Friend WithEvents rbCash As ESL.myRadioButton
    Friend WithEvents abDrBal As ESL.myAmountBox
    Friend WithEvents abMC_Amt As ESL.myAmountBox

End Class
