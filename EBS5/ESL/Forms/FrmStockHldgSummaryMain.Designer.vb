<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStockHldgSummaryMain
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.MyListBox2 = New ESL.myListBox(Me.components)
        Me.Button_reload = New ESL.myButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button_delete_all = New ESL.myButton(Me.components)
        Me.Button_delete = New ESL.myButton(Me.components)
        Me.MyTextbox1 = New ESL.myTextbox
        Me.Button_add = New ESL.myButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarProcess = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(360, 270)
        Me.btnCancel.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(300, 269)
        Me.btnSave.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(297, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Selected Client List"
        '
        'MyListBox2
        '
        Me.MyListBox2.FormattingEnabled = True
        Me.MyListBox2.ItemHeight = 15
        Me.MyListBox2.Location = New System.Drawing.Point(300, 29)
        Me.MyListBox2.Name = "MyListBox2"
        Me.MyListBox2.Size = New System.Drawing.Size(120, 229)
        Me.MyListBox2.TabIndex = 6
        '
        'Button_reload
        '
        Me.Button_reload.Location = New System.Drawing.Point(219, 32)
        Me.Button_reload.Name = "Button_reload"
        Me.Button_reload.Size = New System.Drawing.Size(75, 23)
        Me.Button_reload.TabIndex = 3
        Me.Button_reload.Text = "Reload"
        Me.Button_reload.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Client ID"
        Me.Label2.Visible = False
        '
        'Button_delete_all
        '
        Me.Button_delete_all.Location = New System.Drawing.Point(219, 90)
        Me.Button_delete_all.Name = "Button_delete_all"
        Me.Button_delete_all.Size = New System.Drawing.Size(75, 23)
        Me.Button_delete_all.TabIndex = 5
        Me.Button_delete_all.Text = "Delete All"
        Me.Button_delete_all.UseVisualStyleBackColor = True
        '
        'Button_delete
        '
        Me.Button_delete.Location = New System.Drawing.Point(219, 61)
        Me.Button_delete.Name = "Button_delete"
        Me.Button_delete.Size = New System.Drawing.Size(75, 23)
        Me.Button_delete.TabIndex = 4
        Me.Button_delete.Text = "Delete"
        Me.Button_delete.UseVisualStyleBackColor = True
        '
        'MyTextbox1
        '
        Me.MyTextbox1.Location = New System.Drawing.Point(91, 32)
        Me.MyTextbox1.Name = "MyTextbox1"
        Me.MyTextbox1.Size = New System.Drawing.Size(120, 21)
        Me.MyTextbox1.TabIndex = 1
        '
        'Button_add
        '
        Me.Button_add.Location = New System.Drawing.Point(91, 59)
        Me.Button_add.Name = "Button_add"
        Me.Button_add.Size = New System.Drawing.Size(75, 23)
        Me.Button_add.TabIndex = 2
        Me.Button_add.Text = "Add"
        Me.Button_add.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(88, 276)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 40
        Me.lblProcess.Text = "Processing"
        '
        'pbarProcess
        '
        Me.pbarProcess.Location = New System.Drawing.Point(91, 294)
        Me.pbarProcess.Name = "pbarProcess"
        Me.pbarProcess.Size = New System.Drawing.Size(329, 16)
        Me.pbarProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarProcess.TabIndex = 39
        '
        'FrmStockHldgSummaryMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(573, 367)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarProcess)
        Me.Controls.Add(Me.Button_add)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MyListBox2)
        Me.Controls.Add(Me.Button_reload)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button_delete_all)
        Me.Controls.Add(Me.Button_delete)
        Me.Controls.Add(Me.MyTextbox1)
        Me.KeyPreview = True
        Me.Name = "FrmStockHldgSummaryMain"
        Me.Text = "Client List of Stock Holding Summary"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.MyTextbox1, 0)
        Me.Controls.SetChildIndex(Me.Button_delete, 0)
        Me.Controls.SetChildIndex(Me.Button_delete_all, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Button_reload, 0)
        Me.Controls.SetChildIndex(Me.MyListBox2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Button_add, 0)
        Me.Controls.SetChildIndex(Me.pbarProcess, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MyListBox2 As ESL.myListBox
    Friend WithEvents Button_reload As ESL.myButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_delete_all As ESL.myButton
    Friend WithEvents Button_delete As ESL.myButton
    Friend WithEvents MyTextbox1 As ESL.myTextbox
    Friend WithEvents Button_add As ESL.myButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarProcess As System.Windows.Forms.ProgressBar

End Class
