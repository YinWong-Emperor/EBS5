Public Class myNumericBox
    Inherits TextBox

    Dim horAlign As HorizontalAlignment

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


End Class
