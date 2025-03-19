<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptStockHldgSummary
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbPrinter = New ESL.myRadioButton(Me.components)
        Me.rbPreview = New ESL.myRadioButton(Me.components)
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.printDlg = New System.Windows.Forms.PrintDialog
        Me.MyTextbox1 = New ESL.myTextbox
        Me.Button_add = New ESL.myButton(Me.components)
        Me.Button_load = New ESL.myButton(Me.components)
        Me.Button_delete = New ESL.myButton(Me.components)
        Me.Button_delete_all = New ESL.myButton(Me.components)
        Me.MyListBox1 = New ESL.myListBox(Me.components)
        Me.MyButton1 = New ESL.myButton(Me.components)
        Me.MyButton2 = New ESL.myButton(Me.components)
        Me.MyButton3 = New ESL.myButton(Me.components)
        Me.MyButton4 = New ESL.myButton(Me.components)
        Me.MyListBox2 = New ESL.myListBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button_reload = New ESL.myButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarProcess = New System.Windows.Forms.ProgressBar
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(392, 282)
        Me.btnCancel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(335, 216)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbPrinter)
        Me.GroupBox3.Controls.Add(Me.rbPreview)
        Me.GroupBox3.Location = New System.Drawing.Point(97, 221)
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
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(336, 282)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'printDlg
        '
        Me.printDlg.UseEXDialog = True
        '
        'MyTextbox1
        '
        Me.MyTextbox1.Location = New System.Drawing.Point(96, 29)
        Me.MyTextbox1.Name = "MyTextbox1"
        Me.MyTextbox1.Size = New System.Drawing.Size(120, 21)
        Me.MyTextbox1.TabIndex = 17
        Me.MyTextbox1.Visible = False
        '
        'Button_add
        '
        Me.Button_add.Location = New System.Drawing.Point(96, 53)
        Me.Button_add.Name = "Button_add"
        Me.Button_add.Size = New System.Drawing.Size(75, 23)
        Me.Button_add.TabIndex = 18
        Me.Button_add.Text = "Add"
        Me.Button_add.UseVisualStyleBackColor = True
        Me.Button_add.Visible = False
        '
        'Button_load
        '
        Me.Button_load.Location = New System.Drawing.Point(223, 82)
        Me.Button_load.Name = "Button_load"
        Me.Button_load.Size = New System.Drawing.Size(75, 23)
        Me.Button_load.TabIndex = 19
        Me.Button_load.Text = "Load"
        Me.Button_load.UseVisualStyleBackColor = True
        '
        'Button_delete
        '
        Me.Button_delete.Location = New System.Drawing.Point(224, 58)
        Me.Button_delete.Name = "Button_delete"
        Me.Button_delete.Size = New System.Drawing.Size(75, 23)
        Me.Button_delete.TabIndex = 20
        Me.Button_delete.Text = "Delete"
        Me.Button_delete.UseVisualStyleBackColor = True
        Me.Button_delete.Visible = False
        '
        'Button_delete_all
        '
        Me.Button_delete_all.Location = New System.Drawing.Point(224, 87)
        Me.Button_delete_all.Name = "Button_delete_all"
        Me.Button_delete_all.Size = New System.Drawing.Size(75, 23)
        Me.Button_delete_all.TabIndex = 21
        Me.Button_delete_all.Text = "Delete All"
        Me.Button_delete_all.UseVisualStyleBackColor = True
        Me.Button_delete_all.Visible = False
        '
        'MyListBox1
        '
        Me.MyListBox1.FormattingEnabled = True
        Me.MyListBox1.ItemHeight = 15
        Me.MyListBox1.Location = New System.Drawing.Point(97, 81)
        Me.MyListBox1.Name = "MyListBox1"
        Me.MyListBox1.Size = New System.Drawing.Size(120, 184)
        Me.MyListBox1.TabIndex = 22
        '
        'MyButton1
        '
        Me.MyButton1.Location = New System.Drawing.Point(223, 111)
        Me.MyButton1.Name = "MyButton1"
        Me.MyButton1.Size = New System.Drawing.Size(75, 23)
        Me.MyButton1.TabIndex = 23
        Me.MyButton1.Text = ">"
        Me.MyButton1.UseVisualStyleBackColor = True
        '
        'MyButton2
        '
        Me.MyButton2.Location = New System.Drawing.Point(223, 140)
        Me.MyButton2.Name = "MyButton2"
        Me.MyButton2.Size = New System.Drawing.Size(75, 23)
        Me.MyButton2.TabIndex = 24
        Me.MyButton2.Text = ">>"
        Me.MyButton2.UseVisualStyleBackColor = True
        '
        'MyButton3
        '
        Me.MyButton3.Location = New System.Drawing.Point(223, 189)
        Me.MyButton3.Name = "MyButton3"
        Me.MyButton3.Size = New System.Drawing.Size(75, 23)
        Me.MyButton3.TabIndex = 25
        Me.MyButton3.Text = "<"
        Me.MyButton3.UseVisualStyleBackColor = True
        '
        'MyButton4
        '
        Me.MyButton4.Location = New System.Drawing.Point(223, 218)
        Me.MyButton4.Name = "MyButton4"
        Me.MyButton4.Size = New System.Drawing.Size(75, 23)
        Me.MyButton4.TabIndex = 26
        Me.MyButton4.Text = "<<"
        Me.MyButton4.UseVisualStyleBackColor = True
        '
        'MyListBox2
        '
        Me.MyListBox2.FormattingEnabled = True
        Me.MyListBox2.ItemHeight = 15
        Me.MyListBox2.Location = New System.Drawing.Point(209, 28)
        Me.MyListBox2.Name = "MyListBox2"
        Me.MyListBox2.Size = New System.Drawing.Size(120, 184)
        Me.MyListBox2.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Selected Client List"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Client ID"
        Me.Label2.Visible = False
        '
        'Button_reload
        '
        Me.Button_reload.Location = New System.Drawing.Point(224, 29)
        Me.Button_reload.Name = "Button_reload"
        Me.Button_reload.Size = New System.Drawing.Size(75, 23)
        Me.Button_reload.TabIndex = 30
        Me.Button_reload.Text = "Reload"
        Me.Button_reload.UseVisualStyleBackColor = True
        Me.Button_reload.Visible = False
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(93, 284)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 32
        Me.lblProcess.Text = "Processing"
        '
        'pbarProcess
        '
        Me.pbarProcess.Location = New System.Drawing.Point(96, 302)
        Me.pbarProcess.Name = "pbarProcess"
        Me.pbarProcess.Size = New System.Drawing.Size(329, 16)
        Me.pbarProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarProcess.TabIndex = 31
        '
        'FrmRptStockHldgSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(524, 349)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MyListBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarProcess)
        Me.Controls.Add(Me.Button_reload)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button_delete_all)
        Me.Controls.Add(Me.Button_delete)
        Me.Controls.Add(Me.Button_load)
        Me.Controls.Add(Me.Button_add)
        Me.Controls.Add(Me.MyTextbox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.MyListBox1)
        Me.Controls.Add(Me.MyButton4)
        Me.Controls.Add(Me.MyButton3)
        Me.Controls.Add(Me.MyButton2)
        Me.Controls.Add(Me.MyButton1)
        Me.KeyPreview = True
        Me.Name = "FrmRptStockHldgSummary"
        Me.Text = "Stock Holding Summary Report"
        Me.Controls.SetChildIndex(Me.MyButton1, 0)
        Me.Controls.SetChildIndex(Me.MyButton2, 0)
        Me.Controls.SetChildIndex(Me.MyButton3, 0)
        Me.Controls.SetChildIndex(Me.MyButton4, 0)
        Me.Controls.SetChildIndex(Me.MyListBox1, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.MyTextbox1, 0)
        Me.Controls.SetChildIndex(Me.Button_add, 0)
        Me.Controls.SetChildIndex(Me.Button_load, 0)
        Me.Controls.SetChildIndex(Me.Button_delete, 0)
        Me.Controls.SetChildIndex(Me.Button_delete_all, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Button_reload, 0)
        Me.Controls.SetChildIndex(Me.pbarProcess, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.MyListBox2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPrinter As ESL.myRadioButton
    Friend WithEvents rbPreview As ESL.myRadioButton
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents printDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents MyTextbox1 As ESL.myTextbox
    Friend WithEvents Button_add As ESL.myButton
    Friend WithEvents Button_load As ESL.myButton
    Friend WithEvents Button_delete As ESL.myButton
    Friend WithEvents Button_delete_all As ESL.myButton
    Friend WithEvents MyListBox1 As ESL.myListBox
    Friend WithEvents MyButton1 As ESL.myButton
    Friend WithEvents MyButton2 As ESL.myButton
    Friend WithEvents MyButton3 As ESL.myButton
    Friend WithEvents MyButton4 As ESL.myButton
    Friend WithEvents MyListBox2 As ESL.myListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_reload As ESL.myButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarProcess As System.Windows.Forms.ProgressBar

End Class
