<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIRS
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
        Me.components = New System.ComponentModel.Container()
        Me.lblGenerateFinancialYear = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbReport = New System.Windows.Forms.GroupBox()
        Me.rbPoolReport = New ESL.myRadioButton(Me.components)
        Me.rbAccountReport = New ESL.myRadioButton(Me.components)
        Me.gbCompany = New System.Windows.Forms.GroupBox()
        Me.rbFutures = New ESL.myRadioButton(Me.components)
        Me.rbSecurities = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKey = New ESL.myTextbox()
        Me.btnSignZipEncrypt = New ESL.myButton(Me.components)
        Me.btnGenerateXML = New ESL.myButton(Me.components)
        Me.gbReport.SuspendLayout()
        Me.gbCompany.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(562, 293)
        Me.btnCancel.TabIndex = 100
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(510, 293)
        Me.btnSave.TabIndex = 99
        '
        'lblGenerateFinancialYear
        '
        Me.lblGenerateFinancialYear.AutoSize = True
        Me.lblGenerateFinancialYear.Location = New System.Drawing.Point(310, 40)
        Me.lblGenerateFinancialYear.Name = "lblGenerateFinancialYear"
        Me.lblGenerateFinancialYear.Size = New System.Drawing.Size(90, 15)
        Me.lblGenerateFinancialYear.TabIndex = 41
        Me.lblGenerateFinancialYear.Text = "generationdate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(211, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Financial Year : "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(251, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(196, 22)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "IRS XML Generation"
        '
        'gbReport
        '
        Me.gbReport.Controls.Add(Me.rbPoolReport)
        Me.gbReport.Controls.Add(Me.rbAccountReport)
        Me.gbReport.Location = New System.Drawing.Point(166, 60)
        Me.gbReport.Name = "gbReport"
        Me.gbReport.Size = New System.Drawing.Size(277, 47)
        Me.gbReport.TabIndex = 50
        Me.gbReport.TabStop = False
        Me.gbReport.Text = "Report"
        '
        'rbPoolReport
        '
        Me.rbPoolReport.AutoSize = True
        Me.rbPoolReport.Location = New System.Drawing.Point(147, 20)
        Me.rbPoolReport.Name = "rbPoolReport"
        Me.rbPoolReport.Size = New System.Drawing.Size(90, 19)
        Me.rbPoolReport.TabIndex = 52
        Me.rbPoolReport.TabStop = True
        Me.rbPoolReport.Text = "Pool Report"
        Me.rbPoolReport.UseVisualStyleBackColor = True
        '
        'rbAccountReport
        '
        Me.rbAccountReport.AutoSize = True
        Me.rbAccountReport.Location = New System.Drawing.Point(23, 21)
        Me.rbAccountReport.Name = "rbAccountReport"
        Me.rbAccountReport.Size = New System.Drawing.Size(108, 19)
        Me.rbAccountReport.TabIndex = 51
        Me.rbAccountReport.TabStop = True
        Me.rbAccountReport.Text = "Account Report"
        Me.rbAccountReport.UseVisualStyleBackColor = True
        '
        'gbCompany
        '
        Me.gbCompany.Controls.Add(Me.rbFutures)
        Me.gbCompany.Controls.Add(Me.rbSecurities)
        Me.gbCompany.Location = New System.Drawing.Point(166, 113)
        Me.gbCompany.Name = "gbCompany"
        Me.gbCompany.Size = New System.Drawing.Size(277, 47)
        Me.gbCompany.TabIndex = 60
        Me.gbCompany.TabStop = False
        Me.gbCompany.Text = "Company"
        '
        'rbFutures
        '
        Me.rbFutures.AutoSize = True
        Me.rbFutures.Location = New System.Drawing.Point(147, 20)
        Me.rbFutures.Name = "rbFutures"
        Me.rbFutures.Size = New System.Drawing.Size(67, 19)
        Me.rbFutures.TabIndex = 62
        Me.rbFutures.TabStop = True
        Me.rbFutures.Text = "Futures"
        Me.rbFutures.UseVisualStyleBackColor = True
        '
        'rbSecurities
        '
        Me.rbSecurities.AutoSize = True
        Me.rbSecurities.Location = New System.Drawing.Point(23, 21)
        Me.rbSecurities.Name = "rbSecurities"
        Me.rbSecurities.Size = New System.Drawing.Size(80, 19)
        Me.rbSecurities.TabIndex = 61
        Me.rbSecurities.TabStop = True
        Me.rbSecurities.Text = "Securities"
        Me.rbSecurities.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 15)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "key"
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(343, 213)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(100, 21)
        Me.txtKey.TabIndex = 82
        Me.txtKey.UseSystemPasswordChar = True
        '
        'btnSignZipEncrypt
        '
        Me.btnSignZipEncrypt.Location = New System.Drawing.Point(171, 211)
        Me.btnSignZipEncrypt.Name = "btnSignZipEncrypt"
        Me.btnSignZipEncrypt.Size = New System.Drawing.Size(126, 23)
        Me.btnSignZipEncrypt.TabIndex = 80
        Me.btnSignZipEncrypt.Text = "SignZipEncrypt"
        Me.btnSignZipEncrypt.UseVisualStyleBackColor = True
        '
        'btnGenerateXML
        '
        Me.btnGenerateXML.Location = New System.Drawing.Point(171, 182)
        Me.btnGenerateXML.Name = "btnGenerateXML"
        Me.btnGenerateXML.Size = New System.Drawing.Size(126, 23)
        Me.btnGenerateXML.TabIndex = 70
        Me.btnGenerateXML.Text = "GenerateXML"
        Me.btnGenerateXML.UseVisualStyleBackColor = True
        '
        'frmIRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(624, 361)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.btnSignZipEncrypt)
        Me.Controls.Add(Me.btnGenerateXML)
        Me.Controls.Add(Me.gbCompany)
        Me.Controls.Add(Me.gbReport)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblGenerateFinancialYear)
        Me.KeyPreview = True
        Me.Name = "frmIRS"
        Me.Text = "IRS XML Generation"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblGenerateFinancialYear, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.gbReport, 0)
        Me.Controls.SetChildIndex(Me.gbCompany, 0)
        Me.Controls.SetChildIndex(Me.btnGenerateXML, 0)
        Me.Controls.SetChildIndex(Me.btnSignZipEncrypt, 0)
        Me.Controls.SetChildIndex(Me.txtKey, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.gbReport.ResumeLayout(False)
        Me.gbReport.PerformLayout()
        Me.gbCompany.ResumeLayout(False)
        Me.gbCompany.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGenerateFinancialYear As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gbReport As System.Windows.Forms.GroupBox
    Friend WithEvents rbPoolReport As ESL.myRadioButton
    Friend WithEvents rbAccountReport As ESL.myRadioButton
    Friend WithEvents gbCompany As System.Windows.Forms.GroupBox
    Friend WithEvents rbFutures As ESL.myRadioButton
    Friend WithEvents rbSecurities As ESL.myRadioButton
    Friend WithEvents btnGenerateXML As ESL.myButton
    Friend WithEvents btnSignZipEncrypt As ESL.myButton
    Friend WithEvents txtKey As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
