Public Class FrmCorporateProfile

    Dim cls As New ClsCorporateProfile

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        lSubClearForm()

    End Sub

    Private Sub lSubClearForm()

        Me.txtName.Text = ""
        Me.txtAcc.Text = ""
        Me.txtMargin.Text = ""
        Me.txtPrincipal.Text = ""
        Me.txtNature.Text = ""
        Me.txtFund.Text = ""
        Me.rbUnder1.Checked = True
        Me.cbCapital.Checked = False
        Me.cbSpeculative.Checked = False
        Me.cbIPO.Checked = False
        Me.cbHedging.Checked = False
        Me.cbLongTerm.Checked = False
        Me.cbMediumTerm.Checked = False
        Me.cbShortTerm.Checked = False
        Me.txtSum.Text = ""
        Me.rbTrader.Checked = True
        Me.rbYes.Checked = True

    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim accno As String
        Dim ldtsTemp As DataSet
        Dim ldtwTemp As DataRow

        accno = Trim(Me.txtAcc.Text)
        If (accno = "") Then
            GSubShowInfo(GFncGetSysMsg(5))
            Me.txtAcc.Focus()
        Else
            ldtsTemp = cls.lFncViewClient(accno)
            If ldtsTemp.Tables(0).Rows.Count > 0 Then
                ldtwTemp = ldtsTemp.Tables(0).Rows(0)
                Me.txtName.Text = ldtwTemp("name")
                Me.txtAcc.Text = ldtwTemp("accno")
                Me.txtMargin.Text = ldtwTemp("margin_ac")
                Me.txtPrincipal.Text = ldtwTemp("place")
                Me.txtNature.Text = ldtwTemp("business")
                Me.txtFund.Text = ldtwTemp("funds")
                If (ldtwTemp("experience") = 1) Then
                    Me.rbUnder1.Checked = True
                ElseIf (ldtwTemp("experience") = 2) Then
                    Me.rb1to5.Checked = True
                Else
                    Me.rbOver5.Checked = True
                End If
                Me.cbCapital.Checked = ldtwTemp("capital_preservative")
                Me.cbSpeculative.Checked = ldtwTemp("speculative")
                Me.cbIPO.Checked = ldtwTemp("ipo")
                Me.cbHedging.Checked = ldtwTemp("hedging")
                Me.cbLongTerm.Checked = ldtwTemp("long_term")
                Me.cbMediumTerm.Checked = ldtwTemp("medium_term")
                Me.cbShortTerm.Checked = ldtwTemp("short_term")
                Me.txtSum.Text = ldtwTemp("investment")
                If (ldtwTemp("trader_or_investor") = 1) Then
                    Me.rbTrader.Checked = True
                Else
                    Me.rbInvestor.Checked = True
                End If
                If (ldtwTemp("knowledgeable_investor") = 1) Then
                    Me.rbYes.Checked = True
                Else
                    Me.rbNo.Checked = True
                End If
            Else
                GSubShowInfo(GFncGetSysMsg(86))
            End If
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim accno As String

        accno = Trim(Me.txtAcc.Text)
        If (accno = "") Then
            GSubShowInfo(GFncGetSysMsg(5))
            Me.txtAcc.Focus()
        Else
            cls.lFncDeleteClient(accno)
            Me.lSubClearForm()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim accno As String
        Dim sqlstr As String

        accno = Trim(Me.txtAcc.Text)
        If (accno = "") Then
            GSubShowInfo(GFncGetSysMsg(5))
            Me.txtAcc.Focus()
        Else
            sqlstr = "'" & Me.txtAcc.Text & "','" & Me.txtMargin.Text & "','" & Me.txtName.Text & "','" & Me.txtPrincipal.Text & _
                        "','" & Me.txtNature.Text & "','" & Me.txtFund.Text & "',"
            If (Me.rbUnder1.Checked) Then
                sqlstr += "1,"
            ElseIf (Me.rb1to5.Checked) Then
                sqlstr += "2,"
            Else
                sqlstr += "3,"
            End If
            If (Me.cbCapital.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            If (Me.cbSpeculative.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            If (Me.cbIPO.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            If (Me.cbHedging.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            If (Me.cbLongTerm.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            If (Me.cbMediumTerm.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            If (Me.cbShortTerm.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "0,"
            End If
            sqlstr += Me.txtSum.Text & ","
            If (Me.rbTrader.Checked) Then
                sqlstr += "1,"
            Else
                sqlstr += "2,"
            End If
            If (Me.rbYes.Checked) Then
                sqlstr += "1"
            Else
                sqlstr += "2"
            End If

            cls.lFncSaveClient(accno, sqlstr)
            Me.lSubClearForm()
        End If

    End Sub
End Class
