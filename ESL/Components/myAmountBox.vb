Public Class myAmountBox
    Inherits TextBox

    Dim horAlign As HorizontalAlignment
    Dim lintDP As Integer = 2
    Dim removeTrailingZero As Boolean = False
    Dim intNum As Integer = 9

    Public Sub New()
        ' Initialise the class 
        MyBase.New()
        AddHandler Me.KeyPress, AddressOf myKeyPress
        AddHandler Me.Validating, AddressOf myValidating
        Me.TextAlign = HorizontalAlignment.Right
    End Sub

    Public Shadows Property TextAlign() As HorizontalAlignment
        Get
            Return MyBase.TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            horAlign = value
            MyBase.TextAlign = value
        End Set
    End Property

    Public Shadows Property EnabledRemoveTrailingZero() As Boolean
        Get
            Return removeTrailingZero
        End Get
        Set(ByVal Value As Boolean)
            removeTrailingZero = Value
        End Set
    End Property

    Public Shadows Property Enabled() As Boolean
        Get
            Return MyBase.Enabled
        End Get
        Set(ByVal Value As Boolean)
            ' Set the underlying value 
            MyBase.Enabled = Value
        End Set
    End Property

    'compatibility for base.Enable
    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)
        ' Switch draw styles if disabled 
        Me.SetStyle(ControlStyles.UserPaint, Not MyBase.Enabled)
    End Sub

    Public Property DecimalPoints() As Integer
        Get
            Return lintDP
        End Get
        Set(ByVal value As Integer)
            lintDP = value
        End Set
    End Property

    Public Property IntLen() As Integer
        Get
            Return intNum
        End Get
        Set(ByVal value As Integer)
            intNum = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As Global.System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        ' Draw the bg in 
        e.Graphics.FillRectangle(New SolidBrush(Color.LemonChiffon), Me.ClientRectangle)

        ' Draw the appropriate text in using the fore color 
        If horAlign = HorizontalAlignment.Left Then
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), -1, 1)
        ElseIf horAlign = HorizontalAlignment.Right Then
            Dim boundLeft As Integer
            boundLeft = e.ClipRectangle.Width - e.Graphics.MeasureString(Me.Text, Me.Font).Width + 1
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), _
                New RectangleF(boundLeft, 1, e.ClipRectangle.Width, e.ClipRectangle.Height + 2))
        End If

        '        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), _
        '            Me.Width - e.Graphics.MeasureString(Me.Text.Trim, f).Width * 1.3, 1)

    End Sub

    Private Sub myKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case ChrW(Keys.D0), ChrW(Keys.D1), ChrW(Keys.D2), ChrW(Keys.D3), _
                ChrW(Keys.D4), ChrW(Keys.D5), ChrW(Keys.D6), ChrW(Keys.D7), _
                ChrW(Keys.D8), ChrW(Keys.D9), ChrW(Keys.Enter), ChrW(Keys.Escape), _
                ChrW(Keys.Return), ChrW(Keys.Back), ChrW(Keys.Up), ChrW(Keys.Down), _
                ChrW(Keys.Left), ChrW(Keys.Right), "."c, "+"c, "-"c
                'pass the check
            Case Else
                'not pass the check
                e.Handled = True
        End Select
    End Sub

    Private Sub myValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not IsNumeric(Me.Text.Trim) And Me.Text.Trim <> "" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub myAmountBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        Me.SelectAll()

        If Me.Text <> "" Then
            If IsNumeric(Me.Text) Then
                Me.Text = CType(Me.Text.Trim, Decimal)
            End If
        Else
            Me.Text = "0"
        End If
    End Sub

    Private Sub myAmountBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        formatText()
    End Sub

    'for mantis #6420
    Private Function TNum(Num As String) As Integer
        Num = Replace(Num, ",", "")
        If Strings.Left(Num, 1) = "0" Or Strings.Left(Num, 1) = "-" Or Strings.Left(Num, 1) = "." Then
            TNum = TNum(Strings.Right(Num, Len(Num) - 1))
        Else
            Num = Replace(Num, ".", "")
            TNum = Len(Num)
        End If
    End Function

    Private Sub formatText()
        Dim lstrDP As String = ""
        Dim i As Integer = 0

        If lintDP > 0 Then
            For i = 1 To lintDP
                lstrDP &= "0"
            Next
            lstrDP = "." & lstrDP
        Else
            lstrDP = ""
        End If

        'for mantis #6420
        Dim intPart As Integer = 0
        Dim intPartStr As String = ""

        If (Me.Text <> "") Then
            Dim parts As Array = Me.Text.Split(CChar("."))
            intPartStr = parts.GetValue(0)
            intPart = TNum(intPartStr)
        End If

        If (intPart > IntLen) Then
            intPartStr = Replace(intPartStr, ",", "")
            Dim s As String = Microsoft.VisualBasic.Right(intPartStr, IntLen + 2)
            Me.Text = String.Format("{0}.{1}", s.Substring(0, s.Length - 2), s.Substring(s.Length - 2, 2))
        End If

        If Me.Text <> "" Then
            If IsNumeric(Me.Text) Then
                If removeTrailingZero Then
                    Me.Text = Format(CDec(Me.Text), "###,###,##0" & lstrDP & "###############")
                Else
                    Me.Text = Format(CDec(Me.Text), "###,###,##0" & lstrDP)
                End If

            End If
        Else
            Me.Text = "0"
        End If
    End Sub

    Private Sub myAmountBox_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
        If Not Me.Focused Then
            formatText()
        End If
    End Sub

End Class
