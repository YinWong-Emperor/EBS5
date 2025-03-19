Imports modCommon

Public Class FrmImportCRSAccountInfo
    Dim cls As New ClsImportCRSAccountInfo

    Private Sub FrmImportCRSAccountInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.numReturnYear.Value = DateTime.Now.Year - 1
    End Sub

    Public Sub runFnc(ByVal fncName As String)

        Me.ListBox1.Items.Add(fncName)
        Me.ListBox1.SelectedIndex() = Me.ListBox1.Items.Count - 1
        Application.DoEvents()

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            If (GSubShowYNConfirm("Import CRS Account Info from G2B? ")) = Windows.Forms.DialogResult.Yes Then
                runFnc("Last imported by " & cls.FncGetActionLog())
                runFnc("Start to import CRS Account Info")

                cls.lFncImportData(Me.numReturnYear.Value)

                runFnc("Completed")
                runFnc("Successfully imported by " & cls.FncGetActionLog())
                GSubShowInfo("Successfully imported by " & cls.FncGetActionLog())

            End If
        Catch ex As Exception
            'GSubWriteELog(ex.Message)
            MessageBox.Show("Import CRS Account Info Failed. Please Retry.", "CRS Account Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class