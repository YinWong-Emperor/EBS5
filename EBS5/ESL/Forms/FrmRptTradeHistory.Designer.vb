<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptTradeHistory
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
        Me.pbarProcess = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboClientCode = New ESL.myComboBox(Me.components)
        Me.btnSend = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(401, 142)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(23, 142)
        '
        'pbarProcess
        '
        Me.pbarProcess.Location = New System.Drawing.Point(23, 158)
        Me.pbarProcess.Name = "pbarProcess"
        Me.pbarProcess.Size = New System.Drawing.Size(155, 15)
        Me.pbarProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarProcess.TabIndex = 90
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblProcess.Location = New System.Drawing.Point(23, 142)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(85, 16)
        Me.lblProcess.TabIndex = 89
        Me.lblProcess.Text = "Processing..."
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(326, 142)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 91
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "To Date"
        '
        'DTPTo
        '
        Me.DTPTo.CustomFormat = "dd MMM yyyy"
        Me.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTo.Location = New System.Drawing.Point(204, 81)
        Me.DTPTo.Name = "DTPTo"
        Me.DTPTo.Size = New System.Drawing.Size(121, 21)
        Me.DTPTo.TabIndex = 93
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "From Date"
        '
        'DTPFrom
        '
        Me.DTPFrom.CustomFormat = "dd MMM yyyy"
        Me.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFrom.Location = New System.Drawing.Point(204, 48)
        Me.DTPFrom.Name = "DTPFrom"
        Me.DTPFrom.Size = New System.Drawing.Size(121, 21)
        Me.DTPFrom.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(126, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Client Code"
        '
        'cboClientCode
        '
        Me.cboClientCode.FormattingEnabled = True
        Me.cboClientCode.Location = New System.Drawing.Point(204, 16)
        Me.cboClientCode.Name = "cboClientCode"
        Me.cboClientCode.Size = New System.Drawing.Size(121, 23)
        Me.cboClientCode.TabIndex = 100
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(270, 142)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(50, 55)
        Me.btnSend.TabIndex = 101
        Me.btnSend.Text = "Send"
        Me.btnSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'FrmRptTradeHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(466, 210)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.cboClientCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTPTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPFrom)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pbarProcess)
        Me.Controls.Add(Me.lblProcess)
        Me.KeyPreview = True
        Me.Name = "FrmRptTradeHistory"
        Me.Text = "Export Trade History of CIES Clients"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarProcess, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.DTPFrom, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.DTPTo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboClientCode, 0)
        Me.Controls.SetChildIndex(Me.btnSend, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbarProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboClientCode As ESL.myComboBox
    Friend WithEvents btnSend As System.Windows.Forms.Button

End Class
