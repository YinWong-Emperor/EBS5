Imports System.Data.SqlClient
Public Class ClsCCDRefMgmt

    Protected Friend Function lFnAddNewCCDRef(ByRef MyTrans As SqlTransaction, ByVal accountNo As String, ByVal accountType As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update dbo.client_master set ccd_ref = cm2.ccd_ref, RelatedAC_FTAD=convert(datetime, '01/01/1900', 103),RelatedAC_OTAD=convert(datetime, '01/01/1900', 103),RelatedAC_Remarks='' from ( select MAX(ISNULL(ccd_ref,0)) + 1 as ccd_ref from dbo.client_master) cm2 where acc_no = '" & accountNo & "' and client_type = '" & accountType & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    
    Protected Friend Function lFnUpdateCCDRefGivenInputAccNoAndAccType(ByRef MyTrans As SqlTransaction, _
                                                            ByVal updateAccNo As String,
                                                            ByVal updateAccType As String,
                                                            ByVal CCDRefAccNo As String,
                                                            ByVal CCDRefAccType As String) As Long

        Dim lstrSQL As String = ""
        lstrSQL = "update dbo.client_master set ccd_ref = cm2.ccd_ref,RelatedAC_FTAD=cm2.RelatedAC_FTAD,RelatedAC_OTAD=cm2.RelatedAC_OTAD,RelatedAC_Remarks=cm2.RelatedAC_Remarks from (select ccd_ref,RelatedAC_FTAD,RelatedAC_OTAD,RelatedAC_Remarks from dbo.client_master where acc_no = '" & CCDRefAccNo & "' and client_type ='" & CCDRefAccType & "') cm2 where acc_no = '" & updateAccNo & "' and client_type = '" & updateAccType & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnUpdateCCDRefGivenInputCCDRef(ByRef MyTrans As SqlTransaction, _
                                                            ByVal updateAccNo As String,
                                                            ByVal updateAccType As String,
                                                            ByVal inputCCDRef As String) As Long

        Dim lstrSQL As String = ""
        lstrSQL = "update dbo.client_master set ccd_ref = " & inputCCDRef & ",RelatedAC_FTAD=cm2.RelatedAC_FTAD,RelatedAC_OTAD=cm2.RelatedAC_OTAD,RelatedAC_Remarks=cm2.RelatedAC_Remarks from (select RelatedAC_FTAD,RelatedAC_OTAD,RelatedAC_Remarks from dbo.client_master where ccd_ref = " & inputCCDRef & " ) cm2 where acc_no = '" & updateAccNo & "' and client_type= '" & updateAccType & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnCheckAccountNoExistInG2B(ByVal accountNo As String, ByVal accountType As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "" & _
        " SELECT 1 " & _
        " FROM " & _
        " (   " & _
        " 	SELECT 	scm.accno AS acc_no,   " & _
        " 			CASE   " & _
        " 			  WHEN SUBSTRING (scm.accno, 1, 3) = '500' THEN 'CIES'   " & _
        " 			  ELSE 'Securities'   " & _
        " 			END AS client_type   " & _
        " 	FROM " & GStrG2BSDB & ".dbo.client_master scm   " & _
        " 	UNION ALL    " & _
        " 	SELECT fcm.accno AS acc_no,   " & _
        "           'Futures' AS client_type   " & _
        " 	FROM " & GStrG2BFDB & ".dbo.client_master fcm   " & _
        " ) sfm   " & _
        " WHERE acc_no = '" & accountNo & "' " & _
        "   AND client_type = '" & accountType & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lFnCheckAccountNoExist(ByVal accountNo As String, ByVal accountType As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select ccd_ref from dbo.client_master where acc_no = '" & accountNo & "' and client_type = '" & accountType & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lFnCheckCCDRefExist(ByVal ccdref As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select count(1) as ccdref_RC from dbo.client_master where ccd_ref = " & ccdref
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function getAccPrefixFilter(ByVal MyTrans As SqlTransaction, ByVal client_code As String) As String
        Dim lstrSQL As String = ""
        Dim dtTemp As New DataTable()
        Dim lstrFilterSql As String = ""

        dtTemp = getIsolatedPrefix(MyTrans)

        If dtTemp.Rows.Count > 0 Then
            For Each row As DataRow In dtTemp.Rows
                lstrFilterSql += " AND <Acc> Not Like '" + row.Item("IsolatedPrefix") + "%' "
            Next
        End If

        Return lstrFilterSql.Replace("<Acc>", client_code)
    End Function

    Protected Friend Function getIsolatedPrefix(ByVal MyTrans As SqlTransaction) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = " SELECT CharValue as IsolatedPrefix FROM SystemStaticParam WHERE ParamType = 'FatcaAcc_IsolatedPrefix' "

        Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
    End Function

    Protected Friend Function getLindedAccSuffixFromInitList(ByVal initAccList As DataTable, ByVal replaceStr As String) As String
        Dim lstrSql As String = ""

        For Each row As DataRow In initAccList.Rows
            If row("isLinkedAcc") = "Y" Then
                lstrSql += " OR <Acc> Like '%" + row.Item("acc_no").ToString().Substring(3, 5) + "' "
            End If
        Next

        Return lstrSql.Replace("<Acc>", replaceStr)
    End Function

    Protected Friend Function getLindedCCDFromInitCCDList(ByVal initCCDList As DataTable, ByVal replaceStr As String) As String
        Dim lstrSql As String = ""

        For Each row As DataRow In initCCDList.Rows
            lstrSql += " OR <Acc> = " + row.Item("ccd_ref").ToString() + " "
        Next

        Return lstrSql.Replace("<Acc>", replaceStr)
    End Function

    Protected Friend Function getIsolatedAccFromInitList(ByVal initAccList As DataTable, ByVal replaceStr As String) As String
        Dim lstrSql As String = ""

        For Each row As DataRow In initAccList.Rows
            If row("isLinkedAcc") = "N" Then
                lstrSql += " OR <Acc> = '" + row.Item("acc_no") + "' "
            End If
        Next

        Return lstrSql.Replace("<Acc>", replaceStr)
    End Function

    Protected Friend Function getLinkedAccFromFinalList(ByVal finalAccList As DataTable) As String
        Dim lstrSql As String = ""

        For Each row As DataRow In finalAccList.Rows
            lstrSql += " OR ( acc_no ='" + row.Item("acc_no") + "' AND client_type = '" & row.Item("client_type") & "' ) "
        Next

        Return lstrSql
    End Function

    Protected Friend Function getInitAccList(ByVal inputClientCode As String, ByVal selectedClientCode As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL += " SELECT acc_no, "
        lstrSQL += "        isLinkedAcc "
        lstrSQL += " FROM "
        lstrSQL += " ( "
        lstrSQL += " 	SELECT 	CASE "
        lstrSQL += "               	WHEN pf.prefix IS NULL AND LEN(AccList.acc_no) > 7  "
        lstrSQL += "               	THEN AccList.acc_no "
        lstrSQL += "               	ELSE AccList.acc_no "
        lstrSQL += "           	END AS acc_no, "
        lstrSQL += "           	CASE "
        lstrSQL += "               	WHEN pf.prefix IS NULL AND LEN(AccList.acc_no) > 7  "
        lstrSQL += "               	THEN 'Y' "
        lstrSQL += "               	ELSE 'N' "
        lstrSQL += "           	END AS isLinkedAcc "
        lstrSQL += " 	FROM "
        lstrSQL += "     ( "
        lstrSQL += "     	SELECT 	acc_no "
        lstrSQL += "       	FROM "
        lstrSQL += "         ( "
        lstrSQL += "         	SELECT '" & selectedClientCode & "' AS acc_no "
        If Not String.IsNullOrEmpty(inputClientCode) Then
            lstrSQL += "          	UNION ALL SELECT '" & inputClientCode & "' AS acc_no "
        End If
        lstrSQL += "         ) list "
        lstrSQL += "       	GROUP BY acc_no "
        lstrSQL += "     ) AccList "
        lstrSQL += "    	LEFT JOIN "
        lstrSQL += "     ( "
        lstrSQL += "     	SELECT CharValue AS PREFIX "
        lstrSQL += "       	FROM SystemStaticParam "
        lstrSQL += "       	WHERE paramtype = 'FatcaAcc_IsolatedPrefix' "
        lstrSQL += "     ) pf ON AccList.acc_no LIKE pf.PREFIX +'%' "
        lstrSQL += " ) initList "
        lstrSQL += " GROUP BY acc_no, "
        lstrSQL += "          isLinkedAcc "

        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If

    End Function

    Protected Friend Function getInitCCDList(ByVal inputCCDRef As String, ByVal initAccList As DataTable, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL += " SELECT ccd_ref "
        lstrSQL += " FROM client_master cm "
        lstrSQL += " WHERE  "
        lstrSQL += " ( "
        lstrSQL += " 	1=0 " & getLindedAccSuffixFromInitList(initAccList, "RTRIM(cm.acc_no)") & " "
        If Not String.IsNullOrEmpty(inputCCDRef) Then
            lstrSQL += " 	OR ccd_ref = " & inputCCDRef & " "
        End If
        lstrSQL += " ) "
        lstrSQL += " AND ccd_ref IS NOT NULL "
        lstrSQL += " GROUP BY ccd_ref "

        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If
    End Function

    Protected Friend Function getAllLinkedAccList(ByVal initAccList As DataTable, ByVal initCCDList As DataTable, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String = ""
        lstrSQL += " SELECT acc_no, client_type, ccd_ref, isLinkedAcc, isExist "
        lstrSQL += " FROM "
        lstrSQL += " ( "
        lstrSQL += "         SELECT 	sfm.acc_no,    "
        lstrSQL += "                	sfm.client_type,  "
        lstrSQL += "                	ccd.ccd_ref,  "
        lstrSQL += "         		CASE   "
        lstrSQL += "         			WHEN pf.prefix IS NULL THEN 'Y'  "
        lstrSQL += "         			ELSE 'N'  "
        lstrSQL += "         		END AS isLinkedAcc,  "
        lstrSQL += "         		CASE  "
        lstrSQL += "         			WHEN ccd.acc_no IS NULL THEN 'N'  "
        lstrSQL += "         			ELSE 'Y'  "
        lstrSQL += "         		END AS isExist  "
        lstrSQL += "         FROM    "
        lstrSQL += "         (    "
        lstrSQL += "         	SELECT 	scm.accno AS acc_no,    "
        lstrSQL += "         			CASE    "
        lstrSQL += "         			  WHEN SUBSTRING (scm.accno, 1, 3) = '500' THEN 'CIES'    "
        lstrSQL += "         			  ELSE 'Securities'    "
        lstrSQL += "         			END AS client_type    "
        lstrSQL += "         	FROM " & GStrG2BSDB & ".dbo.client_master scm    "
        lstrSQL += "         	UNION ALL     "
        lstrSQL += "         	SELECT fcm.accno AS acc_no,    "
        lstrSQL += "                   'Futures' AS client_type    "
        lstrSQL += "         	FROM " & GStrG2BFDB & ".dbo.client_master fcm    "
        lstrSQL += "         ) sfm    "
        lstrSQL += "         LEFT JOIN  "
        lstrSQL += "         (  "
        lstrSQL += "         	SELECT acc_no,  "
        lstrSQL += "         	       client_type,  "
        lstrSQL += "         	       ccd_ref  "
        lstrSQL += "         	FROM client_master  "
        lstrSQL += "         ) ccd  "
        lstrSQL += "         ON sfm.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS = ccd.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS  "
        lstrSQL += "         AND sfm.client_type = ccd.client_type  "
        lstrSQL += "         LEFT JOIN  "
        lstrSQL += "         (   "
        lstrSQL += "         	SELECT CharValue AS PREFIX  "
        lstrSQL += "            	FROM SystemStaticParam  "
        lstrSQL += "            	WHERE paramtype = 'FatcaAcc_IsolatedPrefix'  "
        lstrSQL += "         ) pf   "
        lstrSQL += "         ON sfm.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS LIKE pf.PREFIX +'%' COLLATE Chinese_Taiwan_Stroke_CI_AS  "
        lstrSQL += "         WHERE   "
        lstrSQL += "         (  "
        lstrSQL += "                 (  "
        lstrSQL += "                 	1=0 " & getLindedAccSuffixFromInitList(initAccList, "RTRIM(sfm.acc_no)") & "  "
        lstrSQL += "                 )   "
        lstrSQL += "                 AND  "
        lstrSQL += "                 (  "
        lstrSQL += "                 	1=1 " & getAccPrefixFilter(MyTrans, "RTRIM(sfm.acc_no)") & "  "
        lstrSQL += "                 )  "
        lstrSQL += "         )  "
        lstrSQL += "         or  "
        lstrSQL += "         (  "
        lstrSQL += "                 1=0  " & getLindedCCDFromInitCCDList(initCCDList, "ccd.ccd_ref") & " "
        lstrSQL += "         )  "
        lstrSQL += "         UNION ALL  "
        lstrSQL += "         SELECT 	sfm.acc_no,    "
        lstrSQL += "                	sfm.client_type,  "
        lstrSQL += "                	ccd.ccd_ref,  "
        lstrSQL += "         		'N' AS isLinkedAcc,  "
        lstrSQL += "         		CASE  "
        lstrSQL += "         			WHEN ccd.acc_no IS NULL THEN 'N'  "
        lstrSQL += "         			ELSE 'Y'  "
        lstrSQL += "         		END AS isExist  "
        lstrSQL += "         FROM    "
        lstrSQL += "         (    "
        lstrSQL += "         	SELECT 	scm.accno AS acc_no,    "
        lstrSQL += "         			CASE    "
        lstrSQL += "         			  WHEN SUBSTRING (scm.accno, 1, 3) = '500' THEN 'CIES'    "
        lstrSQL += "         			  ELSE 'Securities'    "
        lstrSQL += "         			END AS client_type    "
        lstrSQL += "         	FROM " & GStrG2BSDB & ".dbo.client_master scm    "
        lstrSQL += "         	UNION ALL     "
        lstrSQL += "         	SELECT fcm.accno AS acc_no,    "
        lstrSQL += "                   'Futures' AS client_type    "
        lstrSQL += "         	FROM " & GStrG2BFDB & ".dbo.client_master fcm    "
        lstrSQL += "         ) sfm    "
        lstrSQL += "         LEFT JOIN  "
        lstrSQL += "         (  "
        lstrSQL += "         	SELECT acc_no,  "
        lstrSQL += "         	       client_type,  "
        lstrSQL += "         	       ccd_ref  "
        lstrSQL += "         	FROM client_master  "
        lstrSQL += "         ) ccd  "
        lstrSQL += "         ON sfm.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS = ccd.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS  "
        lstrSQL += "         AND sfm.client_type = ccd.client_type  "
        lstrSQL += "         WHERE   "
        lstrSQL += "         (  "
        lstrSQL += "         	1=0 " & getIsolatedAccFromInitList(initAccList, "RTRIM(sfm.acc_no)") & "  "
        lstrSQL += "         )   "
        lstrSQL += " ) allList "
        lstrSQL += " GROUP BY acc_no, client_type, ccd_ref, isLinkedAcc, isExist "

        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If
    End Function

    Protected Friend Function lFnInsertFromExisting(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal clientType As String, ByVal existingClientCode As String, ByVal existingClientType As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "" & _
        " INSERT INTO client_master  " & _
        " ( " & _
        " 	RelatedAC_FTAD, " & _
        " 	RelatedAC_OTAD, " & _
        " 	RelatedAC_Remarks, " & _
        " 	acc_no, " & _
        " 	client_type " & _
        " ) " & _
        " SELECT  " & _
        " 	RelatedAC_FTAD, " & _
        " 	RelatedAC_OTAD, " & _
        " 	RelatedAC_Remarks, " & _
        " 	'" & client_code & "', " & _
        " 	'" & clientType & "' " & _
        " FROM client_master " & _
        " WHERE acc_no = '" & existingClientCode & "' " & _
        "   AND client_type = '" & existingClientType & "' "
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnInsertClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal clientType As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = " INSERT INTO client_master  " & _
        " ( " & _
        " 	RelatedAC_FTAD, " & _
        " 	RelatedAC_OTAD, " & _
        " 	RelatedAC_Remarks, " & _
        " 	acc_no, " & _
        " 	client_type " & _
        " ) " & _
        " VALUES " & _
        " ( " & _
        " 	'1900-01-01', " & _
        " 	'1900-01-01', " & _
        " 	'', " & _
        " 	'" & client_code & "', " & _
        " 	'" & clientType & "' " & _
        " ) "
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnEditLinkedAcc(ByRef MyTrans As SqlTransaction, ByVal finalAccList As DataTable, ByVal client_code As String, ByVal clientType As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL += " DECLARE @CCD_Ref AS int   "
        lstrSQL += " DECLARE @FTAD_Date DATETIME "
        lstrSQL += " DECLARE @OTAD_Date DATETIME "
        lstrSQL += " DECLARE @Remarks nvarchar(30) "
        lstrSQL += " SELECT @CCD_Ref =    "
        lstrSQL += " (   "
        lstrSQL += " 	SELECT min(ccd_ref) from client_master   "
        lstrSQL += " 	WHERE 1=0 " & getLinkedAccFromFinalList(finalAccList) & "   "
        lstrSQL += " ) "
        lstrSQL += " SELECT  @FTAD_Date = RelatedAC_FTAD,  "
        lstrSQL += "         @OTAD_Date = RelatedAC_OTAD, "
        lstrSQL += "         @Remarks = RelatedAC_Remarks "
        lstrSQL += " FROM    dbo.client_master  "
        lstrSQL += " WHERE   acc_no = '" & client_code & "' "
        lstrSQL += " AND     client_type = '" & clientType & "'  "
        lstrSQL += " UPDATE dbo.client_master "
        lstrSQL += " SET ccd_ref =       "
        lstrSQL += " (    "
        lstrSQL += "        CASE  "
        lstrSQL += "                WHEN @CCD_Ref IS NULL   "
        lstrSQL += "                THEN  "
        lstrSQL += "                (  "
        lstrSQL += "                        SELECT ISNULL(MAX(ccd_ref),0) + 1 FROM client_master  "
        lstrSQL += "                )   "
        lstrSQL += "                ELSE @CCD_Ref  "
        lstrSQL += "        END  "
        lstrSQL += " ), "
        lstrSQL += " RelatedAC_FTAD = ISNULL(@FTAD_Date,'01-Jan-1900'), "
        lstrSQL += " RelatedAC_OTAD = ISNULL(@OTAD_Date,'01-Jan-1900'), "
        lstrSQL += " RelatedAC_Remarks = ISNULL(@Remarks,'') "
        lstrSQL += " WHERE 1=0 " & getLinkedAccFromFinalList(finalAccList) & "  "

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
End Class
