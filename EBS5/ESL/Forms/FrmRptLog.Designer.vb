<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptLog
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboLogType = New ESL.myComboBox(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.MyDateTimePicker2 = New ESL.myDateTimePicker
        Me.MyDateTimePicker1 = New ESL.myDateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbPrinter = New ESL.myRadioButton(Me.components)
        Me.rbPreview = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.pbarProcess = New System.Windows.Forms.ProgressBar
        Me.printDlg = New System.Windows.Forms.PrintDialog
        Me.MyTextbox1 = New ESL.myTextbox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtAccNo = New ESL.myTextbox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(311, 311)
        Me.btnCancel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(255, 311)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboLogType)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 58)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type of Log"
        '
        'cboLogType
        '
        Me.cboLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLogType.FormattingEnabled = True
        Me.cboLogType.Location = New System.Drawing.Point(20, 20)
        Me.cboLogType.Name = "cboLogType"
        Me.cboLogType.Size = New System.Drawing.Size(304, 23)
        Me.cboLogType.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MyDateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.MyDateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 57)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Log Date"
        '
        'MyDateTimePicker2
        '
        Me.MyDateTimePicker2.CustomFormat = "dd MMM yyyy"
        Me.MyDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MyDateTimePicker2.Location = New System.Drawing.Point(208, 20)
        Me.MyDateTimePicker2.Name = "MyDateTimePicker2"
        Me.MyDateTimePicker2.Size = New System.Drawing.Size(116, 21)
        Me.MyDateTimePicker2.TabIndex = 1
        '
        'MyDateTimePicker1
        '
        Me.MyDateTimePicker1.CustomFormat = "dd MMM yyyy"
        Me.MyDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MyDateTimePicker1.Location = New System.Drawing.Point(59, 20)
        Me.MyDateTimePicker1.Name = "MyDateTimePicker1"
        Me.MyDateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.MyDateTimePicker1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(181, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbPrinter)
        Me.GroupBox3.Controls.Add(Me.rbPreview)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 210)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 54)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Print Option"
        '
        'rbPrinter
        '
        Me.rbPrinter.AutoSize = True
        Me.rbPrinter.Location = New System.Drawing.Point(150, 20)
        Me.rbPrinter.Name = "rbPrinter"
        Me.rbPrinter.Size = New System.Drawing.Size(108, 19)
        Me.rbPrinter.TabIndex = 1
        Me.rbPrinter.TabStop = True
        Me.rbPrinter.Text = "Direct to printer"
        Me.rbPrinter.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Location = New System.Drawing.Point(20, 20)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(68, 19)
        Me.rbPreview.TabIndex = 0
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(11, 271)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 8
        Me.lblProcess.Text = "Processing"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(255, 311)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'pbarProcess
        '
        Me.pbarProcess.Location = New System.Drawing.Point(14, 290)
        Me.pbarProcess.Name = "pbarProcess"
        Me.pbarProcess.Size = New System.Drawing.Size(341, 12)
        Me.pbarProcess.TabIndex = 10
        '
        'printDlg
        '
        Me.printDlg.UseEXDialog = True
        '
        'MyTextbox1
        '
        Me.MyTextbox1.Location = New System.Drawing.Point(370, 312)
        Me.MyTextbox1.Name = "MyTextbox1"
        Me.MyTextbox1.Size = New System.Drawing.Size(8, 21)
        Me.MyTextbox1.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtAccNo)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 141)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(341, 57)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Account No."
        '
        'txtAccNo
        '
        Me.txtAccNo.Location = New System.Drawing.Point(60, 20)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(116, 21)
        Me.txtAccNo.TabIndex = 0
        '
        'FrmRptLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(372, 378)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.MyTextbox1)
        Me.Controls.Add(Me.pbarProcess)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.KeyPreview = True
        Me.Name = "FrmRptLog"
        Me.Text = "Log Report"
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.pbarProcess, 0)
        Me.Controls.SetChildIndex(Me.MyTextbox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLogType As ESL.myComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MyDateTimePicker1 As ESL.myDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbPrinter As ESL.myRadioButton
    Friend WithEvents rbPreview As ESL.myRadioButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents pbarProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents printDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents MyDateTimePicker2 As ESL.myDateTimePicker
    Friend WithEvents MyTextbox1 As ESL.myTextbox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAccNo As ESL.myTextbox

End Class
