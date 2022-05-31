<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChequeSorting
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
        Me.gbSorting = New System.Windows.Forms.GroupBox()
        Me.lblSelectedKeys = New System.Windows.Forms.Label()
        Me.lbSelectedKeys = New System.Windows.Forms.ListBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblAvailableKeys = New System.Windows.Forms.Label()
        Me.lbAvailableKeys = New System.Windows.Forms.ListBox()
        Me.gbSorting.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(304, 171)
        '
        'btnSave
        '
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(248, 170)
        Me.btnSave.Visible = True
        '
        'gbSorting
        '
        Me.gbSorting.Controls.Add(Me.lblSelectedKeys)
        Me.gbSorting.Controls.Add(Me.lbSelectedKeys)
        Me.gbSorting.Controls.Add(Me.btnRemove)
        Me.gbSorting.Controls.Add(Me.btnAdd)
        Me.gbSorting.Controls.Add(Me.lblAvailableKeys)
        Me.gbSorting.Controls.Add(Me.lbAvailableKeys)
        Me.gbSorting.Location = New System.Drawing.Point(14, 15)
        Me.gbSorting.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbSorting.Name = "gbSorting"
        Me.gbSorting.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbSorting.Size = New System.Drawing.Size(354, 148)
        Me.gbSorting.TabIndex = 0
        Me.gbSorting.TabStop = False
        '
        'lblSelectedKeys
        '
        Me.lblSelectedKeys.AutoSize = True
        Me.lblSelectedKeys.Location = New System.Drawing.Point(217, 22)
        Me.lblSelectedKeys.Name = "lblSelectedKeys"
        Me.lblSelectedKeys.Size = New System.Drawing.Size(83, 15)
        Me.lblSelectedKeys.TabIndex = 5
        Me.lblSelectedKeys.Text = "Selected keys"
        '
        'lbSelectedKeys
        '
        Me.lbSelectedKeys.FormattingEnabled = True
        Me.lbSelectedKeys.ItemHeight = 15
        Me.lbSelectedKeys.Location = New System.Drawing.Point(220, 40)
        Me.lbSelectedKeys.Name = "lbSelectedKeys"
        Me.lbSelectedKeys.Size = New System.Drawing.Size(120, 94)
        Me.lbSelectedKeys.TabIndex = 4
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Location = New System.Drawing.Point(133, 91)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(81, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "<= Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(133, 62)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(81, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add =>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblAvailableKeys
        '
        Me.lblAvailableKeys.AutoSize = True
        Me.lblAvailableKeys.Location = New System.Drawing.Point(7, 22)
        Me.lblAvailableKeys.Name = "lblAvailableKeys"
        Me.lblAvailableKeys.Size = New System.Drawing.Size(84, 15)
        Me.lblAvailableKeys.TabIndex = 1
        Me.lblAvailableKeys.Text = "Available keys"
        '
        'lbAvailableKeys
        '
        Me.lbAvailableKeys.FormattingEnabled = True
        Me.lbAvailableKeys.ItemHeight = 15
        Me.lbAvailableKeys.Items.AddRange(New Object() {"Amount", "Client Code", "Sequence"})
        Me.lbAvailableKeys.Location = New System.Drawing.Point(6, 40)
        Me.lbAvailableKeys.Name = "lbAvailableKeys"
        Me.lbAvailableKeys.Size = New System.Drawing.Size(120, 94)
        Me.lbAvailableKeys.TabIndex = 0
        '
        'FrmChequeSorting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(372, 234)
        Me.Controls.Add(Me.gbSorting)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmChequeSorting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SORTING KEY SELECTION"
        Me.Controls.SetChildIndex(Me.gbSorting, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.gbSorting.ResumeLayout(False)
        Me.gbSorting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSorting As System.Windows.Forms.GroupBox
    Friend WithEvents lbAvailableKeys As System.Windows.Forms.ListBox
    Friend WithEvents lblAvailableKeys As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lbSelectedKeys As System.Windows.Forms.ListBox
    Friend WithEvents lblSelectedKeys As System.Windows.Forms.Label
End Class
