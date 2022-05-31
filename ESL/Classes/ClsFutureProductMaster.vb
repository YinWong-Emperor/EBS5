Imports System.Data.SqlClient


Public Class ClsFutureProductMaster

    Public Function FncSearch(
                            ByVal counterParty As String,
                            ByVal isOption As Nullable(Of Boolean),
                            ByVal productCode As String,
                            ByVal productName As String) As DataTable

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_FutureProductMaster", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数
        If Not isOption Is Nothing Then
            AddParameter(sqlCmd, "isOption", IIf(isOption, 1, 0))
        End If
        AddParameter(sqlCmd, "counterParty", counterParty)
        AddParameter(sqlCmd, "productCode", productCode)
        AddParameter(sqlCmd, "productName", productName)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Public Function FncDelete(ByVal id As Integer) As Boolean
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Del_FutureProductMaster", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "id", id)

        Return GFncExecuteNonQuery(sqlCmd)

    End Function

    Public Function FncInsert(
                                ByVal pCounterParty As String,
                                ByVal pProductCode As String,
                                ByVal pProductName As String,
                                ByVal pIsOption As Boolean,
                                ByVal pStrikeDecPla As Integer,
                                ByVal pPriceDecPla As Integer,
                                ByVal pContractSize As Integer) As Boolean

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_FutureProductMaster", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "CounterParty", pCounterParty)
        AddParameter(sqlCmd, "ProductCode", pProductCode)
        AddParameter(sqlCmd, "ProductName", pProductName)
        AddParameter(sqlCmd, "IsOption", IIf(pIsOption, 1, 0))
        AddParameter(sqlCmd, "StrikeDecPla", pStrikeDecPla)
        AddParameter(sqlCmd, "PriceDecPla", pPriceDecPla)
        AddParameter(sqlCmd, "ContractSize", pContractSize)
        
        Return GFncExecuteNonQuery(sqlCmd)
    End Function
    Public Function FncUpdate(
                                ByVal pID As Integer,
                                ByVal pCounterParty As String,
                                ByVal pProductCode As String,
                                ByVal pProductName As String,
                                ByVal pIsOption As Boolean,
                                ByVal pStrikeDecPla As Integer,
                                ByVal pPriceDecPla As Integer,
                                ByVal pContractSize As Integer) As Boolean

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_FutureProductMaster", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "ID", pID)
        AddParameter(sqlCmd, "CounterParty", pCounterParty)
        AddParameter(sqlCmd, "ProductCode", pProductCode)
        AddParameter(sqlCmd, "ProductName", pProductName)
        AddParameter(sqlCmd, "IsOption", IIf(pIsOption, 1, 0))
        AddParameter(sqlCmd, "StrikeDecPla", pStrikeDecPla)
        AddParameter(sqlCmd, "PriceDecPla", pPriceDecPla)
        AddParameter(sqlCmd, "ContractSize", pContractSize)

        
        Return GFncExecuteNonQuery(sqlCmd)
    End Function

End Class
