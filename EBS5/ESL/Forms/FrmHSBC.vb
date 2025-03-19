Imports System.IO

Public Class FrmHSBC

    Dim cls As New ClsHSBC
    Dim stocks As List(Of HSBCEntity)
    Dim fetures As List(Of HSBCEntity)

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmHSBC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtgSList.AutoGenerateColumns = False
        Me.dtgFList.AutoGenerateColumns = False
    End Sub

    Private Sub dtg_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dtgFList.DataBindingComplete
        FormatGridView(dtgSList.Columns)
        FormatGridView(dtgFList.Columns)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            Using fileDialog As New OpenFileDialog
                fileDialog.Filter = "CSV files (*.csv)|*.csv"
                If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim selOne As String = fileDialog.FileName
                    Dim tableNames As String() = New String(1) {"#tmpclts", "#tmpcltf"}
                    Dim ldsLst As DataSet = cls.lFncGetData(tableNames)
                    stocks = New List(Of HSBCEntity)()
                    fetures = New List(Of HSBCEntity)()

                    Using reader As StreamReader = File.OpenText(selOne)
                        cls.lFncFormatLst(reader, ldsLst, stocks, fetures)
                    End Using

                    dtgSList.DataSource = stocks
                    dtgFList.DataSource = fetures
                End If
            End Using
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            If Not IsNothing(stocks) Then
                'Start 20190114 Chris
                'Dim strExFile As String = "AFEImport" & DateTime.Now.ToString("yyyyMMddhhmmss")
                Dim strExFile As String = "AFEImport" & DateTime.Now.ToString("yyyyMMdd")
                'End 20190114 Chris

                If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
                    If (cls.lFncExptHSBC(stocks, GStrExptDir, strExFile) = True) Then
                        GSubShowInfo(GFncGetSysMsg(28))
                    Else
                        GSubShowInfo(GFncGetSysMsg(29))
                    End If
                End If
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
        End Try
    End Sub

End Class
