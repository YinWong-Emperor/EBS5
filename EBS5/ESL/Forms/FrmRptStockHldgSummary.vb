Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRptStockHldgSummary

    Dim cls As New ClsRptStocklHldgSummary
    Dim frm As New FrmRptDisplay
    Dim log_type As DataTable

    Private Sub FrmRptStockHldgSummary_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.rbPreview.Checked = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim lstrPrinterName As String = ""
        Dim lstrPath As String = ""
        Dim lshrCopies As Short = 1
        Dim clientID() As String
        Dim rpt As ReportClass = Nothing
        If MyListBox2.Items.Count > 0 Then
            If Me.rbPrinter.Checked = True Then
                If printDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    lstrPrinterName = printDlg.PrinterSettings.PrinterName
                    lshrCopies = printDlg.PrinterSettings.Copies
                Else
                    Exit Sub
                End If
            End If

            lsubEnableProcess(True)
            lsubEnableForm(False)
            Application.DoEvents()


            ReDim clientID(0 To MyListBox2.Items.Count - 1)
            Dim i As Integer
            For i = 0 To MyListBox2.Items.Count - 1
                clientID(i) = MyListBox2.Items.Item(i)
            Next
            ' Dim dr() As DataRow = log_type.Select("misc_desc = '" & Me.cboLogType.Text & "' ")
            rpt = cls.Executed_Rpt(clientID)
            '("", Me.MyDateTimePicker1.Value, Me.MyDateTimePicker2.Value, dr(0))

            If Me.rbPreview.Checked = True Then
                lsubEnableProcess(False)
                frm.GSubDisplayRpt(rpt)
            ElseIf Me.rbPrinter.Checked = True Then
                If GFncPrintRpt(rpt, lstrPrinterName, lshrCopies) Then
                    lsubEnableProcess(False)
                    GFncGetSysMsg(104)
                End If
            End If
        Else
            GSubShowInfo("Selected Client List is Empty!")
        End If

        lsubEnableProcess(False)
        lsubEnableForm(True)

    End Sub

    Private Sub lsubEnableProcess(ByVal bEnable As Boolean)
        lblProcess.Visible = bEnable
        pbarProcess.Visible = bEnable
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.rbPreview.Enabled = bEnable
        Me.rbPrinter.Enabled = bEnable
        Me.btnPrint.Visible = bEnable
        Me.btnCancel.Visible = bEnable
    End Sub

    Private Sub FrmRptStockHldgSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyButton1.Visible = False
        MyButton2.Visible = False
        MyButton3.Visible = False
        MyButton4.Visible = False
        MyListBox1.Visible = False
        Button_load.Visible = False
        Dim ldtsTemp As DataSet = cls.Load_Saved_List()
        Dim i As Integer
        For i = 0 To (ldtsTemp.Tables(0).Rows.Count - 1)
            MyListBox2.Items.Add(ldtsTemp.Tables(0).Rows(i).Item(0))
        Next
        Disable_button()
        lsubEnableProcess(False)
        lsubEnableForm(True)
    End Sub

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton1.Click
        Dim index As Integer = MyListBox1.SelectedIndex
        MyListBox2.Items.Add(MyListBox1.SelectedItem)
        MyListBox1.Items.Remove(MyListBox1.SelectedItem)
        If MyListBox1.Items.Count > index Then
            MyListBox1.SelectedItem = MyListBox1.Items(index)
        ElseIf MyListBox1.Items.Count = index And Not index = 0 Then
            MyListBox1.SelectedItem = MyListBox1.Items(index - 1)
        End If
        Disable_button()
    End Sub

    Private Sub MyButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton2.Click
        Dim int As Integer
        Dim index As Integer = MyListBox1.Items.Count - 1
        For int = 0 To index
            MyListBox2.Items.Add(MyListBox1.Items.Item(0))
            MyListBox1.Items.RemoveAt(0)
        Next
        Disable_button()
    End Sub

    Private Sub MyButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton4.Click
        Dim int As Integer
        Dim index As Integer = MyListBox2.Items.Count - 1
        For int = 0 To index
            MyListBox1.Items.Add(MyListBox2.Items.Item(0))
            MyListBox2.Items.RemoveAt(0)
        Next
        Disable_button()
    End Sub

    Private Sub MyButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton3.Click
        Dim index As Integer = MyListBox2.SelectedIndex
        MyListBox1.Items.Add(MyListBox2.SelectedItem)
        MyListBox2.Items.Remove(MyListBox2.SelectedItem)
        If MyListBox2.Items.Count > index Then
            MyListBox2.SelectedItem = MyListBox2.Items(index)
        ElseIf MyListBox2.Items.Count = index And Not index = 0 Then
            MyListBox2.SelectedItem = MyListBox2.Items(index - 1)
        End If
        Disable_button()
    End Sub
    Private Sub Disable_button()
        If MyListBox2.Items.Count <= 0 Then
            Button_delete.Enabled = False
            Button_delete_all.Enabled = False
        ElseIf Not MyListBox2.SelectedIndex = -1 Then
            Button_delete.Enabled = True
            Button_delete_all.Enabled = True
        Else
            Button_delete.Enabled = False
            Button_delete_all.Enabled = True
        End If
    End Sub

    Private Sub Disable_list_button()
        If MyListBox1.Items.Count <= 0 Then
            MyButton1.Enabled = False
            MyButton2.Enabled = False
        ElseIf Not MyListBox1.SelectedIndex = -1 Then
            MyButton1.Enabled = True
            MyButton2.Enabled = True
        Else
            MyButton1.Enabled = False
            MyButton2.Enabled = True
        End If
        If MyListBox2.Items.Count <= 0 Then
            MyButton3.Enabled = False
            MyButton4.Enabled = False
            Button_delete.Enabled = False
            Button_delete_all.Enabled = False
        ElseIf Not MyListBox2.SelectedIndex = -1 Then
            MyButton3.Enabled = True
            MyButton4.Enabled = True
            Button_delete.Enabled = True
            Button_delete_all.Enabled = True
        Else
            MyButton3.Enabled = False
            MyButton4.Enabled = True
            Button_delete.Enabled = False
            Button_delete_all.Enabled = True
        End If
    End Sub

    Private Sub MyListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyListBox1.SelectedIndexChanged
        Disable_button()
    End Sub

    Private Sub MyListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyListBox2.SelectedIndexChanged
        Disable_button()
    End Sub

    Private Sub Button_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_add.Click
        If cls.validate(MyTextbox1.Text.Trim) Then
            If Not MyListBox2.Items.Contains(MyTextbox1.Text.Trim) Then
                MyListBox2.Items.Add(MyTextbox1.Text.Trim)
                Disable_button()
            Else
                GSubShowInfo("Duplicate Client ID!")
            End If
        Else
            GSubShowInfo("Invalid Client ID!")
        End If
    End Sub

    Private Sub Button_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_load.Click
        Dim ldtsTemp As DataSet = cls.Load_Client_List()
        Dim i As Integer
        For i = 0 To (ldtsTemp.Tables(0).Rows.Count - 1)
            MyListBox1.Items.Add(ldtsTemp.Tables(0).Rows(i).Item(0))
        Next
        Disable_button()
    End Sub

    Private Sub Button_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_delete.Click
        Dim index As Integer = MyListBox2.SelectedIndex
        MyListBox2.Items.Remove(MyListBox2.SelectedItem)
        If MyListBox2.Items.Count > index Then
            MyListBox2.SelectedItem = MyListBox2.Items(index)
        ElseIf MyListBox2.Items.Count = index And Not index = 0 Then
            MyListBox2.SelectedItem = MyListBox2.Items(index - 1)
        End If
        Disable_button()
    End Sub

    Private Sub Button_delete_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_delete_all.Click
        Dim int As Integer
        Dim index As Integer = MyListBox2.Items.Count - 1
        For int = 0 To index
            MyListBox2.Items.RemoveAt(0)
        Next
        Disable_button()
    End Sub

    Private Sub Button_reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_reload.Click
        Dim ldtsTemp As DataSet = cls.Load_Saved_List()
        Dim i As Integer
        MyListBox2.Items.Clear()
        For i = 0 To (ldtsTemp.Tables(0).Rows.Count - 1)
            MyListBox2.Items.Add(ldtsTemp.Tables(0).Rows(i).Item(0))
        Next
        Disable_button()
    End Sub
End Class
