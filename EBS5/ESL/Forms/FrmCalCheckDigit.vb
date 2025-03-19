Public Class FrmCalCheckDigit

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim checkdigit As Integer
        Dim odddigit As Integer
        Dim evendigit As Integer
        Dim accnolength As Integer = 8

        Me.txtUserID.Text = Trim(Me.txtUserID.Text)

        If (Me.txtUserID.Text.Length <= 0 Or Me.txtUserID.Text.Length > accnolength) Then
            GSubShowInfo(GFncGetSysMsg(16))
            Return
        Else
            If (Me.txtUserID.Text.Length < accnolength) Then
                Dim i As Integer

                i = Me.txtUserID.Text.Length
                Do Until i = accnolength
                    Me.txtUserID.Text = "0" & Me.txtUserID.Text
                    i = i + 1
                Loop
            End If
        End If

        odddigit = CInt(Mid(Me.txtUserID.Text, 1, 1)) + CInt(Mid(Me.txtUserID.Text, 3, 1)) + _
                        CInt(Mid(Me.txtUserID.Text, 5, 1)) + CInt(Mid(Me.txtUserID.Text, 7, 1))
        evendigit = CInt(Mid(Me.txtUserID.Text, 2, 1)) + CInt(Mid(Me.txtUserID.Text, 4, 1)) + _
                        CInt(Mid(Me.txtUserID.Text, 6, 1)) + CInt(Mid(Me.txtUserID.Text, 8, 1))
        checkdigit = (odddigit * 3) + evendigit
        checkdigit = checkdigit Mod 10
        checkdigit = 10 - checkdigit
        checkdigit = checkdigit Mod 10
        Me.txtCheckDigit.Text = checkdigit

    End Sub

End Class
