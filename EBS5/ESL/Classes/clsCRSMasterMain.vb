Imports System.Data.SqlClient

Public Class clsCRSMasterMain

    Public Function FncSearch(
                             ByVal accType As String,
                             ByVal crsType As String,
                             ByVal accno As String) As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CRSMaster", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数
        AddParameter(sqlCmd, "AccType", accType)
        AddParameter(sqlCmd, "CrsType", crsType)
        AddParameter(sqlCmd, "Accno", accno)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Public Function FnAddCRSMaster(
                          ByVal accno As String,
                          ByVal accType As String,
                          ByVal fstName As String,
                          ByVal lastName As String,
                          ByVal cpType As String,
                          ByVal resCCode As String,
                          ByVal tin As String,
                          ByVal tinIssueBy As String,
                          ByVal legalAddrType As String,
                          ByVal addrCCode As String,
                          ByVal addr As String,
                          ByVal birthDate As Date,
                          ByVal birthCCode As String,
                          ByVal birthCity As String) As Integer

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_CRSMaster_CP", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "Accno", accno)
            AddParameter(sqlCmd, "AccType", accType)
            AddParameter(sqlCmd, "CPType", cpType)
            AddParameter(sqlCmd, "FirstName", fstName)
            AddParameter(sqlCmd, "LastName", lastName)
            AddParameter(sqlCmd, "ResCountryCode", resCCode)
            AddParameter(sqlCmd, "TIN", tin)
            AddParameter(sqlCmd, "TINIssueBy", tinIssueBy)
            AddParameter(sqlCmd, "BirthDate", birthDate)
            AddParameter(sqlCmd, "BirthCountryCode", birthCCode)
            AddParameter(sqlCmd, "BirthCity", birthCity)
            AddParameter(sqlCmd, "AddressCountryCode", addrCCode)
            AddParameter(sqlCmd, "LegalAddressType", legalAddrType)
            AddParameter(sqlCmd, "AddressFree", addr)

            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function

    Public Function FnDeleteCRSMaster(ByVal mid As Integer, ByVal accno As String, ByVal accType As String, ByVal fstName As String, ByVal lastName As String) As Boolean
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Del_CRSMaster_CP", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "mid", mid)
            AddParameter(sqlCmd, "Accno", accno)
            AddParameter(sqlCmd, "AccType", accType)
            AddParameter(sqlCmd, "FirstName", fstName.Trim)
            AddParameter(sqlCmd, "LastName", lastName.Trim)

            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try
    End Function


    Public Function FnUpdateCRSMaster(ByVal mid As Integer,
                         ByVal accno As String,
                          ByVal accType As String,
                          ByVal crsType As String,
                          ByVal fstName As String,
                          ByVal lastName As String,
                          ByVal accHolderType As String,
                          ByVal cpType As String,
                          ByVal resCCode As String,
                          ByVal tin As String,
                          ByVal tinIssueBy As String,
                          ByVal legalAddrType As String,
                          ByVal addrCCode As String,
                          ByVal addr As String,
                          ByVal birthDate As Date,
                          ByVal birthCCode As String,
                          ByVal birthCity As String) As Integer
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_CRSMaster", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "mid", mid)
            AddParameter(sqlCmd, "Accno", accno)
            AddParameter(sqlCmd, "AccType", accType)
            AddParameter(sqlCmd, "CPType", GFncNoNullString(cpType))
            AddParameter(sqlCmd, "CrsType", crsType)
            AddParameter(sqlCmd, "AccHolderType", GFncNoNullString(accHolderType))
            AddParameter(sqlCmd, "FirstName", GFncNoNullString(fstName))
            AddParameter(sqlCmd, "LastName", GFncNoNullString(lastName))
            AddParameter(sqlCmd, "ResCountryCode", GFncNoNullString(resCCode))
            AddParameter(sqlCmd, "TIN", GFncNoNullString(tin))
            AddParameter(sqlCmd, "TINIssueBy", GFncNoNullString(tinIssueBy))
            AddParameter(sqlCmd, "BirthDate", birthDate)
            AddParameter(sqlCmd, "BirthCountryCode", GFncNoNullString(birthCCode))
            AddParameter(sqlCmd, "BirthCity", GFncNoNullString(birthCity))
            AddParameter(sqlCmd, "AddressCountryCode", GFncNoNullString(addrCCode))
            AddParameter(sqlCmd, "LegalAddressType", GFncNoNullString(legalAddrType))
            AddParameter(sqlCmd, "AddressFree", GFncNoNullString(addr))

            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function

    Public Function FnGetCountryCode() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CRSCountryCode", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' 参数
        'Nothing
        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function


    Public Function FnExportCRSCSV(ByVal strExFile As String, ByVal strAccType As String, ByVal return_year As Integer) As Boolean
        Dim newConn As SqlConnection = CType(GSCnSqlConn, ICloneable).Clone
        Dim ldtsData As DataSet = Nothing

        Try

            Dim scriptName As String = IIf(strAccType = "Securities", "s_Get_CRSNonGroup", "s_Get_CRSNonGroup_f")

            Dim sqlCmd As SqlCommand = New SqlCommand(scriptName, newConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "g2bDB", IIf(strAccType = "Securities", GStrG2BSDB, GStrG2BFDB))
            AddParameter(sqlCmd, "return_year", return_year)

            ldtsData = GFncRtnDS(sqlCmd, intTimeOut:=0)

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                GSubWriteErrLog(ex.Message)
            End If
        Finally
            newConn.Close()
        End Try
        If ldtsData Is Nothing Then
            Return False
        Else
            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Crs_id, AccType, ReturnYear, Accno, CrsType, AccHolderType,CPType,ClientName, FirstName, LastName,NameType,ResCountryCode,TIN,TINIssueBy,BR_ID,BirthDate,BirthCountryCode,BirthCity,AddressCountryCode,LegalAddressType,AddressFree, AccBal,Dividend,Interest,Redemption,OtherPayment")
        End If
    End Function

End Class
