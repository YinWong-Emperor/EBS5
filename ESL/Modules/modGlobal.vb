Imports System.Data.SqlClient

Public Module modGlobal

    Public GStrEPath As String
    Public GStrRptExpPath As String = ""    'global report export path

    Public GStrConnFile As String = ""      'global connection file path
    Public GSCnSqlConn As SqlConnection    'global SQL Connection
    Public GSCnGLConn As SqlConnection
    Public GSCnLiqConn As SqlConnection
    Public GSCnBalConn As SqlConnection
    Public GSCnConConn As SqlConnection     'global Connection
    Public GDteTradeDate As Date

    Public GDtClientCode As DataTable = New DataTable

    Public GStrEIP As String
    Public GStrSender As String
    Public GStrBalDB As String
    Public GStrG2BSPRODDB As String
    Public GStrG2BFPRODDB As String
    Public GStrG2BSDB As String
    Public GStrG2BS2DB As String    'For US Margin
    Public GStrG2BFDB As String
    Public GStrG2BSLMTHDB As String
    Public GStrG2BFLMTHDB As String
    'Start v2.1.0.1 Chris
    Public GStrG2BSLYRDB As String
    Public GStrG2BFLYRDB As String
    'End v2.1.0.1 Chris
    Public GSCnPriceConn As SqlConnection   'global price feed connection
    Public GStrloginID As String = ""      'global current login ID
    Public GBlnFormOpen As Boolean = False     'global child form status flag
    Public GStrSysLang As String = "ENG"      'global system language
    'Public Const GStrConnName As String = "DBConnection"    'global connection name in app.config
    'Public Const GStrPriceConnName As String = "FxFeedDBConnection"    'global connection name for price feed DB in app.config
    'Public GClrMenuColor As System.Drawing.Color = Color.FromArgb(177, 204, 248)
    'Public GStrAno As String = ""
    Public GStrBCode As String = ""
    'Public GStrRpt As String = ""
    'Public GDecMinLots As Decimal
    'Public GDecLotsUnit As Decimal
    Public GStrBPath As String
    'Public DtmStart As DateTime
    Public GStrConDB As String
    Public GStrIsReportDB As String
    Public GSCnMaster As SqlConnection
    Public GArrShowBrh As New ArrayList
    Public GBlnIsAdmin As Boolean = False   'Is administrator flag
    Public GStrDomainUser As String         'Domain user name
    Public GStrExptDir As String = "C:\itas\"
    Public GIsUAT As Boolean
    Public g_branch_name, g_rbranch, g_company, g_version, g_dir As String
    Public SystemDateFormat As String = "dd MMM yyyy"
    Public DecimalFormat As String = "0.00#############"

    Public GSqlCommandTimeout As Integer = 1800   ' sql command timeout
End Module



Public Enum EnumFormStatus
    Search
    Edit
    [New]
    Loading
    Details
    [Delete]
    Invalid
End Enum