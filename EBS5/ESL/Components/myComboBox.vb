Public Class myComboBox
    Inherits ComboBox

    Private Sub myComboBox_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            If GFncCheckFunctionAccess(Me.Parent.FindForm.Name & "." & Me.Name) Then
                Me.Enabled = False
            End If
        End If
    End Sub

End Class
