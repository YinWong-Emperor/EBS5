<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptAEDetail
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
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbToAE = New ESL.myComboBox(Me.components)
        Me.lblTxMonth = New System.Windows.Forms.Label
        Me.cmbFromAE = New ESL.myComboBox(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.cmbTxMonth = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CboBranch = New ESL.myComboBox(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radICBC = New ESL.myRadioButton(Me.components)
        Me.radComm = New ESL.myRadioButton(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(361, 235)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(163, 235)
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(305, 235)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 25
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(21, 238)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 27
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(24, 256)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(214, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 26
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(350, 56)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(193, 20)
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
        Me.RBPreview.Location = New System.Drawing.Point(81, 20)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(243, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "to"
        '
        'cmbToAE
        '
        Me.cmbToAE.FormattingEnabled = True
        Me.cmbToAE.Location = New System.Drawing.Point(266, 16)
        Me.cmbToAE.Name = "cmbToAE"
        Me.cmbToAE.Size = New System.Drawing.Size(116, 23)
        Me.cmbToAE.TabIndex = 30
        '
        'lblTxMonth
        '
        Me.lblTxMonth.AutoSize = True
        Me.lblTxMonth.Location = New System.Drawing.Point(35, 19)
        Me.lblTxMonth.Name = "lblTxMonth"
        Me.lblTxMonth.Size = New System.Drawing.Size(65, 15)
        Me.lblTxMonth.TabIndex = 31
        Me.lblTxMonth.Text = "AE Range:"
        '
        'cmbFromAE
        '
        Me.cmbFromAE.FormattingEnabled = True
        Me.cmbFromAE.Location = New System.Drawing.Point(121, 16)
        Me.cmbFromAE.Name = "cmbFromAE"
        Me.cmbFromAE.Size = New System.Drawing.Size(116, 23)
        Me.cmbFromAE.TabIndex = 29
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'cmbTxMonth
        '
        Me.cmbTxMonth.FormattingEnabled = True
        Me.cmbTxMonth.Location = New System.Drawing.Point(121, 53)
        Me.cmbTxMonth.Name = "cmbTxMonth"
        Me.cmbTxMonth.Size = New System.Drawing.Size(116, 23)
        Me.cmbTxMonth.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Trade Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Branch:"
        '
        'CboBranch
        '
        Me.CboBranch.FormattingEnabled = True
        Me.CboBranch.Location = New System.Drawing.Point(121, 87)
        Me.CboBranch.Name = "CboBranch"
        Me.CboBranch.Size = New System.Drawing.Size(261, 23)
        Me.CboBranch.TabIndex = 37
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radICBC)
        Me.GroupBox1.Controls.Add(Me.radComm)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 40)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Type"
        '
        'radICBC
        '
        Me.radICBC.AutoSize = True
        Me.radICBC.Location = New System.Drawing.Point(193, 14)
        Me.radICBC.Name = "radICBC"
        Me.radICBC.Size = New System.Drawing.Size(54, 19)
        Me.radICBC.TabIndex = 1
        Me.radICBC.Text = "ICBC"
        Me.radICBC.UseVisualStyleBackColor = True
        '
        'radComm
        '
        Me.radComm.AutoSize = True
        Me.radComm.Checked = True
        Me.radComm.Location = New System.Drawing.Point(81, 14)
        Me.radComm.Name = "radComm"
        Me.radComm.Size = New System.Drawing.Size(97, 19)
        Me.radComm.TabIndex = 0
        Me.radComm.TabStop = True
        Me.radComm.Text = "Commission"
        Me.radComm.UseVisualStyleBackColor = True
        '
        'FrmRptAEDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(439, 303)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CboBranch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTxMonth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbToAE)
        Me.Controls.Add(Me.lblTxMonth)
        Me.Controls.Add(Me.cmbFromAE)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.btnPrint)
        Me.KeyPreview = True
        Me.Name = "FrmRptAEDetail"
        Me.Text = "AE DEtail (Commission) Report"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.cmbFromAE, 0)
        Me.Controls.SetChildIndex(Me.lblTxMonth, 0)
        Me.Controls.SetChildIndex(Me.cmbToAE, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbTxMonth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.CboBranch, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbToAE As ESL.myComboBox
    Friend WithEvents lblTxMonth As System.Windows.Forms.Label
    Friend WithEvents cmbFromAE As ESL.myComboBox
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents cmbTxMonth As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboBranch As ESL.myComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radICBC As ESL.myRadioButton
    Friend WithEvents radComm As ESL.myRadioButton

End Class
