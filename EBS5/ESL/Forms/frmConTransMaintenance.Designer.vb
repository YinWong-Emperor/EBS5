<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConTransMaintenance
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
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.txtGroup = New ESL.myTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbClient = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbGroup = New ESL.myListBox(Me.components)
        Me.lbClient = New ESL.myListBox(Me.components)
        Me.btnUP = New ESL.myButton(Me.components)
        Me.btnDown = New ESL.myButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.PrintOption = New System.Windows.Forms.GroupBox()
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtCurrent = New ESL.myRadioButton(Me.components)
        Me.rbtAll = New ESL.myRadioButton(Me.components)
        Me.MyDateTimePicker1 = New ESL.myDateTimePicker()
        Me.MyDateTimePicker2 = New ESL.myDateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.PrintOption.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(450, 487)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(394, 487)
        Me.btnSave.Visible = True
        '
        'btnEdit
        '
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(88, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(80, 23)
        Me.btnEdit.TabIndex = 6
        Me.btnEdit.Text = "Edit Group"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(3, 3)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(80, 23)
        Me.btnNew.TabIndex = 7
        Me.btnNew.Text = "New Group"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.Location = New System.Drawing.Point(180, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(165, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add Client"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(338, 487)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'txtGroup
        '
        Me.txtGroup.Enabled = False
        Me.txtGroup.Location = New System.Drawing.Point(3, 33)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(165, 21)
        Me.txtGroup.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Group"
        '
        'cmbClient
        '
        Me.cmbClient.Enabled = False
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(180, 31)
        Me.cmbClient.MaxLength = 8
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(165, 23)
        Me.cmbClient.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Client"
        '
        'lbGroup
        '
        Me.lbGroup.FormattingEnabled = True
        Me.lbGroup.ItemHeight = 15
        Me.lbGroup.Location = New System.Drawing.Point(6, 76)
        Me.lbGroup.Name = "lbGroup"
        Me.lbGroup.Size = New System.Drawing.Size(165, 244)
        Me.lbGroup.TabIndex = 16
        '
        'lbClient
        '
        Me.lbClient.FormattingEnabled = True
        Me.lbClient.ItemHeight = 15
        Me.lbClient.Location = New System.Drawing.Point(180, 76)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(165, 244)
        Me.lbClient.TabIndex = 17
        '
        'btnUP
        '
        Me.btnUP.Enabled = False
        Me.btnUP.Location = New System.Drawing.Point(351, 76)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(50, 23)
        Me.btnUP.TabIndex = 18
        Me.btnUP.Text = "UP"
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Enabled = False
        Me.btnDown.Location = New System.Drawing.Point(351, 105)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(50, 23)
        Me.btnDown.TabIndex = 19
        Me.btnDown.Text = "Down"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(363, 29)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Connected Transaction Report"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnDown)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.btnUP)
        Me.Panel1.Controls.Add(Me.cmbClient)
        Me.Panel1.Controls.Add(Me.lbClient)
        Me.Panel1.Controls.Add(Me.txtGroup)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbGroup)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(43, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 325)
        Me.Panel1.TabIndex = 21
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(43, 527)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(289, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 57
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(40, 509)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 56
        Me.lblProcess.Text = "Processing"
        '
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(43, 396)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(171, 45)
        Me.PrintOption.TabIndex = 58
        Me.PrintOption.TabStop = False
        Me.PrintOption.Text = "Print / Preview"
        '
        'rbtPrint
        '
        Me.rbtPrint.AutoSize = True
        Me.rbtPrint.Location = New System.Drawing.Point(116, 20)
        Me.rbtPrint.Name = "rbtPrint"
        Me.rbtPrint.Size = New System.Drawing.Size(50, 19)
        Me.rbtPrint.TabIndex = 1
        Me.rbtPrint.Text = "Print"
        Me.rbtPrint.UseVisualStyleBackColor = True
        '
        'rbtPreview
        '
        Me.rbtPreview.AutoSize = True
        Me.rbtPreview.Checked = True
        Me.rbtPreview.Location = New System.Drawing.Point(6, 20)
        Me.rbtPreview.Name = "rbtPreview"
        Me.rbtPreview.Size = New System.Drawing.Size(68, 19)
        Me.rbtPreview.TabIndex = 0
        Me.rbtPreview.TabStop = True
        Me.rbtPreview.Text = "Preview"
        Me.rbtPreview.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtCurrent)
        Me.GroupBox1.Controls.Add(Me.rbtAll)
        Me.GroupBox1.Location = New System.Drawing.Point(223, 396)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 45)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Option"
        '
        'rbtCurrent
        '
        Me.rbtCurrent.AutoSize = True
        Me.rbtCurrent.Checked = True
        Me.rbtCurrent.Location = New System.Drawing.Point(120, 20)
        Me.rbtCurrent.Name = "rbtCurrent"
        Me.rbtCurrent.Size = New System.Drawing.Size(103, 19)
        Me.rbtCurrent.TabIndex = 1
        Me.rbtCurrent.TabStop = True
        Me.rbtCurrent.Text = "Current Group"
        Me.rbtCurrent.UseVisualStyleBackColor = True
        '
        'rbtAll
        '
        Me.rbtAll.AutoSize = True
        Me.rbtAll.Location = New System.Drawing.Point(6, 20)
        Me.rbtAll.Name = "rbtAll"
        Me.rbtAll.Size = New System.Drawing.Size(90, 19)
        Me.rbtAll.TabIndex = 0
        Me.rbtAll.Text = "ALL Groups"
        Me.rbtAll.UseVisualStyleBackColor = True
        '
        'MyDateTimePicker1
        '
        Me.MyDateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.MyDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MyDateTimePicker1.Location = New System.Drawing.Point(53, 14)
        Me.MyDateTimePicker1.Name = "MyDateTimePicker1"
        Me.MyDateTimePicker1.Size = New System.Drawing.Size(115, 21)
        Me.MyDateTimePicker1.TabIndex = 60
        '
        'MyDateTimePicker2
        '
        Me.MyDateTimePicker2.CustomFormat = "dd/MM/yyyy"
        Me.MyDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MyDateTimePicker2.Location = New System.Drawing.Point(218, 14)
        Me.MyDateTimePicker2.Name = "MyDateTimePicker2"
        Me.MyDateTimePicker2.Size = New System.Drawing.Size(115, 21)
        Me.MyDateTimePicker2.TabIndex = 61
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.MyDateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.MyDateTimePicker2)
        Me.GroupBox2.Location = New System.Drawing.Point(43, 441)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 40)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time Period"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(183, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 15)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "From"
        '
        'frmConTransMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(506, 550)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PrintOption)
        Me.Controls.Add(Me.btnPrint)
        Me.KeyPreview = True
        Me.Name = "frmConTransMaintenance"
        Me.Text = "Connected Transaction Maintenance"
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.PrintOption, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents txtGroup As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbClient As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbGroup As ESL.myListBox
    Friend WithEvents lbClient As ESL.myListBox
    Friend WithEvents btnUP As ESL.myButton
    Friend WithEvents btnDown As ESL.myButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtCurrent As ESL.myRadioButton
    Friend WithEvents rbtAll As ESL.myRadioButton
    Friend WithEvents MyDateTimePicker1 As ESL.myDateTimePicker
    Friend WithEvents MyDateTimePicker2 As ESL.myDateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
