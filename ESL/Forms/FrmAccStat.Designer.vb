<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccStat
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudday = New ESL.myNumericUpDown(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudMth = New ESL.myNumericUpDown(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dpFrom = New ESL.myDateTimePicker()
        Me.dpTo = New ESL.myDateTimePicker()
        Me.btnNewAcc = New ESL.myButton(Me.components)
        Me.btnNActAcc = New ESL.myButton(Me.components)
        Me.btnActAcc = New ESL.myButton(Me.components)
        Me.btnTtlAcc = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBStock = New ESL.myRadioButton(Me.components)
        Me.RBFutures = New ESL.myRadioButton(Me.components)
        Me.plAccStat = New System.Windows.Forms.GroupBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        CType(Me.nudday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.plAccStat.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(472, 310)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(416, 310)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(182, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(189, 22)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Client A/C Statistics"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(283, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "months"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(182, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "within"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(394, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "days"
        '
        'nudday
        '
        Me.nudday.Location = New System.Drawing.Point(338, 117)
        Me.nudday.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudday.Name = "nudday"
        Me.nudday.Size = New System.Drawing.Size(50, 21)
        Me.nudday.TabIndex = 15
        Me.nudday.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Opened From"
        '
        'nudMth
        '
        Me.nudMth.Location = New System.Drawing.Point(227, 117)
        Me.nudMth.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudMth.Name = "nudMth"
        Me.nudMth.Size = New System.Drawing.Size(50, 21)
        Me.nudMth.TabIndex = 14
        Me.nudMth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMth.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(380, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 15)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "To"
        '
        'dpFrom
        '
        Me.dpFrom.CustomFormat = "dd/MM/yyyy"
        Me.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFrom.Location = New System.Drawing.Point(271, 190)
        Me.dpFrom.Name = "dpFrom"
        Me.dpFrom.Size = New System.Drawing.Size(103, 21)
        Me.dpFrom.TabIndex = 13
        '
        'dpTo
        '
        Me.dpTo.CustomFormat = "dd/MM/yyyy"
        Me.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpTo.Location = New System.Drawing.Point(407, 190)
        Me.dpTo.Name = "dpTo"
        Me.dpTo.Size = New System.Drawing.Size(103, 21)
        Me.dpTo.TabIndex = 21
        '
        'btnNewAcc
        '
        Me.btnNewAcc.Location = New System.Drawing.Point(19, 187)
        Me.btnNewAcc.Name = "btnNewAcc"
        Me.btnNewAcc.Size = New System.Drawing.Size(138, 27)
        Me.btnNewAcc.TabIndex = 9
        Me.btnNewAcc.Text = "List of New A/C"
        Me.btnNewAcc.UseVisualStyleBackColor = True
        '
        'btnNActAcc
        '
        Me.btnNActAcc.Location = New System.Drawing.Point(19, 129)
        Me.btnNActAcc.Name = "btnNActAcc"
        Me.btnNActAcc.Size = New System.Drawing.Size(138, 27)
        Me.btnNActAcc.TabIndex = 8
        Me.btnNActAcc.Text = "List of Non-active A/C"
        Me.btnNActAcc.UseVisualStyleBackColor = True
        '
        'btnActAcc
        '
        Me.btnActAcc.Location = New System.Drawing.Point(19, 96)
        Me.btnActAcc.Name = "btnActAcc"
        Me.btnActAcc.Size = New System.Drawing.Size(138, 27)
        Me.btnActAcc.TabIndex = 7
        Me.btnActAcc.Text = "List of Active A/C"
        Me.btnActAcc.UseVisualStyleBackColor = True
        '
        'btnTtlAcc
        '
        Me.btnTtlAcc.Location = New System.Drawing.Point(19, 45)
        Me.btnTtlAcc.Name = "btnTtlAcc"
        Me.btnTtlAcc.Size = New System.Drawing.Size(138, 27)
        Me.btnTtlAcc.TabIndex = 6
        Me.btnTtlAcc.Text = "Total No. of A/C"
        Me.btnTtlAcc.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBStock)
        Me.GroupBox1.Controls.Add(Me.RBFutures)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 32)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'RBStock
        '
        Me.RBStock.AutoSize = True
        Me.RBStock.Checked = True
        Me.RBStock.Location = New System.Drawing.Point(6, 10)
        Me.RBStock.Name = "RBStock"
        Me.RBStock.Size = New System.Drawing.Size(55, 19)
        Me.RBStock.TabIndex = 10
        Me.RBStock.TabStop = True
        Me.RBStock.Text = "Stock"
        Me.RBStock.UseVisualStyleBackColor = True
        '
        'RBFutures
        '
        Me.RBFutures.AutoSize = True
        Me.RBFutures.Location = New System.Drawing.Point(67, 10)
        Me.RBFutures.Name = "RBFutures"
        Me.RBFutures.Size = New System.Drawing.Size(67, 19)
        Me.RBFutures.TabIndex = 11
        Me.RBFutures.Text = "Futures"
        Me.RBFutures.UseVisualStyleBackColor = True
        '
        'plAccStat
        '
        Me.plAccStat.Controls.Add(Me.GroupBox1)
        Me.plAccStat.Controls.Add(Me.btnTtlAcc)
        Me.plAccStat.Controls.Add(Me.btnActAcc)
        Me.plAccStat.Controls.Add(Me.btnNActAcc)
        Me.plAccStat.Controls.Add(Me.btnNewAcc)
        Me.plAccStat.Controls.Add(Me.dpTo)
        Me.plAccStat.Controls.Add(Me.dpFrom)
        Me.plAccStat.Controls.Add(Me.Label5)
        Me.plAccStat.Controls.Add(Me.nudMth)
        Me.plAccStat.Controls.Add(Me.Label4)
        Me.plAccStat.Controls.Add(Me.nudday)
        Me.plAccStat.Controls.Add(Me.Label3)
        Me.plAccStat.Controls.Add(Me.Label1)
        Me.plAccStat.Controls.Add(Me.Label2)
        Me.plAccStat.Controls.Add(Me.ShapeContainer1)
        Me.plAccStat.Location = New System.Drawing.Point(12, 58)
        Me.plAccStat.Name = "plAccStat"
        Me.plAccStat.Size = New System.Drawing.Size(524, 246)
        Me.plAccStat.TabIndex = 40
        Me.plAccStat.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 17)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(518, 226)
        Me.ShapeContainer1.TabIndex = 23
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Silver
        Me.LineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LineShape2.Cursor = System.Windows.Forms.Cursors.No
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 21
        Me.LineShape2.X2 = 499
        Me.LineShape2.Y1 = 154
        Me.LineShape2.Y2 = 154
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Silver
        Me.LineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LineShape1.Cursor = System.Windows.Forms.Cursors.No
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 24
        Me.LineShape1.X2 = 502
        Me.LineShape1.Y1 = 70
        Me.LineShape1.Y2 = 70
        '
        'FrmAccStat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(545, 375)
        Me.Controls.Add(Me.plAccStat)
        Me.Controls.Add(Me.Label11)
        Me.KeyPreview = True
        Me.Name = "FrmAccStat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client A/C Statistics"
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.plAccStat, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        CType(Me.nudday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.plAccStat.ResumeLayout(False)
        Me.plAccStat.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudday As ESL.myNumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudMth As ESL.myNumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dpFrom As ESL.myDateTimePicker
    Friend WithEvents dpTo As ESL.myDateTimePicker
    Friend WithEvents btnNewAcc As ESL.myButton
    Friend WithEvents btnNActAcc As ESL.myButton
    Friend WithEvents btnActAcc As ESL.myButton
    Friend WithEvents btnTtlAcc As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBStock As ESL.myRadioButton
    Friend WithEvents RBFutures As ESL.myRadioButton
    Friend WithEvents plAccStat As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape

End Class
