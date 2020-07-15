<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChequePrintingDetails
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.gbxMain = New System.Windows.Forms.GroupBox()
        Me.btnCheckName = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdb_AE = New System.Windows.Forms.RadioButton()
        Me.rdb_Client = New System.Windows.Forms.RadioButton()
        Me.nudAmount = New ESL.myNumericUpDown(Me.components)
        Me.amtSequence = New ESL.myAmountBox()
        Me.dtpTxnDate = New ESL.myDateTimePicker()
        Me.txtClientName = New ESL.myTextbox()
        Me.txtClientCode = New ESL.myTextbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnDel = New ESL.myButton(Me.components)
        Me.gbxMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(444, 186)
        Me.btnCancel.TabIndex = 14
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(392, 186)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Visible = True
        '
        'gbxMain
        '
        Me.gbxMain.Controls.Add(Me.btnCheckName)
        Me.gbxMain.Controls.Add(Me.GroupBox1)
        Me.gbxMain.Controls.Add(Me.nudAmount)
        Me.gbxMain.Controls.Add(Me.amtSequence)
        Me.gbxMain.Controls.Add(Me.dtpTxnDate)
        Me.gbxMain.Controls.Add(Me.txtClientName)
        Me.gbxMain.Controls.Add(Me.txtClientCode)
        Me.gbxMain.Controls.Add(Me.Label5)
        Me.gbxMain.Controls.Add(Me.Label4)
        Me.gbxMain.Controls.Add(Me.Label3)
        Me.gbxMain.Controls.Add(Me.Label2)
        Me.gbxMain.Controls.Add(Me.Label1)
        Me.gbxMain.Location = New System.Drawing.Point(12, 12)
        Me.gbxMain.Name = "gbxMain"
        Me.gbxMain.Size = New System.Drawing.Size(482, 167)
        Me.gbxMain.TabIndex = 6
        Me.gbxMain.TabStop = False
        '
        'btnCheckName
        '
        Me.btnCheckName.Location = New System.Drawing.Point(241, 54)
        Me.btnCheckName.Name = "btnCheckName"
        Me.btnCheckName.Size = New System.Drawing.Size(90, 23)
        Me.btnCheckName.TabIndex = 10
        Me.btnCheckName.Text = "Check Name"
        Me.btnCheckName.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdb_AE)
        Me.GroupBox1.Controls.Add(Me.rdb_Client)
        Me.GroupBox1.Location = New System.Drawing.Point(337, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 66)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type"
        '
        'rdb_AE
        '
        Me.rdb_AE.AutoSize = True
        Me.rdb_AE.Checked = True
        Me.rdb_AE.Location = New System.Drawing.Point(61, 14)
        Me.rdb_AE.Name = "rdb_AE"
        Me.rdb_AE.Size = New System.Drawing.Size(40, 19)
        Me.rdb_AE.TabIndex = 6
        Me.rdb_AE.TabStop = True
        Me.rdb_AE.Text = "AE"
        Me.rdb_AE.UseVisualStyleBackColor = True
        '
        'rdb_Client
        '
        Me.rdb_Client.AutoSize = True
        Me.rdb_Client.Location = New System.Drawing.Point(61, 39)
        Me.rdb_Client.Name = "rdb_Client"
        Me.rdb_Client.Size = New System.Drawing.Size(57, 19)
        Me.rdb_Client.TabIndex = 7
        Me.rdb_Client.Text = "Client"
        Me.rdb_Client.UseVisualStyleBackColor = True
        '
        'nudAmount
        '
        Me.nudAmount.DecimalPlaces = 2
        Me.nudAmount.Location = New System.Drawing.Point(88, 128)
        Me.nudAmount.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.nudAmount.Minimum = New Decimal(New Integer() {1410065407, 2, 0, -2147352576})
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(147, 21)
        Me.nudAmount.TabIndex = 4
        Me.nudAmount.Tag = "1"
        Me.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAmount.ThousandsSeparator = True
        '
        'amtSequence
        '
        Me.amtSequence.DecimalPoints = 0
        Me.amtSequence.Enabled = False
        Me.amtSequence.EnabledRemoveTrailingZero = False
        Me.amtSequence.IntLen = 9
        Me.amtSequence.Location = New System.Drawing.Point(88, 20)
        Me.amtSequence.Name = "amtSequence"
        Me.amtSequence.Size = New System.Drawing.Size(147, 21)
        Me.amtSequence.TabIndex = 1
        Me.amtSequence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpTxnDate
        '
        Me.dtpTxnDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpTxnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTxnDate.Location = New System.Drawing.Point(308, 128)
        Me.dtpTxnDate.Name = "dtpTxnDate"
        Me.dtpTxnDate.Size = New System.Drawing.Size(168, 21)
        Me.dtpTxnDate.TabIndex = 5
        '
        'txtClientName
        '
        Me.txtClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientName.Location = New System.Drawing.Point(88, 92)
        Me.txtClientName.MaxLength = 120
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(388, 21)
        Me.txtClientName.TabIndex = 3
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(88, 56)
        Me.txtClientCode.MaxLength = 8
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(147, 21)
        Me.txtClientCode.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Txn. Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Client Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Client Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sequence"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = Global.ESL.My.Resources.Resources.btnEdit_Image
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(12, 188)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDel.Image = Global.ESL.My.Resources.Resources.btnDelete_Image
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDel.Location = New System.Drawing.Point(392, 186)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(50, 55)
        Me.btnDel.TabIndex = 11
        Me.btnDel.Text = "Delete"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'FrmChequePrintingDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 255)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.gbxMain)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmChequePrintingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Cheque Details"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.gbxMain, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDel, 0)
        Me.gbxMain.ResumeLayout(False)
        Me.gbxMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTxnDate As ESL.myDateTimePicker
    Friend WithEvents txtClientName As ESL.myTextbox
    Friend WithEvents txtClientCode As ESL.myTextbox
    Friend WithEvents amtSequence As ESL.myAmountBox
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnDel As ESL.myButton
    Friend WithEvents nudAmount As ESL.myNumericUpDown
    Friend WithEvents rdb_Client As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_AE As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCheckName As System.Windows.Forms.Button
End Class
