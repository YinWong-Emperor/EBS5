<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptLargeCashDepositLog
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
        Me.DTPTo = New System.Windows.Forms.DateTimePicker
        Me.DTPFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.radRange = New System.Windows.Forms.RadioButton
        Me.radPoint = New System.Windows.Forms.RadioButton
        Me.amtMin = New ESL.myAmountBox
        Me.amtAmount = New ESL.myAmountBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.amtMax = New ESL.myAmountBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbCurrency = New System.Windows.Forms.ComboBox
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.pbarProcess = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(449, 184)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 184)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(335, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "to"
        '
        'DTPTo
        '
        Me.DTPTo.CustomFormat = "dd MMM yyyy"
        Me.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTo.Location = New System.Drawing.Point(378, 37)
        Me.DTPTo.Name = "DTPTo"
        Me.DTPTo.Size = New System.Drawing.Size(121, 21)
        Me.DTPTo.TabIndex = 97
        '
        'DTPFrom
        '
        Me.DTPFrom.CustomFormat = "dd MMM yyyy"
        Me.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFrom.Location = New System.Drawing.Point(188, 37)
        Me.DTPFrom.Name = "DTPFrom"
        Me.DTPFrom.Size = New System.Drawing.Size(121, 21)
        Me.DTPFrom.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 15)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Transaction date period from:"
        '
        'radRange
        '
        Me.radRange.AutoSize = True
        Me.radRange.Location = New System.Drawing.Point(15, 70)
        Me.radRange.Name = "radRange"
        Me.radRange.Size = New System.Drawing.Size(167, 19)
        Me.radRange.TabIndex = 101
        Me.radRange.TabStop = True
        Me.radRange.Text = "Cash deposit amount >= :"
        Me.radRange.UseVisualStyleBackColor = True
        '
        'radPoint
        '
        Me.radPoint.AutoSize = True
        Me.radPoint.Location = New System.Drawing.Point(15, 95)
        Me.radPoint.Name = "radPoint"
        Me.radPoint.Size = New System.Drawing.Size(160, 19)
        Me.radPoint.TabIndex = 102
        Me.radPoint.TabStop = True
        Me.radPoint.Text = "Cash deposit amount > :"
        Me.radPoint.UseVisualStyleBackColor = True
        '
        'amtMin
        '
        Me.amtMin.DecimalPoints = 2
        Me.amtMin.Location = New System.Drawing.Point(188, 70)
        Me.amtMin.Name = "amtMin"
        Me.amtMin.Size = New System.Drawing.Size(121, 21)
        Me.amtMin.TabIndex = 103
        Me.amtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'amtAmount
        '
        Me.amtAmount.DecimalPoints = 2
        Me.amtAmount.Location = New System.Drawing.Point(188, 97)
        Me.amtAmount.Name = "amtAmount"
        Me.amtAmount.Size = New System.Drawing.Size(121, 21)
        Me.amtAmount.TabIndex = 104
        Me.amtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(315, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = " and <= : "
        '
        'amtMax
        '
        Me.amtMax.DecimalPoints = 2
        Me.amtMax.Location = New System.Drawing.Point(378, 70)
        Me.amtMax.Name = "amtMax"
        Me.amtMax.Size = New System.Drawing.Size(121, 21)
        Me.amtMax.TabIndex = 106
        Me.amtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Currency: "
        '
        'cmbCurrency
        '
        Me.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(76, 133)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(121, 23)
        Me.cmbCurrency.TabIndex = 108
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(393, 184)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 109
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'pbarProcess
        '
        Me.pbarProcess.Location = New System.Drawing.Point(71, 220)
        Me.pbarProcess.Name = "pbarProcess"
        Me.pbarProcess.Size = New System.Drawing.Size(316, 12)
        Me.pbarProcess.TabIndex = 111
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(68, 201)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 110
        Me.lblProcess.Text = "Processing"
        '
        'frmRptLargeCashDepositLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(511, 251)
        Me.Controls.Add(Me.pbarProcess)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cmbCurrency)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.amtMax)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.amtAmount)
        Me.Controls.Add(Me.amtMin)
        Me.Controls.Add(Me.radPoint)
        Me.Controls.Add(Me.radRange)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTPTo)
        Me.Controls.Add(Me.DTPFrom)
        Me.KeyPreview = True
        Me.Name = "frmRptLargeCashDepositLog"
        Me.Text = "Large Cash Deposit Log"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.DTPFrom, 0)
        Me.Controls.SetChildIndex(Me.DTPTo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.radRange, 0)
        Me.Controls.SetChildIndex(Me.radPoint, 0)
        Me.Controls.SetChildIndex(Me.amtMin, 0)
        Me.Controls.SetChildIndex(Me.amtAmount, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.amtMax, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cmbCurrency, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarProcess, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents radRange As System.Windows.Forms.RadioButton
    Friend WithEvents radPoint As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents amtMin As ESL.myAmountBox
    Friend WithEvents amtAmount As ESL.myAmountBox
    Friend WithEvents amtMax As ESL.myAmountBox
    Friend WithEvents pbarProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label

End Class
