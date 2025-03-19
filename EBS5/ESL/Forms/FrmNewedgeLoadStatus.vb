Public Class FrmNewedgeLoadStatus

    Dim cls As New ClsNewedgeLoadStatus

    Private Sub FrmNewedgeLoadStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim lds As DataSet

        lds = cls.getClientInfo()

        For row As Integer = 0 To lds.Tables(0).Rows.Count - 1
            If GFncNoNullString(lds.Tables(0).Rows(row).Item(1).ToString()) = "" Then
                Me.lbtdate.Items.Add(lds.Tables(0).Rows(row).Item(0).ToString())
            Else
                Me.lbtdate.Items.Add(lds.Tables(0).Rows(row).Item(0).ToString() & " - " & GFncNoNullString(lds.Tables(0).Rows(row).Item(1).ToString()))
            End If
        Next

        Me.lbtdate.SelectedIndex = 0

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lbtdate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtdate.SelectedIndexChanged

        Dim lds As DataSet

        Me.rtbcontent.Text = ""
        Me.rtbcontent.WordWrap = False

        Dim tString As String = Me.lbtdate.SelectedItem.ToString
        Dim lcTradeDate As String = ""
        Dim lcCounterParty As String = ""
        If tString.Contains(" - ") Then
            lcTradeDate = tString.Substring(0, tString.IndexOf(" - "))
            lcCounterParty = tString.Substring(tString.IndexOf(" - ") + Len(" - "))
        Else
            lcTradeDate = tString
        End If

        'lds = cls.getContent(Me.lbtdate.SelectedItem.ToString)
        lds = cls.getContent(lcTradeDate, lcCounterParty)

        For row As Integer = 0 To lds.Tables(0).Rows.Count - 1
            Dim lstr As String = lds.Tables(0).Rows(row).Item(0).ToString()
            If lstr.Contains(vbLf) Then
                Me.rtbcontent.AppendText(lstr)
            Else
                Me.rtbcontent.AppendText(lstr & vbLf)
            End If

        Next

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub
End Class
