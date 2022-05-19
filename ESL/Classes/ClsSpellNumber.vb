'/* 摘自网络 再根据v3的code修改 */

Option Explicit On

Public Class ClsSpellNumber

    Public Shared Function SpellNumber(ByVal MyNumber)
        Dim Dollars, Cents, Temp, Cents1
        Dim DecimalPlace, Count
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Million "
        Place(4) = " Billion "
        Place(5) = " Trillion "
        ' 字符串表示的金额。
        MyNumber = Trim(Str(MyNumber))
        ' Position of decimal place 0 if none.小数点后的位置0如果没有。
        DecimalPlace = InStr(MyNumber, ".")
        ' Convert cents and set MyNumber to dollar amount.MyNumber转换美分和设置,金额。
        If DecimalPlace > 0 Then
            Cents = Left(Mid(MyNumber, DecimalPlace + 1) & _
                      "00", 2)
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If
        Count = 1
        Cents1 = GetCents(Cents)
        Do While MyNumber <> ""
            Temp = GetHundreds(Right(MyNumber, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(MyNumber) > 3 Then
                MyNumber = Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        Select Case Dollars
            Case ""
                Dollars = "No Dollars"
            Case "One"
                Dollars = "One Dollar"
            Case Else
                Dollars = Dollars & " Dollars"
        End Select
        Select Case Cents1
            Case ""
                Cents1 = " Only"
            Case "One"
                Cents1 = " and One Cent Only"
            Case Else
                Cents1 = "  and " & Cents1 & " Cents Only"
        End Select
        SpellNumber = Dollars & Cents1
        Do While InStr(SpellNumber, "  ") > 0
            SpellNumber = Replace(SpellNumber, "  ", " ")
        Loop
    End Function

    ' Converts a number from 100-999 into text转换数字100 - 999进入文本
    Shared Function GetHundreds(ByVal MyNumber)
        Dim Result As String
        If Val(MyNumber) = 0 Then Exit Function
        MyNumber = Right("000" & MyNumber, 3)
        ' Convert the hundreds place.转换百的地方。
        If Mid(MyNumber, 1, 1) <> "0" Then
            'Start e20190315 Chris
            'Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred and "
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
            'End e20190315 Chris
        End If
        ' Convert the tens and ones place.转换千的地方。
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function

    ' Converts a number from 10 to 99 into text.转换数字从10到99成文本。
    Shared Function GetTens(TensText)
        Dim Result As String
        Result = ""           ' Null out the temporary function value.空出暂时的函数值。
        If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Val(Left(TensText, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit _
                (Right(TensText, 1))  ' Retrieve ones place.检索的地方。
        End If
        GetTens = Result
    End Function

    ' Converts a number from 1 to 9 into text.
    Shared Function GetDigit(Digit)
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function
    Shared Function GetCents(ByVal Cents)
        Dim Result As String
        Result = ""
        If Val(Left(Cents, 1)) = 1 Then
            Select Case Val(Cents)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        ElseIf Val(Mid(Cents, 1, 1)) = 0 Then
            Select Case Val(Left(Cents, 2))
                Case 1 : Result = "One"
                Case 2 : Result = "Two"
                Case 3 : Result = "Three"
                Case 4 : Result = "Four"
                Case 5 : Result = "Five"
                Case 6 : Result = "Six"
                Case 7 : Result = "Seven"
                Case 8 : Result = "Eight"
                Case 9 : Result = "Nine"
                Case Else
            End Select
        Else
            Select Case Val(Left(Cents, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit _
                (Right(Cents, 1))
        End If
        GetCents = Result
    End Function

End Class