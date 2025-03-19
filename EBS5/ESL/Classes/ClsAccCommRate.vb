Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsAccCommRate

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncNoAcc() As ReportClass


        Dim ldtsTemp As DataSet
        Dim rpt As New RptAccCommRateNoAcc

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccCommRate_NoAcc", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("NUMBER OF SECURITIES ACCOUNTS BY COMMISSION RATE (MARGIN & CASH)")
        End If

    End Function

    Protected Friend Function lFncAccDetails() As ReportClass


        Dim ldtsTemp As DataSet
        Dim rpt As New RptAccCommRateAccDetail

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccCommRate_AccDtl", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("SECURITIES ACCOUNT BY COMMISION RATE (MARGIN & CASH)")
        End If

    End Function

End Class
