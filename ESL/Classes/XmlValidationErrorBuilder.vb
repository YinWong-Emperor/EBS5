Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Public Class XmlValidationErrorBuilder
    Private _errors As New List(Of ValidationEventArgs)()

    Public Sub ValidationEventHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)
        If args.Severity = XmlSeverityType.Error Then
            _errors.Add(args)
        End If
    End Sub

    Public Function GetErrors() As String
        If _errors.Count <> 0 Then
            Dim builder As New StringBuilder()
            builder.Append("The following ")
            builder.Append(_errors.Count.ToString())
            builder.AppendLine(" error(s) were found while validating the XML document against the XSD:")
            For Each i As ValidationEventArgs In _errors
                builder.Append("* ")
                builder.AppendLine(i.Message)
            Next
            Return builder.ToString()
        Else
            Return Nothing
        End If
    End Function
    Public Function LoadValidatedXmlDocument(xmlFilePath As String, xsdFilePath1 As String, xsdFilePath2 As String, xsdFilePath3 As String, xsdFilePath4 As String) As String
        Dim doc As New XmlDocument()
        doc.Load(xmlFilePath)
        doc.Schemas.Add(Nothing, xsdFilePath1)
        doc.Schemas.Add(Nothing, xsdFilePath2)
        doc.Schemas.Add(Nothing, xsdFilePath3)
        doc.Schemas.Add(Nothing, xsdFilePath4)
        Dim errorBuilder As New XmlValidationErrorBuilder()
        doc.Validate(New ValidationEventHandler(AddressOf errorBuilder.ValidationEventHandler))
        Dim errorsText As String = errorBuilder.GetErrors()
        'If errorsText IsNot Nothing Then
        'Throw New Exception(errorsText)
        'End If
        Return errorsText
    End Function
    Public Function LoadValidatedXmlDocument(xmlFilePath As String, xsdFilePath1 As String) As String
        Dim doc As New XmlDocument()
        doc.Load(xmlFilePath)
        doc.Schemas.Add(Nothing, xsdFilePath1)

        Dim errorBuilder As New XmlValidationErrorBuilder()
        doc.Validate(New ValidationEventHandler(AddressOf errorBuilder.ValidationEventHandler))
        Dim errorsText As String = errorBuilder.GetErrors()
        'If errorsText IsNot Nothing Then
        'Throw New Exception(errorsText)
        'End If
        Return errorsText
    End Function
End Class
