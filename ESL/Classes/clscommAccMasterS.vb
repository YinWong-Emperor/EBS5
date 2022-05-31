Imports System.Data.SqlClient

Public Class clscommAccMasterS
    Public comm_type_Sec As String = "Sec"
    Public comm_type_Fut As String = "Fut"

    Protected Friend Function GetMaxMonth() As String
        Dim lstrSQL As String = "select max(txmonth) from draft_comm_acc_master_d"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
            Return Now.Year & Format(Val(Now.Month - 1), "00")
        Else
            Return ds.Tables(0).Rows(0).Item(0)
        End If
    End Function

    Protected Friend Function LoadAccNo() As DataSet
        Dim lstrSQL As String = "Select distinct acc_no,ae_no_f, ae_no_s,acc_name_f, acc_name_s, inFut, inSec " & _
                                "from draft_comm_acc_master order by inFut asc, inSec asc, acc_no asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "Acc")
    End Function

    Protected Friend Function LoadAeNo() As DataSet
        Dim lstrSQL As String
        lstrSQL = "Select distinct ae_no,ae_name_s, ae_name_f, inFut, inSec  from draft_comm_ae_master order by ae_no asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "Ae")
    End Function

    Protected Friend Function LoadAeByMonth(ByVal Month As String, ByVal type As String, ByVal Acc As String, _
    ByVal ae As String) As DataSet
        Dim lstrSQL As String = ""
        Select Case type
            Case comm_type_Sec
                lstrSQL = "select distinct a.ae_no_s as ae_no, b.ae_name_s as ae_name from draft_comm_acc_master_d a " & _
                    "left outer join draft_comm_ae_master b on a.ae_no_s= b.ae_no where a.txmonth ='" & Month & _
                    "' and isnull(a.ae_no_s,'') <> '' "
                If Acc.Length > 0 Then
                    lstrSQL += " and a.acc_no='" & Acc & "' "
                End If
                If ae.Length > 0 Then
                    lstrSQL += " and a.ae_no_s ='" & ae & "' "
                End If
                lstrSQL += " order by a.ae_no_s"
            Case comm_type_Fut
                lstrSQL = "select distinct a.ae_no_f as ae_no, b.ae_name_f as ae_name from draft_comm_acc_master_d a " & _
                    "left outer join draft_comm_ae_master b on a.ae_no_f= b.ae_no where a.txmonth ='" & Month & _
                    "' and isnull(a.ae_no_f,'') <> '' "
                If Acc.Length > 0 Then
                    lstrSQL += " and a.acc_no='" & Acc & "' "
                End If
                If ae.Length > 0 Then
                    lstrSQL += " and a.ae_no_f ='" & ae & "' "
                End If
                lstrSQL += " order by a.ae_no_f"
        End Select
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "ae")
    End Function

    Protected Friend Function LoadACCByMonth(ByVal Month As String, ByVal type As String, ByVal ae_no As String, ByVal Acc_no As String) As DataSet
        Dim lstrSQL As String = ""
        Select Case type
            Case comm_type_Sec
                lstrSQL = "select a.acc_no, a.isconsolid, a.isbothfo, a.minNorAmt, a.minIntAmt, a.minNorRate, a.minIntRate, " & _
                    "b.acc_name, isdefault_s as isdefault from draft_comm_acc_master_d a left outer join draft_comm_acc_master b " & _
                    "on a.acc_no =b.acc_no where a.txmonth ='" & Month & "' and isnull(a.ae_no_s,'')<>'' and a.ae_no_s ='" & ae_no & "' "
                If Acc_no.Length > 0 Then
                    lstrSQL += " and a.acc_no='" & Acc_no & "' "
                End If
                lstrSQL += " order by a.acc_no"
            Case comm_type_Fut
                lstrSQL = "select a.acc_no, a.isconsolid, a.isbothfo, a.minNorAmt, a.minIntAmt, a.minNorRate, a.minIntRate, " & _
                    "b.acc_name, isdefault_f as isdefault from draft_comm_acc_master_d a left outer join draft_comm_acc_master b " & _
                    "on a.acc_no =b.acc_no where a.txmonth ='" & Month & "' and isnull(a.ae_no_f,'')<>'' and a.ae_no_f ='" & ae_no & "' "
                If Acc_no.Length > 0 Then
                    lstrSQL += " and a.acc_no='" & Acc_no & "' "
                End If
                lstrSQL += " order by a.acc_no"
        End Select
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "acc")
    End Function

    Protected Friend Function lFncCheckOverlap(ByVal Month As String, ByVal type As String, ByVal ae_no As String, ByVal acc_no As String, ByVal EditMethod As String) As Boolean
        Dim lstrSQL As String = ""
        Select Case type
            Case comm_type_Sec
                lstrSQL = "select * from draft_comm_acc_master_d where txmonth ='" & Month & "' and isnull(ae_no_s,'')<>'' " & _
                            "and ae_no_s ='" & ae_no & "' and acc_no ='" & acc_no & "' order by acc_no"
            Case comm_type_Fut
                lstrSQL = "select * from draft_comm_acc_master_d where txmonth ='" & Month & "' and isnull(ae_no_f,'')<>'' " & _
                            "and ae_no_f ='" & ae_no & "' and acc_no ='" & acc_no & "' order by acc_no"
        End Select
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, lstrSQL)
        Select Case EditMethod
            Case "New", "NewBatch"
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Case "Edit", "EditBatch"
                If ds.Tables(0).Rows.Count <= 0 Then
                    Return True
                Else
                    If ds.Tables(0).Rows.Count > 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
        End Select
    End Function

    Protected Friend Sub lFncInsertACC(ByVal Month As String, ByVal type As String, ByVal ae_no As String, ByVal acc_no As String, _
        ByVal consolidNI As Integer, ByVal consolidFO As Integer, ByVal NorAmt As Double, ByVal NorRate As Double, ByVal IntAmt As Double, _
        ByVal IntRate As Double, ByVal blnisDefault As Boolean, ByVal MyTrans As SqlTransaction, Optional ByVal strACGrp As String = "")
        Dim lstrSQL As String = ""
        Dim logStr As String = ""
        Select Case type
            Case comm_type_Fut
                lstrSQL = "Insert into draft_comm_acc_master_d (acc_no, txmonth, isconsolid, isbothfo, minNorAmt, minNorRate, " & _
                    "minIntAmt, minIntRate, ae_no_f, ae_no_s, isdefault_f, isdefault_s, acc_group_f, acc_group_s) Values ('" & _
                    acc_no & "', '" & Month & "', " & consolidNI & ", " & consolidFO & ", " & NorAmt & ", " & NorRate & ", " & _
                    IntAmt & ", " & IntRate & ", '" & ae_no & "',''," & IIf(blnisDefault, 1, 0) & ",0,'" & strACGrp & "','')"
                logStr = GfncOneFieldLog("Consolid", IIf(CBool(consolidNI) = False, "No", "Yes")) & " " & _
                    GfncOneFieldLog("Consolidate FO", IIf(CBool(consolidFO) = False, "No", "Yes")) & " " & _
                    GfncOneFieldLog("Min. Nor. Amt.", NorAmt) & " " & GfncOneFieldLog("Min. Nor. Rate", NorRate) & " " & _
                    GfncOneFieldLog("Min. Int. Amt.", IntAmt) & " " & GfncOneFieldLog("Min. Int. Rate", IntRate) & " " & _
                    GfncOneFieldLog("Default Futures", IIf(CBool(IIf(blnisDefault, 1, 0)) = False, "No", "Yes")) & " " & _
                    GfncOneFieldLog("Account Group Futures", strACGrp)
            Case comm_type_Sec
                lstrSQL = "Insert into draft_comm_acc_master_d (acc_no, txmonth, isconsolid, isbothfo, minNorAmt, minNorRate, " & _
                    "minIntAmt, minIntRate, ae_no_s, ae_no_f, isdefault_s, isdefault_f,  acc_group_s, acc_group_f) Values ('" & _
                    acc_no & "', '" & Month & "', " & consolidNI & ", " & consolidFO & ", " & NorAmt & ", " & NorRate & ", " & _
                    IntAmt & ", " & IntRate & ", '" & ae_no & "',''," & IIf(blnisDefault, 1, 0) & ",0,'" & strACGrp & "','')"
                logStr = GfncOneFieldLog("Consolid", IIf(CBool(consolidNI) = False, "No", "Yes")) & " " & _
                    GfncOneFieldLog("Consolidate FO", IIf(CBool(consolidFO) = False, "No", "Yes")) & " " & _
                    GfncOneFieldLog("Min. Nor. Amt.", NorAmt) & " " & GfncOneFieldLog("Min. Nor. Rate", NorRate) & " " & _
                    GfncOneFieldLog("Min. Int. Amt.", IntAmt) & " " & GfncOneFieldLog("Min. Int. Rate", IntRate) & " " & _
                    GfncOneFieldLog("Default Securities", IIf(CBool(IIf(blnisDefault, 1, 0)) = False, "No", "Yes")) & " " & _
                    GfncOneFieldLog("Account Group Securities", strACGrp)
        End Select
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        GFncFillLog(GStrloginID, "A", GDteTradeDate, "ACMaster", ae_no, acc_no, 0, Month, logStr, MyTrans)
    End Sub

    Protected Friend Sub lFncInsertName(ByVal acc_no As String, ByVal Name As String, ByVal MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "Update draft_comm_acc_master Set acc_name='" & Name & "' where acc_no='" & acc_no & "' "
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Sub

    Protected Friend Sub lFncEditACC(ByVal Month As String, ByVal type As String, ByVal ae_no As String, ByVal acc_no As String, _
        ByVal consolidNI As Integer, ByVal consolidFO As Integer, ByVal NorAmt As Double, ByVal NorRate As Double, ByVal IntAmt As Double, _
        ByVal IntRate As Double, ByVal blnisDefault As Boolean, ByVal MyTrans As SqlTransaction, Optional ByVal strACGrp As String = "")
        Dim lstrSQL As String = ""
        Dim logStr As String = ""
        Dim oldDt As DataTable
        Dim oldConsolidNI As String = ""
        Dim oldConsolidFO As String = ""
        Dim oldNorAmt As Double = 0
        Dim oldNorRate As Double = 0
        Dim oldIntAmt As Double = 0
        Dim oldIntRate As Double = 0
        Dim oldStrACGrp As String = ""
        Dim oldBlnisDefault As String = ""
        Select Case type
            Case comm_type_Fut
                lstrSQL = "Update draft_comm_acc_master_d Set isconsolid=" & consolidNI & ", isbothfo=" & consolidFO & _
                    ", minNorAmt = " & NorAmt & ", minNorRate = " & NorRate & ", minIntAmt = " & IntAmt & ", minIntRate = " & _
                    IntRate & ", acc_group_f = '" & strACGrp & "', isdefault_f = " & IIf(blnisDefault, 1, 0) & _
                    " where acc_no ='" & acc_no & "' and  txmonth='" & Month & "' and ae_no_f = '" & ae_no & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_acc_master_d where acc_no ='" & acc_no & _
                    "' and txmonth='" & Month & "' and ae_no_f = '" & ae_no & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldConsolidNI = GFncNoNullString(oldDt.Rows(0).Item("isconsolid")).Trim
                    If oldConsolidNI = "" Then
                        oldConsolidNI = "False"
                    End If
                    oldConsolidFO = GFncNoNullString(oldDt.Rows(0).Item("isbothfo")).Trim
                    If oldConsolidFO = "" Then
                        oldConsolidFO = "False"
                    End If
                    oldNorAmt = GFncNoNullValue(oldDt.Rows(0).Item("minNorAmt"))
                    oldNorRate = GFncNoNullValue(oldDt.Rows(0).Item("minNorRate"))
                    oldIntAmt = GFncNoNullValue(oldDt.Rows(0).Item("minIntAmt"))
                    oldIntRate = GFncNoNullValue(oldDt.Rows(0).Item("minIntRate"))
                    oldStrACGrp = GFncNoNullString(oldDt.Rows(0).Item("acc_group_f")).Trim
                    oldBlnisDefault = GFncNoNullString(oldDt.Rows(0).Item("isdefault_f")).Trim
                End If
                If oldStrACGrp.Trim <> strACGrp.Trim Then
                    logStr &= GfncOneFieldLog("Account Group Futures", oldStrACGrp.Trim, strACGrp.Trim) & " "
                End If
                If CBool(oldBlnisDefault) <> CBool(blnisDefault) Then
                    logStr &= GfncOneFieldLog("Default Futures", IIf(CBool(oldBlnisDefault) = False, "No", "Yes"), IIf(CBool(blnisDefault) = False, "No", "Yes")) & " "
                End If
            Case comm_type_Sec
                lstrSQL = "Update draft_comm_acc_master_d Set isconsolid=" & consolidNI & ", isbothfo=" & consolidFO & _
                    ", minNorAmt = " & NorAmt & ", minNorRate = " & NorRate & ", minIntAmt = " & IntAmt & ", minIntRate = " & _
                    IntRate & ", acc_group_s = '" & strACGrp & "', isdefault_s = " & IIf(blnisDefault, 1, 0) & _
                    " where acc_no ='" & acc_no & "' and txmonth='" & Month & "' and ae_no_s = '" & ae_no & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_acc_master_d where acc_no ='" & acc_no & _
                    "' and txmonth='" & Month & "' and ae_no_s = '" & ae_no & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldConsolidNI = GFncNoNullString(oldDt.Rows(0).Item("isconsolid")).Trim
                    If oldConsolidNI = "" Then
                        oldConsolidNI = "False"
                    End If
                    oldConsolidFO = GFncNoNullString(oldDt.Rows(0).Item("isbothfo")).Trim
                    If oldConsolidFO = "" Then
                        oldConsolidFO = "False"
                    End If
                    oldNorAmt = GFncNoNullValue(oldDt.Rows(0).Item("minNorAmt"))
                    oldNorRate = GFncNoNullValue(oldDt.Rows(0).Item("minNorRate"))
                    oldIntAmt = GFncNoNullValue(oldDt.Rows(0).Item("minIntAmt"))
                    oldIntRate = GFncNoNullValue(oldDt.Rows(0).Item("minIntRate"))
                    oldStrACGrp = GFncNoNullString(oldDt.Rows(0).Item("acc_group_s")).Trim
                    oldBlnisDefault = GFncNoNullString(oldDt.Rows(0).Item("isdefault_s")).Trim
                End If
                If oldStrACGrp.Trim <> strACGrp.Trim Then
                    logStr &= GfncOneFieldLog("Account Group Securities", oldStrACGrp.Trim, strACGrp.Trim)
                End If
                If CBool(oldBlnisDefault) <> CBool(blnisDefault) Then
                    logStr &= GfncOneFieldLog("Default Securities", IIf(CBool(oldBlnisDefault) = False, "No", "Yes"), IIf(CBool(blnisDefault) = False, "No", "Yes"))
                End If
        End Select
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        If oldIntRate <> IntRate Then
            logStr = GfncOneFieldLog("Min. Int. Rate", oldIntRate, IntRate) & " " & logStr
        End If
        If oldIntAmt <> IntAmt Then
            logStr = GfncOneFieldLog("Min. Int. Amt.", oldIntAmt, IntAmt) & " " & logStr
        End If
        If oldNorRate <> NorRate Then
            logStr = GfncOneFieldLog("Min. Nor. Rate", oldNorAmt, NorAmt) & " " & logStr
        End If
        If oldNorAmt <> NorAmt Then
            logStr = GfncOneFieldLog("Min. Nor. Amt.", oldNorAmt, NorAmt) & " " & logStr
        End If
        If CBool(oldConsolidFO) <> CBool(consolidFO) Then
            logStr = GfncOneFieldLog("Consolidate FO", IIf(CBool(oldConsolidFO) = False, "No", "Yes"), IIf(CBool(consolidFO) = False, "No", "Yes")) & " " & logStr
        End If
        If CBool(oldConsolidNI) <> CBool(consolidNI) Then
            logStr = GfncOneFieldLog("Consolid", IIf(CBool(oldConsolidNI) = False, "No", "Yes"), IIf(CBool(consolidNI) = False, "No", "Yes")) & " " & logStr
        End If
        GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACMaster", ae_no, acc_no, 0, Month, logStr, MyTrans)
    End Sub

    Protected Friend Sub lFncDeleteAcc(ByVal Acc As String, ByVal ae_no As String, ByVal type As String, ByVal comm_month As String, ByVal MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        Dim logstr As String = ""
        Select Case type
            Case comm_type_Fut
                lstrSQL = "Delete from draft_comm_acc_master_d where acc_no = '" & Acc & "' and ae_no_f = '" & ae_no & _
                            "' and txmonth ='" & comm_month & "' "
                logstr = GfncOneFieldLog("AE No Futures", ae_no)
            Case comm_type_Sec
                lstrSQL = "Delete from draft_comm_acc_master_d where acc_no = '" & Acc & "' and ae_no_s = '" & ae_no & _
                            "' and txmonth ='" & comm_month & "' "
                logstr = GfncOneFieldLog("AE No Securities", ae_no)
        End Select
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        GFncFillLog(GStrloginID, "D", GDteTradeDate, "ACMaster", ae_no, Acc, 0, comm_month, logstr, MyTrans)
    End Sub

    Protected Friend Function BatchEdit(ByVal Month As String, ByVal type As String, ByVal ae As String) As DataSet
        Dim lstrSQL As String = ""
        Select Case type
            Case comm_type_Fut
                lstrSQL = "select acc_no, isconsolid, isbothfo, isdefault_f as isdefault, minNorAmt, minNorRate, minIntAmt, " & _
                    "minIntRate, 'False' as selection from draft_comm_acc_master_d where txmonth='" & Month & _
                    "' and isnull(ae_no_f,'')<>'' "
                If ae <> "" Then
                    lstrSQL += " and ae_no_f ='" & ae & "'"
                End If
            Case comm_type_Sec
                lstrSQL = "select acc_no, isconsolid, isbothfo, isdefault_s as isdefault, minNorAmt, minNorRate, minIntAmt, " & _
                    "minIntRate, 'False' as selection from draft_comm_acc_master_d where txmonth='" & Month & _
                    "' and isnull(ae_no_s,'')<>'' "
                If ae <> "" Then
                    lstrSQL += " and ae_no_s ='" & ae & "'"
                End If
        End Select
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "BatchEdit")
    End Function

    Protected Friend Function BatchAdd(ByVal Month As String, ByVal type As String, ByVal ae As String) As DataSet
        Dim lstrSQL As String = ""
        Dim condition As String = ""
        Select Case type
            Case comm_type_Fut
                If ae <> "" Then
                    condition = "and ae_no_f ='" & ae & "'"
                End If
                lstrSQL = "select acc_no, isconsolid=0, isbothfo=0, 0 as isdefault, minNorAmt='', minNorRate='', minIntAmt='', " & _
                    "minIntRate='', 'False' as selection from draft_comm_acc_master where infut=1 " & condition & _
                    " and acc_no not in (select acc_no from draft_comm_acc_master_d where txmonth='" & Month & _
                    "' and isnull(ae_no_f,'')<>''  " & condition & ") order by acc_no"
            Case comm_type_Sec
                If ae <> "" Then
                    condition = "and ae_no_s ='" & ae & "'"
                End If
                lstrSQL = "select acc_no, isconsolid=0, isbothfo=0, 0 as isdefault, minNorAmt='', minNorRate='', minIntAmt='', " & _
                    "minIntRate='', 'False' as selection from draft_comm_acc_master where inSec=1 " & condition & _
                    " and acc_no not in (select acc_no from draft_comm_acc_master_d where txmonth='" & Month & _
                    "' and isnull(ae_no_s,'')<>''  " & condition & ") order by acc_no"
        End Select
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "BatchAdd")
    End Function

    Protected Friend Function lFncExistAcc(ByVal comm_month As String, ByVal type As String, ByVal ae_no As String, ByVal MyTrans As SqlTransaction) As DataTable
        Dim lstrSQL As String = ""
        Select Case type
            Case comm_type_Fut
                lstrSQL = "Select acc_no, txmonth from draft_comm_acc_master_d where txmonth='" & comm_month & "' and ae_no_f ='" & ae_no & "' "
            Case comm_type_Sec
                lstrSQL = "Select acc_no, txmonth from draft_comm_acc_master_d where txmonth='" & comm_month & "' and ae_no_s ='" & ae_no & "' "
        End Select
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)

    End Function
End Class
