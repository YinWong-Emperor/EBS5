Imports System.Data.SqlClient
Public Class ClsFatcaIJAccProfile

    Protected Friend Function lFnAddClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal strClient_Type As String, ByVal strFATCA_Account_Type As String, ByVal strUS_in_care_of_or_hold_mail_address As String, ByVal strUS_Citizen As String, ByVal strBorn_in_US As String, ByVal strUS_Address As String, ByVal strUS_Telephone_No As String, ByVal strFund_Transfer_US As String, ByVal strAuthorized_person_with_US_address As String, ByVal strW_form_signed As String, ByVal dtDate_of_Signings As DateTime, ByVal dtExpiry_date_w_form As DateTime, ByVal strTIN As String, ByVal dtLast_Review_Date As DateTime, ByVal strFATCA_Remarks As String, ByVal strFATCA_GIIN As String) As Long
        Dim lstrSQL As String = ""
        
        lstrSQL = "DECLARE @PersonID AS int " & _
        "SELECT @PersonID =  (SELECT ISNULL(max(PersonID), 0) + 1 FROM client_master) " & _
        "INSERT INTO client_master( " & _
        "	acc_no, " & _
        "	client_type, " & _
        "	FATCA_acc_type, " & _
        "	us_passport_holder, " & _
        "	us_citizen, " & _
        "	us_born, " & _
        "	us_address, " & _
        "	us_phone, " & _
        "	us_fund_transfer, " & _
        "	us_auth_person, " & _
        "	w8_form_signed, " & _
        "	w8_form_date, " & _
        "	w8_form_expiry_date, " & _
        "	us_tin, " & _
        "	us_review_date, " & _
        "	FATCA_Remarks, " & _
        "	FATCA_GIIN, " & _
        "	PersonID " & _
        ") " & _
        "VALUES('" & client_code & "', " & _
        "       '" & strClient_Type & "', " & _
        "       '" & strFATCA_Account_Type & "', " & _
        "       '" & strUS_in_care_of_or_hold_mail_address & "', " & _
        "       '" & strUS_Citizen & "', " & _
        "       '" & strBorn_in_US & "', " & _
        "       '" & strUS_Address & "', " & _
        "       '" & strUS_Telephone_No & "', " & _
        "       '" & strFund_Transfer_US & "', " & _
        "       '" & strAuthorized_person_with_US_address & "', " & _
        "       '" & strW_form_signed & "', " & _
        "       '" & Format(dtDate_of_Signings, "yyyy/MM/dd") & "', " & _
        "       '" & Format(dtExpiry_date_w_form, "yyyy/MM/dd") & "', " & _
        "       '" & strTIN & "', " & _
        "       '" & Format(dtLast_Review_Date, "yyyy/MM/dd") & "', " & _
        "       '" & strFATCA_Remarks & "', " & _
        "       '" & strFATCA_GIIN & "', " & _
        "       @PersonID) "
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnEditLinkedAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal strClient_Type As String, _
                                               ByVal strFATCA_Account_Type As String, ByVal strUS_in_care_of_or_hold_mail_address As String, _
                                               ByVal strUS_Citizen As String, ByVal strBorn_in_US As String, ByVal strUS_Address As String, _
                                               ByVal strUS_Telephone_No As String, ByVal strFund_Transfer_US As String, ByVal strAuthorized_person_with_US_address As String, _
                                               ByVal strW_form_signed As String, ByVal dtDate_of_Signings As DateTime, ByVal dtExpiry_date_w_form As DateTime, _
                                               ByVal strTIN As String, ByVal dtLast_Review_Date As DateTime, ByVal strFATCA_Remarks As String, _
                                               ByVal strFATCA_GIIN As String, ByVal personID As String, _
                                               ByVal strAccPrefixFilter As String) As Long
        Dim lstrSQL As String =
        "DECLARE @PersonID AS int  " & _
        "DECLARE @AccNo AS VARCHAR(10)  " & _
        "SET @AccNo = '" & client_code & "' " & _
        "SELECT @PersonID =  " & _
        "( " & _
        "	select min(PersonID) from client_master   " & _
        "	where RTRIM(acc_no) LIKE  " & _
        "		CASE " & _
        "			WHEN LEN(@AccNo) > 7  " & _
        "			THEN '%' + SUBSTRING(@AccNo, 4, 5) " & _
        "			ELSE @AccNo " & _
        "		END " & _
        "	AND  " & _
        "	( " & _
        "		1=1 " & strAccPrefixFilter & " " & _
        "	)  " & _
        ") " & _
        "UPDATE client_master   " & _
        "SET FATCA_acc_type = '" & strFATCA_Account_Type & "' ,  " & _
        "us_passport_holder = '" & strUS_in_care_of_or_hold_mail_address & "' ,  " & _
        "us_citizen = '" & strUS_Citizen & "' ,  " & _
        "us_born = '" & strBorn_in_US & "',  " & _
        "us_address = '" & strUS_Address & "' ,  " & _
        "us_phone = '" & strUS_Telephone_No & "',  " & _
        "us_fund_transfer= '" & strFund_Transfer_US & "',  " & _
        "us_auth_person= '" & strAuthorized_person_with_US_address & "',  " & _
        "w8_form_signed= '" & strW_form_signed & "',  " & _
        "w8_form_date= '" & Format(dtDate_of_Signings, "yyyy/MM/dd") & "',  " & _
        "w8_form_expiry_date='" & Format(dtExpiry_date_w_form, "yyyy/MM/dd") & "',  " & _
        "us_tin = '" & strTIN & "',  " & _
        "us_review_date='" & Format(dtLast_Review_Date, "yyyy/MM/dd") & "',  " & _
        "FATCA_Remarks = '" & strFATCA_Remarks & "',  " & _
        "FATCA_GIIN = '" & strFATCA_GIIN & "',  " & _
        "PersonID = 	  " & _
        "(	 " & _
        "        CASE  " & _
        "                WHEN @PersonID is null  " & _
        "                THEN 	(  " & _
        "                               SELECT max(PersonID) + 1 AS PersonID  " & _
        "                               FROM client_master  " & _
        "                        )  " & _
        "                ELSE @PersonID  " & _
        "        END  " & _
        ")  " & _
        "WHERE  " & _
        "( " & _
        "	RTRIM(acc_no) LIKE  " & _
        "	CASE " & _
        "			WHEN LEN(@AccNo) > 7  " & _
        "			THEN '%' + SUBSTRING(@AccNo, 4, 5) " & _
        "			ELSE @AccNo " & _
        "	END " & _
        "	AND  " & _
        "	( " & _
        "			1=1 " & strAccPrefixFilter & " " & _
        "	)  " & _
        ") " &
        If(String.IsNullOrEmpty(personID), "", " or PersonID = '" & personID & "' ")
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnEditIsolatedAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal strClient_Type As String, ByVal strFATCA_Account_Type As String, ByVal strUS_in_care_of_or_hold_mail_address As String, ByVal strUS_Citizen As String, ByVal strBorn_in_US As String, ByVal strUS_Address As String, ByVal strUS_Telephone_No As String, ByVal strFund_Transfer_US As String, ByVal strAuthorized_person_with_US_address As String, ByVal strW_form_signed As String, ByVal dtDate_of_Signings As DateTime, ByVal dtExpiry_date_w_form As DateTime, ByVal strTIN As String, ByVal dtLast_Review_Date As DateTime, ByVal strFATCA_Remarks As String, ByVal strFATCA_GIIN As String, ByVal personID As String) As Long
        Dim lstrSQL As String =
        "DECLARE @PersonID AS int  " & _
        "DECLARE @AccNo AS VARCHAR(10)  " & _
        "DECLARE @ClientType AS VARCHAR(20) " & _
        "SET @AccNo = '" & client_code & "' " & _
        "SET @ClientType = '" & strClient_Type & "'  " & _
        "SELECT @PersonID =  " & _
        "( " & _
        "	SELECT min(PersonID) from client_master   " & _
        "	WHERE RTRIM(acc_no) = @AccNo " & _
        "	AND	client_type = @ClientType " & _
        ") " & _
        "UPDATE client_master   " & _
        "SET FATCA_acc_type = '" & strFATCA_Account_Type & "' ,  " & _
        "us_passport_holder = '" & strUS_in_care_of_or_hold_mail_address & "' ,  " & _
        "us_citizen = '" & strUS_Citizen & "' ,  " & _
        "us_born = '" & strBorn_in_US & "',  " & _
        "us_address = '" & strUS_Address & "' ,  " & _
        "us_phone = '" & strUS_Telephone_No & "',  " & _
        "us_fund_transfer= '" & strFund_Transfer_US & "',  " & _
        "us_auth_person= '" & strAuthorized_person_with_US_address & "',  " & _
        "w8_form_signed= '" & strW_form_signed & "',  " & _
        "w8_form_date= '" & Format(dtDate_of_Signings, "yyyy/MM/dd") & "',  " & _
        "w8_form_expiry_date='" & Format(dtExpiry_date_w_form, "yyyy/MM/dd") & "',  " & _
        "us_tin = '" & strTIN & "',  " & _
        "us_review_date='" & Format(dtLast_Review_Date, "yyyy/MM/dd") & "',  " & _
        "FATCA_Remarks = '" & strFATCA_Remarks & "',  " & _
        "FATCA_GIIN = '" & strFATCA_GIIN & "',  " & _
        "PersonID = 	  " & _
        "(	 " & _
        "        CASE  " & _
        "                WHEN @PersonID is null  " & _
        "                THEN 	(  " & _
        "                               SELECT max(PersonID) + 1 AS PersonID  " & _
        "                               FROM client_master  " & _
        "                        )  " & _
        "                ELSE @PersonID  " & _
        "        END  " & _
        ")  " & _
        "WHERE (RTRIM(acc_no) = @AccNo " & _
        "AND	client_type = @ClientType) " &
        If(String.IsNullOrEmpty(personID), "", " or PersonID = '" & personID & "' ")
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnWriteLog(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal Action As String, ByVal Log As String)
        Dim lstrSQL As String
        lstrSQL = " Insert into LogTbl (D_User, D_Date, D_Action, D_Type, D_AE, D_AC, D_O_TDate, D_OID, D_Txmonth, D_Log) values " & _
            "( '" & GStrloginID & "', GETDATE(), '" & Action & "', 'FatcaIJAccProfile', '', '" & client_code & "', getdate(), '', '', '" & GFncSqlQuote(Log) & "' )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnGetAccMasterRecordByAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal client_type As String) As DataSet
        Dim ds As New DataSet
        'Dim lstr As String = "select accno AS Account_No, name_1 AS Account_Name, ISNULL(vwcm.FATCA_acc_type, '') AS FATCA_Account_Type , ISNULL(vwcm.us_passport_holder,'') AS US_in_care_of_or_hold_mail_address, ISNULL(vwcm.us_citizen,'') AS US_Citizen, ISNULL(vwcm.us_born,'') AS Born_in_US, ISNULL(vwcm.us_address,'') AS US_Address, ISNULL(vwcm.us_phone,'') AS US_Telephone_No, ISNULL(vwcm.us_fund_transfer,'') AS Fund_Transfer_US, ISNULL(vwcm.us_auth_person,'') AS Authorized_person_with_US_address, ISNULL(vwcm.w8_form_signed, '') AS W_form_signed, CASE WHEN CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_date,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_date,''), 103) END AS Date_of_Signings, ISNULL(vwcm.us_tin,'') AS TIN, CASE WHEN  CONVERT(VARCHAR(30), ISNULL(vwcm.us_review_date,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(vwcm.us_review_date,''), 103) END AS Last_Review_Date, FATCA_Remarks from Vw_client_master_2 vwcm where accno = '" & client_code & "' and client_type= '" & client_type & "'"
        Dim lstr As String = " " & _
        "SELECT " & _
        "clm.accno, " & _
        "clm.name_1, " & _
        "clm.nature_s, " & _
        "clm.client_type, " & _
        "cm.FATCA_Account_Type, " & _
        "cm.FATCA_GIIN, " & _
        "cm.US_in_care_of_or_hold_mail_address, " & _
        "cm.US_Citizen, " & _
        "cm.Born_in_US, " & _
        "cm.US_Address, " & _
        "cm.US_Telephone_No, " & _
        "cm.Fund_Transfer_US, " & _
        "cm.Authorized_person_with_US_address, " & _
        "cm.W_form_signed, " & _
        "cm.Date_of_Signings, " & _
        "cm.TIN, " & _
        "cm.Last_Review_Date, " & _
        "cm.FATCA_Remarks " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "clm.accno, " & _
                "clm.name_1, " & _
                "CASE clm.nature " & _
                    "WHEN '0' THEN 'Individual' WHEN '1' THEN 'Joint' " & _
                    "ELSE 'Corporation' " & _
                "END AS nature_s, " & _
                "CASE " & _
                    "WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' " & _
                    "ELSE 'Securities' " & _
                "END AS client_type " & _
                "FROM " & _
                    "" & GStrG2BSDB & ".dbo.client_master clm " & _
                "WHERE clm.accno = '" & client_code & "' and CASE WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' ELSE 'Securities' END = '" & client_type & "'" & _
        ") clm " & _
        "LEFT OUTER JOIN " & _
        "( " & _
            "SELECT " & _
                "localcm.acc_no, " & _
                "localcm.client_type, " & _
                "ISNULL(localcm.FATCA_acc_type, '') AS FATCA_Account_Type, " & _
                "ISNULL(localcm.FATCA_GIIN, '') As FATCA_GIIN, " & _
                "ISNULL(localcm.us_passport_holder,'') AS US_in_care_of_or_hold_mail_address, " & _
                "ISNULL(localcm.us_citizen,'') AS US_Citizen, " & _
                "ISNULL(localcm.us_born,'') AS Born_in_US, " & _
                "ISNULL(localcm.us_address,'') AS US_Address, " & _
                "ISNULL(localcm.us_phone,'') AS US_Telephone_No, " & _
                "ISNULL(localcm.us_fund_transfer,'') AS Fund_Transfer_US, " & _
                "ISNULL(localcm.us_auth_person,'') AS Authorized_person_with_US_address, " & _
                "ISNULL(localcm.w8_form_signed, '') AS W_form_signed, " & _
                "CASE " & _
                "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) ='01/01/1900' " & _
                "THEN '' " & _
                "ELSE CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) " & _
                "END AS Date_of_Signings, " & _
                "ISNULL(localcm.us_tin,'') AS TIN, " & _
                "CASE " & _
                "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.us_review_date,''), 103) ='01/01/1900' " & _
                "THEN '' " & _
                "ELSE CONVERT(VARCHAR(30),ISNULL(localcm.us_review_date,''), 103) " & _
                "END AS Last_Review_Date, " & _
                "FATCA_Remarks " & _
                "FROM client_master localcm " & _
                "WHERE localcm.acc_no = '" & client_code & "' and localcm.client_type = '" & client_type & "'" & _
        ") cm ON cm.acc_no=clm.accno COLLATE DATABASE_DEFAULT AND cm.client_type = clm.client_type " & _
        "UNION " & _
        "SELECT " & _
        "clm.accno, " & _
        "clm.name_1, " & _
        "clm.nature_s, " & _
        "clm.client_type, " & _
        "cm.FATCA_Account_Type, " & _
        "cm.FATCA_GIIN, " & _
        "cm.US_in_care_of_or_hold_mail_address, " & _
        "cm.US_Citizen, " & _
        "cm.Born_in_US, " & _
        "cm.US_Address, " & _
        "cm.US_Telephone_No, " & _
        "cm.Fund_Transfer_US, " & _
        "cm.Authorized_person_with_US_address, " & _
        "cm.W_form_signed, " & _
        "cm.Date_of_Signings, " & _
        "cm.TIN, " & _
        "cm.Last_Review_Date, " & _
        "cm.FATCA_Remarks " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
            "clm.accno, " & _
            "clm.name_1, " & _
            "CASE clm.nature " & _
                "WHEN '0' THEN 'Individual' WHEN '1' THEN 'Joint' " & _
                "ELSE 'Corporation' " & _
            "END AS nature_s, " & _
            "CASE " & _
                "WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' " & _
                "ELSE 'Futures' " & _
            "END AS client_type " & _
            "FROM " & _
            "" & GStrG2BFDB & ".dbo.client_master clm " & _
            "WHERE accno = '" & client_code & "' and CASE WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' ELSE 'Futures' END = '" & client_type & "' " & _
        ") clm " & _
        "LEFT OUTER JOIN " & _
        "( " & _
            "SELECT " & _
                "localcm.acc_no, " & _
                "localcm.client_type, " & _
                "ISNULL(localcm.FATCA_acc_type, '') AS FATCA_Account_Type, " & _
                "ISNULL(localcm.FATCA_GIIN, '') As FATCA_GIIN, " & _
                "ISNULL(localcm.us_passport_holder,'') AS US_in_care_of_or_hold_mail_address, " & _
                "ISNULL(localcm.us_citizen,'') AS US_Citizen, " & _
                "ISNULL(localcm.us_born,'') AS Born_in_US, " & _
                "ISNULL(localcm.us_address,'') AS US_Address, " & _
                "ISNULL(localcm.us_phone,'') AS US_Telephone_No, " & _
                "ISNULL(localcm.us_fund_transfer,'') AS Fund_Transfer_US, " & _
                "ISNULL(localcm.us_auth_person,'') AS Authorized_person_with_US_address, " & _
                "ISNULL(localcm.w8_form_signed, '') AS W_form_signed, " & _
                "CASE " & _
                    "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) ='01/01/1900' " & _
                    "THEN '' " & _
                    "ELSE CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) " & _
                "END AS Date_of_Signings, " & _
                "ISNULL(localcm.us_tin,'') AS TIN, " & _
                "CASE " & _
                    "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.us_review_date,''), 103) ='01/01/1900' " & _
                    "THEN '' " & _
                    "ELSE CONVERT(VARCHAR(30),ISNULL(localcm.us_review_date,''), 103) " & _
                "END AS Last_Review_Date, " & _
                "FATCA_Remarks " & _
            "FROM client_master localcm " & _
            "WHERE localcm.acc_no = '" & client_code & "' and localcm.client_type = '" & client_type & "'" & _
        ") cm ON cm.acc_no=clm.accno COLLATE DATABASE_DEFAULT AND cm.client_type = clm.client_type "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster", MyTrans)
        Return ds
    End Function
    Protected Friend Function lFnGetAccMasterRecordByAcc(ByVal client_code As String, ByVal client_type As String) As DataSet
        Dim ds As New DataSet
        'Dim lstr As String = "select accno AS Account_No, name_1 AS Account_Name, vwcm.nature_s, client_type, ISNULL(vwcm.FATCA_acc_type, '') AS FATCA_Account_Type , ISNULL(vwcm.us_passport_holder,'') AS US_in_care_of_or_hold_mail_address, ISNULL(vwcm.us_citizen,'') AS US_Citizen, ISNULL(vwcm.us_born,'') AS Born_in_US, ISNULL(vwcm.us_address,'') AS US_Address, ISNULL(vwcm.us_phone,'') AS US_Telephone_No, ISNULL(vwcm.us_fund_transfer,'') AS Fund_Transfer_US, ISNULL(vwcm.us_auth_person,'') AS Authorized_person_with_US_address, ISNULL(vwcm.w8_form_signed, '') AS W_form_signed, CASE WHEN CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_date,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(vwcm.w8_form_date,''), 103) END AS Date_of_Signings, ISNULL(vwcm.us_tin,'') AS TIN, CASE WHEN  CONVERT(VARCHAR(30), ISNULL(vwcm.us_review_date,''), 103) ='01/01/1900' THEN '' ELSE CONVERT(VARCHAR(30), ISNULL(vwcm.us_review_date,''), 103) END AS Last_Review_Date, FATCA_Remarks from Vw_client_master_2 vwcm where accno = '" & client_code & "' and client_type= '" & client_type & "'"
        Dim lstr As String = " " & _
        "SELECT " & _
        "clm.accno, " & _
        "clm.name_1, " & _
        "clm.nature_s, " & _
        "clm.client_type, " & _
        "cm.FATCA_Account_Type, " & _
        "cm.FATCA_GIIN, " & _
        "cm.US_in_care_of_or_hold_mail_address, " & _
        "cm.US_Citizen, " & _
        "cm.Born_in_US, " & _
        "cm.US_Address, " & _
        "cm.US_Telephone_No, " & _
        "cm.Fund_Transfer_US, " & _
        "cm.Authorized_person_with_US_address, " & _
        "cm.W_form_signed, " & _
        "cm.Date_of_Signings, " & _
        "cm.TIN, " & _
        "cm.Last_Review_Date, " & _
        "cm.FATCA_Remarks, " & _
        "cm.CCD_Ref, " & _
        "cm.PersonID " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "clm.accno, " & _
                "clm.name_1, " & _
                "CASE clm.nature " & _
                    "WHEN '0' THEN 'Individual' WHEN '1' THEN 'Joint' " & _
                    "ELSE 'Corporation' " & _
                "END AS nature_s, " & _
                "CASE " & _
                    "WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' " & _
                    "ELSE 'Securities' " & _
                "END AS client_type " & _
                "FROM " & _
                    "" & GStrG2BSDB & ".dbo.client_master clm " & _
                "WHERE clm.accno = '" & client_code & "' and CASE WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' ELSE 'Securities' END = '" & client_type & "'" & _
        ") clm " & _
        "LEFT OUTER JOIN " & _
        "( " & _
            "SELECT " & _
                "localcm.acc_no, " & _
                "localcm.client_type, " & _
                "ISNULL(localcm.FATCA_acc_type, '') AS FATCA_Account_Type, " & _
                "ISNULL(localcm.FATCA_GIIN, '') As FATCA_GIIN, " & _
                "ISNULL(localcm.us_passport_holder,'') AS US_in_care_of_or_hold_mail_address, " & _
                "ISNULL(localcm.us_citizen,'') AS US_Citizen, " & _
                "ISNULL(localcm.us_born,'') AS Born_in_US, " & _
                "ISNULL(localcm.us_address,'') AS US_Address, " & _
                "ISNULL(localcm.us_phone,'') AS US_Telephone_No, " & _
                "ISNULL(localcm.us_fund_transfer,'') AS Fund_Transfer_US, " & _
                "ISNULL(localcm.us_auth_person,'') AS Authorized_person_with_US_address, " & _
                "ISNULL(localcm.w8_form_signed, '') AS W_form_signed, " & _
                "CASE " & _
                "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) ='01/01/1900' " & _
                "THEN '' " & _
                "ELSE CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) " & _
                "END AS Date_of_Signings, " & _
                "ISNULL(localcm.us_tin,'') AS TIN, " & _
                "CASE " & _
                "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.us_review_date,''), 103) ='01/01/1900' " & _
                "THEN '' " & _
                "ELSE CONVERT(VARCHAR(30),ISNULL(localcm.us_review_date,''), 103) " & _
                "END AS Last_Review_Date, " & _
                "FATCA_Remarks, " & _
                "localcm.ccd_ref as CCD_Ref, " & _
                "localcm.PersonID as PersonID " & _
                "FROM client_master localcm " & _
                "WHERE localcm.acc_no = '" & client_code & "' and localcm.client_type = '" & client_type & "'" & _
        ") cm ON cm.acc_no=clm.accno COLLATE DATABASE_DEFAULT AND cm.client_type = clm.client_type " & _
        "UNION " & _
        "SELECT " & _
        "clm.accno, " & _
        "clm.name_1, " & _
        "clm.nature_s, " & _
        "clm.client_type, " & _
        "cm.FATCA_Account_Type, " & _
        "cm.FATCA_GIIN, " & _
        "cm.US_in_care_of_or_hold_mail_address, " & _
        "cm.US_Citizen, " & _
        "cm.Born_in_US, " & _
        "cm.US_Address, " & _
        "cm.US_Telephone_No, " & _
        "cm.Fund_Transfer_US, " & _
        "cm.Authorized_person_with_US_address, " & _
        "cm.W_form_signed, " & _
        "cm.Date_of_Signings, " & _
        "cm.TIN, " & _
        "cm.Last_Review_Date, " & _
        "cm.FATCA_Remarks, " & _
        "cm.CCD_Ref, " & _
        "cm.PersonID " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
            "clm.accno, " & _
            "clm.name_1, " & _
            "CASE clm.nature " & _
                "WHEN '0' THEN 'Individual' WHEN '1' THEN 'Joint' " & _
                "ELSE 'Corporation' " & _
            "END AS nature_s, " & _
            "CASE " & _
                "WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' " & _
                "ELSE 'Futures' " & _
            "END AS client_type " & _
            "FROM " & _
            "" & GStrG2BFDB & ".dbo.client_master clm " & _
            "WHERE accno = '" & client_code & "' and CASE WHEN SUBSTRING(clm.accno, 1,3) = '500' THEN 'CIES' ELSE 'Futures' END = '" & client_type & "' " & _
        ") clm " & _
        "LEFT OUTER JOIN " & _
        "( " & _
            "SELECT " & _
                "localcm.acc_no, " & _
                "localcm.client_type, " & _
                "ISNULL(localcm.FATCA_acc_type, '') AS FATCA_Account_Type, " & _
                "ISNULL(localcm.FATCA_GIIN, '') As FATCA_GIIN, " & _
                "ISNULL(localcm.us_passport_holder,'') AS US_in_care_of_or_hold_mail_address, " & _
                "ISNULL(localcm.us_citizen,'') AS US_Citizen, " & _
                "ISNULL(localcm.us_born,'') AS Born_in_US, " & _
                "ISNULL(localcm.us_address,'') AS US_Address, " & _
                "ISNULL(localcm.us_phone,'') AS US_Telephone_No, " & _
                "ISNULL(localcm.us_fund_transfer,'') AS Fund_Transfer_US, " & _
                "ISNULL(localcm.us_auth_person,'') AS Authorized_person_with_US_address, " & _
                "ISNULL(localcm.w8_form_signed, '') AS W_form_signed, " & _
                "CASE " & _
                    "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) ='01/01/1900' " & _
                    "THEN '' " & _
                    "ELSE CONVERT(VARCHAR(30), ISNULL(localcm.w8_form_date,''), 103) " & _
                "END AS Date_of_Signings, " & _
                "ISNULL(localcm.us_tin,'') AS TIN, " & _
                "CASE " & _
                    "WHEN CONVERT(VARCHAR(30), ISNULL(localcm.us_review_date,''), 103) ='01/01/1900' " & _
                    "THEN '' " & _
                    "ELSE CONVERT(VARCHAR(30),ISNULL(localcm.us_review_date,''), 103) " & _
                "END AS Last_Review_Date, " & _
                "FATCA_Remarks, " & _
                "localcm.ccd_ref as CCD_Ref, " & _
                "localcm.PersonID as PersonID " & _
            "FROM client_master localcm " & _
            "WHERE localcm.acc_no = '" & client_code & "' and localcm.client_type = '" & client_type & "'" & _
        ") cm ON cm.acc_no=clm.accno COLLATE DATABASE_DEFAULT AND cm.client_type = clm.client_type "

        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function
    Protected Friend Function lFnGetClientMasterByAcc(ByVal client_code As String, ByVal client_type As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select acc_no FROM client_master where acc_no = '" & client_code & "' and  client_type = '" & client_type & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltClientMaster")
        Return ds
    End Function
    Protected Friend Function lFnGetRelatedACInfo(ByVal client_code As String, ByVal client_type As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select acc_no, client_type, ccd_ref from dbo.client_master cm1 where cm1.ccd_ref = (select ccd_ref from dbo.client_master where acc_no = '" & client_code & "' and client_type = '" & client_type & "') order by acc_no"        
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltClientMaster")
        Return ds
    End Function
    Protected Friend Function lFnGetRelatedACAdditionalInfo(ByVal client_code As String, ByVal client_type As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select convert(datetime, RelatedAC_FTAD, 103) as RelatedAC_FTAD, convert(datetime, RelatedAC_OTAD, 103) As RelatedAC_OTAD, RelatedAC_Remarks from dbo.client_master where acc_no = '" & client_code & "' and client_type='" & client_type & "'"        
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltClientMaster")
        Return ds
    End Function
    Protected Friend Function lFnUnlinkCCDRef(ByRef MyTrans As SqlTransaction, ByVal accountno As String, ByVal accountType As String) As Long
        Dim sqlStr As String
        sqlStr = String.Format("update dbo.client_master set ccd_ref = null, RelatedAC_FTAD=convert(datetime, '01/01/1900', 103),RelatedAC_OTAD=convert(datetime, '01/01/1900', 103) where acc_no = '{0}' and client_type='{1}'", accountno, accountType)
        Return GFncRunSQL(GSCnSqlConn, MyTrans, sqlStr, 0)
    End Function

    Protected Friend Function lFnUpdateCCDRefWithGivenAccountNo(ByRef MyTrans As SqlTransaction, ByVal accountNo As String, ByVal accountType As String, ByVal ccdref As String) As Long
        Dim lstrSQL As String = ""

        If Not String.IsNullOrEmpty(ccdref) Then
            lstrSQL = "update cm1 set cm1.ccd_ref = " & ccdref & ",cm1.RelatedAC_FTAD =ISNULL( cm3.RelatedAC_FTAD,'01-Jan-1900'),cm1.RelatedAC_OTAD =ISNULL(cm3.RelatedAC_OTAD,'01-Jan-1900'),cm1.RelatedAC_Remarks =ISNULL(cm3.RelatedAC_Remarks,'') from dbo.client_master as cm1,( select cm2.RelatedAC_FTAD,cm2.RelatedAC_OTAD,cm2.RelatedAC_Remarks from ( select ccd_ref, RelatedAC_FTAD, RelatedAC_OTAD, RelatedAC_Remarks from dbo.client_master where acc_no = '" & accountNo & "' and client_type='" & accountType & "') as cm1 LEFT JOIN ( SELECT ccd_ref, RelatedAC_FTAD, RelatedAC_OTAD, RelatedAC_Remarks FROM( select ccd_ref, acc_no, RelatedAC_FTAD, RelatedAC_OTAD, RelatedAC_Remarks, row_number() over(order by acc_no) as rn from dbo.client_master as t where ccd_ref = " & ccdref & ") as t1 where rn = ( select max(tbl.rownum) as max_row from (  select row_number() over( order by acc_no) as rownum from dbo.client_master where ccd_ref = " & ccdref & " ) as tbl  )) as cm2 on cm2.ccd_ref = " & ccdref & " ) as cm3 where cm1.acc_no = '" & accountNo & "' and cm1.client_type='" & accountType & "'"
        End If

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnUpdateCCDRefForChange(ByRef MyTrans As SqlTransaction, ByVal ccdref As String, ByVal cur_ccd_ref As String) As Long
        Dim lstrSQL As String = ""

        If String.IsNullOrEmpty(ccdref) Then
            lstrSQL = "update dbo.client_master set ccd_ref = null, RelatedAC_FTAD=convert(datetime, '01/01/1900', 103),RelatedAC_OTAD=convert(datetime, '01/01/1900', 103),RelatedAC_Remarks='' from ( select acc_no, client_type from dbo.client_master cm1 where exists(SELECT 1 FROM dbo.client_master cm2 WHERE cm2.ccd_ref = " & cur_ccd_ref & " AND cm1.acc_no = cm2.acc_no and cm1.client_type = cm2.client_type)) cm3 where dbo.client_master.acc_no = cm3.acc_no and dbo.client_master.client_type = cm3.client_type"
        Else
            lstrSQL = "update cm1 set cm1.ccd_ref = " & ccdref & ", cm1.RelatedAC_FTAD = ISNULL( cm10.RelatedAC_FTAD,'01-Jan-1900'), cm1.RelatedAC_OTAD = ISNULL(cm10.RelatedAC_OTAD,'01-Jan-1900'), cm1.RelatedAC_Remarks = ISNULL(cm10.RelatedAC_Remarks,'') from dbo.client_master cm1 LEFT JOIN( SELECT ccd_Ref,RelatedAC_FTAD, RelatedAC_OTAD, RelatedAC_Remarks FROM ( select ccd_ref, acc_no, RelatedAC_FTAD, RelatedAC_OTAD, RelatedAC_Remarks, row_number() over(order by acc_no) as rn from dbo.client_master as t where ccd_ref = " & ccdref & " ) as t1 where rn = ( select max(tbl.rowCols) as max_row from ( select row_number() over(order by acc_no) as rowCols from dbo.client_master as tbl where tbl.ccd_ref = " & ccdref & " ) as tbl ) ) as cm10 on cm10.ccd_ref = " & ccdref & " where EXISTS ( select 1 from dbo.client_master cm2 where cm2.ccd_ref = " & cur_ccd_ref & " AND cm1.acc_no = cm2.acc_no And cm1.client_type = cm2.client_type )"
        End If

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function


    Protected Friend Function lFnUpdateAdditionalRelatedACInfo(ByRef MyTrans As SqlTransaction, _
                                                                 ByVal ftad As String, ByVal otad As String, ByVal remarks As String, _
                                                                 ByVal cur_ccd_ref As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update dbo.client_master set RelatedAC_FTAD = convert(datetime, '" & ftad & "', 103), RelatedAC_OTAD = convert(datetime, '" & otad & "', 103), RelatedAC_Remarks = '" & remarks & "' from ( SELECT acc_no, client_type FROM dbo.client_master cm1 WHERE EXISTS ( SELECT 1 FROM dbo.client_master cm2 WHERE cm2.ccd_ref = " & cur_ccd_ref & " AND cm1.acc_no = cm2.acc_no ) and ccd_ref = " & cur_ccd_ref & " ) cm3 where dbo.client_master.acc_no = cm3.acc_no and dbo.client_master.client_type = cm3.client_type"

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnUpdateAdditionalRelatedACInfo(ByRef MyTrans As SqlTransaction, _
                                                                ByVal ftad As String, ByVal otad As String, ByVal remarks As String, _
                                                                ByVal account_no As String, ByVal account_type As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update dbo.client_master set RelatedAC_FTAD = convert(datetime, '" & ftad & "', 103), RelatedAC_OTAD = convert(datetime, '" & otad & "', 103), RelatedAC_Remarks = '" & remarks & "' where acc_no = '" & account_no & "' and client_type = '" & account_type & "' and (ccd_ref is null)"

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnGetFuturesThirdParty() As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
        "ParamName,IntValue,CharValue " & _
        "FROM " & _
        GStrConDB & ".dbo.SystemStaticParam " & _
        "WHERE ParamType='ThirdPartyMaster'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyMaster")
        Return ds
    End Function
    Protected Friend Function lFnGetSecuritiesAccountDetailsByAcc(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
            "cm.acc_no, " & _
            "cm.w8_form_date, " & _
            "gcm.external_accno " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "cm.acc_no, " & _
                "cm.w8_form_date " & _
            "FROM " & _
                GStrConDB & ".dbo.client_master cm " & _
            "WHERE cm.acc_no = '" & client_code & "' and client_type='Securities' " & _
        ") cm " & _
        "INNER JOIN " & _
        "( " & _
            "SELECT " & _
                "gcm.accno, " & _
                "gcm.external_accno " & _
            "FROM " & _
                GStrG2BSDB & " .dbo.client_master gcm " & _
            "WHERE gcm.accno = '" & client_code & "'" & _
        ") gcm " & _
        "ON gcm.accno COLLATE DATABASE_DEFAULT=cm.acc_no "

        ds = GFncRtnDS(GSCnSqlConn, lstr, "SecuritiesAccountDetails")
        Return ds
    End Function
    Protected Friend Function lFnGetFuturesAccountDetailsByAcc(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
            "cm.acc_no, " & _
            "cm.w8_form_date, " & _
            "' ' AS external_accno " & _
        "FROM " & _
        "( " & _
            "SELECT " & _
                "cm.acc_no, " & _
                "cm.w8_form_date " & _
            "FROM " & _
                GStrConDB & ".dbo.client_master cm " & _
            "WHERE cm.acc_no = '" & client_code & "' and cm.client_type='Futures' " & _
        ") cm "
        
        ds = GFncRtnDS(GSCnSqlConn, lstr, "FuturesAccountDetails")
        Return ds
    End Function
    Protected Friend Function lFnGetClientMarketRecordByAcc(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
                "vicm.MAMK, vicm.SG, vicm.SSE, vicm.SZEN, vicm.US " & _
        "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
        "LEFT OUTER JOIN " & _
            "" & GStrG2BSDB & ".dbo.view_it_client_market vicm " & _
            "ON vicm.aid=cm.aid " & _
        "WHERE cm.accno='" & client_code.ToString.Trim & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ClientMarket")
        Return ds
    End Function

    Protected Friend Function lFnGetForeignMarketRecordByAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sMarket As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
            "afi.Accno, afi.Market, afi.ServiceStartDate, afi.Channel, afi.UVOTCMarketStartDate, afi.iTradeStartDate, " & _
            "asi.ServiceType, asi.StartDate, asi.EndDate, afi.RiskDisclosure, " & _
            "t1.MAMK, t1.SG, t1.SSE, t1.SZEN, t1.US " & _
        "FROM " & _
            "" & GStrConDB & ".dbo.AccountForeignInfo afi " & _
        "LEFT OUTER JOIN " & _
            "" & GStrConDB & ".dbo.AdvServiceInfo asi " & _
        "ON asi.Accno=afi.Accno AND asi.Market=afi.Market " & _
        "LEFT OUTER JOIN " & _
            "( " & _
            "SELECT " & _
                "cm.aid,cm.accno, " & _
                "vicm.MAMK, vicm.SG, vicm.SSE, vicm.SZEN, vicm.US " & _
            "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BSDB & ".dbo.view_it_client_market vicm " & _
                "ON vicm.aid=cm.aid " & _
            ") t1 " & _
            "ON t1.accno COLLATE DATABASE_DEFAULT=afi.accno COLLATE DATABASE_DEFAULT " & _
        "WHERE afi.accno='" & client_code.ToString.Trim & "' and afi.market ='" & sMarket & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ForeignMarket", MyTrans)

        Return ds
    End Function
    Protected Friend Function lFnGetForeignMarketRecordByAcc(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
            "afi.Accno, afi.Market, afi.ServiceStartDate, afi.Channel, afi.UVOTCMarketStartDate, afi.iTradeStartDate, " & _
            "asi.ServiceType, asi.StartDate, asi.EndDate, afi.RiskDisclosure," & _
            "t1.MAMK, t1.SG, t1.SSE, t1.SZEN, t1.US " & _
        "FROM " & _
            "" & GStrConDB & ".dbo.AccountForeignInfo afi " & _
        "LEFT OUTER JOIN " & _
            "" & GStrConDB & ".dbo.AdvServiceInfo asi " & _
        "ON asi.Accno=afi.Accno AND asi.Market=afi.Market " & _
        "LEFT OUTER JOIN " & _
            "( " & _
            "SELECT " & _
                "cm.aid,cm.accno, " & _
                "vicm.MAMK, vicm.SG, vicm.SSE, vicm.SZEN, vicm.US " & _
            "FROM " & GStrG2BSDB & ".dbo.client_master cm " & _
            "LEFT OUTER JOIN " & _
                "" & GStrG2BSDB & ".dbo.view_it_client_market vicm " & _
                "ON vicm.aid=cm.aid " & _
            ") t1 " & _
            "ON t1.accno COLLATE DATABASE_DEFAULT=afi.accno COLLATE DATABASE_DEFAULT " & _
        "WHERE afi.accno='" & client_code.ToString.Trim & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ForeignMarket")

        Return ds
    End Function
    Protected Friend Function lFnGetForeignMarketRecordByAccByMarket(ByVal mytrans As SqlTransaction, ByVal client_code As String, ByVal sMarket As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String =
        "SELECT " & _
            "afi.Accno, afi.Market, afi.ServiceStartDate, afi.Channel, afi.UVOTCMarketStartDate, afi.iTradeStartDate, " & _
            "asi.ServiceType, asi.StartDate, asi.EndDate, afi.RiskDisclosure " & _
        "FROM " & _
            "" & GStrConDB & ".dbo.AccountForeignInfo afi " & _
        "LEFT OUTER JOIN " & _
            "" & GStrConDB & ".dbo.AdvServiceInfo asi " & _
        "ON asi.Accno=afi.Accno AND asi.Market=afi.Market " & _
        "WHERE afi.accno='" & client_code.ToString.Trim & "' AND afi.Market = '" & sMarket & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ForeignMarket", mytrans)
        Return ds
    End Function
    Protected Friend Function lFnEditAccountForeignInfo(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sMarket As String, ByVal sServiceStartDate As String, ByVal sFMRiskDisclosure As String, ByVal sChannel As String, ByVal sFMUSITradeStartDate As String, ByVal sFMUVOTCMarketStartDate As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update AccountForeignInfo SET ServiceStartDate =  convert(datetime, '" & sServiceStartDate & "', 103), RiskDisclosure= '" & sFMRiskDisclosure & "', Channel='" & sChannel & "', UVOTCMarketStartDate = convert(datetime,'" & sFMUVOTCMarketStartDate & "', 103),  iTradeStartDate = convert(datetime, '" & sFMUSITradeStartDate & "', 103) WHERE AccNo = '" & client_code & "' and Market = '" & sMarket & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnAddAccountForeignInfo(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sMarket As String, ByVal sServiceStartDate As String, ByVal sFMRiskDisclosure As String, ByVal sChannel As String, ByVal sFMUSITradeStartDate As String, ByVal sFMUVOTCMarketStartDate As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "INSERT INTO AccountForeignInfo(Accno, Market, ServiceStartDate, Channel, UVOTCMarketStartDate, iTradeStartDate, RiskDisclosure)VALUES('" & client_code & "', '" & sMarket & "', convert(datetime, '" & sServiceStartDate & "', 103), '" & sChannel & "', convert(datetime,'" & sFMUVOTCMarketStartDate & "', 103), convert(datetime, '" & sFMUSITradeStartDate & "', 103), '" & sFMRiskDisclosure & "')"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnEditAdvServiceInfo(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sMarket As String, ByVal sServiceType As String, ByVal sStartDate As String, ByVal sEndDate As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update AdvServiceInfo SET StartDate = convert(datetime, '" & sStartDate & "', 103), EndDate = convert(datetime, '" & sEndDate & "', 103) WHERE AccNo = '" & client_code & "' and Market = '" & sMarket & "' and ServiceType = '" & sServiceType & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnAddAdvServiceInfo(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sMarket As String, ByVal sServiceType As String, ByVal sStartDate As String, ByVal sEndDate As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "INSERT INTO AdvServiceInfo(Accno, ServiceType, Market, StartDate, EndDate)VALUES('" & client_code & "', '" & sServiceType & "', '" & sMarket & "', convert(datetime, '" & sStartDate & "', 103), convert(datetime, '" & sEndDate & "', 103))"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnGetThirdPartyMappingByAcc(ByVal client_code As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpamapp.AccNo, " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks, " & _
        "tpamapp.ServiceStartdate " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "INNER JOIN " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
        "ON tpamapp.platform=tpam.platform and tpamapp.ThirdPartyAccNo=tpam.ThirdPartyAccNo " & _
        "WHERE tpamapp.Accno= '" & client_code & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMapping")
        Return ds
    End Function

    Protected Friend Function lFnGetThirdPartyMappingByAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpamapp.AccNo, " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks, " & _
        "tpamapp.ServiceStartdate " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "INNER JOIN " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
        "ON tpamapp.platform=tpam.platform and tpamapp.ThirdPartyAccNo=tpam.ThirdPartyAccNo " & _
        "WHERE tpamapp.Accno= " & client_code & " "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMapping", MyTrans)
        Return ds
    End Function
    Protected Friend Function lFnGetThirdPartyMappingByAccByPlatform(ByVal client_code As String, ByVal sPlatform As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpamapp.AccNo, " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks, " & _
        "tpamapp.ServiceStartdate " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "INNER JOIN " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
        "ON tpamapp.platform=tpam.platform and tpamapp.ThirdPartyAccNo=tpam.ThirdPartyAccNo " & _
        "WHERE tpamapp.Accno= '" & client_code & "' AND tpamapp.Platform='" & sPlatform & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMapping")
        Return ds
    End Function
    Protected Friend Function lFnGetThirdPartyMappingByAccByPlatform(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sPlatform As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpamapp.AccNo, " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks, " & _
        "tpamapp.ServiceStartdate " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "INNER JOIN " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
        "ON tpamapp.platform=tpam.platform and tpamapp.ThirdPartyAccNo=tpam.ThirdPartyAccNo " & _
        "WHERE tpamapp.Accno= '" & client_code & "' AND tpamapp.Platform='" & sPlatform & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMapping", MyTrans)
        Return ds
    End Function
    Protected Friend Function lFnGetThirdPartyMappingByNotAcc(ByVal client_code As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpamapp.AccNo, " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks, " & _
        "tpamapp.ServiceStartdate " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "INNER JOIN " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
        "ON tpamapp.platform=tpam.platform and tpamapp.ThirdPartyAccNo=tpam.ThirdPartyAccNo " & _
        "WHERE tpamapp.Accno<> " & client_code & " "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMapping")
        Return ds
    End Function
    Protected Friend Function lFnGetThirdPartyMappingByNotAccPlatform(ByVal client_code As String, ByVal sFMPlatform As String, ByVal sFMTPAccNo As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpamapp.AccNo, " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks, " & _
        "tpamapp.ServiceStartdate " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "INNER JOIN " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMapping tpamapp " & _
        "ON tpamapp.platform=tpam.platform and tpamapp.ThirdPartyAccNo=tpam.ThirdPartyAccNo " & _
        "WHERE tpamapp.Accno<> '" & client_code & "' AND tpam.Platform='" & sFMPlatform & "' AND tpam.ThirdPartyAccNo='" & sFMTPAccNo & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMapping")
        Return ds
    End Function
    Protected Friend Function lFnGetThirdPartyMasterByPlatform(ByVal sPlatform As String)
        Dim ds As New DataSet
        Dim lstr As String = String.Empty
        lstr = "SELECT " & _
        "tpam.Platform, " & _
        "tpam.ThirdPartyAccNo," & _
        "tpam.ThirdPartyUsername, " & _
        "tpam.Remarks " & _
        "FROM " & _
        "" & GStrConDB & ".dbo.ThirdPartyAccountMaster tpam " & _
        "WHERE tpam.Platform='" & sPlatform & "' "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "ThirdPartyAccMaster")
        Return ds
    End Function
    Protected Friend Function lFnEditThirdPartyMapping(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sFMPlatform As String, ByVal sFMTPAccNo As String, ByVal sFMTPSerStartDate As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update ThirdPartyAccountMapping SET ThirdPartyAccNo = '" & sFMTPAccNo & "', ServiceStartDate= convert(datetime, '" & sFMTPSerStartDate & "', 103) WHERE AccNo = '" & client_code & "' AND Platform='" & sFMPlatform & "' "
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnEditThirdPartyMaster(ByRef MyTrans As SqlTransaction, ByVal sFMPlatformorg As String, ByVal sFMTPAccNoorg As String, ByVal sFMPlatform As String, ByVal sFMTPAccNo As String, ByVal sFMTPUsername As String, ByVal sFMRemarks As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update ThirdPartyAccountMaster SET Platform='" & sFMPlatform & "', ThirdPartyAccNo = '" & sFMTPAccNo & "', ThirdPartyUsername = '" & sFMTPUsername & "', Remarks='" & sFMRemarks & "' WHERE ThirdPartyAccNo = '" & sFMTPAccNoorg & "' and Platform = '" & sFMPlatformorg & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnAddThirdPartyMapping(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal sFMPlatform As String, ByVal sFMTPAccNo As String, ByVal sFMTPSerStartDate As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "INSERT INTO ThirdPartyAccountMapping(AccNo,Platform,ThirdPartyAccNo,ServiceStartdate)VALUES('" & client_code & "','" & sFMPlatform & "', '" & sFMTPAccNo & "', convert(datetime, '" & sFMTPSerStartDate & "', 103))"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnaddThirdPartyMaster(ByRef MyTrans As SqlTransaction, ByVal sFMPlatform As String, ByVal sFMTPAccNo As String, ByVal sFMTPUsername As String, ByVal sFMRemarks As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "INSERT INTO ThirdPartyAccountMaster(Platform,ThirdPartyAccNo,ThirdPartyUsername,Remarks)VALUES('" & sFMPlatform & "', '" & sFMTPAccNo & "','" & sFMTPUsername & "', '" & sFMRemarks & "')"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFncGetAddIsolatedAccList(ByVal client_code As String, ByVal strClient_Type As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String =
        "DECLARE @AccNo as VARCHAR(10) " & _
        "DECLARE @ClientType as VARCHAR(20) " & _
        "SET @AccNo = '" & client_code & "' " & _
        "SET @ClientType = '" & strClient_Type & "' " & _
        "SELECT acc_no, " & _
        "       client_type " & _
        "FROM " & _
        "( " & _
        "	SELECT 	scm.accno AS acc_no, " & _
        "			CASE " & _
        "			  WHEN SUBSTRING (scm.accno, 1, 3) = '500' THEN 'CIES' " & _
        "			  ELSE 'Securities' " & _
        "			END AS client_type " & _
        "	FROM " & GStrG2BSDB & ".dbo.client_master scm " & _
        "	UNION ALL  " & _
        "	SELECT fcm.accno AS acc_no,  " & _
        "          'Futures' AS client_type  " & _
        "	FROM " & GStrG2BFDB & ".dbo.client_master fcm  " & _
        ") secfut_master " & _
        "WHERE  " & _
        "RTRIM(acc_no) = @AccNo  " & _
        "AND client_type = @ClientType " & _
        "AND NOT EXISTS " & _
        "( " & _
        "	SELECT 1 " & _
        "	FROM client_master cltm " & _
        "	WHERE  " & _
        "	RTRIM(acc_no) = @AccNo  " & _
        "	AND client_type = @ClientType " & _
        "	AND secfut_master.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS = cltm.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS " & _
        "	AND secfut_master.client_type = cltm.client_type " & _
        ") "
        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If

    End Function
    Protected Friend Function lFncGetAddLinkedAccList(ByVal client_code As String, ByVal strClient_Type As String, ByVal strAccPrefixFilter As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String =
        "DECLARE @AccNo as VARCHAR(10)  " & _
        "DECLARE @ClientType as VARCHAR(20)  " & _
        "SET @AccNo = '" & client_code & "'  " & _
        "SET @ClientType = '" & strClient_Type & "' " & _
        "SELECT acc_no,  " & _
        "       client_type  " & _
        "FROM  " & _
        "(  " & _
        "	SELECT 	scm.accno AS acc_no,  " & _
        "			CASE  " & _
        "			  WHEN SUBSTRING (scm.accno, 1, 3) = '500' THEN 'CIES'  " & _
        "			  ELSE 'Securities'  " & _
        "			END AS client_type  " & _
        "	FROM " & GStrG2BSDB & ".dbo.client_master scm  " & _
        "	UNION ALL   " & _
        "	SELECT fcm.accno AS acc_no,  " & _
        "          'Futures' AS client_type  " & _
        "	FROM " & GStrG2BFDB & ".dbo.client_master fcm  " & _
        ") secfut_master  " & _
        "WHERE   " & _
        "RTRIM(acc_no) LIKE   " & _
        "CASE  " & _
        "	WHEN LEN(@AccNo) > 7   " & _
        "	THEN '%' + SUBSTRING(@AccNo, 4, 5)  " & _
        "	ELSE @AccNo  " & _
        "END  " & _
        "AND   " & _
        "(  " & _
        "	1=1 " & strAccPrefixFilter & "  " & _
        ")  " & _
        "AND NOT EXISTS  " & _
        "(  " & _
        "	SELECT 1  " & _
        "	FROM client_master cltm  " & _
        "	WHERE   " & _
        "	RTRIM(acc_no) LIKE  " & _
        "	CASE  " & _
        "		WHEN LEN(@AccNo) > 7   " & _
        "		THEN '%' + SUBSTRING(@AccNo, 4, 5)  " & _
        "		ELSE @AccNo  " & _
        "	END  " & _
        "	AND   " & _
        "	(  " & _
        "		1=1 " & strAccPrefixFilter & "  " & _
        "	)  " & _
        "	AND secfut_master.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS = cltm.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS  " & _
        "	AND secfut_master.client_type = cltm.client_type  " & _
        ")  "

        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If
    End Function
    Protected Friend Function getAccPrefixFilter(ByVal client_code As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As String
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

    Protected Friend Function getIsolatedPrefix(Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = " SELECT CharValue as IsolatedPrefix FROM SystemStaticParam WHERE ParamType = 'FatcaAcc_IsolatedPrefix' "
        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If

    End Function
    Protected Friend Function lFnModifyCCDRefWithGivenAccountNo(ByRef MyTrans As SqlTransaction, ByVal accountNo As String, ByVal accountType As String, ByVal ccdref As String) As Long
        Dim lstrSQL As String = "" & _
        " UPDATE cm1 " & _
        " SET cm1.ccd_ref = " & If(String.IsNullOrEmpty(ccdref), "Null", ccdref) & ", " & _
        " cm1.RelatedAC_FTAD = ISNULL(cm.RelatedAC_FTAD, '1900-01-01'), " & _
        " cm1.RelatedAC_OTAD = ISNULL(cm.RelatedAC_OTAD, '1900-01-01'), " & _
        " cm1.RelatedAC_Remarks = ISNULL(cm.RelatedAC_Remarks, '') " & _
        " FROM dbo.client_master AS cm1 " & _
        " LEFT JOIN " & _
        " ( " & _
        " 	SELECT  acc_no, " & _
        " 			client_type, " & _
        " 			RelatedAC_FTAD, " & _
        " 		    RelatedAC_OTAD, " & _
        " 		    RelatedAC_Remarks " & _
        " 	FROM dbo.client_master AS cm " & _
        " 	WHERE acc_no = '" & accountNo & "' " & _
        " 	AND client_type = '" & accountType & "' " & _
        " ) cm  " & _
        " ON cm.acc_no = cm1.acc_no  " & _
        " AND cm.client_type = cm1.client_type " & _
        " WHERE cm1.acc_no = '" & accountNo & "' " & _
        " AND cm1.client_type = '" & accountType & "' "

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnInsertNewCCDRefWithGivenAccountNo(ByRef MyTrans As SqlTransaction, ByVal accountNo As String, ByVal accountType As String, ByVal ccdref As String) As Long
        Dim lstrSQL As String = "" & _
        " INSERT INTO client_master  " & _
        " ( " & _
        "   ccd_ref, " & _
        " 	RelatedAC_FTAD, " & _
        " 	RelatedAC_OTAD, " & _
        " 	RelatedAC_Remarks, " & _
        " 	acc_no, " & _
        " 	client_type " & _
        " ) " & _
        " VALUES " & _
        " ( " & _
        "   " & If(String.IsNullOrEmpty(ccdref), "Null", ccdref) & ", " & _
        " 	'1900-01-01', " & _
        " 	'1900-01-01', " & _
        " 	'', " & _
        " 	'" & accountNo & "', " & _
        " 	'" & accountType & "' " & _
        " ) "

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
End Class
