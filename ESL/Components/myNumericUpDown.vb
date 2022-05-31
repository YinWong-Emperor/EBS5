Public Class myNumericUpDown
    Inherits NumericUpDown

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        If (Text.Trim().Length = 0) Then
            Text = MyBase.Value
            MyBase.OnTextChanged(e)
        End If
    End Sub

    Protected Overrides Sub OnValidating(e As System.ComponentModel.CancelEventArgs)
        Me.Value = Math.Round(Me.Value, Me.DecimalPlaces, MidpointRounding.AwayFromZero)
        MyBase.OnValidating(e)
    End Sub
End Class
