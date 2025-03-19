Imports System.IO
Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem

Public Class clsRptExternalAC

    Protected Friend Function GenReport() As DataTable
        Dim lcResult As DataTable = New dtsRptExternalAC.dtsRptExternalACDataTable
        Dim lcDr As DataRow
        Dim lcStrSQL As String = "SELECT distinct a.accno, a.name_1, a.aeno, b.name as ae_name, a.external_accno, a.external_credit_lmt " & _
                            " FROM " & GStrG2BSDB & _
                            ".dbo.view_it_client_all a LEFT OUTER JOIN " & GStrG2BSDB & ".dbo.ae_master b ON a.aeno=b.aeno WHERE 1=1 " & _
                            "AND rtrim(isnull(a.external_accno, '')) <> '' "

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        For i As Integer = 0 To dt.Rows.Count - 1
            lcDr = lcResult.NewRow()
            lcDr("d_acc_no") = GFncNoNullString(dt.Rows(i).Item("accno"))
            lcDr("d_acc_name") = GFncNoNullString(dt.Rows(i).Item("name_1"))
            lcDr("d_ae_no") = GFncNoNullString(dt.Rows(i).Item("aeno"))
            lcDr("d_ae_name") = GFncNoNullString(dt.Rows(i).Item("ae_name"))
            lcDr("d_ext_acc_no") = GFncNoNullString(dt.Rows(i).Item("external_accno"))
            lcDr("d_ext_credit_limit") = GFncNoNullValue(dt.Rows(i).Item("external_credit_lmt"))
            lcResult.Rows.Add(lcDr)
        Next

        Return lcResult
    End Function

    Protected Friend Function ExportToExcel(ByVal pSrc As DataTable, ByVal pFilePath As String) As Boolean
        Dim lcPath As String = pFilePath.Substring(0, pFilePath.LastIndexOf("\") + 1)
        Dim lcFileName As String = pFilePath.Substring(pFilePath.LastIndexOf("\") + 1)
        Dim lcHeader As String = "Client A/C No, Client Name, A/E No, A/E Name, External A/C No, External Credit Limit(HKD) "

        Return GExportToExcel(lcPath, lcFileName, pSrc, lcHeader)
    End Function

End Class
