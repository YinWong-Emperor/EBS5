<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptClientTurnover
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
        Me.btnPrint = New System.Windows.Forms.Button
        Me.grpSearchOptions = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAvgTurnover = New ESL.myNumericBox
        Me.cboAECodeFrm = New System.Windows.Forms.ComboBox
        Me.cboExchange = New System.Windows.Forms.ComboBox
        Me.cboAECodeTo = New System.Windows.Forms.ComboBox
        Me.cboClientFrm = New System.Windows.Forms.ComboBox
        Me.cboClientTo = New System.Windows.Forms.ComboBox
        Me.cbExchange = New System.Windows.Forms.CheckBox
        Me.cbAvgTurnover = New System.Windows.Forms.CheckBox
        Me.cbAECode = New System.Windows.Forms.CheckBox
        Me.cbClient = New System.Windows.Forms.CheckBox
        Me.grpPrintOptions = New System.Windows.Forms.GroupBox
        Me.rbPrint = New System.Windows.Forms.RadioButton
        Me.rbPreview = New System.Windows.Forms.RadioButton
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.dtpTrade = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSortClientNo = New System.Windows.Forms.RadioButton
        Me.rbSortAvgTurnover = New System.Windows.Forms.RadioButton
        Me.lblSorting = New System.Windows.Forms.Label
        Me.grpSearchOptions.SuspendLayout()
        Me.grpPrintOptions.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(330, 359)
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(12, 360)
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(274, 359)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'grpSearchOptions
        '
        Me.grpSearchOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSearchOptions.Controls.Add(Me.Label3)
        Me.grpSearchOptions.Controls.Add(Me.Label2)
        Me.grpSearchOptions.Controls.Add(Me.Label1)
        Me.grpSearchOptions.Controls.Add(Me.txtAvgTurnover)
        Me.grpSearchOptions.Controls.Add(Me.cboAECodeFrm)
        Me.grpSearchOptions.Controls.Add(Me.cboExchange)
        Me.grpSearchOptions.Controls.Add(Me.cboAECodeTo)
        Me.grpSearchOptions.Controls.Add(Me.cboClientFrm)
        Me.grpSearchOptions.Controls.Add(Me.cboClientTo)
        Me.grpSearchOptions.Controls.Add(Me.cbExchange)
        Me.grpSearchOptions.Controls.Add(Me.cbAvgTurnover)
        Me.grpSearchOptions.Controls.Add(Me.cbAECode)
        Me.grpSearchOptions.Controls.Add(Me.cbClient)
        Me.grpSearchOptions.Location = New System.Drawing.Point(12, 43)
        Me.grpSearchOptions.Name = "grpSearchOptions"
        Me.grpSearchOptions.Size = New System.Drawing.Size(364, 154)
        Me.grpSearchOptions.TabIndex = 7
        Me.grpSearchOptions.TabStop = False
        Me.grpSearchOptions.Text = "Search Criteria"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(199, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Lots"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "to"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "to"
        '
        'txtAvgTurnover
        '
        Me.txtAvgTurnover.Location = New System.Drawing.Point(153, 87)
        Me.txtAvgTurnover.Name = "txtAvgTurnover"
        Me.txtAvgTurnover.Size = New System.Drawing.Size(40, 21)
        Me.txtAvgTurnover.TabIndex = 9
        Me.txtAvgTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAECodeFrm
        '
        Me.cboAECodeFrm.FormattingEnabled = True
        Me.cboAECodeFrm.Location = New System.Drawing.Point(101, 58)
        Me.cboAECodeFrm.Name = "cboAECodeFrm"
        Me.cboAECodeFrm.Size = New System.Drawing.Size(113, 23)
        Me.cboAECodeFrm.TabIndex = 8
        '
        'cboExchange
        '
        Me.cboExchange.FormattingEnabled = True
        Me.cboExchange.Location = New System.Drawing.Point(101, 114)
        Me.cboExchange.Name = "cboExchange"
        Me.cboExchange.Size = New System.Drawing.Size(121, 23)
        Me.cboExchange.TabIndex = 7
        '
        'cboAECodeTo
        '
        Me.cboAECodeTo.FormattingEnabled = True
        Me.cboAECodeTo.Location = New System.Drawing.Point(245, 58)
        Me.cboAECodeTo.Name = "cboAECodeTo"
        Me.cboAECodeTo.Size = New System.Drawing.Size(113, 23)
        Me.cboAECodeTo.TabIndex = 6
        '
        'cboClientFrm
        '
        Me.cboClientFrm.FormattingEnabled = True
        Me.cboClientFrm.Location = New System.Drawing.Point(101, 29)
        Me.cboClientFrm.Name = "cboClientFrm"
        Me.cboClientFrm.Size = New System.Drawing.Size(113, 23)
        Me.cboClientFrm.TabIndex = 5
        '
        'cboClientTo
        '
        Me.cboClientTo.FormattingEnabled = True
        Me.cboClientTo.Location = New System.Drawing.Point(245, 29)
        Me.cboClientTo.Name = "cboClientTo"
        Me.cboClientTo.Size = New System.Drawing.Size(113, 23)
        Me.cboClientTo.TabIndex = 4
        '
        'cbExchange
        '
        Me.cbExchange.AutoSize = True
        Me.cbExchange.Location = New System.Drawing.Point(6, 116)
        Me.cbExchange.Name = "cbExchange"
        Me.cbExchange.Size = New System.Drawing.Size(89, 19)
        Me.cbExchange.TabIndex = 3
        Me.cbExchange.Text = "Exchange : "
        Me.cbExchange.UseVisualStyleBackColor = True
        '
        'cbAvgTurnover
        '
        Me.cbAvgTurnover.AutoSize = True
        Me.cbAvgTurnover.Location = New System.Drawing.Point(6, 89)
        Me.cbAvgTurnover.Name = "cbAvgTurnover"
        Me.cbAvgTurnover.Size = New System.Drawing.Size(141, 19)
        Me.cbAvgTurnover.TabIndex = 2
        Me.cbAvgTurnover.Text = "Average Turnover >= "
        Me.cbAvgTurnover.UseVisualStyleBackColor = True
        '
        'cbAECode
        '
        Me.cbAECode.AutoSize = True
        Me.cbAECode.Location = New System.Drawing.Point(6, 60)
        Me.cbAECode.Name = "cbAECode"
        Me.cbAECode.Size = New System.Drawing.Size(80, 19)
        Me.cbAECode.TabIndex = 1
        Me.cbAECode.Text = "AE Code: "
        Me.cbAECode.UseVisualStyleBackColor = True
        '
        'cbClient
        '
        Me.cbClient.AutoSize = True
        Me.cbClient.Location = New System.Drawing.Point(6, 31)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(67, 19)
        Me.cbClient.TabIndex = 0
        Me.cbClient.Text = "Client : "
        Me.cbClient.UseVisualStyleBackColor = True
        '
        'grpPrintOptions
        '
        Me.grpPrintOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPrintOptions.Controls.Add(Me.rbPrint)
        Me.grpPrintOptions.Controls.Add(Me.rbPreview)
        Me.grpPrintOptions.Location = New System.Drawing.Point(12, 252)
        Me.grpPrintOptions.Name = "grpPrintOptions"
        Me.grpPrintOptions.Size = New System.Drawing.Size(364, 60)
        Me.grpPrintOptions.TabIndex = 8
        Me.grpPrintOptions.TabStop = False
        Me.grpPrintOptions.Text = "Print Options"
        '
        'rbPrint
        '
        Me.rbPrint.AutoSize = True
        Me.rbPrint.Location = New System.Drawing.Point(198, 26)
        Me.rbPrint.Name = "rbPrint"
        Me.rbPrint.Size = New System.Drawing.Size(50, 19)
        Me.rbPrint.TabIndex = 1
        Me.rbPrint.TabStop = True
        Me.rbPrint.Text = "Print"
        Me.rbPrint.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Location = New System.Drawing.Point(97, 26)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(68, 19)
        Me.rbPreview.TabIndex = 0
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'pbarPrint
        '
        Me.pbarPrint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbarPrint.Location = New System.Drawing.Point(12, 337)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(364, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 59
        '
        'lblProcess
        '
        Me.lblProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(12, 315)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 58
        Me.lblProcess.Text = "Processing"
        '
        'dtpTrade
        '
        Me.dtpTrade.CustomFormat = "yyyy/MM/dd"
        Me.dtpTrade.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTrade.Location = New System.Drawing.Point(113, 12)
        Me.dtpTrade.Name = "dtpTrade"
        Me.dtpTrade.Size = New System.Drawing.Size(112, 21)
        Me.dtpTrade.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Trade Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblSorting)
        Me.GroupBox1.Controls.Add(Me.rbSortClientNo)
        Me.GroupBox1.Controls.Add(Me.rbSortAvgTurnover)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 40)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sorting"
        '
        'rbSortClientNo
        '
        Me.rbSortClientNo.AutoSize = True
        Me.rbSortClientNo.Location = New System.Drawing.Point(227, 15)
        Me.rbSortClientNo.Name = "rbSortClientNo"
        Me.rbSortClientNo.Size = New System.Drawing.Size(76, 19)
        Me.rbSortClientNo.TabIndex = 1
        Me.rbSortClientNo.TabStop = True
        Me.rbSortClientNo.Text = "Client No"
        Me.rbSortClientNo.UseVisualStyleBackColor = True
        '
        'rbSortAvgTurnover
        '
        Me.rbSortAvgTurnover.AutoSize = True
        Me.rbSortAvgTurnover.Location = New System.Drawing.Point(101, 15)
        Me.rbSortAvgTurnover.Name = "rbSortAvgTurnover"
        Me.rbSortAvgTurnover.Size = New System.Drawing.Size(120, 19)
        Me.rbSortAvgTurnover.TabIndex = 0
        Me.rbSortAvgTurnover.TabStop = True
        Me.rbSortAvgTurnover.Text = "Average Turnover"
        Me.rbSortAvgTurnover.UseVisualStyleBackColor = True
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(51, 17)
        Me.lblSorting.Name = "lblSorting"
        Me.lblSorting.Size = New System.Drawing.Size(44, 15)
        Me.lblSorting.TabIndex = 62
        Me.lblSorting.Text = "Sort by"
        '
        'FrmRptClientTurnover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(388, 427)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpTrade)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpSearchOptions)
        Me.Controls.Add(Me.grpPrintOptions)
        Me.KeyPreview = True
        Me.Name = "FrmRptClientTurnover"
        Me.Text = "Client Account Turnover Statisitcs"
        Me.Controls.SetChildIndex(Me.grpPrintOptions, 0)
        Me.Controls.SetChildIndex(Me.grpSearchOptions, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.dtpTrade, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.grpSearchOptions.ResumeLayout(False)
        Me.grpSearchOptions.PerformLayout()
        Me.grpPrintOptions.ResumeLayout(False)
        Me.grpPrintOptions.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents grpSearchOptions As System.Windows.Forms.GroupBox
    Friend WithEvents grpPrintOptions As System.Windows.Forms.GroupBox
    Friend WithEvents cbExchange As System.Windows.Forms.CheckBox
    Friend WithEvents cbAvgTurnover As System.Windows.Forms.CheckBox
    Friend WithEvents cbAECode As System.Windows.Forms.CheckBox
    Friend WithEvents cbClient As System.Windows.Forms.CheckBox
    Friend WithEvents txtAvgTurnover As ESL.myNumericBox
    Friend WithEvents cboAECodeFrm As System.Windows.Forms.ComboBox
    Friend WithEvents cboExchange As System.Windows.Forms.ComboBox
    Friend WithEvents cboAECodeTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboClientFrm As System.Windows.Forms.ComboBox
    Friend WithEvents cboClientTo As System.Windows.Forms.ComboBox
    Friend WithEvents rbPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrint As System.Windows.Forms.RadioButton
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTrade As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSorting As System.Windows.Forms.Label
    Friend WithEvents rbSortClientNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbSortAvgTurnover As System.Windows.Forms.RadioButton

End Class
