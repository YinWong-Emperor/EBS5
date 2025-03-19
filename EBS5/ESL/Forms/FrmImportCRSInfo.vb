Imports modCommon

Public Class FrmImportCRSInfo
    Dim cls As New ClsImportCRSInfo

    Public Sub runFnc(ByVal fncName As String)

        Me.ListBox1.Items.Add(fncName)
        Me.ListBox1.SelectedIndex() = Me.ListBox1.Items.Count - 1
        Application.DoEvents()

    End Sub

    Private Sub btnLoadExcel_Click(sender As Object, e As EventArgs) Handles btnLoadExcel.Click
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim filename As String = ""
        Dim dt As DataTable = New DataTable
        Dim isImported As Boolean = False
        Try
            openFileDialog1.Filter = "Excel (*.xlsx, *.xls) |*.xlsx; *.xls"
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                filename = openFileDialog1.FileName
                If (GSubShowYNConfirm("Import NEXT-OSS Data? ")) = Windows.Forms.DialogResult.Yes Then

                    isImported = True

                    runFnc("Last imported by " & cls.FncGetActionLog())
                    runFnc("Start to import country data")
 
                    dt = cls.lFncGetCRSInfoFromExcel(filename)
                    If (dt.Rows.Count > 0) Then
                        cls.lFncUploadData(dt, isImported)
                        'GSubShowInfo(GFncGetSysMsg(8))
                    End If

                    runFnc("Completed")
                    runFnc("Successfully imported by " & cls.FncGetActionLog())
                    GSubShowInfo("Successfully imported by " & cls.FncGetActionLog())

                End If
            End If
        Catch ex As Exception
            'GSubWriteELog(ex.Message)
            MessageBox.Show("Import NEXT-OSS Data Failed. Please Retry.", "NEXT-OSS Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Using myProcess As New Process()
                myProcess.StartInfo.FileName = "\\ebs.uat.ecg.eguat.net\UAT\Sample_NEXTOSSData.xls"
                myProcess.Start()
            End Using

        Catch ex As Exception
            ' The error message
            MessageBox.Show("Unable to open link that was clicked.")
        End Try
    End Sub
End Class