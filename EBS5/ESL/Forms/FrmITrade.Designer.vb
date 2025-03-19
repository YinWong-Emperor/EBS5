<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmITrade
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
        Me.txtAccno = New ESL.myNumericBox
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.lbAccno = New ESL.myListBox(Me.components)
        Me.btnUp = New ESL.myButton(Me.components)
        Me.btnDown = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblLastTradeDate = New System.Windows.Forms.Label
        Me.dpLastFrom = New ESL.myDateTimePicker
        Me.dpLastTo = New ESL.myDateTimePicker
        Me.dpThisFrom = New ESL.myDateTimePicker
        Me.dpThisTo = New ESL.myDateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnExportTurnover = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnExportClient = New ESL.myButton(Me.components)
        Me.btnExportAll = New ESL.myButton(Me.components)
        Me.btnEquityAll = New ESL.myButton(Me.components)
        Me.btnEquity = New ESL.myButton(Me.components)
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(361, 333)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(311, 333)
        Me.btnSave.Visible = True
        '
        'txtAccno
        '
        Me.txtAccno.Enabled = False
        Me.txtAccno.Location = New System.Drawing.Point(57, 86)
        Me.txtAccno.Name = "txtAccno"
        Me.txtAccno.Size = New System.Drawing.Size(120, 21)
        Me.txtAccno.TabIndex = 6
        Me.txtAccno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(57, 113)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add Client"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lbAccno
        '
        Me.lbAccno.FormattingEnabled = True
        Me.lbAccno.ItemHeight = 15
        Me.lbAccno.Location = New System.Drawing.Point(57, 142)
        Me.lbAccno.Name = "lbAccno"
        Me.lbAccno.Size = New System.Drawing.Size(120, 184)
        Me.lbAccno.TabIndex = 9
        '
        'btnUp
        '
        Me.btnUp.Enabled = False
        Me.btnUp.Location = New System.Drawing.Point(178, 142)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(24, 91)
        Me.btnUp.TabIndex = 10
        Me.btnUp.Text = "UP"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Enabled = False
        Me.btnDown.Location = New System.Drawing.Point(178, 235)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(24, 91)
        Me.btnDown.TabIndex = 11
        Me.btnDown.Text = "DN"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(244, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Last Month Period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "This Month Period"
        '
        'lblLastTradeDate
        '
        Me.lblLastTradeDate.AutoSize = True
        Me.lblLastTradeDate.Location = New System.Drawing.Point(237, 296)
        Me.lblLastTradeDate.Name = "lblLastTradeDate"
        Me.lblLastTradeDate.Size = New System.Drawing.Size(0, 15)
        Me.lblLastTradeDate.TabIndex = 14
        '
        'dpLastFrom
        '
        Me.dpLastFrom.CustomFormat = "dd MMM yyyy"
        Me.dpLastFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpLastFrom.Location = New System.Drawing.Point(240, 104)
        Me.dpLastFrom.Name = "dpLastFrom"
        Me.dpLastFrom.Size = New System.Drawing.Size(115, 21)
        Me.dpLastFrom.TabIndex = 15
        '
        'dpLastTo
        '
        Me.dpLastTo.CustomFormat = "dd MMM yyyy"
        Me.dpLastTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpLastTo.Location = New System.Drawing.Point(240, 146)
        Me.dpLastTo.Name = "dpLastTo"
        Me.dpLastTo.Size = New System.Drawing.Size(115, 21)
        Me.dpLastTo.TabIndex = 16
        '
        'dpThisFrom
        '
        Me.dpThisFrom.CustomFormat = "dd MMM yyyy"
        Me.dpThisFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpThisFrom.Location = New System.Drawing.Point(240, 209)
        Me.dpThisFrom.Name = "dpThisFrom"
        Me.dpThisFrom.Size = New System.Drawing.Size(115, 21)
        Me.dpThisFrom.TabIndex = 17
        '
        'dpThisTo
        '
        Me.dpThisTo.CustomFormat = "dd MMM yyyy"
        Me.dpThisTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpThisTo.Location = New System.Drawing.Point(240, 251)
        Me.dpThisTo.Name = "dpThisTo"
        Me.dpThisTo.Size = New System.Drawing.Size(116, 21)
        Me.dpThisTo.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(283, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 15)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "To"
        '
        'btnExportTurnover
        '
        Me.btnExportTurnover.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportTurnover.Location = New System.Drawing.Point(60, 333)
        Me.btnExportTurnover.Name = "btnExportTurnover"
        Me.btnExportTurnover.Size = New System.Drawing.Size(50, 55)
        Me.btnExportTurnover.TabIndex = 21
        Me.btnExportTurnover.Text = "Export T/O"
        Me.btnExportTurnover.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportTurnover.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(272, 22)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "I-Trade Turnover and Equity"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(261, 333)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 24
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnExportClient
        '
        Me.btnExportClient.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportClient.Location = New System.Drawing.Point(10, 333)
        Me.btnExportClient.Name = "btnExportClient"
        Me.btnExportClient.Size = New System.Drawing.Size(50, 55)
        Me.btnExportClient.TabIndex = 25
        Me.btnExportClient.Text = "Export Client"
        Me.btnExportClient.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportClient.UseVisualStyleBackColor = True
        '
        'btnExportAll
        '
        Me.btnExportAll.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportAll.Location = New System.Drawing.Point(110, 333)
        Me.btnExportAll.Name = "btnExportAll"
        Me.btnExportAll.Size = New System.Drawing.Size(50, 55)
        Me.btnExportAll.TabIndex = 26
        Me.btnExportAll.Text = "Export T/O All"
        Me.btnExportAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportAll.UseVisualStyleBackColor = True
        '
        'btnEquityAll
        '
        Me.btnEquityAll.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquityAll.Location = New System.Drawing.Point(210, 333)
        Me.btnEquityAll.Name = "btnEquityAll"
        Me.btnEquityAll.Size = New System.Drawing.Size(50, 55)
        Me.btnEquityAll.TabIndex = 28
        Me.btnEquityAll.Text = "Export Equity All"
        Me.btnEquityAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEquityAll.UseVisualStyleBackColor = True
        '
        'btnEquity
        '
        Me.btnEquity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquity.Location = New System.Drawing.Point(160, 333)
        Me.btnEquity.Name = "btnEquity"
        Me.btnEquity.Size = New System.Drawing.Size(50, 55)
        Me.btnEquity.TabIndex = 27
        Me.btnEquity.Text = "Export Equity"
        Me.btnEquity.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEquity.UseVisualStyleBackColor = True
        '
        'FrmITrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(414, 401)
        Me.Controls.Add(Me.btnEquityAll)
        Me.Controls.Add(Me.btnEquity)
        Me.Controls.Add(Me.btnExportAll)
        Me.Controls.Add(Me.btnExportClient)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExportTurnover)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dpThisTo)
        Me.Controls.Add(Me.dpThisFrom)
        Me.Controls.Add(Me.dpLastTo)
        Me.Controls.Add(Me.dpLastFrom)
        Me.Controls.Add(Me.lblLastTradeDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtAccno)
        Me.Controls.Add(Me.lbAccno)
        Me.KeyPreview = True
        Me.Name = "FrmITrade"
        Me.Text = "Internet Trade Turnover"
        Me.Controls.SetChildIndex(Me.lbAccno, 0)
        Me.Controls.SetChildIndex(Me.txtAccno, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnUp, 0)
        Me.Controls.SetChildIndex(Me.btnDown, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblLastTradeDate, 0)
        Me.Controls.SetChildIndex(Me.dpLastFrom, 0)
        Me.Controls.SetChildIndex(Me.dpLastTo, 0)
        Me.Controls.SetChildIndex(Me.dpThisFrom, 0)
        Me.Controls.SetChildIndex(Me.dpThisTo, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnExportTurnover, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnExportClient, 0)
        Me.Controls.SetChildIndex(Me.btnExportAll, 0)
        Me.Controls.SetChildIndex(Me.btnEquity, 0)
        Me.Controls.SetChildIndex(Me.btnEquityAll, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAccno As ESL.myNumericBox
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents lbAccno As ESL.myListBox
    Friend WithEvents btnUp As ESL.myButton
    Friend WithEvents btnDown As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLastTradeDate As System.Windows.Forms.Label
    Friend WithEvents dpLastFrom As ESL.myDateTimePicker
    Friend WithEvents dpLastTo As ESL.myDateTimePicker
    Friend WithEvents dpThisFrom As ESL.myDateTimePicker
    Friend WithEvents dpThisTo As ESL.myDateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnExportTurnover As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnExportClient As ESL.myButton
    Friend WithEvents btnExportAll As ESL.myButton
    Friend WithEvents btnEquityAll As ESL.myButton
    Friend WithEvents btnEquity As ESL.myButton

End Class
