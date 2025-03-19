<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptMarginCall
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CboFrm = New ESL.myComboBox(Me.components)
        Me.CboTo = New ESL.myComboBox(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.CBExport = New ESL.myCheckBox(Me.components)
        Me.txtPath = New ESL.myTextbox
        Me.CB1000 = New ESL.myCheckBox(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RBDebitBal = New ESL.myRadioButton(Me.components)
        Me.RBAEName = New ESL.myRadioButton(Me.components)
        Me.RBMarginCall = New ESL.myRadioButton(Me.components)
        Me.txtPathXLS = New ESL.myTextbox
        Me.CBExportXLS = New ESL.myCheckBox(Me.components)
        Me.CBSellOnly = New ESL.myCheckBox(Me.components)
        Me.nbMR = New ESL.myNumericBox
        Me.nbAR = New ESL.myNumericBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboAndOr = New ESL.myComboBox(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(407, 357)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(351, 357)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 68)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(134, 30)
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
        Me.RBPreview.Location = New System.Drawing.Point(20, 30)
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
        Me.Label2.Location = New System.Drawing.Point(214, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Runner Code"
        '
        'CboFrm
        '
        Me.CboFrm.FormattingEnabled = True
        Me.CboFrm.Location = New System.Drawing.Point(102, 11)
        Me.CboFrm.Name = "CboFrm"
        Me.CboFrm.Size = New System.Drawing.Size(106, 23)
        Me.CboFrm.TabIndex = 10
        '
        'CboTo
        '
        Me.CboTo.FormattingEnabled = True
        Me.CboTo.Location = New System.Drawing.Point(241, 11)
        Me.CboTo.Name = "CboTo"
        Me.CboTo.Size = New System.Drawing.Size(121, 23)
        Me.CboTo.TabIndex = 11
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(14, 354)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 17
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(17, 372)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(405, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 16
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'CBExport
        '
        Me.CBExport.AutoSize = True
        Me.CBExport.Location = New System.Drawing.Point(18, 162)
        Me.CBExport.Name = "CBExport"
        Me.CBExport.Size = New System.Drawing.Size(138, 19)
        Me.CBExport.TabIndex = 19
        Me.CBExport.Text = "Export To Excel (csv)"
        Me.CBExport.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(152, 160)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(305, 21)
        Me.txtPath.TabIndex = 20
        '
        'CB1000
        '
        Me.CB1000.AutoSize = True
        Me.CB1000.Location = New System.Drawing.Point(18, 41)
        Me.CB1000.Name = "CB1000"
        Me.CB1000.Size = New System.Drawing.Size(205, 19)
        Me.CB1000.TabIndex = 21
        Me.CB1000.Text = "Exclude Total Margin Call < 1000"
        Me.CB1000.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBDebitBal)
        Me.GroupBox1.Controls.Add(Me.RBAEName)
        Me.GroupBox1.Controls.Add(Me.RBMarginCall)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 213)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 68)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort Option"
        '
        'RBDebitBal
        '
        Me.RBDebitBal.AutoSize = True
        Me.RBDebitBal.Location = New System.Drawing.Point(302, 30)
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
        Me.RBAEName.Location = New System.Drawing.Point(20, 30)
        Me.RBAEName.Name = "RBAEName"
        Me.RBAEName.Size = New System.Drawing.Size(77, 19)
        Me.RBAEName.TabIndex = 1
        Me.RBAEName.TabStop = True
        Me.RBAEName.Text = "AE Name"
        Me.RBAEName.UseVisualStyleBackColor = True
        '
        'RBMarginCall
        '
        Me.RBMarginCall.AutoSize = True
        Me.RBMarginCall.Location = New System.Drawing.Point(134, 30)
        Me.RBMarginCall.Name = "RBMarginCall"
        Me.RBMarginCall.Size = New System.Drawing.Size(132, 19)
        Me.RBMarginCall.TabIndex = 0
        Me.RBMarginCall.Text = "Margin Call Amount"
        Me.RBMarginCall.UseVisualStyleBackColor = True
        '
        'txtPathXLS
        '
        Me.txtPathXLS.Location = New System.Drawing.Point(152, 186)
        Me.txtPathXLS.Name = "txtPathXLS"
        Me.txtPathXLS.Size = New System.Drawing.Size(305, 21)
        Me.txtPathXLS.TabIndex = 25
        '
        'CBExportXLS
        '
        Me.CBExportXLS.AutoSize = True
        Me.CBExportXLS.Location = New System.Drawing.Point(18, 188)
        Me.CBExportXLS.Name = "CBExportXLS"
        Me.CBExportXLS.Size = New System.Drawing.Size(135, 19)
        Me.CBExportXLS.TabIndex = 24
        Me.CBExportXLS.Text = "Export To Excel (xls)"
        Me.CBExportXLS.UseVisualStyleBackColor = True
        '
        'CBSellOnly
        '
        Me.CBSellOnly.AutoSize = True
        Me.CBSellOnly.Location = New System.Drawing.Point(18, 64)
        Me.CBSellOnly.Name = "CBSellOnly"
        Me.CBSellOnly.Size = New System.Drawing.Size(74, 19)
        Me.CBSellOnly.TabIndex = 29
        Me.CBSellOnly.Text = "Sell Only"
        Me.CBSellOnly.UseVisualStyleBackColor = True
        '
        'nbMR
        '
        Me.nbMR.Enabled = False
        Me.nbMR.Location = New System.Drawing.Point(303, 126)
        Me.nbMR.Name = "nbMR"
        Me.nbMR.Size = New System.Drawing.Size(51, 21)
        Me.nbMR.TabIndex = 46
        Me.nbMR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbAR
        '
        Me.nbAR.Enabled = False
        Me.nbAR.Location = New System.Drawing.Point(166, 126)
        Me.nbAR.Name = "nbAR"
        Me.nbAR.Size = New System.Drawing.Size(51, 21)
        Me.nbAR.TabIndex = 45
        Me.nbAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(112, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 15)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "and AR>"
        '
        'cboAndOr
        '
        Me.cboAndOr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAndOr.Enabled = False
        Me.cboAndOr.FormattingEnabled = True
        Me.cboAndOr.Location = New System.Drawing.Point(223, 125)
        Me.cboAndOr.Name = "cboAndOr"
        Me.cboAndOr.Size = New System.Drawing.Size(49, 23)
        Me.cboAndOr.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "MR>"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(99, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(235, 15)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "4. Margin Client and mc_dr_bal<=cr_limit "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(99, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(358, 45)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "1. Cash Client and DUE(mc_due>0) " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Cash Client and Undue(mc_due<=0 and Undue>0" & _
            ") and AR>1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. Margin Client and mc_dr_bal>cr_limit" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'FrmRptMrgCall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(477, 438)
        Me.Controls.Add(Me.nbMR)
        Me.Controls.Add(Me.nbAR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboAndOr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CBSellOnly)
        Me.Controls.Add(Me.txtPathXLS)
        Me.Controls.Add(Me.CBExportXLS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CB1000)
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
        Me.Name = "FrmRptMrgCall"
        Me.Text = "Margin Call Report (New)"
        Me.Controls.SetChildIndex(Me.CboTo, 0)
        Me.Controls.SetChildIndex(Me.CboFrm, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.CBExport, 0)
        Me.Controls.SetChildIndex(Me.txtPath, 0)
        Me.Controls.SetChildIndex(Me.CB1000, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.CBExportXLS, 0)
        Me.Controls.SetChildIndex(Me.txtPathXLS, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.CBSellOnly, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboAndOr, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.nbAR, 0)
        Me.Controls.SetChildIndex(Me.nbMR, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboFrm As ESL.myComboBox
    Friend WithEvents CboTo As ESL.myComboBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents CBExport As ESL.myCheckBox
    Friend WithEvents txtPath As ESL.myTextbox
    Friend WithEvents CB1000 As ESL.myCheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBAEName As ESL.myRadioButton
    Friend WithEvents RBMarginCall As ESL.myRadioButton
    Friend WithEvents txtPathXLS As ESL.myTextbox
    Friend WithEvents CBExportXLS As ESL.myCheckBox
    Friend WithEvents CBSellOnly As ESL.myCheckBox
    Friend WithEvents RBDebitBal As ESL.myRadioButton
    Friend WithEvents nbMR As ESL.myNumericBox
    Friend WithEvents nbAR As ESL.myNumericBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboAndOr As ESL.myComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
