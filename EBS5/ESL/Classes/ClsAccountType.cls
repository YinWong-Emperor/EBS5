Public Class ClsAccountType
    Private Key As String

    Public Shared ReadOnly Futures As ClsAccountType = New ClsAccountType("Futures")
    Public Shared ReadOnly Securities As ClsAccountType = New ClsAccountType("Securities")
    Public Shared ReadOnly CIES As ClsAccountType = New ClsAccountType("CIES")
    Public Shared ReadOnly StockOption As ClsAccountType = New ClsAccountType("StockOption")
    Public Shared ReadOnly MutualFund As ClsAccountType = New ClsAccountType("MutualFund")

    Private Sub New(ByVal key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Key
    End Function
End Class
