Public Class FrmCommAES

    Dim clsS As New ClsCommAES
    Dim clsF As New ClsCommAE

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Me.DataGridView1.DataSource = clsS.lFncCalTotalComm("200807")
        Me.DataGridView1.DataMember = "tradelist"
        'Me.DataGridView1.Columns("debug").Width = 800

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton1.Click
        Dim ldtDetailF As DataTable
        Dim ldtDetailS As DataTable
        Dim ldtComm As DataTable

        ldtDetailF = clsF.lfncParpareTODTF("200807")
        ldtDetailS = clsS.lFncCalTotalComm("200807").Tables(0)

        ldtComm = clsF.lfncUpdComm("200807", ldtDetailS, ldtDetailF)
        Me.DataGridView1.DataSource = clsS.lFncCalCommManager(ldtComm, "200807")
        'Me.DataGridView1.DataSource = ldtComm
        'Me.DataGridView1.DataMember = "managerlist"

        'total_comm_s, total_comm_f, total_comm_o, total_brok_s, total_brok_f, total_brok_o
    End Sub
End Class
