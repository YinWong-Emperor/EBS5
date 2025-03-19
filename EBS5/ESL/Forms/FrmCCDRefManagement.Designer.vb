<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCCDRefManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCCDRefManagement))
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblCCDRefAccountNo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAccountType = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtAccountNo = New ESL.myTextbox()
        Me.btnCCDRefMgmtExit = New ESL.myButton(Me.components)
        Me.btnLinkCCDRef = New ESL.myButton(Me.components)
        Me.txtCCDRef = New ESL.myTextbox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(18, 37)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 15)
        Me.Label27.TabIndex = 807
        Me.Label27.Text = "Target Account No"
        '
        'lblCCDRefAccountNo
        '
        Me.lblCCDRefAccountNo.AutoSize = True
        Me.lblCCDRefAccountNo.Location = New System.Drawing.Point(129, 37)
        Me.lblCCDRefAccountNo.Name = "lblCCDRefAccountNo"
        Me.lblCCDRefAccountNo.Size = New System.Drawing.Size(105, 15)
        Me.lblCCDRefAccountNo.TabIndex = 808
        Me.lblCCDRefAccountNo.Text = "Target Account No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 889
        Me.Label1.Text = "CCD Ref:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Linen
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboAccountType)
        Me.GroupBox1.Controls.Add(Me.txtAccountNo)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 85)
        Me.GroupBox1.TabIndex = 809
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 887
        Me.Label2.Text = "Account Type:"
        '
        'cboAccountType
        '
        Me.cboAccountType.Enabled = False
        Me.cboAccountType.FormattingEnabled = True
        Me.cboAccountType.Items.AddRange(New Object() {"CIES", "Futures", "Securities"})
        Me.cboAccountType.Location = New System.Drawing.Point(85, 48)
        Me.cboAccountType.Name = "cboAccountType"
        Me.cboAccountType.Size = New System.Drawing.Size(177, 23)
        Me.cboAccountType.TabIndex = 888
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(11, 24)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 15)
        Me.Label31.TabIndex = 881
        Me.Label31.Text = "Account No:"
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(84, 21)
        Me.txtAccountNo.MaxLength = 50
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(177, 21)
        Me.txtAccountNo.TabIndex = 882
        '
        'btnCCDRefMgmtExit
        '
        Me.btnCCDRefMgmtExit.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btnCCDRefMgmtExit.Image = CType(resources.GetObject("btnCCDRefMgmtExit.Image"), System.Drawing.Image)
        Me.btnCCDRefMgmtExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCCDRefMgmtExit.Location = New System.Drawing.Point(279, 205)
        Me.btnCCDRefMgmtExit.Name = "btnCCDRefMgmtExit"
        Me.btnCCDRefMgmtExit.Size = New System.Drawing.Size(50, 55)
        Me.btnCCDRefMgmtExit.TabIndex = 892
        Me.btnCCDRefMgmtExit.Text = "Exit"
        Me.btnCCDRefMgmtExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCCDRefMgmtExit.UseVisualStyleBackColor = True
        '
        'btnLinkCCDRef
        '
        Me.btnLinkCCDRef.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnLinkCCDRef.Location = New System.Drawing.Point(150, 193)
        Me.btnLinkCCDRef.Name = "btnLinkCCDRef"
        Me.btnLinkCCDRef.Size = New System.Drawing.Size(120, 27)
        Me.btnLinkCCDRef.TabIndex = 891
        Me.btnLinkCCDRef.Text = "Link CCD Ref"
        Me.btnLinkCCDRef.UseVisualStyleBackColor = True
        '
        'txtCCDRef
        '
        Me.txtCCDRef.Location = New System.Drawing.Point(93, 158)
        Me.txtCCDRef.MaxLength = 50
        Me.txtCCDRef.Name = "txtCCDRef"
        Me.txtCCDRef.Size = New System.Drawing.Size(177, 21)
        Me.txtCCDRef.TabIndex = 890
        '
        'FrmCCDRefManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(341, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCCDRefMgmtExit)
        Me.Controls.Add(Me.btnLinkCCDRef)
        Me.Controls.Add(Me.txtCCDRef)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCCDRefAccountNo)
        Me.Controls.Add(Me.Label27)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCCDRefManagement"
        Me.Text = "CCD Ref Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblCCDRefAccountNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCCDRef As ESL.myTextbox
    Friend WithEvents btnLinkCCDRef As ESL.myButton
    Friend WithEvents btnCCDRefMgmtExit As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAccountNo As ESL.myTextbox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
