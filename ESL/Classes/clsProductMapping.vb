Imports System.Data.SqlClient
Public Class clsProductMapping

    Public Function FncLoadProduct() As DataTable
        Dim str As String = "(select distinct d_code from product_mapping) union " & _
            "(select distinct product_code as d_code from futures_product_master) union " & _
            "(select distinct code as d_code from FuturesOP where counterparty = 'newedge') union " & _
            "(select distinct code as d_code from FuturesClosePost where counterparty = 'newedge') order by d_code"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Public Function FncLoadNewedge() As DataTable
        'Dim str As String = "(select distinct product from newedge_cap_CP) union " & _
        '    "(select distinct product from newedge_cap_OP) union " & _
        '    "(select distinct d_newedge_code as product from product_mapping) order by product"
        Dim str As String = "(select distinct product from vw_cap_CP) union " & _
           "(select distinct product from vw_cap_OP) union " & _
           "(select distinct d_newedge_code as product from product_mapping) order by product"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Public Function FncSearch(ByVal eCode As String, ByVal eName As String, _
    ByVal nName As String, ByVal CounterParty As String) As DataTable
        Dim str As String = "select d_code, d_desc, d_newedge_code, d_counterparty, CASE WHEN d_isoption = 1 THEN 'Yes' ELSE 'No' END AS d_isoption from product_mapping where 1 = 1 "
        If eCode <> "" Then
            str &= "and d_code like '%" & eCode & "%' "
        End If
        If eName <> "" Then
            str &= "and d_desc like '%" & eName.Replace("'", "''") & "%' "
        End If
        If nName <> "" Then
            str &= "and d_newedge_code like '%" & nName.Replace("'", "''") & "%' "
        End If
        If CounterParty <> "" Then
            str &= "and d_CounterParty like '%" & CounterParty.Replace("'", "''") & "%' "
        End If
        str &= "order by d_code, d_counterparty "
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Public Function FncDelete(ByVal eCode As String, ByVal CounterParty As String, ByVal sIsOption As String) As Boolean
        Dim str As String = "delete from product_mapping where d_code = '" & eCode & _
        "' and d_counterparty = '" & CounterParty & "' AND d_IsOption='" & sIsOption & "' "
        Dim mytrans As SqlTransaction = Nothing
        Try
            mytrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, mytrans, str) <= 0 Then
                mytrans.Rollback()
                Return False
            End If
            mytrans.Commit()
            mytrans = Nothing
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (mytrans IsNot Nothing) Then
                    mytrans.Rollback()
                End If
                GSubWriteErrLog("DeleteFromProductMapping: " & ex.Message)
                Return False
            End If
        End Try
    End Function

    Public Function FncCheckExistEcode(ByVal eCode As String, _
    ByVal CounterParty As String, ByVal isoption As String) As Boolean
        Dim str As String = "Select * from product_mapping where d_code = '" & eCode & _
        "' and d_counterparty = '" & CounterParty & "' AND d_isoption ='" & isoption & "' "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FncCheckExistNName(ByVal nName As String, ByVal eCode As String, _
    ByVal type As String, ByVal CounterParty As String, ByVal isoption As String) As Boolean
        Dim str As String = "select * from product_mapping where d_newedge_code = '" & nName.Replace("'", "''") & _
                "' and d_counterparty = '" & CounterParty.Replace("'", "''") & "' AND d_isoption= '" & isoption & "' "
        If type <> "A" Then
            str &= "and d_code <> '" & eCode & "' "
        End If
        str &= "UNION ALL " & _
                "SELECT * from product_mapping where d_newedge_code = '" & nName.Replace("'", "''") & _
                "' and d_counterparty = '" & CounterParty.Replace("'", "''") & "' AND d_isoption= '" & isoption & "' "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FncInsert(ByVal eCode As String, ByVal eName As String, ByVal nName As String, _
    ByVal CounterParty As String, ByVal IsOption As String) As Boolean
        Dim str As String = "insert into product_mapping (d_code, d_desc, d_newedge_code, " & _
                " d_newedge_desc, d_counterParty, d_isoption) values ('" & _
            eCode & "', '" & eName.Replace("'", "''") & "', '" & nName.Replace("'", "''") & _
            "', '','" & CounterParty.Replace("'", "''") & "', " & IsOption & ")"
        Dim mytrans As SqlTransaction = Nothing
        Try
            mytrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, mytrans, str) <= 0 Then
                mytrans.Rollback()
                Return False
            End If
            mytrans.Commit()
            mytrans = Nothing
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (mytrans IsNot Nothing) Then
                    mytrans.Rollback()
                End If
                GSubWriteErrLog("InsertIntoProductMapping: " & ex.Message)
                Return False
            End If
        End Try
    End Function

    Public Function FncUpdate(ByVal eCode As String, ByVal eName As String, ByVal nName As String, _
    ByVal CounterParty As String, ByVal iIsOption As String, ByVal iOrgIsOption As String) As Boolean
        Dim str As String = "update product_mapping set d_desc = '" & eName.Replace("'", "''") & "', d_newedge_code = '" & _
            nName.Replace("'", "''") & "', d_isoption ='" & iIsOption & "' where d_code = '" & eCode & "' and d_counterparty = '" & CounterParty & "' AND d_isoption = " & iOrgIsOption & ""
        Dim mytrans As SqlTransaction = Nothing
        Try
            mytrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, mytrans, str) <= 0 Then
                mytrans.Rollback()
                Return False
            End If
            mytrans.Commit()
            mytrans = Nothing
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (mytrans IsNot Nothing) Then
                    mytrans.Rollback()
                End If
                GSubWriteErrLog("UpdateProductMapping: " & ex.Message)
                Return False
            End If
        End Try
    End Function
End Class
