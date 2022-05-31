<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientProfileRpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientProfileRpt))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpfrom = New ESL.myDateTimePicker
        Me.dpto = New ESL.myDateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbactualbigger = New ESL.myRadioButton(Me.components)
        Me.rball = New ESL.myRadioButton(Me.components)
        Me.rbindividual = New ESL.myRadioButton(Me.components)
        Me.rbcorporate = New ESL.myRadioButton(Me.components)
        Me.rbactualsmaller = New ESL.myRadioButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnView = New ESL.myButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(420, 309)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(364, 309)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Trading Period"
        '
        'dpfrom
        '
        Me.dpfrom.CustomFormat = "dd MMM yyyy"
        Me.dpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpfrom.Location = New System.Drawing.Point(182, 85)
        Me.dpfrom.Name = "dpfrom"
        Me.dpfrom.Size = New System.Drawing.Size(119, 21)
        Me.dpfrom.TabIndex = 7
        '
        'dpto
        '
        Me.dpto.CustomFormat = "dd MMM yyyy"
        Me.dpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpto.Location = New System.Drawing.Point(351, 85)
        Me.dpto.Name = "dpto"
        Me.dpto.Size = New System.Drawing.Size(119, 21)
        Me.dpto.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(316, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Filtering Criteria"
        '
        'rbactualbigger
        '
        Me.rbactualbigger.AutoSize = True
        Me.rbactualbigger.Checked = True
        Me.rbactualbigger.Location = New System.Drawing.Point(6, 20)
        Me.rbactualbigger.Name = "rbactualbigger"
        Me.rbactualbigger.Size = New System.Drawing.Size(271, 19)
        Me.rbactualbigger.TabIndex = 11
        Me.rbactualbigger.TabStop = True
        Me.rbactualbigger.Text = "Actual Trade Volume >= Indicated Investment"
        Me.rbactualbigger.UseVisualStyleBackColor = True
        '
        'rball
        '
        Me.rball.AutoSize = True
        Me.rball.Location = New System.Drawing.Point(195, 20)
        Me.rball.Name = "rball"
        Me.rball.Size = New System.Drawing.Size(38, 19)
        Me.rball.TabIndex = 12
        Me.rball.TabStop = True
        Me.rball.Text = "All"
        Me.rball.UseVisualStyleBackColor = True
        '
        'rbindividual
        '
        Me.rbindividual.AutoSize = True
        Me.rbindividual.Checked = True
        Me.rbindividual.Location = New System.Drawing.Point(6, 20)
        Me.rbindividual.Name = "rbindividual"
        Me.rbindividual.Size = New System.Drawing.Size(77, 19)
        Me.rbindividual.TabIndex = 13
        Me.rbindividual.TabStop = True
        Me.rbindividual.Text = "Individual"
        Me.rbindividual.UseVisualStyleBackColor = True
        '
        'rbcorporate
        '
        Me.rbcorporate.AutoSize = True
        Me.rbcorporate.Location = New System.Drawing.Point(99, 20)
        Me.rbcorporate.Name = "rbcorporate"
        Me.rbcorporate.Size = New System.Drawing.Size(80, 19)
        Me.rbcorporate.TabIndex = 14
        Me.rbcorporate.TabStop = True
        Me.rbcorporate.Text = "Corporate"
        Me.rbcorporate.UseVisualStyleBackColor = True
        '
        'rbactualsmaller
        '
        Me.rbactualsmaller.AutoSize = True
        Me.rbactualsmaller.Location = New System.Drawing.Point(6, 45)
        Me.rbactualsmaller.Name = "rbactualsmaller"
        Me.rbactualsmaller.Size = New System.Drawing.Size(264, 19)
        Me.rbactualsmaller.TabIndex = 15
        Me.rbactualsmaller.TabStop = True
        Me.rbactualsmaller.Text = "Actual Trade Volume < Indicated Investment"
        Me.rbactualsmaller.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbactualbigger)
        Me.GroupBox1.Controls.Add(Me.rbactualsmaller)
        Me.GroupBox1.Location = New System.Drawing.Point(182, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 79)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbindividual)
        Me.GroupBox2.Controls.Add(Me.rbcorporate)
        Me.GroupBox2.Controls.Add(Me.rball)
        Me.GroupBox2.Location = New System.Drawing.Point(182, 214)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 53)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Individual or Corporate"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnView.Location = New System.Drawing.Point(364, 309)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(50, 55)
        Me.btnView.TabIndex = 19
        Me.btnView.Text = "View"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(151, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(195, 22)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Client Profile Report"
        '
        'FrmClientProfileRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(529, 419)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dpto)
        Me.Controls.Add(Me.dpfrom)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmClientProfileRpt"
        Me.Text = "Client Profile Report"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dpfrom, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dpto, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpfrom As ESL.myDateTimePicker
    Friend WithEvents dpto As ESL.myDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbactualbigger As ESL.myRadioButton
    Friend WithEvents rball As ESL.myRadioButton
    Friend WithEvents rbindividual As ESL.myRadioButton
    Friend WithEvents rbcorporate As ESL.myRadioButton
    Friend WithEvents rbactualsmaller As ESL.myRadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnView As ESL.myButton
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
