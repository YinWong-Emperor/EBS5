Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices


'----------------编译开关---------------------
#Const LPTCTL_SOLUTION = "02"       ' 01   02

'LPTCTL_SOLUTION说明：
'=====================
'[方案一]
'win32-api CreateFile直接访问本地 "\\.\LPT1"，进行读写；具备“可以不生成临时文件”等优点。
'(!适用于【User的生产环境】；但是广州【开发环境】尝试不了，没硬件)
'
'[方案二]
'生成临时文件c:\itas\printout\output.prn，然后再拷贝到打印机方式。
'(广州【开发环境】可以进行打印和测试)
'(若采用此方案，请留意在生产环境 UAC可能引起的权限问题)

' * 另外请留意 app.config的相关配置，比如ChequePrinter_LPTName




''' <summary>
''' LPT端口控制类
''' </summary>
''' <remarks></remarks>
Public Class ClsLptControl
    Implements IDisposable


    '------------Members-------------

    ''' <summary>
    ''' LPT端口对应的名称<para /><seealso>https://ss64.com/nt/net-use.html</seealso>
    ''' </summary>
    ''' <remarks></remarks>
    Dim LptName As String

    ''' <summary>
    ''' 句柄
    ''' </summary>
    Dim LptHandler As IntPtr


    ' Flag: Has Dispose already been called?
    Dim disposed As Boolean = False

    ' Flag: Has call Init function?
    Dim inited As Boolean = False
    Public ReadOnly Property IsInited() As Boolean
        Get
            Return Me.inited
        End Get
    End Property

    '------------Define--------------

#Region "Win32api"

#End Region

    '##---------structs
    Public Structure OVERLAPPED
        Public InternalLow As IntPtr
        Public InternalHigh As IntPtr
        Public OffsetHigh As Int32
        Public OffsetLow As Int32
        Public EventHandle As IntPtr
    End Structure

    '##----------consts

    Private Const GENERIC_WRITE = &H40000000
    Private Const GENERIC_READ = &H80000000

    Private Const OPEN_EXISTING = 3

    Private Const FILE_SHARE_READ = &H1
    Private Const FILE_SHARE_WRITE = &H2


    '##---------apis

    '<DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    'Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As UInteger, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As IntPtr


    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Public Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As System.UInt32, ByVal dwShareMode As System.UInt32, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As System.UInt32, ByVal dwFlagsAndAttributes As System.UInt32, ByVal hTemplateFile As IntPtr) As IntPtr
    End Function


    '<DllImport("kernel32.dll")> _ 
    Private Declare Function WriteFile Lib "kernel32" Alias "WriteFile" (ByVal hFile As IntPtr, ByRef lpBuffer As Byte(), ByVal nNumberOfBytesToWrite As Integer, ByRef lpNumberOfBytesWritten As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef lpOverlapped As OVERLAPPED) As IntPtr

    '<DllImport("kernel32.dll", SetLastError:=True)> _
    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (hObject As IntPtr) As Boolean


    '------------Control-------------

#Region "构造函数"

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal m_LptName As String)
        Me.LptName = m_LptName
    End Sub

#End Region

#Region "释放"
    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() _
               Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposed Then Return

        If disposing Then
            '释放托管对象
            '当前无~
        End If

        '释放非托管对象
        If Me.LptHandler.ToInt32() > 0 Then CloseHandle(Me.LptHandler)

        '设计标记
        disposed = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
#End Region


#Region "初始化"

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <returns>成功与否</returns>
    ''' <remarks></remarks>
    Public Function Init() As Boolean

        Try

#If LPTCTL_SOLUTION = "01" Then
            '方案一：访问本地lpt端口  device-file
            Me.LptHandler = CreateFile(Me.LptName, GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
            If Me.LptHandler.ToInt32() > 0 Then inited = True
#End If

#If LPTCTL_SOLUTION = "02" Then
            '方案二：copy文件方式，因此此处默认通过
            inited = True
#End If

        Catch ex As Exception
            inited = False

            Dim errorCode As Integer = Marshal.GetLastWin32Error()
            Dim errMsg As String = "error throw when call ClsLptControl::Init. = " & Hex(errorCode) _
                                 & " : " & New System.ComponentModel.Win32Exception(errorCode).Message
            System.Diagnostics.Trace.WriteLine(errMsg)
            GSubWriteErrLog(errMsg)
        End Try

        Return inited
    End Function

    Sub CheckInited()
        If Me.inited = False Then Throw New Exception("LPT device was not init successfully.")
    End Sub


#End Region

#Region "写数据"

    ''' <summary>
    ''' 写数据 - 字节数组数据
    ''' </summary>
    ''' <param name="datas">字节数组数据</param>
    ''' <returns>成功与否</returns>
    ''' <remarks></remarks>
    Public Function WriteDatas(datas As Byte()) As Boolean
        CheckInited()

        Try
            Dim i As Integer, o As OVERLAPPED

            Return WriteFile(Me.LptHandler, datas, datas.Length, i, o)
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' 写数据 - 字符串
    ''' </summary>
    ''' <param name="dataStr">字符串数据</param>
    ''' <param name="encoding">编码</param>
    ''' <returns>成功与否</returns>
    ''' <remarks></remarks>
    Public Function WriteDatas(dataStr As String, Optional encoding As Encoding = Nothing) As Boolean
        CheckInited()

        '整理参数
        If encoding Is Nothing Then encoding = System.Text.Encoding.UTF8

        '生成buffers
        Dim datas As Byte() = encoding.GetBytes(dataStr)

        Try
#If LPTCTL_SOLUTION = "01" Then
            '方案一：访问本地lpt端口  device-file
            Return WriteDatas(datas)
#End If

#If LPTCTL_SOLUTION = "02" Then
            '方案二：copy文件方式

            '------------生成临时文件------------
            Dim dirPath As String = String.Empty
            Dim filePath As String = String.Empty
            Try
                dirPath = "c:\\itas\\printout\\"
                filePath = IO.Path.Combine(dirPath, "output.prn")

                If IO.Directory.Exists(dirPath) = False Then IO.Directory.CreateDirectory(dirPath)
                If IO.File.Exists(filePath) Then IO.File.Delete(filePath)
                IO.File.WriteAllBytes(filePath, datas)
            Catch ex As Exception
                Dim errMsg As String = "ClsLptControl::WriteDatasx 无法生成临时文件:" + ex.Message
                System.Diagnostics.Trace.WriteLine(errMsg)
                GSubWriteErrLog(errMsg)
                MsgBox(errMsg)
            End Try
            '-----------------------------------

            '------------拷贝临时文件------------
            System.IO.File.Copy(filePath, Me.LptName, True)
            '------------------------------------
#End If

        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region


End Class
