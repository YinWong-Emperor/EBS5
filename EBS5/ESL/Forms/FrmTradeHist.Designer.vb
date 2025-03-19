<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTradeHist
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.RBBoth = New System.Windows.Forms.RadioButton
        Me.RBAFE = New System.Windows.Forms.RadioButton
        Me.RBIASIA = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtStock = New ESL.myTextbox
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(302, 246)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(246, 246)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Export"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.RBBoth)
        Me.GroupBox1.Controls.Add(Me.RBAFE)
        Me.GroupBox1.Controls.Add(Me.RBIASIA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTPFrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtStock)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 228)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(216, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "99999"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(216, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(216, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "MM/DD/YYYY"
        '
        'RBBoth
        '
        Me.RBBoth.AutoSize = True
        Me.RBBoth.Location = New System.Drawing.Point(22, 187)
        Me.RBBoth.Name = "RBBoth"
        Me.RBBoth.Size = New System.Drawing.Size(318, 19)
        Me.RBBoth.TabIndex = 6
        Me.RBBoth.TabStop = True
        Me.RBBoth.Text = "Export from IASIA Before 11/04/2005, Others from AFE"
        Me.RBBoth.UseVisualStyleBackColor = True
        '
        'RBAFE
        '
        Me.RBAFE.AutoSize = True
        Me.RBAFE.Location = New System.Drawing.Point(22, 162)
        Me.RBAFE.Name = "RBAFE"
        Me.RBAFE.Size = New System.Drawing.Size(219, 19)
        Me.RBAFE.TabIndex = 5
        Me.RBAFE.TabStop = True
        Me.RBAFE.Text = "Export from AFE (New System) Only"
        Me.RBAFE.UseVisualStyleBackColor = True
        '
        'RBIASIA
        '
        Me.RBIASIA.AutoSize = True
        Me.RBIASIA.Location = New System.Drawing.Point(22, 137)
        Me.RBIASIA.Name = "RBIASIA"
        Me.RBIASIA.Size = New System.Drawing.Size(219, 19)
        Me.RBIASIA.TabIndex = 4
        Me.RBIASIA.TabStop = True
        Me.RBIASIA.Text = "Export from IASIA (Old System) Only"
        Me.RBIASIA.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "To Date"
        '
        'DTPTo
        '
        Me.DTPTo.CustomFormat = "MM/dd/yyyy"
        Me.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTo.Location = New System.Drawing.Point(95, 97)
        Me.DTPTo.Name = "DTPTo"
        Me.DTPTo.Size = New System.Drawing.Size(103, 21)
        Me.DTPTo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From Date"
        '
        'DTPFrom
        '
        Me.DTPFrom.CustomFormat = "MM/dd/yyyy"
        Me.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFrom.Location = New System.Drawing.Point(95, 59)
        Me.DTPFrom.Name = "DTPFrom"
        Me.DTPFrom.Size = New System.Drawing.Size(103, 21)
        Me.DTPFrom.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Stock Code"
        '
        'txtStock
        '
        Me.txtStock.Location = New System.Drawing.Point(95, 20)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(103, 21)
        Me.txtStock.TabIndex = 1
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(12, 278)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(345, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 23
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(9, 256)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 24
        Me.lblProcess.Text = "Processing"
        '
        'FrmTradeHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(365, 312)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FrmTradeHist"
        Me.Text = "Trade History"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStock As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBIASIA As System.Windows.Forms.RadioButton
    Friend WithEvents RBBoth As System.Windows.Forms.RadioButton
    Friend WithEvents RBAFE As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label

End Class
