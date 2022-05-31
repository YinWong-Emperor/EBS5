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
Imports System.Text.RegularExpressions

Public Class frmCRS

    Dim clsCRS As New ClsCRS
    Private sFinancialYear As String
    Private strAEOIid As String = ""
    Private strFIName As String = ""
    Private strAccType As String = "Securities"
    Private strMessageRefId As String = ""

    Dim sCRSFolderPathAccountReport As String = "CRS\AccountReport\"

    Private Sub frmCRS_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        ''Me.numReturnYear.Value = GDteTradeDate.AddYears(-1).Year.ToString()
        Me.numReturnYear.Value = DateTime.Now.AddYears(-1).Year

        'If Not Directory.Exists(GStrExptDir & sCRSFolderPathAccountReport) Then
        '    Directory.CreateDirectory(GStrExptDir & sCRSFolderPathAccountReport)
        'End If



    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Me.GenerateXML(Me.GetFileName())
    End Sub


    Private Sub GenerateXML(ByVal strExFile As String)


        Dim dt As DataTable = clsCRS.lFnGetCRSAccountTable(Me.strAccType)

        If dt Is Nothing Then
            GSubShowWarn("Generate XML is failed : Data is empty.")
            Return
        End If

        Dim writer As XmlTextWriter = New XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" & strExFile, System.Text.Encoding.UTF8)

        Try

            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2

            writer.WriteStartElement("crs", "AEOI_Report", "http://www.ird.gov.hk/AEOI/crs/v1/HK_XMLSchema_v1.0.xsd") 'start AEOI_Report
            writer.WriteAttributeString("xmlns", "cfc", Nothing, "http://www.ird.gov.hk/AEOI/aeoitypes/v1")
            writer.WriteAttributeString("xmlns", "crs", Nothing, "http://www.ird.gov.hk/AEOI/crs/v1")
            writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")

            Me.GenerateMessageSpec(writer)

            Me.GenerateCrsBody(dt, writer)

            writer.WriteEndElement() 'end AEOI_Report

            GSubShowInfo(GFncGetSysMsg(28))
            GSubShowInfo(" Plese found xml file in  " & Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" & strExFile)
            Using myProcess As New Process()
                myProcess.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" & strExFile
                myProcess.Start()
            End Using
        Catch ex As Exception
            GSubWriteErrLog(ex.Message.ToString, GStrEPath)

            GSubShowWarn(ex.Message)
        Finally
            writer.Close()
        End Try
    End Sub

#Region "MessageSpec"

    Private Sub GenerateMessageSpec(ByVal writer As XmlTextWriter)

        Dim dateNow As Date = Date.Now

        writer.WriteStartElement("crs:MessageSpec") 'start MessageSpec

        writer.WriteStartElement("crs:AeoiId") 'start AeoiId
        writer.WriteString(strAEOIid)
        writer.WriteEndElement() ' end AeoiId

        writer.WriteStartElement("crs:FIName") 'start FIName
        writer.WriteString(strFIName)
        writer.WriteEndElement() ' end FIName

        writer.WriteStartElement("crs:MessageRefId") 'start MessageRefId
        writer.WriteString(strMessageRefId)
        writer.WriteEndElement() ' end MessageRefId

        writer.WriteStartElement("crs:MessageTypeIndic") 'start MessageTypeIndic
        writer.WriteString("CRS701")
        writer.WriteEndElement() ' end MessageTypeIndic

        writer.WriteStartElement("crs:ReturnYear") 'start ReturnYear
        writer.WriteString(Me.numReturnYear.Value.ToString())
        writer.WriteEndElement() ' end ReturnYear

        writer.WriteStartElement("crs:Timestamp") 'start Timestamp
        writer.WriteString(dateNow.ToString("yyyy-MM-ddTHH:mm:ss"))
        writer.WriteEndElement() ' end Timestamp

        writer.WriteEndElement() ' end MessageSpec
    End Sub

#End Region

#Region "CrsBody"

    Private Sub GenerateCrsBody(ByVal dt As DataTable, ByVal writer As XmlTextWriter)

        writer.WriteStartElement("crs:CrsBody") 'start CrsBody

        writer.WriteStartElement("crs:ReportingGroup") 'start ReportingGroup

        'Dim idv_dt As DataRow() = dt.Select(" CrsType = 'I' or CrsType = 'J'")
        Dim idv_dt As DataRow() = dt.Select(" CrsType = 'I'")

        If idv_dt.Length > 0 Then
            Me.GenerateIndividualAccountReport(idv_dt.CopyToDataTable(), writer)
        End If

        'Dim e_dt As DataRow() = dt.Select(" CrsType = 'E' or CrsType = 'CP'")
        Dim e_dt As DataRow() = dt.Select(" CrsType = 'E' or CrsType = 'J'")

        If e_dt.Length > 0 Then
            Me.GenerateEntityAccountReport(e_dt.CopyToDataTable(), writer)
        End If

        writer.WriteEndElement() 'end ReportingGroup
        writer.WriteEndElement() 'end CrsBody
    End Sub

#Region "Individual"

    Private Sub GenerateIndividualAccountReport(ByVal dt As DataTable, ByVal writer As XmlTextWriter)
        Dim index As Integer = 0
        Dim row As DataRow
        For index = 0 To dt.Rows.Count - 1

            row = dt.Rows(index)

            writer.WriteStartElement("crs:AccountReport") 'start AccountReport

            writer.WriteStartElement("crs:DocSpec") 'start DocSpec
            writer.WriteStartElement("crs:DocTypeIndic") 'start DocTypeIndic
            writer.WriteString("OECD1")
            writer.WriteEndElement() 'end DocTypeIndic
            writer.WriteStartElement("crs:DocRefId") 'start DocRefId
            writer.WriteString(Me.strMessageRefId & row("crs_id").ToString())
            writer.WriteEndElement() 'end DocRefId
            writer.WriteEndElement() 'end DocSpec

            writer.WriteStartElement("crs:AccountNumber") 'start AccountNumber
            If row("AcctNumberType").ToString().Trim() <> "" Then
                writer.WriteAttributeString("AcctNumberType", row("AcctNumberType").ToString())
            End If
            writer.WriteAttributeString("UndocumentedAccount", row("IS_Undocumented").ToString())
            writer.WriteAttributeString("ClosedAccount", row("IS_Close").ToString())

            writer.WriteString(row("Accno").ToString().Trim())
            writer.WriteEndElement() 'end AccountNumber

            writer.WriteStartElement("crs:AccountHolder") 'start AccountHolder

            Me.GenerateIndividualInfo(row, writer)

            writer.WriteEndElement() 'end AccountHolder

            writer.WriteStartElement("crs:AccountBalance") 'start AccountBalance
            writer.WriteAttributeString("currCode", "HKD")
            writer.WriteString(row("AccBal").ToString())
            writer.WriteEndElement() 'end AccountBalance

            If row("payment_type").ToString().Trim() <> "" Then
                writer.WriteStartElement("crs:Payment") 'start Payment
                writer.WriteStartElement("crs:Type") 'start Type

                writer.WriteString(row("payment_type").ToString())
                writer.WriteEndElement() 'end Type
                writer.WriteStartElement("crs:PaymentAmnt") 'start PaymentAmnt
                writer.WriteAttributeString("currCode", "HKD")
                writer.WriteString(row("payment_value").ToString())
                writer.WriteEndElement() 'end PaymentAmnt

                writer.WriteEndElement() 'end Payment
            End If

            writer.WriteEndElement() 'end AccountReport
        Next
    End Sub

    Private Sub GenerateIndividualInfo(ByVal row As DataRow, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("crs:Individual") 'start Individual

        writer.WriteStartElement("crs:ResCountryCode") 'start ResCountryCode
        writer.WriteString(row("ResCountryCode").ToString())
        writer.WriteEndElement() 'end ResCountryCode

        If row("TIN").ToString().Trim() <> "" Then
            writer.WriteStartElement("crs:TIN") 'start TIN
            If row("TINIssueBy").ToString().Trim() <> "" Then
                writer.WriteAttributeString("issuedBy", row("TINIssueBy").ToString())
            End If
            writer.WriteString(row("TIN").ToString().Trim())
            writer.WriteEndElement() 'end TIN
        End If

        writer.WriteStartElement("crs:Name") 'start Name
        If row("NameType").ToString().Trim() <> "" Then
            writer.WriteAttributeString("nameType", row("NameType").ToString())
        End If
        writer.WriteStartElement("crs:FirstName") 'start FirstName
        writer.WriteString(row("FirstName").ToString().Trim())
        writer.WriteEndElement() 'end FirstName
        writer.WriteStartElement("crs:LastName") 'start LastName
        writer.WriteString(row("LastName").ToString().Trim())
        writer.WriteEndElement() 'end LastName
        writer.WriteEndElement() 'end Name

        writer.WriteStartElement("crs:Address") 'start Address
        If row("LegalAddressType").ToString().Trim().Trim() <> "" Then
            writer.WriteAttributeString("legalAddressType", row("LegalAddressType").ToString().Trim())
        End If

        If row("AddressCountryCode").ToString().Trim() <> "" Then
            writer.WriteStartElement("cfc:CountryCode") 'start CountryCode
            writer.WriteString(row("AddressCountryCode").ToString())
            writer.WriteEndElement() 'end CountryCode
        End If

        Dim free_addr As String = row("AddressFree").ToString()
        writer.WriteStartElement("cfc:AddressFree") 'start AddressFree


        'While (Len(free_addr) > 0)
        '    If Len(free_addr) > 150 Then
        '        writer.WriteStartElement("cfc:Line") 'start Line
        '        writer.WriteString(GfncSubString(free_addr, 0, 150))
        '        writer.WriteEndElement() 'end Line
        '        free_addr = free_addr.Substring(Len(free_addr) - 150)
        '    Else
        '        writer.WriteStartElement("cfc:Line") 'start Line
        '        writer.WriteString(free_addr)
        '        writer.WriteEndElement() 'end Line
        '        free_addr = ""
        '    End If
        'End While
        writer.WriteStartElement("cfc:Line") 'start Line
        writer.WriteString(Regex.Replace(free_addr, "&#x([0-8BCEF]|1[0-9A-F]);|[\u0000-\u0008\u000B\u000C\u000E-\u001F]", String.Empty).Trim())
        writer.WriteEndElement() 'end Line

        writer.WriteEndElement() 'end AddressFree
        writer.WriteEndElement() 'end Address

        If Not IsDBNull(row("BirthDate")) Then
            writer.WriteStartElement("crs:BirthInfo") 'start BirthInfo
            writer.WriteStartElement("crs:BirthDate") 'start BirthDate
            writer.WriteString(CDate(row("BirthDate")).ToString("yyyy-MM-dd"))
            writer.WriteEndElement() 'end BirthDate

            If row("BirthCountryCode").ToString().Trim() <> "" Then
                writer.WriteStartElement("crs:CountryInfo") 'start CountryInfo
                writer.WriteStartElement("crs:CountryCode") 'start CountryCode
                writer.WriteString(row("BirthCountryCode").ToString())

                writer.WriteEndElement() 'end CountryCode
                writer.WriteEndElement() 'end CountryInfo
            End If
            writer.WriteEndElement() 'end BirthInfo
        End If


        writer.WriteEndElement() 'end Individual
    End Sub

#End Region

#Region "Entity"

    Private Sub GenerateEntityAccountReport(ByVal ecpdt As DataTable, ByVal writer As XmlTextWriter)

        Dim index As Integer = 0
        Dim row As DataRow
        'Dim eRows As DataRow() = ecpdt.Select(" CrsType = 'E'")
        Dim eRows As DataRow() = ecpdt.Select(" CrsType = 'E' or CrsType = 'J'")
        Dim cpRows As DataRow()
        For index = 0 To eRows.Length - 1

            row = eRows(index)

            writer.WriteStartElement("crs:AccountReport") 'start AccountReport

            writer.WriteStartElement("crs:DocSpec") 'start DocSpec
            writer.WriteStartElement("crs:DocTypeIndic") 'start DocTypeIndic
            writer.WriteString("OECD1")
            writer.WriteEndElement() 'end DocTypeIndic
            writer.WriteStartElement("crs:DocRefId") 'start DocRefId
            writer.WriteString(Me.strMessageRefId & row("crs_id").ToString())
            writer.WriteEndElement() 'end DocRefId
            writer.WriteEndElement() 'end DocSpec

            writer.WriteStartElement("crs:AccountNumber") 'start AccountNumber            
            writer.WriteAttributeString("ClosedAccount", row("IS_Close").ToString())
            writer.WriteString(row("Accno").ToString().Trim())
            writer.WriteEndElement() 'end AccountNumber

            writer.WriteStartElement("crs:AccountHolder") 'start AccountHolder

            writer.WriteStartElement("crs:Organisation") 'start Organisation
            writer.WriteStartElement("crs:ResCountryCode") 'start ResCountryCode
            writer.WriteString(row("ResCountryCode").ToString())
            writer.WriteEndElement() 'end ResCountryCode

            writer.WriteStartElement("crs:IN") 'start IN
            writer.WriteAttributeString("issuedBy", row("TINIssueBy").ToString())
            writer.WriteString(row("TIN").ToString().Trim())
            writer.WriteEndElement() 'end IN

            writer.WriteStartElement("crs:Name") 'start Name
            If row("NameType").ToString().Trim() <> "" Then
                writer.WriteAttributeString("nameType", row("NameType").ToString())
            End If
            writer.WriteString(row("ClientName").ToString().Trim())
            writer.WriteEndElement() 'end Name

            writer.WriteStartElement("crs:Address") 'start Address
            If row("LegalAddressType").ToString().Trim() <> "" Then
                writer.WriteAttributeString("legalAddressType", row("LegalAddressType").ToString().Trim())
            End If


            writer.WriteStartElement("cfc:CountryCode") 'start CountryCode
            writer.WriteString(row("AddressCountryCode").ToString())
            writer.WriteEndElement() 'end CountryCode

            Dim free_addr As String = row("AddressFree").ToString()
            writer.WriteStartElement("cfc:AddressFree") 'start AddressFree


            'While (Len(free_addr) > 0)
            '    If Len(free_addr) > 150 Then
            '        writer.WriteStartElement("cfc:Line") 'start Line
            '        writer.WriteString(GfncSubString(free_addr, 0, 150))
            '        writer.WriteEndElement() 'end Line
            '        free_addr = free_addr.Substring(Len(free_addr) - 150)
            '    Else
            '        writer.WriteStartElement("cfc:Line") 'start Line
            '        writer.WriteString(free_addr)
            '        writer.WriteEndElement() 'end Line
            '        free_addr = ""
            '    End If
            'End While
            writer.WriteStartElement("cfc:Line") 'start Line
            writer.WriteString(Regex.Replace(free_addr, "&#x([0-8BCEF]|1[0-9A-F]);|[\u0000-\u0008\u000B\u000C\u000E-\u001F]", String.Empty).Trim())
            writer.WriteEndElement() 'end Line

            writer.WriteEndElement() 'end AddressFree
            writer.WriteEndElement() 'end Address
            writer.WriteEndElement() 'end Organisation

            writer.WriteStartElement("crs:AcctHolderType") 'start AcctHolderType
            writer.WriteString(row("AccHolderType").ToString())
            writer.WriteEndElement() 'end AcctHolderType

            writer.WriteEndElement() 'end AccountHolder

            cpRows = ecpdt.Select(" Accno = '" & row("accno").ToString() & "' and  CrsType = 'CP'")

            If cpRows.Length > 0 Then
                Me.GenerateControllingPerson(cpRows, writer)
            End If




            writer.WriteStartElement("crs:AccountBalance") 'start AccountBalance
            writer.WriteAttributeString("currCode", "HKD")
            writer.WriteString(row("AccBal").ToString())
            writer.WriteEndElement() 'end AccountBalance

            If row("payment_type").ToString().Trim() <> "" Then
                writer.WriteStartElement("crs:Payment") 'start Payment
                writer.WriteStartElement("crs:Type") 'start Type

                writer.WriteString(row("payment_type").ToString())
                writer.WriteEndElement() 'end Type
                writer.WriteStartElement("crs:PaymentAmnt") 'start PaymentAmnt
                writer.WriteAttributeString("currCode", "HKD")
                writer.WriteString(row("payment_value").ToString())
                writer.WriteEndElement() 'end PaymentAmnt

                writer.WriteEndElement() 'end Payment
            End If

            writer.WriteEndElement() 'end AccountReport
        Next
    End Sub

    Private Sub GenerateControllingPerson(ByVal rows As DataRow(), ByVal writer As XmlTextWriter)

        Dim index As Integer = 0
        Dim row As DataRow
        For index = 0 To rows.Length - 1
            row = rows(index)
            writer.WriteStartElement("crs:ControllingPerson") 'start ControllingPerson

            Me.GenerateIndividualInfo(row, writer)
            If row("CPType").ToString().Trim() <> "" Then
                writer.WriteStartElement("crs:CtrlgPersonType") 'start CtrlgPersonType
                writer.WriteString(row("CPType").ToString())
                writer.WriteEndElement() 'end CtrlgPersonType
            End If
            writer.WriteEndElement() 'end ControllingPerson
        Next
    End Sub

#End Region

#End Region

    Private Function GetFileName() As String

        If Me.rbSecurities.Checked Then
            Me.strAccType = "Securities"
            Me.strAEOIid = "AE13315"
            Me.strFIName = "Emperor Securities Limited"
        Else
            Me.strAccType = "Futures"
            Me.strAEOIid = "AT37725"
            Me.strFIName = "Emperor Futures Limited"
        End If
        Me.strMessageRefId = Me.numReturnYear.Value & strAEOIid & Date.Now.ToString("yyyyMMddHHmmss") & "01"

        Return Me.strMessageRefId & ".xml"
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class