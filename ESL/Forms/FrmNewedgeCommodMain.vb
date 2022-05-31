Imports System.Data.SqlClient

Public Class FrmNewedgeCommodMain

    Dim cls As New ClsNewedgeCommodMain
    Dim preID As String = ""

    Private Sub FrmNewedgeCommodMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lFnLoadCommodity()
        lFncChangeButtonStatus(True)

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        preID = ""
        lFncClearField()
        lFncChangeFieldStatus(True)
        lFncChangeButtonStatus(False)
        Me.txtriccode.Focus()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        preID = Me.dtgCommod.Item(0, Me.dtgCommod.CurrentRow.Index).Value
        Me.txtriccode.Text = Me.dtgCommod.Item(1, Me.dtgCommod.CurrentRow.Index).Value
        Me.txtcommod.Text = Me.dtgCommod.Item(2, Me.dtgCommod.CurrentRow.Index).Value
        Me.nbcommf.Text = Me.dtgCommod.Item(3, Me.dtgCommod.CurrentRow.Index).Value
        Me.nbClearingf.Text = Me.dtgCommod.Item(4, Me.dtgCommod.CurrentRow.Index).Value
        Me.nblevyf.Text = Me.dtgCommod.Item(5, Me.dtgCommod.CurrentRow.Index).Value
        Me.nbcomme.Text = Me.dtgCommod.Item(6, Me.dtgCommod.CurrentRow.Index).Value
        Me.nbclearinge.Text = Me.dtgCommod.Item(7, Me.dtgCommod.CurrentRow.Index).Value
        Me.nblevye.Text = Me.dtgCommod.Item(8, Me.dtgCommod.CurrentRow.Index).Value
        lFncChangeFieldStatus(True)
        lFncChangeButtonStatus(False)
        Me.txtriccode.Focus()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim MyTrans As SqlTransaction = Nothing

        preID = Me.dtgCommod.Item(0, Me.dtgCommod.CurrentRow.Index).Value

        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then

            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                cls.lFncDeleteCommod(preID, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing

                lFnLoadCommodity()
                GSubShowInfo(GFncGetSysMsg(8))
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try

        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim i As Integer = 0
        Dim rowIndex As Integer = 0
        Dim MyTrans As SqlTransaction = Nothing
        Dim curRicCode As String = ""

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            For i = 0 To Me.dtgCommod.Rows.Count - 1
                If (Me.dtgCommod.Rows(i).Cells(0).Value.ToString.Trim <> preID) Then
                    If (Me.dtgCommod.Rows(i).Cells(1).Value = Me.txtriccode.Text) Then
                        GSubShowInfo(GFncGetSysMsg(35))
                        Return
                    End If
                    If (Me.dtgCommod.Rows(i).Cells(2).Value = Me.txtcommod.Text) Then
                        GSubShowInfo(GFncGetSysMsg(36))
                        Return
                    End If
                End If
            Next

            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                If (preID = "") Then 'add
                    cls.lFncInsertCommod(Me.txtriccode.Text, Me.txtcommod.Text, Me.nbcommf.Text, Me.nbClearingf.Text, _
                                        Me.nblevyf.Text, Me.nbcomme.Text, Me.nbclearinge.Text, Me.nblevye.Text, MyTrans)
                                        rowIndex = Me.dtgCommod.RowCount
                Else 'edit
                    cls.lFncUpdateCommod(preID, Me.txtriccode.Text, Me.txtcommod.Text, Me.nbcommf.Text, Me.nbClearingf.Text, _
                                        Me.nblevyf.Text, Me.nbcomme.Text, Me.nbclearinge.Text, Me.nblevye.Text, MyTrans)
                    rowIndex = Me.dtgCommod.CurrentRow.Index
                End If
                curRicCode = Me.txtriccode.Text.Trim
                MyTrans.Commit()
                MyTrans = Nothing
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try

            lFncClearField()
            lFnLoadCommodity()
            lFncChangeFieldStatus(False)
            lFncChangeButtonStatus(True)

            For i = 0 To Me.dtgCommod.Rows.Count - 1
                If (Me.dtgCommod.Rows(i).Cells(1).Value.ToString.Trim = curRicCode) Then
                    Me.dtgCommod.Rows(i).Cells(1).Selected = True
                    Me.dtgCommod.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next

            GSubShowInfo(GFncGetSysMsg(8))
        End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        lFncClearField()
        lFncChangeFieldStatus(False)
        lFncChangeButtonStatus(True)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub lFnLoadCommodity()

        Me.dtgCommod.DataSource = cls.lFncGetCommodities()
        Me.dtgCommod.DataMember = "commod"

    End Sub

    Private Sub lFncClearField()

        Me.txtriccode.Text = ""
        Me.txtcommod.Text = ""
        Me.nbcommf.Text = ""
        Me.nbClearingf.Text = ""
        Me.nblevyf.Text = ""
        Me.nbcomme.Text = ""
        Me.nbclearinge.Text = ""
        Me.nblevye.Text = ""

    End Sub

    Private Sub lFncChangeFieldStatus(ByVal flag As Boolean)

        Me.txtriccode.Enabled = flag
        Me.txtcommod.Enabled = flag
        Me.nbcommf.Enabled = flag
        Me.nbClearingf.Enabled = flag
        Me.nblevyf.Enabled = flag
        Me.nbcomme.Enabled = flag
        Me.nbclearinge.Enabled = flag
        Me.nblevye.Enabled = flag

    End Sub

    Private Sub lFncChangeButtonStatus(ByVal flag As Boolean)

        Me.btnNew.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.btnReset.Enabled = Not flag
        Me.btnCancel.Enabled = flag

    End Sub

End Class
