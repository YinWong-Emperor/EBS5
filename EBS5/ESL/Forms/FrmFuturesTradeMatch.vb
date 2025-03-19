Imports System.Text
Imports System.IO

Public Class FrmFuturesTradeMatch

    Dim cls As New ClsFuturesTradeMatch

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'Dim word As New Microsoft.Office.Interop.Word.Application
        'Dim doc As Microsoft.Office.Interop.Word.Document = Nothing
        'Dim myWord As Microsoft.Office.Interop.Word.Range
        'Dim lstr As String = ""
        'Dim lcontent As String = ""
        'Dim i As Integer = 1
        'Dim readtype As Integer = 0
        'Dim lsWriter As StreamWriter = Nothing
        'Dim ldtComfirm As New DataTable
        'Dim ldtPurchase As New DataTable
        'Dim ldtOpenPost As New DataTable

        'Try
        '    lsWriter = New StreamWriter("C:\test.txt", False, System.Text.Encoding.GetEncoding(950))
        '    doc = word.Documents.Open("c:\test.doc")
        '    doc.Activate()

        '    cls.lFncCreateTempTable()

        '    For Each myWord In doc.Sentences
        '        If (i > 88) Then
        '            i = 1
        '            lsWriter.WriteLine(lstr)
        '        End If
        '        If (i >= 15) Then
        '            lstr = myWord.Text
        '            lstr = lcontent & lstr

        '            If (InStr(lstr, "C  O  N  F  I  R  M  A  T  I  O  N") > 0) Then
        '                readtype = 1
        '            ElseIf (InStr(lstr, "P  U  R  C  H  A  S  E") > 0) Then
        '                readtype = 2
        '            ElseIf (InStr(lstr, "O  P  E  N      P  O  S  I  T  I  O  N  S") > 0) Then
        '                readtype = 3
        '            Else
        '                If (lstr.Trim.Length > 0) Then
        '                    If (IsNumeric(lstr.Substring(1, 2)) = True) Then
        '                        Dim lvalue As String
        '                        'Dim ldate As Date
        '                        Dim action As String
        '                        Dim qty As String
        '                        Dim ldesc As String
        '                        Dim monthcode As String


        '                        'lvalue = lstr.Substring(1, 7)
        '                        'If (lvalue.Trim.Length = 0) Then
        '                        '    'error message
        '                        '    'Return
        '                        'End If
        '                        'ldate = CDate(lvalue.Substring(5, 2) & lvalue.Substring(2, 3) & lvalue.Substring(0, 2))

        '                        If (lstr.Substring(20, 14).Trim.Length = 0 And lstr.Substring(35, 14).Trim.Length = 0) Then
        '                            'error message
        '                            'Return
        '                        End If
        '                        If (lstr.Substring(20, 14).Trim.Length <> 0) Then
        '                            action = "L"
        '                            qty = CDbl(lstr.Substring(20, 14))
        '                        Else
        '                            action = "S"
        '                            qty = CDbl(lstr.Substring(35, 14))
        '                        End If

        '                        lvalue = lstr.Substring(50, 30)
        '                        If (lvalue.Trim.Length = 0) Then
        '                            'error message
        '                            'Return
        '                        End If
        '                        ldesc = lvalue
        '                        monthcode = ldesc.Substring(4, 2) & cls.lFncGetMonth(ldesc.Substring(0, 3))

        '                        ldesc = ldesc.Substring(7, 23)

        '                        'lvalue = lstr.Substring(84, 11)
        '                        'If (IsNumeric(lvalue) = False) Then
        '                        '    'error message
        '                        '    'Return
        '                        'End If



        '                        If (readtype = 1) Then
        '                            'cls.lFncInsertDate(ldtComfirm, CDate(ldate), action, qty)
        '                        ElseIf (readtype = 2) Then
        '                            '  cls.lFncInsertDate(ldtPurchase, CDate(ldate), action, qty)
        '                        ElseIf (readtype = 3) Then
        '                            cls.lFncInsertData(ldtOpenPost, action, qty, ldesc, monthcode)
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '        i = i + 1
        '    Next



        '    'cls.lFncDropTempTable()

        '    End
        'Catch ex As System.Runtime.InteropServices.COMException
        '    MessageBox.Show("Error accessing Word document.")
        'Finally
        '    doc.Close(True)
        '    lsWriter.Flush()
        '    lsWriter.Close()
        'End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
