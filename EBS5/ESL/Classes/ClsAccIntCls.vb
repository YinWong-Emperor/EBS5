Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class ClsAccIntCls

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncNoAcc() As ReportClass


        Dim ldtsTemp As DataSet
        Dim rpt As New RptAccIntClsNoAcc
        
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccIntCls_NoAcc", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        Else
            rpt = clsRpt.lfncRtnEmptyRpt("NUMBER OF SECURITIES ACCOUNT BY INTEREST CLASS (MARGIN & CASH)")
        End If


        Return rpt

    End Function

    Protected Friend Function lFncAccDetail() As ReportClass


        Dim ldtsTemp As DataSet
        Dim rpt As New RptAccIntClsAccDetail

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccIntCls_AccDtl", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("SECURITIES ACCOUNT BY INTEREST CLASS (MARGIN & CASH)")
        End If

    End Function

    Protected Friend Function lFncAccDetailEpt(ByVal strExFile As String) As Boolean

        Dim ldtsData As DataSet

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccIntCls_AccDtl", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)

        ldtsData = GFncRtnDS(sqlCmd)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE, Acc_Type, int_code, int_1, int_2, int_3 ")

    End Function

End Class
