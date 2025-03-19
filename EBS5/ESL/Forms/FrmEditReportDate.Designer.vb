<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditReportDate
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditReportDate))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboEmailSubject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CurTradeDate = New System.Windows.Forms.DateTimePicker()
        Me.NxtTradeDate = New System.Windows.Forms.DateTimePicker()
        Me.TradeDateInd = New System.Windows.Forms.Label()
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnCancel = New ESL.myButton(Me.components)
        Me.btnSave = New ESL.myButton(Me.components)
        Me.PrvTradeDate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(308, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(216, 22)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Edit Email Report Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboEmailSubject
        '
        Me.cboEmailSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmailSubject.FormattingEnabled = True
        Me.cboEmailSubject.Location = New System.Drawing.Point(240, 93)
        Me.cboEmailSubject.Name = "cboEmailSubject"
        Me.cboEmailSubject.Size = New System.Drawing.Size(398, 21)
        Me.cboEmailSubject.TabIndex = 122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(130, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Email Subject"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExit.Location = New System.Drawing.Point(587, 359)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(51, 54)
        Me.btnExit.TabIndex = 125
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(94, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 15)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Previous Trade Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(101, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 15)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Current Trade Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(118, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 15)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Next Trade Date"
        '
        'CurTradeDate
        '
        Me.CurTradeDate.Enabled = False
        Me.CurTradeDate.Location = New System.Drawing.Point(240, 201)
        Me.CurTradeDate.Name = "CurTradeDate"
        Me.CurTradeDate.Size = New System.Drawing.Size(272, 20)
        Me.CurTradeDate.TabIndex = 135
        '
        'NxtTradeDate
        '
        Me.NxtTradeDate.Enabled = False
        Me.NxtTradeDate.Location = New System.Drawing.Point(240, 237)
        Me.NxtTradeDate.Name = "NxtTradeDate"
        Me.NxtTradeDate.Size = New System.Drawing.Size(272, 20)
        Me.NxtTradeDate.TabIndex = 136
        '
        'TradeDateInd
        '
        Me.TradeDateInd.AutoSize = True
        Me.TradeDateInd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.TradeDateInd.Location = New System.Drawing.Point(527, 205)
        Me.TradeDateInd.Name = "TradeDateInd"
        Me.TradeDateInd.Size = New System.Drawing.Size(0, 15)
        Me.TradeDateInd.TabIndex = 138
        Me.TradeDateInd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(312, 286)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 23)
        Me.btnEdit.TabIndex = 137
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(428, 286)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 23)
        Me.btnCancel.TabIndex = 130
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(515, 359)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(51, 54)
        Me.btnSave.TabIndex = 129
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'PrvTradeDate
        '
        Me.PrvTradeDate.Enabled = False
        Me.PrvTradeDate.Location = New System.Drawing.Point(240, 164)
        Me.PrvTradeDate.Name = "PrvTradeDate"
        Me.PrvTradeDate.Size = New System.Drawing.Size(272, 20)
        Me.PrvTradeDate.TabIndex = 139
        '
        'FrmEditReportDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.PrvTradeDate)
        Me.Controls.Add(Me.TradeDateInd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.NxtTradeDate)
        Me.Controls.Add(Me.CurTradeDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEmailSubject)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmEditReportDate"
        Me.Text = "Edit Report Date"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents cboEmailSubject As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSave As myButton
    Friend WithEvents btnCancel As myButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CurTradeDate As DateTimePicker
    Friend WithEvents NxtTradeDate As DateTimePicker
    Friend WithEvents btnEdit As myButton
    Friend WithEvents TradeDateInd As Label
    Friend WithEvents PrvTradeDate As DateTimePicker
End Class
