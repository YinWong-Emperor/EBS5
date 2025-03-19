Public Class frmCommAE

    Dim cls As New ClsCommAE

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not cls.FncGetLogs(Me.CBOMonth.Text.Trim) Then
            MessageBox.Show("Some commission records have not been approved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim ldtDetailF As DataTable
        Dim ldtDetailS As DataTable
        Dim ldtComm As DataTable
        Dim ldtMan As DataTable
        Me.ListBox1.Items.Clear()
        If GSubShowYNConfirm(GFncGetSysMsg(61) & " (" & Me.CBOMonth.Text & ") ") = Windows.Forms.DialogResult.Yes Then
            If GFncCheckCommStatus() Then
                Return
            End If
            Me.ListBox1.ForeColor = Color.Red
            Me.ListBox1.Items.Add("Step 1) Calcuate the Commission of securities ")
            Me.ListBox1.Items.Add("")
            Application.DoEvents()
            ldtDetailS = cls.lFncCalTotalComm(Me.CBOMonth.Text).Tables(0)
            Me.ListBox1.Items.Add("Step 2) Calcuate the Commission of Futures & Options ")
            Me.ListBox1.Items.Add("")
            Application.DoEvents()
            ldtDetailF = cls.lfncParpareTODTF(Me.CBOMonth.Text)
            ldtComm = cls.lfncUpdComm(Me.CBOMonth.Text, ldtDetailS, ldtDetailF)
            Me.ListBox1.Items.Add("Step 3) Calcuate the Incentive & Bonus ")
            Me.ListBox1.Items.Add("")
            Application.DoEvents()
            ldtComm = cls.lfncCalOther(Me.CBOMonth.Text, ldtComm)
            Me.ListBox1.Items.Add("Step 4) Calcuate the Manager Override ")
            Me.ListBox1.Items.Add("")
            Application.DoEvents()
            ldtMan = cls.lFncCalCommManager(ldtComm, Me.CBOMonth.Text)
            ldtComm = cls.lfncUpdCommM(Me.CBOMonth.Text, ldtComm, ldtMan)
            cls.lfncUpdateTable(Me.CBOMonth.Text, ldtComm)
            Me.ListBox1.Items.Add("AE Commission generation completed ! ")
        End If
        'me.dgdData.DataSource = ldtComm
        'Me.dgdData.DataSource = ldtMan
    End Sub

    Private Sub frmCommAE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        'Dim ldtTxMonth As DataTable = cls.lFncGetTxMonth()
        'Dim lintCnt As Integer = 0
        'If ldtTxMonth.Rows.Count > 0 Then
        '    For Each ldrTxMonth As DataRow In ldtTxMonth.Rows
        '        Me.CBOMonth.Items.Add(ldrTxMonth("txmonth"))
        '        lintCnt += 1
        '        If lintCnt > 12 Then
        '            Exit For
        '        End If
        '    Next
        '    Me.CBOMonth.Text = ldtTxMonth.Rows(0).Item("txmonth")
        'End If
        Dim ldtTxmonth As String = GfncGetMonth()
        Me.CBOMonth.Items.Add(ldtTxmonth)
        Me.CBOMonth.Text = ldtTxmonth
        Me.txtLastGenerate.Text = cls.lFncGetLastGenerateDate(ldtTxmonth)
        Me.txtLastImport.Text = cls.lFncGetLastImportDate(ldtTxmonth)
        Me.btnSave.Visible = True
    End Sub

End Class
