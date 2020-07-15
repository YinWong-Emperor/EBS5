Public Class myDateTimePicker
    Inherits DateTimePicker

    Public Sub New()
        ' Initialise the class 
        MyBase.New()
    End Sub

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
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), -1, 1)
    End Sub

End Class
