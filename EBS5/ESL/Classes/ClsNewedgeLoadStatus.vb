Public Class ClsNewedgeLoadStatus

    Protected Friend Function getClientInfo() As DataSet

        Dim lstrsql As String

        'lstrsql = "select distinct tdate from newedge_content order by tdate"
        lstrsql = "select tdate, counterparty from newedge_content group by counterparty, tdate order by tdate"
        Return GFncRtnDS(GSCnSqlConn, lstrsql, 0)

    End Function

    Protected Friend Function getContent(ByVal tdate As String, ByVal pCounterParty As String) As DataSet

        Dim lstrsql As String

        lstrsql = "select content from newedge_content where tdate = '" & tdate & "' "
        If pCounterParty = "" Then
            lstrsql = lstrsql & "and counterparty IS NULL order by line"
        Else
            lstrsql = lstrsql & "and counterparty = '" & pCounterParty & "' order by line"
        End If

        Return GFncRtnDS(GSCnSqlConn, lstrsql, 0)

    End Function

End Class
