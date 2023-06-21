Imports System.Data.SqlClient

Public Class ClsEditReportDate

    Protected Friend Function getReportDtl() As DataSet
        Dim query As String = "select ReportSchID, ReportSchName, EmailSubject, ReportSchID+' - '+EmailSubject as Title, PreviousTradeDate, CurrentTradeDate, NextTradeDate from dbo.ReportSchedule order by ReportSchID"
        Return GFncRtnDS(GSCnSqlConn, query)
    End Function

    Protected Friend Function EditTradeDate(ByVal reportSchID As String, ByVal PrvTradeDate As String, ByVal CurTradeDate As String, ByVal NxtTradeDate As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlAdd As String = ""

        sqlAdd += " UPDATE dbo.ReportSchedule set PreviousTradeDate = '" + PrvTradeDate + "',"
        sqlAdd += " CurrentTradeDate = '" + CurTradeDate + "', "
        sqlAdd += " NextTradeDate = '" + NxtTradeDate + "' "
        sqlAdd += "where ReportSchID = '" + reportSchID + "'"

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            GFncRunSQL(GSCnSqlConn, MyTrans, sqlAdd, 0)

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function
End Class