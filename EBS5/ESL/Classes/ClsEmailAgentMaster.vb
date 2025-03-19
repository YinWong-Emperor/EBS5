Imports System.Data.SqlClient

Public Class ClsEmailAlertRecipientList
    Dim EmailDT As DataTable

    Protected Friend Function getEmailSubject() As DataSet
        Dim query As String = "select ReportSchID, ReportSchName, EmailSubject from dbo.ReportSchedule order by EmailSubject"
        Return GFncRtnDS(GSCnSqlConn, query)
    End Function

    Protected Friend Function EmailRefresh(ByVal reportSchID As String, ByVal reportSchName As String) As DataTable
        Dim query As String = String.Empty
        query += " declare @EmailList as varchar(1000) "
        query += " select @EmailList = EmailList from dbo.ReportSchedule where ReportSchID = '" + reportSchID + "' "
        query += " and ReportSchName = '" + reportSchName + "' "
        query += " SELECT Splitcolumn as 'Email Address' FROM dbo.[f_SplitStringToRow] (@EmailList,';') "
        query += " WHERE Splitcolumn <> '' AND Splitcolumn is not null "
        EmailDT = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Return EmailDT
    End Function

    Protected Friend Function EmailAdd(ByVal Address As String, ByVal reportSchID As String, ByVal reportSchName As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlAdd As String = ""

        sqlAdd += " UPDATE dbo.ReportSchedule "
        sqlAdd += " SET EmailList = CASE "
        sqlAdd += " 					WHEN EmailList is null or EmailList = '' THEN '" + Address + "' "
        sqlAdd += " 					ELSE EmailList + ';' + '" + Address + "' "
        sqlAdd += " 				END "
        sqlAdd += " WHERE ReportSchID = '" + reportSchID + "' "
        sqlAdd += " AND ReportSchName = '" + reportSchName + "' "

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

    Protected Friend Function EmailAdjust(ByVal oddEmail As String, ByVal newEmail As String, ByVal reportSchID As String, ByVal reportSchName As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlAdjust As String = ""

        sqlAdjust += " UPDATE dbo.ReportSchedule "
        sqlAdjust += " SET EmailList = replace(EmailList, '" + oddEmail + "', '" + newEmail + "') "
        sqlAdjust += " WHERE ReportSchID = '" + reportSchID + "' "
        sqlAdjust += " AND ReportSchName = '" + reportSchName + "' "

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            GFncRunSQL(GSCnSqlConn, MyTrans, sqlAdjust, 0)

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

    Protected Friend Function EmailDel(ByVal Address As String, ByVal reportSchID As String, ByVal reportSchName As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = ""

        sqlDel += " UPDATE dbo.ReportSchedule "
        sqlDel += " SET EmailList =  "
        sqlDel += " replace "
        sqlDel += "         (replace "
        sqlDel += "                 (replace(EmailList, '" + Address + ";', '') "
        sqlDel += "         , ';" + Address + "', '') "
        sqlDel += " , '" + Address + "', '') "
        sqlDel += " WHERE ReportSchID = '" + reportSchID + "' "
        sqlDel += " AND ReportSchName = '" + reportSchName + "' "

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(13))
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
