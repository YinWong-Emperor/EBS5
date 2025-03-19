Public Class myRadioButton

    Inherits RadioButton

    Private Sub myRadioButton_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled Then
            If GFncCheckFunctionAccess(Me.Parent.FindForm.Name & "." & Me.Name) Then
                Me.Enabled = False
            End If
        End If
    End Sub
End Class
