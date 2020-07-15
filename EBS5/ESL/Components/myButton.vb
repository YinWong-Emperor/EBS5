Public Class myButton
    Inherits Button

    Private Sub myButton_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled Then
            If GFncCheckFunctionAccess(Me.Parent.FindForm.Name & "." & Me.Name) Then
                Me.Enabled = False
            End If
        End If
    End Sub

    Private Sub myButton_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Me.Enabled Then
            If GFncCheckCommStatus(Me.Parent.FindForm.Name & "." & Me.Name) Then
                Me.Enabled = False
                If Not Me.Parent.Text.Trim.Contains("     Current Lock Status: 'Locked'") Then
                    Me.Parent.Text &= "     Current Lock Status: 'Locked'"
                End If
                Return
            End If
        End If
    End Sub

    Private Sub myButton_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        If Me.Enabled Then
            If GFncCheckCommStatus(Me.Parent.FindForm.Name & "." & Me.Name) Then
                Me.Enabled = False
                If Not Me.Parent.Text.Trim.Contains("     Current Lock Status: 'Locked'") Then
                    Me.Parent.Text &= "     Current Lock Status: 'Locked'"
                End If
                Return
            End If
        End If
    End Sub

End Class
