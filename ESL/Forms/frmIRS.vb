Imports System.Configuration
Imports System.Xml
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.IO
Imports System.IO.Compression
Imports System.IO.Compression.GZipStream
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports Ionic.Zip


Public Class frmIRS
    Private sFinancialYear As String
    Private sCurr As String

    Private htAccHolderType As New Hashtable()
    Private htAccountPoolreportType As New Hashtable()

    Dim sIRSFolderPathAccountReport As String = "IRS\AccountReport\"
    Dim sIRSFolderPathPoolReport As String = "IRS\PoolReport\"

    Private sSecuritiesCompany As String = "MFZPXJ.99999.SL.344"
    Private sFuturesCompany As String = "7HJZSV.99999.SL.344"

    Private strSecuritiesEncryptExFile As String = sSecuritiesCompany & "_Payload"
    Private strFuturesEncryptExFile As String = sFuturesCompany & "_Payload"
    Private strSecuritiesExFile As String = sSecuritiesCompany & "_Payload.xml"
    Private strFuturesExFile As String = sFuturesCompany & "_Payload.xml"
    Private strSecuritiesMetaExFile As String = sSecuritiesCompany & "_Metadata.xml"
    Private strFuturesMetaExFile As String = sFuturesCompany & "_Metadata.xml"
    Private strSecuritiesAESKeyExFile As String = sSecuritiesCompany & "_Key"
    Private strFuturesAESKeyExFile As String = sFuturesCompany & "_Key"

    Private strGroupSecuritiesEncryptExFile As String = sSecuritiesCompany & "_Payload"
    Private strGroupFuturesEncryptExFile As String = sFuturesCompany & "_Payload"
    Private strGroupSecuritiesExFile As String = sSecuritiesCompany & "_Payload.xml"
    Private strGroupFuturesExFile As String = sFuturesCompany & "_Payload.xml"
    Private strGroupSecuritiesMetaExFile As String = sSecuritiesCompany & "_Metadata.xml"
    Private strGroupFuturesMetaExFile As String = sFuturesCompany & "_Metadata.xml"
    Private strGroupSecuritiesAESKeyExFile As String = sSecuritiesCompany & "_Key"
    Private strGroupFuturesAESKeyExFile As String = sFuturesCompany & "_Key"


    Private algorithm As RijndaelManaged

    Private sESLCertPath As String = Application.StartupPath & "\IRSCert\ESL.pfx"
    Private sEFLCertPath As String = Application.StartupPath & "\IRSCert\EFL.pfx"
    Private sCertPassword As String = "emperor"

    Private sAESKey As String = String.Empty

    Private Sub frmIRS_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim clsIRS As New ClsIRS
        Dim dsSystemStaticParamFinancialYear As New DataSet
        Dim dtSystemStaticParamFinancialYear As New DataTable

        Dim dsFinancialYear As New DataSet
        Dim dtFinancialYear As New DataTable

        Dim dsSystemStaticParamCurr As New DataSet
        Dim dtSystemStaticParamCurr As New DataTable

        Try
            dsFinancialYear = clsIRS.lFnGetFinancialYear()
            If dsFinancialYear IsNot Nothing And dsFinancialYear.Tables.Count > 0 Then
                dtFinancialYear = dsFinancialYear.Tables(0)
            End If

            For Each row As DataRow In dtFinancialYear.Rows
                If Not row.IsNull(dtFinancialYear.Columns("tdate")) Then

                    lblGenerateFinancialYear.Text = row("tdate").ToString.Trim

                    sFinancialYear = Date.ParseExact(row("tdate").ToString.Trim, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("yyyy-MM-dd")

                End If
            Next


            dsSystemStaticParamCurr = clsIRS.lFnGetSystemStaticParamCurr()
            If dsSystemStaticParamCurr IsNot Nothing And dsSystemStaticParamCurr.Tables.Count > 0 Then
                dtSystemStaticParamCurr = dsSystemStaticParamCurr.Tables(0)
            End If
            For Each row As DataRow In dtSystemStaticParamCurr.Rows
                If Not row.IsNull(dtSystemStaticParamCurr.Columns("CharValue")) Then
                    sCurr = row("CharValue").ToString.Trim
                Else
                    sCurr = ""
                End If
            Next


            If Not Directory.Exists(GStrExptDir & sIRSFolderPathAccountReport) Then
                Directory.CreateDirectory(GStrExptDir & sIRSFolderPathAccountReport)
            End If

            If Not Directory.Exists(GStrExptDir & sIRSFolderPathPoolReport) Then
                Directory.CreateDirectory(GStrExptDir & sIRSFolderPathPoolReport)
            End If

            rbAccountReport.Checked = True
            rbSecurities.Checked = True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message.ToString, GStrEPath)

            GSubShowWarn(ex.Message)
        End Try
    End Sub
    Private Sub btnGenerateXML_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateXML.Click
        Dim clsIRS As New ClsIRS

        Dim sFATCAAccType As String = String.Empty
        Dim iNumCount As Integer = 0

        Dim bSecuritiesAccountReportSuccess As Boolean = False
        Dim bFuturesAccountReportSuccess As Boolean = False
        Dim bSecuritiesGroupReportSuccess As Boolean = False
        Dim bFuturesGroupReportSuccess As Boolean = False


        Dim dsIRSAccAccountReportSecurities As New DataSet
        Dim dtIRSAccAccountReportSecurities As New DataTable
        Dim dsIRSAccAccountReportFutures As New DataSet
        Dim dtIRSAccAccountReportFutures As New DataTable

        Dim dsIRSAccGroupReportSecurities As New DataSet
        Dim dtIRSAccGroupReportSecurities As New DataTable
        Dim dsIRSAccGroupReportFutures As New DataSet
        Dim dtIRSAccGroupReportFutures As New DataTable

        Dim dsAccountReportSecurities As New DataSet
        Dim dtAccountReportSecurities As New DataTable
        Dim dsAccountReportFutures As New DataSet
        Dim dtAccountReportFutures As New DataTable

        Dim dsGroupReportSecurities As New DataSet
        Dim dtGroupReportSecurities As New DataTable
        Dim dsGroupReportFutures As New DataSet
        Dim dtGroupReportFutures As New DataTable

        Try
            If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
                If rbAccountReport.Checked = True Then
                    If rbSecurities.Checked = True Then

                
                        dsAccountReportSecurities = clsIRS.lFnGetFATCAAccSecurities(sFinancialYear, sCurr)

                        If dsAccountReportSecurities IsNot Nothing And dsAccountReportSecurities.Tables.Count > 0 Then
                            dtAccountReportSecurities = dsAccountReportSecurities.Tables(0)
                        End If
                        If dtAccountReportSecurities.Rows.Count > 0 Then
                            bSecuritiesAccountReportSuccess = GenerateXML(dtAccountReportSecurities, sSecuritiesCompany, GStrExptDir & sIRSFolderPathAccountReport & strSecuritiesExFile)
                            If bSecuritiesAccountReportSuccess Then
                                bSecuritiesAccountReportSuccess = False
                                bSecuritiesAccountReportSuccess = Validate1(strSecuritiesExFile, sIRSFolderPathAccountReport)
                                If bSecuritiesAccountReportSuccess Then
                                    GSubShowInfo(GFncGetSysMsg(28))
                                End If
                            End If
                        Else
                            GSubWriteEventLog(GFncGetSysMsg(2), GStrEPath)
                            GSubShowInfo(GFncGetSysMsg(2))
                        End If
                    ElseIf rbFutures.Checked = True Then

                        dsAccountReportFutures = clsIRS.lFnGetFATCAAccFutures(sFinancialYear, sCurr)
                        If dsAccountReportFutures IsNot Nothing And dsAccountReportFutures.Tables.Count > 0 Then
                            dtAccountReportFutures = dsAccountReportFutures.Tables(0)

                        End If
                        If dtAccountReportFutures.Rows.Count > 0 Then
                            bFuturesAccountReportSuccess = GenerateXML(dtAccountReportFutures, sFuturesCompany, GStrExptDir & sIRSFolderPathAccountReport & strFuturesExFile)
                            If bFuturesAccountReportSuccess Then
                                bFuturesAccountReportSuccess = False
                                bFuturesAccountReportSuccess = Validate1(strFuturesExFile, sIRSFolderPathAccountReport)
                                If bFuturesAccountReportSuccess Then
                                    GSubShowInfo(GFncGetSysMsg(28))
                                End If
                            End If
                        Else
                            GSubWriteEventLog(GFncGetSysMsg(2), GStrEPath)
                            GSubShowInfo(GFncGetSysMsg(2))
                        End If

                    End If

                ElseIf rbPoolReport.Checked = True Then

                    If rbSecurities.Checked = True Then

                        dsGroupReportSecurities = clsIRS.lFnGetFATCAAccGroupSecurities(sFinancialYear, sCurr)
                        If dtGroupReportSecurities IsNot Nothing And dsGroupReportSecurities.Tables.Count > 0 Then
                            dtGroupReportSecurities = dsGroupReportSecurities.Tables(0)
                        End If
                        If dtGroupReportSecurities.Rows.Count > 0 Then
                            bSecuritiesGroupReportSuccess = GeneratePoolReportXML(dtGroupReportSecurities, sSecuritiesCompany, sFATCAAccType, iNumCount, GStrExptDir & sIRSFolderPathPoolReport & strGroupSecuritiesExFile)
                            If bSecuritiesGroupReportSuccess Then
                                bSecuritiesGroupReportSuccess = False
                                bSecuritiesGroupReportSuccess = Validate1(strGroupSecuritiesExFile, sIRSFolderPathPoolReport)
                                If bSecuritiesGroupReportSuccess Then
                                    GSubShowInfo(GFncGetSysMsg(28))
                                End If
                            End If
                        Else
                            GSubWriteEventLog(GFncGetSysMsg(2), GStrEPath)
                            GSubShowInfo(GFncGetSysMsg(2))
                        End If

                    ElseIf rbFutures.Checked = True Then

                        dsGroupReportFutures = clsIRS.lFnGetFATCAAccGroupFutures(sFinancialYear, sCurr)
                        If dsGroupReportFutures IsNot Nothing And dsGroupReportFutures.Tables.Count > 0 Then
                            dtGroupReportFutures = dsGroupReportFutures.Tables(0)
                        End If
                        If dtGroupReportFutures.Rows.Count > 0 Then
                            bFuturesGroupReportSuccess = GeneratePoolReportXML(dtGroupReportFutures, sFuturesCompany, sFATCAAccType, iNumCount, GStrExptDir & sIRSFolderPathPoolReport & strGroupFuturesExFile)
                            If bFuturesGroupReportSuccess Then
                                bFuturesGroupReportSuccess = False
                                bFuturesGroupReportSuccess = Validate1(strGroupFuturesExFile, sIRSFolderPathPoolReport)
                                If bFuturesGroupReportSuccess Then
                                    GSubShowInfo(GFncGetSysMsg(28))
                                End If
                            End If
                        Else
                            GSubWriteEventLog(GFncGetSysMsg(2), GStrEPath)
                            GSubShowInfo(GFncGetSysMsg(2))
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            GSubWriteErrLog(ex.Message.ToString, GStrEPath)

            GSubShowWarn(ex.Message)
        End Try




    End Sub

    Private Function GenerateXML(ByVal dt As DataTable, ByVal company As String, ByVal strExFile As String)
        Dim sCompany As String = String.Empty
        Dim sAccNo As String = String.Empty
        Dim sGIIN As String = String.Empty
        Dim sTIN As String = String.Empty
        Dim sname_1 As String = String.Empty
        Dim snd_addr_1 As String = String.Empty

        Dim sDob As String = "1900-01-01"
        Dim dtDob As DateTime = Date.Now
        Dim iNature As String = 0
        Dim sAcBal As String = String.Empty

        Dim dtLastProcessTime As String
        Dim sLastProcessTime As String
        dtLastProcessTime = Date.Now
        sLastProcessTime = Format(Date.Now, "yyyy-MM-ddThh:mm:ss").ToString
        Dim sFATCA_acc_type As String = String.Empty
        Dim sCountryCode As String = String.Empty
        Dim iCounter As Integer = 1

        Dim writer As XmlTextWriter = Nothing
        Try
            If dt.Rows.Count > 0 Then
                writer = New XmlTextWriter(strExFile, System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2

                writer.WriteStartElement("ftc", "FATCA_OECD", "urn:oecd:ties:fatca:v1") 'start FATCA_OECD

                writer.WriteAttributeString("xmlns", "iso", "http://www.w3.org/2000/xmlns/", "urn:oecd:ties:isofatcatypes:v1")
                writer.WriteAttributeString("xmlns", "sfa", "http://www.w3.org/2000/xmlns/", "urn:oecd:ties:stffatcatypes:v1")
                writer.WriteAttributeString("xmlns", "stf", "http://www.w3.org/2000/xmlns/", "urn:oecd:ties:stf:v4")
                writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                writer.WriteAttributeString("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "urn:oecd:ties:fatca:v1 FatcaXML_v1.1.xsd ")

                writer.WriteStartElement("ftc", "MessageSpec", Nothing) 'start MessageSpec

                writer.WriteStartElement("sfa", "SendingCompanyIN", Nothing)
                writer.WriteString(company)
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "TransmittingCountry", Nothing)
                writer.WriteString("HK")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "ReceivingCountry", Nothing)
                writer.WriteString("US")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "MessageType", Nothing)
                writer.WriteString("FATCA")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "Contact", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "MessageRefId", Nothing) '[FATCA-YYYYY-MM-DDTHH:MM:SS]
                writer.WriteString("FATCA-" & sLastProcessTime)
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "CorrMessageRefId", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "ReportingPeriod", Nothing)
                writer.WriteString(sFinancialYear)
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "Timestamp", Nothing)
                writer.WriteString(sLastProcessTime)
                writer.WriteEndElement()

                writer.WriteEndElement() ' end MessageSpec

                writer.WriteStartElement("ftc", "FATCA", Nothing) 'start FATCA

                writer.WriteStartElement("ftc", "ReportingFI", Nothing) 'start ReportingFI

                writer.WriteStartElement("sfa", "ResCountryCode", Nothing)
                writer.WriteString("HK")
                writer.WriteEndElement()
                'writer.WriteStartElement("sfa", "TIN", Nothing)
                'writer.WriteString("163")
                'writer.WriteEndElement()
                If Not String.IsNullOrEmpty(dt.Rows.Item(0).Item("Name")) Then
                    sCompany = dt.Rows.Item(0).Item("Name").ToString.Trim
                Else
                    sCompany = ""
                End If
                writer.WriteStartElement("sfa", "Name", Nothing)
                writer.WriteString(sCompany)
                writer.WriteEndElement()
                'start Address
                writer.WriteStartElement("sfa", "Address", Nothing)
                writer.WriteStartElement("sfa", "CountryCode", Nothing)
                writer.WriteString("HK")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "AddressFree", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteEndElement()
                'end address
                'start DocSpec
                writer.WriteStartElement("ftc", "DocSpec", Nothing)
                writer.WriteStartElement("ftc", "DocTypeIndic", Nothing)
                writer.WriteString("FATCA1")
                writer.WriteEndElement()
                writer.WriteStartElement("ftc", "DocRefId", Nothing)
                writer.WriteString("FATCA-" & sLastProcessTime)
                writer.WriteEndElement()
                writer.WriteStartElement("ftc", "CorrMessageRefId", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteStartElement("ftc", "CorrDocRefId", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteEndElement()
                'end DocSpec

                writer.WriteEndElement() 'end ReportingFI
                For Each row As DataRow In dt.Rows
                    If Not row.IsNull(dt.Columns("name")) Then
                        sCompany = row("name").ToString.Trim
                    Else
                        sCompany = ""
                    End If
                    If Not row.IsNull(dt.Columns("accno")) Then
                        sAccNo = row("accno").ToString.Trim
                    Else
                        sAccNo = ""
                    End If
                    If Not row.IsNull(dt.Columns("name_1")) Then
                        sname_1 = row("name_1").ToString.Trim
                    Else
                        sname_1 = ""
                    End If
                    If Not row.IsNull(dt.Columns("nature")) Then
                        iNature = Convert.ToInt16(row("nature").ToString.Trim)
                    Else
                        iNature = 0
                    End If
                    If Not row.IsNull(dt.Columns("us_tin")) Then
                        sTIN = row("us_tin").ToString.Trim
                    Else
                        sTIN = ""
                    End If
                    If Not row.IsNull(dt.Columns("FATCA_GIIN")) Then
                        sGIIN = row("FATCA_GIIN").ToString.Trim
                    Else
                        sGIIN = ""
                    End If
                    If Not row.IsNull(dt.Columns("addr_1")) Then
                        snd_addr_1 = row("addr_1").ToString.Trim
                    Else
                        snd_addr_1 = ""
                    End If

                    If Not row.IsNull(dt.Columns("dob")) Then
                        sDob = row("dob").ToString
                        If Not String.IsNullOrEmpty(sDob) Then
                            dtDob = Convert.ToDateTime(sDob)
                            sDob = Format(dtDob, "yyyy-MM-dd").ToString
                        Else
                            sDob = "1900-01-01"
                        End If
                    Else
                        sDob = "1900-01-01"
                    End If
                    If Not row.IsNull(dt.Columns("acbal")) Then
                        sAcBal = row("acbal").ToString.Trim
                    Else
                        sAcBal = "0"
                    End If

                    If Not row.IsNull(dt.Columns("IRSFatcaAccType")) Then
                        sFATCA_acc_type = row("IRSFatcaAccType").ToString.Trim
                        If Not String.IsNullOrEmpty(sFATCA_acc_type) Then

                        Else
                            sFATCA_acc_type = "FATCA101" 'default
                        End If

                    Else
                        sFATCA_acc_type = "FATCA101" 'default
                    End If
                    If Not row.IsNull(dt.Columns("CountryCode")) Then
                        sCountryCode = row("CountryCode").ToString.Trim
                    Else
                        sCountryCode = ""
                    End If



                    writer.WriteStartElement("ftc", "ReportingGroup", Nothing) 'start ReportingGroup 
                    writer.WriteStartElement("ftc", "AccountReport", Nothing) 'start AccountReport 

                    writer.WriteStartElement("ftc", "DocSpec", Nothing) 'start DocSpec 
                    writer.WriteStartElement("ftc", "DocTypeIndic", Nothing)
                    writer.WriteString("FATCA1")
                    writer.WriteEndElement()
                    writer.WriteStartElement("ftc", "DocRefId", Nothing)
                    writer.WriteString(iCounter)
                    writer.WriteEndElement()
                    writer.WriteStartElement("ftc", "CorrMessageRefId", Nothing)
                    writer.WriteString("")
                    writer.WriteEndElement()
                    writer.WriteStartElement("ftc", "CorrDocRefId", Nothing)
                    writer.WriteString("")
                    writer.WriteEndElement()
                    writer.WriteEndElement() 'end DocSpec 

                    writer.WriteStartElement("ftc", "AccountNumber", Nothing) 'start AccountNumber 
                    writer.WriteString(sAccNo)
                    writer.WriteEndElement() 'end AccountNumber 

                    writer.WriteStartElement("ftc", "AccountHolder", Nothing) 'start AccountHolder 
                    If iNature = 0 Or iNature = 1 Then 'individual or joint
                        writer.WriteStartElement("ftc", "Individual", Nothing) 'start Individual
                        writer.WriteStartElement("sfa", "ResCountryCode", Nothing)
                        writer.WriteString(sCountryCode)
                        writer.WriteEndElement()
                        If sTIN <> "" Then
                            writer.WriteStartElement("sfa", "TIN", Nothing)
                            writer.WriteString(sTIN)
                            writer.WriteEndElement()
                        End If

                        writer.WriteStartElement("sfa", "Name", Nothing) ' start Name
                        writer.WriteStartElement("sfa", "PrecedingTitle", Nothing) ' start PrecedingTitle
                        writer.WriteString("")
                        writer.WriteEndElement() ' end PrecedingTitle
                        writer.WriteStartElement("sfa", "Title", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "FirstName", Nothing)
                        writer.WriteString(sname_1)
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "MiddleName", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "NamePrefix", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "LastName", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "GenerationIdentifier", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "Suffix", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteStartElement("sfa", "GeneralSuffix", Nothing)
                        writer.WriteString("")
                        writer.WriteEndElement()
                        writer.WriteEndElement()  ' end Name

                        writer.WriteStartElement("sfa", "Address", Nothing) ' start Address
                        writer.WriteStartElement("sfa", "CountryCode", Nothing) ' start CountryCode
                        writer.WriteString(sCountryCode)
                        writer.WriteEndElement() ' end CountryCode
                        writer.WriteStartElement("sfa", "AddressFree", Nothing)

                        writer.WriteString(snd_addr_1)

                        writer.WriteEndElement()
                        writer.WriteEndElement()  ' end Address

                        'writer.WriteStartElement("sfa", "Nationality", Nothing) ' start Nationality
                        'writer.WriteString("HK")
                        'writer.WriteEndElement() ' end Nationality

                        writer.WriteStartElement("sfa", "BirthInfo", Nothing) ' start BirthInfo
                        writer.WriteStartElement("sfa", "BirthDate", Nothing) ' start BirthDate
                        writer.WriteString(sDob)
                        writer.WriteEndElement() ' end BirthDate
                        writer.WriteStartElement("sfa", "City", Nothing) ' start City
                        writer.WriteString("")
                        writer.WriteEndElement() ' end City
                        writer.WriteStartElement("sfa", "CitySubentity", Nothing) ' start CitySubentity
                        writer.WriteString("")
                        writer.WriteEndElement() ' end CitySubentity
                        writer.WriteStartElement("sfa", "CountryInfo", Nothing) ' start CountryInfo
                        writer.WriteStartElement("sfa", "CountryCode", Nothing) ' start CountryCode
                        writer.WriteString(sCountryCode)
                        writer.WriteEndElement() ' end CountryCode
                        writer.WriteEndElement() ' end CountryInfo

                        writer.WriteEndElement() ' end BirthInfo                   

                        writer.WriteEndElement() 'end Individual 
                    ElseIf iNature = 2 Then 'corporate
                        writer.WriteStartElement("ftc", "Organisation", Nothing) 'start Organisation

                        writer.WriteStartElement("sfa", "ResCountryCode", Nothing) ' start ResCountryCode
                        writer.WriteString(sCountryCode)
                        writer.WriteEndElement() ' end ResCountryCode
                        If sTIN <> "" Then
                            writer.WriteStartElement("sfa", "TIN", Nothing) ' start TIN
                            writer.WriteString(sTIN)
                            writer.WriteEndElement() ' end TIN
                        End If

                        writer.WriteStartElement("sfa", "Name", Nothing) 'start Name
                        writer.WriteString(sname_1)
                        writer.WriteEndElement() 'end Name

                        writer.WriteStartElement("sfa", "Address", Nothing) ' start Address

                        writer.WriteStartElement("sfa", "CountryCode", Nothing) ' start CountryCode
                        writer.WriteString(sCountryCode)
                        writer.WriteEndElement() ' end CountryCode
                        writer.WriteStartElement("sfa", "AddressFree", Nothing) ' start AddressFree
                        writer.WriteString(snd_addr_1)
                        writer.WriteEndElement() 'end AddressFree

                        writer.WriteEndElement()  ' end Address

                        writer.WriteEndElement() 'end Organisation

                        writer.WriteStartElement("ftc", "AcctHolderType", Nothing) 'start AcctHolderType
                        writer.WriteString(sFATCA_acc_type)
                        writer.WriteEndElement()  ' end AcctHolderType
                    End If

                    writer.WriteEndElement() 'end AccountHolder 

                    writer.WriteStartElement("ftc", "SubstantialOwner", Nothing) ' start SubstantialOwner

                    writer.WriteStartElement("sfa", "ResCountryCode", Nothing) ' start ResCountryCode
                    writer.WriteString(sCountryCode)
                    writer.WriteEndElement() 'end ResCountryCode
                    If sTIN <> "" Then
                        writer.WriteStartElement("sfa", "TIN", Nothing) ' start TIN
                        writer.WriteString(sTIN)
                        writer.WriteEndElement() 'end TIN
                    End If


                    writer.WriteStartElement("sfa", "Name", Nothing) ' start Name
                    writer.WriteStartElement("sfa", "PrecedingTitle", Nothing) ' start PrecedingTitle
                    writer.WriteString("")
                    writer.WriteEndElement() 'end PrecedingTitle
                    writer.WriteStartElement("sfa", "Title", Nothing) ' start Title
                    writer.WriteString("")
                    writer.WriteEndElement() 'end Title
                    writer.WriteStartElement("sfa", "FirstName", Nothing) ' start FirstName
                    writer.WriteString("")
                    writer.WriteEndElement() 'end FirstName
                    writer.WriteStartElement("sfa", "MiddleName", Nothing) ' start MiddleName
                    writer.WriteString("")
                    writer.WriteEndElement() 'end MiddleName
                    writer.WriteStartElement("sfa", "NamePrefix", Nothing) ' start NamePrefix
                    writer.WriteString("")
                    writer.WriteEndElement() 'end NamePrefix
                    writer.WriteStartElement("sfa", "LastName", Nothing) ' start LastName
                    writer.WriteString("")
                    writer.WriteEndElement() 'end LastName
                    writer.WriteStartElement("sfa", "GenerationIdentifier", Nothing) ' start GenerationIdentifier
                    writer.WriteString("")
                    writer.WriteEndElement() 'end GenerationIdentifier
                    writer.WriteStartElement("sfa", "Suffix", Nothing) ' start Suffix
                    writer.WriteString("")
                    writer.WriteEndElement() 'end Suffix
                    writer.WriteStartElement("sfa", "GeneralSuffix", Nothing) ' start GeneralSuffix
                    writer.WriteString("")
                    writer.WriteEndElement() 'end GeneralSuffix
                    writer.WriteEndElement() 'end Name
                    writer.WriteStartElement("sfa", "Address", Nothing) ' start Address
                    writer.WriteStartElement("sfa", "CountryCode", Nothing) ' start CountryCode
                    writer.WriteString(sCountryCode)
                    writer.WriteEndElement() 'end CountryCode
                    writer.WriteStartElement("sfa", "AddressFree", Nothing) ' start AddressFree

                    writer.WriteString(snd_addr_1)

                    writer.WriteEndElement() 'end AddressFree
                    writer.WriteEndElement() 'end Address
                    'writer.WriteStartElement("sfa", "Nationality", Nothing) ' start Nationality
                    'writer.WriteString("AF")
                    'writer.WriteEndElement() 'end Nationality
                    writer.WriteStartElement("sfa", "BirthInfo", Nothing) ' start BirthInfo
                    writer.WriteStartElement("sfa", "BirthDate", Nothing) ' start BirthDate
                    writer.WriteString(sDob)
                    writer.WriteEndElement() 'end BirthDate
                    writer.WriteStartElement("sfa", "City", Nothing) ' start City
                    writer.WriteString("")
                    writer.WriteEndElement() 'end City
                    writer.WriteStartElement("sfa", "CitySubentity", Nothing) ' start CitySubentity
                    writer.WriteString("")
                    writer.WriteEndElement() 'end CitySubentity
                    writer.WriteStartElement("sfa", "CountryInfo", Nothing) ' start CountryInfo
                    writer.WriteStartElement("sfa", "CountryCode", Nothing) ' start CountryCode
                    writer.WriteString(sCountryCode)
                    writer.WriteEndElement() 'end CountryCode
                    writer.WriteEndElement() 'end CountryInfo
                    writer.WriteEndElement() 'end BirthInfo

                    writer.WriteEndElement() 'end SubstantialOwner

                    writer.WriteStartElement("ftc", "AccountBalance", Nothing) ' start AccountBalance
                    writer.WriteAttributeString("currCode", sCurr)
                    writer.WriteString(Math.Round(Convert.ToDecimal(sAcBal), 2))
                    writer.WriteEndElement() 'end AccountBalance

                    writer.WriteStartElement("ftc", "Payment", Nothing) ' start Payment
                    writer.WriteStartElement("ftc", "Type", Nothing) ' start Type
                    writer.WriteString("FATCA501")
                    writer.WriteEndElement() 'end Type
                    writer.WriteStartElement("ftc", "PaymentAmnt", Nothing) ' start PaymentAmnt
                    writer.WriteAttributeString("currCode", sCurr)
                    writer.WriteString("0.00")
                    writer.WriteEndElement() 'end PaymentAmnt
                    writer.WriteEndElement() 'end Payment

                    writer.WriteEndElement() 'end AccountReport  
                    writer.WriteEndElement() 'end ReportingGroup


                    iCounter = iCounter + 1
                    writer.Flush()


                Next
                writer.WriteEndElement() 'end FATCA

                writer.WriteEndElement()  'end FATCA_OECD

                writer.WriteEndDocument()
                'GSubWriteEventLog(strExFile & " generated", GStrEPath)
                writer.Close()
            End If
            Return True
        Catch ex As Exception
            GSubWriteErrLog("Generate XML is failed : " & ex.Message.ToString, GStrEPath)
            If writer IsNot Nothing Then
                writer.Close()
            End If
            GSubShowWarn("Generate XML is failed : " & ex.Message)
            Return False
        End Try


    End Function

    Private Function GeneratePoolReportXML(ByVal dt As DataTable, ByVal company As String, ByVal sFATCAAccType As String, ByVal iNumCount As Integer, ByVal strExFile As String)
        Dim sCompany As String = String.Empty

        Dim sFATCA_acc_type As String = String.Empty

        Dim sAcBal As String = String.Empty
        Dim sRecordCount As String = String.Empty

        Dim dtLastProcessTime As String
        Dim sLastProcessTime As String
        dtLastProcessTime = Date.Now
        sLastProcessTime = Format(Date.Now, "yyyy-MM-ddThh:mm:ss").ToString

        Dim iCounter As Integer = 1

        Dim writer As XmlTextWriter = Nothing
        Try
            If dt.Rows.Count > 0 Then
                writer = New XmlTextWriter(strExFile, System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2



                writer.WriteStartElement("ftc", "FATCA_OECD", "urn:oecd:ties:fatca:v1") 'start FATCA_OECD

                writer.WriteAttributeString("xmlns", "iso", "http://www.w3.org/2000/xmlns/", "urn:oecd:ties:isofatcatypes:v1")
                writer.WriteAttributeString("xmlns", "sfa", "http://www.w3.org/2000/xmlns/", "urn:oecd:ties:stffatcatypes:v1")
                writer.WriteAttributeString("xmlns", "stf", "http://www.w3.org/2000/xmlns/", "urn:oecd:ties:stf:v4")
                writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                writer.WriteAttributeString("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "urn:oecd:ties:fatca:v1 FatcaXML_v1.1.xsd ")

                writer.WriteStartElement("ftc", "MessageSpec", Nothing) 'start MessageSpec

                writer.WriteStartElement("sfa", "SendingCompanyIN", Nothing)
                writer.WriteString(company)
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "TransmittingCountry", Nothing)
                writer.WriteString("HK")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "ReceivingCountry", Nothing)
                writer.WriteString("US")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "MessageType", Nothing)
                writer.WriteString("FATCA")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "Contact", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "MessageRefId", Nothing)
                writer.WriteString("FATCA-" & sLastProcessTime)
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "CorrMessageRefId", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "ReportingPeriod", Nothing)
                writer.WriteString(sFinancialYear)
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "Timestamp", Nothing)
                writer.WriteString(sLastProcessTime)
                writer.WriteEndElement()

                writer.WriteEndElement() ' end MessageSpec

                writer.WriteStartElement("ftc", "FATCA", Nothing) 'start FATCA

                writer.WriteStartElement("ftc", "ReportingFI", Nothing) 'start ReportingFI

                writer.WriteStartElement("sfa", "ResCountryCode", Nothing)
                writer.WriteString("HK")
                writer.WriteEndElement()
                'writer.WriteStartElement("sfa", "TIN", Nothing)
                'writer.WriteString("163")
                'writer.WriteEndElement()
                If Not String.IsNullOrEmpty(dt.Rows.Item(0).Item("Name")) Then
                    sCompany = dt.Rows.Item(0).Item("Name").ToString.Trim
                Else
                    sCompany = ""
                End If
                writer.WriteStartElement("sfa", "Name", Nothing)
                writer.WriteString(sCompany)
                writer.WriteEndElement()
                'start Address
                writer.WriteStartElement("sfa", "Address", Nothing)
                writer.WriteStartElement("sfa", "CountryCode", Nothing)
                writer.WriteString("HK")
                writer.WriteEndElement()
                writer.WriteStartElement("sfa", "AddressFree", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteEndElement()
                'end address
                'start DocSpec
                writer.WriteStartElement("ftc", "DocSpec", Nothing)
                writer.WriteStartElement("ftc", "DocTypeIndic", Nothing)
                writer.WriteString("FATCA1")
                writer.WriteEndElement()
                writer.WriteStartElement("ftc", "DocRefId", Nothing)
                writer.WriteString("FATCA-" & sLastProcessTime)
                writer.WriteEndElement()
                writer.WriteStartElement("ftc", "CorrMessageRefId", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteStartElement("ftc", "CorrDocRefId", Nothing)
                writer.WriteString("")
                writer.WriteEndElement()
                writer.WriteEndElement()
                'end DocSpec

                writer.WriteEndElement() 'end ReportingFI

                For Each row As DataRow In dt.Rows
                    If Not row.IsNull(dt.Columns("name")) Then
                        sCompany = row("name").ToString.Trim
                    Else
                        sCompany = ""
                    End If

                    If Not row.IsNull(dt.Columns("IRSFatcaAccType")) Then
                        sFATCA_acc_type = row("IRSFatcaAccType").ToString.Trim
                        If Not String.IsNullOrEmpty(sFATCA_acc_type) Then

                        Else
                            sFATCA_acc_type = "FATCA201" 'default
                        End If

                    Else
                        sFATCA_acc_type = "FATCA201" 'default
                    End If

                    If Not row.IsNull(dt.Columns("acbal")) Then
                        sAcBal = row("acbal").ToString.Trim
                    Else
                        sAcBal = "0"
                    End If


                    If Not row.IsNull(dt.Columns("cnt")) Then
                        sRecordCount = row("cnt").ToString.Trim
                    Else
                        sRecordCount = "0"
                    End If



                    writer.WriteStartElement("ftc", "ReportingGroup", Nothing) 'start ReportingGroup 

                    writer.WriteStartElement("ftc", "PoolReport", Nothing) ' start PoolReport

                    writer.WriteStartElement("ftc", "DocSpec", Nothing) ' start DocSpec
                    writer.WriteStartElement("ftc", "DocTypeIndic", Nothing) ' start DocTypeIndic
                    writer.WriteString("FATCA1")
                    writer.WriteEndElement() ' end DocTypeIndic
                    writer.WriteStartElement("ftc", "DocRefId", Nothing) ' start DocRefId
                    writer.WriteString(iCounter)
                    writer.WriteEndElement() ' end DocTypeIndic
                    writer.WriteStartElement("ftc", "CorrMessageRefId", Nothing) ' start CorrMessageRefId
                    writer.WriteString("")
                    writer.WriteEndElement() ' end CorrMessageRefId
                    writer.WriteStartElement("ftc", "CorrDocRefId", Nothing) ' start CorrDocRefId
                    writer.WriteString("")
                    writer.WriteEndElement() ' end CorrDocRefId
                    writer.WriteEndElement() ' end DocSpec

                    writer.WriteStartElement("ftc", "AccountCount", Nothing) ' start AccountCount
                    writer.WriteString(sRecordCount)
                    writer.WriteEndElement() ' end AccountCount
                    writer.WriteStartElement("ftc", "AccountPoolReportType", Nothing) ' start AccountCount
                    writer.WriteString(sFATCA_acc_type)
                    writer.WriteEndElement() ' end AccountPoolReportType
                    writer.WriteStartElement("ftc", "PoolBalance", Nothing) ' start PoolBalance
                    writer.WriteAttributeString("currCode", sCurr)
                    writer.WriteString(Math.Round(Convert.ToDecimal(sAcBal), 2))
                    writer.WriteEndElement() ' end PoolBalance

                    writer.WriteEndElement() ' end PoolReport


                    writer.WriteEndElement() 'end ReportingGroup


                    iCounter = iCounter + 1
                    writer.Flush()
                    'GSubWriteEventLog(strExFile & " generated", GStrEPath)
                Next
                writer.WriteEndElement() 'end FATCA

                writer.WriteEndElement()  'end FATCA_OECD

                writer.WriteEndDocument()


                writer.Close()
            End If
            Return True
        Catch ex As Exception
            GSubWriteErrLog("Generate pool XML is failed : " & ex.Message.ToString, GStrEPath)
            If writer IsNot Nothing Then
                writer.Close()
            End If
            GSubShowWarn("Generate pool XML is failed : " & ex.Message)

            Return False
        End Try

    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Function Validate1(ByVal strFile As String, ByVal sIRSFolderPath As String) As Boolean

        Dim sErrorText As String
        Dim bSuccess As Boolean
        Dim xmlvalidate As New XmlValidationErrorBuilder
        Try

            sErrorText = xmlvalidate.LoadValidatedXmlDocument(GStrExptDir & sIRSFolderPath & strFile, Application.StartupPath & "\xsl\FatcaXML_v1.1.xsd", Application.StartupPath & "\xsl\isofatcatypes_v1.0.xsd", Application.StartupPath & "\xsl\oecdtypes_v4.1.xsd", Application.StartupPath & "\xsl\stffatcatypes_v1.1.xsd")

            Dim myString As String = Application.StartupPath


            If String.IsNullOrEmpty(sErrorText) Then

                'GSubWriteEventLog("Validation successfully", GStrEPath)
                bSuccess = True
            Else
                GSubShowInfo("Validation is failed : " & sErrorText)
                GSubWriteEventLog("Validation is failed : " & sErrorText, GStrEPath)
                bSuccess = False
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message.ToString, GStrEPath)
            GSubShowWarn(ex.Message)
            bSuccess = False
        End Try


        Return bSuccess

    End Function
    Private Function Validate2(ByVal strFile As String, ByVal sIRSFolderPath As String) As Boolean

        Dim sErrorText As String
        Dim bSuccess As Boolean
        Dim xmlvalidate As New XmlValidationErrorBuilder
        Try

            sErrorText = xmlvalidate.LoadValidatedXmlDocument(GStrExptDir & sIRSFolderPath & strFile, Application.StartupPath & "\xsl\FATCA-IDES-SenderFileMetadata-1.0.xsd")

            Dim myString As String = Application.StartupPath


            If String.IsNullOrEmpty(sErrorText) Then

                'GSubWriteEventLog("Validation successfully", GStrEPath)
                bSuccess = True
            Else
                GSubShowInfo("Validation is failed : " & sErrorText)
                GSubWriteEventLog("Validation is failed : " & sErrorText, GStrEPath)
                bSuccess = False
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message.ToString, GStrEPath)
            GSubShowWarn(ex.Message)
            bSuccess = False
        End Try


        Return bSuccess

    End Function

    Private Function SignXml(ByVal strFile As String, ByVal sIRSFolderPath As String, ByVal sCertPath As String) As Boolean

        Dim rsakey As RSACryptoServiceProvider

        Dim bSuccess As Boolean

        Dim xmlDoc As New XmlDocument()


        Try

            Dim cert As X509Certificate2 = New X509Certificate2(sCertPath, sCertPassword)


            rsakey = CType(cert.PrivateKey, RSACryptoServiceProvider)

            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load(GStrExptDir & sIRSFolderPath & strFile)

            ' Check arguments. 
            If xmlDoc Is Nothing Then
                Throw New ArgumentException("xmlDoc")
            End If
            If rsakey Is Nothing Then
                Throw New ArgumentException("Key")
            End If
            ' Create a SignedXml object. 
            Dim signedXml As New SignedXml(xmlDoc)
            ' Add the key to the SignedXml document.
            signedXml.SigningKey = rsakey
            ' Create a reference to be signed. 
            Dim reference As New Reference()
            reference.Uri = ""
            Dim keyInfo As New KeyInfo()
            keyInfo.AddClause(New RSAKeyValue(CType(rsakey, RSA)))
            signedXml.KeyInfo = keyInfo


            keyInfo.AddClause(New KeyInfoX509Data(cert))
            ' Add an enveloped transformation to the reference. 
            Dim env As New XmlDsigEnvelopedSignatureTransform()
            reference.AddTransform(env)
            ' Add the reference to the SignedXml object.
            signedXml.AddReference(reference)
            ' Compute the signature.
            signedXml.ComputeSignature()
            ' Get the XML representation of the signature and save 
            ' it to an XmlElement object. 
            Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
            ' Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))
            If TypeOf xmlDoc.FirstChild Is XmlDeclaration Then
                xmlDoc.RemoveChild(xmlDoc.FirstChild)
            End If
            xmlDoc.Save(GStrExptDir & sIRSFolderPath & strFile)
            'GSubWriteEventLog("Sign successfully", GStrEPath)
            bSuccess = True
            Return bSuccess


        Catch ex As Exception
            GSubWriteErrLog("Sign is failed : " & ex.Message.ToString, GStrEPath)
            GSubShowWarn("Sign is failed : " & ex.Message)
            bSuccess = False
            Return bSuccess
        End Try


    End Function


    Private Function Compress(ByVal strFile As String, ByVal sIRSFolderPath As String) As Boolean
        Dim bSuccess As Boolean
        Dim fi As New IO.FileInfo(GStrExptDir & sIRSFolderPath & strFile)

        Dim filename As String
        filename = fi.FullName.ToString
        filename = filename.Substring(0, filename.IndexOf(".xml"))
        Try

            Dim Zip As ZipFile = New ZipFile()

            Zip.AddFile(GStrExptDir & sIRSFolderPath & strFile, "")
            Zip.Save(filename & ".zip")



            bSuccess = True
            Return bSuccess
        Catch ex As Exception
            GSubWriteErrLog("Zip is failed : " & ex.Message.ToString, GStrEPath)
            GSubShowWarn("Zip is failed : " & ex.Message)
            bSuccess = False
            Return bSuccess
        End Try

    End Function


    Private Function Encrypt(ByVal strInputFile As String, ByVal strFile As String, ByVal sIRSFolderPath As String, ByVal sKey As String) As Boolean

        Dim bSuccess As Boolean

        Try

            Encrypted(GStrExptDir & sIRSFolderPath & strInputFile.Substring(0, strInputFile.IndexOf(".xml")) & ".zip", GStrExptDir & sIRSFolderPath & strFile, sKey)
            'GSubWriteEventLog("Encrypt successfully", GStrEPath)
            bSuccess = True
            Return bSuccess
        Catch ex As Exception
            GSubWriteErrLog("Encrypt is failed : " & ex.Message.ToString, GStrEPath)
            GSubShowWarn("Encrypt is failed : " & ex.Message)
            bSuccess = False
            Return bSuccess
        End Try
    End Function

    Public Sub Encrypted(ByVal path As String, byvaloutpath As String, ByVal secretKey As String)
        Dim fsInput As System.IO.FileStream
        Dim fsOutput As System.IO.FileStream

        fsInput = New System.IO.FileStream(path, FileMode.Open, _
                                           FileAccess.Read)
        fsOutput = New System.IO.FileStream(byvaloutpath, FileMode.OpenOrCreate, _
                                            FileAccess.Write)
        fsOutput.SetLength(0) 'make sure fsOutput is empty


        Dim UniEncoding As New UnicodeEncoding

        Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing
        Dim lngFileLength As Long = fsInput.Length 'the input file's length
        Dim intBytesInCurrentBlock As Integer 'current bytes being processed
        Dim lngBytesProcessed As Long = 0 'running count of bytes processed
        Dim cryptoStream As CryptoStream

        Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
        cryptoStream = New CryptoStream(fsOutput, algorithm.CreateEncryptor(), CryptoStreamMode.Write)

        While lngBytesProcessed < lngFileLength

            intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)

            cryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)

            lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)

        End While

        'cryptoStream.FlushFinalBlock()
        'encryptedPassword = outputStream.ToArray()

        cryptoStream.Close()
        fsInput.Close()
        fsOutput.Close()

        'start Delete the zip after encrypt
        My.Computer.FileSystem.DeleteFile(path, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
        'end Delete the zip after encrypt
    End Sub

    Private Function getAlgorithm(ByVal secretKey As String) As RijndaelManaged
        Const salt As String = "put your salt here"
        Const keySize As Integer = 256

        Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(salt))
        algorithm = New RijndaelManaged()
        algorithm.KeySize = keySize
        algorithm.IV = keyBuilder.GetBytes(CType(algorithm.BlockSize / 8, Integer))
        algorithm.Key = keyBuilder.GetBytes(CType(algorithm.KeySize / 8, Integer))
        algorithm.Padding = PaddingMode.PKCS7

        Return algorithm
    End Function
    Private Function GenerateMetaXML(ByVal sCompany As String, ByVal IRSXMLfile As String, ByVal strExFile As String, ByVal sIRSFolderPath As String) As Boolean

        Dim dtLastProcessTime As String
        Dim sLastProcessTime As String
        dtLastProcessTime = Date.Now
        sLastProcessTime = Format(Date.Now, "yyyy-MM-ddThh:mm:ss").ToString


        Dim bSuccess As Boolean

        Dim writer As XmlTextWriter = Nothing
        Try

            writer = New XmlTextWriter(GStrExptDir & sIRSFolderPath & strExFile, System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2



            writer.WriteStartElement("FATCAIDESSenderFileMetadata") 'start FATCAIDESSenderFileMetadata

            writer.WriteAttributeString("xmlns", "http://www.w3.org/2000/xmlns/", "urn:fatca:idessenderfilemetadata")
            writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")

            writer.WriteStartElement("FATCAEntitySenderId", Nothing) 'start FATCAEntitySenderId 
            writer.WriteString(sCompany)
            writer.WriteEndElement() 'end FATCAEntitySenderId

            writer.WriteStartElement("FATCAEntityReceiverId", Nothing) 'start FATCAEntityReceiverId 
            writer.WriteString(sCompany)
            writer.WriteEndElement() 'end FATCAEntityReceiverId

            writer.WriteStartElement("FATCAEntCommunicationTypeCd", Nothing) 'start FATCAEntCommunicationTypeCd 
            writer.WriteString("RPT")
            writer.WriteEndElement() 'end FATCAEntCommunicationTypeCd

            writer.WriteStartElement("SenderFileId", Nothing) 'start SenderFileId 
            sLastProcessTime = sLastProcessTime.Replace("-", "")
            sLastProcessTime = sLastProcessTime & "Z"
            writer.WriteString(sLastProcessTime & sCompany)
            writer.WriteEndElement() 'end SenderFileId

            Dim doc As New XmlDocument()
            doc.Load(GStrExptDir & sIRSFolderPath & IRSXMLfile)


            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)

            nsmgr.AddNamespace("ftc", "urn:oecd:ties:fatca:v1")
            m_nodelist = doc.SelectNodes("//ftc:FATCA_OECD/ftc:MessageSpec", nsmgr)


            For Each m_node In m_nodelist
                sLastProcessTime = m_node.ChildNodes.Item(8).InnerText
            Next
            sLastProcessTime = sLastProcessTime & "Z"
            writer.WriteStartElement("FileCreateTs", Nothing) 'start FileCreateTs 
            writer.WriteString(sLastProcessTime)
            writer.WriteEndElement() 'end FileCreateTs

            writer.WriteStartElement("TaxYear", Nothing) 'start TaxYear 
            writer.WriteString(sFinancialYear.Substring(0, 4))
            writer.WriteEndElement() 'end TaxYear

            writer.WriteStartElement("FileRevisionInd", Nothing) 'start FileRevisionInd 
            writer.WriteString("true")
            writer.WriteEndElement() 'end FileRevisionInd

            writer.Flush()
            'GSubWriteEventLog("metaIRS.xml generated", GStrEPath)



            writer.WriteEndElement() 'end FATCAIDESSenderFileMetadata

            writer.WriteEndDocument()


            writer.Close()

            bSuccess = Validate2(strExFile, sIRSFolderPath)


            'GSubWriteEventLog("Meta successfully", GStrEPath)
            bSuccess = True
            Return bSuccess
        Catch ex As Exception
            GSubWriteErrLog("Meta is failed : " & ex.Message.ToString, GStrEPath)
            If writer IsNot Nothing Then
                writer.Close()
            End If
            GSubShowWarn("Meta is failed : " & ex.Message)

            bSuccess = False
            Return bSuccess
        End Try

    End Function

    Private Sub btnSignZipEncrypt_Click(sender As System.Object, e As System.EventArgs) Handles btnSignZipEncrypt.Click
        Dim bSecuritiesAccountReportSuccess As Boolean = False
        Dim bFuturesAccountReportSuccess As Boolean = False
        Dim bSecuritiesGroupReportSuccess As Boolean = False
        Dim bFuturesGroupReportSuccess As Boolean = False

        Dim iSteps As Integer = 0
        Dim iTotalSteps As Integer = 6
        Try
            If txtKey.Text <> "" Then
                sAESKey = txtKey.Text

                If (GSubShowYNConfirm("Confirm to Package?") = Windows.Forms.DialogResult.Yes) Then

                    If rbAccountReport.Checked Then
                        If rbSecurities.Checked Then

                            If File.Exists(GStrExptDir & sIRSFolderPathAccountReport & strSecuritiesExFile) Then
                                bSecuritiesAccountReportSuccess = SignXml(strSecuritiesExFile, sIRSFolderPathAccountReport, sESLCertPath)
                                If bSecuritiesAccountReportSuccess Then
                                    iSteps = iSteps + 1
                                End If
                                If iSteps = 1 Then
                                    bSecuritiesAccountReportSuccess = Compress(strSecuritiesExFile, sIRSFolderPathAccountReport)
                                    If bSecuritiesAccountReportSuccess Then
                                        iSteps = iSteps + 1
                                    End If
                                    If iSteps = 2 Then
                                        bSecuritiesAccountReportSuccess = Encrypt(strSecuritiesExFile, strSecuritiesEncryptExFile, sIRSFolderPathAccountReport, sAESKey)
                                        If bSecuritiesAccountReportSuccess Then
                                            iSteps = iSteps + 1
                                        End If
                                        If iSteps = 3 Then
                                            bSecuritiesAccountReportSuccess = GenerateMetaXML(sSecuritiesCompany, strSecuritiesExFile, strSecuritiesMetaExFile, sIRSFolderPathAccountReport)
                                            If bSecuritiesAccountReportSuccess Then
                                                iSteps = iSteps + 1
                                            End If
                                            If iSteps = 4 Then
                                                bSecuritiesAccountReportSuccess = EncryptAESKey(strSecuritiesAESKeyExFile, sIRSFolderPathAccountReport, sESLCertPath)
                                                If bSecuritiesAccountReportSuccess Then
                                                    iSteps = iSteps + 1
                                                End If
                                                If iSteps = 5 Then
                                                    bSecuritiesAccountReportSuccess = CompressDataPacket(sSecuritiesCompany, strSecuritiesExFile, sIRSFolderPathAccountReport, strSecuritiesExFile.Substring(0, strSecuritiesExFile.IndexOf(".xml")), strSecuritiesMetaExFile, strSecuritiesAESKeyExFile)
                                                    If bSecuritiesAccountReportSuccess Then
                                                        iSteps = iSteps + 1
                                                    End If
                                                    If iSteps = 6 Then
                                                        GSubShowInfo(GFncGetSysMsg(28))
                                                    End If

                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                GSubShowWarn("File does not exists " & GStrExptDir & strSecuritiesExFile)
                            End If

                        ElseIf rbFutures.Checked Then
                            If File.Exists(GStrExptDir & sIRSFolderPathAccountReport & strFuturesExFile) Then
                                bFuturesAccountReportSuccess = SignXml(strFuturesExFile, sIRSFolderPathAccountReport, sEFLCertPath)
                                If bFuturesAccountReportSuccess Then
                                    iSteps = iSteps + 1
                                End If
                                If iSteps = 1 Then
                                    bFuturesAccountReportSuccess = Compress(strFuturesExFile, sIRSFolderPathAccountReport)
                                    If bFuturesAccountReportSuccess Then
                                        iSteps = iSteps + 1
                                    End If
                                    If iSteps = 2 Then
                                        bFuturesAccountReportSuccess = Encrypt(strFuturesExFile, strFuturesEncryptExFile, sIRSFolderPathAccountReport, sAESKey)
                                        If bFuturesAccountReportSuccess Then
                                            iSteps = iSteps + 1
                                        End If
                                        If iSteps = 3 Then
                                            bFuturesAccountReportSuccess = GenerateMetaXML(sFuturesCompany, strFuturesExFile, strFuturesMetaExFile, sIRSFolderPathAccountReport)
                                            If bFuturesAccountReportSuccess Then
                                                iSteps = iSteps + 1
                                            End If
                                            If iSteps = 4 Then
                                                bFuturesAccountReportSuccess = EncryptAESKey(strFuturesAESKeyExFile, sIRSFolderPathAccountReport, sEFLCertPath)
                                                If bFuturesAccountReportSuccess Then
                                                    iSteps = iSteps + 1
                                                End If
                                                If iSteps = 5 Then
                                                    bFuturesAccountReportSuccess = CompressDataPacket(sFuturesCompany, strFuturesExFile, sIRSFolderPathAccountReport, strFuturesExFile.Substring(0, strFuturesExFile.IndexOf(".xml")), strFuturesMetaExFile, strFuturesAESKeyExFile)
                                                    If bFuturesAccountReportSuccess Then
                                                        iSteps = iSteps + 1
                                                    End If
                                                    If iSteps = 6 Then
                                                        GSubShowInfo(GFncGetSysMsg(28))
                                                    End If

                                                End If

                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                GSubShowWarn("File does not exists " & GStrExptDir & strFuturesExFile)
                            End If
                        End If

                    ElseIf rbPoolReport.Checked Then

                        If rbSecurities.Checked Then
                            If File.Exists(GStrExptDir & sIRSFolderPathPoolReport & strGroupSecuritiesExFile) Then
                                bSecuritiesGroupReportSuccess = SignXml(strGroupSecuritiesExFile, sIRSFolderPathPoolReport, sESLCertPath)
                                If bSecuritiesGroupReportSuccess Then
                                    iSteps = iSteps + 1
                                End If
                                If iSteps = 1 Then
                                    bSecuritiesGroupReportSuccess = Compress(strGroupSecuritiesExFile, sIRSFolderPathPoolReport)
                                    If bSecuritiesGroupReportSuccess Then
                                        iSteps = iSteps + 1
                                    End If
                                    If iSteps = 2 Then
                                        bSecuritiesGroupReportSuccess = Encrypt(strGroupSecuritiesExFile, strGroupSecuritiesEncryptExFile, sIRSFolderPathPoolReport, sAESKey)
                                        If bSecuritiesGroupReportSuccess Then
                                            iSteps = iSteps + 1
                                        End If
                                        If iSteps = 3 Then
                                            bSecuritiesAccountReportSuccess = GenerateMetaXML(sSecuritiesCompany, strGroupSecuritiesExFile, strGroupSecuritiesMetaExFile, sIRSFolderPathPoolReport)
                                            If bSecuritiesGroupReportSuccess Then
                                                iSteps = iSteps + 1
                                            End If
                                            If iSteps = 4 Then
                                                bSecuritiesAccountReportSuccess = EncryptAESKey(strGroupSecuritiesAESKeyExFile, sIRSFolderPathPoolReport, sESLCertPath)
                                                If bSecuritiesAccountReportSuccess Then
                                                    iSteps = iSteps + 1
                                                End If
                                                If iSteps = 5 Then
                                                    bSecuritiesAccountReportSuccess = CompressDataPacket(sSecuritiesCompany, strGroupSecuritiesExFile, sIRSFolderPathPoolReport, strGroupSecuritiesExFile.Substring(0, strGroupSecuritiesExFile.IndexOf(".xml")), strGroupSecuritiesMetaExFile, strGroupSecuritiesAESKeyExFile)
                                                    If bSecuritiesAccountReportSuccess Then
                                                        iSteps = iSteps + 1
                                                    End If
                                                    If iSteps = 6 Then
                                                        GSubShowInfo(GFncGetSysMsg(28))
                                                    End If

                                                End If
                                            End If
                                        End If
                                    End If

                                End If
                            Else
                                GSubShowWarn("File does not exists " & GStrExptDir & strGroupSecuritiesExFile)
                            End If
                        ElseIf rbFutures.Checked Then

                            If File.Exists(GStrExptDir & sIRSFolderPathPoolReport & strGroupFuturesExFile) Then
                                bFuturesGroupReportSuccess = SignXml(strGroupFuturesExFile, sIRSFolderPathPoolReport, sEFLCertPath)
                                If bFuturesGroupReportSuccess Then
                                    iSteps = iSteps + 1
                                End If
                                If iSteps = 1 Then
                                    bFuturesGroupReportSuccess = Compress(strGroupFuturesExFile, sIRSFolderPathPoolReport)
                                    If bFuturesGroupReportSuccess Then
                                        iSteps = iSteps + 1
                                    End If
                                    If iSteps = 2 Then
                                        bFuturesGroupReportSuccess = Encrypt(strGroupFuturesExFile, strGroupFuturesEncryptExFile, sIRSFolderPathPoolReport, sAESKey)
                                        If bFuturesGroupReportSuccess Then
                                            iSteps = iSteps + 1
                                        End If
                                        If iSteps = 3 Then
                                            bFuturesGroupReportSuccess = GenerateMetaXML(sFuturesCompany, strGroupFuturesExFile, strGroupFuturesMetaExFile, sIRSFolderPathPoolReport)
                                            If bFuturesGroupReportSuccess Then
                                                iSteps = iSteps + 1
                                            End If
                                            If iSteps = 4 Then
                                                bFuturesGroupReportSuccess = EncryptAESKey(strGroupFuturesAESKeyExFile, sIRSFolderPathPoolReport, sEFLCertPath)
                                                If bFuturesGroupReportSuccess Then
                                                    iSteps = iSteps + 1
                                                End If
                                                If iSteps = 5 Then
                                                    bFuturesGroupReportSuccess = CompressDataPacket(sFuturesCompany, strGroupFuturesExFile, sIRSFolderPathPoolReport, strGroupFuturesExFile.Substring(0, strGroupFuturesExFile.IndexOf(".xml")), strGroupFuturesMetaExFile, strGroupFuturesAESKeyExFile)
                                                    If bFuturesGroupReportSuccess Then
                                                        iSteps = iSteps + 1
                                                    End If
                                                    If iSteps = 6 Then
                                                        GSubShowInfo(GFncGetSysMsg(28))
                                                    End If

                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                GSubShowWarn("File does not exists " & GStrExptDir & strGroupFuturesExFile)
                            End If
                        End If

                    End If
                End If
            Else
                GSubShowInfo("Please input One Time Encryption key")
            End If
            
        Catch ex As Exception
            GSubWriteErrLog(ex.Message.ToString, GStrEPath)
            GSubShowWarn(ex.Message)
        End Try


    End Sub

    Private Function EncryptAESKey(ByVal strfile As String, ByVal sIRSFolderPath As String, ByVal sCertPath As String) As Boolean
        Dim bSuccess As Boolean
        Dim encoder As New UTF8Encoding
        Dim textbytes As Byte()
        Dim EncryptedByte() As Byte
        Dim cipherbytes As Byte()
        Dim plainbytes As Byte()

        Dim sEncryptedString As String
        Dim sDecryptedMessage As String


        Dim cert As X509Certificate2 = New X509Certificate2(sCertPath, sCertPassword, X509KeyStorageFlags.Exportable)
        Dim certData As Byte() = cert.Export(X509ContentType.Pkcs12, sCertPassword)
        Dim PublicProviderRsaKey As RSACryptoServiceProvider
        Dim PrivateProviderRsaKey As RSACryptoServiceProvider
        Try

            PublicProviderRsaKey = CType(cert.PublicKey.Key, RSACryptoServiceProvider)

            textbytes = Encoding.Unicode.GetBytes(sAESKey)
            EncryptedByte = PublicProviderRsaKey.Encrypt(textbytes, False)

            sEncryptedString = Convert.ToBase64String(EncryptedByte)

            cipherbytes = Convert.FromBase64String(sEncryptedString)


            PrivateProviderRsaKey = CType(cert.PrivateKey, RSACryptoServiceProvider)

            plainbytes = PrivateProviderRsaKey.Decrypt(cipherbytes, False)
            Dim enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()
            sDecryptedMessage = enc.GetString(plainbytes)



            Dim sw As StreamWriter = New StreamWriter(GStrExptDir & sIRSFolderPath & strfile)
            sw.Write(sEncryptedString)

            sw.Close()

            'GSubWriteEventLog("Encrypt AESKey successfully", GStrEPath)
            bSuccess = True
            Return bSuccess
            'End If
            'Next


        Catch ex As Exception
            GSubWriteErrLog("Encrypt AESKey is failed : " & ex.Message.ToString, GStrEPath)
            GSubShowWarn("Encrypt AESKey is failed : " & ex.Message)
            bSuccess = False
            Return bSuccess
        End Try
    End Function


    Private Function CompressDataPacket(ByVal sCompany As String, ByVal strExFile As String, ByVal sIRSFolderPath As String, ByVal sFile1 As String, ByVal sFile2 As String, ByVal sFile3 As String) As Boolean
        Dim bSuccess As Boolean
        Dim dirpath As String = GStrExptDir & sIRSFolderPath
        Dim sLastProcessTime As String = String.Empty
        Dim sOutPutFile As String = String.Empty
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        Dim doc As New XmlDocument()

        Try
            'start delete all zip file
            For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
                dirpath, _
                Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.zip*")

                My.Computer.FileSystem.DeleteFile(foundFile, _
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, _
                    Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            Next
            'end delete all zip file

            Dim Zip As ZipFile = New ZipFile()
            doc.Load(GStrExptDir & sIRSFolderPath & strExFile)
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)


            nsmgr.AddNamespace("ftc", "urn:oecd:ties:fatca:v1")
            m_nodelist = doc.SelectNodes("//ftc:FATCA_OECD/ftc:MessageSpec", nsmgr)

            For Each m_node In m_nodelist
                sLastProcessTime = m_node.ChildNodes.Item(8).InnerText
            Next

            sLastProcessTime = sLastProcessTime.Replace("-", "")
            sLastProcessTime = sLastProcessTime.Replace(":", "")
            sLastProcessTime = sLastProcessTime & "Z"

            Dim di As DirectoryInfo = New DirectoryInfo(dirpath)

            sOutPutFile = sLastProcessTime & "_" & sCompany & ".zip" '20150211T200731244Z_000000.00000.TA.124.zip 

            Dim files(3) As String
            files(0) = GStrExptDir & sIRSFolderPath & sFile1
            files(1) = GStrExptDir & sIRSFolderPath & sFile2
            files(2) = GStrExptDir & sIRSFolderPath & sFile3
            Zip.AddFile(files(0), "")
            Zip.AddFile(files(1), "")
            Zip.AddFile(files(2), "")
            Zip.Save(GStrExptDir & sIRSFolderPath & sOutPutFile)

            'start delete the files
            My.Computer.FileSystem.DeleteFile(files(0), Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(files(1), Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(files(2), Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            'end delete the files

            'GSubWriteEventLog("CompressDataPacket successfully", GStrEPath)
            bSuccess = True
            Return bSuccess
        Catch ex As Exception
            GSubWriteErrLog("CompressDataPacket is failed : " & ex.Message.ToString, GStrEPath)
            GSubShowWarn("CompressDataPacket is failed : " & ex.Message)
            bSuccess = False
            Return bSuccess
        End Try




    End Function

End Class
