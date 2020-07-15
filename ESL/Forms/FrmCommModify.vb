'Imports System.Data.SqlClient

Public Class FrmCommModify
    Private stateFlag As String
    Dim cls As New ClsCommModify
    Dim myObj As String
    Dim FormLoad As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            stateFlag = ""
            emptyFields()
            CommTradeGrid_SelectionChanged(Nothing, System.EventArgs.Empty)
            Me.CommTradeGrid.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sql As String
        Dim sql_log As String = ""
        Dim warning As String = ""
        Dim type As Integer
        If Me.MTtype.Text = "I-trade" Then
            type = 4
        Else
            type = 0
        End If

        Select Case stateFlag
            Case "Add"
                warning = Validation()
             
                If warning.Length > 0 Then

                    GSubShowError(warning + " is/are missing!")
                    Return
                End If
                If GSubShowYNConfirm("Are you sure to Add?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Me.MOid.Text = cls.GetNewID()
                sql = "'" & Me.MYr.Text.Trim & Format(CInt(Me.MMonth.Text.Trim), "00").ToString.Trim & "', '" & "" & "', '" & "" & "', '" & _
                                            Format(Me.MTDate.Value, "MM/dd/yyyy") & "', '" & Me.MOid.Text.Trim & "', '" & Me.MStk.Text.Trim & "', " & _
                                            Me.MPrice.Text.Trim & ", " & Me.MQty.Text & ", " & Me.MgrossAmt.Text.Trim & "," & Me.MComm.Text.Trim & ", " & _
                                            Me.MCommRate.Text.Trim & ", '" & type.ToString & "' , GETDATE(), " & _
                                            " '" & GStrloginID & "'" & ", 'A', '" & Me.MAE.Text.Trim & "', '" & Me.MAC.Text.Trim & "' "
                sql_log = "'" & GStrloginID & "', '" & Format(Now, "MM/dd/yyyy hh:mm:ss") & "', 'A', 'CommAdj', '" & _
                    Me.MAE.Text.Trim & "', '" & Me.MAC.Text.Trim & "', '" & Format(Me.MTDate.Value, "MM/dd/yyyy") & "', " & _
                    "'" & Me.MOid.Text.Trim & "', '" & Me.MYr.Text.Trim & Format(CInt(Me.MMonth.Text.Trim), "00").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog(Nothing)) & "'"
                cls.AddAdj(sql, sql_log)
                myObj = Me.MOid.Text.Trim
                Me.CboAdjSYr.Text = Me.MYr.Text
                Me.CboAdjSMonth.Text = Me.MMonth.Text
                EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
            Case "Modify"
                warning = Validation()
                If warning.Length > 0 Then
                    GSubShowError(warning + " is/are missing!")
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(39), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                'check modified
                Dim newestValDT As DataTable = cls.GetNewestVal(Me.MOid.Text.Trim)
                If newestValDT.Rows.Count <= 0 Then
                    GSubShowError(GFncGetSysMsg(9))
                    Return
                End If
                If newestValDT.Rows(0).Item("adjaction") = "Deleted" Then 'return when it is already deleted
                    GSubShowError(GFncGetSysMsg(9))
                    Return
                End If
                If newestValDT.Rows(0).Item("adjaction") <> "" Then ' Action ='New' 'Adjusted'

                    sql = "aeno='" & Me.MAE.Text & "', acno='" & Me.MAC.Text & "', qty=" & Me.MQty.Text & _
                            ", ae='" & "" & "', acct='" & "" & "'" & _
                            ", commission =" & Me.MComm.Text & ", comm_rate = " & Me.MCommRate.Text & ", grossamt =" & Me.MgrossAmt.Text.Trim & _
                            ", lastupduser ='" & GStrloginID & "', lastupddate = GETDATE()" & _
                            " , adjaction='" & GetAdjCode(Me.CommTradeGrid.CurrentRow.Cells("adjaction").Value.ToString.Trim) & "', tradetype='" & type & "'"
                    sql_log = "'" & GStrloginID & "', GETDATE(), " & _
                                    "'" & GetAdjCode(newestValDT.Rows(0).Item("adjaction").ToString.Trim) & "'" & _
                                    ", 'CommAdj', '" & _
                                    newestValDT.Rows(0).Item("aeno").ToString.Trim & "', '" & _
                                    newestValDT.Rows(0).Item("accno").ToString.Trim & "', '" & _
                                    Format(newestValDT.Rows(0).Item("tdate"), "MM/dd/yyyy") & "', " & _
                                    "'" & newestValDT.Rows(0).Item("oid").ToString.Trim & "', '" & _
                                     newestValDT.Rows(0).Item("txmonth") & "', '" & GFncSqlQuote(fncGenLog(newestValDT)) & "'"
                    cls.UpdateAdj(CommTradeGrid.CurrentRow.Cells("oid").Value, sql, sql_log)
                    myObj = Me.MOid.Text.Trim
                    EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
                Else  ' unadj transection

                    sql = "'" & Me.MYr.Text.Trim & Format(CInt(Me.MMonth.Text.Trim), "00").ToString.Trim & "', '" & "" & "', '" & "" & "', '" & _
                            Format(Me.MTDate.Value, "MM/dd/yyyy") & "', '" & Me.MOid.Text.Trim & "', '" & Me.MStk.Text.Trim & "', " & _
                            Me.MPrice.Text.Trim & ", " & Me.MQty.Text.Trim & ", " & Me.MgrossAmt.Text.Trim & "," & Me.MComm.Text.Trim & ", " & _
                            Me.MCommRate.Text.Trim & ", '" & type & "' , GETDATE(), " & _
                            " '" & GStrloginID & "'" & ", 'M', '" & Me.MAE.Text.Trim & "', '" & Me.MAC.Text.Trim & "' "
                    sql_log = "'" & GStrloginID & "', GETDATE(), 'M', 'CommAdj', '" & _
                                                        newestValDT.Rows(0).Item("aeno") & "', '" & _
                                                         newestValDT.Rows(0).Item("accno") & "', '" & _
                                                        Format(newestValDT.Rows(0).Item("tdate"), "MM/dd/yyyy") & "', " & _
                                                        "'" & newestValDT.Rows(0).Item("oid") & "', '" & _
                                                       newestValDT.Rows(0).Item("txmonth") & "', '" & GFncSqlQuote(fncGenLog(newestValDT)) & "'"
                    cls.AddAdj(sql, sql_log)
                    myObj = Me.MOid.Text.Trim
                    EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
                End If
        End Select
        stateFlag = ""
        Me.CommTradeGrid.Focus()
    End Sub

    Private Sub MyButtonModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonModify.Click
        EnableObj(True, False, False)
        Me.MYr.Enabled = False
        Me.MMonth.Enabled = False
        Me.MStk.Enabled = False
        Me.MTDate.Enabled = False
        'Me.MTtype.Enabled = False
        Me.MPrice.Enabled = False
        stateFlag = "Modify"
        Me.MAE.Focus()
    End Sub

    Private Sub EnableObj(ByVal blnFlag As Boolean, ByVal buttonAdd As Boolean, ByVal buttonFlag As Boolean)
        Me.MAC.Enabled = blnFlag
        Me.MAE.Enabled = blnFlag
        Me.MComm.Enabled = blnFlag
        Me.MCommRate.Enabled = blnFlag
        Me.MOid.Enabled = False
        Me.MQty.Enabled = blnFlag
        Me.MgrossAmt.Enabled = blnFlag
        Me.MyButtonAdd.Enabled = buttonAdd
        Me.MyButtonDel.Enabled = buttonFlag
        Me.MyButtonModify.Enabled = buttonFlag
        Me.btnSave.Enabled = blnFlag
        'Me.btnCancel.Enabled = True
        Me.CommTradeGrid.Enabled = Not blnFlag
        Me.MYr.Enabled = blnFlag
        Me.MMonth.Enabled = blnFlag
        'Me.MAeName.Enabled = blnFlag
        'Me.MAccName.Enabled = blnFlag
        Me.MTDate.Enabled = blnFlag
        Me.MStk.Enabled = blnFlag
        'Me.MStkName.Enabled = blnFlag
        Me.MPrice.Enabled = blnFlag
        Me.MTtype.Enabled = blnFlag
        Me.tc.Enabled = Not blnFlag
        'Me.SearchBox.Enabled = Not blnFlag
    End Sub

    Private Sub emptyFields()
        Me.MOid.Text = ""
        Me.MQty.Text = 0
        Me.MCommRate.Text = ""
        Me.MComm.Text = ""
        Me.MAC.Text = ""
        Me.MAE.Text = ""
        'Me.MAccName.Text = ""
        'Me.MAeName.Text = ""
        Me.MMonth.Text = Now.Month
        Me.MYr.Text = Now.Year
        Me.MPrice.Text = ""
        Me.MStk.Text = ""
        'Me.MStkName.Text = ""
        Me.MTDate.Text = Now.Date
        Me.MTtype.Text = "Normal"
        Me.MgrossAmt.Text = ""
    End Sub

    Private Sub EnqToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnqToolStripButton.Click
        ' Dim CommView As DataTable
        Dim condition1 As String = ""
        Dim condition2 As String = ""
        Dim Displaytype As String = "All"
        Select Case Me.tc.SelectedTab().Name()
            Case "tp1"
                condition1 += " and year(tdate)=" & Me.CboAdjSYr.Text.Trim & " and month(tdate)=" & Me.CboAdjSMonth.Text.Trim & " "
                condition2 += " and year(tdate)=" & Me.CboAdjSYr.Text.Trim & " and month(tdate)=" & Me.CboAdjSMonth.Text.Trim & " "
                If Me.MyRadioButtonAll.Checked Then
                    Displaytype = "All"
                End If
                If Me.MyRadioButtonAdj.Checked Then
                    Displaytype = "Adjusted"
                End If
                If Me.MyRadioButtonDel.Checked Then
                    Displaytype = "Deleted"
                End If

            Case "tp2"

                If RadioOID.Checked Then
                    condition1 += " and oid='" & Me.SOid.Text & "'"
                    condition2 += " and oid='" & Me.SOid.Text & "'"
                    Displaytype = "Oid"
                Else
                    condition1 += " and year(tdate)=" & Me.SYr.Text.Trim & " and month(tdate)=" & Me.SMonth.Text.Trim & " "
                    condition2 += " and year(tdate)=" & Me.SYr.Text.Trim & " and month(tdate)=" & Me.SMonth.Text.Trim & " "
                    If MyCheckBoxDate.Checked Then
                        condition1 += " and day(tdate)=" & SDay.Text.Trim & " "
                        condition2 += " and day(tdate)=" & SDay.Text.Trim & " "
                    End If
                    If Me.MyCheckBoxAE.Checked Then
                        If Me.SAccNo.Text.Trim.Length > 0 Then
                            condition1 += " and upper(acno) like '%" & Me.SAccNo.Text.Trim.ToUpper & "%' "
                            condition2 += " and upper(accno) like '%" & Me.SAccNo.Text.Trim.ToUpper & "%' "
                        End If
                        If Me.SAccName.Text.Trim.Length > 0 Then
                            condition1 += " and upper(acct) like '%" & Me.SAccName.Text.Trim.ToUpper & "%'"
                            condition2 += " and upper(accname) like '%" & Me.SAccName.Text.Trim.ToUpper & "%'"
                        End If
                        If Me.SAeNo.Text.Trim.Length > 0 Then
                            condition1 += " and upper(aeno) like '%" & Me.SAeNo.Text.Trim.ToUpper & "%' "
                            condition2 += " and upper(aeno) like '%" & Me.SAeNo.Text.Trim.ToUpper & "%' "
                        End If
                        If Me.SAeName.Text.Trim.Length > 0 Then
                            condition1 += " and upper(ae) like '%" & Me.SAeName.Text.Trim.ToUpper & "%'"
                            condition2 += " and upper(aename) like '%" & Me.SAeName.Text.Trim.ToUpper & "%'"
                        End If
                    End If
                    If Me.MyRadioButtonAll.Checked Then
                        Displaytype = "All"
                    End If
                    If Me.MyRadioButtonAdj.Checked Then
                        Displaytype = "Adjusted"
                    End If
                    If Me.MyRadioButtonDel.Checked Then
                        Displaytype = "Deleted"
                    End If
                End If
                Me.CboAdjSYr.Text = Me.SYr.Text
                Me.CboAdjSMonth.Text = Me.SMonth.Text
                Me.MyRadioButtonAdj.Checked = Me.RBAdj.Checked
                Me.MyRadioButtonAll.Checked = Me.RBAll.Checked
                Me.MyRadioButtonDel.Checked = Me.RBDel.Checked
        End Select
        EnableObj(False, True, False)
        Me.emptyFields()
        CommTradeGrid.DataSource = cls.Search(condition1, condition2, Displaytype)
        CommTradeGrid_SelectionChanged(Nothing, System.EventArgs.Empty)
        If Me.MyRadioButtonDel.Checked Then
            Me.MyButtonAdd.Enabled = False
        End If
        Me.tc.SelectTab("tp1")

        If myObj.Length > 0 Then
            lsubGoRecord()
        End If

        Me.CommTradeGrid.Focus()
        'showbgcolor()
    End Sub

    Private Sub CommTradeGrid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CommTradeGrid.SelectionChanged
        If CommTradeGrid.SelectedRows.Count > 0 Then
            Me.MAE.Text = CommTradeGrid.CurrentRow.Cells("ae").Value.ToString.Trim
            'Me.MAeName.Text = CommTradeGrid.CurrentRow.Cells("aename").Value.ToString.Trim
            Me.MAC.Text = CommTradeGrid.CurrentRow.Cells("accno").Value.ToString.Trim
            'Me.MAccName.Text = CommTradeGrid.CurrentRow.Cells("accname").Value.ToString.Trim
            Me.MTDate.Text = CommTradeGrid.CurrentRow.Cells("tdate").Value.ToString.Trim
            Me.MComm.Text = CommTradeGrid.CurrentRow.Cells("commission").Value.ToString.Trim
            Me.MCommRate.Text = CommTradeGrid.CurrentRow.Cells("comm_rate").Value.ToString.Trim
            Me.MOid.Text = CommTradeGrid.CurrentRow.Cells("oid").Value.ToString.Trim
            Me.MQty.Text = CommTradeGrid.CurrentRow.Cells("qty").Value
            Me.MStk.Text = CommTradeGrid.CurrentRow.Cells("stkno").Value.ToString.Trim
            'Me.MStkName.Text = CommTradeGrid.CurrentRow.Cells("stkname").Value.ToString.Trim
            Me.MPrice.Text = CommTradeGrid.CurrentRow.Cells("avgprice").Value.ToString.Trim
            Me.MTtype.Text = CommTradeGrid.CurrentRow.Cells("tradetype").Value.ToString.Trim
            Me.MYr.Text = CommTradeGrid.CurrentRow.Cells("txmonth").Value.ToString.Trim.Substring(0, 4)
            Me.MMonth.Text = CInt(CommTradeGrid.CurrentRow.Cells("txmonth").Value.ToString.Trim.Substring(4, 2))
            Me.MgrossAmt.Text = Me.CommTradeGrid.CurrentRow.Cells("grossamt").Value.ToString.Trim

            If GFncNoNullString(Me.CommTradeGrid.CurrentRow.Cells("AdjAction").Value) = "Deleted" Then
                EnableObj(False, False, False)
                Me.MyButtonDel.Text = "Restore"
                Me.MyButtonDel.Enabled = True
            Else
                Me.MyButtonDel.Text = "Delete"
                EnableObj(False, True, True)
            End If
            MyButtonAdd.Focus()
        End If

    End Sub

    Private Sub FrmCommModify_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        myObj = ""
        FormLoad = True

        For yr As Integer = Now.Year - 5 To Now.Year + 5
            Me.SYr.Items.Add(yr)
            Me.CboAdjSYr.Items.Add(yr)
            Me.MYr.Items.Add(yr)
        Next
        For mon As Integer = 1 To 12
            Me.SMonth.Items.Add(mon)
            Me.MMonth.Items.Add(mon)
            Me.CboAdjSMonth.Items.Add(mon)
        Next
        For day As Integer = 1 To 31
            Me.SDay.Items.Add(day)
        Next
        Me.MTtype.Items.Add("Normal")
        Me.MTtype.Items.Add("I-trade")
        GetAeAcCode()
        'Me.SYr.Text = Now.Year
        'Me.SMonth.Text = Now.Month
        emptySearch()
        EnableObj(False, True, False)
        EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)

        RadioOID_CheckedChanged(Nothing, System.EventArgs.Empty)
        FormLoad = False
    End Sub

    Private Sub SearchObjEnable(ByVal blnFlag As Boolean)
        SOid.Enabled = Not blnFlag
        'Me.MyCheckBoxAcc.Enabled = blnFlag
        Me.MyCheckBoxAE.Enabled = blnFlag
        Me.MyCheckBoxDate.Enabled = blnFlag
        'Me.MyCheckBoxTDate.Enabled = blnFlag
        If blnFlag Then
            '    'MyCheckBoxAcc_CheckedChanged(Nothing, System.EventArgs.Empty)
            MyCheckBoxDate_CheckedChanged(Nothing, System.EventArgs.Empty)
            MyCheckBoxAE_CheckedChanged(Nothing, System.EventArgs.Empty)
            '    'MyCheckBoxTDate_CheckedChanged(Nothing, System.EventArgs.Empty)
        Else
            'Me.SYr.Enabled = False
            'Me.SMonth.Enabled = False
            'Me.STDate.Enabled = blnFlag
            SAccNo.Enabled = blnFlag
            SAccName.Enabled = blnFlag
            SAeNo.Enabled = blnFlag
            SAeName.Enabled = blnFlag
            SDay.Enabled = blnFlag
        End If
        SYr.Enabled = blnFlag
        SMonth.Enabled = blnFlag
        Me.PanelAdj.Enabled = blnFlag
        'MyRadioButtonAdj.Enabled = blnFlag
        'MyRadioButtonAll.Enabled = blnFlag
    End Sub

    Private Sub RadioOID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioOID.CheckedChanged
        If RadioOID.Checked Then
            'Me.SOid.Enabled = RadioOID.Checked
            SearchObjEnable(False)
        Else
            SearchObjEnable(True)
        End If
    End Sub

    Private Sub MyCheckBoxDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyCheckBoxDate.CheckedChanged
        'Dim modify As Boolean = MyCheckBoxDate.Checked
        SDay.Enabled = MyCheckBoxDate.Checked

    End Sub

    Private Sub MyCheckBoxAE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyCheckBoxAE.CheckedChanged
        'Dim modify As Boolean = Me.MyCheckBoxAE.Checked
        Me.SAeNo.Enabled = Me.MyCheckBoxAE.Checked
        Me.SAeName.Enabled = Me.MyCheckBoxAE.Checked
        Me.SAccNo.Enabled = Me.MyCheckBoxAE.Checked
        Me.SAccName.Enabled = Me.MyCheckBoxAE.Checked
    End Sub

    Private Sub MyButtonResetSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonResetSearch.Click
        Dim ans As DialogResult = GSubShowYNConfirm("Are you sure to Reset the search fields?", MessageBoxDefaultButton.Button2)
        If ans = Windows.Forms.DialogResult.No Then
            Return
        End If
        RadioOther.Checked = True
        'MyCheckBoxTDate.Checked = False
        'Me.MyCheckBoxAcc.Checked = False
        Me.MyCheckBoxAE.Checked = False
        Me.MyCheckBoxDate.Checked = False
        RBAll.Checked = True
        emptySearch()
        SearchObjEnable(True)
    End Sub

    Private Sub emptySearch()
        Dim yr As Integer
        Dim mon As Integer
        Dim Day As Integer
        SearchLatestDate(yr, mon, Day)
        Me.SOid.Text = ""
        Me.SAccName.Text = ""
        Me.SAccNo.Text = ""
        Me.SAeName.Text = ""
        Me.SAeNo.Text = ""
        Me.SMonth.Text = mon
        Me.CboAdjSMonth.Text = mon
        Me.CboAdjSYr.Text = yr
        Me.SYr.Text = yr
        Me.SDay.Text = Day
    End Sub

    Private Sub SearchLatestDate(ByRef yr As Integer, ByRef mon As Integer, ByRef tdate As Integer)
        Dim day As Date = Nothing
        Dim sql As String = "select max(a.tdate) from (select max(a.tdate)as tdate from view_comm_trade_s a left outer join comm_adj_s b on a.oid=b.oid where isnull(b.adjaction,'') <>'D' union select max(tdate)as tdate from comm_adj_s where isnull(adjaction,'') <>'D') a"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            day = dt.Rows(0).Item(0)
            yr = day.Year
            mon = day.Month
            tdate = day.Day
        Else
            yr = Now.Year
            mon = Now.Month
            tdate = Now.Day
        End If
    End Sub

    Private Function fncGenLog(ByVal DT As DataTable) As String
        Dim lstrLog As String = ""
        If stateFlag = "Modify" Then
            If Me.MAE.Text <> DT.Rows(0).Item("aeno").ToString.Trim Then
                lstrLog += GfncOneFieldLog("AE", DT.Rows(0).Item("aeno").ToString.Trim, _
                                Me.MAE.Text)
            End If
            'If Me.MAeName.Text <> Me.CommTradeGrid.CurrentRow.Cells("aename").Value.ToString.Trim Then
            '    lstrLog += GfncOneFieldLog("AeName", Me.CommTradeGrid.CurrentRow.Cells("aename").Value.ToString.Trim, _
            '                                    Me.MAeName.Text)
            'End If
            If Me.MAC.Text <> DT.Rows(0).Item("accno").ToString.Trim Then
                lstrLog += GfncOneFieldLog("ACC", DT.Rows(0).Item("accno").ToString.Trim, _
                                Me.MAC.Text)
            End If
            'If Me.MAccName.Text <> Me.CommTradeGrid.CurrentRow.Cells("accname").Value.ToString.Trim Then
            '    lstrLog += GfncOneFieldLog("AccName", Me.CommTradeGrid.CurrentRow.Cells("accname").Value.ToString.Trim, _
            '                                    Me.MAccName.Text)
            'End If
            If Me.MQty.Text <> DT.Rows(0).Item("qty").ToString.Trim Then
                lstrLog += GfncOneFieldLog("Quality", DT.Rows(0).Item("qty").ToString.Trim, _
                                Me.MQty.Text)
            End If
            If Me.MComm.Text <> DT.Rows(0).Item("comm").ToString.Trim Then
                lstrLog += GfncOneFieldLog("Comm", DT.Rows(0).Item("comm").ToString.Trim, _
                                Me.MComm.Text)
            End If
            If Me.MCommRate.Text <> DT.Rows(0).Item("comm_rate").ToString.Trim Then
                lstrLog += GfncOneFieldLog("CommRate", DT.Rows(0).Item("comm_rate").ToString.Trim, _
                                Me.MCommRate.Text)
            End If
            If Me.MgrossAmt.Text <> DT.Rows(0).Item("grossamt").ToString.Trim Then
                lstrLog += GfncOneFieldLog("grossamt", DT.Rows(0).Item("grossamt").ToString.Trim, _
                                                Me.MgrossAmt.Text)
            End If
            If Me.MTtype.Text <> DT.Rows(0).Item("ttype").ToString.Trim Then
                lstrLog += GfncOneFieldLog("tradetype", DT.Rows(0).Item("ttype").ToString.Trim, _
                                                                Me.MTtype.Text)
            End If
        End If
        Return lstrLog
    End Function

    Public Function GfncOneFieldLog(ByVal lstrTitle As String, ByVal lstrFm As String, _
           Optional ByVal lstrTo As String = Nothing) As String

        If IsNothing(lstrTo) Then
            Return "[" & lstrTitle.Trim & "]='" & lstrFm.Trim & "'"
        Else
            Return "[" & lstrTitle.Trim & "]='" & lstrFm.Trim & "' To '" & lstrTo.Trim & "' "
        End If

    End Function

    Private Sub MyButtonDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonDel.Click
        Dim Sql As String
        Dim action As String = ""
        Dim type As Integer

        If Me.CommTradeGrid.SelectedRows.Count > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Dim log As String
            'delete
            If GetAdjCode(GFncNoNullString(Me.CommTradeGrid.CurrentRow.Cells("adjaction").Value)) <> "D" Then
                Dim newestValDT As DataTable = cls.GetNewestVal(Me.MOid.Text.Trim)
                If newestValDT.Rows(0).Item("ttype") = "I-trade" Then
                    type = 4
                Else
                    type = 0
                End If

                If newestValDT.Rows.Count <= 0 Then
                    GSubShowError(GFncGetSysMsg(14))
                    Return
                End If
                If newestValDT.Rows(0).Item("adjaction") = "Deleted" Then 'return when it is already deleted
                    GSubShowError(GFncGetSysMsg(14))
                    Return
                End If


                If GFncNoNullString(newestValDT.Rows(0).Item("adjaction")) = "New" Then
                    action = GfncOneFieldLog("adjaction", GetAdjCode(GFncNoNullString(newestValDT.Rows(0).Item("adjaction"))), "D")
                End If
                log = "'" & GStrloginID & "', GETDATE(), 'D', 'CommAdj', '" & _
                                    newestValDT.Rows(0).Item("aeno") & "', '" & newestValDT.Rows(0).Item("accno") & "', '" & Format(newestValDT.Rows(0).Item("tdate"), "MM/dd/yyyy") & "', " & _
                                    "'" & newestValDT.Rows(0).Item("oid") & "', '" & newestValDT.Rows(0).Item("txmonth") & "', '" & GFncSqlQuote(action) & "'"
                If newestValDT.Rows(0).Item("adjaction") <> "" Then
                    If newestValDT.Rows(0).Item("adjaction") = "New" Then
                        ' Physically delete Newly add record
                        cls.DelNewRec(newestValDT.Rows(0).Item("oid"), log)
                    Else
                        'Mark delete Adjusted Record
                        cls.delRecord(newestValDT.Rows(0).Item("oid"), log, 1)
                    End If



                Else
                    ' Markdelete UnAdj Rec
                    'gross = newestValDT.Rows(0).Item("avgprice") * Me.MQty.Text
                    Sql = "'" & newestValDT.Rows(0).Item("txmonth") & "', '" & newestValDT.Rows(0).Item("aeno") & "', '" & newestValDT.Rows(0).Item("accno") & "', '" & _
                                Format(newestValDT.Rows(0).Item("tdate"), "MM/dd/yyyy") & "', '" & newestValDT.Rows(0).Item("oid") & "', '" & newestValDT.Rows(0).Item("stk") & "', " & _
                                newestValDT.Rows(0).Item("avgprice") & ", " & newestValDT.Rows(0).Item("qty") & ", " & newestValDT.Rows(0).Item("grossamt") & "," & newestValDT.Rows(0).Item("comm") & ", " & _
                                newestValDT.Rows(0).Item("comm_rate") & ", '" & type & "' , GETDATE(), " & _
                                " '" & GStrloginID & "'" & ", 'D', '" & "" & "', '" & "" & "' "
                    cls.delRecord(Sql, log, 0)
                End If
            Else
                'restore
                If GSubShowYNConfirm(GFncGetSysMsg(41), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Dim newestValDT As DataTable = cls.GetNewestVal(Me.MOid.Text.Trim)
                If newestValDT.Rows(0).Item("ttype") = "I-trade" Then
                    type = 4
                Else
                    type = 0
                End If
                If newestValDT.Rows.Count <= 0 Then
                    GSubShowError(GFncGetSysMsg(38))
                    Return
                End If
                If newestValDT.Rows(0).Item("adjaction") <> "Deleted" Then 'return when it is not deleted
                    GSubShowError(GFncGetSysMsg(38))
                    Return
                End If

                Dim PreAction As String '= cls.ReStoreDel(Me.CommTradeGrid.CurrentRow.Cells("oid").Value.ToString.Trim).ToUpper
                PreAction = "M"

                action = GfncOneFieldLog("adjaction", GetAdjCode(newestValDT.Rows(0).Item("adjaction")), PreAction)

                log = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommAdj', '" & _
                                                    newestValDT.Rows(0).Item("aeno") & "', '" & newestValDT.Rows(0).Item("accno") & "', '" & Format(newestValDT.Rows(0).Item("tdate"), "MM/dd/yyyy") & "', " & _
                                                    "'" & newestValDT.Rows(0).Item("oid") & "', '" & newestValDT.Rows(0).Item("txmonth") & "', '" & GFncSqlQuote(action) & "'"
                Sql = "'" & PreAction & "' where oid = '" & Me.CommTradeGrid.CurrentRow.Cells("oid").Value.ToString.Trim & "'"
                cls.ReStoreDel(Sql, log)
            End If

            EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub MyButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonAdd.Click
        Me.emptyFields()
        EnableObj(True, False, False)
        'Me.MOid.Enabled = True
        stateFlag = "Add"
        Me.MYr.Focus()
    End Sub

    Private Sub MyRadioButtonAdj_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyRadioButtonAdj.CheckedChanged
        If FormLoad = False Then
            If Me.MyRadioButtonAdj.Checked Then
                EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub MPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MPrice.TextChanged
        If Me.MPrice.Enabled = True And Me.MPrice.Text.Length > 0 And Me.MQty.Text.Length > 0 Then
            Me.MgrossAmt.Text = MPrice.Text * MQty.Text
        End If
    End Sub

    Private Sub MQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MQty.TextChanged
        If Me.MQty.Enabled = True And Me.MPrice.Text.Length > 0 And Me.MQty.Text.Length > 0 Then
            Me.MgrossAmt.Text = MPrice.Text * MQty.Text
        End If
    End Sub

    Private Sub MyRadioButtonAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyRadioButtonAll.CheckedChanged
        If FormLoad = False Then
            If Me.MyRadioButtonAll.Checked Then
                If Me.MYr.Text.Length > 0 And Me.MMonth.Text.Length > 0 Then
                    EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
                End If
            End If
        End If
    End Sub

    Private Sub MyRadioButtonDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyRadioButtonDel.CheckedChanged
        If FormLoad = False Then
            If Me.MyRadioButtonDel.Checked Then
                If Me.MYr.Text.Length > 0 And Me.MMonth.Text.Length > 0 Then
                    EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
                End If
            End If
        End If
    End Sub

    Private Function Validation() As String
        Dim warning As String = ""
        If MOid.Text = "" And stateFlag <> "Add" Then
            warning += " OID,"
            MOid.Focus()
        End If
        If Me.MAE.Text = "" Then
            warning += " AE,"
            MAE.Focus()
        End If
        If MAC.Text = "" Then
            warning += " AC,"
            MAC.Focus()
        End If
        If Me.MStk.Text = "" And stateFlag <> "Add" Then
            warning += " Stock,"
            MStk.Focus()
        End If
        If Me.MPrice.Text = "" Then
            warning += " Avg Price,"
            MPrice.Focus()
        End If
        If Me.MQty.Text = "" Then
            warning += " Quantity,"
            MQty.Focus()
        End If
        If Me.MgrossAmt.Text = "" Then
            warning += " Gross Amount,"
            MgrossAmt.Focus()
        End If
        If Me.MComm.Text = "" Then
            warning += " Commission,"
            MComm.Focus()
        End If
        If Me.MCommRate.Text = "" Then
            warning += " Commission Rate,"
            MCommRate.Focus()
        End If
        If Me.MTtype.Text = "" Then
            warning += " Trade Type,"
            MTtype.Focus()
        End If
        If warning.Length > 0 Then
            Return warning.Substring(0, warning.Length - 1)
        End If
        Return ""
    End Function

    Private Sub lsubGoRecord()

        For lintCnt As Integer = 0 To Me.CommTradeGrid.Rows.Count - 1
            If Me.CommTradeGrid.Rows(lintCnt).Cells("oid").Value.ToString.Trim = myObj Then
                Me.CommTradeGrid.Rows(lintCnt).Cells(0).Selected = True
                Me.CommTradeGrid.Focus()
                Exit For
            End If
            'If strName <> "" Then
            '    If Me.dgdLeave.Rows(lintCnt).Cells("l_staff").Value = strName.Trim Then
            '        Me.dgdLeave.Rows(lintCnt).Cells(0).Selected = True
            '        Me.dgdLeave.Focus()
            '        Exit For
            '    End If
            'End If
        Next
        myObj = ""
    End Sub

    Private Function GetAdjCode(ByVal inadj As String) As String
        Select Case inadj
            Case "New"
                Return "A"
            Case "Adjusted"
                Return "M"
            Case "Deleted"
                Return "D"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub CboAdjSYr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAdjSYr.SelectedIndexChanged, CboAdjSMonth.SelectedIndexChanged
        If FormLoad = False Then
            If Me.tc.SelectedTab().Name() = "tp1" And Me.CboAdjSYr.Text.Length > 0 And Me.CboAdjSMonth.Text.Length > 0 Then
                EnqToolStripButton_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub tc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tc.SelectedIndexChanged
        If Me.tc.SelectedTab().Name() = "tp2" Then
            PanelButton.Enabled = False
        Else
            PanelButton.Enabled = True
        End If
    End Sub

    Private Sub GetAeAcCode()
        'MAE.Items.Add("")
        Dim dt As DataTable = cls.GetAeCode
        For Each dr As DataRow In dt.Rows
            MAE.Items.Add(dr.Item(0).ToString.Trim)
        Next
        'MAC.Items.Add("")
        dt = cls.GetAcCode
        For Each dr As DataRow In dt.Rows
            MAC.Items.Add(dr.Item(0).ToString.Trim)
        Next
    End Sub
  
    Private Sub MAC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MAC.SelectedIndexChanged
        Me.txtAcName.Text = cls.GetAcName(MAC.Text)
    End Sub

    Private Sub MAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MAE.SelectedIndexChanged
        Me.txtAeName.Text = cls.GetAeName(MAE.Text)
    End Sub

End Class
