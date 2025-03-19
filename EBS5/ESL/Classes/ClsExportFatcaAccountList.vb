Imports System.IO

Public Class ClsExportFatcaAccountList

    Protected Friend Function lFncFatcaAccountList(ByVal lstrSQL As String) As Boolean


        Dim ldtsTemp As DataSet
        Dim strExFile As String = "fatca_acc_list.csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then

            Dim lstr As String = String.Empty
            Dim strTmpSQL As String

            strTmpSQL = "SELECT * INTO #tmp_client_master_2 FROM tmp_client_master_2 WHERE 1 <> 1"
            GFncRunSQL(GSCnSqlConn, strTmpSQL, 0)

            strTmpSQL = "INSERT INTO #tmp_client_master_2 EXEC [s_client_master_2] '" & GStrG2BSPRODDB & "', '" & GStrG2BFPRODDB & "';"
            GFncRunSQL(GSCnSqlConn, strTmpSQL, 0)

            lstr += " SELECT accno,"
            lstr += "       name_1,"
            lstr += "       nature_s,"
            lstr += "       aeno,"
            lstr += "       br_id,"
            lstr += "       client_type,"
            lstr += "       FATCA_acc_type,"
            lstr += "       w8_form_signed,"
            lstr += "       CASE"
            lstr += "           WHEN CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_date,''), 103) ='01/01/1900' THEN ''"
            lstr += "           ELSE CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_date,''), 103)"
            lstr += "       END AS w8_form_date,"
            lstr += "       CASE"
            lstr += "           WHEN CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_expiry_date,''), 103) ='01/01/1900' THEN ''"
            lstr += "           ELSE CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_expiry_date,''), 103)"
            lstr += "       END AS w8_form_expiry_date,"
            lstr += "       us_citizen,"
            lstr += "       us_born,"
            lstr += "       us_address,"
            lstr += "       us_phone,"
            lstr += "       us_fund_transfer,"
            lstr += "       us_auth_person,"
            lstr += "       us_passport_holder,"
            lstr += "       us_tin,"
            lstr += "       us_review_date,"
            lstr += "       FATCA_Remarks,"
            lstr += "       FATCA_GIIN,"
            lstr += "       date_open,"
            lstr += "       CASE"
            lstr += "           WHEN suspend_field='Yes' THEN 'Y'"
            lstr += "           ELSE 'N'"
            lstr += "       END AS suspend_field,"
            lstr += "       suspend_code,"
            lstr += "       sus_date"
            lstr += "  FROM dbo.#tmp_client_master_2 vwcm"
            lstr += " WHERE 1=1 "
            lstr += lstrSQL
            lstr += " ORDER BY accno ASC"

            ldtsTemp = GFncRtnDS(GSCnSqlConn, lstr, 0)

            strTmpSQL = "DROP TABLE #tmp_client_master_2"
            GFncRunSQL(GSCnSqlConn, strTmpSQL, 0)

            If (ldtsTemp.Tables(0).Rows.Count > 0) Then
                ExportCSV(GStrExptDir, strExFile, ldtsTemp, " accno, name_1, nature_s, aeno, br_id, Account Type, FATCA acc_type, W form signed?, W form Signing Date, W form Expiry Date, US Citizen / Resident?, US born?, US address?,  US tel. no.?, Fund Transfer from/to US?, Auth. person with US address?, US 'in-care-of' or 'hold mail' address?, US EIN/SSN, Last Review Date,FATCA_Remarks, FATCA_GIIN, date_open, suspend_field, suspend_code, date_suspend ")
                GSubShowInfo(GFncGetSysMsg(28))
                Return True
            End If

            GSubShowInfo(GFncGetSysMsg(2))
        End If

        Return False

    End Function
    Public Function ExportCSV(ByVal strExptDir As String, ByVal strExptFilename As String, _
                                ByVal ldtsData As DataSet, ByVal strHeader As String) As Boolean

        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtcData As DataColumn
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        Try
            lstrFiles = System.IO.Directory.GetFiles(strExptDir, strExptFilename)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            lsWriter = New StreamWriter(strExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))
            lstrColValue = strHeader
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()

            For Each ldtwData In ldtsData.Tables(0).Rows
                lstrColValue = ""
                For Each ldtcData In ldtsData.Tables(0).Columns
                    If (lstrColValue.Length > 0) Then
                        lstrColValue += ","
                    End If

                    If (ldtcData.DataType.Name = "String") Then
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += "=""" & Trim(Replace(Replace(Replace(Replace(ldtwData(ldtcData.ColumnName), ",", ";"), _
                                            Chr(10), ""), Chr(12), ""), Chr(13), "")) & """"
                        End If
                    Else
                        If (IsDBNull(ldtwData(ldtcData.ColumnName))) Then
                            lstrColValue += "="""""
                        Else
                            lstrColValue += Trim(CStr(ldtwData(ldtcData.ColumnName)))
                        End If
                    End If
                Next
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()

            Next
            lstrColValue = ""
            lsWriter.WriteLine(lstrColValue)


            lstrColValue = "=""" & Trim(Replace(Replace(Replace(Replace("Total", ",", ";"), _
                                            Chr(10), ""), Chr(12), ""), Chr(13), "")) & """"
            lstrColValue += ","
            lstrColValue += "="" " & ldtsData.Tables(0).Rows.Count & " accounts"""
            lsWriter.WriteLine(lstrColValue)

            lsWriter.Close()

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try

    End Function
End Class
