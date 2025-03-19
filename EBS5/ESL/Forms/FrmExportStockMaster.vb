Imports System.Threading
Imports System.Globalization
Imports System.Windows.Forms

Public Class FrmExportStockMaster
    Dim cls As New ClsStockMaster

    Private Sub FrmExportStockMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetProductType()
        SetClosingDate()
    End Sub

    Private Sub SetProductType()
        Dim dtProductType As New DataTable
        dtProductType = cls.lFnGetProductType().Tables(0)

        For Each row As DataRow In dtProductType.Rows
            lstProductType.Items.Add(row("description"))
        Next

        SwapItem(lstProductType, lstSelectedProductType, True)
    End Sub

    Private Sub SetClosingDate()
        Dim g2sbRetTdate As New Date

        Thread.CurrentThread.CurrentCulture = New CultureInfo(GFncGetCulture())
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(GFncGetCulture())

        dtpCpDate.Format = DateTimePickerFormat.Custom
        dtpCpDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        g2sbRetTdate = GFncGetG2sbRetTDate()
        dtpCpDate.Value = g2sbRetTdate
        dtpCpDate.MaxDate = g2sbRetTdate

        dtpCpDate.Checked = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAddPt_Click(sender As Object, e As EventArgs) Handles btnAddPt.Click
        SwapItem(lstProductType, lstSelectedProductType, False)
    End Sub

    Private Sub btnRemovePt_Click(sender As Object, e As EventArgs) Handles btnRemovePt.Click
        SwapItem(lstSelectedProductType, lstProductType, False)
    End Sub

    Private Sub SwapItem(lsbFrom As ListBox, lsbTo As ListBox, ByVal swapAll As Boolean)
        Dim lastIndex As Integer = 0

        If swapAll Then
            For i As Integer = 0 To lsbFrom.Items.Count - 1
                lsbTo.Items.Add(lsbFrom.Items(0))
                lsbFrom.Items.RemoveAt(0)
            Next
        Else
            For i As Integer = 0 To lsbFrom.SelectedIndices.Count - 1
                lastIndex = lsbFrom.SelectedIndex
                lsbTo.Items.Add(lsbFrom.SelectedItem)
                lsbFrom.Items.RemoveAt(lsbFrom.SelectedIndex)
            Next
        End If

        If lastIndex <= lsbFrom.Items.Count - 1 Then
            lsbFrom.SetSelected(lastIndex, True)
        ElseIf lastIndex = lsbFrom.Items.Count And lastIndex > 0 Then
            lsbFrom.SetSelected(lastIndex - 1, True)
        End If
    End Sub

    Private Sub btnAddAllPt_Click(sender As Object, e As EventArgs) Handles btnAddAllPt.Click
        SwapItem(lstProductType, lstSelectedProductType, True)
    End Sub

    Private Sub btnRemoveAllPt_Click(sender As Object, e As EventArgs) Handles btnRemoveAllPt.Click
        SwapItem(lstSelectedProductType, lstProductType, True)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If lstSelectedProductType.Items.Count <= 0 Then
            GSubShowWarn("Please select at least one product type.")
        Else
            Dim selectedProductTypes(lstSelectedProductType.Items.Count - 1) As String
            lstSelectedProductType.Items.CopyTo(selectedProductTypes, 0)

            Dim cpDate As DateTime = DateTime.MinValue
            If dtpCpDate.Checked Then
                cpDate = dtpCpDate.Value
            End If

            If cls.lFncExportStockMaster(selectedProductTypes, cpDate) Then
                GSubShowInfo(GFncGetSysMsg(28))
            End If
        End If
    End Sub
End Class