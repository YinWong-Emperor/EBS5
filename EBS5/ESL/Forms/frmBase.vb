Public Class frmBase

    Dim frm As frmMenu
    Const strToolBarExit = "ToolStripButton7"
    Dim isControlEventSeted As Boolean = False

    Private Sub frmBase_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not Me.MdiParent Is Nothing Then
            frm = Me.MdiParent
            frm.MenuStrip1.Items("ExitToolStripMenuItem2").Enabled = False
            frm.toolbarMenu.Items(strToolBarExit).Enabled = False
        End If
    End Sub

    Private Sub frmBase_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        GBlnFormOpen = False
        If Not frm Is Nothing Then
            If frm.MdiChildren.Length = 1 Then
                frm.MenuStrip1.Items("ExitToolStripMenuItem2").Enabled = True
                frm.toolbarMenu.Items(strToolBarExit).Enabled = True
            End If
        End If
    End Sub

    Private Sub frmBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isControlEventSeted = False Then
            GSubSetControlMoveNext(Me)
            GSubSetTextBoxGotFocus(Me)
            isControlEventSeted = True
        End If

        If Me.Text.Trim <> "" Then
            Me.Text &= Space(10)
        End If

        '2017-11-22  Õë¶Ômantisbt-6394 µÄÐÞ¸Ä
        If Not Me.Text.Contains("User:") Then
            Me.Text &= "User: " & GStrloginID & Space(5) & "Trade Date: " & Format(GDteTradeDate, "dd/MM/yyyy")
        End If

        Me.KeyPreview = True
        Me.AutoScroll = False
        GBlnFormOpen = True

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub SetAutoScroll()
        Me.AutoScroll = True
        Me.Width += 25
    End Sub

End Class