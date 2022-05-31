Imports System.Data.SqlClient

Public Class ClsCorporateProfile

    Protected Friend Function lFncViewClient(ByVal accno As String) As DataSet

        Dim lstrSQL As String = ""

        lstrSQL = "select accno, margin_ac, name, place, business, funds, experience, capital_preservative, " & _
                    "speculative, ipo, hedging, long_term, medium_term, short_term, investment, trader_or_investor, " & _
                    "knowledgeable_investor from corp_client where accno = '" & accno & "'"
        Return GFncRtnDS(GSCnBalConn, lstrSQL)

    End Function

    Protected Friend Sub lFncDeleteClient(ByVal accno As String)

        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet
        Dim MyTrans As SqlTransaction = Nothing

        lstrSQL = "select * from corp_client where accno = '" & accno & "'"
        ldtsTemp = GFncRtnDS(GSCnBalConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11)) = 6 Then
                Try
                    MyTrans = GSCnLiqConn.BeginTransaction

                    lstrSQL = "DELETE from corp_client where accno = '" & accno & "'"
                    GFncRunSQL(GSCnBalConn, lstrSQL, 0)

                    MyTrans.Commit()
                    MyTrans = Nothing
                Catch ex As Exception
                    If GSCnLiqConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                    End If
                End Try
            End If
        Else
            GSubShowInfo(GFncGetSysMsg(86))
        End If

    End Sub

    Protected Friend Sub lFncSaveClient(ByVal accno As String, ByVal condition As String)

        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "select * from corp_client where accno = '" & accno & "'"
            ldtsTemp = GFncRtnDS(GSCnBalConn, lstrSQL, 0)
            If ldtsTemp.Tables(0).Rows.Count > 0 Then
                If GSubShowYNConfirm(GFncGetSysMsg(7) & GFncGetSysMsg(6)) = 6 Then
                    lstrSQL = "delete from client where accno = '" & accno & "'"
                    GFncRunSQL(GSCnBalConn, lstrSQL, 0)
                Else
                    Return
                End If
            End If
            lstrSQL = "INSERT INTO corp_client(accno, margin_ac, name, place, business, funds, experience, capital_preservative, " & _
                        "speculative, ipo, hedging, long_term, medium_term, short_term, investment, trader_or_investor, " & _
                        "knowledgeable_investor) values (" & condition & ")"
            GFncRunSQL(GSCnBalConn, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Sub

End Class
