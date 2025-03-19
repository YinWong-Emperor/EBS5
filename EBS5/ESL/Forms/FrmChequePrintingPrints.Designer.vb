<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChequePrintingPrints
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
        Me.components = New System.ComponentModel.Container()
        Me.gbxMain = New System.Windows.Forms.GroupBox()
        Me.gbxPrintReport = New System.Windows.Forms.GroupBox()
        Me.rbtDirectly4PrintReport = New System.Windows.Forms.RadioButton()
        Me.rbtPreview4PrintReport = New System.Windows.Forms.RadioButton()
        Me.gbxRecordRange = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbSequenceNoTo = New System.Windows.Forms.ComboBox()
        Me.cbbSequenceNoFrom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbbClientCodeTo = New System.Windows.Forms.ComboBox()
        Me.cbbClientCodeFrom = New System.Windows.Forms.ComboBox()
        Me.rbtSequenceNo4RecordRange = New System.Windows.Forms.RadioButton()
        Me.rbtClientCode4RecordRange = New System.Windows.Forms.RadioButton()
        Me.rbtAll4RecordRange = New System.Windows.Forms.RadioButton()
        Me.gbxPrintSequence = New System.Windows.Forms.GroupBox()
        Me.rbtClientCode4PrintSequence = New System.Windows.Forms.RadioButton()
        Me.rbtSequenceNo4PrintSequence = New System.Windows.Forms.RadioButton()
        Me.gbxReportType = New System.Windows.Forms.GroupBox()
        Me.rbtCheque4ReportType = New System.Windows.Forms.RadioButton()
        Me.rbtListing4ReportType = New System.Windows.Forms.RadioButton()
        Me.dtpTxnDate = New ESL.myDateTimePicker()
        Me.lblPrintReport = New System.Windows.Forms.Label()
        Me.lblRecordRange = New System.Windows.Forms.Label()
        Me.lblPrintSequence = New System.Windows.Forms.Label()
        Me.lblReportType = New System.Windows.Forms.Label()
        Me.lblTxnDate = New System.Windows.Forms.Label()
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.DlgPrint = New System.Windows.Forms.PrintDialog()
        Me.chk_PrinterSelect = New System.Windows.Forms.CheckBox()
        Me.gbxMain.SuspendLayout()
        Me.gbxPrintReport.SuspendLayout()
        Me.gbxRecordRange.SuspendLayout()
        Me.gbxPrintSequence.SuspendLayout()
        Me.gbxReportType.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(444, 490)
        Me.btnCancel.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(392, 490)
        '
        'gbxMain
        '
        Me.gbxMain.Controls.Add(Me.gbxPrintReport)
        Me.gbxMain.Controls.Add(Me.gbxRecordRange)
        Me.gbxMain.Controls.Add(Me.gbxPrintSequence)
        Me.gbxMain.Controls.Add(Me.gbxReportType)
        Me.gbxMain.Controls.Add(Me.dtpTxnDate)
        Me.gbxMain.Controls.Add(Me.lblPrintReport)
        Me.gbxMain.Controls.Add(Me.lblRecordRange)
        Me.gbxMain.Controls.Add(Me.lblPrintSequence)
        Me.gbxMain.Controls.Add(Me.lblReportType)
        Me.gbxMain.Controls.Add(Me.lblTxnDate)
        Me.gbxMain.Location = New System.Drawing.Point(12, 12)
        Me.gbxMain.Name = "gbxMain"
        Me.gbxMain.Size = New System.Drawing.Size(482, 459)
        Me.gbxMain.TabIndex = 6
        Me.gbxMain.TabStop = False
        '
        'gbxPrintReport
        '
        Me.gbxPrintReport.Controls.Add(Me.chk_PrinterSelect)
        Me.gbxPrintReport.Controls.Add(Me.rbtDirectly4PrintReport)
        Me.gbxPrintReport.Controls.Add(Me.rbtPreview4PrintReport)
        Me.gbxPrintReport.Location = New System.Drawing.Point(116, 357)
        Me.gbxPrintReport.Name = "gbxPrintReport"
        Me.gbxPrintReport.Size = New System.Drawing.Size(346, 81)
        Me.gbxPrintReport.TabIndex = 4
        Me.gbxPrintReport.TabStop = False
        Me.gbxPrintReport.Text = "Print Option"
        '
        'rbtDirectly4PrintReport
        '
        Me.rbtDirectly4PrintReport.AutoSize = True
        Me.rbtDirectly4PrintReport.Location = New System.Drawing.Point(17, 52)
        Me.rbtDirectly4PrintReport.Name = "rbtDirectly4PrintReport"
        Me.rbtDirectly4PrintReport.Size = New System.Drawing.Size(147, 19)
        Me.rbtDirectly4PrintReport.TabIndex = 1
        Me.rbtDirectly4PrintReport.TabStop = True
        Me.rbtDirectly4PrintReport.Text = "Send to Printer directly"
        Me.rbtDirectly4PrintReport.UseVisualStyleBackColor = True
        '
        'rbtPreview4PrintReport
        '
        Me.rbtPreview4PrintReport.AutoSize = True
        Me.rbtPreview4PrintReport.Location = New System.Drawing.Point(17, 24)
        Me.rbtPreview4PrintReport.Name = "rbtPreview4PrintReport"
        Me.rbtPreview4PrintReport.Size = New System.Drawing.Size(150, 19)
        Me.rbtPreview4PrintReport.TabIndex = 0
        Me.rbtPreview4PrintReport.TabStop = True
        Me.rbtPreview4PrintReport.Text = "Print Preview Windows"
        Me.rbtPreview4PrintReport.UseVisualStyleBackColor = True
        '
        'gbxRecordRange
        '
        Me.gbxRecordRange.Controls.Add(Me.Label2)
        Me.gbxRecordRange.Controls.Add(Me.cbbSequenceNoTo)
        Me.gbxRecordRange.Controls.Add(Me.cbbSequenceNoFrom)
        Me.gbxRecordRange.Controls.Add(Me.Label1)
        Me.gbxRecordRange.Controls.Add(Me.cbbClientCodeTo)
        Me.gbxRecordRange.Controls.Add(Me.cbbClientCodeFrom)
        Me.gbxRecordRange.Controls.Add(Me.rbtSequenceNo4RecordRange)
        Me.gbxRecordRange.Controls.Add(Me.rbtClientCode4RecordRange)
        Me.gbxRecordRange.Controls.Add(Me.rbtAll4RecordRange)
        Me.gbxRecordRange.Location = New System.Drawing.Point(116, 237)
        Me.gbxRecordRange.Name = "gbxRecordRange"
        Me.gbxRecordRange.Size = New System.Drawing.Size(346, 109)
        Me.gbxRecordRange.TabIndex = 3
        Me.gbxRecordRange.TabStop = False
        Me.gbxRecordRange.Text = "Print Option"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "To"
        '
        'cbbSequenceNoTo
        '
        Me.cbbSequenceNoTo.FormattingEnabled = True
        Me.cbbSequenceNoTo.Location = New System.Drawing.Point(243, 77)
        Me.cbbSequenceNoTo.Name = "cbbSequenceNoTo"
        Me.cbbSequenceNoTo.Size = New System.Drawing.Size(94, 23)
        Me.cbbSequenceNoTo.TabIndex = 5
        '
        'cbbSequenceNoFrom
        '
        Me.cbbSequenceNoFrom.FormattingEnabled = True
        Me.cbbSequenceNoFrom.Location = New System.Drawing.Point(123, 77)
        Me.cbbSequenceNoFrom.Name = "cbbSequenceNoFrom"
        Me.cbbSequenceNoFrom.Size = New System.Drawing.Size(94, 23)
        Me.cbbSequenceNoFrom.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "To"
        '
        'cbbClientCodeTo
        '
        Me.cbbClientCodeTo.FormattingEnabled = True
        Me.cbbClientCodeTo.Location = New System.Drawing.Point(243, 50)
        Me.cbbClientCodeTo.Name = "cbbClientCodeTo"
        Me.cbbClientCodeTo.Size = New System.Drawing.Size(94, 23)
        Me.cbbClientCodeTo.TabIndex = 3
        '
        'cbbClientCodeFrom
        '
        Me.cbbClientCodeFrom.FormattingEnabled = True
        Me.cbbClientCodeFrom.Location = New System.Drawing.Point(123, 50)
        Me.cbbClientCodeFrom.Name = "cbbClientCodeFrom"
        Me.cbbClientCodeFrom.Size = New System.Drawing.Size(94, 23)
        Me.cbbClientCodeFrom.TabIndex = 3
        '
        'rbtSequenceNo4RecordRange
        '
        Me.rbtSequenceNo4RecordRange.AutoSize = True
        Me.rbtSequenceNo4RecordRange.Location = New System.Drawing.Point(17, 79)
        Me.rbtSequenceNo4RecordRange.Name = "rbtSequenceNo4RecordRange"
        Me.rbtSequenceNo4RecordRange.Size = New System.Drawing.Size(100, 19)
        Me.rbtSequenceNo4RecordRange.TabIndex = 2
        Me.rbtSequenceNo4RecordRange.TabStop = True
        Me.rbtSequenceNo4RecordRange.Text = "Sequence No"
        Me.rbtSequenceNo4RecordRange.UseVisualStyleBackColor = True
        '
        'rbtClientCode4RecordRange
        '
        Me.rbtClientCode4RecordRange.AutoSize = True
        Me.rbtClientCode4RecordRange.Location = New System.Drawing.Point(17, 52)
        Me.rbtClientCode4RecordRange.Name = "rbtClientCode4RecordRange"
        Me.rbtClientCode4RecordRange.Size = New System.Drawing.Size(90, 19)
        Me.rbtClientCode4RecordRange.TabIndex = 1
        Me.rbtClientCode4RecordRange.TabStop = True
        Me.rbtClientCode4RecordRange.Text = "Client Code"
        Me.rbtClientCode4RecordRange.UseVisualStyleBackColor = True
        '
        'rbtAll4RecordRange
        '
        Me.rbtAll4RecordRange.AutoSize = True
        Me.rbtAll4RecordRange.Location = New System.Drawing.Point(17, 24)
        Me.rbtAll4RecordRange.Name = "rbtAll4RecordRange"
        Me.rbtAll4RecordRange.Size = New System.Drawing.Size(38, 19)
        Me.rbtAll4RecordRange.TabIndex = 0
        Me.rbtAll4RecordRange.TabStop = True
        Me.rbtAll4RecordRange.Text = "All"
        Me.rbtAll4RecordRange.UseVisualStyleBackColor = True
        '
        'gbxPrintSequence
        '
        Me.gbxPrintSequence.Controls.Add(Me.rbtClientCode4PrintSequence)
        Me.gbxPrintSequence.Controls.Add(Me.rbtSequenceNo4PrintSequence)
        Me.gbxPrintSequence.Location = New System.Drawing.Point(116, 148)
        Me.gbxPrintSequence.Name = "gbxPrintSequence"
        Me.gbxPrintSequence.Size = New System.Drawing.Size(346, 81)
        Me.gbxPrintSequence.TabIndex = 2
        Me.gbxPrintSequence.TabStop = False
        Me.gbxPrintSequence.Text = "Print Option"
        '
        'rbtClientCode4PrintSequence
        '
        Me.rbtClientCode4PrintSequence.AutoSize = True
        Me.rbtClientCode4PrintSequence.Location = New System.Drawing.Point(17, 52)
        Me.rbtClientCode4PrintSequence.Name = "rbtClientCode4PrintSequence"
        Me.rbtClientCode4PrintSequence.Size = New System.Drawing.Size(90, 19)
        Me.rbtClientCode4PrintSequence.TabIndex = 1
        Me.rbtClientCode4PrintSequence.TabStop = True
        Me.rbtClientCode4PrintSequence.Text = "Client Code"
        Me.rbtClientCode4PrintSequence.UseVisualStyleBackColor = True
        '
        'rbtSequenceNo4PrintSequence
        '
        Me.rbtSequenceNo4PrintSequence.AutoSize = True
        Me.rbtSequenceNo4PrintSequence.Location = New System.Drawing.Point(17, 24)
        Me.rbtSequenceNo4PrintSequence.Name = "rbtSequenceNo4PrintSequence"
        Me.rbtSequenceNo4PrintSequence.Size = New System.Drawing.Size(100, 19)
        Me.rbtSequenceNo4PrintSequence.TabIndex = 0
        Me.rbtSequenceNo4PrintSequence.TabStop = True
        Me.rbtSequenceNo4PrintSequence.Text = "Sequence No"
        Me.rbtSequenceNo4PrintSequence.UseVisualStyleBackColor = True
        '
        'gbxReportType
        '
        Me.gbxReportType.Controls.Add(Me.rbtCheque4ReportType)
        Me.gbxReportType.Controls.Add(Me.rbtListing4ReportType)
        Me.gbxReportType.Location = New System.Drawing.Point(116, 59)
        Me.gbxReportType.Name = "gbxReportType"
        Me.gbxReportType.Size = New System.Drawing.Size(346, 81)
        Me.gbxReportType.TabIndex = 1
        Me.gbxReportType.TabStop = False
        Me.gbxReportType.Text = "Report Type"
        '
        'rbtCheque4ReportType
        '
        Me.rbtCheque4ReportType.AutoSize = True
        Me.rbtCheque4ReportType.Location = New System.Drawing.Point(17, 52)
        Me.rbtCheque4ReportType.Name = "rbtCheque4ReportType"
        Me.rbtCheque4ReportType.Size = New System.Drawing.Size(69, 19)
        Me.rbtCheque4ReportType.TabIndex = 1
        Me.rbtCheque4ReportType.TabStop = True
        Me.rbtCheque4ReportType.Text = "Cheque"
        Me.rbtCheque4ReportType.UseVisualStyleBackColor = True
        '
        'rbtListing4ReportType
        '
        Me.rbtListing4ReportType.AutoSize = True
        Me.rbtListing4ReportType.Location = New System.Drawing.Point(17, 24)
        Me.rbtListing4ReportType.Name = "rbtListing4ReportType"
        Me.rbtListing4ReportType.Size = New System.Drawing.Size(62, 19)
        Me.rbtListing4ReportType.TabIndex = 0
        Me.rbtListing4ReportType.TabStop = True
        Me.rbtListing4ReportType.Text = "Listing"
        Me.rbtListing4ReportType.UseVisualStyleBackColor = True
        '
        'dtpTxnDate
        '
        Me.dtpTxnDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpTxnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTxnDate.Location = New System.Drawing.Point(116, 21)
        Me.dtpTxnDate.Name = "dtpTxnDate"
        Me.dtpTxnDate.Size = New System.Drawing.Size(168, 21)
        Me.dtpTxnDate.TabIndex = 0
        '
        'lblPrintReport
        '
        Me.lblPrintReport.AutoSize = True
        Me.lblPrintReport.Location = New System.Drawing.Point(19, 390)
        Me.lblPrintReport.Name = "lblPrintReport"
        Me.lblPrintReport.Size = New System.Drawing.Size(72, 15)
        Me.lblPrintReport.TabIndex = 0
        Me.lblPrintReport.Text = "Print Report"
        '
        'lblRecordRange
        '
        Me.lblRecordRange.AutoSize = True
        Me.lblRecordRange.Location = New System.Drawing.Point(19, 284)
        Me.lblRecordRange.Name = "lblRecordRange"
        Me.lblRecordRange.Size = New System.Drawing.Size(87, 15)
        Me.lblRecordRange.TabIndex = 0
        Me.lblRecordRange.Text = "Record Range"
        '
        'lblPrintSequence
        '
        Me.lblPrintSequence.AutoSize = True
        Me.lblPrintSequence.Location = New System.Drawing.Point(19, 181)
        Me.lblPrintSequence.Name = "lblPrintSequence"
        Me.lblPrintSequence.Size = New System.Drawing.Size(91, 15)
        Me.lblPrintSequence.TabIndex = 0
        Me.lblPrintSequence.Text = "Print Sequence"
        '
        'lblReportType
        '
        Me.lblReportType.AutoSize = True
        Me.lblReportType.Location = New System.Drawing.Point(19, 92)
        Me.lblReportType.Name = "lblReportType"
        Me.lblReportType.Size = New System.Drawing.Size(72, 15)
        Me.lblReportType.TabIndex = 0
        Me.lblReportType.Text = "Report Type"
        '
        'lblTxnDate
        '
        Me.lblTxnDate.AutoSize = True
        Me.lblTxnDate.Location = New System.Drawing.Point(19, 24)
        Me.lblTxnDate.Name = "lblTxnDate"
        Me.lblTxnDate.Size = New System.Drawing.Size(58, 15)
        Me.lblTxnDate.TabIndex = 0
        Me.lblTxnDate.Text = "Txn. Date"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(392, 490)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'DlgPrint
        '
        Me.DlgPrint.UseEXDialog = True
        '
        'chk_PrinterSelect
        '
        Me.chk_PrinterSelect.AutoSize = True
        Me.chk_PrinterSelect.Location = New System.Drawing.Point(223, 54)
        Me.chk_PrinterSelect.Name = "chk_PrinterSelect"
        Me.chk_PrinterSelect.Size = New System.Drawing.Size(99, 19)
        Me.chk_PrinterSelect.TabIndex = 2
        Me.chk_PrinterSelect.Text = "Select Printer"
        Me.chk_PrinterSelect.UseVisualStyleBackColor = True
        '
        'FrmChequePrintingPrints
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 559)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.gbxMain)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmChequePrintingPrints"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print GL Client Cheque"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.gbxMain, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.gbxMain.ResumeLayout(False)
        Me.gbxMain.PerformLayout()
        Me.gbxPrintReport.ResumeLayout(False)
        Me.gbxPrintReport.PerformLayout()
        Me.gbxRecordRange.ResumeLayout(False)
        Me.gbxRecordRange.PerformLayout()
        Me.gbxPrintSequence.ResumeLayout(False)
        Me.gbxPrintSequence.PerformLayout()
        Me.gbxReportType.ResumeLayout(False)
        Me.gbxReportType.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxMain As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecordRange As System.Windows.Forms.Label
    Friend WithEvents lblReportType As System.Windows.Forms.Label
    Friend WithEvents lblTxnDate As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents dtpTxnDate As ESL.myDateTimePicker
    Friend WithEvents lblPrintSequence As System.Windows.Forms.Label
    Friend WithEvents lblPrintReport As System.Windows.Forms.Label
    Friend WithEvents gbxReportType As System.Windows.Forms.GroupBox
    Friend WithEvents rbtCheque4ReportType As System.Windows.Forms.RadioButton
    Friend WithEvents rbtListing4ReportType As System.Windows.Forms.RadioButton
    Friend WithEvents gbxPrintSequence As System.Windows.Forms.GroupBox
    Friend WithEvents rbtClientCode4PrintSequence As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSequenceNo4PrintSequence As System.Windows.Forms.RadioButton
    Friend WithEvents gbxRecordRange As System.Windows.Forms.GroupBox
    Friend WithEvents rbtSequenceNo4RecordRange As System.Windows.Forms.RadioButton
    Friend WithEvents rbtClientCode4RecordRange As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAll4RecordRange As System.Windows.Forms.RadioButton
    Friend WithEvents gbxPrintReport As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDirectly4PrintReport As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPreview4PrintReport As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbSequenceNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents cbbSequenceNoFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbClientCodeTo As System.Windows.Forms.ComboBox
    Friend WithEvents cbbClientCodeFrom As System.Windows.Forms.ComboBox
    Friend WithEvents DlgPrint As System.Windows.Forms.PrintDialog
    Friend WithEvents chk_PrinterSelect As System.Windows.Forms.CheckBox
End Class
