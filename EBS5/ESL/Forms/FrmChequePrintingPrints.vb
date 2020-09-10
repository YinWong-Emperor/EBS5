Imports System.Globalization

Public Class FrmChequePrintingPrints

    '---------Consts----------

    Const iSpellMaxLenghPerRow = 50


    '---------Members---------

    Dim cls As New ClsChequePrinting
    Dim lpt As New ClsLptControl(Configuration.ConfigurationManager.AppSettings("ChequePrinter_LPTName"))

    '---------Control---------

#Region "绑定单选项处理事件"

    ''' <summary>
    ''' 绑定单选项处理事件-文本改变时-自由事件
    ''' </summary>
    ''' <param name="sender">控件</param>
    ''' <param name="action">处理</param>
    Private Sub BindDeal_ComboBox_TextChanged(sender As ComboBox, action As Action)
        GUIBindDeal_ComboBox_TextChanged(sender, action)
    End Sub

    ''' <summary>
    ''' 绑定单选项处理事件-当第1个对象的选中索引改变时，修改第2个对象的选中索引
    ''' </summary>
    ''' <param name="sender1">控件1</param>
    ''' <param name="sender2">控件2</param>
    Private Sub BindDeal_ComboBox_ChangeSencondIndex_When_FirstIndexChanged(sender1 As ComboBox, sender2 As ComboBox)
        GUIBindDeal_ComboBox_ChangeSencondIndex_When_FirstIndexChanged(sender1, sender2)
    End Sub

#End Region

#Region "初始化"

    Public Sub SetTargetDate(ByVal targetDate As DateTime)
        Me.dtpTxnDate.Value = targetDate
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        'List ClientCodes
        Try
            Dim dt_ccs As DataTable = cls.FncListClientCodes()
            Dim ret_ccs As IQueryable(Of String) = dt_ccs.AsEnumerable().AsQueryable().Select(Function(x) x.Field(Of String)(0))
            cbbClientCodeFrom.DataSource = ret_ccs.ToArray()
            cbbClientCodeTo.DataSource = ret_ccs.ToArray()
            cbbClientCodeFrom.SelectedIndex = -1
            cbbClientCodeTo.SelectedIndex = -1
        Catch ex As Exception
        End Try

        'List SequenceNos
        Try
            Dim dt_sns As DataTable = cls.FncListSequenceNos()
            Dim ret_sns As IQueryable(Of Integer) = dt_sns.AsEnumerable().AsQueryable().Select(Function(x) x.Field(Of Integer)(0))
            cbbSequenceNoFrom.DataSource = ret_sns.ToArray()
            cbbSequenceNoFrom.SelectedIndex = -1
            cbbSequenceNoTo.DataSource = ret_sns.ToArray()
            cbbSequenceNoTo.SelectedIndex = -1
        Catch ex As Exception
        End Try

        'Bind events
        '#TextChanged
        Dim action4cbbClientCodes As Action = Sub() rbtClientCode4RecordRange.Checked = True
        BindDeal_ComboBox_TextChanged(cbbClientCodeFrom, action4cbbClientCodes)
        BindDeal_ComboBox_TextChanged(cbbClientCodeTo, action4cbbClientCodes)
        Dim action4cbbSequenceNos As Action = Sub() rbtSequenceNo4RecordRange.Checked = True
        BindDeal_ComboBox_TextChanged(cbbSequenceNoFrom, action4cbbSequenceNos)
        BindDeal_ComboBox_TextChanged(cbbSequenceNoTo, action4cbbSequenceNos)
        '#IndexChanged
        BindDeal_ComboBox_ChangeSencondIndex_When_FirstIndexChanged(cbbClientCodeFrom, cbbClientCodeTo)
        BindDeal_ComboBox_ChangeSencondIndex_When_FirstIndexChanged(cbbSequenceNoFrom, cbbSequenceNoTo)

        'Default value
        rbtListing4ReportType.Checked = True
        rbtSequenceNo4PrintSequence.Checked = True
        rbtAll4RecordRange.Checked = True
        rbtPreview4PrintReport.Checked = True

    End Sub

#End Region

#Region "打印"

    ''' <summary>
    ''' 打印
    ''' </summary>
    Private Sub DoPrint()
        'Get params
        Dim OpgPrtSeq As Integer, OpgPrtRec As Integer
        OpgPrtSeq = IIf(rbtSequenceNo4PrintSequence.Checked, 1, 2)
        OpgPrtRec = IIf(rbtAll4RecordRange.Checked, 1, IIf(rbtClientCode4RecordRange.Checked, 2, 3))

        Dim SequenceNoFrom As Integer = 0, SequenceNoTo As Integer = Integer.MaxValue
        Integer.TryParse(cbbSequenceNoFrom.Text.Trim(), SequenceNoFrom)
        Integer.TryParse(cbbSequenceNoTo.Text.Trim(), SequenceNoTo)

        Dim ClientCodeFrom As String = cbbClientCodeFrom.Text.Trim(), ClientCodeTo As String = cbbClientCodeTo.Text.Trim()

        '##Load data
        Dim dt As DataTable
        Try
            dt = cls.FncLoadPrintData(dtpTxnDate.Value.Date, _
                                        OpgPrtSeq, _
                                        OpgPrtRec, _
                                        ClientCodeFrom, _
                                        ClientCodeTo, _
                                        SequenceNoFrom, _
                                        SequenceNoTo _
                                        )
        Catch ex As Exception
            End
        End Try

        '----------------------------
        'Deal with different logic different by [Report Type] & [Print Report]

        If rbtListing4ReportType.Checked Then
            '#--------Listing--------

            '##Combine CrystalReport
            Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

            'Get params
            Dim m_ClientCodeFrom As String = Nothing, m_ClientCodeTo As String = Nothing, m_SequenceNoFrom As Integer? = Nothing, m_SequenceNoTo As Integer? = Nothing
            If rbtClientCode4RecordRange.Checked Then
                m_ClientCodeFrom = ClientCodeFrom
                m_ClientCodeTo = ClientCodeTo
            End If
            If rbtSequenceNo4RecordRange.Checked Then
                m_SequenceNoFrom = SequenceNoFrom
                m_SequenceNoTo = SequenceNoTo
            End If

            'Get target ReportClass
            rpt = cls.FncCreateRpt(dt, dtpTxnDate.Value.Date, m_ClientCodeFrom, m_ClientCodeTo, m_SequenceNoFrom, m_SequenceNoTo)

            If rbtPreview4PrintReport.Checked Then
                '##Preview
                '弹水晶报表去预览
                Dim frm As New FrmRptDisplay
                frm.GSubDisplayRpt(rpt)
            Else
                '##Printer
                Dim intFromPage As Integer, intToPage As Integer, strPrinterName As String, shtCopies As Integer

                '###弹PrintDialog去获取参数
                If DlgPrint.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    strPrinterName = DlgPrint.PrinterSettings.PrinterName
                    shtCopies = DlgPrint.PrinterSettings.Copies
                    If DlgPrint.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                        intFromPage = DlgPrint.PrinterSettings.FromPage
                        intToPage = DlgPrint.PrinterSettings.ToPage
                    End If
                Else
                    Exit Sub
                End If
                '###进行打印并显示消息
                If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                    GSubShowInfo(GFncGetSysMsg(104))
                End If

            End If

        Else
            '#--------Cheque--------

            If rbtPreview4PrintReport.Checked Then
                '##Preview
                '弹Form显示数据
                Dim previewOnlyFrm As New FrmChequePrintingPreviewOnlyForCheque
                previewOnlyFrm.ShowDatas(dt)
                previewOnlyFrm.ShowDialog(Me)

            Else
                '##Printer

                If Not chk_PrinterSelect.Checked Then
                    ''''[Start] For lpt direct printing 

                    'Init
                    If lpt.IsInited = False Then
                        If lpt.Init() = False Then
                            MsgBox("Printer is not ready.", MsgBoxStyle.Exclamation, "Not Ready")
                            Return
                        End If
                    End If

                    'Combine datas
                    Dim ret As String = DoPrintHelper_GetStringData_CheuqeToPrinter(dt)

                    'Send datas
                    Try
                        lpt.WriteDatas(ret)
                        MsgBox("Print Success.", MsgBoxStyle.Information, "Success")
                    Catch ex As Exception
                        MsgBox("Printer is not ready.", MsgBoxStyle.Exclamation, "Not Ready")
                    End Try

                    ''''[End] For lpt direct printing 
                Else
                    ''''[Start] For Printer Dialog printing 

                    Dim ret As String = DoPrintHelper_GetStringData_CheuqeToPrinter(dt)
                    Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
                    Dim datas As Byte() = encoding.GetBytes(ret)
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

                    Dim pDoc As System.Drawing.Printing.PrintDocument = New System.Drawing.Printing.PrintDocument()
                    pDoc.DocumentName = "Cheque Print"
                    DlgPrint.Document = pDoc
                    If DlgPrint.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        streamToPrint = New System.IO.StreamReader(filePath)
                        printFont = New Font("Arial", 10)
                        AddHandler pDoc.PrintPage, AddressOf Me.pDoc_PrintPage
                        pDoc.Print()
                        streamToPrint.Close()
                    Else
                        Exit Sub
                    End If

                    ''''[End] For Printer Dialog printing
                End If

            End If

            End If
    End Sub

    Private streamToPrint As System.IO.StreamReader
    Private printFont As Font

    Private Sub pDoc_PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Iterate over the file, printing each line.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, _
                yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub

    ''' <summary>
    ''' 打印 - 打印机打印支票
    ''' </summary>
    ''' <remarks></remarks>
    Private Function DoPrintHelper_GetStringData_CheuqeToPrinter(dt As DataTable) As String

        Const LineWrap As String = vbCrLf                   ' 0D 0A
        Dim rets As New System.Text.StringBuilder


        '/* 根据output(xxxx-xx-xx).prn文件的分析结果、v3狐狸仔部分code的参考，有以下结论：   */'
        '  <信息头>
        '  <支票内容A>
        '  <支票内容B>
        '  <支票内容C>

        '#1 <信息头>占2行;
        '#2 每个<支票内容>占22行;
        '#3 换行符为 \r\n  <=>  0D 0A  ;
        '#4 空白位为 空格  <=>  20  ;

        '--------------------------------------------------

        '<信息头>:
        rets.Append(Space(1) & Chr(&H1B) & Chr(&H40) & Chr(&H1B) & Chr(&H50)) : rets.Append(LineWrap)
        rets.Append(LineWrap)

        '遍历<支票内容>
        For Each item As DataRow In dt.Rows
            'std-line 1
            '*:     0383                         0383
            Dim client_code As String = item.Field(Of String)("client_code").Trim()
            rets.Append(Space(5))
            rets.Append(client_code & Space(25) & client_code)
            rets.Append(LineWrap)


            'std-line 2
            '*:     10-AUG-2015                    10-AUG-2015                                                                      10-AUG-2015
            rets.Append(Space(5))

            Dim txn_date As DateTime? = item.Field(Of DateTime?)("txn_date")
            If txn_date IsNot Nothing Then
                Dim day_txn_date As Integer = txn_date.Value.Year
                Dim fullDateString As String = txn_date.Value.ToString("dd-MMM-yyyy", CultureInfo.GetCultureInfo("en-US"))

                rets.Append(fullDateString)
                'ε = = (づ′▽`)づ 强迫症专用对齐; 原需求如此。
                If day_txn_date < 10 Then rets.Append(Space(1))

                rets.Append(Space(20))

                rets.Append(fullDateString)
                'ε = = (づ′▽`)づ 强迫症专用对齐; 原需求如此。
                If day_txn_date < 10 Then rets.Append(Space(1))

                rets.Append(Space(70))
                rets.Append(fullDateString)
            End If

            rets.Append(LineWrap)


            'std-line 3
            '*:     gChan Tai Man                  P           gChan Tai Man                  P
            Dim userName As String = item.Field(Of String)("name").PadRight(120)        '主动补齐120个长度

            rets.Append(Space(5))
            rets.Append(Chr(&H1B) & Chr(&H67))

            Dim name1 As String = Trim(GfncSubString(userName, 0, 30)).PadRight(30)
            rets.Append(name1 & Chr(&H1B) & Chr(&H50))
            rets.Append(Space(11))
            rets.Append(Chr(&H1B) & Chr(&H67))
            rets.Append(name1 & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)


            'std-line 4
            '*:     g                              P           g                              P
            rets.Append(Space(5))
            rets.Append(Chr(&H1B) & Chr(&H67))

            Dim name2 As String = Trim(GfncSubString(userName, 31, 30)).PadRight(30)
            rets.Append(name2 & Chr(&H1B) & Chr(&H50))
            rets.Append(Space(11))
            rets.Append(Chr(&H1B) & Chr(&H67))
            rets.Append(name2 & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)


            'std-line 5
            '*:     g                              P           g                              X           Chan Tai ManP
            rets.Append(Space(5))
            rets.Append(Chr(&H1B) & Chr(&H67))

            Dim nam3 As String = Trim(GfncSubString(userName, 61, 30)).PadRight(30)
            rets.Append(nam3 & Chr(&H1B) & Chr(&H50))
            rets.Append(Space(11))
            rets.Append(Chr(&H1B) & Chr(&H67))
            'rets.Append(nam3 & Chr(&H1B) & Chr(&H50))
            rets.Append(nam3 & Chr(&H1B) & Chr(&H58))
            rets.Append(Chr(&H1) & Chr(&H18) & Chr(&H0))
            rets.Append(Space(10))
            rets.Append(userName.Trim() & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)


            'std-line 6
            '*:     g                              P           g                              P
            rets.Append(Space(5))
            rets.Append(Chr(&H1B) & Chr(&H67))

            Dim name4 As String = Trim(GfncSubString(userName, 91, 30)).PadRight(30)
            rets.Append(name4 & Chr(&H1B) & Chr(&H50))
            rets.Append(Space(11))
            rets.Append(Chr(&H1B) & Chr(&H67))
            rets.Append(name4 & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)


            'std-line 7
            '*:                                                                  MSix Hundred Fourteen Thousand Three Hundred SixtyFP
            'e20190218 start
            'Dim amount As Double = item.Field(Of Double)("amount")
            Dim amount As Double = Convert.ToDouble(item("amount"))
            'e20190218 end
            Dim strAmount As String = amount.ToString("N").Trim()
            Dim spellNumber As String = Trim(ClsSpellNumber.SpellNumber(amount))
            Dim arrSpell As String() = DoPrintHelper_Number_GetArrSpell(spellNumber)

            rets.Append(Space(66))
            rets.Append(Chr(&H1B) & Chr(&H4D))
            rets.Append(Trim(arrSpell(0)))
            rets.Append(Chr(&H1B) & Chr(&H46) & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)


            'std-line 8
            '*:                                                                  MThree Dollars and Fifty Three Cents Only                  P***614,363.53FP
            Dim iSpellBetweenAmt As Short = 58 - Trim(arrSpell(1)).Length


            If spellNumber.Length <= iSpellMaxLenghPerRow Then
                rets.Append(Space(114))
            Else
                rets.Append(Space(66))
                rets.Append(Chr(&H1B) & Chr(&H4D))
                rets.Append(Trim(arrSpell(1)))
                rets.Append(Space(iSpellBetweenAmt) & Chr(&H1B) & Chr(&H50))
            End If

            rets.Append("***")
            rets.Append(strAmount)
            rets.Append(Chr(&H1B) & Chr(&H46) & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)


            'std-line 9
            '*:     614,363.53                     614,363.53                    MFP
            rets.Append(Space(5))

            Dim iAmtBetweenAmt As Short = 31 - strAmount.Length         '36 - xxx - 5

            rets.Append(strAmount & Space(iAmtBetweenAmt) & strAmount & Space(66 - strAmount.Length * 2 - iAmtBetweenAmt - 5))
            rets.Append(Chr(&H1B) & Chr(&H4D))
            rets.Append(Trim(arrSpell(2)))
            rets.Append(Chr(&H1B) & Chr(&H46) & Chr(&H1B) & Chr(&H50))
            rets.Append(LineWrap)

            'std-line 10~22 空行
            'For index As Short = (2 + 9 - 1) To 22      ' 2个<信息头> +  9个<std-line> - 索引起始      <=> 共13个空行
            For index As Short = (2 + 9 + 1) To 22
                rets.Append(LineWrap)
            Next
            rets.Append(Chr(&HC))
        Next

        Return rets.ToString()
    End Function

    Private Function DoPrintHelper_Number_GetArrSpell(sSpell As String) As String()
        '/* 转换逻辑翻译自 v3狐狸仔的Code: */

        Dim ret As String() = New String(8) {String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty}

        Dim iLength As Integer = sSpell.Length
        Dim iArrSize As Integer = Math.Ceiling(iLength / 50)

        Const iCharMax = 50

        Dim iCnt As Integer = 0, iTruncateIndex As Integer, sSpellTemp As String = String.Empty
        Do While iCnt < iArrSize
            If iLength >= iSpellMaxLenghPerRow Then

                If iCnt = 0 Then
                    iTruncateIndex = GfncSubString(sSpell, 1, iCharMax).LastIndexOf(" ")
                    ret(iCnt) = GfncSubString(sSpell, 1, iTruncateIndex)
                    sSpellTemp = sSpell.Substring(iTruncateIndex + 1)
                ElseIf iCnt > 0 Then

                    If iCnt < iArrSize Then
                        iTruncateIndex = GfncSubString(sSpellTemp, 1, iCharMax).LastIndexOf(" ")
                        ret(iCnt) = GfncSubString(sSpellTemp, 1, iTruncateIndex)
                        sSpellTemp = sSpellTemp.Substring(iTruncateIndex + 1)
                    Else
                        iTruncateIndex = GfncSubString(sSpellTemp, 1, iLength - iTruncateIndex + 1).LastIndexOf(" ")
                        ret(iCnt) = GfncSubString(sSpellTemp, 1, iLength - iTruncateIndex + 1)
                    End If

                End If

            Else
                ret(iCnt) = sSpell.Substring(0)
            End If

            iCnt += 1
        Loop

        Return ret

    End Function

#End Region


    '-------------------------

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            'Set cursor
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            'Do it
            DoPrint()
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
        End Try

        'Restore cursor
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
End Class