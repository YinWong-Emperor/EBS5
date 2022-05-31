<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptFatcaAccountList
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
        Me.cboAccType = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFatcaAccType = New ESL.myComboBox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboClientType = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboAENoFrom = New ESL.myComboBox(Me.components)
        Me.chkAccNo = New ESL.myCheckBox(Me.components)
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboAENoTo = New ESL.myComboBox(Me.components)
        Me.txtAccNoFrom = New ESL.myTextbox()
        Me.txtAccNoTo = New ESL.myTextbox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkAENo = New ESL.myCheckBox(Me.components)
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(562, 238)
        Me.btnCancel.TabIndex = 65
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(510, 238)
        Me.btnSave.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(547, 22)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "FATCA Account List"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboAccType
        '
        Me.cboAccType.FormattingEnabled = True
        Me.cboAccType.Location = New System.Drawing.Point(172, 44)
        Me.cboAccType.Name = "cboAccType"
        Me.cboAccType.Size = New System.Drawing.Size(121, 23)
        Me.cboAccType.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Account Type"
        '
        'cboFatcaAccType
        '
        Me.cboFatcaAccType.FormattingEnabled = True
        Me.cboFatcaAccType.Location = New System.Drawing.Point(172, 73)
        Me.cboFatcaAccType.Name = "cboFatcaAccType"
        Me.cboFatcaAccType.Size = New System.Drawing.Size(121, 23)
        Me.cboFatcaAccType.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "FATCA Account Type"
        '
        'cboClientType
        '
        Me.cboClientType.FormattingEnabled = True
        Me.cboClientType.Location = New System.Drawing.Point(172, 102)
        Me.cboClientType.Name = "cboClientType"
        Me.cboClientType.Size = New System.Drawing.Size(121, 23)
        Me.cboClientType.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Client Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(130, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(298, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "To"
        '
        'cboAENoFrom
        '
        Me.cboAENoFrom.FormattingEnabled = True
        Me.cboAENoFrom.Location = New System.Drawing.Point(172, 160)
        Me.cboAENoFrom.Name = "cboAENoFrom"
        Me.cboAENoFrom.Size = New System.Drawing.Size(121, 23)
        Me.cboAENoFrom.TabIndex = 31
        '
        'chkAccNo
        '
        Me.chkAccNo.AutoSize = True
        Me.chkAccNo.Location = New System.Drawing.Point(15, 133)
        Me.chkAccNo.Name = "chkAccNo"
        Me.chkAccNo.Size = New System.Drawing.Size(58, 19)
        Me.chkAccNo.TabIndex = 20
        Me.chkAccNo.Text = "Client"
        Me.chkAccNo.UseVisualStyleBackColor = True
        '
        'pbarPrint
        '
        Me.pbarPrint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbarPrint.Location = New System.Drawing.Point(15, 217)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(364, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 62
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(12, 199)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 61
        Me.lblProcess.Text = "Processing"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(15, 238)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 63
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(299, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "To"
        '
        'cboAENoTo
        '
        Me.cboAENoTo.FormattingEnabled = True
        Me.cboAENoTo.Location = New System.Drawing.Point(325, 160)
        Me.cboAENoTo.Name = "cboAENoTo"
        Me.cboAENoTo.Size = New System.Drawing.Size(121, 23)
        Me.cboAENoTo.TabIndex = 33
        '
        'txtAccNoFrom
        '
        Me.txtAccNoFrom.Location = New System.Drawing.Point(172, 132)
        Me.txtAccNoFrom.Name = "txtAccNoFrom"
        Me.txtAccNoFrom.Size = New System.Drawing.Size(121, 21)
        Me.txtAccNoFrom.TabIndex = 22
        '
        'txtAccNoTo
        '
        Me.txtAccNoTo.Location = New System.Drawing.Point(324, 132)
        Me.txtAccNoTo.Name = "txtAccNoTo"
        Me.txtAccNoTo.Size = New System.Drawing.Size(121, 21)
        Me.txtAccNoTo.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(130, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 15)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "From"
        '
        'chkAENo
        '
        Me.chkAENo.AutoSize = True
        Me.chkAENo.Location = New System.Drawing.Point(15, 163)
        Me.chkAENo.Name = "chkAENo"
        Me.chkAENo.Size = New System.Drawing.Size(74, 19)
        Me.chkAENo.TabIndex = 29
        Me.chkAENo.Text = "AE Code"
        Me.chkAENo.UseVisualStyleBackColor = True
        '
        'FrmRptFatcaAccountList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(624, 304)
        Me.Controls.Add(Me.chkAENo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAccNoTo)
        Me.Controls.Add(Me.txtAccNoFrom)
        Me.Controls.Add(Me.cboAENoTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkAccNo)
        Me.Controls.Add(Me.cboAENoFrom)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboClientType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFatcaAccType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAccType)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmRptFatcaAccountList"
        Me.Text = "FATCA Account List"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboAccType, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cboFatcaAccType, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cboClientType, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cboAENoFrom, 0)
        Me.Controls.SetChildIndex(Me.chkAccNo, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboAENoTo, 0)
        Me.Controls.SetChildIndex(Me.txtAccNoFrom, 0)
        Me.Controls.SetChildIndex(Me.txtAccNoTo, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.chkAENo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAccType As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFatcaAccType As ESL.myComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboClientType As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboAENoFrom As ESL.myComboBox
    Friend WithEvents chkAccNo As ESL.myCheckBox
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboAENoTo As ESL.myComboBox
    Friend WithEvents txtAccNoFrom As ESL.myTextbox
    Friend WithEvents txtAccNoTo As ESL.myTextbox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkAENo As ESL.myCheckBox

End Class
