Imports System.Data.SqlClient
Imports iTextSharp

Public Class FrmLoadNewedge

    Dim cls As New ClsLoadNewEdge
    Dim wordType As System.Type = Type.GetTypeFromProgID("Word.Application")
    Dim wordApplication As Object = Activator.CreateInstance(wordType)

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim lcheck As Boolean = False
        Dim filename As String = ""
        Dim lstr As String = ""
        Try
            openFileDialog1.Filter = "Word (*.doc) |*.doc"
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                filename = openFileDialog1.FileName
                lstr = cls.lFncGetTradeDateFromDoc(filename, wordApplication)
                If (lstr = "") Then
                    GSubShowInfo(GFncGetSysMsg(34))
                    Return
                End If
                If (GSubShowYNConfirm(lstr & GFncGetSysMsg(32)) = Windows.Forms.DialogResult.Yes) Then
                    If (cls.lFncTradeDateImported(lstr, "Newedge") = True) Then
                        If (GSubShowYNConfirm(lstr & GFncGetSysMsg(33) & GFncGetSysMsg(6)) = Windows.Forms.DialogResult.No) Then
                            Return
                        End If
                    Else
                    End If
                    cls.lFncGetTradeData(filename, lstr)
                    GSubShowInfo(GFncGetSysMsg(8))
                End If
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnLoadPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPdf.Click
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim lcheck As Boolean = False
        Dim filename As String = ""
        Dim lstr As String = ""
        Try
            openFileDialog1.Filter = "PDF (*.pdf) |*.pdf"
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                filename = openFileDialog1.FileName
                Dim lcContent As String() = cls.GetTextFromPDF(filename)
                lstr = cls.lFncGetTradeDateFromPDF(lcContent)
                If (lstr = "") Then
                    GSubShowInfo(GFncGetSysMsg(34))
                    Return
                End If
                If (GSubShowYNConfirm(lstr & GFncGetSysMsg(32)) = Windows.Forms.DialogResult.Yes) Then
                    If (cls.lFncTradeDateImported(lstr, "ADM") = True) Then
                        If (GSubShowYNConfirm(lstr & GFncGetSysMsg(33) & GFncGetSysMsg(6)) = Windows.Forms.DialogResult.No) Then
                            Return
                        End If
                    Else
                    End If
                    cls.lFncGetTradeDataFromPDF(filename, lstr)
                    GSubShowInfo(GFncGetSysMsg(8))
                End If
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return
        End Try
    End Sub

    Private Sub FrmLoadNewedge_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not IsDBNull(wordApplication) Then
                wordApplication.Quit()
                cls.releaseObject(wordApplication)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLoadMarex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadMarex.Click
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim lcheck As Boolean = False
        Dim filename As String = ""
        Dim lstr As String = ""
        Try
            'Start [P191038-781 Chris Chan 20211019
            openFileDialog1.Filter = "Excel File (*.xlsx) |*.xlsx"
            'End [P191038-781 Chris Chan 20211019
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                filename = openFileDialog1.FileName
                'Start [P191038-781] Chris Chan 20211019
                'Dim lcContent As String() = cls.GetTextFromMarexPDF(filename)
                'lstr = cls.lFncGetTradeDateFromMarexPDF(lcContent)
                lstr = cls.lFncGetTradeDateFromMarexExcel(filename)
                'End [P191038-781] Chris Chan 20211019
                If (lstr = "") Then
                    GSubShowInfo(GFncGetSysMsg(34))
                    Return
                End If
                If (GSubShowYNConfirm(lstr & GFncGetSysMsg(32)) = Windows.Forms.DialogResult.Yes) Then
                    'If (cls.lFncTradeDateImported(lstr, "Marex") = True) Then
                    '    If (GSubShowYNConfirm(lstr & GFncGetSysMsg(33) & GFncGetSysMsg(6)) = Windows.Forms.DialogResult.No) Then
                    '        Return
                    '    End If
                    'Else
                    'End If
                    'Start [P191038-781] Chris Chan 20211019
                    'cls.lFncGetTradeDataFromMarexPDF(filename, lstr)
                    Me.UseWaitCursor = True
                    Application.DoEvents()
                    cls.lFncGetTradeDataFromMarexExcel(filename, lstr)
                    Me.UseWaitCursor = False
                    'End [P191038-781] Chris Chan 20211019
                    GSubShowInfo(GFncGetSysMsg(8))
                End If
            End If
        Catch ex As Exception
            Me.UseWaitCursor = False
            GSubWriteErrLog(ex.Message)
            Return
        End Try
    End Sub

    Private Sub FrmLoadNewedge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLoadAdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAdv.Click
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim lcheck As Boolean = False
        Dim filename As String = ""
        Dim lstr As String = ""
        Try
            'TO-DO: add logic for reloading.. reference MAREX
            openFileDialog1.Filter = "CSV files (*.csv) |*.csv"
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                'filename = openFileDialog1.FileName.Substring(0, 8)
                filename = openFileDialog1.FileName
                lstr = cls.lFncGetTradeDateFromAdv(filename)
                If (lstr = "") Then
                    GSubShowInfo("Some error for loading the ADV source file name. (should be: yyyyMMddADVDTN.CSV)")
                    Return
                End If
                If (GSubShowYNConfirm(lstr & GFncGetSysMsg(32)) = Windows.Forms.DialogResult.Yes) Then
                    Me.UseWaitCursor = True
                    Application.DoEvents()
                    cls.lFncGetTradeDataFromAdv(filename, lstr)
                    Me.UseWaitCursor = False
                    GSubShowInfo(GFncGetSysMsg(8))
                End If
            End If
        Catch ex As Exception
            Me.UseWaitCursor = False
            GSubWriteErrLog(ex.Message)
            Return
        End Try
    End Sub
End Class