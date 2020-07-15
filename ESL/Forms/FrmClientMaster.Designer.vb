<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientMaster
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
        Me.txtClientFrom = New ESL.myTextbox
        Me.txtClientTo = New ESL.myTextbox
        Me.cbClient = New ESL.myCheckBox(Me.components)
        Me.cbAE = New ESL.myCheckBox(Me.components)
        Me.comboAEFrom = New ESL.myComboBox(Me.components)
        Me.comboAETo = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExportS = New ESL.myButton(Me.components)
        Me.btnExportF = New ESL.myButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(428, 192)
        Me.btnCancel.TabIndex = 9
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(372, 192)
        '
        'txtClientFrom
        '
        Me.txtClientFrom.Enabled = False
        Me.txtClientFrom.Location = New System.Drawing.Point(210, 91)
        Me.txtClientFrom.Name = "txtClientFrom"
        Me.txtClientFrom.Size = New System.Drawing.Size(121, 21)
        Me.txtClientFrom.TabIndex = 2
        '
        'txtClientTo
        '
        Me.txtClientTo.Enabled = False
        Me.txtClientTo.Location = New System.Drawing.Point(357, 91)
        Me.txtClientTo.Name = "txtClientTo"
        Me.txtClientTo.Size = New System.Drawing.Size(121, 21)
        Me.txtClientTo.TabIndex = 3
        '
        'cbClient
        '
        Me.cbClient.AutoSize = True
        Me.cbClient.Location = New System.Drawing.Point(130, 93)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(58, 19)
        Me.cbClient.TabIndex = 1
        Me.cbClient.Text = "Client"
        Me.cbClient.UseVisualStyleBackColor = True
        '
        'cbAE
        '
        Me.cbAE.AutoSize = True
        Me.cbAE.Location = New System.Drawing.Point(130, 135)
        Me.cbAE.Name = "cbAE"
        Me.cbAE.Size = New System.Drawing.Size(74, 19)
        Me.cbAE.TabIndex = 4
        Me.cbAE.Text = "AE Code"
        Me.cbAE.UseVisualStyleBackColor = True
        '
        'comboAEFrom
        '
        Me.comboAEFrom.Enabled = False
        Me.comboAEFrom.FormattingEnabled = True
        Me.comboAEFrom.Location = New System.Drawing.Point(210, 133)
        Me.comboAEFrom.Name = "comboAEFrom"
        Me.comboAEFrom.Size = New System.Drawing.Size(121, 23)
        Me.comboAEFrom.TabIndex = 10
        '
        'comboAETo
        '
        Me.comboAETo.Enabled = False
        Me.comboAETo.FormattingEnabled = True
        Me.comboAETo.Location = New System.Drawing.Point(357, 133)
        Me.comboAETo.Name = "comboAETo"
        Me.comboAETo.Size = New System.Drawing.Size(121, 23)
        Me.comboAETo.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Record Range"
        '
        'btnExportS
        '
        Me.btnExportS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportS.Location = New System.Drawing.Point(316, 192)
        Me.btnExportS.Name = "btnExportS"
        Me.btnExportS.Size = New System.Drawing.Size(50, 55)
        Me.btnExportS.TabIndex = 7
        Me.btnExportS.Text = "Export (S)"
        Me.btnExportS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportS.UseVisualStyleBackColor = True
        '
        'btnExportF
        '
        Me.btnExportF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportF.Location = New System.Drawing.Point(372, 192)
        Me.btnExportF.Name = "btnExportF"
        Me.btnExportF.Size = New System.Drawing.Size(50, 55)
        Me.btnExportF.TabIndex = 8
        Me.btnExportF.Text = "Export (F)"
        Me.btnExportF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportF.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(159, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 22)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Export Client Master"
        '
        'FrmClientMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(516, 296)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExportF)
        Me.Controls.Add(Me.btnExportS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboAETo)
        Me.Controls.Add(Me.comboAEFrom)
        Me.Controls.Add(Me.cbAE)
        Me.Controls.Add(Me.cbClient)
        Me.Controls.Add(Me.txtClientTo)
        Me.Controls.Add(Me.txtClientFrom)
        Me.KeyPreview = True
        Me.Name = "FrmClientMaster"
        Me.Text = "Export Client Master"
        Me.Controls.SetChildIndex(Me.txtClientFrom, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.txtClientTo, 0)
        Me.Controls.SetChildIndex(Me.cbClient, 0)
        Me.Controls.SetChildIndex(Me.cbAE, 0)
        Me.Controls.SetChildIndex(Me.comboAEFrom, 0)
        Me.Controls.SetChildIndex(Me.comboAETo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnExportS, 0)
        Me.Controls.SetChildIndex(Me.btnExportF, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtClientFrom As ESL.myTextbox
    Friend WithEvents txtClientTo As ESL.myTextbox
    Friend WithEvents cbClient As ESL.myCheckBox
    Friend WithEvents cbAE As ESL.myCheckBox
    Friend WithEvents comboAEFrom As ESL.myComboBox
    Friend WithEvents comboAETo As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportS As ESL.myButton
    Friend WithEvents btnExportF As ESL.myButton
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
